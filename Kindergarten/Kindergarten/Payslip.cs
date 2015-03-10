using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten
{
    public class Payslip
    {
        public UInt32 ID;
        public DateTime Date, ReportingFrom, ReportingTo;

        public Payslip(UInt32 id, DateTime date, DateTime reportingFrom, DateTime reportingTo)
        {
            ID = id;
            Date = date;
            ReportingFrom = reportingFrom;
            ReportingTo = reportingTo;
        }

        public Payslip(Payslip p)
        {
            ID = p.ID;
            Date = p.Date;
            ReportingFrom = p.ReportingFrom;
            ReportingTo = p.ReportingTo;
        }
    }

    public class PayslipPeople
    {
        public UInt32 IDPerson, IDPayslip;
        public String Name, Post;
        public Double Salary;
        public UInt32 WorkedDays;

        public PayslipPeople(UInt32 idPerson, UInt32 idPayslip, String name, String post, Double salary, UInt32 workedDays)
        {
            IDPerson = idPerson;
            IDPayslip = idPayslip;
            Name = name;
            Post = post;
            Salary = salary;
            WorkedDays = workedDays;
        }

        public PayslipPeople(PayslipPeople p)
        {
            IDPerson = p.IDPerson;
            IDPayslip = p.IDPayslip;
            Name = p.Name;
            Post = p.Post;
            Salary = p.Salary;
            WorkedDays = p.WorkedDays;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
