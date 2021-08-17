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
    public partial class Doktor_Bilgi_Düzenle : Form
    {
        public Doktor_Bilgi_Düzenle()
        {
            InitializeComponent();
        }
        SqlBağlantısı bgl = new SqlBağlantısı();
        public string TCno;
        private void Doktor_Bilgi_Düzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = TCno;

            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar Where DoktorTc=@p1", bgl.bağlantı());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                CmbBranş.Text = dr[3].ToString();
                TxtŞifre.Text = dr[5].ToString();
            }
            bgl.bağlantı().Close();
        }

        private void BtnBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand kout2 = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 Where DoktorTC=@p5", bgl.bağlantı());
            kout2.Parameters.AddWithValue("@p1", TxtAd.Text);
            kout2.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            kout2.Parameters.AddWithValue("@p3", CmbBranş.Text);
            kout2.Parameters.AddWithValue("@p4", TxtŞifre.Text);
            kout2.Parameters.AddWithValue("@p5", MskTC.Text);
            kout2.ExecuteNonQuery();
            bgl.bağlantı().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
