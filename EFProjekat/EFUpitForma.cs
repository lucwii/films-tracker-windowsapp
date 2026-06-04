using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFProjekat
{
    public partial class EFUpitForma : Form
    {
        private FilmoviDBEntities db = new FilmoviDBEntities();

        public EFUpitForma()
        {
            InitializeComponent();
        }

        private void EFUpitForma_Load(object sender, EventArgs e)
        {
            IzvrsiUpit();
        }

        private void IzvrsiUpit()
        {
            try
            {
                var rezultat = db.Zanrs
                    .Select(z => new
                    {
                        Zanr = z.NazivZanra,
                        BrojFilmova = z.Films.Count(),
                        ProsecnaOcena = z.Films
                            .SelectMany(f => f.Recenzijas)
                            .Average(r => (double?)r.Ocena) ?? 0
                    })
                    .OrderByDescending(x => x.BrojFilmova)
                    .ToList();

                dgvUpit.DataSource = rezultat;
                dgvUpit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvUpit.Columns["Zanr"].HeaderText = "Žanr";
                dgvUpit.Columns["BrojFilmova"].HeaderText = "Broj filmova";
                dgvUpit.Columns["ProsecnaOcena"].HeaderText = "Prosečna ocena";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri izvršavanju upita: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
