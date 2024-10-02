using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Git Test");
            //cc1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtDersAd.Text);
            MessageBox.Show("Ders Eklendi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtDersid.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtDersAd.Text,byte.Parse(txtDersid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
