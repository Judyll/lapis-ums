namespace FinanceServices
{
    partial class MultipleAdditionalFeeCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultipleAdditionalFeeCreate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ctlPayment = new RemoteClient.ControlAdditionalFeeManager();
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbxChecked = new System.Windows.Forms.PictureBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblTextSelected = new System.Windows.Forms.Label();
            this.gbxAdditionalPayment = new System.Windows.Forms.GroupBox();
            this.lblParticularDescription = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnSearchAdditionalFee = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnRecord = new System.Windows.Forms.Button();
            this.gbxData = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.pbxUnlock = new System.Windows.Forms.PictureBox();
            this.pbxLocked = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.txtAdditionalFeeRemarks = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChecked)).BeginInit();
            this.gbxAdditionalPayment.SuspendLayout();
            this.gbxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLocked)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlPayment
            // 
            this.ctlPayment.BackColor = System.Drawing.Color.Transparent;
            this.ctlPayment.IsForApply = true;
            this.ctlPayment.Location = new System.Drawing.Point(605, 63);
            this.ctlPayment.Name = "ctlPayment";
            this.ctlPayment.Size = new System.Drawing.Size(255, 648);
            this.ctlPayment.TabIndex = 0;
            // 
            // lblResult
            // 
            this.lblResult.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Maroon;
            this.lblResult.Location = new System.Drawing.Point(245, 459);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(47, 13);
            this.lblResult.TabIndex = 65;
            this.lblResult.Text = "Result:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(202, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Query:";
            // 
            // pbxChecked
            // 
            this.pbxChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxChecked.BackColor = System.Drawing.Color.Transparent;
            this.pbxChecked.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxChecked.Image = ((System.Drawing.Image)(resources.GetObject("pbxChecked.Image")));
            this.pbxChecked.Location = new System.Drawing.Point(6, 14);
            this.pbxChecked.Name = "pbxChecked";
            this.pbxChecked.Size = new System.Drawing.Size(22, 22);
            this.pbxChecked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxChecked.TabIndex = 74;
            this.pbxChecked.TabStop = false;
            // 
            // lblLine
            // 
            this.lblLine.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLine.AutoSize = true;
            this.lblLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.ForeColor = System.Drawing.Color.Maroon;
            this.lblLine.Location = new System.Drawing.Point(356, 456);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(12, 16);
            this.lblLine.TabIndex = 79;
            this.lblLine.Text = "|";
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.ForeColor = System.Drawing.Color.Red;
            this.lblSelected.Location = new System.Drawing.Point(435, 456);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(15, 15);
            this.lblSelected.TabIndex = 78;
            this.lblSelected.Text = "0";
            // 
            // lblTextSelected
            // 
            this.lblTextSelected.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTextSelected.AutoSize = true;
            this.lblTextSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextSelected.ForeColor = System.Drawing.Color.Maroon;
            this.lblTextSelected.Location = new System.Drawing.Point(368, 459);
            this.lblTextSelected.Name = "lblTextSelected";
            this.lblTextSelected.Size = new System.Drawing.Size(61, 13);
            this.lblTextSelected.TabIndex = 77;
            this.lblTextSelected.Text = "Selected:";
            // 
            // gbxAdditionalPayment
            // 
            this.gbxAdditionalPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAdditionalPayment.Controls.Add(this.label41);
            this.gbxAdditionalPayment.Controls.Add(this.txtAdditionalFeeRemarks);
            this.gbxAdditionalPayment.Controls.Add(this.lblParticularDescription);
            this.gbxAdditionalPayment.Controls.Add(this.label26);
            this.gbxAdditionalPayment.Controls.Add(this.btnSearchAdditionalFee);
            this.gbxAdditionalPayment.Controls.Add(this.txtAmount);
            this.gbxAdditionalPayment.Controls.Add(this.label24);
            this.gbxAdditionalPayment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAdditionalPayment.ForeColor = System.Drawing.Color.Navy;
            this.gbxAdditionalPayment.Location = new System.Drawing.Point(9, 64);
            this.gbxAdditionalPayment.Name = "gbxAdditionalPayment";
            this.gbxAdditionalPayment.Size = new System.Drawing.Size(590, 135);
            this.gbxAdditionalPayment.TabIndex = 89;
            this.gbxAdditionalPayment.TabStop = false;
            this.gbxAdditionalPayment.Text = " ADDITIONAL FEE INFORMATION ";
            // 
            // lblParticularDescription
            // 
            this.lblParticularDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParticularDescription.AutoSize = true;
            this.lblParticularDescription.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParticularDescription.ForeColor = System.Drawing.Color.Red;
            this.lblParticularDescription.Location = new System.Drawing.Point(206, 24);
            this.lblParticularDescription.Name = "lblParticularDescription";
            this.lblParticularDescription.Size = new System.Drawing.Size(24, 23);
            this.lblParticularDescription.TabIndex = 38;
            this.lblParticularDescription.Text = "  -";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(12, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(188, 23);
            this.label26.TabIndex = 37;
            this.label26.Text = "Particular Description:";
            // 
            // btnSearchAdditionalFee
            // 
            this.btnSearchAdditionalFee.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchAdditionalFee.BackgroundImage")));
            this.btnSearchAdditionalFee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchAdditionalFee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchAdditionalFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAdditionalFee.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchAdditionalFee.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearchAdditionalFee.Location = new System.Drawing.Point(549, 12);
            this.btnSearchAdditionalFee.Name = "btnSearchAdditionalFee";
            this.btnSearchAdditionalFee.Size = new System.Drawing.Size(35, 35);
            this.btnSearchAdditionalFee.TabIndex = 0;
            this.btnSearchAdditionalFee.UseVisualStyleBackColor = true;
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Red;
            this.txtAmount.Location = new System.Drawing.Point(210, 59);
            this.txtAmount.MaxLength = 12;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(366, 40);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(88, 62);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 33);
            this.label24.TabIndex = 1;
            this.label24.Text = "Amount:";
            // 
            // btnRecord
            // 
            this.btnRecord.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRecord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecord.BackgroundImage")));
            this.btnRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecord.Enabled = false;
            this.btnRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.Location = new System.Drawing.Point(516, 451);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(68, 24);
            this.btnRecord.TabIndex = 2;
            this.btnRecord.Text = "      Record";
            this.btnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecord.UseVisualStyleBackColor = true;
            // 
            // gbxData
            // 
            this.gbxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxData.Controls.Add(this.lblStatus);
            this.gbxData.Controls.Add(this.dgvList);
            this.gbxData.Controls.Add(this.label1);
            this.gbxData.Controls.Add(this.pbxChecked);
            this.gbxData.Controls.Add(this.pbxUnlock);
            this.gbxData.Controls.Add(this.btnRecord);
            this.gbxData.Controls.Add(this.pbxLocked);
            this.gbxData.Controls.Add(this.lblLine);
            this.gbxData.Controls.Add(this.lblTextSelected);
            this.gbxData.Controls.Add(this.lblSelected);
            this.gbxData.Controls.Add(this.lblResult);
            this.gbxData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxData.ForeColor = System.Drawing.Color.Black;
            this.gbxData.Location = new System.Drawing.Point(9, 205);
            this.gbxData.Name = "gbxData";
            this.gbxData.Size = new System.Drawing.Size(590, 481);
            this.gbxData.TabIndex = 90;
            this.gbxData.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(32, 459);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(122, 13);
            this.lblStatus.TabIndex = 96;
            this.lblStatus.Text = "This record is OPEN";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvList.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(6, 40);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 15;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(578, 405);
            this.dgvList.TabIndex = 63;
            // 
            // pbxUnlock
            // 
            this.pbxUnlock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxUnlock.BackgroundImage")));
            this.pbxUnlock.Location = new System.Drawing.Point(8, 448);
            this.pbxUnlock.Name = "pbxUnlock";
            this.pbxUnlock.Size = new System.Drawing.Size(24, 24);
            this.pbxUnlock.TabIndex = 98;
            this.pbxUnlock.TabStop = false;
            // 
            // pbxLocked
            // 
            this.pbxLocked.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxLocked.BackgroundImage")));
            this.pbxLocked.Location = new System.Drawing.Point(8, 448);
            this.pbxLocked.Name = "pbxLocked";
            this.pbxLocked.Size = new System.Drawing.Size(24, 24);
            this.pbxLocked.TabIndex = 97;
            this.pbxLocked.TabStop = false;
            this.pbxLocked.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 58);
            this.panel1.TabIndex = 93;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(142, 108);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(58, 15);
            this.label41.TabIndex = 114;
            this.label41.Text = "Remarks:";
            // 
            // txtAdditionalFeeRemarks
            // 
            this.txtAdditionalFeeRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdditionalFeeRemarks.BackColor = System.Drawing.Color.White;
            this.txtAdditionalFeeRemarks.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalFeeRemarks.Location = new System.Drawing.Point(210, 105);
            this.txtAdditionalFeeRemarks.MaxLength = 100;
            this.txtAdditionalFeeRemarks.Name = "txtAdditionalFeeRemarks";
            this.txtAdditionalFeeRemarks.Size = new System.Drawing.Size(366, 23);
            this.txtAdditionalFeeRemarks.TabIndex = 113;
            // 
            // MultipleAdditionalFeeCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(860, 708);
            this.Controls.Add(this.gbxAdditionalPayment);
            this.Controls.Add(this.ctlPayment);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbxData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultipleAdditionalFeeCreate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbxChecked)).EndInit();
            this.gbxAdditionalPayment.ResumeLayout(false);
            this.gbxAdditionalPayment.PerformLayout();
            this.gbxData.ResumeLayout(false);
            this.gbxData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLocked)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RemoteClient.ControlAdditionalFeeManager ctlPayment;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.PictureBox pbxChecked;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblTextSelected;
        public System.Windows.Forms.GroupBox gbxAdditionalPayment;
        public System.Windows.Forms.Label lblParticularDescription;
        private System.Windows.Forms.Label label26;
        protected System.Windows.Forms.Button btnSearchAdditionalFee;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnRecord;
        public System.Windows.Forms.GroupBox gbxData;
        private System.Windows.Forms.DataGridView dgvList;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label lblStatus;
        protected System.Windows.Forms.PictureBox pbxUnlock;
        protected System.Windows.Forms.PictureBox pbxLocked;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtAdditionalFeeRemarks;
    }
}