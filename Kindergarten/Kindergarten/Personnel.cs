using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten
{
    public class Personnel
    {
        public UInt32 ID = 0;
        public String FName, LName, PName, Post;
        public Double Salary;
        public String DateReceipt, DateDismissal;

        public Personnel(String fName, String lName, String pName, String post, Double salary)
        {
            FName = fName;
            LName = lName;
            PName = pName;
            Post = post;
            Salary = salary;
        }

        public Personnel(UInt32 id, String fName, String lName, String pName, String post, Double salary)
        {
            ID = id;
            FName = fName;
            LName = lName;
            PName = pName;
            Post = post;
            Salary = salary;
        }

        public Personnel(UInt32 id, String fName, String lName, String pName, String post, Double salary, String dateReceipt, String dateDismissal)
        {
            ID = id;
            FName = fName;
            LName = lName;
            PName = pName;
            Post = post;
            Salary = salary;
            DateReceipt = dateReceipt;
            DateDismissal = dateDismissal;
        }

        public Personnel(Personnel p)
        {
            ID = p.ID;
            FName = p.FName;
            LName = p.LName;
            PName = p.PName;
            Post = p.Post;
            Salary = p.Salary;
            DateReceipt = p.DateReceipt;
            DateDismissal = p.DateDismissal;
        }
    }
}
