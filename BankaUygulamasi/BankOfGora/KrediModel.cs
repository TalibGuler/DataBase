using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUygulamasi
{
    public class Kredi
    {
        Connections connections = new Connections();
        public double KrediDegeri { get; set; }
        public string LastPayDate { get; set; }
        public int FaizId { get; set; }
        public KrediType KrediType { get; set; }
        public int KrediTypeId { get; set; }
        public string Name { get; set; }

        public Kredi(int fi, int kti, string n, double f)
        {
            KrediDegeri = f;
            FaizId = fi;
            KrediTypeId = kti;
            LastPayDate = n;
            getTypeName(KrediTypeId);
            //Name = KrediType.Name;
        }
        public void getTypeName(int id)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(connections.getSomeRequest("KREDI TIPI", id), conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    KrediType ft = new KrediType(dr[1].ToString());
                    KrediType = ft;
                    conn.Close();
                }

                conn.Close();
            }
            catch
            {

            }
        }


    }
    public class KrediType
    {
        public string Name { get; set; }
        public KrediType(string s)
        {
            Name = s;
        }
    }
}
