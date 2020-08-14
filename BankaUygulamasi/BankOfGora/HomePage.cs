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
    public partial class HomePage : Form
    {
        LoginPage LoginForm = new LoginPage();
        Connections connections = new Connections();
        RegisterForm registerForm = new RegisterForm();
        public HomePage()
        {
            InitializeComponent();


        }

        private void BtnGoLogin_Click(object sender, EventArgs e)
        {
            LoginForm.Show();
            this.Hide();
        }

        private void BtnGoRegister_Click(object sender, EventArgs e)
        {
            registerForm.Show();
            this.Hide();

        }

        private void HomePage_Load(object sender, EventArgs e)
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
