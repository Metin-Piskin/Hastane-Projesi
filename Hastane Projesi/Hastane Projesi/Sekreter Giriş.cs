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
    public partial class Sekreter_Giriş : Form
    {
        public Sekreter_Giriş()
        {
            InitializeComponent();
        }
        SqlBağlantısı bgl = new SqlBağlantısı();
        private void BtnGirişYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sekreter Where SekreterTc=@p1 and SekreterSifre=@p2", bgl.bağlantı());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtŞifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Sekreter_Detay frs = new Sekreter_Detay();
                frs.TCno = MskTC.Text;
                frs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC & Şifre", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtŞifre.Clear();
                MskTC.Clear();
                MskTC.Focus();
            }
            bgl.bağlantı().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Girişler gg = new Girişler();
            gg.Show();
            this.Close();
        }
    }
}
