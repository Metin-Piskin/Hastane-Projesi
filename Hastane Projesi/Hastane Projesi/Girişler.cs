using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Projesi
{
    public partial class Girişler : Form
    {
        public Girişler()
        {
            InitializeComponent();
        }

        private void BtnHastaGiriş_Click(object sender, EventArgs e)
        {
            Hasta_Giriş fr = new Hasta_Giriş();
            fr.Show();
            this.Hide();

        }

        private void BtnDoktorGirişi_Click(object sender, EventArgs e)
        {
            Doktor_Giriş fr = new Doktor_Giriş();
            fr.Show();
            this.Hide();
        }

        private void BtnSekreteGirişi_Click(object sender, EventArgs e)
        {
            Sekreter_Giriş fr = new Sekreter_Giriş();
            fr.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
