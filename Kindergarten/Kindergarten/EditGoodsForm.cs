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
    public partial class EditGoodsForm : Form
    {
        public Boolean ok = false;

        public String Gds
        {
            set { textBoxGds.Text = value; }
            get { return textBoxGds.Text; }
        }

        public String Count
        {
            set { textBoxCount.Text = value; }
            get { return textBoxCount.Text; }
        }

        public String Unit
        {
            set { textBoxUnit.Text = value; }
            get { return textBoxUnit.Text; }
        }

        public String Price
        {
            set { textBoxPrice.Text = value; }
            get { return textBoxPrice.Text; }
        }

        public EditGoodsForm()
        {
            InitializeComponent();
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
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
            textBox.SelectionStart = position;
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 position = textBox.SelectionStart;
            bool p = false;
            String newStr = "";
            foreach (Char c in textBox.Text)
            {
                if (c >= '0' && c <= '9')
                    newStr += c;
                else if  (c == '.' || c == ',')
                    newStr += '.';
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
            if (Gds.Length == 0 || Count.Length == 0 || Unit.Length == 0 || Price.Length == 0)
                MessageBox.Show("Не все поля заполнены!", "Ошибка");
            else
            {
                ok = true;
                Close();
            }
        }
    }
}
