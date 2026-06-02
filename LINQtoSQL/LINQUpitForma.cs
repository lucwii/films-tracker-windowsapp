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
    public partial class LINQUpitForma : Form
    {
        private FilmoviDBDataContext db = new FilmoviDBDataContext();

        public LINQUpitForma()
        {
            InitializeComponent();
        }

        private void LINQUpitForma_Load(object sender, EventArgs e)
        {
            IzvrsiUpit();
        }

        private void IzvrsiUpit()
        {
            try
            {
                // LEFT OUTER JOIN - svi zanrovi i njihovi filmovi
                // ukljucujuci zanrove koji nemaju filmove
                var rezultat = from z in db.Zanrs
                               join f in db.Films
                               on z.IdZanr equals f.IdZanr
                               into filmovi
                               from film in filmovi.DefaultIfEmpty()
                               select new
                               {
                                   Zanr = z.NazivZanra,
                                   Film = film == null ? "Nema filmova" : film.Naziv,
                                   Datum = film == null ? (DateTime?)null : film.DatumGledanja,
                                   Status = film == null ? "-" : film.Status.NazivStatusa
                               };

                dgvUpit.DataSource = rezultat.ToList();
                dgvUpit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Lepsi nazivi kolona
                dgvUpit.Columns["Zanr"].HeaderText = "Žanr";
                dgvUpit.Columns["Film"].HeaderText = "Naziv filma";
                dgvUpit.Columns["Datum"].HeaderText = "Datum gledanja";
                dgvUpit.Columns["Status"].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri izvršavanju upita: " + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
