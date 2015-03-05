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
    public partial class AuthorizationForm : Form
    {
        public Sql sql = new Sql();

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            if (sql.Connect(textBoxAddress.Text, textBoxLogin.Text, textBoxPsw.Text))
                Close();
            else
                MessageBox.Show("Ошибка!!!", "Ошибка");
        }
    }
}
