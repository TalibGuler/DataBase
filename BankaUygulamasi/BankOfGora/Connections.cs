using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace BankaUygulamasi

{

    public class Connections
    {
        public string serverDB { get; set; }
        public string portDB { get; set; }
        public string userIdDB { get; set; }
        public string passwordDB { get; set; }
        public string dbNameDB { get; set; }

        private string connstring;
        public int idsDB { get; set; }
        public string connstringDB { get => connstring; set => connstring = value; }


        public Connections()
        {

            serverDB = "localhost";
            portDB = "5433";
            userIdDB = "postgres";
            passwordDB = "g181210011";
            dbNameDB = "Banka";
            setConnstring();
            idsDB = 100;
            getIDSDB();
        }

        void setConnstring()
        {
            connstringDB = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    serverDB, portDB, userIdDB,
                    passwordDB, dbNameDB);
        }
        public string sqlUserQuery { get; set; }
        public void setUserRequests(string username, string password) => sqlUserQuery = "SELECT * FROM \"public\".\"KULLANICI\" where \"KullaniciAdi\"='" + username + "' AND \"Sifre\"='" + password + "'";

        public string getSomeRequest(string name, int id) => "SELECT * FROM \"public\"."+ "\""+name +"\""+" where \"Id\"='" + id + "'";

        public string getSomeRequestName(string name,string alan, string id) => "SELECT * FROM \"public\"." + "\"" + name + "\"" + " where \""+alan+"\"='" + id + "'";
        public string getAllRequest(string name,string alan) => "SELECT \""+alan+"\" FROM \"public\"." + "\"" + name + "\" ";

        public string addOrderDB(int id, int BaseID, int TargetID, int currencyID, double MC) => String.Format("INSERT INTO \"public\".\"EMIRLER\" VALUES ('{0}','{1}','{2}','{3}','{4}');",id,BaseID,TargetID,currencyID,MC);
        
        public void getIDSDB()
        {
            NpgsqlConnection conn3 = new NpgsqlConnection(connstringDB);
            conn3.Open();
            NpgsqlCommand cmd3 = new NpgsqlCommand("SELECT * FROM \"public\"." + "\"idmaker\"", conn3);
            NpgsqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.Read())
            {
                idsDB = dr3.GetInt32(0);
            }
            conn3.Close();
        }

    }
}
