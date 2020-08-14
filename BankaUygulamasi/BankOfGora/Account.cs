using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUygulamasi
{
    public class Account
    {
        private Connections connections = new Connections();
        public AccauntType AT { get; set; }
        public string AName { get; set; }
        public double MoneyCount { get; set; }
        public int CurrencyId { get; set; }
        public int faizId { get; set; }
        public int OrderId { get; set; }
        public int PaymentId { get; set; }
        public int AccTypeId { get; set; }
        public Account(int IcurrencyId, int FaizIDD, int OrderdId, int PaymentID, string Saname, int accTypeIDD, double FmoneyCount)
        {
            AName = Saname;
            MoneyCount = FmoneyCount;
            CurrencyId = IcurrencyId;
            faizId = FaizIDD;
            OrderId = OrderdId;
            PaymentId = PaymentID;
            AccTypeId = accTypeIDD;
            getTypeName(AccTypeId);
        }
        public void getTypeName(int id)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connections.connstringDB);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(connections.getSomeRequest("HESAP TURU", id), conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    AccauntType at = new AccauntType(dr[1].ToString());
                    AT = at;
                    conn.Close();
                }
                conn.Close();
            }
            catch
            {

            }
        }
    }
    public class AccauntType
    {
        public string ATname { get; set; }
        public AccauntType(string n)
        {
            ATname = n;
        }
    }
}
