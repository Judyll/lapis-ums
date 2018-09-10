using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeServices
{
    internal partial class SubjectSearchOnTextBoxListStudentLoading : SearchOnTextboxListStudentLoad
    {
        protected System.Windows.Forms.PictureBox pbxChecked;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.DataGridView dgvDetails;
        public System.Windows.Forms.GroupBox gbxEnrolmentInfo;
        private System.Windows.Forms.CheckBox chkIsIrregular;
        protected System.Windows.Forms.PictureBox pbxInsertSubjects;
    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectSearchOnTextBoxListStudentLoading));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbxInsertSubjects = new System.Windows.Forms.PictureBox();
            this.pbxChecked = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.gbxEnrolmentInfo = new System.Windows.Forms.GroupBox();
            this.chkIsIrregular = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInsertSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.gbxEnrolmentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(548, 12);
            // 
            // pbxDone
            // 
            this.pbxDone.Location = new System.Drawing.Point(909, 9);
            // 
            // pbxRefresh
            // 
            this.pbxRefresh.Location = new System.Drawing.Point(872, 9);
            // 
            // pbxInsertSubjects
            // 
            this.pbxInsertSubjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxInsertSubjects.BackColor = System.Drawing.Color.Transparent;
            this.pbxInsertSubjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxInsertSubjects.Image = ((System.Drawing.Image)(resources.GetObject("pbxInsertSubjects.Image")));
            this.pbxInsertSubjects.Location = new System.Drawing.Point(12, 290);
            this.pbxInsertSubjects.Name = "pbxInsertSubjects";
            this.pbxInsertSubjects.Size = new System.Drawing.Size(51, 51);
            this.pbxInsertSubjects.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxInsertSubjects.TabIndex = 72;
            this.pbxInsertSubjects.TabStop = false;
            // 
            // pbxChecked
            // 
            this.pbxChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxChecked.BackColor = System.Drawing.Color.Transparent;
            this.pbxChecked.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxChecked.Image = ((System.Drawing.Image)(resources.GetObject("pbxChecked.Image")));
            this.pbxChecked.Location = new System.Drawing.Point(12, 19);
            this.pbxChecked.Name = "pbxChecked";
            this.pbxChecked.Size = new System.Drawing.Size(22, 22);
            this.pbxChecked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxChecked.TabIndex = 73;
            this.pbxChecked.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(161, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Selected:";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.ForeColor = System.Drawing.Color.Red;
            this.lblSelected.Location = new System.Drawing.Point(221, 406);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(15, 15);
            this.lblSelected.TabIndex = 75;
            this.lblSelected.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(149, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 16);
            this.label3.TabIndex = 76;
            this.label3.Text = "|";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeColumns = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(6, 17);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.RowHeadersWidth = 15;
            this.dgvDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.dgvDetails.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(602, 115);
            this.dgvDetails.TabIndex = 77;
            // 
            // gbxEnrolmentInfo
            // 
            this.gbxEnrolmentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxEnrolmentInfo.BackColor = System.Drawing.SystemColors.Control;
            this.gbxEnrolmentInfo.Controls.Add(this.dgvDetails);
            this.gbxEnrolmentInfo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxEnrolmentInfo.ForeColor = System.Drawing.Color.Navy;
            this.gbxEnrolmentInfo.Location = new System.Drawing.Point(329, 290);
            this.gbxEnrolmentInfo.Name = "gbxEnrolmentInfo";
            this.gbxEnrolmentInfo.Size = new System.Drawing.Size(616, 139);
            this.gbxEnrolmentInfo.TabIndex = 78;
            this.gbxEnrolmentInfo.TabStop = false;
            this.gbxEnrolmentInfo.Text = " SCHEDULE DETAILS ";
            // 
            // chkIsIrregular
            // 
            this.chkIsIrregular.AutoSize = true;
            this.chkIsIrregular.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsIrregular.ForeColor = System.Drawing.Color.Maroon;
            this.chkIsIrregular.Location = new System.Drawing.Point(78, 303);
            this.chkIsIrregular.Name = "chkIsIrregular";
            this.chkIsIrregular.Size = new System.Drawing.Size(243, 23);
            this.chkIsIrregular.TabIndex = 78;
            this.chkIsIrregular.Text = "Is IRREGULAR STUDENT Loading";
            this.chkIsIrregular.UseVisualStyleBackColor = true;
            // 
            // SubjectSearchOnTextBoxListStudentLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(954, 435);
            this.Controls.Add(this.chkIsIrregular);
            this.Controls.Add(this.gbxEnrolmentInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbxChecked);
            this.Controls.Add(this.pbxInsertSubjects);
            this.Name = "SubjectSearchOnTextBoxListStudentLoading";
            this.Text = "   Subject Schedule List";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblResult, 0);
            this.Controls.SetChildIndex(this.pbxDone, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.Controls.SetChildIndex(this.pbxInsertSubjects, 0);
            this.Controls.SetChildIndex(this.pbxChecked, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblSelected, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.gbxEnrolmentInfo, 0);
            this.Controls.SetChildIndex(this.chkIsIrregular, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInsertSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.gbxEnrolmentInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
