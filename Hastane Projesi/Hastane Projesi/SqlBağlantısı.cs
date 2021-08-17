using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastane_Projesi
{
    class SqlBağlantısı
    {
        public SqlConnection bağlantı()
        {
            SqlConnection bağlan = new SqlConnection("Data Source=DESKTOP-ATVNEGK;Initial Catalog=HastaneProje;Integrated Security=True");
            bağlan.Open();
            return bağlan;
        }






    }
}
