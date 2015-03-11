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
    public partial class EditPayslipPeopleForm : Form
    {
        public Boolean ok = false;

        public String Salary
        {
            set { textBoxSalary.Text = value; }
            get { return textBoxSalary.Text; }
        }

        public String Days
        {
            set { textBoxDays.Text = value; }
            get { return textBoxDays.Text; }
        }

        public EditPayslipPeopleForm()
        {
            InitializeComponent();
        }

        private void textBoxSalary_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 position = textBox.SelectionStart;
            bool p = false;
            String newStr = "";
            foreach (Char c in textBox.Text)
            {
                if (c >= '0' && c <= '9')
                    newStr += c;
                else if (c == '.' || c == ',')
                    newStr += ',';
                else
                    p = true;
            }
            textBox.Text = newStr;
            if (p)
                --position;
            if (position != -1)
                textBox.SelectionStart = position;
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            ok = true;
            Close();
        }

        private void textBoxDays_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 position = textBox.SelectionStart;
            bool p = false;
            String newStr = "";
            foreach (Char c in textBox.Text)
            {
                if (c >= '0' && c <= '9')
                    newStr += c;
                else
                    p = true;
            }
            textBox.Text = newStr;
            if (p)
                --position;
            if (position != -1)
                textBox.SelectionStart = position;
        }
    }
}
