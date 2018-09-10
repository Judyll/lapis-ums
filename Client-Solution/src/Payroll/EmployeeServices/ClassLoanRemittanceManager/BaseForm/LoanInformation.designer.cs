namespace EmployeeServices
{
    partial class LoanInformation
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
            this.lblId = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.gbxPrincipal = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrincipal = new System.Windows.Forms.TextBox();
            this.lblMaturityDate = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.cboLoanType = new System.Windows.Forms.ComboBox();
            this.lblSysID = new System.Windows.Forms.Label();
            this.gbxSysID = new System.Windows.Forms.GroupBox();
            this.gbxLoanType = new System.Windows.Forms.GroupBox();
            this.gbxReferenceNo = new System.Windows.Forms.GroupBox();
            this.gbxReleaseDate = new System.Windows.Forms.GroupBox();
            this.lnkReleaseDate = new System.Windows.Forms.LinkLabel();
            this.gbxMaturityDate = new System.Windows.Forms.GroupBox();
            this.lnkMaturityDate = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMonthlyAmmortization = new System.Windows.Forms.TextBox();
            this.gbxPrincipal.SuspendLayout();
            this.gbxSysID.SuspendLayout();
            this.gbxLoanType.SuspendLayout();
            this.gbxReferenceNo.SuspendLayout();
            this.gbxReleaseDate.SuspendLayout();
            this.gbxMaturityDate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(12, 63);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(291, 23);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "E2000-001-B";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 58);
            this.panel1.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(11, 85);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(599, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "E2000-001-B";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxPrincipal
            // 
            this.gbxPrincipal.Controls.Add(this.label3);
            this.gbxPrincipal.Controls.Add(this.txtPrincipal);
            this.gbxPrincipal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPrincipal.ForeColor = System.Drawing.Color.Navy;
            this.gbxPrincipal.Location = new System.Drawing.Point(319, 183);
            this.gbxPrincipal.Name = "gbxPrincipal";
            this.gbxPrincipal.Size = new System.Drawing.Size(294, 113);
            this.gbxPrincipal.TabIndex = 4;
            this.gbxPrincipal.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "Principal Amount w/ Interest";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrincipal
            // 
            this.txtPrincipal.BackColor = System.Drawing.Color.White;
            this.txtPrincipal.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrincipal.ForeColor = System.Drawing.Color.Red;
            this.txtPrincipal.Location = new System.Drawing.Point(6, 51);
            this.txtPrincipal.MaxLength = 12;
            this.txtPrincipal.Name = "txtPrincipal";
            this.txtPrincipal.Size = new System.Drawing.Size(268, 40);
            this.txtPrincipal.TabIndex = 0;
            this.txtPrincipal.Text = "0.00";
            this.txtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaturityDate
            // 
            this.lblMaturityDate.BackColor = System.Drawing.Color.Transparent;
            this.lblMaturityDate.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaturityDate.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblMaturityDate.Location = new System.Drawing.Point(62, 22);
            this.lblMaturityDate.Name = "lblMaturityDate";
            this.lblMaturityDate.Size = new System.Drawing.Size(225, 23);
            this.lblMaturityDate.TabIndex = 20;
            this.lblMaturityDate.Text = "label10";
            this.lblMaturityDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.BackColor = System.Drawing.Color.Transparent;
            this.lblReleaseDate.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleaseDate.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblReleaseDate.Location = new System.Drawing.Point(62, 22);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(225, 23);
            this.lblReleaseDate.TabIndex = 21;
            this.lblReleaseDate.Text = "label11";
            this.lblReleaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.BackColor = System.Drawing.Color.White;
            this.txtReferenceNo.Location = new System.Drawing.Point(60, 20);
            this.txtReferenceNo.MaxLength = 100;
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(228, 23);
            this.txtReferenceNo.TabIndex = 0;
            this.txtReferenceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboLoanType
            // 
            this.cboLoanType.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboLoanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoanType.FormattingEnabled = true;
            this.cboLoanType.Location = new System.Drawing.Point(9, 21);
            this.cboLoanType.Name = "cboLoanType";
            this.cboLoanType.Size = new System.Drawing.Size(265, 23);
            this.cboLoanType.TabIndex = 0;
            // 
            // lblSysID
            // 
            this.lblSysID.BackColor = System.Drawing.Color.Transparent;
            this.lblSysID.Location = new System.Drawing.Point(6, 20);
            this.lblSysID.Name = "lblSysID";
            this.lblSysID.Size = new System.Drawing.Size(282, 23);
            this.lblSysID.TabIndex = 19;
            this.lblSysID.Text = "Processing...";
            this.lblSysID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxSysID
            // 
            this.gbxSysID.Controls.Add(this.lblSysID);
            this.gbxSysID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSysID.ForeColor = System.Drawing.Color.Navy;
            this.gbxSysID.Location = new System.Drawing.Point(15, 124);
            this.gbxSysID.Name = "gbxSysID";
            this.gbxSysID.Size = new System.Drawing.Size(294, 53);
            this.gbxSysID.TabIndex = 8;
            this.gbxSysID.TabStop = false;
            this.gbxSysID.Text = " System ID ";
            // 
            // gbxLoanType
            // 
            this.gbxLoanType.Controls.Add(this.cboLoanType);
            this.gbxLoanType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxLoanType.ForeColor = System.Drawing.Color.Navy;
            this.gbxLoanType.Location = new System.Drawing.Point(319, 124);
            this.gbxLoanType.Name = "gbxLoanType";
            this.gbxLoanType.Size = new System.Drawing.Size(294, 53);
            this.gbxLoanType.TabIndex = 3;
            this.gbxLoanType.TabStop = false;
            this.gbxLoanType.Text = " Loan Type ";
            // 
            // gbxReferenceNo
            // 
            this.gbxReferenceNo.Controls.Add(this.txtReferenceNo);
            this.gbxReferenceNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxReferenceNo.ForeColor = System.Drawing.Color.Navy;
            this.gbxReferenceNo.Location = new System.Drawing.Point(15, 183);
            this.gbxReferenceNo.Name = "gbxReferenceNo";
            this.gbxReferenceNo.Size = new System.Drawing.Size(294, 53);
            this.gbxReferenceNo.TabIndex = 0;
            this.gbxReferenceNo.TabStop = false;
            this.gbxReferenceNo.Text = " Reference No. ";
            // 
            // gbxReleaseDate
            // 
            this.gbxReleaseDate.Controls.Add(this.lnkReleaseDate);
            this.gbxReleaseDate.Controls.Add(this.lblReleaseDate);
            this.gbxReleaseDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxReleaseDate.ForeColor = System.Drawing.Color.Navy;
            this.gbxReleaseDate.Location = new System.Drawing.Point(15, 242);
            this.gbxReleaseDate.Name = "gbxReleaseDate";
            this.gbxReleaseDate.Size = new System.Drawing.Size(294, 53);
            this.gbxReleaseDate.TabIndex = 1;
            this.gbxReleaseDate.TabStop = false;
            this.gbxReleaseDate.Text = " Release Date ";
            // 
            // lnkReleaseDate
            // 
            this.lnkReleaseDate.AutoSize = true;
            this.lnkReleaseDate.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lnkReleaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkReleaseDate.Location = new System.Drawing.Point(3, 32);
            this.lnkReleaseDate.Name = "lnkReleaseDate";
            this.lnkReleaseDate.Size = new System.Drawing.Size(48, 15);
            this.lnkReleaseDate.TabIndex = 0;
            this.lnkReleaseDate.TabStop = true;
            this.lnkReleaseDate.Text = "change";
            // 
            // gbxMaturityDate
            // 
            this.gbxMaturityDate.Controls.Add(this.lnkMaturityDate);
            this.gbxMaturityDate.Controls.Add(this.lblMaturityDate);
            this.gbxMaturityDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxMaturityDate.ForeColor = System.Drawing.Color.Navy;
            this.gbxMaturityDate.Location = new System.Drawing.Point(15, 301);
            this.gbxMaturityDate.Name = "gbxMaturityDate";
            this.gbxMaturityDate.Size = new System.Drawing.Size(294, 53);
            this.gbxMaturityDate.TabIndex = 2;
            this.gbxMaturityDate.TabStop = false;
            this.gbxMaturityDate.Text = " Maturity Date ";
            // 
            // lnkMaturityDate
            // 
            this.lnkMaturityDate.AutoSize = true;
            this.lnkMaturityDate.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lnkMaturityDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkMaturityDate.Location = new System.Drawing.Point(5, 32);
            this.lnkMaturityDate.Name = "lnkMaturityDate";
            this.lnkMaturityDate.Size = new System.Drawing.Size(48, 15);
            this.lnkMaturityDate.TabIndex = 0;
            this.lnkMaturityDate.TabStop = true;
            this.lnkMaturityDate.Text = "change";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(-1, 373);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 34);
            this.panel2.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMonthlyAmmortization);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(319, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 53);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Monthly Ammortization (Optional) ";
            // 
            // txtMonthlyAmmortization
            // 
            this.txtMonthlyAmmortization.BackColor = System.Drawing.Color.White;
            this.txtMonthlyAmmortization.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonthlyAmmortization.ForeColor = System.Drawing.Color.Red;
            this.txtMonthlyAmmortization.Location = new System.Drawing.Point(6, 21);
            this.txtMonthlyAmmortization.MaxLength = 12;
            this.txtMonthlyAmmortization.Name = "txtMonthlyAmmortization";
            this.txtMonthlyAmmortization.Size = new System.Drawing.Size(268, 27);
            this.txtMonthlyAmmortization.TabIndex = 25;
            this.txtMonthlyAmmortization.Text = "0.00";
            this.txtMonthlyAmmortization.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LoanInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(622, 406);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbxMaturityDate);
            this.Controls.Add(this.gbxReleaseDate);
            this.Controls.Add(this.gbxReferenceNo);
            this.Controls.Add(this.gbxLoanType);
            this.Controls.Add(this.gbxSysID);
            this.Controls.Add(this.gbxPrincipal);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanInformation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxPrincipal.ResumeLayout(false);
            this.gbxPrincipal.PerformLayout();
            this.gbxSysID.ResumeLayout(false);
            this.gbxLoanType.ResumeLayout(false);
            this.gbxReferenceNo.ResumeLayout(false);
            this.gbxReferenceNo.PerformLayout();
            this.gbxReleaseDate.ResumeLayout(false);
            this.gbxReleaseDate.PerformLayout();
            this.gbxMaturityDate.ResumeLayout(false);
            this.gbxMaturityDate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSysID;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label lblId;
        protected System.Windows.Forms.Label lblName;
        protected System.Windows.Forms.TextBox txtReferenceNo;
        protected System.Windows.Forms.ComboBox cboLoanType;
        protected System.Windows.Forms.Label lblSysID;
        protected System.Windows.Forms.Label lblReleaseDate;
        protected System.Windows.Forms.TextBox txtPrincipal;
        protected System.Windows.Forms.Label lblMaturityDate;
        protected System.Windows.Forms.LinkLabel lnkReleaseDate;
        protected System.Windows.Forms.LinkLabel lnkMaturityDate;
        protected System.Windows.Forms.GroupBox gbxPrincipal;
        protected System.Windows.Forms.GroupBox gbxLoanType;
        protected System.Windows.Forms.GroupBox gbxReferenceNo;
        protected System.Windows.Forms.GroupBox gbxReleaseDate;
        protected System.Windows.Forms.GroupBox gbxMaturityDate;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.TextBox txtMonthlyAmmortization;
    }
}