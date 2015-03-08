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
    public partial class EditPersonnel : Form
    {
        public Boolean ok = false;

        private UInt32 id = 0;

        public Personnel person
        {
            set
            {
                textBoxFName.Text = value.FName;
                textBoxLName.Text = value.LName;
                textBoxPName.Text = value.PName;
                textBoxPost.Text = value.Post;
                textBoxSalary.Text = value.Salary.ToString();
                id = value.ID;
            }
            get 
            {
                Personnel person = new Personnel(id, textBoxFName.Text, textBoxLName.Text, textBoxPName.Text, textBoxPost.Text, Convert.ToDouble(textBoxSalary.Text));
                return person;
            }
        }

        public EditPersonnel()
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
            textBox.SelectionStart = position;
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (textBoxFName.Text.Length == 0 || textBoxLName.Text.Length == 0 || textBoxPName.Text.Length == 0 || textBoxPost.Text.Length == 0 || textBoxSalary.Text.Length == 0)
                MessageBox.Show("Не все поля заполнены!", "Ошибка");
            else
            {
                ok = true;
                Close();
            }
        }

        public void HidenButtons(Boolean enabled)
        {
            textBoxFName.Enabled = enabled;
            textBoxLName.Enabled = enabled;
            textBoxPName.Enabled = enabled;
        }
    }
}
