namespace FinanceServices
{
    partial class BreakDownBankDeposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BreakDownBankDeposit));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCreditEntry = new System.Windows.Forms.TextBox();
            this.btnSearchedAccountTitle = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.gbxDateRage = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbxDateRage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Location = new System.Drawing.Point(0, 296);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 35);
            this.panel2.TabIndex = 96;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 58);
            this.panel1.TabIndex = 95;
            // 
            // txtCreditEntry
            // 
            this.txtCreditEntry.BackColor = System.Drawing.Color.White;
            this.txtCreditEntry.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditEntry.Location = new System.Drawing.Point(98, 65);
            this.txtCreditEntry.MaxLength = 100;
            this.txtCreditEntry.Name = "txtCreditEntry";
            this.txtCreditEntry.ReadOnly = true;
            this.txtCreditEntry.Size = new System.Drawing.Size(250, 26);
            this.txtCreditEntry.TabIndex = 11;
            // 
            // btnSearchedAccountTitle
            // 
            this.btnSearchedAccountTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchedAccountTitle.BackgroundImage")));
            this.btnSearchedAccountTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchedAccountTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchedAccountTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchedAccountTitle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchedAccountTitle.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearchedAccountTitle.Location = new System.Drawing.Point(354, 63);
            this.btnSearchedAccountTitle.Name = "btnSearchedAccountTitle";
            this.btnSearchedAccountTitle.Size = new System.Drawing.Size(22, 22);
            this.btnSearchedAccountTitle.TabIndex = 12;
            this.btnSearchedAccountTitle.UseVisualStyleBackColor = true;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Black;
            this.label51.Location = new System.Drawing.Point(2, 70);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(87, 15);
            this.label51.TabIndex = 167;
            this.label51.Text = "Account Entry:";
            // 
            // gbxDateRage
            // 
            this.gbxDateRage.Controls.Add(this.dtpEnd);
            this.gbxDateRage.Controls.Add(this.label2);
            this.gbxDateRage.Controls.Add(this.dtpStart);
            this.gbxDateRage.Controls.Add(this.label3);
            this.gbxDateRage.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDateRage.Location = new System.Drawing.Point(24, 66);
            this.gbxDateRage.Name = "gbxDateRage";
            this.gbxDateRage.Size = new System.Drawing.Size(382, 95);
            this.gbxDateRage.TabIndex = 104;
            this.gbxDateRage.TabStop = false;
            this.gbxDateRage.Text = " Date Range ";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Checked = false;
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(98, 52);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(243, 23);
            this.dtpEnd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(29, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 100;
            this.label2.Text = "Date End:";
            // 
            // dtpStart
            // 
            this.dtpStart.Checked = false;
            this.dtpStart.Enabled = false;
            this.dtpStart.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Location = new System.Drawing.Point(98, 23);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(243, 23);
            this.dtpStart.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(22, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 99;
            this.label3.Text = "Date Start:";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Red;
            this.txtAmount.Location = new System.Drawing.Point(98, 28);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(250, 31);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(33, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 164;
            this.label8.Text = "Amount:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCreditEntry);
            this.groupBox1.Controls.Add(this.btnSearchedAccountTitle);
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 112);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Account Information ";
            // 
            // BreakDownBankDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(428, 331);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxDateRage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BreakDownBankDeposit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxDateRage.ResumeLayout(false);
            this.gbxDateRage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Button btnSearchedAccountTitle;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbxDateRage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.TextBox txtCreditEntry;
        protected System.Windows.Forms.TextBox txtAmount;
        protected System.Windows.Forms.DateTimePicker dtpEnd;
        protected System.Windows.Forms.DateTimePicker dtpStart;

    }
}