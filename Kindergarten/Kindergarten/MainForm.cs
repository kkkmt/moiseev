using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using ExcelLibrary;
using ExcelLibrary.SpreadSheet;

namespace Kindergarten
{
    public partial class MainForm : Form
    {
        Sql sql;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AuthorizationForm f = new AuthorizationForm();
            f.ShowDialog();
            sql = f.sql;
            if (sql.State != ConnectionState.Open)
                Close();
            else
                UpdateTableChildren();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                UpdateTableChildren();
            }
        }

        #region Children

        private void UpdateTableChildren()
        {
            ChildrenList.Items.Clear();

            List<Child> children = sql.GetChildren();

            foreach (Child child in children)
                ChildrenList.Items.Add(ChildToListViewItem(child));
        }

        private ListViewItem ChildToListViewItem(Child child)
        {
            String name = child.LName + " " + child.FName + " " + child.PName;
            String birth = child.Birth.ToShortDateString();
            ListViewItem item = new ListViewItem(new String[] { name, birth, child.Address, child.Group });
            item.Tag = new Child(child);
            return item;
        }

        private void EditChildren()
        {
            EditChildrenForm f = new EditChildrenForm();

            if (ChildrenList.SelectedIndices.Count == 1)
                f.child = (Child)ChildrenList.SelectedItems[0].Tag;

            f.ShowDialog();

            if (f.ok)
            {
                Child baseChild = f.child;
                foreach (ListViewItem item in ChildrenList.SelectedItems)
                {
                    Child child = new Child(baseChild);
                    child.ID = ((Child)item.Tag).ID;

                    if (sql.SaveEditChild(child))
                    {
                        ListViewItem newItem = ChildToListViewItem(child);
                        item.Tag = newItem.Tag;
                        for (int i = 0; i != item.SubItems.Count; ++i)
                            item.SubItems[i] = newItem.SubItems[i];
                    }
                    else
                    {
                        MessageBox.Show("Ошибка!!!", "Ошибка");
                        return;
                    }
                }
            }
        }

        private void butUpdateChildren_Click(object sender, EventArgs e)
        {
            UpdateTableChildren();
        }

        private void EditChildren(object sender, EventArgs e)
        {
            if (ChildrenList.SelectedIndices.Count != 0)
                EditChildren();
        }

        private void AddChildren(object sender, EventArgs e)
        {
            EditChildrenForm f = new EditChildrenForm();
            f.Text = "Добавить";
            f.butOk.Text = "Добавить";
            f.ShowDialog();
            if (f.ok)
            {
                Child child = f.child;
                child.ID = sql.AddChild(child);
                ChildrenList.Items.Add(ChildToListViewItem(child));
            }
        }

        private void DeleteChildren(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ChildrenList.SelectedItems)
            {
                sql.DelChild(((Child)item.Tag).ID);
                ChildrenList.Items.Remove(item);
            }
        }

        private void contextMenuChildren_Opening(object sender, CancelEventArgs e)
        {
            if (ChildrenList.SelectedIndices.Count == 0)
                e.Cancel = true;
        }

        private void CreateExcelReceipt(String path, UInt32 id, Child child, List<Goods> goods)
        {
            FileStream baseFile = File.OpenRead(@"Template\kvitantsia.xls");
            FileStream file = File.Create(path);
            baseFile.CopyTo(file);
            baseFile.Close();
            file.Close();

            Workbook book = Workbook.Load(path);
            //Workbook book = Workbook.Load(@"Template\kvitantsia.xls");
            Worksheet sheet = book.Worksheets[0];

            DateTime date = DateTime.Now;
            String[] month = { "Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря" };

            sheet.Cells[12, 1] = new Cell(String.Format("Квитанция на оплату № {0} от {1} {2} {3} г.", id, date.Day, month[date.Month - 1], date.Year), sheet.Cells[12, 1].Format);
            sheet.Cells[18, 6] = new Cell(String.Format("{0} группа №{1}", child.LName + " " + child.FName + " " + child.PName, child.Group), sheet.Cells[18, 6].Format);
            
            //book.Save(path);
        }

        private void ChildrenToXLS(object sender, EventArgs e)
        {
            if (ChildrenList.SelectedItems.Count == 1)
            {
                GoodsForm f = new GoodsForm();
                f.ShowDialog();
                if (f.ok)
                {
                    Child child = (Child)ChildrenList.SelectedItems[0].Tag;
                    List<Goods> goods = f.goods;
                    UInt32 id = sql.AddPayment(child, goods);

                    if (id == 0)
                        MessageBox.Show("Ошибка", "Ошибка");
                    else if (MessageBox.Show("Квитанция успешно сохранина на сервере!\nВыгрузить квитанцию в Excel?", "Оплата", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Exel Файл (*.xls)|*.xls";
                        sfd.FileName = "Квитанция на оплату №" + id;

                        if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            CreateExcelReceipt(sfd.FileName, id, child, goods);
                    }
                    
                }
            }
        }

        #endregion

    }
}
