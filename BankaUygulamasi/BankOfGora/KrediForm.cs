using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaUygulamasi
{
    public partial class KrediForm : Form
    {
        public Connections connections = new Connections();
        public User userK;
        public Account hesapK;
        public Kredi kredi;
        public Faiz faiz;
        Random rnd = new Random();

        public KrediForm()
        {
            InitializeComponent();
        }

        private void KrediForm_Load(object sender, EventArgs e)
        {
            
            cboxType.Items.Add(kredi.KrediType.Name.Trim());
            lblFaizOrani.Text = faiz.FaizDegeri.ToString();

        }

        private void BtnKrediCek_Click(object sender, EventArgs e)
        {
            int temp = rnd.Next(100, 1000);
            int miktar = Convert.ToInt32(tboxTutar.Text);
            string str2 = "UPDATE \"HESAP\" SET \"ParaMiktari\" = \"ParaMiktari\" +" + Convert.ToDouble(tboxTutar.Text) + " WHERE \"Id\" = '" + userK.HesapId + "'";
            NpgsqlConnection conn2 = new NpgsqlConnection(connections.connstringDB);
            conn2.Open();
            NpgsqlCommand cmd2 = new NpgsqlCommand(str2, conn2);
            NpgsqlCommand cmd5 = new NpgsqlCommand(String.Format("SELECT \"Borclandir\"({0},{1},{2},'{3}')", temp+connections.idsDB, Convert.ToDouble(tboxTutar.Text),userK.HesapId,"Kredi"), conn2);
            cmd5.ExecuteNonQuery();
            NpgsqlCommand cmd3 = new NpgsqlCommand(String.Format("SELECT \"FaizHesabi\"({0},{1},{1})", 1, miktar, Convert.ToDouble(faiz.FaizDegeri)), conn2);
            int deger = Convert.ToInt32(cmd3.ExecuteScalar());

            cmd2.ExecuteNonQueryAsync();
            conn2.Close();
            MessageBox.Show(miktar +" Tutarında  "+cboxType.SelectedItem.ToString()+" Kredisinden Cektiniz\n"+"Geri Odemeniz gereken Tutar = "+deger,"KREDI",MessageBoxButtons.OK);
            HesapForm hf = new HesapForm();
            hf.userH = userK;
            hf.hesap = hesapK;
            hf.Show();
            this.Hide();
        }

    }
}
