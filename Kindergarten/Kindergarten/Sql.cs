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

        private MySqlDataReader SqlCommandReader(String request)
        {
            MySqlCommand command = connect.CreateCommand();
            command.CommandText = request;
            return command.ExecuteReader();
        }

        private object SqlCommandScalar(String request)
        {
            MySqlCommand command = connect.CreateCommand();
            command.CommandText = request;
            return command.ExecuteScalar();
        }

        private bool SqlCommand(String request)
        {
            try
            {
                MySqlCommand command = connect.CreateCommand();
                command.CommandText = request;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                String s = ex.Message;
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

            MySqlDataReader reader = SqlCommandReader("SELECT * FROM kindergarten.getchildren;");
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

            MySqlDataReader reader = SqlCommandReader(String.Format("CALL GetChild({0});", id));
            while (reader.Read())
            {
                Parent mother = new Parent(reader["MFName"].ToString(), reader["MLName"].ToString(), reader["MPName"].ToString(), reader["MPhone"].ToString());
                Parent father = new Parent(reader["FFName"].ToString(), reader["FLName"].ToString(), reader["FPName"].ToString(), reader["FPhone"].ToString());
                child = new Child(Convert.ToUInt32(reader["ID"].ToString()), reader["FName"].ToString(), reader["LName"].ToString(), reader["PName"].ToString(), ((DateTime)reader["Birth"]), reader["Address"].ToString(), reader["Group"].ToString(), mother, father);
            }
            reader.Close();

            return child;
        }

        public bool UpdateChild(Child child)
        {
            String s = String.Format("call UpdateChild('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}');",
                child.ID, child.FName, child.LName, child.PName, DateToStr(child.Birth), child.Address, child.Group,
                child.Mother.FName, child.Mother.LName, child.Mother.PName, child.Mother.Phone,
                child.Father.FName, child.Father.LName, child.Father.PName, child.Father.Phone);
            return SqlCommand(s);
        }

        public UInt32 AddChild(Child child)
        {
            String s = String.Format("select AddChild('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}');",
                child.FName, child.LName, child.PName, DateToStr(child.Birth), child.Address, child.Group,
                child.Mother.FName, child.Mother.LName, child.Mother.PName, child.Mother.Phone,
                child.Father.FName, child.Father.LName, child.Father.PName, child.Father.Phone);
            return (UInt32)SqlCommandScalar(s);
        }

        public bool DelChild(UInt32 id)
        {
            return SqlCommand(String.Format("call DelChild({0});", id));
        }

        #endregion

        #region Paymant

        public UInt32 AddPayment(Child child, List<Goods> goods)
        {
            String s = String.Format("select AddPayment('{0}', '{1}');", DateToStr(DateTime.Now), child.LName + " " + child.FName + " " + child.PName + " группа №" + child.Group);
            UInt32 id = (UInt32)SqlCommandScalar(s);
            foreach (Goods gds in goods)
                if (!SqlCommand(String.Format("call AddGoods('{0}', '{1}', '{2}', '{3}', '{4}');", id, gds.Gds, gds.Count, gds.Unit, gds.Price.ToString().Replace(',', '.'))))
                    return 0;
            return id;
        }

        public List<Payment> GetPayments()
        {
            List<Payment> list = new List<Payment>();

            MySqlDataReader reader = SqlCommandReader("SELECT * FROM kindergarten.getpayment;");
            while (reader.Read())
            {
                Payment pay = new Payment(Convert.ToUInt32(reader["ID"].ToString()), ((DateTime)reader["Date"]), reader["Buyer"].ToString());
                list.Add(pay);
            }
            reader.Close();

            return list;
        }

        public List<Goods> GetGoodsByIDPayment(UInt32 IDPayment)
        {
            List<Goods> list = new List<Goods>();

            MySqlDataReader reader = SqlCommandReader(String.Format("call kindergarten.GetGoodsByIDPayment('{0}');", IDPayment));
            while (reader.Read())
            {
                Goods gds = new Goods(reader["Gds"].ToString(), Convert.ToInt32(reader["Count"].ToString()), reader["Unit"].ToString(), Convert.ToDouble(reader["Price"].ToString()));
                list.Add(gds);
            }
            reader.Close();

            return list;
        }

        #endregion

        #region Personnel

        public List<Personnel> GetPersonnel()
        {
            List<Personnel> list = new List<Personnel>();

            MySqlDataReader reader = SqlCommandReader("SELECT * FROM kindergarten.getpersonnel;");
            while (reader.Read())
            {
                Personnel person = new Personnel(Convert.ToUInt32(reader["ID"].ToString()), reader["FName"].ToString(), reader["LName"].ToString(), reader["PName"].ToString(), reader["Post"].ToString(), Convert.ToDouble(reader["Salary"].ToString()), reader["DateReceipt"].ToString(), reader["DateDismissal"].ToString());
                if (person.DateReceipt != "")
                    person.DateReceipt = DateTime.Parse(person.DateReceipt).ToShortDateString();
                if (person.DateDismissal != "")
                    person.DateDismissal = DateTime.Parse(person.DateDismissal).ToShortDateString();
                list.Add(person);
            }
            reader.Close();

            return list;
        }

        public Personnel GetPerson(UInt32 id)
        {
            Personnel person = null;

            MySqlDataReader reader = SqlCommandReader(String.Format("SELECT * FROM kindergarten.getpersonnel WHERE ID = {0};", id));
            while (reader.Read())
            {
                person = new Personnel(Convert.ToUInt32(reader["ID"].ToString()), reader["FName"].ToString(), reader["LName"].ToString(), reader["PName"].ToString(), reader["Post"].ToString(), Convert.ToDouble(reader["Salary"].ToString()), reader["DateReceipt"].ToString(), reader["DateDismissal"].ToString());
                if (person.DateReceipt != "")
                    person.DateReceipt = DateTime.Parse(person.DateReceipt).ToShortDateString();
                if (person.DateDismissal != "")
                    person.DateDismissal = DateTime.Parse(person.DateDismissal).ToShortDateString();
            }
            reader.Close();

            return person;
        }

        public Personnel AddPerson(String fName, String lName, String pName, String post, Double salary)
        {
            return AddPerson(new Personnel(fName, lName, pName, post, salary));
        }

        public Personnel AddPerson(Personnel person)
        {
            String s = String.Format("call kindergarten.AddPerson('{0}', '{1}', '{2}', '{3}', '{4}');", person.FName, person.LName, person.PName, person.Post, person.Salary.ToString().Replace(',', '.'));

            MySqlDataReader reader = SqlCommandReader(s);
            while (reader.Read())
            {
                person.DateReceipt = DateTime.Parse(reader["DateReceipt"].ToString()).ToShortDateString();
                person.ID = Convert.ToUInt32(reader["ID"].ToString());
            }
            reader.Close();

            return person;
        }

        public String DelPerson(UInt32 id)
        {
            String s = String.Format("select DelPerson('{0}');", id);
            return DateTime.Parse(SqlCommandScalar(s).ToString()).ToShortDateString();
        }

        public Personnel DelPerson(Personnel person)
        {
            person.DateDismissal = DelPerson(person.ID);
            return person;
        }

        public bool BringBackPerson(UInt32 id)
        {
            String s = String.Format("call kindergarten.BringBackPerson('{0}');", id);
            return SqlCommand(s);
        }

        public bool UpdatePerson(Personnel person)
        {
            return UpdatePerson(person.ID, person.Post, person.Salary);
        }

        public bool UpdatePerson(UInt32 id, String post, Double salary)
        {
            String s = String.Format("call kindergarten.UpdatePerson('{0}', '{1}', '{2}');", id, post, salary.ToString().Replace(',', '.'));
            return SqlCommand(s);
        }

        #endregion

        #region Payslip

        public List<Payslip> GetPayslip()
        {
            List<Payslip> list = new List<Payslip>();

            MySqlDataReader reader = SqlCommandReader("SELECT * FROM kindergarten.getpayslip;");
            while (reader.Read())
            {
                Payslip pay = new Payslip(Convert.ToUInt32(reader["ID"].ToString()), DateTime.Parse(reader["Date"].ToString()), DateTime.Parse(reader["ReportingFrom"].ToString()), DateTime.Parse(reader["ReportingTo"].ToString()));
                list.Add(pay);
            }
            reader.Close();

            return list;
        }

        public List<PayslipPeople> GetPersonnelForPayslip()
        {
            List<PayslipPeople> list = new List<PayslipPeople>();

            MySqlDataReader reader = SqlCommandReader("SELECT * FROM kindergarten.GetPersonnelForPayslip;");
            while (reader.Read())
            {
                PayslipPeople people = new PayslipPeople(Convert.ToUInt32(reader["ID"].ToString()), reader["Name"].ToString(), reader["Post"].ToString(), Convert.ToDouble(reader["Salary"].ToString()));
                list.Add(people);
            }
            reader.Close();

            return list;
        }

        public List<PayslipPeople> GetPayslipAtID(UInt32 ID)
        {
            List<PayslipPeople> list = new List<PayslipPeople>();

            MySqlDataReader reader = SqlCommandReader(String.Format("call kindergarten.GetPayslipPeopleAtIDPayslip('{0}');", ID));
            while (reader.Read())
            {
                PayslipPeople people = new PayslipPeople(Convert.ToUInt32(reader["IDPerson"].ToString()), reader["Name"].ToString(), reader["Post"].ToString(), Convert.ToDouble(reader["Salary"].ToString()), Convert.ToUInt32(reader["WorkedDays"].ToString()));
                list.Add(people);
            }
            reader.Close();

            return list;
        }

        public UInt32 AddPayslip(DateTime date, DateTime dateFrom, DateTime dateTo, List<PayslipPeople> list)
        {
            String s = String.Format("select kindergarten.AddPayslip('{0}', '{1}', '{2}');", DateToStr(date), DateToStr(dateFrom), DateToStr(dateTo));

            UInt32 id = Convert.ToUInt32(SqlCommandScalar(s).ToString());

            foreach (PayslipPeople people in list)
            {
                s = String.Format("call kindergarten.AddPayslipPeople('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", id, people.ID, people.Name, people.Post, people.Salary.ToString().Replace(',', '.'), people.WorkedDays);
                if (!SqlCommand(s))
                   return 0;
            }

            return id;
        }

        #endregion

        #region

        public List<History> GetHistory()
        {
            List<History> list = new List<History>();

            MySqlDataReader reader = SqlCommandReader("SELECT * FROM kindergarten.gethistory;");
            while (reader.Read())
            {
                History history = new History(Convert.ToUInt32(reader["ID"].ToString()), DateTime.Parse(reader["Date"].ToString()), reader["Events"].ToString(), reader["User"].ToString());
                list.Add(history);
            }
            reader.Close();

            return list;
        }

        #endregion
    }
}
