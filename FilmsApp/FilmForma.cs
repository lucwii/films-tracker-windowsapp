using Biznis;
using DTO;
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
    public partial class FilmForma : Form
    {
        private FilmBiznis filmBiznis = new FilmBiznis();
        private ZanrDTO trenutniZanr;
        public FilmForma(ZanrDTO zanr)
        {
            InitializeComponent();
            trenutniZanr = zanr;
            lbNaslov.Text = "Filmovi zanra: " + zanr.NazivZanra;
            this.Text = "Filmovi";
        }

        private void FilmForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            try
            {
                dgvFilmovi.DataSource = filmBiznis.GetAll(trenutniZanr.idZanr);
                dgvFilmovi.Columns["IdFilm"].Visible = false;
                dgvFilmovi.Columns["IdZanr"].Visible = false;
                dgvFilmovi.Columns["IdStatus"].Visible = false;

                dgvFilmovi.Columns["Naziv"].HeaderText = "Naziv filma";
                dgvFilmovi.Columns["DatumGledanja"].HeaderText = "Datum gledanja";
                dgvFilmovi.Columns["NazivStatusa"].HeaderText = "Status";

                dgvFilmovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvFilmovi.EnableHeadersVisualStyles = false;
                dgvFilmovi.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                dgvFilmovi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvFilmovi.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                dgvFilmovi.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greska pri ucitavanju " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            FilmDetaljiForma forma = new FilmDetaljiForma(trenutniZanr);
            forma.ShowDialog();
            UcitajPodatke();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvFilmovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite film za izmenu!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FilmDTO selektovani = (FilmDTO)dgvFilmovi.SelectedRows[0].DataBoundItem;
            FilmDetaljiForma forma = new FilmDetaljiForma(trenutniZanr, selektovani);
            forma.ShowDialog();
            UcitajPodatke();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvFilmovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite film za izmenu!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FilmDTO selektovani = (FilmDTO)dgvFilmovi.SelectedRows[0].DataBoundItem;

            DialogResult potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete " + selektovani.Naziv + "?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (potvrda == DialogResult.Yes)
            {
                try
                {
                    filmBiznis.Delete(selektovani.IdFilm);
                    MessageBox.Show("Film je uspešno obrisan!",
                        "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcitajPodatke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRecenzije_Click(object sender, EventArgs e)
        {
            if (dgvFilmovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite film za pregled recenzija!",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FilmDTO selektovani = (FilmDTO)dgvFilmovi.SelectedRows[0].DataBoundItem;
            RecenzijaForma forma = new RecenzijaForma(selektovani);
            forma.ShowDialog();
        }
    }
}
