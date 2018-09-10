namespace OfficeServices
{
    partial class SearchListForStudent
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchListForStudent));
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pgbPrint = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintStatement = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintStudentLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintStudentMasterList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintStudentEnrolmentList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintStudentList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintStudentQuickCount = new System.Windows.Forms.ToolStripButton();
            this.btnPrintStudentInsurance = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Maroon;
            this.lblResult.Location = new System.Drawing.Point(56, 5);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(47, 13);
            this.lblResult.TabIndex = 60;
            this.lblResult.Text = "Result:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(13, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Query:";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 22);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 15;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(693, 237);
            this.dgvList.TabIndex = 58;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgbPrint,
            this.toolStripSeparator1,
            this.btnPrintStatement,
            this.toolStripSeparator2,
            this.btnPrintStudentLoad,
            this.toolStripSeparator3,
            this.btnPrintStudentMasterList,
            this.toolStripSeparator4,
            this.btnPrintStudentEnrolmentList,
            this.toolStripSeparator5,
            this.btnPrintStudentList,
            this.toolStripSeparator6,
            this.btnPrintStudentInsurance,
            this.btnPrintStudentQuickCount});
            this.toolStrip1.Location = new System.Drawing.Point(0, 290);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(717, 25);
            this.toolStrip1.TabIndex = 61;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pgbPrint
            // 
            this.pgbPrint.Name = "pgbPrint";
            this.pgbPrint.Size = new System.Drawing.Size(500, 22);
            this.pgbPrint.Step = 2;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrintStatement
            // 
            this.btnPrintStatement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintStatement.Enabled = false;
            this.btnPrintStatement.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintStatement.Image")));
            this.btnPrintStatement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintStatement.Name = "btnPrintStatement";
            this.btnPrintStatement.Size = new System.Drawing.Size(23, 22);
            this.btnPrintStatement.Text = "Print statement of accounts";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrintStudentLoad
            // 
            this.btnPrintStudentLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintStudentLoad.Enabled = false;
            this.btnPrintStudentLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintStudentLoad.Image")));
            this.btnPrintStudentLoad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrintStudentLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintStudentLoad.Name = "btnPrintStudentLoad";
            this.btnPrintStudentLoad.Size = new System.Drawing.Size(23, 22);
            this.btnPrintStudentLoad.Text = "Print student enrolment record";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrintStudentMasterList
            // 
            this.btnPrintStudentMasterList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintStudentMasterList.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintStudentMasterList.Image")));
            this.btnPrintStudentMasterList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintStudentMasterList.Name = "btnPrintStudentMasterList";
            this.btnPrintStudentMasterList.Size = new System.Drawing.Size(23, 22);
            this.btnPrintStudentMasterList.Text = "Print student master list";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrintStudentEnrolmentList
            // 
            this.btnPrintStudentEnrolmentList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintStudentEnrolmentList.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintStudentEnrolmentList.Image")));
            this.btnPrintStudentEnrolmentList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintStudentEnrolmentList.Name = "btnPrintStudentEnrolmentList";
            this.btnPrintStudentEnrolmentList.Size = new System.Drawing.Size(23, 22);
            this.btnPrintStudentEnrolmentList.Text = "Print student enrolment list";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrintStudentList
            // 
            this.btnPrintStudentList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintStudentList.Enabled = false;
            this.btnPrintStudentList.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintStudentList.Image")));
            this.btnPrintStudentList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintStudentList.Name = "btnPrintStudentList";
            this.btnPrintStudentList.Size = new System.Drawing.Size(23, 22);
            this.btnPrintStudentList.Text = "Print student list";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrintStudentQuickCount
            // 
            this.btnPrintStudentQuickCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintStudentQuickCount.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintStudentQuickCount.Image")));
            this.btnPrintStudentQuickCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintStudentQuickCount.Name = "btnPrintStudentQuickCount";
            this.btnPrintStudentQuickCount.Size = new System.Drawing.Size(23, 22);
            this.btnPrintStudentQuickCount.Text = "Print student quick count";
            // 
            // btnPrintStudentInsurance
            // 
            this.btnPrintStudentInsurance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintStudentInsurance.Enabled = false;
            this.btnPrintStudentInsurance.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintStudentInsurance.Image")));
            this.btnPrintStudentInsurance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintStudentInsurance.Name = "btnPrintStudentInsurance";
            this.btnPrintStudentInsurance.Size = new System.Drawing.Size(23, 22);
            this.btnPrintStudentInsurance.Text = "Print student insurance list";
            // 
            // SearchListForStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 315);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchListForStudent";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "   Student List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnPrintStatement;
        internal System.Windows.Forms.ToolStripButton btnPrintStudentLoad;
        internal System.Windows.Forms.ToolStripProgressBar pgbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnPrintStudentMasterList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnPrintStudentEnrolmentList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnPrintStudentList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnPrintStudentQuickCount;
        private System.Windows.Forms.ToolStripButton btnPrintStudentInsurance;

    }
}