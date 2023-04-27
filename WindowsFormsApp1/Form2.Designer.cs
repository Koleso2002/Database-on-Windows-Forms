namespace WindowsFormsApp1
{
    partial class Form2
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
            this.Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SerialNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ProductionDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DateOfCommission = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.PurshasePrise = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ResidualPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PercentageOfWear = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.WorkNotWork = new System.Windows.Forms.CheckBox();
            this.RequireRepairs = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PreventiveRepairs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ExtraordinaryRepairs = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(122, 25);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(287, 20);
            this.Name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Оборудование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип оборудования";
            // 
            // Type
            // 
            this.Type.FormattingEnabled = true;
            this.Type.Location = new System.Drawing.Point(167, 71);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(242, 21);
            this.Type.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(21, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Заводской номер";
            // 
            // SerialNumber
            // 
            this.SerialNumber.Location = new System.Drawing.Point(167, 120);
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.Size = new System.Drawing.Size(242, 20);
            this.SerialNumber.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата выпуска";
            // 
            // ProductionDate
            // 
            this.ProductionDate.Location = new System.Drawing.Point(238, 163);
            this.ProductionDate.Name = "ProductionDate";
            this.ProductionDate.Size = new System.Drawing.Size(171, 20);
            this.ProductionDate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(21, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Дата ввода в эксплуатацию";
            // 
            // DateOfCommission
            // 
            this.DateOfCommission.Location = new System.Drawing.Point(238, 208);
            this.DateOfCommission.Name = "DateOfCommission";
            this.DateOfCommission.Size = new System.Drawing.Size(171, 20);
            this.DateOfCommission.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(21, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Покупная стоимость";
            // 
            // PurshasePrise
            // 
            this.PurshasePrise.Location = new System.Drawing.Point(195, 254);
            this.PurshasePrise.Name = "PurshasePrise";
            this.PurshasePrise.Size = new System.Drawing.Size(214, 20);
            this.PurshasePrise.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(21, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Остаточная стоимость";
            // 
            // ResidualPrice
            // 
            this.ResidualPrice.Location = new System.Drawing.Point(195, 304);
            this.ResidualPrice.Name = "ResidualPrice";
            this.ResidualPrice.Size = new System.Drawing.Size(214, 20);
            this.ResidualPrice.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(21, 355);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Процент износа";
            // 
            // PercentageOfWear
            // 
            this.PercentageOfWear.Location = new System.Drawing.Point(195, 352);
            this.PercentageOfWear.Name = "PercentageOfWear";
            this.PercentageOfWear.Size = new System.Drawing.Size(214, 20);
            this.PercentageOfWear.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(457, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Необходимый ремонт";
            // 
            // WorkNotWork
            // 
            this.WorkNotWork.AutoSize = true;
            this.WorkNotWork.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkNotWork.Location = new System.Drawing.Point(460, 24);
            this.WorkNotWork.Name = "WorkNotWork";
            this.WorkNotWork.Size = new System.Drawing.Size(92, 20);
            this.WorkNotWork.TabIndex = 17;
            this.WorkNotWork.Text = "Не работает";
            this.WorkNotWork.UseVisualStyleBackColor = true;
            // 
            // RequireRepairs
            // 
            this.RequireRepairs.Location = new System.Drawing.Point(460, 71);
            this.RequireRepairs.MaxLength = 300;
            this.RequireRepairs.Multiline = true;
            this.RequireRepairs.Name = "RequireRepairs";
            this.RequireRepairs.Size = new System.Drawing.Size(299, 203);
            this.RequireRepairs.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(457, 307);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "ППР";
            // 
            // PreventiveRepairs
            // 
            this.PreventiveRepairs.Location = new System.Drawing.Point(597, 304);
            this.PreventiveRepairs.Name = "PreventiveRepairs";
            this.PreventiveRepairs.Size = new System.Drawing.Size(162, 20);
            this.PreventiveRepairs.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(457, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "Внеплановый ремонт";
            // 
            // ExtraordinaryRepairs
            // 
            this.ExtraordinaryRepairs.Location = new System.Drawing.Point(597, 351);
            this.ExtraordinaryRepairs.Name = "ExtraordinaryRepairs";
            this.ExtraordinaryRepairs.Size = new System.Drawing.Size(162, 20);
            this.ExtraordinaryRepairs.TabIndex = 22;
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add.Location = new System.Drawing.Point(510, 407);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(248, 27);
            this.Add.TabIndex = 23;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.ExtraordinaryRepairs);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.PreventiveRepairs);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.RequireRepairs);
            this.Controls.Add(this.WorkNotWork);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PercentageOfWear);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ResidualPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PurshasePrise);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DateOfCommission);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ProductionDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SerialNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Name);
           // this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SerialNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker ProductionDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DateOfCommission;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PurshasePrise;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ResidualPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PercentageOfWear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox WorkNotWork;
        private System.Windows.Forms.TextBox RequireRepairs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PreventiveRepairs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ExtraordinaryRepairs;
        private System.Windows.Forms.Button Add;
    }
}