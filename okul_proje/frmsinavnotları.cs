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
    public partial class frmsinavnotları : Form
    {
        public frmsinavnotları()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Notlistesi(int.Parse(txtogrenciid.Text));
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MIKAILPC\SQLEXPRESS;Initial Catalog=bonusokul;Integrated Security=True");
        private void frmsinavnotları_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Select * from Tbldersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "dersad";
            comboBox1.ValueMember = "dersid";
            comboBox1.DataSource = dt;
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {   notid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtogrenciid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            Txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
         
        }
        int sinav1, sinav3, sinav2, proje;
        double ortalama;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
           
            
            sinav1 = Convert.ToInt16(txtsinav1.Text);
            sinav2 = Convert.ToInt16(txtsinav2.Text);
            sinav3 = Convert.ToInt16(txtsinav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            TxtOrt.Text = ortalama.ToString("0.00");
            if (ortalama >= 50)
            {
                Txtdurum.Text = "True";
            }
            else
            {
                Txtdurum.Text = "False";
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGüncelle(byte.Parse(comboBox1.SelectedValue.ToString()),int.Parse(txtogrenciid.Text), byte.Parse(txtsinav1.Text), byte.Parse(txtsinav2.Text), byte.Parse(txtsinav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrt.Text),bool.Parse(Txtdurum.Text),notid);
        }
    }
}
