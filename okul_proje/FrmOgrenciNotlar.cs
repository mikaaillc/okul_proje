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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MIKAILPC\SQLEXPRESS;Initial Catalog=bonusokul;Integrated Security=True");
        public string numara;
     
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select dersad,sinav1,sinav2,sinav3,proje,ortalama from tblnotlar INNER join TblDersler on TBLNOTLAR.Dersid = TblDersler.Dersid where Ogrenciid = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from TBLOGRENCILER where ogrid=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[1] + " " +dr[2];
            }
            baglanti.Close();
            //this.Text = numara.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
