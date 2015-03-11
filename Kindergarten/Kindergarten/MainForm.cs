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
                UpdateTableChildren();
            else if (e.TabPageIndex == 1)
                UpdateTablePayment();
            else if (e.TabPageIndex == 2)
                UpdateTablePersonnel();
            else if (e.TabPageIndex == 3)
                UpdateTablePayslip();
        }

        private String NumberToTextOne(Int32 value)
        {
            switch (value)
            {
                case 1:
                    return "один";
                case 2:
                    return "два";
                case 3:
                    return "три";
                case 4:
                    return "четыре";
                case 5:
                    return "пять";
                case 6:
                    return "шесть";
                case 7:
                    return "семь";
                case 8:
                    return "восемь";
                case 9:
                    return "девять";
                default:
                    return "";
            }
        }

        private String NumberToTextTen(Int32 value)
        {
            Int32 a = value / 10, b = value % 10;
            String s = NumberToTextOne(a);
            String s1 = NumberToTextOne(b);
            switch (a)
            {
                case 0:
                    s = s1;
                    break;
                case 1:
                    switch (b)
                    {
                        case 0:
                            s = "десять";
                            break;
                        case 2:
                            s = "двенадцать";
                            break;
                        case 3:
                            s = s1 + "надцать";
                            break;
                        default:
                            s = s1.Substring(0, s1.Length - 1) + "надцать";
                            break;
                    }
                    break;
                case 4:
                    s = "сорок " + s1;
                    break;
                case 9:
                    s = "девяносто " + s1;
                    break;
                case 2:
                case 3:
                    s += "дцать " + s1;
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    s += "десят " + s1;
                    break;
            }
            return s;
        }

        private String NumberToTextHundred(Int32 value)
        {
            Int32 a = value / 100;
            String s = NumberToTextOne(a);
            String s1 = NumberToTextTen(value % 100);
            switch (a)
            {
                case 1:
                    s = "сто ";
                    break;
                case 2:
                    s = "двесте ";
                    break;
                case 3:
                    s = "тристо ";
                    break;
                case 4:
                    s = "четыресто ";
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    s += "сот ";
                    break;
            }
            return (s + s1).Trim();
        }

        private String NumberToTextThousand(Int32 value)
        {
            Int32 a = value / 1000, b = a % 10, c = (a / 10) % 10;
            String s = "", s1 = "", s2 = "";
            if (value == 0)
                return "ноль";
            else if (a == 0)
                return NumberToTextHundred(value % 1000);
            else if ((b == 1 || b == 2) && c != 1)
            {
                switch (b)
                {
                    case 1:
                        s1 = NumberToTextHundred(((Int32)a / 10) * 10) + " одна";
                        break;
                    case 2:
                        s1 = NumberToTextHundred(((Int32)a / 10) * 10) + " две";
                        break;
                }
            }
            else
                s1 = NumberToTextHundred(a);
            s2 = NumberToTextHundred(value % 1000);

            switch (s1[s1.Length - 1])
            {
                case 'а':
                    s = s1 + " тысяча ";
                    break;
                case 'е':
                case 'и':
                    s = s1 + " тысячи ";
                    break;
                default:
                    s = s1 + " тысяч ";
                    break;
            }

            return (s + s2).Trim();
        }

        private void CreateExcelReceipt(String path, UInt32 id, String Buyer, DateTime date, List<Goods> goods)
        {
            String[] month = { "Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря" };

            Excel.Application app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook book = app.Workbooks.Open(Path.GetFullPath(@"Template\kvitantsia.xls"));
            Excel.Worksheet sheet = (Excel.Worksheet)book.Worksheets[1];

            sheet.Cells[13, 2] = String.Format("Квитанция на оплату № {0} от {1} {2} {3} г.", id, date.Day, month[date.Month - 1], date.Year);
            sheet.Cells[19, 7] = Buyer;

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
            //Пятнадцать тысяч рублей 00 копеек
            String sumStr = NumberToTextThousand((int)sum);
            sumStr = sumStr[0].ToString().ToUpper() + sumStr.Substring(1);
            String rub = "";
            switch (sumStr.Last())
            {
                case 'н':
                    rub = "рубль";
                    break;
                case 'а':
                case 'и':
                    if (sumStr.Length > 5 && sumStr.Substring(sumStr.Length - 7, 5) == "тысяча")
                        rub = "рублей";
                    else
                        rub = "рубля";
                    break;
                    rub = "рубля";
                    break;
                default:
                    rub = "рублей";
                    break;
            }
            Int32 kopeck = (Int32)((sum - (Int32)sum) * 100);
            String kopeckStr = "";
            switch (kopeck % 10)
            {
                case 1:
                    if (kopeck / 10 == 1)
                        kopeckStr = "копеек";
                    else
                        kopeckStr = "копейка";
                    break;
                case 2:
                case 3:
                case 4:
                    if (kopeck / 10 == 1)
                        kopeckStr = "копеек";
                    else
                        kopeckStr = "копейки";
                    break;
                default:
                    kopeckStr = "копеек";
                    break;
            }
            sheet.Cells[startIndexI + goods.Count + 5, 2] = String.Format("{0} {1} {2} {3}", sumStr, rub, kopeck, kopeckStr);

            book.SaveAs(path);
            app.Visible = true;
        }

        private void CreateExcelReceipt(String path, UInt32 id, Child child, DateTime date, List<Goods> goods)
        {
            String buyer = String.Format("{0} группа №{1}", child.LName + " " + child.FName + " " + child.PName, child.Group);
            CreateExcelReceipt(path, id, buyer, date, goods);
        }

        #region Children

        private void UpdateTableChildren()
        {
            listViewChildren.Items.Clear();

            List<Child> children = sql.GetChildren();

            foreach (Child child in children)
                listViewChildren.Items.Add(ChildToListViewItem(child));
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

            if (listViewChildren.SelectedIndices.Count == 1)
                f.child = (Child)listViewChildren.SelectedItems[0].Tag;

            f.ShowDialog();

            if (f.ok)
            {
                Child baseChild = f.child;
                foreach (ListViewItem item in listViewChildren.SelectedItems)
                {
                    Child child = new Child(baseChild);
                    child.ID = ((Child)item.Tag).ID;

                    if (sql.UpdateChild(child))
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
            if (listViewChildren.SelectedIndices.Count != 0)
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
                listViewChildren.Items.Add(ChildToListViewItem(child));
            }
        }

        private void DeleteChildren(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewChildren.SelectedItems)
            {
                sql.DelChild(((Child)item.Tag).ID);
                listViewChildren.Items.Remove(item);
            }
        }

        private void contextMenuChildren_Opening(object sender, CancelEventArgs e)
        {
            if (listViewChildren.SelectedIndices.Count == 0)
                e.Cancel = true;
        }

        private void ChildrenToXLS(object sender, EventArgs e)
        {
            if (listViewChildren.SelectedItems.Count == 1)
            {
                GoodsForm f = new GoodsForm();
                f.ShowDialog();
                if (f.ok)
                {
                    Child child = (Child)listViewChildren.SelectedItems[0].Tag;
                    List<Goods> goods = f.goods;
                    UInt32 id = sql.AddPayment(child, goods);

                    if (id == 0)
                        MessageBox.Show("Ошибка", "Ошибка");
                    else if (MessageBox.Show("Квитанция успешно сохранена на сервере!\nВыгрузить квитанцию в Excel?", "Оплата", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Exel Файл (*.xls)|*.xls";
                        sfd.FileName = "Квитанция на оплату №" + id;

                        if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            CreateExcelReceipt(sfd.FileName, id, child, DateTime.Now, goods);
                    }
                    
                }
            }
        }

        #endregion

        #region Payment

        private void UpdateTablePayment()
        {
            listViewPayment.Items.Clear();

            List<Payment> payments = sql.GetPayments();

            foreach (Payment pay in payments)
                listViewPayment.Items.Add(new ListViewItem(new String[] { pay.IDPayment.ToString(), pay.Date.ToShortDateString(), pay.Buyer }));
        }

        private void listViewPayment_ItemActivate(object sender, EventArgs e)
        {
            GoodsForm f = new GoodsForm();
            ListViewItem item = listViewPayment.SelectedItems[0];
            f.goods = sql.GetGoodsByIDPayment(Convert.ToUInt32(item.SubItems[0].Text));
            f.Text = item.SubItems[2].Text;
            f.HidenButtons(false);
            f.ShowDialog();
        }

        private void contextMenuStripPayment_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = sender as ContextMenuStrip;
            if (listViewPayment.SelectedItems.Count == 0)
                e.Cancel = true;
            else if (listViewPayment.SelectedItems.Count == 1)
                menu.Items[0].Enabled = true;
            else
                menu.Items[0].Enabled = false;
        }

        private void ButPrintToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (listViewPayment.SelectedItems.Count == 1)
            {
                sfd.Filter = "Exel Файл (*.xls)|*.xls";
                sfd.FileName = "Квитанция на оплату №" + listViewPayment.SelectedItems[0].SubItems[0].Text;
            }
            else
            {
                sfd.Filter = "";
                sfd.FileName = "Квитанции " + DateTime.Now.ToShortDateString();
            }

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (listViewPayment.SelectedItems.Count == 1)
                {
                    ListViewItem item = listViewPayment.SelectedItems[0];
                    UInt32 id = Convert.ToUInt32(item.SubItems[0].Text);
                    CreateExcelReceipt(sfd.FileName, id, item.SubItems[2].Text, DateTime.Parse(item.SubItems[1].Text), sql.GetGoodsByIDPayment(id));
                }
                else
                {
                    foreach (ListViewItem item in listViewPayment.SelectedItems)
                    {
                        UInt32 id = Convert.ToUInt32(item.SubItems[0].Text);
                        String name = String.Format("{0}\\Квитанция на оплату №{1}.xls", sfd.FileName, id);
                        Directory.CreateDirectory(sfd.FileName);
                        CreateExcelReceipt(name, id, item.SubItems[2].Text, DateTime.Parse(item.SubItems[1].Text), sql.GetGoodsByIDPayment(id));                
                    }
                }
            }
        }

        #endregion

        #region Personnel

        private void UpdateTablePersonnel()
        {
            listViewPersonnel.Items.Clear();

            List<Personnel> list = sql.GetPersonnel();

            foreach (Personnel person in list)
            {
                String name = person.LName + " " + person.FName + " " + person.PName;
                listViewPersonnel.Items.Add(new ListViewItem(new String[] { person.ID.ToString(), name, person.Post, person.Salary.ToString(), person.DateReceipt, person.DateDismissal }));
            }
        }

        private void butAddPersonnel_Click(object sender, EventArgs e)
        {
            EditPersonnelForm f = new EditPersonnelForm();
            f.Text = "Добавить";
            f.butOk.Text = "Добавить";
            f.ShowDialog();

            if (f.ok)
            {
                Personnel person = sql.AddPerson(f.person);
                String name = person.LName + " " + person.FName + " " + person.PName;
                listViewPersonnel.Items.Insert(0, new ListViewItem(new String[] { person.ID.ToString(), name, person.Post, person.Salary.ToString(), person.DateReceipt, person.DateDismissal }));
            }
        }

        private void butUpdatePersonnel_Click(object sender, EventArgs e)
        {
            UpdateTablePersonnel();
        }

        private void butEditPersonnel_Click(object sender, EventArgs e)
        {
            if (listViewPersonnel.SelectedItems.Count == 1)
            {
                ListViewItem item = listViewPersonnel.SelectedItems[0];
                if (item.SubItems[5].Text == "")
                {
                    EditPersonnelForm f = new EditPersonnelForm();
                    f.person = sql.GetPerson(Convert.ToUInt32(item.Text));
                    f.HidenButtons(false);
                    f.ShowDialog();

                    if (f.ok)
                    {
                        Personnel person = f.person;
                        if (sql.UpdatePerson(person))
                        {
                            item.SubItems[2].Text = person.Post;
                            item.SubItems[3].Text = person.Salary.ToString();
                        }
                        else
                            MessageBox.Show("Ошибка!!!", "Ошибка");
                    }
                }
            }
        }

        private void butDelPersonnel_Click(object sender, EventArgs e)
        {
            if (listViewPersonnel.SelectedItems.Count == 1)
            {
                ListViewItem item = listViewPersonnel.SelectedItems[0];
                if (item.SubItems[5].Text == "" && MessageBox.Show(String.Format("Вы точно хотите уволить \"{0}\"?", item.SubItems[1].Text), "Уволить", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    item.SubItems[5].Text = sql.DelPerson(Convert.ToUInt32(item.Text));
            }
        }

        private void butBringBackPerson_Click(object sender, EventArgs e)
        {
            if (listViewPersonnel.SelectedItems.Count == 1)
            {
                ListViewItem item = listViewPersonnel.SelectedItems[0];
                if (item.SubItems[5].Text != "" && MessageBox.Show(String.Format("Вы точно хотите вернуть \"{0}\" назад?", item.SubItems[1].Text), "Вернуть", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes && sql.BringBackPerson(Convert.ToUInt32(item.Text)))
                    item.SubItems[5].Text = "";
            }
        }

        private void contextMenuPersonnel_Opening(object sender, CancelEventArgs e)
        {
            if (listViewPersonnel.SelectedItems.Count == 1)
            {
                ContextMenuStrip menu = sender as ContextMenuStrip;
                if (listViewPersonnel.SelectedItems[0].SubItems[5].Text == "")
                {
                    menu.Items[0].Enabled = true;
                    menu.Items[1].Enabled = true;
                    menu.Items[2].Enabled = false;
                }
                else
                {
                    menu.Items[0].Enabled = false;
                    menu.Items[1].Enabled = false;
                    menu.Items[2].Enabled = true;
                }
            }
            else
                e.Cancel = true;
        }

        #endregion

        #region Payslip

        private void UpdateTablePayslip()
        {
            listViewPayslip.Items.Clear();

            List<Payslip> list = sql.GetPayslip();

            foreach (Payslip pay in list)
                listViewPayslip.Items.Add(new ListViewItem(new String[] { pay.ID.ToString(), pay.Date.ToShortDateString(), pay.ReportingFrom.ToShortDateString(), pay.ReportingTo.ToShortDateString() }));
        }

        private void butUpdatePayslip_Click(object sender, EventArgs e)
        {
            UpdateTablePayslip();
        }

        private void butAddPayslip_Click(object sender, EventArgs e)
        {
            AddPayslipForm f = new AddPayslipForm();
            f.list = sql.GetPersonnelForPayslip();
            f.ShowDialog();

            if (f.ok)
            {
                if (sql.AddPayslip(f.Date, f.Year, f.Month, f.list) && MessageBox.Show("Расчётная ведомость сохранена на сервере!\nВыгрузить квитанцию в Excel?", "Расчётная ведомость", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                }
            }
        }

        #endregion
    }
}
