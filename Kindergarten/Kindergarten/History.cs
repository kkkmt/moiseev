using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten
{
    public class History
    {
        public UInt32 ID;
        public DateTime Date;
        public String Events, User;

        public History(UInt32 id, DateTime date, String events, String user)
        {
            ID = id;
            Date = date;
            Events = events;
            User = user;
        }

        public History(History p)
        {
            ID = p.ID;
            Date = p.Date;
            Events = p.Events;
            User = p.User;
        }
    }
}
