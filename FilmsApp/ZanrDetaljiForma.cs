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
    public partial class ZanrDetaljiForma : Form
    {
        private ZanrBiznis zanrBiznis = new ZanrBiznis();
        private ZanrDTO trenutniZanr = null;
        public ZanrDetaljiForma()
        {
            InitializeComponent();
            tbID.Visible = false;
            lbId.Visible = false;
            this.Text = "Upravljanje zanrom";
        }

        public ZanrDetaljiForma(ZanrDTO zanr)
        {
            InitializeComponent();
            trenutniZanr = zanr;

            tbID.Text = zanr.idZanr.ToString();
            tbNaziv.Text = zanr.NazivZanra;
            this.Text = "Upravljanje zanrom";
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                ZanrDTO zanr = new ZanrDTO();
                zanr.NazivZanra = tbNaziv.Text;

                if (trenutniZanr == null)
                {
                    zanrBiznis.Insert(zanr);
                    MessageBox.Show("Žanr je uspešno dodat!",
                        "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    zanr.idZanr = trenutniZanr.idZanr;
                    zanrBiznis.Update(zanr);
                    MessageBox.Show("Žanr je uspešno izmenjen!",
                        "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
