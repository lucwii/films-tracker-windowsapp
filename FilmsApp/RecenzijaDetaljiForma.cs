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
    public partial class RecenzijaDetaljiForma : Form
    {
        private RecenzijaBiznis recenzijaBiznis = new RecenzijaBiznis();
        private FilmDTO trenutniFilm;
        private RecenzijaDTO trenutnaRecenzija = null;
        public RecenzijaDetaljiForma(FilmDTO film)
        {
            InitializeComponent();
            trenutniFilm = film;
            tbId.Visible = false;
            lbId.Visible = false;
        }

        public RecenzijaDetaljiForma(FilmDTO film, RecenzijaDTO recenzija)
        {
            InitializeComponent();
            trenutniFilm = film;
            trenutnaRecenzija = recenzija;

            tbId.Text = recenzija.IdRecenzije.ToString();
            tbTekst.Text = recenzija.TekstRecenzije;
            numOcena.Value = recenzija.Ocena;
            dtpDatum.Value = recenzija.DatumRecenzije;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                RecenzijaDTO recenzija = new RecenzijaDTO();
                recenzija.TekstRecenzije = tbTekst.Text;
                recenzija.Ocena = (int)numOcena.Value;
                recenzija.DatumRecenzije = dtpDatum.Value.Date;
                recenzija.IdFilm = trenutniFilm.IdFilm;

                if(trenutnaRecenzija == null)
                {
                    recenzijaBiznis.Insert(recenzija);
                    MessageBox.Show("Recenzija je uspesno dodata!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    recenzija.IdRecenzije = trenutnaRecenzija.IdRecenzije;
                    recenzijaBiznis.Update(recenzija);
                    MessageBox.Show("Recenzija je uspesno azurirana!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
