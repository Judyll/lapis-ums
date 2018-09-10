namespace FinanceServices
{
    partial class CashReceiptReportControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashReceiptReportControl));
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("TUITION FEE, MISCELLANEOUS, OTHER FEES, LABORATORY FEES", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("MISCELLANEOUS INCOME", System.Windows.Forms.HorizontalAlignment.Left);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lsvCashReceiptDetails = new System.Windows.Forms.ListView();
            this.receiptNo = new System.Windows.Forms.ColumnHeader();
            this.receivedDate = new System.Windows.Forms.ColumnHeader();
            this.receivedFrom = new System.Windows.Forms.ColumnHeader();
            this.course = new System.Windows.Forms.ColumnHeader();
            this.clAccountCode = new System.Windows.Forms.ColumnHeader();
            this.accountName = new System.Windows.Forms.ColumnHeader();
            this.clAmount = new System.Windows.Forms.ColumnHeader();
            this.chkIsConsolidated = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnShowResult = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvCashReceipsSummariezed = new System.Windows.Forms.ListView();
            this.smAccountCode = new System.Windows.Forms.ColumnHeader();
            this.smAccountName = new System.Windows.Forms.ColumnHeader();
            this.cmCourse = new System.Windows.Forms.ColumnHeader();
            this.smSubCode = new System.Windows.Forms.ColumnHeader();
            this.smSubName = new System.Windows.Forms.ColumnHeader();
            this.smAmount = new System.Windows.Forms.ColumnHeader();
            this.smTotal = new System.Windows.Forms.ColumnHeader();
            this.pnlSummarized = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkCreateBreakDownDeposit = new System.Windows.Forms.LinkLabel();
            this.lsvBankDeposits = new System.Windows.Forms.ListView();
            this.clAccountCode1 = new System.Windows.Forms.ColumnHeader();
            this.clAccountName1 = new System.Windows.Forms.ColumnHeader();
            this.clSubCode = new System.Windows.Forms.ColumnHeader();
            this.clSubName = new System.Windows.Forms.ColumnHeader();
            this.clAmount1 = new System.Windows.Forms.ColumnHeader();
            this.clSystemId = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblShortage = new System.Windows.Forms.Label();
            this.lblTotalCashReceipts = new System.Windows.Forms.Label();
            this.lblTotalDeposits = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.panel2.TabIndex = 79;
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
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Silver;
            this.pnlDetails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlDetails.BackgroundImage")));
            this.pnlDetails.Location = new System.Drawing.Point(-1, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(997, 58);
            this.pnlDetails.TabIndex = 78;
            this.pnlDetails.Visible = false;
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
            this.lsvCashReceiptDetails.Location = new System.Drawing.Point(12, 133);
            this.lsvCashReceiptDetails.MultiSelect = false;
            this.lsvCashReceiptDetails.Name = "lsvCashReceiptDetails";
            this.lsvCashReceiptDetails.ShowItemToolTips = true;
            this.lsvCashReceiptDetails.Size = new System.Drawing.Size(970, 310);
            this.lsvCashReceiptDetails.TabIndex = 80;
            this.lsvCashReceiptDetails.UseCompatibleStateImageBehavior = false;
            this.lsvCashReceiptDetails.View = System.Windows.Forms.View.Details;
            this.lsvCashReceiptDetails.Visible = false;
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
            this.groupBox2.TabIndex = 103;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Date Range ";
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
            // lsvCashReceipsSummariezed
            // 
            this.lsvCashReceipsSummariezed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvCashReceipsSummariezed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.smAccountCode,
            this.smAccountName,
            this.cmCourse,
            this.smSubCode,
            this.smSubName,
            this.smAmount,
            this.smTotal});
            this.lsvCashReceipsSummariezed.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvCashReceipsSummariezed.FullRowSelect = true;
            this.lsvCashReceipsSummariezed.GridLines = true;
            listViewGroup3.Header = "TUITION FEE, MISCELLANEOUS, OTHER FEES, LABORATORY FEES";
            listViewGroup3.Name = "grpStudentPayments";
            listViewGroup4.Header = "MISCELLANEOUS INCOME";
            listViewGroup4.Name = "grpMiscellaneousIncome";
            this.lsvCashReceipsSummariezed.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.lsvCashReceipsSummariezed.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvCashReceipsSummariezed.HideSelection = false;
            this.lsvCashReceipsSummariezed.Location = new System.Drawing.Point(12, 133);
            this.lsvCashReceipsSummariezed.MultiSelect = false;
            this.lsvCashReceipsSummariezed.Name = "lsvCashReceipsSummariezed";
            this.lsvCashReceipsSummariezed.ShowItemToolTips = true;
            this.lsvCashReceipsSummariezed.Size = new System.Drawing.Size(970, 310);
            this.lsvCashReceipsSummariezed.TabIndex = 106;
            this.lsvCashReceipsSummariezed.UseCompatibleStateImageBehavior = false;
            this.lsvCashReceipsSummariezed.View = System.Windows.Forms.View.Details;
            this.lsvCashReceipsSummariezed.Visible = false;
            // 
            // smAccountCode
            // 
            this.smAccountCode.Text = "  Account Code";
            this.smAccountCode.Width = 100;
            // 
            // smAccountName
            // 
            this.smAccountName.Text = "                    Account Name";
            this.smAccountName.Width = 240;
            // 
            // cmCourse
            // 
            this.cmCourse.Text = " CRSE/DPT";
            this.cmCourse.Width = 100;
            // 
            // smSubCode
            // 
            this.smSubCode.Text = "Sub. Code";
            this.smSubCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.smSubCode.Width = 90;
            // 
            // smSubName
            // 
            this.smSubName.Text = "                          Sub. Name";
            this.smSubName.Width = 240;
            // 
            // smAmount
            // 
            this.smAmount.Text = "Amount      ";
            this.smAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.smAmount.Width = 90;
            // 
            // smTotal
            // 
            this.smTotal.Text = "Total         ";
            this.smTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.smTotal.Width = 90;
            // 
            // pnlSummarized
            // 
            this.pnlSummarized.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlSummarized.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlSummarized.BackgroundImage")));
            this.pnlSummarized.Location = new System.Drawing.Point(-1, 0);
            this.pnlSummarized.Name = "pnlSummarized";
            this.pnlSummarized.Size = new System.Drawing.Size(997, 58);
            this.pnlSummarized.TabIndex = 79;
            this.pnlSummarized.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkCreateBreakDownDeposit);
            this.groupBox1.Controls.Add(this.lsvBankDeposits);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 449);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(970, 150);
            this.groupBox1.TabIndex = 107;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Break Down of Bank Deposits ";
            // 
            // lnkCreateBreakDownDeposit
            // 
            this.lnkCreateBreakDownDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkCreateBreakDownDeposit.AutoSize = true;
            this.lnkCreateBreakDownDeposit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreateBreakDownDeposit.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkCreateBreakDownDeposit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreateBreakDownDeposit.Location = new System.Drawing.Point(787, 129);
            this.lnkCreateBreakDownDeposit.Name = "lnkCreateBreakDownDeposit";
            this.lnkCreateBreakDownDeposit.Size = new System.Drawing.Size(177, 15);
            this.lnkCreateBreakDownDeposit.TabIndex = 82;
            this.lnkCreateBreakDownDeposit.TabStop = true;
            this.lnkCreateBreakDownDeposit.Text = "[ Create Break Down Deposit ]";
            this.lnkCreateBreakDownDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkCreateBreakDownDeposit.Visible = false;
            // 
            // lsvBankDeposits
            // 
            this.lsvBankDeposits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvBankDeposits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clAccountCode1,
            this.clAccountName1,
            this.clSubCode,
            this.clSubName,
            this.clAmount1,
            this.clSystemId});
            this.lsvBankDeposits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvBankDeposits.FullRowSelect = true;
            this.lsvBankDeposits.GridLines = true;
            this.lsvBankDeposits.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvBankDeposits.HideSelection = false;
            this.lsvBankDeposits.Location = new System.Drawing.Point(6, 22);
            this.lsvBankDeposits.MultiSelect = false;
            this.lsvBankDeposits.Name = "lsvBankDeposits";
            this.lsvBankDeposits.ShowItemToolTips = true;
            this.lsvBankDeposits.Size = new System.Drawing.Size(958, 104);
            this.lsvBankDeposits.TabIndex = 81;
            this.lsvBankDeposits.UseCompatibleStateImageBehavior = false;
            this.lsvBankDeposits.View = System.Windows.Forms.View.Details;
            // 
            // clAccountCode1
            // 
            this.clAccountCode1.Text = "        Account Code";
            this.clAccountCode1.Width = 150;
            // 
            // clAccountName1
            // 
            this.clAccountName1.Text = "                         Account Name";
            this.clAccountName1.Width = 250;
            // 
            // clSubCode
            // 
            this.clSubCode.Text = "              Sub. Code";
            this.clSubCode.Width = 150;
            // 
            // clSubName
            // 
            this.clSubName.Text = "                              Sub. Name";
            this.clSubName.Width = 250;
            // 
            // clAmount1
            // 
            this.clAmount1.Text = "Amount          ";
            this.clAmount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clAmount1.Width = 130;
            // 
            // clSystemId
            // 
            this.clSystemId.Text = "";
            this.clSystemId.Width = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblShortage);
            this.groupBox3.Controls.Add(this.lblTotalCashReceipts);
            this.groupBox3.Controls.Add(this.lblTotalDeposits);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 605);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(970, 66);
            this.groupBox3.TabIndex = 108;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Summary ";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(718, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 19);
            this.label5.TabIndex = 102;
            this.label5.Text = "Overage/(Shortage)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(368, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 19);
            this.label4.TabIndex = 101;
            this.label4.Text = "Total cash receipts for the period";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 19);
            this.label3.TabIndex = 100;
            this.label3.Text = "Total bank deposits for the period";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShortage
            // 
            this.lblShortage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortage.ForeColor = System.Drawing.Color.Red;
            this.lblShortage.Location = new System.Drawing.Point(718, 38);
            this.lblShortage.Name = "lblShortage";
            this.lblShortage.Size = new System.Drawing.Size(238, 19);
            this.lblShortage.TabIndex = 105;
            this.lblShortage.Text = "-";
            this.lblShortage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalCashReceipts
            // 
            this.lblTotalCashReceipts.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCashReceipts.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCashReceipts.Location = new System.Drawing.Point(368, 38);
            this.lblTotalCashReceipts.Name = "lblTotalCashReceipts";
            this.lblTotalCashReceipts.Size = new System.Drawing.Size(238, 19);
            this.lblTotalCashReceipts.TabIndex = 104;
            this.lblTotalCashReceipts.Text = "-";
            this.lblTotalCashReceipts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalDeposits
            // 
            this.lblTotalDeposits.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDeposits.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDeposits.Location = new System.Drawing.Point(18, 38);
            this.lblTotalDeposits.Name = "lblTotalDeposits";
            this.lblTotalDeposits.Size = new System.Drawing.Size(238, 19);
            this.lblTotalDeposits.TabIndex = 103;
            this.lblTotalDeposits.Text = "-";
            this.lblTotalDeposits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CashReceiptReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(994, 712);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lsvCashReceiptDetails);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.lsvCashReceipsSummariezed);
            this.Controls.Add(this.pnlSummarized);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashReceiptReportControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.ListView lsvCashReceiptDetails;
        private System.Windows.Forms.ColumnHeader clAccountCode;
        private System.Windows.Forms.ColumnHeader accountName;
        private System.Windows.Forms.ColumnHeader receivedDate;
        private System.Windows.Forms.ColumnHeader receivedFrom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader course;
        private System.Windows.Forms.ColumnHeader receiptNo;
        private System.Windows.Forms.ColumnHeader clAmount;
        protected System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnShowResult;
        protected System.Windows.Forms.CheckBox chkIsConsolidated;
        private System.Windows.Forms.ListView lsvCashReceipsSummariezed;
        private System.Windows.Forms.ColumnHeader smAccountCode;
        private System.Windows.Forms.ColumnHeader smAccountName;
        private System.Windows.Forms.ColumnHeader cmCourse;
        private System.Windows.Forms.ColumnHeader smSubCode;
        private System.Windows.Forms.ColumnHeader smSubName;
        private System.Windows.Forms.ColumnHeader smAmount;
        private System.Windows.Forms.ColumnHeader smTotal;
        private System.Windows.Forms.Panel pnlSummarized;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lsvBankDeposits;
        private System.Windows.Forms.ColumnHeader clAccountCode1;
        private System.Windows.Forms.ColumnHeader clAccountName1;
        private System.Windows.Forms.ColumnHeader clSubCode;
        private System.Windows.Forms.ColumnHeader clSubName;
        private System.Windows.Forms.ColumnHeader clAmount1;
        private System.Windows.Forms.ColumnHeader clSystemId;
        protected System.Windows.Forms.LinkLabel lnkCreateBreakDownDeposit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblShortage;
        private System.Windows.Forms.Label lblTotalCashReceipts;
        private System.Windows.Forms.Label lblTotalDeposits;
    }
}