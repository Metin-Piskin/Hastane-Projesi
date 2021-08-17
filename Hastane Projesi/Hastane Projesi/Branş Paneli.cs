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
    public partial class Branş_Paneli : Form
    {
        public Branş_Paneli()
        {
            InitializeComponent();
        }
        SqlBağlantısı bgl = new SqlBağlantısı();
        private void Branş_Paneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.bağlantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Branslar (Bransad) values (@b1)", bgl.bağlantı());
            komut.Parameters.AddWithValue("@b1", TxtBranş.Text);
            komut.ExecuteNonQuery();
            bgl.bağlantı().Close();
            MessageBox.Show("Branş Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtİd.Text = dataGridView1.Rows[seçilen].Cells[0].Value.ToString();
            TxtBranş.Text = dataGridView1.Rows[seçilen].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_Branslar Where Bransid=@b1", bgl.bağlantı());
            komut.Parameters.AddWithValue("@b1", Txtİd.Text);
            komut.ExecuteNonQuery();
            bgl.bağlantı().Close();
            MessageBox.Show("Kayıt Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Branslar set BransAd=@d1 where bransid=@d2", bgl.bağlantı());
            komut.Parameters.AddWithValue("@d1", TxtBranş.Text);
            komut.Parameters.AddWithValue("@d2", Txtİd.Text);
            komut.ExecuteNonQuery();
            bgl.bağlantı().Close();
            MessageBox.Show("Branşlar Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From  Tbl_Branslar", bgl.bağlantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            TxtBranş.Clear();
            Txtİd.Clear();
            TxtBranş.Focus();
        }
    }
}
