namespace AccountingServices
{
    partial class ChartOfAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartOfAccount));
            this.gbxPersonalInfo = new System.Windows.Forms.GroupBox();
            this.cboAccountCategory = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAccountDescription = new System.Windows.Forms.TextBox();
            this.btnClearSummaryAccount = new System.Windows.Forms.Button();
            this.pnlDebitSide = new System.Windows.Forms.Panel();
            this.rdbNoDebitSide = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearchSummaryAccount = new System.Windows.Forms.Button();
            this.txtCompanyPolicy = new System.Windows.Forms.TextBox();
            this.txtSummaryAccount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbYesDebitSide = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbYesActiveAccount = new System.Windows.Forms.RadioButton();
            this.rdbNoActiveAccount = new System.Windows.Forms.RadioButton();
            this.gbxPersonalInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlDebitSide.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxPersonalInfo
            // 
            this.gbxPersonalInfo.Controls.Add(this.cboAccountCategory);
            this.gbxPersonalInfo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPersonalInfo.ForeColor = System.Drawing.Color.Navy;
            this.gbxPersonalInfo.Location = new System.Drawing.Point(12, 72);
            this.gbxPersonalInfo.Name = "gbxPersonalInfo";
            this.gbxPersonalInfo.Size = new System.Drawing.Size(514, 77);
            this.gbxPersonalInfo.TabIndex = 11;
            this.gbxPersonalInfo.TabStop = false;
            this.gbxPersonalInfo.Text = " ACCOUNT CATEGORY ";
            // 
            // cboAccountCategory
            // 
            this.cboAccountCategory.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboAccountCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountCategory.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAccountCategory.FormattingEnabled = true;
            this.cboAccountCategory.Location = new System.Drawing.Point(31, 27);
            this.cboAccountCategory.Name = "cboAccountCategory";
            this.cboAccountCategory.Size = new System.Drawing.Size(451, 31);
            this.cboAccountCategory.TabIndex = 79;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Location = new System.Drawing.Point(0, 523);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(543, 35);
            this.panel2.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 58);
            this.panel1.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.txtAccountDescription);
            this.groupBox1.Controls.Add(this.btnClearSummaryAccount);
            this.groupBox1.Controls.Add(this.pnlDebitSide);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSearchSummaryAccount);
            this.groupBox1.Controls.Add(this.txtCompanyPolicy);
            this.groupBox1.Controls.Add(this.txtSummaryAccount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAccountName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAccountCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 353);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ACCOUNT INFORMATION ";
            // 
            // txtAccountDescription
            // 
            this.txtAccountDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountDescription.BackColor = System.Drawing.Color.White;
            this.txtAccountDescription.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountDescription.Location = new System.Drawing.Point(172, 87);
            this.txtAccountDescription.MaxLength = 2000;
            this.txtAccountDescription.Multiline = true;
            this.txtAccountDescription.Name = "txtAccountDescription";
            this.txtAccountDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccountDescription.Size = new System.Drawing.Size(305, 75);
            this.txtAccountDescription.TabIndex = 59;
            // 
            // btnClearSummaryAccount
            // 
            this.btnClearSummaryAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClearSummaryAccount.BackgroundImage")));
            this.btnClearSummaryAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearSummaryAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearSummaryAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSummaryAccount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSummaryAccount.ForeColor = System.Drawing.Color.Transparent;
            this.btnClearSummaryAccount.Location = new System.Drawing.Point(483, 249);
            this.btnClearSummaryAccount.Name = "btnClearSummaryAccount";
            this.btnClearSummaryAccount.Size = new System.Drawing.Size(22, 22);
            this.btnClearSummaryAccount.TabIndex = 58;
            this.btnClearSummaryAccount.UseVisualStyleBackColor = true;
            // 
            // pnlDebitSide
            // 
            this.pnlDebitSide.Controls.Add(this.rdbYesDebitSide);
            this.pnlDebitSide.Controls.Add(this.rdbNoDebitSide);
            this.pnlDebitSide.Location = new System.Drawing.Point(172, 277);
            this.pnlDebitSide.Name = "pnlDebitSide";
            this.pnlDebitSide.Size = new System.Drawing.Size(112, 25);
            this.pnlDebitSide.TabIndex = 56;
            // 
            // rdbNoDebitSide
            // 
            this.rdbNoDebitSide.AutoSize = true;
            this.rdbNoDebitSide.Checked = true;
            this.rdbNoDebitSide.Location = new System.Drawing.Point(70, 3);
            this.rdbNoDebitSide.Name = "rdbNoDebitSide";
            this.rdbNoDebitSide.Size = new System.Drawing.Size(39, 18);
            this.rdbNoDebitSide.TabIndex = 53;
            this.rdbNoDebitSide.TabStop = true;
            this.rdbNoDebitSide.Text = "No";
            this.rdbNoDebitSide.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(60, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 51;
            this.label7.Text = "Is Active Account:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(40, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 15);
            this.label6.TabIndex = 50;
            this.label6.Text = "Is Debit Side Increase:";
            // 
            // btnSearchSummaryAccount
            // 
            this.btnSearchSummaryAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchSummaryAccount.BackgroundImage")));
            this.btnSearchSummaryAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchSummaryAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchSummaryAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSummaryAccount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSummaryAccount.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearchSummaryAccount.Location = new System.Drawing.Point(455, 248);
            this.btnSearchSummaryAccount.Name = "btnSearchSummaryAccount";
            this.btnSearchSummaryAccount.Size = new System.Drawing.Size(22, 22);
            this.btnSearchSummaryAccount.TabIndex = 49;
            this.btnSearchSummaryAccount.UseVisualStyleBackColor = true;
            // 
            // txtCompanyPolicy
            // 
            this.txtCompanyPolicy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompanyPolicy.BackColor = System.Drawing.Color.White;
            this.txtCompanyPolicy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyPolicy.Location = new System.Drawing.Point(172, 168);
            this.txtCompanyPolicy.MaxLength = 2000;
            this.txtCompanyPolicy.Multiline = true;
            this.txtCompanyPolicy.Name = "txtCompanyPolicy";
            this.txtCompanyPolicy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCompanyPolicy.Size = new System.Drawing.Size(305, 75);
            this.txtCompanyPolicy.TabIndex = 47;
            // 
            // txtSummaryAccount
            // 
            this.txtSummaryAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSummaryAccount.BackColor = System.Drawing.Color.White;
            this.txtSummaryAccount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSummaryAccount.Location = new System.Drawing.Point(172, 249);
            this.txtSummaryAccount.MaxLength = 100;
            this.txtSummaryAccount.Name = "txtSummaryAccount";
            this.txtSummaryAccount.ReadOnly = true;
            this.txtSummaryAccount.Size = new System.Drawing.Size(277, 23);
            this.txtSummaryAccount.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(53, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 15);
            this.label5.TabIndex = 46;
            this.label5.Text = "Account Summary:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 15);
            this.label4.TabIndex = 44;
            this.label4.Text = "Company Policy Procedure:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(43, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 15);
            this.label3.TabIndex = 42;
            this.label3.Text = "Account Description:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountName.BackColor = System.Drawing.Color.White;
            this.txtAccountName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(172, 58);
            this.txtAccountName.MaxLength = 100;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(305, 23);
            this.txtAccountName.TabIndex = 39;
            this.txtAccountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(72, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 40;
            this.label2.Text = "Account Name:";
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountCode.BackColor = System.Drawing.Color.White;
            this.txtAccountCode.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountCode.Location = new System.Drawing.Point(172, 29);
            this.txtAccountCode.MaxLength = 100;
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(305, 23);
            this.txtAccountCode.TabIndex = 37;
            this.txtAccountCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(77, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Account Code:";
            // 
            // rdbYesDebitSide
            // 
            this.rdbYesDebitSide.AutoSize = true;
            this.rdbYesDebitSide.Location = new System.Drawing.Point(3, 3);
            this.rdbYesDebitSide.Name = "rdbYesDebitSide";
            this.rdbYesDebitSide.Size = new System.Drawing.Size(42, 18);
            this.rdbYesDebitSide.TabIndex = 54;
            this.rdbYesDebitSide.Text = "Yes";
            this.rdbYesDebitSide.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdbYesActiveAccount);
            this.panel3.Controls.Add(this.rdbNoActiveAccount);
            this.panel3.Location = new System.Drawing.Point(172, 304);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(112, 25);
            this.panel3.TabIndex = 60;
            // 
            // rdbYesActiveAccount
            // 
            this.rdbYesActiveAccount.AutoSize = true;
            this.rdbYesActiveAccount.Checked = true;
            this.rdbYesActiveAccount.Location = new System.Drawing.Point(3, 3);
            this.rdbYesActiveAccount.Name = "rdbYesActiveAccount";
            this.rdbYesActiveAccount.Size = new System.Drawing.Size(42, 18);
            this.rdbYesActiveAccount.TabIndex = 54;
            this.rdbYesActiveAccount.TabStop = true;
            this.rdbYesActiveAccount.Text = "Yes";
            this.rdbYesActiveAccount.UseVisualStyleBackColor = true;
            // 
            // rdbNoActiveAccount
            // 
            this.rdbNoActiveAccount.AutoSize = true;
            this.rdbNoActiveAccount.Location = new System.Drawing.Point(70, 3);
            this.rdbNoActiveAccount.Name = "rdbNoActiveAccount";
            this.rdbNoActiveAccount.Size = new System.Drawing.Size(39, 18);
            this.rdbNoActiveAccount.TabIndex = 53;
            this.rdbNoActiveAccount.Text = "No";
            this.rdbNoActiveAccount.UseVisualStyleBackColor = true;
            // 
            // ChartOfAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(540, 558);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbxPersonalInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartOfAccount";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxPersonalInfo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlDebitSide.ResumeLayout(false);
            this.pnlDebitSide.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gbxPersonalInfo;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCompanyPolicy;
        private System.Windows.Forms.TextBox txtSummaryAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccountCode;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button btnSearchSummaryAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdbNoDebitSide;
        private System.Windows.Forms.Panel pnlDebitSide;
        protected System.Windows.Forms.ComboBox cboAccountCategory;
        private System.Windows.Forms.TextBox txtAccountDescription;
        protected System.Windows.Forms.Button btnClearSummaryAccount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdbYesActiveAccount;
        private System.Windows.Forms.RadioButton rdbNoActiveAccount;
        private System.Windows.Forms.RadioButton rdbYesDebitSide;

    }
}