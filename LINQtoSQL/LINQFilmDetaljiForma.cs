using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQtoSQL
{
    public partial class LINQFilmDetaljiForma : Form
    {
        private FilmoviDBDataContext db = new FilmoviDBDataContext();
        private int trenutniIdZanr;
        private Film trenutniFilm = null;

        // Konstruktor za NOVI film
        public LINQFilmDetaljiForma(int idZanr)
        {
            InitializeComponent();
            trenutniIdZanr = idZanr;
            txtId.Visible = false;
            lblId.Visible = false;
        }

        // Konstruktor za IZMENU
        public LINQFilmDetaljiForma(int idZanr, Film film)
        {
            InitializeComponent();
            trenutniIdZanr = idZanr;
            trenutniFilm = film;

            txtId.Text = film.IdFilm.ToString();
            txtNaziv.Text = film.Naziv;
            if (film.DatumGledanja != null)
                dtpDatum.Value = Convert.ToDateTime(film.DatumGledanja);
        }

        private void LINQFilmDetaljiForma_Load(object sender, EventArgs e)
        {
            UcitajStatuse();
        }

        private void UcitajStatuse()
        {
            try
            {
                cmbStatus.DataSource = db.Status.ToList();
                cmbStatus.DisplayMember = "NazivStatusa";
                cmbStatus.ValueMember = "IdStatus";

                if (trenutniFilm != null)
                    cmbStatus.SelectedValue = trenutniFilm.IdStatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju statusa: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            // Validacija
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Naziv filma je obavezan!",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbStatus.SelectedValue == null)
            {
                MessageBox.Show("Status je obavezan!",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (trenutniFilm == null)
                {
                    // NOVI film kroz stored proceduru
                    db.sp_DodajFilm(
                        txtNaziv.Text,
                        dtpDatum.Value.Date,
                        trenutniIdZanr,
                        (int)cmbStatus.SelectedValue
                    );
                    db.SubmitChanges();
                    MessageBox.Show("Film je uspešno dodat!",
                        "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // IZMENA postojeceg filma
                    trenutniFilm.Naziv = txtNaziv.Text;
                    trenutniFilm.DatumGledanja = dtpDatum.Value.Date;
                    trenutniFilm.IdStatus = (int)cmbStatus.SelectedValue;
                    db.SubmitChanges();
                    MessageBox.Show("Film je uspešno izmenjen!",
                        "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
