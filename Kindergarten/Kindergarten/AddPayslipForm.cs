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
        public Boolean ok = false;

        public List<PayslipPeople> List
        {
            set
            {
                listBoxName.Items.Clear();
                foreach (PayslipPeople people in value)
                    listBoxName.Items.Add(people);
            }
            get
            {
                List<PayslipPeople> list = new List<PayslipPeople>();

                foreach (ListViewItem item in listViewPayslip.Items)
                {
                    PayslipPeople people = new PayslipPeople((UInt32)item.Tag, item.SubItems[0].Text, item.SubItems[1].Text, Convert.ToDouble(item.SubItems[2].Text), Convert.ToUInt32(item.SubItems[3].Text));
                    list.Add(people);
                }

                list.Sort(delegate(PayslipPeople p1, PayslipPeople p2) { return p1.CompareTo(p2); });

                return list;
            }
        }

        public DateTime Date
        {
            set { dateTimePicker1.Value = value; }
            get { return dateTimePicker1.Value; }
        }

        public int Month
        {
            set { comboBox1.SelectedIndex = value - 1; }
            get { return comboBox1.SelectedIndex + 1; }
        }

        public int Year
        {
            set { comboBox2.Text = value.ToString(); }
            get { return Convert.ToInt32(comboBox2.Text); }
        }

        public AddPayslipForm()
        {
            InitializeComponent();
        }

        private void listBoxName_DoubleClick(object sender, EventArgs e)
        {
            foreach (PayslipPeople people in listBoxName.SelectedItems)
            {
                ListViewItem lvItem = new ListViewItem(new String[] { people.Name, people.Post, people.Salary.ToString(), people.WorkedDays == 0 ? "" : people.WorkedDays.ToString() });
                lvItem.Tag = people.ID;
                listViewPayslip.Items.Add(lvItem);
            }

            var item = listBoxName.SelectedItem;
            do
                listBoxName.Items.Remove(item);
            while ((item = listBoxName.SelectedItem) != null);
        }

        private void butLVDel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewPayslip.SelectedItems)
            {
                UInt32 days = Convert.ToUInt32(item.SubItems[3].Text == "" ? "0" : item.SubItems[3].Text);
                PayslipPeople people = new PayslipPeople((UInt32)item.Tag ,item.SubItems[0].Text, item.SubItems[1].Text, Convert.ToDouble(item.SubItems[2].Text), days);
                listBoxName.Items.Add(people);
                listViewPayslip.Items.Remove(item);
            }
        }

        private void contextMenuListBox_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listBoxName.SelectedItems.Count == 0;
        }

        private void contextMenuListView_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listViewPayslip.SelectedItems.Count == 0;
        }

        private void AddPayslipForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = DateTime.Now.Month - 1;

            int year = DateTime.Now.Year;
            for (int i = 0; i != 100; ++i)
                comboBox2.Items.Add((year - i).ToString());
            comboBox2.SelectedIndex = 0;
        }

        private void listViewPayslip_ItemActivate(object sender, EventArgs e)
        {
            EditPayslipPeopleForm f = new EditPayslipPeopleForm();
            if (listViewPayslip.SelectedItems.Count == 1)
            {
                f.Salary = listViewPayslip.SelectedItems[0].SubItems[2].Text;
                f.Days = listViewPayslip.SelectedItems[0].SubItems[3].Text;
            }
            f.ShowDialog();

            if (f.ok)
            {
                foreach (ListViewItem item in listViewPayslip.SelectedItems)
                {
                    if (f.Salary != "")
                        item.SubItems[2].Text = f.Salary;
                    if (f.Days != "")
                        item.SubItems[3].Text = f.Days;
                }
            }
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (listViewPayslip.Items.Count == 0)
                MessageBox.Show("Список пустой!", "Ошибка");
            else
            {
                foreach (ListViewItem item in listViewPayslip.Items)
                    if (item.SubItems[2].Text == "" || item.SubItems[3].Text == "")
                    {
                        MessageBox.Show("Не всё заполнено!", "Ошибка");
                        return;
                    }
                ok = true;
                Close();
            }
        }

        private void AddPayslipForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
