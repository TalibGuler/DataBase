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
    public partial class LoginPage : Form
    {
        Connections connections = new Connections();
        public LoginPage()
        {
            InitializeComponent();


        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            tboxUserPasswordLogin.PasswordChar = '*';
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            connections.setUserRequests(tboxUserNameLogin.Text, tboxUserPasswordLogin.Text);
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(connections.sqlUserQuery, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    User user = new User(dr[3].ToString(), dr[4].ToString(), dr[7].ToString(), dr[8].ToString(), dr[5].ToString(), dr[6].ToString(), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]));
                    HesapForm hesapForm = new HesapForm();
                    hesapForm.userH = user;
                    hesapForm.Show();
                    this.Hide();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Boyle Bir Kullanıcı Bulunamadı tekrar deneyin","Hata",MessageBoxButtons.OK);
                    conn.Close();
                }
                conn.Close();
            }
            catch
            {

            }

        }

    }
}
