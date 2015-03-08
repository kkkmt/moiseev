namespace Kindergarten
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.children = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butUpdateChildren = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.butAddChild = new System.Windows.Forms.ToolStripButton();
            this.butEditChildren = new System.Windows.Forms.ToolStripButton();
            this.butDelChildren = new System.Windows.Forms.ToolStripButton();
            this.contextMenuChildren = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изминитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personnel = new System.Windows.Forms.TabPage();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewPayment = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripPayment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.посмотретьТоварыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButPrintToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.butUpdatePersonnel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.butAddPersonnel = new System.Windows.Forms.ToolStripButton();
            this.butEditPersonnel = new System.Windows.Forms.ToolStripButton();
            this.butDelPersonnel = new System.Windows.Forms.ToolStripButton();
            this.listViewPersonnel = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewChildren = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.children.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuChildren.SuspendLayout();
            this.personnel.SuspendLayout();
            this.contextMenuStripPayment.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.children);
            this.tabControl1.Controls.Add(this.personnel);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(511, 290);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // children
            // 
            this.children.BackColor = System.Drawing.Color.White;
            this.children.Controls.Add(this.listViewChildren);
            this.children.Controls.Add(this.toolStrip1);
            this.children.Location = new System.Drawing.Point(4, 22);
            this.children.Name = "children";
            this.children.Padding = new System.Windows.Forms.Padding(3);
            this.children.Size = new System.Drawing.Size(503, 264);
            this.children.TabIndex = 0;
            this.children.Text = "Дети";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butUpdateChildren,
            this.toolStripSeparator1,
            this.butAddChild,
            this.butEditChildren,
            this.butDelChildren});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(497, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // butUpdateChildren
            // 
            this.butUpdateChildren.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butUpdateChildren.Image = ((System.Drawing.Image)(resources.GetObject("butUpdateChildren.Image")));
            this.butUpdateChildren.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butUpdateChildren.Name = "butUpdateChildren";
            this.butUpdateChildren.Size = new System.Drawing.Size(23, 22);
            this.butUpdateChildren.Text = "Обновить";
            this.butUpdateChildren.Click += new System.EventHandler(this.butUpdateChildren_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // butAddChild
            // 
            this.butAddChild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butAddChild.Image = ((System.Drawing.Image)(resources.GetObject("butAddChild.Image")));
            this.butAddChild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butAddChild.Name = "butAddChild";
            this.butAddChild.Size = new System.Drawing.Size(23, 22);
            this.butAddChild.Text = "Добавить";
            this.butAddChild.Click += new System.EventHandler(this.AddChildren);
            // 
            // butEditChildren
            // 
            this.butEditChildren.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butEditChildren.Image = ((System.Drawing.Image)(resources.GetObject("butEditChildren.Image")));
            this.butEditChildren.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butEditChildren.Name = "butEditChildren";
            this.butEditChildren.Size = new System.Drawing.Size(23, 22);
            this.butEditChildren.Text = "Изменить";
            this.butEditChildren.Click += new System.EventHandler(this.EditChildren);
            // 
            // butDelChildren
            // 
            this.butDelChildren.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butDelChildren.Image = ((System.Drawing.Image)(resources.GetObject("butDelChildren.Image")));
            this.butDelChildren.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butDelChildren.Name = "butDelChildren";
            this.butDelChildren.Size = new System.Drawing.Size(23, 22);
            this.butDelChildren.Text = "Удалить";
            this.butDelChildren.Click += new System.EventHandler(this.DeleteChildren);
            // 
            // contextMenuChildren
            // 
            this.contextMenuChildren.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изминитьToolStripMenuItem,
            this.удалитьToolStripMenuItem1,
            this.toolStripSeparator2,
            this.PrintToolStripMenuItem});
            this.contextMenuChildren.Name = "contextMenuChildren";
            this.contextMenuChildren.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuChildren.Size = new System.Drawing.Size(130, 76);
            this.contextMenuChildren.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuChildren_Opening);
            // 
            // изминитьToolStripMenuItem
            // 
            this.изминитьToolStripMenuItem.Name = "изминитьToolStripMenuItem";
            this.изминитьToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.изминитьToolStripMenuItem.Text = "Изминить";
            this.изминитьToolStripMenuItem.Click += new System.EventHandler(this.EditChildren);
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            this.удалитьToolStripMenuItem1.Click += new System.EventHandler(this.DeleteChildren);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(126, 6);
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.PrintToolStripMenuItem.Text = "Оплата";
            this.PrintToolStripMenuItem.Click += new System.EventHandler(this.ChildrenToXLS);
            // 
            // personnel
            // 
            this.personnel.Controls.Add(this.listViewPayment);
            this.personnel.Location = new System.Drawing.Point(4, 22);
            this.personnel.Name = "personnel";
            this.personnel.Padding = new System.Windows.Forms.Padding(3);
            this.personnel.Size = new System.Drawing.Size(503, 264);
            this.personnel.TabIndex = 1;
            this.personnel.Text = "Оплата";
            this.personnel.UseVisualStyleBackColor = true;
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // listViewPayment
            // 
            this.listViewPayment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewPayment.ContextMenuStrip = this.contextMenuStripPayment;
            this.listViewPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPayment.FullRowSelect = true;
            this.listViewPayment.GridLines = true;
            this.listViewPayment.Location = new System.Drawing.Point(3, 3);
            this.listViewPayment.Name = "listViewPayment";
            this.listViewPayment.Size = new System.Drawing.Size(497, 258);
            this.listViewPayment.TabIndex = 0;
            this.listViewPayment.UseCompatibleStateImageBehavior = false;
            this.listViewPayment.View = System.Windows.Forms.View.Details;
            this.listViewPayment.ItemActivate += new System.EventHandler(this.listViewPayment_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            this.columnHeader1.Width = 39;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Дата";
            this.columnHeader2.Width = 104;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Покупатель";
            this.columnHeader3.Width = 323;
            // 
            // contextMenuStripPayment
            // 
            this.contextMenuStripPayment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.посмотретьТоварыToolStripMenuItem,
            this.ButPrintToExcel});
            this.contextMenuStripPayment.Name = "contextMenuStripPayment";
            this.contextMenuStripPayment.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripPayment.Size = new System.Drawing.Size(182, 48);
            this.contextMenuStripPayment.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripPayment_Opening);
            // 
            // посмотретьТоварыToolStripMenuItem
            // 
            this.посмотретьТоварыToolStripMenuItem.Name = "посмотретьТоварыToolStripMenuItem";
            this.посмотретьТоварыToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.посмотретьТоварыToolStripMenuItem.Text = "Посмотреть услуги";
            this.посмотретьТоварыToolStripMenuItem.Click += new System.EventHandler(this.listViewPayment_ItemActivate);
            // 
            // ButPrintToExcel
            // 
            this.ButPrintToExcel.Name = "ButPrintToExcel";
            this.ButPrintToExcel.Size = new System.Drawing.Size(181, 22);
            this.ButPrintToExcel.Text = "Записать в Excel";
            this.ButPrintToExcel.Click += new System.EventHandler(this.ButPrintToExcel_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewPersonnel);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(503, 264);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Персонал";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butUpdatePersonnel,
            this.toolStripSeparator3,
            this.butAddPersonnel,
            this.butEditPersonnel,
            this.butDelPersonnel});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(497, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // butUpdatePersonnel
            // 
            this.butUpdatePersonnel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butUpdatePersonnel.Image = ((System.Drawing.Image)(resources.GetObject("butUpdatePersonnel.Image")));
            this.butUpdatePersonnel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butUpdatePersonnel.Name = "butUpdatePersonnel";
            this.butUpdatePersonnel.Size = new System.Drawing.Size(23, 22);
            this.butUpdatePersonnel.Text = "Обновить";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // butAddPersonnel
            // 
            this.butAddPersonnel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butAddPersonnel.Image = ((System.Drawing.Image)(resources.GetObject("butAddPersonnel.Image")));
            this.butAddPersonnel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butAddPersonnel.Name = "butAddPersonnel";
            this.butAddPersonnel.Size = new System.Drawing.Size(23, 22);
            this.butAddPersonnel.Text = "Добавить сотрудника";
            // 
            // butEditPersonnel
            // 
            this.butEditPersonnel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butEditPersonnel.Image = ((System.Drawing.Image)(resources.GetObject("butEditPersonnel.Image")));
            this.butEditPersonnel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butEditPersonnel.Name = "butEditPersonnel";
            this.butEditPersonnel.Size = new System.Drawing.Size(23, 22);
            this.butEditPersonnel.Text = "Изменить";
            // 
            // butDelPersonnel
            // 
            this.butDelPersonnel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butDelPersonnel.Image = ((System.Drawing.Image)(resources.GetObject("butDelPersonnel.Image")));
            this.butDelPersonnel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butDelPersonnel.Name = "butDelPersonnel";
            this.butDelPersonnel.Size = new System.Drawing.Size(23, 22);
            this.butDelPersonnel.Text = "Уволить сотрудника";
            // 
            // listViewPersonnel
            // 
            this.listViewPersonnel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPersonnel.FullRowSelect = true;
            this.listViewPersonnel.GridLines = true;
            this.listViewPersonnel.Location = new System.Drawing.Point(3, 28);
            this.listViewPersonnel.Name = "listViewPersonnel";
            this.listViewPersonnel.Size = new System.Drawing.Size(497, 233);
            this.listViewPersonnel.TabIndex = 1;
            this.listViewPersonnel.UseCompatibleStateImageBehavior = false;
            this.listViewPersonnel.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "№";
            this.columnHeader4.Width = 29;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ф.И.О.";
            this.columnHeader5.Width = 241;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Дата приёма";
            this.columnHeader6.Width = 94;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Дата увольнения";
            this.columnHeader7.Width = 101;
            // 
            // listViewChildren
            // 
            this.listViewChildren.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listViewChildren.ContextMenuStrip = this.contextMenuChildren;
            this.listViewChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChildren.FullRowSelect = true;
            this.listViewChildren.GridLines = true;
            this.listViewChildren.Location = new System.Drawing.Point(3, 28);
            this.listViewChildren.Name = "listViewChildren";
            this.listViewChildren.Size = new System.Drawing.Size(497, 233);
            this.listViewChildren.TabIndex = 2;
            this.listViewChildren.UseCompatibleStateImageBehavior = false;
            this.listViewChildren.View = System.Windows.Forms.View.Details;
            this.listViewChildren.ItemActivate += new System.EventHandler(this.EditChildren);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ф.И.О.";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Год рождения";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Адрес";
            this.columnHeader10.Width = 128;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Группа";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 290);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Колобок";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.children.ResumeLayout(false);
            this.children.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuChildren.ResumeLayout(false);
            this.personnel.ResumeLayout(false);
            this.contextMenuStripPayment.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage personnel;
        private System.Windows.Forms.TabPage children;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butUpdateChildren;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton butAddChild;
        private System.Windows.Forms.ToolStripButton butEditChildren;
        private System.Windows.Forms.ToolStripButton butDelChildren;
        private System.Windows.Forms.ContextMenuStrip contextMenuChildren;
        private System.Windows.Forms.ToolStripMenuItem изминитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ListView listViewPayment;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPayment;
        private System.Windows.Forms.ToolStripMenuItem посмотретьТоварыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ButPrintToExcel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton butUpdatePersonnel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton butAddPersonnel;
        private System.Windows.Forms.ToolStripButton butEditPersonnel;
        private System.Windows.Forms.ToolStripButton butDelPersonnel;
        private System.Windows.Forms.ListView listViewPersonnel;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView listViewChildren;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}

