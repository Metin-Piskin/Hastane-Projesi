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
    public partial class Sekreter_Detay : Form
    {
        public Sekreter_Detay()
        {
            InitializeComponent();
        }
        public string TCno;
        SqlBağlantısı bgl = new SqlBağlantısı();
        private void Sekreter_Detay_Load(object sender, EventArgs e)
        {
            LblTc.Text = TCno;
            // Ad Soyad Çekme
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter Where SekreterTC=@p1", bgl.bağlantı());
            komut1.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.bağlantı().Close();
            //Branşları Datagride Aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.bağlantı());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            //Doktor Bİlgilerini Çekme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd +' '+ DoktorSoyad) as 'Doktorlar',DoktorBrans From Tbl_Doktorlar", bgl.bağlantı());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            //Branşları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.bağlantı());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBranş.Items.Add(dr2[0]);
            }
            bgl.bağlantı().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)", bgl.bağlantı());
            komutkaydet.Parameters.AddWithValue("@r1", MskTarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", MskSaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", CmbBranş.Text);
            komutkaydet.Parameters.AddWithValue("@r4", CmbDoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.bağlantı().Close();
            MessageBox.Show("Randevu Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmbBranş_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.bağlantı());
            komut.Parameters.AddWithValue("@p1", CmbBranş.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.bağlantı().Close();
        }

        private void BtnDuyuruOluştur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)", bgl.bağlantı());
            komut.Parameters.AddWithValue("@d1", RchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.bağlantı().Close();
            MessageBox.Show("Duyuru Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDoktorPaneli_Click(object sender, EventArgs e)
        {
            Doktor_Paneli drp = new Doktor_Paneli();
            drp.Show();
        }

        private void BtnBranşPaneli_Click(object sender, EventArgs e)
        {
            Branş_Paneli brp = new Branş_Paneli();
            brp.Show();
        }

        private void BtnRandevuListe_Click(object sender, EventArgs e)
        {
            Randevu_Listesi rrp = new Randevu_Listesi();
            rrp.Show();
        }

        private void BtnDuyuru_Click(object sender, EventArgs e)
        {
            Duyurular dg = new Duyurular();
            dg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Girişler gg = new Girişler();
            gg.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
