using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten
{
    public class Personnel
    {
        public UInt32 ID;
        public String FName, LName, PName, Post;
        public Double Solary;
        public DateTime DateReceipt, DateDismissal;

        public Personnel(UInt32 id, String fName, String lName, String pName, String post, Double solary, DateTime dateReceipt, DateTime dateDismissal)
        {
            ID = id;
            FName = fName;
            LName = lName;
            PName = pName;
            Post = post;
            Solary = solary;
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
            Solary = p.Solary;
            DateReceipt = p.DateReceipt;
            DateDismissal = p.DateDismissal;
        }
    }
}
