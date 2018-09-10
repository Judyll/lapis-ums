namespace BaseServices
{
    partial class SearchList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.mnuUpdate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemUpdateBasic = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemUpdateAdvance = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemViewStudentEnrolmentHistory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.mnuUpdate.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvList.Location = new System.Drawing.Point(12, 10);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 15;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(693, 237);
            this.dgvList.TabIndex = 58;
            // 
            // mnuUpdate
            // 
            this.mnuUpdate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuUpdate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemUpdateBasic,
            this.mnuItemUpdateAdvance,
            this.mnuItemViewStudentEnrolmentHistory});
            this.mnuUpdate.Name = "mnuUpdate";
            this.mnuUpdate.Size = new System.Drawing.Size(286, 70);
            // 
            // mnuItemUpdateBasic
            // 
            this.mnuItemUpdateBasic.Name = "mnuItemUpdateBasic";
            this.mnuItemUpdateBasic.Size = new System.Drawing.Size(285, 22);
            this.mnuItemUpdateBasic.Text = "Update Student Basic Information";
            // 
            // mnuItemUpdateAdvance
            // 
            this.mnuItemUpdateAdvance.Name = "mnuItemUpdateAdvance";
            this.mnuItemUpdateAdvance.Size = new System.Drawing.Size(285, 22);
            this.mnuItemUpdateAdvance.Text = "Update Student Advance Information";
            // 
            // mnuItemViewStudentEnrolmentHistory
            // 
            this.mnuItemViewStudentEnrolmentHistory.Name = "mnuItemViewStudentEnrolmentHistory";
            this.mnuItemViewStudentEnrolmentHistory.Size = new System.Drawing.Size(285, 22);
            this.mnuItemViewStudentEnrolmentHistory.Text = "View Student Enrolment History";
            // 
            // SearchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 275);
            this.ControlBox = false;
            this.Controls.Add(this.dgvList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "    SearchList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.mnuUpdate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuUpdate;
        private System.Windows.Forms.ToolStripMenuItem mnuItemUpdateBasic;
        private System.Windows.Forms.ToolStripMenuItem mnuItemUpdateAdvance;
        protected System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ToolStripMenuItem mnuItemViewStudentEnrolmentHistory;

    }
}