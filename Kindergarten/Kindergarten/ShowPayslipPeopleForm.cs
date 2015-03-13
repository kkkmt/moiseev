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
    public partial class ShowPayslipPeopleForm : Form
    {
        public List<PayslipPeople> List
        {
            set
            {
                listView1.Items.Clear();
                foreach (PayslipPeople people in value)
                {
                    ListViewItem item = new ListViewItem(new String[] { people.Name, people.Post, people.Salary.ToString(), people.WorkedDays.ToString() });
                    listView1.Items.Add(item);
                }
            }
        }

        public ShowPayslipPeopleForm()
        {
            InitializeComponent();
        }

        private void ShowPayslipPeopleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
