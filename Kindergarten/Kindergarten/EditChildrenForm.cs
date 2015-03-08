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
    public partial class EditChildrenForm : Form
    {
        #region children

        private String FName
        {
            set { textBoxFName.Text = value; }
            get { return textBoxFName.Text; }
        }

        private String LName
        {
            set { textBoxLName.Text = value; }
            get { return textBoxLName.Text; }
        }

        private String PName
        {
            set { textBoxPName.Text = value; }
            get { return textBoxPName.Text; }
        }

        private DateTime Birth
        {
            set
            {
                comboBoxYear.Text = value.Year.ToString();
                comboBoxMonth.SelectedIndex = value.Month - 1;
                comboBoxDay.SelectedIndex = value.Day - 1;
            }
            get 
            {
                return new DateTime(Convert.ToInt32(comboBoxYear.Text), comboBoxMonth.SelectedIndex + 1, Convert.ToInt32(comboBoxDay.Text));
            }
        }

        private String Address
        {
            set { textBoxAddress.Text = value; }
            get { return textBoxAddress.Text; }
        }

        private String Group
        {
            set { textBoxGroup.Text = value; }
            get { return textBoxGroup.Text; }
        }

        #endregion

        #region mother

        private String MFName
        {
            set { textBoxMFName.Text = value; }
            get { return textBoxMFName.Text; }
        }

        private String MLName
        {
            set { textBoxMLName.Text = value; }
            get { return textBoxMLName.Text; }
        }

        private String MPName
        {
            set { textBoxMPName.Text = value; }
            get { return textBoxMPName.Text; }
        }

        private String MPhone
        {
            set { textBoxMPhone.Text = value; }
            get { return textBoxMPhone.Text; }
        }

        #endregion

        #region father

        private String FFName
        {
            set { textBoxFFName.Text = value; }
            get { return textBoxFFName.Text; }
        }

        private String FLName
        {
            set { textBoxFLName.Text = value; }
            get { return textBoxFLName.Text; }
        }

        private String FPName
        {
            set { textBoxFPName.Text = value; }
            get { return textBoxFPName.Text; }
        }

        private String FPhone
        {
            set { textBoxFPhone.Text = value; }
            get { return textBoxFPhone.Text; }
        }

        #endregion

        public Child child
        {
            set
            {
                FName = value.FName;
                LName = value.LName;
                PName = value.PName;
                Birth = value.Birth;
                Address = value.Address;
                Group = value.Group;
                MFName = value.Mother.FName;
                MLName = value.Mother.LName;
                MPName = value.Mother.PName;
                MPhone = value.Mother.Phone;
                FFName = value.Father.FName;
                FLName = value.Father.LName;
                FPName = value.Father.PName;
                FPhone = value.Father.Phone;
            }
            get
            {
                return new Child(0, FName, LName, PName, Birth, Address, Group, new Parent(MFName, MLName, MPName, MPhone), new Parent(FFName, FLName, FPName, FPhone));
            }
        }

        public Boolean ok = false;

        public EditChildrenForm()
        {
            InitializeComponent();
            int a = DateTime.Now.Year;
            for (int i = 0; i != 100; ++i)
                comboBoxYear.Items.Add(a - i);
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (comboBoxDay.Text.Length == 0 || comboBoxMonth.Text.Length == 0 || comboBoxYear.Text.Length == 0 || FName.Length == 0 || LName.Length == 0 || PName.Length == 0 || Address.Length == 0 || Group.Length == 0)
            {
                Color col = Color.Red;

                labelFName.ForeColor = col;
                labelLName.ForeColor = col;
                labelPName.ForeColor = col;
                labelBirth.ForeColor = col;
                labelAddress.ForeColor = col;
                labelGroup.ForeColor = col;

                MessageBox.Show("Обязательные поля не заполнены!!!", "Ошибка");
            }
            else
            {
                ok = true;
                Close();
            }
        }

        private void butCanlce_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 position = textBox.SelectionStart;
            bool p = false;
            String newStr = "";
            foreach (Char c in textBox.Text)
            {
                if ((c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == ' ')
                    newStr += c;
                else
                    p = true;
            }
            textBox.Text = newStr;
            if (p)
                --position;
            textBox.SelectionStart = position;
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
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
    }
}
