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
    public partial class PaymentForm : Form
    {
        public Payment p;
        public Account act;
        public User userP;
        public Connections connections = new Connections();
        Random rnd = new Random();
        public PaymentForm()
        {
            InitializeComponent();
            
            cBoxType.Items.Clear();
        }


        private void PaymentForm_Load(object sender, EventArgs e)
        {
            p = new Payment();
            cBoxType.Items.Add(p.pt.name.Trim());
        }

        private void BtnOdemeYap_Click(object sender, EventArgs e)
        {
            if (tboxTutar.Text != "")
            {
                if (act.MoneyCount >= Convert.ToDouble(tboxTutar.Text))
                {
                    int temp = rnd.Next(100, 1000);
                    //string OdemeTrigger = "UPDATE \"HESAP\" SET \"ParaMiktari\" = \"ParaMiktari\" -" + Convert.ToDouble(tboxTutar.Text) + " WHERE \"Id\" = '" + userP.HesapId + "'";
                    string func = String.Format("SELECT \"ode\"({0},{1})",userP.HesapId, Convert.ToDouble(tboxTutar.Text));
                    string UpdateHesap = String.Format("UPDATE \"public\".\"HESAP\" SET	\"OdemeId\" = {0};", temp + connections.idsDB);
                    string addOdeme = String.Format("INSERT INTO \"public\".\"ODEME\"  VALUES( '{0}', '{1}','{2}','{3}', '{4}');", temp + connections.idsDB, '1', connections.idsDB, 1, Convert.ToDouble(tboxTutar.Text));
                    NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
                    conn.Open();

                    NpgsqlCommand cmd4 = new NpgsqlCommand(func, conn);
                    NpgsqlCommand cmd2 = new NpgsqlCommand(UpdateHesap, conn);
                    NpgsqlCommand cmd3 = new NpgsqlCommand(addOdeme, conn);

                    cmd4.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show(cBoxType.Text + " Noktasına \n" + tboxTutar.Text + " Kadar Odeme Yapıldı", "test", MessageBoxButtons.OK);
                    HesapForm hf = new HesapForm();
                    hf.userH = userP;
                    hf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(cBoxType.Text + "için \n" + " Bakiye Yok", "test", MessageBoxButtons.OK);
                    HesapForm hf = new HesapForm();
                    hf.hesap = act;
                    hf.userH = userP;
                    hf.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("islem basarısız tekrar deneyiniz...", "test", MessageBoxButtons.OK);
            }


        }
    }
}
