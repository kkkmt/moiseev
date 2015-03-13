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
    public partial class GoodsForm : Form
    {
        public Boolean ok = false;
        private Boolean activateItem = true;

        public List<Goods> goods
        {
            set
            {
                foreach (Goods gds in value)
                {
                    ListViewItem lvi = new ListViewItem(new String[] { gds.Gds, gds.Count.ToString(), gds.Unit, gds.Price.ToString() });
                    listView1.Items.Add(lvi);
                }
            }
            get
            {
                List<Goods> list = new List<Goods>();
                foreach (ListViewItem item in listView1.Items)
                    list.Add(new Goods(item.SubItems[0].Text, Convert.ToInt32(item.SubItems[1].Text), item.SubItems[2].Text, Convert.ToDouble(item.SubItems[3].Text)));
                return list;
            }
        }

        public GoodsForm()
        {
            InitializeComponent();
        }

        public void HidenButtons(Boolean enabled)
        {
            butAdd.Enabled = enabled;
            butCancle.Enabled = enabled;
            butDel.Enabled = enabled;
            butEdit.Enabled = enabled;
            butOk.Enabled = enabled;

            activateItem = enabled;

            contextMenuStrip1.Enabled = enabled;
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            EditGoodsForm f = new EditGoodsForm();
            f.ShowDialog();
            if (f.ok)
            {
                ListViewItem lvi = new ListViewItem(new String[] { f.Gds, f.Count, f.Unit, f.Price });
                listView1.Items.Add(lvi);
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0 && activateItem)
            {
                EditGoodsForm f = new EditGoodsForm();
                f.butOk.Text = "Изменить";
                if (listView1.SelectedItems.Count == 1)
                {
                    f.Gds = listView1.SelectedItems[0].SubItems[0].Text;
                    f.Count = listView1.SelectedItems[0].SubItems[1].Text;
                    f.Unit = listView1.SelectedItems[0].SubItems[2].Text;
                    f.Price = listView1.SelectedItems[0].SubItems[3].Text;
                }
                f.ShowDialog();
                if (f.ok)
                {
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        item.SubItems[0].Text = f.Gds;
                        item.SubItems[1].Text = f.Count;
                        item.SubItems[2].Text = f.Unit;
                        item.SubItems[3].Text = f.Price;
                    }
                }
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
                listView1.Items.Remove(item);
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
                MessageBox.Show("Нет услуг!!!", "Ошибка");
            else
            {
                ok = true;
                Close();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                e.Cancel = true;
        }

        private void GoodsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
