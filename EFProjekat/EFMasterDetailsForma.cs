using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace EFProjekat
{
    public partial class EFMasterDetailsForma : Form
    {
        private FilmoviDBEntities db = new FilmoviDBEntities();

        public EFMasterDetailsForma()
        {
            InitializeComponent();
        }

        private void EFMasterDetailsForma_Load(object sender, EventArgs e)
        {
            UcitajZanrove();
        }

        private void UcitajZanrove()
        {
            try
            {
                dgvZanrovi.DataSource = db.Zanrs.ToList();

                foreach (DataGridViewColumn col in dgvZanrovi.Columns)
                    col.Visible = false;

                dgvZanrovi.Columns["IdZanr"].Visible = false;
                dgvZanrovi.Columns["NazivZanra"].Visible = true;
                dgvZanrovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju žanrova: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvZanrovi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvZanrovi.SelectedRows.Count == 0) return;
            if (dgvZanrovi.SelectedRows[0].DataBoundItem == null) return;

            try
            {
                Zanr selektovani = (Zanr)dgvZanrovi.SelectedRows[0].DataBoundItem;
                UcitajFilmove(selektovani.IdZanr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajFilmove(int idZanr)
        {
            try
            {
                dgvFilmovi.DataSource = db.Films
                    .Where(f => f.IdZanr == idZanr)
                    .Include(f => f.Status)
                    .ToList();

                foreach (DataGridViewColumn col in dgvFilmovi.Columns)
                    col.Visible = false;

                dgvFilmovi.Columns["Naziv"].Visible = true;
                dgvFilmovi.Columns["DatumGledanja"].Visible = true;

                dgvFilmovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju filmova: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            if (dgvZanrovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite žanr!",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Zanr selektovani = (Zanr)dgvZanrovi.SelectedRows[0].DataBoundItem;
            EFFilmDetaljiForma forma = new EFFilmDetaljiForma(selektovani.IdZanr);
            forma.ShowDialog();
            UcitajFilmove(selektovani.IdZanr);
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvFilmovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite film za izmenu!",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Zanr selektovaniZanr = (Zanr)dgvZanrovi.SelectedRows[0].DataBoundItem;
            Film selektovaniFilm = (Film)dgvFilmovi.SelectedRows[0].DataBoundItem;
            EFFilmDetaljiForma forma = new EFFilmDetaljiForma(selektovaniZanr.IdZanr, selektovaniFilm);
            forma.ShowDialog();
            UcitajFilmove(selektovaniZanr.IdZanr);
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvFilmovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite film za brisanje!",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Film selektovani = (Film)dgvFilmovi.SelectedRows[0].DataBoundItem;

            DialogResult potvrda = MessageBox.Show(
                "Da li ste sigurni da želite da obrišete film: " + selektovani.Naziv + "?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (potvrda == DialogResult.Yes)
            {
                try
                {
                    if (selektovani.Recenzijas.Count > 0)
                    {
                        MessageBox.Show("Nije moguće obrisati film koji ima recenzije!",
                            "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    db.Films.Remove(selektovani);
                    db.SaveChanges();

                    MessageBox.Show("Film je uspešno obrisan!",
                        "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Zanr selektovaniZanr = (Zanr)dgvZanrovi.SelectedRows[0].DataBoundItem;
                    UcitajFilmove(selektovaniZanr.IdZanr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri brisanju: " + ex.Message,
                        "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEFUpit_Click(object sender, EventArgs e)
        {
            EFUpitForma forma = new EFUpitForma();
            forma.ShowDialog();
        }
    }
}
