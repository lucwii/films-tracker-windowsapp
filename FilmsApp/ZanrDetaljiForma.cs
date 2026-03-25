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
            tbNaziv.Visible = false;
        }

        public ZanrDetaljiForma(ZanrDTO zanr)
        {
            InitializeComponent();
            trenutniZanr = zanr;

            tbID.Text = zanr.idZanr.ToString();
            tbNaziv.Text = zanr.NazivZanra;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

        }
    }
}
