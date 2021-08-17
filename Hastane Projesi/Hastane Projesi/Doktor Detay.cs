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

namespace Hastane_Projesi
{
    public partial class Doktor_Detay : Form
    {
        public Doktor_Detay()
        {
            InitializeComponent();
        }
        SqlBağlantısı bgl = new SqlBağlantısı();
        public string TC;
        private void Doktor_Detay_Load(object sender, EventArgs e)
        {
            LblTc.Text = TC;
            // Ad Soyad Çekme
            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorTC=@p1", bgl.bağlantı());
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1].ToString();
            }
            bgl.bağlantı().Close();
            //Randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuDoktor='" + LblAdSoyad.Text + "'", bgl.bağlantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            Doktor_Bilgi_Düzenle fr = new Doktor_Bilgi_Düzenle();
            fr.TCno = LblTc.Text;
            fr.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular fr = new Duyurular();
            fr.Show();
        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            Girişler gg = new Girişler();
            gg.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;
            RchŞikayet.Text = dataGridView1.Rows[seçilen].Cells[7].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
