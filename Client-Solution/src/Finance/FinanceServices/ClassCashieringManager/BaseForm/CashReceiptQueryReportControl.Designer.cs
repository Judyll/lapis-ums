namespace FinanceServices
{
    partial class CashReceiptQueryReportControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashReceiptQueryReportControl));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnShowResult = new System.Windows.Forms.Button();
            this.btnSearchCreditEntry = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCreditEntry = new System.Windows.Forms.TextBox();
            this.lnkResetQuery = new System.Windows.Forms.LinkLabel();
            this.chkIncludeDate = new System.Windows.Forms.CheckBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lsvCashReceiptQuery = new System.Windows.Forms.ListView();
            this.receiptNo = new System.Windows.Forms.ColumnHeader();
            this.receivedDate = new System.Windows.Forms.ColumnHeader();
            this.receivedFrom = new System.Windows.Forms.ColumnHeader();
            this.course = new System.Windows.Forms.ColumnHeader();
            this.clAccountCode = new System.Windows.Forms.ColumnHeader();
            this.accountName = new System.Windows.Forms.ColumnHeader();
            this.clAmount = new System.Windows.Forms.ColumnHeader();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(-1, 677);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 35);
            this.panel2.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(13, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 23);
            this.btnPrint.TabIndex = 0;
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
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "  Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Silver;
            this.pnlDetails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlDetails.BackgroundImage")));
            this.pnlDetails.Location = new System.Drawing.Point(-1, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(997, 58);
            this.pnlDetails.TabIndex = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnShowResult);
            this.groupBox2.Controls.Add(this.btnSearchCreditEntry);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCreditEntry);
            this.groupBox2.Controls.Add(this.lnkResetQuery);
            this.groupBox2.Controls.Add(this.chkIncludeDate);
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(969, 115);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Search Query ";
            // 
            // btnShowResult
            // 
            this.btnShowResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowResult.Location = new System.Drawing.Point(883, 82);
            this.btnShowResult.Name = "btnShowResult";
            this.btnShowResult.Size = new System.Drawing.Size(80, 23);
            this.btnShowResult.TabIndex = 106;
            this.btnShowResult.Text = "Show Result";
            this.btnShowResult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowResult.UseVisualStyleBackColor = true;
            // 
            // btnSearchCreditEntry
            // 
            this.btnSearchCreditEntry.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchCreditEntry.BackgroundImage")));
            this.btnSearchCreditEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchCreditEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchCreditEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCreditEntry.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCreditEntry.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearchCreditEntry.Location = new System.Drawing.Point(550, 60);
            this.btnSearchCreditEntry.Name = "btnSearchCreditEntry";
            this.btnSearchCreditEntry.Size = new System.Drawing.Size(26, 26);
            this.btnSearchCreditEntry.TabIndex = 3;
            this.btnSearchCreditEntry.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(98, 21);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(478, 29);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(47, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Query:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Credit Entry:";
            // 
            // txtCreditEntry
            // 
            this.txtCreditEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreditEntry.BackColor = System.Drawing.Color.White;
            this.txtCreditEntry.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditEntry.Location = new System.Drawing.Point(98, 56);
            this.txtCreditEntry.MaxLength = 50;
            this.txtCreditEntry.Multiline = true;
            this.txtCreditEntry.Name = "txtCreditEntry";
            this.txtCreditEntry.ReadOnly = true;
            this.txtCreditEntry.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCreditEntry.Size = new System.Drawing.Size(446, 38);
            this.txtCreditEntry.TabIndex = 2;
            // 
            // lnkResetQuery
            // 
            this.lnkResetQuery.AutoSize = true;
            this.lnkResetQuery.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkResetQuery.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkResetQuery.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkResetQuery.Location = new System.Drawing.Point(886, 27);
            this.lnkResetQuery.Name = "lnkResetQuery";
            this.lnkResetQuery.Size = new System.Drawing.Size(77, 15);
            this.lnkResetQuery.TabIndex = 7;
            this.lnkResetQuery.TabStop = true;
            this.lnkResetQuery.Text = "Reset Query";
            this.lnkResetQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIncludeDate
            // 
            this.chkIncludeDate.AutoSize = true;
            this.chkIncludeDate.Location = new System.Drawing.Point(658, 82);
            this.chkIncludeDate.Name = "chkIncludeDate";
            this.chkIncludeDate.Size = new System.Drawing.Size(88, 18);
            this.chkIncludeDate.TabIndex = 6;
            this.chkIncludeDate.Text = "Include Date";
            this.chkIncludeDate.UseVisualStyleBackColor = true;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Checked = false;
            this.dtpEnd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(658, 50);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(219, 23);
            this.dtpEnd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(592, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date End:";
            // 
            // dtpStart
            // 
            this.dtpStart.Checked = false;
            this.dtpStart.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Location = new System.Drawing.Point(658, 21);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(220, 23);
            this.dtpStart.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(585, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date Start:";
            // 
            // lsvCashReceiptQuery
            // 
            this.lsvCashReceiptQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvCashReceiptQuery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.receiptNo,
            this.receivedDate,
            this.receivedFrom,
            this.course,
            this.clAccountCode,
            this.accountName,
            this.clAmount});
            this.lsvCashReceiptQuery.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvCashReceiptQuery.FullRowSelect = true;
            this.lsvCashReceiptQuery.GridLines = true;
            this.lsvCashReceiptQuery.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvCashReceiptQuery.HideSelection = false;
            this.lsvCashReceiptQuery.Location = new System.Drawing.Point(12, 185);
            this.lsvCashReceiptQuery.MultiSelect = false;
            this.lsvCashReceiptQuery.Name = "lsvCashReceiptQuery";
            this.lsvCashReceiptQuery.ShowItemToolTips = true;
            this.lsvCashReceiptQuery.Size = new System.Drawing.Size(970, 486);
            this.lsvCashReceiptQuery.TabIndex = 1;
            this.lsvCashReceiptQuery.UseCompatibleStateImageBehavior = false;
            this.lsvCashReceiptQuery.View = System.Windows.Forms.View.Details;
            // 
            // receiptNo
            // 
            this.receiptNo.Text = "Receipt No.";
            this.receiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.receiptNo.Width = 80;
            // 
            // receivedDate
            // 
            this.receivedDate.Text = "Received Date";
            this.receivedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.receivedDate.Width = 100;
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
            // clAccountCode
            // 
            this.clAccountCode.Text = "  Account Code";
            this.clAccountCode.Width = 100;
            // 
            // accountName
            // 
            this.accountName.Text = "                          Account Name";
            this.accountName.Width = 240;
            // 
            // clAmount
            // 
            this.clAmount.Text = "Amount          ";
            this.clAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clAmount.Width = 120;
            // 
            // CashReceiptQueryReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(994, 712);
            this.Controls.Add(this.lsvCashReceiptQuery);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDetails);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashReceiptQueryReportControl";
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
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkIncludeDate;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtCreditEntry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.LinkLabel lnkResetQuery;
        protected System.Windows.Forms.TextBox txtSearch;
        protected System.Windows.Forms.Button btnSearchCreditEntry;
        private System.Windows.Forms.ListView lsvCashReceiptQuery;
        private System.Windows.Forms.ColumnHeader receiptNo;
        private System.Windows.Forms.ColumnHeader receivedDate;
        private System.Windows.Forms.ColumnHeader receivedFrom;
        private System.Windows.Forms.ColumnHeader course;
        private System.Windows.Forms.ColumnHeader clAccountCode;
        private System.Windows.Forms.ColumnHeader accountName;
        private System.Windows.Forms.ColumnHeader clAmount;
        private System.Windows.Forms.Button btnShowResult;
    }
}