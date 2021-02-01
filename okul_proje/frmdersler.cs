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
    public partial class frmdersler : Form
    {
        public frmdersler()
        {
            InitializeComponent();
        }

        private void frmdersler_MouseHover(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }
        DataSet1TableAdapters.TblDerslerTableAdapter ds = new DataSet1TableAdapters.TblDerslerTableAdapter();
        void listele()
        {
            dataGridView1.DataSource = ds.Derslistesi();
        }
        private void frmdersler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.derselkle(Txtdersad.Text);
            MessageBox.Show("Ders Eklendi");
            listele();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.derssil(byte.Parse(txtdersid.Text));
            MessageBox.Show("Ders Silindi");
            listele();
        }

        private void btnGumcelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(Txtdersad.Text,byte.Parse(txtdersid.Text));
            MessageBox.Show("Ders Güncellendi");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           txtdersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Txtdersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
