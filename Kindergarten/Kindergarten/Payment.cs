using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten
{
    public class Payment
    {
        public UInt32 IDPayment;
        public DateTime Date;
        public String Buyer;

        public Payment(UInt32 idPayment, DateTime date, String buyer)
        {
            IDPayment = idPayment;
            Date = date;
            Buyer = buyer;
        }

        public Payment(Payment p)
        {
            IDPayment = p.IDPayment;
            Date = p.Date;
            Buyer = p.Buyer;
        }
    }

    public class Goods
    {
        public String Gds, Unit;
        public Int32 Count;
        public Double Price;

        public Goods(String gds, Int32 count, String unit, Double price)
        {
            Gds = gds;
            Count = count;
            Unit = unit;
            Price = price;
        }

        public Goods(Goods g)
        {
            Gds = g.Gds;
            Count = g.Count;
            Unit = g.Unit;
            Price = g.Price;
        }
    }
}
