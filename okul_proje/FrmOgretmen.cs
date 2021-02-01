using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace okul_proje
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmkulup fr = new frmkulup();
            fr.Show();
            
        }

        private void btnders_Click(object sender, EventArgs e)
        {
            frmdersler ft = new frmdersler();
            ft.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmogrenci ft = new frmogrenci();
            ft.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmsinavnotları fr = new frmsinavnotları();
            fr.Show();

        }
    }
}
