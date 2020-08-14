using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUygulamasi
{
    public class Faiz
    {
        Connections connections = new Connections();
        public double FaizDegeri { get; set; }
        public FaizType faizType { get; set; }
        public int FaizTypeId { get; set; }
        public string Name { get; set; }

        public Faiz(double f, int fti)
        {
            FaizDegeri = f;
            FaizTypeId = fti;
            getTypeName(FaizTypeId);
            Name = faizType.Name;
        }
        public void getTypeName(int id)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(connections.getSomeRequest("FAIZ TURU", id), conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    FaizType ft = new FaizType(dr[1].ToString());
                    faizType = ft;
                    conn.Close();
                }

                conn.Close();
            }
            catch
            {

            }
        }


    }
    public class FaizType
    {
        public string Name { get; set; }
        public FaizType(string s)
        {
            Name = s;
        }
    }
}
