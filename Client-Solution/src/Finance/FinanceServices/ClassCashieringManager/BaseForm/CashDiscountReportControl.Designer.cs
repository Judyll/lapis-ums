namespace FinanceServices
{
    partial class CashDiscountReportControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashDiscountReportControl));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.receivedFrom = new System.Windows.Forms.ColumnHeader();
            this.course = new System.Windows.Forms.ColumnHeader();
            this.receivedDate = new System.Windows.Forms.ColumnHeader();
            this.clAccountCode = new System.Windows.Forms.ColumnHeader();
            this.receiptNo = new System.Windows.Forms.ColumnHeader();
            this.lsvCashReceiptDetails = new System.Windows.Forms.ListView();
            this.accountName = new System.Windows.Forms.ColumnHeader();
            this.clAmount = new System.Windows.Forms.ColumnHeader();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.btnShowResult = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.chkIsConsolidated = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(-1, 527);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 35);
            this.panel2.TabIndex = 111;
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(13, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 23);
            this.btnPrint.TabIndex = 71;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(896, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "  Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // receivedFrom
            // 
            this.receivedFrom.Text = "                     Received From";
            this.receivedFrom.Width = 220;
            // 
            // course
            // 
            this.course.Text = "   CRSE/DPT";
            this.course.Width = 90;
            // 
            // receivedDate
            // 
            this.receivedDate.Text = "Received Date";
            this.receivedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.receivedDate.Width = 100;
            // 
            // clAccountCode
            // 
            this.clAccountCode.Text = "  Account Code";
            this.clAccountCode.Width = 100;
            // 
            // receiptNo
            // 
            this.receiptNo.Text = "Receipt No.";
            this.receiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.receiptNo.Width = 80;
            // 
            // lsvCashReceiptDetails
            // 
            this.lsvCashReceiptDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvCashReceiptDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.receiptNo,
            this.receivedDate,
            this.receivedFrom,
            this.course,
            this.clAccountCode,
            this.accountName,
            this.clAmount});
            this.lsvCashReceiptDetails.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvCashReceiptDetails.FullRowSelect = true;
            this.lsvCashReceiptDetails.GridLines = true;
            this.lsvCashReceiptDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvCashReceiptDetails.HideSelection = false;
            this.lsvCashReceiptDetails.Location = new System.Drawing.Point(12, 137);
            this.lsvCashReceiptDetails.MultiSelect = false;
            this.lsvCashReceiptDetails.Name = "lsvCashReceiptDetails";
            this.lsvCashReceiptDetails.ShowItemToolTips = true;
            this.lsvCashReceiptDetails.Size = new System.Drawing.Size(970, 375);
            this.lsvCashReceiptDetails.TabIndex = 112;
            this.lsvCashReceiptDetails.UseCompatibleStateImageBehavior = false;
            this.lsvCashReceiptDetails.View = System.Windows.Forms.View.Details;
            // 
            // accountName
            // 
            this.accountName.Text = "                          Account Name";
            this.accountName.Width = 240;
            // 
            // clAmount
            // 
            this.clAmount.Text = "Discount Amount  ";
            this.clAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clAmount.Width = 120;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Silver;
            this.pnlDetails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlDetails.BackgroundImage")));
            this.pnlDetails.Location = new System.Drawing.Point(-1, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(997, 58);
            this.pnlDetails.TabIndex = 109;
            // 
            // btnShowResult
            // 
            this.btnShowResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowResult.Location = new System.Drawing.Point(855, 23);
            this.btnShowResult.Name = "btnShowResult";
            this.btnShowResult.Size = new System.Drawing.Size(109, 23);
            this.btnShowResult.TabIndex = 105;
            this.btnShowResult.Text = "Show Result";
            this.btnShowResult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowResult.UseVisualStyleBackColor = true;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Checked = false;
            this.dtpEnd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(407, 22);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(219, 23);
            this.dtpEnd.TabIndex = 1;
            // 
            // chkIsConsolidated
            // 
            this.chkIsConsolidated.AutoSize = true;
            this.chkIsConsolidated.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsConsolidated.Location = new System.Drawing.Point(649, 27);
            this.chkIsConsolidated.Name = "chkIsConsolidated";
            this.chkIsConsolidated.Size = new System.Drawing.Size(100, 18);
            this.chkIsConsolidated.TabIndex = 104;
            this.chkIsConsolidated.Text = "Is Consolidated";
            this.chkIsConsolidated.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(341, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 100;
            this.label2.Text = "Date End:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnShowResult);
            this.groupBox2.Controls.Add(this.chkIsConsolidated);
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(970, 60);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Date Range ";
            // 
            // dtpStart
            // 
            this.dtpStart.Checked = false;
            this.dtpStart.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Location = new System.Drawing.Point(88, 23);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(220, 23);
            this.dtpStart.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 99;
            this.label1.Text = "Date Start:";
            // 
            // CashDiscountReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(994, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lsvCashReceiptDetails);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashDiscountReportControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader receivedFrom;
        private System.Windows.Forms.ColumnHeader course;
        private System.Windows.Forms.ColumnHeader receivedDate;
        private System.Windows.Forms.ColumnHeader clAccountCode;
        private System.Windows.Forms.ColumnHeader receiptNo;
        private System.Windows.Forms.ListView lsvCashReceiptDetails;
        private System.Windows.Forms.ColumnHeader accountName;
        private System.Windows.Forms.ColumnHeader clAmount;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Button btnShowResult;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        protected System.Windows.Forms.CheckBox chkIsConsolidated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
    }
}