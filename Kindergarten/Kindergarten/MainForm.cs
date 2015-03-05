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

using Excel = Microsoft.Office.Interop.Excel;

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
            DateTime date = DateTime.Now;
            String[] month = { "Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря" };
            
            Excel.Application app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook book = app.Workbooks.Open(Path.GetFullPath(@"Template\kvitantsia.xls"));
            Excel.Worksheet sheet = (Excel.Worksheet)book.Worksheets[1];

            sheet.Cells[13, 2] = String.Format("Квитанция на оплату № {0} от {1} {2} {3} г.", id, date.Day, month[date.Month - 1], date.Year);
            sheet.Cells[19, 7] = String.Format("{0} группа №{1}", child.LName + " " + child.FName + " " + child.PName, child.Group);

            int startIndexI = 22, startIndexJ = 2;
            Excel.Range R1 = (Excel.Range)sheet.Rows[startIndexI];

            for (int i = 1; i < goods.Count; ++i)
            {
                R1.Copy(Type.Missing);
                R1.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
            }

            String f = "=";
            Double sum = 0;
            for (int i = 0; i != goods.Count; ++i)
            {
                sheet.Cells[startIndexI + i, startIndexJ] = i + 1;
                sheet.Cells[startIndexI + i, startIndexJ + 2] = goods[i].Gds;
                sheet.Cells[startIndexI + i, startIndexJ + 20] = goods[i].Count;
                sheet.Cells[startIndexI + i, startIndexJ + 23] = goods[i].Unit;
                sheet.Cells[startIndexI + i, startIndexJ + 26] = goods[i].Price;

                f += String.Format("R[-{0}]C+", 2 + i);
                sum += goods[i].Price * goods[i].Count;
            }

            sheet.Cells[startIndexI + goods.Count + 1, 33] = f.Substring(0, f.Length - 1);
            sheet.Cells[startIndexI + goods.Count + 4, 2] = String.Format("Всего наименований {0}, на сумму {1} руб.", goods.Count, sum);

            book.SaveAs(path);
            app.Visible = true;
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
