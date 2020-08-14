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
    public partial class RegisterForm : Form
    {
        int count;
        Connections connections = new Connections();
        public RegisterForm()
        {
            InitializeComponent();
            count = 1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (Kontrol())
            {
                try
                {



                    const int ID = 1;
                    string sqlQueryAccount = String.Format("INSERT INTO \"public\".\"HESAP\"  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", connections.idsDB, ID, ID, ID, ID, tboxName.Text + " Hesabi", ID, tboxParaM.Text);
                    string sqlQuery = "INSERT INTO \"public\".\"KULLANICI\" (\"Id\",\"HesapId\",\"KullaniciTipId\",\"KullaniciAdi\",\"Sifre\",\"Email\",\"TC\",\"Isim\",\"Soyisim\") VALUES('" + connections.idsDB + "','" + connections.idsDB + "','" + ID + "','" + tboxUserName.Text + "','" + tboxPassword.Text + "','" + tboxEmail.Text + "','" + tboxTC.Text + "','" + tboxName.Text + "','" + tboxLastname.Text + "');";
                    NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
                    conn.Open();

                    NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, conn);
                    NpgsqlCommand cmd2 = new NpgsqlCommand(sqlQueryAccount, conn);
                    cmd2.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();


                    conn.Close();

                    LoginPage lp = new LoginPage();
                    try
                    {
                        string str2 = "UPDATE \"idmaker\" SET \"ids\" = \"ids\" +" + 1 + "";
                        NpgsqlConnection conn2 = new NpgsqlConnection(connections.connstringDB);
                        conn2.Open();
                        NpgsqlCommand cmd3 = new NpgsqlCommand(str2, conn2);
                        cmd3.ExecuteNonQueryAsync();
                        conn2.Close();
                    }
                    catch (Exception msg)
                    {

                        throw;
                    }

                    lp.Show();
                    this.Hide();
                }
                catch (Exception msg)
                {
                    Console.WriteLine("HATA");

                    throw;
                }
            }
        }

        private bool Kontrol()
        {
            if (tboxName.Text == "")
                MessageBox.Show("isim değeri boş olamaz", "HATA", MessageBoxButtons.YesNoCancel);
            else if (tboxLastname.Text == "")
                MessageBox.Show("Soyisim değeri boş olamaz", "HATA", MessageBoxButtons.YesNoCancel);
            else if (tboxEmail.Text == "")
                MessageBox.Show("Email değeri boş olamaz", "HATA", MessageBoxButtons.YesNoCancel);
            else if (tboxTC.Text == "")
                MessageBox.Show("TC değeri boş olamaz", "HATA", MessageBoxButtons.YesNoCancel);
            else if (tboxUserName.Text == "")
                MessageBox.Show("Kullanıcı Adı değeri boş olamaz", "HATA", MessageBoxButtons.YesNoCancel);
            else if (tboxPassword.Text == "")
                MessageBox.Show("Şifre değeri boş olamaz", "HATA", MessageBoxButtons.YesNoCancel);
            else
            {
                return true;
            }
            return false;


        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {



            NpgsqlConnection conn3 = new NpgsqlConnection(connections.connstringDB);
            conn3.Open();
            NpgsqlCommand cmd3 = new NpgsqlCommand("SELECT * FROM \"public\"." + "\"idmaker\"", conn3);
            NpgsqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.Read())
            {
                connections.idsDB = dr3.GetInt32(0);
            }
            conn3.Close();


        }
    }
}
