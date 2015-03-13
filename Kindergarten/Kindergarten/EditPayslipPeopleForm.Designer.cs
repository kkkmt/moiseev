namespace Kindergarten
{
    partial class EditPayslipPeopleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPayslipPeopleForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSalary = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDays = new System.Windows.Forms.TextBox();
            this.butCancle = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тарифная ставка:";
            // 
            // textBoxSalary
            // 
            this.textBoxSalary.Location = new System.Drawing.Point(117, 12);
            this.textBoxSalary.Name = "textBoxSalary";
            this.textBoxSalary.Size = new System.Drawing.Size(116, 20);
            this.textBoxSalary.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Отработано дней:";
            // 
            // textBoxDays
            // 
            this.textBoxDays.Location = new System.Drawing.Point(117, 38);
            this.textBoxDays.Name = "textBoxDays";
            this.textBoxDays.Size = new System.Drawing.Size(116, 20);
            this.textBoxDays.TabIndex = 3;
            this.textBoxDays.TextChanged += new System.EventHandler(this.textBoxDays_TextChanged);
            // 
            // butCancle
            // 
            this.butCancle.Location = new System.Drawing.Point(12, 64);
            this.butCancle.Name = "butCancle";
            this.butCancle.Size = new System.Drawing.Size(107, 23);
            this.butCancle.TabIndex = 4;
            this.butCancle.Text = "Отмена";
            this.butCancle.UseVisualStyleBackColor = true;
            this.butCancle.Click += new System.EventHandler(this.butCancle_Click);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(126, 64);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(107, 23);
            this.butOk.TabIndex = 5;
            this.butOk.Text = "Готово";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // EditPayslipPeopleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 97);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.butCancle);
            this.Controls.Add(this.textBoxDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSalary);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditPayslipPeopleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменить";
            this.TextChanged += new System.EventHandler(this.textBoxSalary_TextChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSalary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDays;
        private System.Windows.Forms.Button butCancle;
        private System.Windows.Forms.Button butOk;
    }
}