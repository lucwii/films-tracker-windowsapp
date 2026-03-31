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
    public partial class ZanrForma : Form
    {
        private ZanrBiznis zanrBiznis = new ZanrBiznis();
        public ZanrForma()
        {
            InitializeComponent();
        }

        private void ZanrForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            try
            {
                dgvZanrovi.DataSource = zanrBiznis.GetAll();
                dgvZanrovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvZanrovi.Columns["idZanr"].HeaderText = "ID";
                dgvZanrovi.Columns["NazivZanra"].HeaderText = "Naziv";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri ucitavanju: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            ZanrDetaljiForma zanrDetaljiForma = new ZanrDetaljiForma();
            zanrDetaljiForma.ShowDialog();
            UcitajPodatke();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvZanrovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite žanr za izmenu!",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ZanrDTO selektovani = (ZanrDTO)dgvZanrovi.SelectedRows[0].DataBoundItem;

            ZanrDetaljiForma zanrDetaljiForma = new ZanrDetaljiForma(selektovani);
            zanrDetaljiForma.ShowDialog();
            UcitajPodatke();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvZanrovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite žanr za brisanje!",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ZanrDTO selektovani = (ZanrDTO)dgvZanrovi.SelectedRows[0].DataBoundItem;

            DialogResult potvrda = MessageBox.Show(
                "Da li ste sigurni da želite da obrišete žanr: " + selektovani.NazivZanra + "?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (potvrda == DialogResult.Yes)
            {
                try
                {
                    zanrBiznis.Delete(selektovani.idZanr);
                    MessageBox.Show("Žanr je uspešno obrisan!",
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

        private void btnFilmovi_Click(object sender, EventArgs e)
        {
            if (dgvZanrovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo izaberite žanr!",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ZanrDTO selektovani = (ZanrDTO)dgvZanrovi.SelectedRows[0].DataBoundItem;
            FilmForma forma = new FilmForma(selektovani);
            forma.ShowDialog();
        }
    }
}
