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
    public partial class frmkulup : Form
    {
        public frmkulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MIKAILPC\SQLEXPRESS;Initial Catalog=bonusokul;Integrated Security=True");
        public void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblkulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frmkulup_Load(object sender, EventArgs e)
        {

            liste();

        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblkulupler (kulupad) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", Txtkulupad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            liste();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Txtkulupad.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from tblkulupler where KULUPID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkulupid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp silindi");
            liste();
        }

        private void btnGumcelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update tblkulupler set KULUPAD=@p1 where KULUPID=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", Txtkulupad.Text);
            komut.Parameters.AddWithValue("@p2", txtkulupid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Güncellendi");
            liste();
        }
    }
}
