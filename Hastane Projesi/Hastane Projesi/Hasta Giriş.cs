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
    public partial class Hasta_Giriş : Form
    {
        public Hasta_Giriş()
        {
            InitializeComponent();
        }
        SqlBağlantısı bgl = new SqlBağlantısı();
        private void LnkÜyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hasta_Kayıt fr = new Hasta_Kayıt();
            fr.Show();
        }

        private void BtnGirişYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2", bgl.bağlantı());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtŞifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Hasta_Detay frm = new Hasta_Detay();
                frm.tc = MskTC.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC & Şifre", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
