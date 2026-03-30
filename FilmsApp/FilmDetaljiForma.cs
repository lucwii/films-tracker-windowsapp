using Biznis;
using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmsApp
{
    public partial class FilmDetaljiForma : Form
    {
        private FilmBiznis filmBiznis = new FilmBiznis();
        private StatusDAL statusDAL = new StatusDAL();
        private ZanrDTO trenutniZanr;
        private FilmDTO trenutniFilm = null;
        public FilmDetaljiForma(ZanrDTO zanr)
        {
            InitializeComponent();
            trenutniZanr = zanr;
            tbId.Visible = false;
            lbId.Visible = false;
        }

        public FilmDetaljiForma(ZanrDTO zanr, FilmDTO film)
        {
            InitializeComponent();
            trenutniZanr = zanr;
            trenutniFilm = film;

            tbId.Text = film.IdFilm.ToString();
            tbNaziv.Text = film.Naziv;
            dtpDatum.Value = film.DatumGledanja;
        }

        private void FilmDetaljiForma_Load(object sender, EventArgs e)
        {
            UcitajStatuse();
        }

        private void UcitajStatuse()
        {
            try
            {
                var statusi = statusDAL.GetAll();
                cbStatus.DataSource = statusi;
                cbStatus.DisplayMember = "NazivStatusa";
                cbStatus.ValueMember = "IdStatus";

                if(trenutniFilm != null)
                {
                    cbStatus.SelectedValue = trenutniFilm.IdStatus;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju statusa: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                FilmDTO film = new FilmDTO();
                film.Naziv = tbNaziv.Text;
                film.DatumGledanja = dtpDatum.Value.Date;
                film.IdZanr = trenutniZanr.idZanr;
                film.IdStatus = (int)cbStatus.SelectedValue;

                if (trenutniFilm == null)
                {
                    filmBiznis.Insert(film);
                    MessageBox.Show("Film je uspešno dodat!",
                        "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    film.IdFilm = trenutniFilm.IdFilm;
                    filmBiznis.Update(film);
                    MessageBox.Show("Film je uspešno izmenjen!",
                        "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
