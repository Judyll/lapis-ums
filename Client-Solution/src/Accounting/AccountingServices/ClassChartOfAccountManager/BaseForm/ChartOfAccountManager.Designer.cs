namespace AccountingServices
{
    partial class ChartOfAccountManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartOfAccountManager));
            this.trvChartOfAccounts = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxPersonalInfo = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCreateChartOfAccount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearchChartOfAccount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintChartOfAccounts = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.gbxPersonalInfo.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvChartOfAccounts
            // 
            this.trvChartOfAccounts.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvChartOfAccounts.Indent = 20;
            this.trvChartOfAccounts.ItemHeight = 25;
            this.trvChartOfAccounts.Location = new System.Drawing.Point(3, 46);
            this.trvChartOfAccounts.Name = "trvChartOfAccounts";
            this.trvChartOfAccounts.ShowNodeToolTips = true;
            this.trvChartOfAccounts.Size = new System.Drawing.Size(731, 517);
            this.trvChartOfAccounts.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(0, 663);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 35);
            this.panel2.TabIndex = 27;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(672, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "  Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 58);
            this.panel1.TabIndex = 26;
            // 
            // gbxPersonalInfo
            // 
            this.gbxPersonalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPersonalInfo.Controls.Add(this.toolStrip1);
            this.gbxPersonalInfo.Controls.Add(this.trvChartOfAccounts);
            this.gbxPersonalInfo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPersonalInfo.ForeColor = System.Drawing.Color.Navy;
            this.gbxPersonalInfo.Location = new System.Drawing.Point(21, 71);
            this.gbxPersonalInfo.Name = "gbxPersonalInfo";
            this.gbxPersonalInfo.Size = new System.Drawing.Size(737, 569);
            this.gbxPersonalInfo.TabIndex = 28;
            this.gbxPersonalInfo.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateChartOfAccount,
            this.toolStripSeparator1,
            this.btnSearchChartOfAccount,
            this.toolStripSeparator2,
            this.btnPrintChartOfAccounts});
            this.toolStrip1.Location = new System.Drawing.Point(3, 18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(731, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCreateChartOfAccount
            // 
            this.btnCreateChartOfAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreateChartOfAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateChartOfAccount.Image")));
            this.btnCreateChartOfAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateChartOfAccount.Name = "btnCreateChartOfAccount";
            this.btnCreateChartOfAccount.Size = new System.Drawing.Size(23, 22);
            this.btnCreateChartOfAccount.Text = "Create chart of account";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSearchChartOfAccount
            // 
            this.btnSearchChartOfAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearchChartOfAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchChartOfAccount.Image")));
            this.btnSearchChartOfAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchChartOfAccount.Name = "btnSearchChartOfAccount";
            this.btnSearchChartOfAccount.Size = new System.Drawing.Size(23, 22);
            this.btnSearchChartOfAccount.Text = "Search chart of account";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrintChartOfAccounts
            // 
            this.btnPrintChartOfAccounts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintChartOfAccounts.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintChartOfAccounts.Image")));
            this.btnPrintChartOfAccounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintChartOfAccounts.Name = "btnPrintChartOfAccounts";
            this.btnPrintChartOfAccounts.Size = new System.Drawing.Size(23, 22);
            this.btnPrintChartOfAccounts.Text = "Print chart of accounts";
            // 
            // ChartOfAccountManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(778, 697);
            this.Controls.Add(this.gbxPersonalInfo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartOfAccountManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.gbxPersonalInfo.ResumeLayout(false);
            this.gbxPersonalInfo.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TreeView trvChartOfAccounts;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.GroupBox gbxPersonalInfo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCreateChartOfAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSearchChartOfAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPrintChartOfAccounts;
    }
}