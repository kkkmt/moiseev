using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;

namespace Kindergarten
{
    public class Sql
    {
        MySqlConnection connect = new MySqlConnection();

        private MySqlDataReader sqlRequestReader(String request)
        {
            MySqlCommand command = connect.CreateCommand();
            command.CommandText = request;
            return command.ExecuteReader();
        }

        private object sqlRequestScalar(String request)
        {
            MySqlCommand command = connect.CreateCommand();
            command.CommandText = request;
            return command.ExecuteScalar();
        }

        private bool sqlRequest(String request)
        {
            try
            {
                MySqlCommand command = connect.CreateCommand();
                command.CommandText = request;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public System.Data.ConnectionState State
        {
            get { return connect.State; }
        }

        public Sql() {}

        public Sql(String server, String login, String password)
        {
            Connect(server, login, password);
        }

        public void Close()
        {
            connect.Close();
        }

        public bool Connect(String server, String login, String password)
        {
            try
            {
                connect.ConnectionString = String.Format("server={0};database=kindergarten;uid={1};password={2};charset=utf8;", server, login, password);
                connect.Open();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        private String DateToStr(DateTime date)
        {
            return date.Year + "." + date.Month + "." + date.Day;
        }

        #region Children

        public List<Child> GetChildren()
        {
            List<Child> Children = new List<Child>();

            MySqlDataReader reader = sqlRequestReader("call GetChildren();");
            while (reader.Read())
            {
                Parent mother = new Parent(reader["MFName"].ToString(), reader["MLName"].ToString(), reader["MPName"].ToString(), reader["MPhone"].ToString());
                Parent father = new Parent(reader["FFName"].ToString(), reader["FLName"].ToString(), reader["FPName"].ToString(), reader["FPhone"].ToString());
                Child child = new Child(Convert.ToUInt32(reader["ID"].ToString()), reader["FName"].ToString(), reader["LName"].ToString(), reader["PName"].ToString(), ((DateTime)reader["Birth"]), reader["Address"].ToString(), reader["Group"].ToString(), mother, father);
                Children.Add(child);
            }
            reader.Close();

            return Children;
        }

        public Child GetChild(UInt32 id)
        {
            Child child = null;

            MySqlDataReader reader = sqlRequestReader(String.Format("CALL GetChild({0});", id));
            while (reader.Read())
            {
                Parent mother = new Parent(reader["MFName"].ToString(), reader["MLName"].ToString(), reader["MPName"].ToString(), reader["MPhone"].ToString());
                Parent father = new Parent(reader["FFName"].ToString(), reader["FLName"].ToString(), reader["FPName"].ToString(), reader["FPhone"].ToString());
                child = new Child(Convert.ToUInt32(reader["ID"].ToString()), reader["FName"].ToString(), reader["LName"].ToString(), reader["PName"].ToString(), ((DateTime)reader["Birth"]), reader["Address"].ToString(), reader["Group"].ToString(), mother, father);
            }
            reader.Close();

            return child;
        }

        public bool SaveEditChild(Child child)
        {
            String s = String.Format("call SaveEditChild('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}');",
                child.ID, child.FName, child.LName, child.PName, DateToStr(child.Birth), child.Address, child.Group,
                child.Mother.FName, child.Mother.LName, child.Mother.PName, child.Mother.Phone,
                child.Father.FName, child.Father.LName, child.Father.PName, child.Father.Phone);
            return sqlRequest(s);
        }

        public UInt32 AddChild(Child child)
        {
            String s = String.Format("select AddChild('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');",
                child.FName, child.LName, child.PName, DateToStr(child.Birth), child.Address, child.Group,
                child.Mother.FName, child.Mother.LName, child.Mother.PName, child.Mother.Phone,
                child.Father.FName, child.Father.LName, child.Father.PName, child.Father.Phone);
            return (UInt32)sqlRequestScalar(s);
        }

        public bool DelChild(UInt32 id)
        {
            return sqlRequest(String.Format("call DelChild({0});", id));
        }

        #endregion

        #region Paymant

        public UInt32 AddPayment(Child child, List<Goods> goods)
        {
            String s = String.Format("select AddPayment('{0}', '{1}');", DateToStr(DateTime.Now), child.LName + " " + child.FName + " " + child.PName + " группа №" + child.Group);
            UInt32 id = (UInt32)sqlRequestScalar(s);
            foreach (Goods gds in goods)
                if (!sqlRequest(String.Format("call AddGoods('{0}', '{1}', '{2}', '{3}', '{4}');", id, gds.Gds, gds.Count, gds.Unit, gds.Price.ToString().Replace(',', '.'))))
                    return 0;
            return id;
        }

        #endregion
    }
}
