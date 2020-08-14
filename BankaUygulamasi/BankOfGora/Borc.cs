using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaUygulamasi
{
    public partial class Borc : Form
    {
        public Account hesap;
        public User user;
        Connections connections = new Connections();
        public Borc()
        {
            InitializeComponent();
        }

        private void Borc_Load(object sender, EventArgs e)
        {
            NpgsqlConnection conn5 = new NpgsqlConnection(connections.connstringDB);
            conn5.Open();
            NpgsqlCommand cmd5 = new NpgsqlCommand("SELECT * FROM \"public\".\"BORCLAR\" WHERE \"HesapId\" = "+user.HesapId+";", conn5);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd5);

            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            conn5.Close();

            //string sqlConn = "server=localhost; database=Veritabani; trusted_connection=true;";
            //string cmdText = "select * from tabloadi where kosul order by Alanadi";

            //// Connection ve command olusturmuyoruz.
            //// adaptörün kendisi bu nesneleri bizim yerimize olusturuyor.
            //DataAdapter da = new DataAdapter(cmdText, sqlConn);

            //DataTable dt = new DataTable();

            //da.Fill(dt);


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
