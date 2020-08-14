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

    public partial class SendMoney : Form
    {
        public Order order;
        public User user;
        public Account hesap;
        public HesapForm hf;
        Connections connections = new Connections();
        Random rnd = new Random();

        public SendMoney()
        {

            InitializeComponent();
        }

        private void SendMoney_Load(object sender, EventArgs e)
        {
            //lblPro.Visible = false;
            pbRun.Step = 20;

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(connections.getAllRequest("HESAP", "HesapAdi"), conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string s = String.Format("{0}", dr.GetString(0));
                        cboxUser.Items.Add(s.Trim());

                    }
                }


                conn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("HATA");
                throw;
            }

        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            pbRun.PerformStep();
            //pbRun.MarqueeAnimationSpeed = 100;
            lblPro.Visible = true;

            //string str = "UPDATE \"HESAP\" SET \"ParaMiktari\" = \"ParaMiktari\" -" + Convert.ToDouble(tboxTutar.Text) + " WHERE \"Id\" = '" + user.HesapId + "'";
            //NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
            //conn.Open();
            //NpgsqlCommand cmd = new NpgsqlCommand(str, conn);
            //// NpgsqlDataReader dr = cmd.ExecuteReader();
            //cmd.ExecuteNonQueryAsync();
            //conn.Close();
            //pbRun.PerformStep();

            NpgsqlConnection conn3 = new NpgsqlConnection(connections.connstringDB);
            conn3.Open();
            NpgsqlCommand cmd3 = new NpgsqlCommand(connections.getSomeRequestName("HESAP", "HesapAdi", cboxUser.SelectedItem.ToString().Trim()), conn3);
            NpgsqlDataReader dr3 = cmd3.ExecuteReader();
            int hesapid = 1;
            if (dr3.Read())
            {
                hesapid = dr3.GetInt32(0);
            }

            conn3.Close();

            NpgsqlConnection conn4 = new NpgsqlConnection(connections.connstringDB);
            conn4.Open();
            NpgsqlCommand cmd7 = new NpgsqlCommand("SELECT \"aktar\"(" + user.HesapId + "," + hesapid + "," + Convert.ToDouble(tboxTutar.Text) + ")", conn4);
            cmd7.ExecuteNonQuery();
            conn4.Close();
 

            int temp = rnd.Next(100, 1000);
            string OrderInsert = String.Format("INSERT INTO \"public\".\"EMIRLER\" VALUES ('{0}','{1}','{2}','{3}','{4}')", temp + connections.idsDB, connections.idsDB, hesapid, hesap.CurrencyId, Convert.ToDouble(tboxTutar.Text));
            string UpdateHesap = String.Format("UPDATE \"public\".\"HESAP\" SET	\"EmirId\" = {0} where \"Id\"={1}", temp + connections.idsDB,user.HesapId);
            NpgsqlConnection connInsert = new NpgsqlConnection(connections.connstringDB);
            connInsert.Open();

            NpgsqlCommand cmd4 = new NpgsqlCommand(OrderInsert, connInsert);
            NpgsqlCommand cmd5 = new NpgsqlCommand(UpdateHesap, connInsert);
            cmd4.ExecuteNonQuery();
            cmd5.ExecuteNonQuery();
            connInsert.Close();


            pbRun.PerformStep();
            pbRun.MarqueeAnimationSpeed = 0;
            lblPro.Visible = false;
            MessageBox.Show(hesap.AName + " Hesabindan " + cboxUser.SelectedItem.ToString().Trim() + " Hesabına " + Convert.ToDouble(tboxTutar.Text).ToString() + " Tutarinda Para Gönderildi", "Para Gonderildi", MessageBoxButtons.OK);
            pbRun.Value = 100;
            hf = new HesapForm();
            hf.userH = user;
            hf.hesap = hesap;
            hf.Show();
            this.Hide();

        }
    }
}
