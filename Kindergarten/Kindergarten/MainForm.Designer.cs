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
            this.ChildrenList = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.birth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.group = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuChildren = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изминитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personnel = new System.Windows.Forms.TabPage();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.children.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuChildren.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.children);
            this.tabControl1.Controls.Add(this.personnel);
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
            this.children.Controls.Add(this.toolStrip1);
            this.children.Controls.Add(this.ChildrenList);
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
            // ChildrenList
            // 
            this.ChildrenList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.ChildrenList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChildrenList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.birth,
            this.address,
            this.group});
            this.ChildrenList.ContextMenuStrip = this.contextMenuChildren;
            this.ChildrenList.FullRowSelect = true;
            this.ChildrenList.GridLines = true;
            this.ChildrenList.HideSelection = false;
            this.ChildrenList.Location = new System.Drawing.Point(3, 31);
            this.ChildrenList.Name = "ChildrenList";
            this.ChildrenList.Size = new System.Drawing.Size(497, 230);
            this.ChildrenList.TabIndex = 0;
            this.ChildrenList.UseCompatibleStateImageBehavior = false;
            this.ChildrenList.View = System.Windows.Forms.View.Details;
            this.ChildrenList.ItemActivate += new System.EventHandler(this.EditChildren);
            // 
            // name
            // 
            this.name.Text = "Ф.И.О.";
            this.name.Width = 168;
            // 
            // birth
            // 
            this.birth.Text = "Год рождения";
            this.birth.Width = 85;
            // 
            // address
            // 
            this.address.Text = "Адрес";
            this.address.Width = 165;
            // 
            // group
            // 
            this.group.Text = "Группа";
            this.group.Width = 74;
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
            this.personnel.Location = new System.Drawing.Point(4, 22);
            this.personnel.Name = "personnel";
            this.personnel.Padding = new System.Windows.Forms.Padding(3);
            this.personnel.Size = new System.Drawing.Size(503, 264);
            this.personnel.TabIndex = 1;
            this.personnel.Text = "Персонал";
            this.personnel.UseVisualStyleBackColor = true;
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage personnel;
        private System.Windows.Forms.TabPage children;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butUpdateChildren;
        private System.Windows.Forms.ListView ChildrenList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader birth;
        private System.Windows.Forms.ColumnHeader address;
        private System.Windows.Forms.ColumnHeader group;
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
    }
}

