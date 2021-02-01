using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace okul_proje
{
    public partial class frmogrenci : Form
    {
        public frmogrenci()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=MIKAILPC\SQLEXPRESS;Initial Catalog=bonusokul;Integrated Security=True");
        private void frmogrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
           

            SqlCommand komut = new SqlCommand("Select * from Tblkulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember="Kulupad";
            comboBox1.ValueMember = "KulupId";
            comboBox1.DataSource = dt;
     



        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string c = "";
        private void button2_Click(object sender, EventArgs e)
        {
            
            
            ds.ogrenciekle(Txtograd.Text, txtogrsoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci Eklendi");
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtogrenciid.Text));
            MessageBox.Show("Öğrenci silindi");
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtogrenciid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Txtograd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtogrsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Erkek")
                {
                    radioButton2.Checked = true;
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Kız")
                {
                    radioButton1.Checked = true;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Öğrenci seç");
            }
            


        }

        private void btnGumcelle_Click(object sender, EventArgs e)
        {
            ds.ogrenciguncelle(Txtograd.Text, txtogrsoyad.Text,byte.Parse(comboBox1.SelectedValue.ToString()), c, int.Parse(txtogrenciid.Text));
            MessageBox.Show("Öğrenci Güncellendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.OgrenciGetir(txtara.Text);
        }
    }
}
