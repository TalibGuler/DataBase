using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUygulamasi
{
    public class Payment
    {
        private Connections connections = new Connections();

        public PaymentType pt { get; set; }
        public int PaymentTypeId { get; set; }
        public int BaseId { get; set; }
        public int TargetId { get; set; }
        public double Money { get; set; }
        public Payment(int pti, int bi, int ti, double m)
        {
            PaymentTypeId = pti;
            BaseId = bi;
            TargetId = ti;
            Money = m;
            getTypeName(PaymentTypeId);
        }

        public Payment()
        {
            getTypeName(1);
        }

        public void getTypeName(int id)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(connections.getSomeRequest("ODEME TURU", id), conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    PaymentType ptt = new PaymentType(dr[1].ToString());
                    pt = ptt;
                    conn.Close();
                }

                conn.Close();
            }
            catch
            {

            }
        }
    }
    public class PaymentType
    {
        public string name { get; set; }
        public PaymentType(string n)
        {
            name = n;
        }

    }
}
