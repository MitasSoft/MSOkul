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

namespace Okul
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=BT02589;Initial Catalog=Okul;Integrated Security=True");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select DersAd, Sınav1, Sınav2, Sınav3, Proje, Ortalama, Durum From Tbl_Notlar inner join Tbl_Dersler on Tbl_Dersler.Dersid = Tbl_Notlar.Dersid where Ogrid = @p1", bgl);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("Select OgrAd, OgrSoyad from Tbl_Ogrenciler where Ogrid = @p2",bgl);
            komut2.Parameters.AddWithValue("@p2", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0].ToString() + " " + dr[1].ToString();
            }
            bgl.Close();

            
        }
    }
}
