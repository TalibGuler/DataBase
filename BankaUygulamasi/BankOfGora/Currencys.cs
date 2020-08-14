using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUygulamasi
{
    public class Currencys
    {
        public double TRYvalue { get; set; }
        public double EURvalue { get; set; }
        public double USDvalue { get; set; }
        public double STRvalue { get; set; }
        public Currencys(double TRY,double USD,double EUR,double STR)
        {
            TRYvalue = TRY;
            USDvalue = USD;
            EURvalue = EUR;
            STRvalue = STR;
        }
    }
}
