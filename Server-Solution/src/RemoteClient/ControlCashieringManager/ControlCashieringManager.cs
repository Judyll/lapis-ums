using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteClient
{
    public partial class ControlCashieringManager : AnimatedPanel
    {
        protected System.Windows.Forms.PictureBox pbxClose;
        protected System.Windows.Forms.TextBox txtStudentTab;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.PictureBox pbxAdditionalFee;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.LinkLabel lnkScholarshipDiscounts;
        protected System.Windows.Forms.LinkLabel lnkCreditMemo;
        protected System.Windows.Forms.LinkLabel lnkRegisterSummarized;
        protected System.Windows.Forms.LinkLabel lnkRegisterDetailed;
        protected System.Windows.Forms.LinkLabel lnkARStudentPerTerm;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.LinkLabel lnkDecrement;
        protected System.Windows.Forms.TextBox txtReceiptNo;
        protected System.Windows.Forms.LinkLabel lnkIncrement;
        protected System.Windows.Forms.LinkLabel lnkViewCancel;
        protected System.Windows.Forms.LinkLabel lnkCancelReceipt;
        protected System.Windows.Forms.LinkLabel lnkARStudentPerFiscalYear;
        protected System.Windows.Forms.PictureBox pbxMiscellaneousIncome;
        protected System.Windows.Forms.LinkLabel lnkCashReceiptsDetailed;
        protected System.Windows.Forms.LinkLabel lnkCashReceiptsSummarized;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpReceiptDate;
        protected System.Windows.Forms.LinkLabel lnkCashDiscounts;
        protected System.Windows.Forms.LinkLabel lnkCashReceiptsQuery;
        protected System.Windows.Forms.PictureBox pbxRefresh;
    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCashieringManager));
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.pbxRefresh = new System.Windows.Forms.PictureBox();
            this.txtStudentTab = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbxAdditionalFee = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkCashReceiptsQuery = new System.Windows.Forms.LinkLabel();
            this.lnkCashDiscounts = new System.Windows.Forms.LinkLabel();
            this.lnkCashReceiptsSummarized = new System.Windows.Forms.LinkLabel();
            this.lnkCashReceiptsDetailed = new System.Windows.Forms.LinkLabel();
            this.lnkARStudentPerFiscalYear = new System.Windows.Forms.LinkLabel();
            this.lnkARStudentPerTerm = new System.Windows.Forms.LinkLabel();
            this.lnkRegisterSummarized = new System.Windows.Forms.LinkLabel();
            this.lnkRegisterDetailed = new System.Windows.Forms.LinkLabel();
            this.lnkCreditMemo = new System.Windows.Forms.LinkLabel();
            this.lnkScholarshipDiscounts = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.lnkIncrement = new System.Windows.Forms.LinkLabel();
            this.lnkDecrement = new System.Windows.Forms.LinkLabel();
            this.lnkViewCancel = new System.Windows.Forms.LinkLabel();
            this.lnkCancelReceipt = new System.Windows.Forms.LinkLabel();
            this.pbxMiscellaneousIncome = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAdditionalFee)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMiscellaneousIncome)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlHeader.BackgroundImage")));
            this.pnlHeader.Size = new System.Drawing.Size(262, 28);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.pbxMiscellaneousIncome);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.pbxAdditionalFee);
            this.pnlMain.Controls.Add(this.pbxClose);
            this.pnlMain.Controls.Add(this.pbxRefresh);
            this.pnlMain.Controls.Add(this.txtStudentTab);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Size = new System.Drawing.Size(255, 579);
            this.pnlMain.Controls.SetChildIndex(this.groupBox2, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtStudentTab, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxClose, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxAdditionalFee, 0);
            this.pnlMain.Controls.SetChildIndex(this.label1, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox3, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxMiscellaneousIncome, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnlMain.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // pbxClose
            // 
            this.pbxClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Image = ((System.Drawing.Image)(resources.GetObject("pbxClose.Image")));
            this.pbxClose.Location = new System.Drawing.Point(214, 37);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(33, 41);
            this.pbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxClose.TabIndex = 11;
            this.pbxClose.TabStop = false;
            // 
            // pbxRefresh
            // 
            this.pbxRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pbxRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pbxRefresh.Image")));
            this.pbxRefresh.Location = new System.Drawing.Point(175, 37);
            this.pbxRefresh.Name = "pbxRefresh";
            this.pbxRefresh.Size = new System.Drawing.Size(33, 41);
            this.pbxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxRefresh.TabIndex = 12;
            this.pbxRefresh.TabStop = false;
            // 
            // txtStudentTab
            // 
            this.txtStudentTab.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtStudentTab.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtStudentTab.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentTab.Location = new System.Drawing.Point(10, 112);
            this.txtStudentTab.MaxLength = 50;
            this.txtStudentTab.Name = "txtStudentTab";
            this.txtStudentTab.Size = new System.Drawing.Size(237, 26);
            this.txtStudentTab.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(7, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Query for Student Tab";
            // 
            // pbxAdditionalFee
            // 
            this.pbxAdditionalFee.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxAdditionalFee.BackColor = System.Drawing.Color.Transparent;
            this.pbxAdditionalFee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxAdditionalFee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxAdditionalFee.Image = ((System.Drawing.Image)(resources.GetObject("pbxAdditionalFee.Image")));
            this.pbxAdditionalFee.Location = new System.Drawing.Point(136, 37);
            this.pbxAdditionalFee.Name = "pbxAdditionalFee";
            this.pbxAdditionalFee.Size = new System.Drawing.Size(33, 41);
            this.pbxAdditionalFee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAdditionalFee.TabIndex = 15;
            this.pbxAdditionalFee.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.lnkCashReceiptsQuery);
            this.groupBox1.Controls.Add(this.lnkCashDiscounts);
            this.groupBox1.Controls.Add(this.lnkCashReceiptsSummarized);
            this.groupBox1.Controls.Add(this.lnkCashReceiptsDetailed);
            this.groupBox1.Controls.Add(this.lnkARStudentPerFiscalYear);
            this.groupBox1.Controls.Add(this.lnkARStudentPerTerm);
            this.groupBox1.Controls.Add(this.lnkRegisterSummarized);
            this.groupBox1.Controls.Add(this.lnkRegisterDetailed);
            this.groupBox1.Controls.Add(this.lnkCreditMemo);
            this.groupBox1.Controls.Add(this.lnkScholarshipDiscounts);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 286);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cashier\'s Report";
            // 
            // lnkCashReceiptsQuery
            // 
            this.lnkCashReceiptsQuery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkCashReceiptsQuery.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCashReceiptsQuery.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCashReceiptsQuery.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCashReceiptsQuery.Location = new System.Drawing.Point(2, 251);
            this.lnkCashReceiptsQuery.Name = "lnkCashReceiptsQuery";
            this.lnkCashReceiptsQuery.Size = new System.Drawing.Size(233, 26);
            this.lnkCashReceiptsQuery.TabIndex = 24;
            this.lnkCashReceiptsQuery.TabStop = true;
            this.lnkCashReceiptsQuery.Text = "Cash Receipts (Query)";
            this.lnkCashReceiptsQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkCashDiscounts
            // 
            this.lnkCashDiscounts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkCashDiscounts.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCashDiscounts.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCashDiscounts.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCashDiscounts.Location = new System.Drawing.Point(2, 43);
            this.lnkCashDiscounts.Name = "lnkCashDiscounts";
            this.lnkCashDiscounts.Size = new System.Drawing.Size(233, 26);
            this.lnkCashDiscounts.TabIndex = 23;
            this.lnkCashDiscounts.TabStop = true;
            this.lnkCashDiscounts.Text = "Cash Discounts";
            this.lnkCashDiscounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkCashReceiptsSummarized
            // 
            this.lnkCashReceiptsSummarized.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkCashReceiptsSummarized.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCashReceiptsSummarized.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCashReceiptsSummarized.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCashReceiptsSummarized.Location = new System.Drawing.Point(2, 225);
            this.lnkCashReceiptsSummarized.Name = "lnkCashReceiptsSummarized";
            this.lnkCashReceiptsSummarized.Size = new System.Drawing.Size(233, 26);
            this.lnkCashReceiptsSummarized.TabIndex = 22;
            this.lnkCashReceiptsSummarized.TabStop = true;
            this.lnkCashReceiptsSummarized.Text = "Cash Receipts (Summarized)";
            this.lnkCashReceiptsSummarized.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkCashReceiptsDetailed
            // 
            this.lnkCashReceiptsDetailed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkCashReceiptsDetailed.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCashReceiptsDetailed.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCashReceiptsDetailed.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCashReceiptsDetailed.Location = new System.Drawing.Point(2, 199);
            this.lnkCashReceiptsDetailed.Name = "lnkCashReceiptsDetailed";
            this.lnkCashReceiptsDetailed.Size = new System.Drawing.Size(233, 26);
            this.lnkCashReceiptsDetailed.TabIndex = 21;
            this.lnkCashReceiptsDetailed.TabStop = true;
            this.lnkCashReceiptsDetailed.Text = "Cash Receipts (Detailed)";
            this.lnkCashReceiptsDetailed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkARStudentPerFiscalYear
            // 
            this.lnkARStudentPerFiscalYear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkARStudentPerFiscalYear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkARStudentPerFiscalYear.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkARStudentPerFiscalYear.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkARStudentPerFiscalYear.Location = new System.Drawing.Point(2, 173);
            this.lnkARStudentPerFiscalYear.Name = "lnkARStudentPerFiscalYear";
            this.lnkARStudentPerFiscalYear.Size = new System.Drawing.Size(233, 26);
            this.lnkARStudentPerFiscalYear.TabIndex = 20;
            this.lnkARStudentPerFiscalYear.TabStop = true;
            this.lnkARStudentPerFiscalYear.Text = "A/R - Student Per Fiscal Year";
            this.lnkARStudentPerFiscalYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkARStudentPerTerm
            // 
            this.lnkARStudentPerTerm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkARStudentPerTerm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkARStudentPerTerm.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkARStudentPerTerm.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkARStudentPerTerm.Location = new System.Drawing.Point(2, 147);
            this.lnkARStudentPerTerm.Name = "lnkARStudentPerTerm";
            this.lnkARStudentPerTerm.Size = new System.Drawing.Size(233, 26);
            this.lnkARStudentPerTerm.TabIndex = 19;
            this.lnkARStudentPerTerm.TabStop = true;
            this.lnkARStudentPerTerm.Text = "A/R - Student Per Term";
            this.lnkARStudentPerTerm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkRegisterSummarized
            // 
            this.lnkRegisterSummarized.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkRegisterSummarized.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRegisterSummarized.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkRegisterSummarized.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkRegisterSummarized.Location = new System.Drawing.Point(2, 121);
            this.lnkRegisterSummarized.Name = "lnkRegisterSummarized";
            this.lnkRegisterSummarized.Size = new System.Drawing.Size(233, 26);
            this.lnkRegisterSummarized.TabIndex = 18;
            this.lnkRegisterSummarized.TabStop = true;
            this.lnkRegisterSummarized.Text = "Fees Register (Summarized)";
            this.lnkRegisterSummarized.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkRegisterDetailed
            // 
            this.lnkRegisterDetailed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkRegisterDetailed.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRegisterDetailed.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkRegisterDetailed.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkRegisterDetailed.Location = new System.Drawing.Point(2, 95);
            this.lnkRegisterDetailed.Name = "lnkRegisterDetailed";
            this.lnkRegisterDetailed.Size = new System.Drawing.Size(233, 26);
            this.lnkRegisterDetailed.TabIndex = 17;
            this.lnkRegisterDetailed.TabStop = true;
            this.lnkRegisterDetailed.Text = "Fees Register (Detailed)";
            this.lnkRegisterDetailed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkCreditMemo
            // 
            this.lnkCreditMemo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkCreditMemo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreditMemo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreditMemo.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCreditMemo.Location = new System.Drawing.Point(2, 69);
            this.lnkCreditMemo.Name = "lnkCreditMemo";
            this.lnkCreditMemo.Size = new System.Drawing.Size(233, 26);
            this.lnkCreditMemo.TabIndex = 16;
            this.lnkCreditMemo.TabStop = true;
            this.lnkCreditMemo.Text = "Credit Memo Prooflist";
            this.lnkCreditMemo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkScholarshipDiscounts
            // 
            this.lnkScholarshipDiscounts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkScholarshipDiscounts.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkScholarshipDiscounts.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkScholarshipDiscounts.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkScholarshipDiscounts.Location = new System.Drawing.Point(2, 17);
            this.lnkScholarshipDiscounts.Name = "lnkScholarshipDiscounts";
            this.lnkScholarshipDiscounts.Size = new System.Drawing.Size(233, 26);
            this.lnkScholarshipDiscounts.TabIndex = 15;
            this.lnkScholarshipDiscounts.TabStop = true;
            this.lnkScholarshipDiscounts.Text = "Scholarship Discounts";
            this.lnkScholarshipDiscounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.txtReceiptNo);
            this.groupBox2.Controls.Add(this.lnkIncrement);
            this.groupBox2.Controls.Add(this.lnkDecrement);
            this.groupBox2.Controls.Add(this.lnkViewCancel);
            this.groupBox2.Controls.Add(this.lnkCancelReceipt);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 439);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 76);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Receipt No.";
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtReceiptNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtReceiptNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptNo.ForeColor = System.Drawing.Color.Red;
            this.txtReceiptNo.Location = new System.Drawing.Point(49, 20);
            this.txtReceiptNo.MaxLength = 10;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(139, 27);
            this.txtReceiptNo.TabIndex = 18;
            this.txtReceiptNo.Text = "000000";
            this.txtReceiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lnkIncrement
            // 
            this.lnkIncrement.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkIncrement.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkIncrement.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkIncrement.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkIncrement.Location = new System.Drawing.Point(190, 20);
            this.lnkIncrement.Name = "lnkIncrement";
            this.lnkIncrement.Size = new System.Drawing.Size(42, 26);
            this.lnkIncrement.TabIndex = 16;
            this.lnkIncrement.TabStop = true;
            this.lnkIncrement.Text = "| >> |";
            this.lnkIncrement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkDecrement
            // 
            this.lnkDecrement.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkDecrement.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDecrement.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkDecrement.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkDecrement.Location = new System.Drawing.Point(6, 20);
            this.lnkDecrement.Name = "lnkDecrement";
            this.lnkDecrement.Size = new System.Drawing.Size(42, 26);
            this.lnkDecrement.TabIndex = 15;
            this.lnkDecrement.TabStop = true;
            this.lnkDecrement.Text = "| << |";
            this.lnkDecrement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkViewCancel
            // 
            this.lnkViewCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkViewCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkViewCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkViewCancel.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkViewCancel.Location = new System.Drawing.Point(110, 49);
            this.lnkViewCancel.Name = "lnkViewCancel";
            this.lnkViewCancel.Size = new System.Drawing.Size(125, 26);
            this.lnkViewCancel.TabIndex = 20;
            this.lnkViewCancel.TabStop = true;
            this.lnkViewCancel.Text = "View Cancelled Receipt";
            this.lnkViewCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkCancelReceipt
            // 
            this.lnkCancelReceipt.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkCancelReceipt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCancelReceipt.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCancelReceipt.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCancelReceipt.Location = new System.Drawing.Point(5, 49);
            this.lnkCancelReceipt.Name = "lnkCancelReceipt";
            this.lnkCancelReceipt.Size = new System.Drawing.Size(99, 26);
            this.lnkCancelReceipt.TabIndex = 19;
            this.lnkCancelReceipt.TabStop = true;
            this.lnkCancelReceipt.Text = "Cancel Receipt No.";
            this.lnkCancelReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxMiscellaneousIncome
            // 
            this.pbxMiscellaneousIncome.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxMiscellaneousIncome.BackColor = System.Drawing.Color.Transparent;
            this.pbxMiscellaneousIncome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxMiscellaneousIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxMiscellaneousIncome.Image = ((System.Drawing.Image)(resources.GetObject("pbxMiscellaneousIncome.Image")));
            this.pbxMiscellaneousIncome.Location = new System.Drawing.Point(97, 37);
            this.pbxMiscellaneousIncome.Name = "pbxMiscellaneousIncome";
            this.pbxMiscellaneousIncome.Size = new System.Drawing.Size(33, 41);
            this.pbxMiscellaneousIncome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxMiscellaneousIncome.TabIndex = 18;
            this.pbxMiscellaneousIncome.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.dtpReceiptDate);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 521);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 55);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Receipt Date";
            // 
            // dtpReceiptDate
            // 
            this.dtpReceiptDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dtpReceiptDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpReceiptDate.CalendarMonthBackground = System.Drawing.Color.GhostWhite;
            this.dtpReceiptDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.dtpReceiptDate.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpReceiptDate.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.dtpReceiptDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiptDate.Location = new System.Drawing.Point(5, 22);
            this.dtpReceiptDate.Name = "dtpReceiptDate";
            this.dtpReceiptDate.Size = new System.Drawing.Size(228, 22);
            this.dtpReceiptDate.TabIndex = 1;
            // 
            // ControlCashieringManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlCashieringManager";
            this.Size = new System.Drawing.Size(255, 579);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAdditionalFee)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMiscellaneousIncome)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
