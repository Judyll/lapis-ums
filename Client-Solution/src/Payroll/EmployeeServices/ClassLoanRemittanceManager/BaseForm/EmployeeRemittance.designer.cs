namespace EmployeeServices
{
    partial class EmployeeRemittance
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
            this.lblName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEmpId = new System.Windows.Forms.Label();
            this.gbxSysID = new System.Windows.Forms.GroupBox();
            this.lblSysID = new System.Windows.Forms.Label();
            this.gbxRemittanceDate = new System.Windows.Forms.GroupBox();
            this.lblRemittanceDate = new System.Windows.Forms.Label();
            this.lnkChangeDate = new System.Windows.Forms.LinkLabel();
            this.gbxAmountPaid = new System.Windows.Forms.GroupBox();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.gbxAmountBalance = new System.Windows.Forms.GroupBox();
            this.txtAmountBalance = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLoanId = new System.Windows.Forms.Label();
            this.gbxSysID.SuspendLayout();
            this.gbxRemittanceDate.SuspendLayout();
            this.gbxAmountPaid.SuspendLayout();
            this.gbxAmountBalance.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(11, 89);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(599, 23);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Altavista";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 58);
            this.panel1.TabIndex = 4;
            // 
            // lblEmpId
            // 
            this.lblEmpId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpId.Location = new System.Drawing.Point(12, 67);
            this.lblEmpId.Name = "lblEmpId";
            this.lblEmpId.Size = new System.Drawing.Size(597, 23);
            this.lblEmpId.TabIndex = 3;
            this.lblEmpId.Text = "E2000-001-B";
            this.lblEmpId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxSysID
            // 
            this.gbxSysID.Controls.Add(this.lblSysID);
            this.gbxSysID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSysID.ForeColor = System.Drawing.Color.Navy;
            this.gbxSysID.Location = new System.Drawing.Point(15, 170);
            this.gbxSysID.Name = "gbxSysID";
            this.gbxSysID.Size = new System.Drawing.Size(294, 53);
            this.gbxSysID.TabIndex = 9;
            this.gbxSysID.TabStop = false;
            this.gbxSysID.Text = " System ID ";
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
            // gbxRemittanceDate
            // 
            this.gbxRemittanceDate.Controls.Add(this.lblRemittanceDate);
            this.gbxRemittanceDate.Controls.Add(this.lnkChangeDate);
            this.gbxRemittanceDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRemittanceDate.ForeColor = System.Drawing.Color.Navy;
            this.gbxRemittanceDate.Location = new System.Drawing.Point(15, 230);
            this.gbxRemittanceDate.Name = "gbxRemittanceDate";
            this.gbxRemittanceDate.Size = new System.Drawing.Size(294, 53);
            this.gbxRemittanceDate.TabIndex = 1;
            this.gbxRemittanceDate.TabStop = false;
            this.gbxRemittanceDate.Text = " Remittance Date ";
            // 
            // lblRemittanceDate
            // 
            this.lblRemittanceDate.BackColor = System.Drawing.Color.Transparent;
            this.lblRemittanceDate.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemittanceDate.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblRemittanceDate.Location = new System.Drawing.Point(62, 22);
            this.lblRemittanceDate.Name = "lblRemittanceDate";
            this.lblRemittanceDate.Size = new System.Drawing.Size(225, 23);
            this.lblRemittanceDate.TabIndex = 29;
            this.lblRemittanceDate.Text = "label11";
            this.lblRemittanceDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkChangeDate
            // 
            this.lnkChangeDate.AutoSize = true;
            this.lnkChangeDate.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lnkChangeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkChangeDate.Location = new System.Drawing.Point(3, 32);
            this.lnkChangeDate.Name = "lnkChangeDate";
            this.lnkChangeDate.Size = new System.Drawing.Size(48, 15);
            this.lnkChangeDate.TabIndex = 0;
            this.lnkChangeDate.TabStop = true;
            this.lnkChangeDate.Text = "change";
            // 
            // gbxAmountPaid
            // 
            this.gbxAmountPaid.Controls.Add(this.txtAmountPaid);
            this.gbxAmountPaid.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAmountPaid.ForeColor = System.Drawing.Color.Navy;
            this.gbxAmountPaid.Location = new System.Drawing.Point(315, 170);
            this.gbxAmountPaid.Name = "gbxAmountPaid";
            this.gbxAmountPaid.Size = new System.Drawing.Size(294, 54);
            this.gbxAmountPaid.TabIndex = 0;
            this.gbxAmountPaid.TabStop = false;
            this.gbxAmountPaid.Text = " Amount Paid ";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.BackColor = System.Drawing.Color.White;
            this.txtAmountPaid.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPaid.ForeColor = System.Drawing.Color.Red;
            this.txtAmountPaid.Location = new System.Drawing.Point(60, 19);
            this.txtAmountPaid.MaxLength = 12;
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(228, 31);
            this.txtAmountPaid.TabIndex = 0;
            this.txtAmountPaid.Text = "0.00";
            this.txtAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbxAmountBalance
            // 
            this.gbxAmountBalance.Controls.Add(this.txtAmountBalance);
            this.gbxAmountBalance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAmountBalance.ForeColor = System.Drawing.Color.Navy;
            this.gbxAmountBalance.Location = new System.Drawing.Point(315, 230);
            this.gbxAmountBalance.Name = "gbxAmountBalance";
            this.gbxAmountBalance.Size = new System.Drawing.Size(294, 53);
            this.gbxAmountBalance.TabIndex = 5;
            this.gbxAmountBalance.TabStop = false;
            this.gbxAmountBalance.Text = " Amount Balance ";
            // 
            // txtAmountBalance
            // 
            this.txtAmountBalance.BackColor = System.Drawing.Color.White;
            this.txtAmountBalance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountBalance.ForeColor = System.Drawing.Color.Red;
            this.txtAmountBalance.Location = new System.Drawing.Point(62, 18);
            this.txtAmountBalance.MaxLength = 12;
            this.txtAmountBalance.Name = "txtAmountBalance";
            this.txtAmountBalance.ReadOnly = true;
            this.txtAmountBalance.Size = new System.Drawing.Size(226, 31);
            this.txtAmountBalance.TabIndex = 14;
            this.txtAmountBalance.Text = "0.00";
            this.txtAmountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(-1, 297);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 34);
            this.panel2.TabIndex = 28;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.Maroon;
            this.lblDescription.Location = new System.Drawing.Point(13, 140);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(599, 23);
            this.lblDescription.TabIndex = 30;
            this.lblDescription.Text = "Altavista";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoanId
            // 
            this.lblLoanId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanId.ForeColor = System.Drawing.Color.Maroon;
            this.lblLoanId.Location = new System.Drawing.Point(14, 118);
            this.lblLoanId.Name = "lblLoanId";
            this.lblLoanId.Size = new System.Drawing.Size(595, 23);
            this.lblLoanId.TabIndex = 29;
            this.lblLoanId.Text = "E2000-001-B";
            this.lblLoanId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EmployeeRemittance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(624, 329);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblLoanId);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbxRemittanceDate);
            this.Controls.Add(this.gbxAmountBalance);
            this.Controls.Add(this.gbxAmountPaid);
            this.Controls.Add(this.gbxSysID);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblEmpId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeRemittance";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxSysID.ResumeLayout(false);
            this.gbxRemittanceDate.ResumeLayout(false);
            this.gbxRemittanceDate.PerformLayout();
            this.gbxAmountPaid.ResumeLayout(false);
            this.gbxAmountPaid.PerformLayout();
            this.gbxAmountBalance.ResumeLayout(false);
            this.gbxAmountBalance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSysID;
        public System.Windows.Forms.LinkLabel lnkChangeDate;
        protected System.Windows.Forms.Label lblRemittanceDate;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.GroupBox gbxRemittanceDate;
        protected System.Windows.Forms.GroupBox gbxAmountPaid;
        protected System.Windows.Forms.GroupBox gbxAmountBalance;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Label lblName;
        protected System.Windows.Forms.Label lblEmpId;
        protected System.Windows.Forms.Label lblDescription;
        protected System.Windows.Forms.Label lblLoanId;
        protected System.Windows.Forms.TextBox txtAmountBalance;
        protected System.Windows.Forms.TextBox txtAmountPaid;
        protected System.Windows.Forms.Label lblSysID;
    }
}