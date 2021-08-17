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
    public partial class Bilgi_Düzenle : Form
    {
        public Bilgi_Düzenle()
        {
            InitializeComponent();
        }
        public string TCno;
        SqlBağlantısı bgl = new SqlBağlantısı();
        private void Bilgi_Düzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = TCno;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTc=@p1", bgl.bağlantı());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                //MskTC.Text = dr[3].ToString();
                MskTel.Text = dr[4].ToString();
                TxtŞifre.Text = dr[5].ToString();
                CmbCinsiyet.Text = dr[6].ToString();
            }
            bgl.bağlantı().Close();
        }

        private void BtnBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand kout2 = new SqlCommand("Update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTel=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 Where HastaTC=@p6", bgl.bağlantı());
            kout2.Parameters.AddWithValue("@p1", TxtAd.Text);
            kout2.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            kout2.Parameters.AddWithValue("@p3", MskTel.Text);
            kout2.Parameters.AddWithValue("@p4", TxtŞifre.Text);
            kout2.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
            kout2.Parameters.AddWithValue("@p6", MskTC.Text);
            kout2.ExecuteNonQuery();
            bgl.bağlantı().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
