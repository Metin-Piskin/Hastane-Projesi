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
    public partial class Randevu_Listesi : Form
    {
        public Randevu_Listesi()
        {
            InitializeComponent();
        }
        SqlBağlantısı bgl = new SqlBağlantısı();

        private void Randevu_Listesi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular", bgl.bağlantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
