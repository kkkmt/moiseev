﻿namespace Kindergarten
{
    partial class EditPersonnelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPersonnelForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSalary = new System.Windows.Forms.TextBox();
            this.butCancle = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия:";
            // 
            // textBoxLName
            // 
            this.textBoxLName.Location = new System.Drawing.Point(86, 12);
            this.textBoxLName.Name = "textBoxLName";
            this.textBoxLName.Size = new System.Drawing.Size(197, 20);
            this.textBoxLName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя:";
            // 
            // textBoxFName
            // 
            this.textBoxFName.Location = new System.Drawing.Point(86, 38);
            this.textBoxFName.Name = "textBoxFName";
            this.textBoxFName.Size = new System.Drawing.Size(197, 20);
            this.textBoxFName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отчество:";
            // 
            // textBoxPName
            // 
            this.textBoxPName.Location = new System.Drawing.Point(86, 64);
            this.textBoxPName.Name = "textBoxPName";
            this.textBoxPName.Size = new System.Drawing.Size(197, 20);
            this.textBoxPName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Должность:";
            // 
            // textBoxPost
            // 
            this.textBoxPost.Location = new System.Drawing.Point(86, 90);
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(197, 20);
            this.textBoxPost.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Оклад:";
            // 
            // textBoxSalary
            // 
            this.textBoxSalary.Location = new System.Drawing.Point(86, 116);
            this.textBoxSalary.Name = "textBoxSalary";
            this.textBoxSalary.Size = new System.Drawing.Size(197, 20);
            this.textBoxSalary.TabIndex = 9;
            this.textBoxSalary.TextChanged += new System.EventHandler(this.textBoxSalary_TextChanged);
            // 
            // butCancle
            // 
            this.butCancle.Location = new System.Drawing.Point(12, 142);
            this.butCancle.Name = "butCancle";
            this.butCancle.Size = new System.Drawing.Size(132, 23);
            this.butCancle.TabIndex = 10;
            this.butCancle.Text = "Отмена";
            this.butCancle.UseVisualStyleBackColor = true;
            this.butCancle.Click += new System.EventHandler(this.butCancle_Click);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(151, 142);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(132, 23);
            this.butOk.TabIndex = 11;
            this.butOk.Text = "Изменить";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // EditPersonnelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 175);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.butCancle);
            this.Controls.Add(this.textBoxSalary);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditPersonnelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменить";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSalary;
        private System.Windows.Forms.Button butCancle;
        public System.Windows.Forms.Button butOk;
    }
}