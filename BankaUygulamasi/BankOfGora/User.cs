using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUygulamasi
{

    public class User
    {
        private Connections connections = new Connections();
        public UserType userType { get; set; }
        public string username { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string password { get; set; }

        public string Email { get; set; }
        public string TC { get; set; }
        public int HesapId { get; set; }
        public int TipId { get; set; }
        public User(string Susername, string Spassword, string Sname, string Slastname, string Semail, string Stc, int IhesapId, int ItipId)
        {
            username = Susername;
            password = Spassword;
            Name = Sname;
            Lastname = Slastname;
            TC = Stc;
            Email = Semail;
            HesapId = IhesapId;
            TipId = ItipId;
            getTypeName(TipId);
        }
        public void getTypeName(int id)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(connections.getSomeRequest("KULLANICI TIPI", id), conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    UserType ut = new UserType(dr[1].ToString());
                    userType = ut;
                    conn.Close();
                }
                conn.Close();
            }
            catch
            {

            }
        }
    }
    public class UserType
    {
        public string Name { get; set; }
        public UserType(string nameUT)
        {
            Name = nameUT;
        }
    }
}
