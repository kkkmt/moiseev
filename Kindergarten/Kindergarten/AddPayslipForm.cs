using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class AddPayslipForm : Form
    {
        //List<PayslipPeople> list = new List<PayslipPeople>();
        public List<PayslipPeople> list
        {
            set
            {
                foreach (PayslipPeople people in value)
                    listBoxName.Items.Add(people);
            }
            get
            {
                List<PayslipPeople> list = new List<PayslipPeople>();

                foreach (ListViewItem item in listViewPayslip.Items)
                    list.Add((PayslipPeople)item.Tag);

                return list;
            }
        }

        public AddPayslipForm()
        {
            InitializeComponent();
        }
    }
}
