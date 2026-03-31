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
    public partial class RecenzijaForma : Form
    {
        private RecenzijaBiznis recenzijaBiznis = new RecenzijaBiznis();
        private FilmDTO trenutniFilm;
        public RecenzijaForma(FilmDTO film)
        {
            InitializeComponent();
            trenutniFilm = film;
            lbNaslov.Text = "Recenzije filma: " + trenutniFilm.Naziv;
        }

        private void RecenzijaForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            try
            {
                dgvRecenzije.DataSource = recenzijaBiznis.GetAll(trenutniFilm.IdFilm);
                dgvRecenzije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvRecenzije.Columns["IdRecenzije"].Visible = false;
                dgvRecenzije.Columns["IdFilm"].Visible = false;

                dgvRecenzije.Columns["TekstRecenzije"].HeaderText = "Tekst recenzije";
                dgvRecenzije.Columns["DatumRecenzije"].HeaderText = "Datum recenzije";

                dgvRecenzije.Columns["TekstRecenzije"].FillWeight = 300;
                dgvRecenzije.Columns["Ocena"].FillWeight = 50;
                dgvRecenzije.Columns["DatumRecenzije"].FillWeight = 100;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju: " + ex.Message,
                   "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            RecenzijaDetaljiForma forma = new RecenzijaDetaljiForma(trenutniFilm);
            forma.ShowDialog();
            UcitajPodatke();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if(dgvRecenzije.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite jednu recenziju za izmenu!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            RecenzijaDTO selektovana = (RecenzijaDTO)dgvRecenzije.SelectedRows[0].DataBoundItem;
            RecenzijaDetaljiForma forma = new RecenzijaDetaljiForma(trenutniFilm, selektovana);
            forma.ShowDialog();
            UcitajPodatke();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if(dgvRecenzije.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite jednu recenziju za brisanje!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            RecenzijaDTO selektovana = (RecenzijaDTO)dgvRecenzije.SelectedRows[0].DataBoundItem;

            DialogResult potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovu recenziju?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(potvrda == DialogResult.Yes)
            {
                try
                {
                    recenzijaBiznis.Delete(selektovana.IdRecenzije);
                    MessageBox.Show("Recenzija uspesno obrisana!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcitajPodatke();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
