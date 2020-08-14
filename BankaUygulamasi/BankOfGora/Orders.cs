using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUygulamasi
{
    public class Order
    {
        public int BaseId { get; set; }
        public int TargetId { get; set; }
        public int currencyId { get; set; }
        public double MoneyCount { get; set; }

        public Order(int bi,int ti,int ci,double mc)
        {
            BaseId = bi;
            TargetId = ti;
            currencyId = ci;
            MoneyCount = mc;

        }
    }

}
