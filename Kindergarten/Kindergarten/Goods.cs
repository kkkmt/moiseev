using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten
{
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
