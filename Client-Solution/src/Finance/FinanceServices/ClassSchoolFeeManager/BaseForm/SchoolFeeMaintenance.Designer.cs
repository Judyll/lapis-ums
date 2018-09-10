namespace FinanceServices
{
    partial class SchoolFeeMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchoolFeeMaintenance));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboYearLevel = new System.Windows.Forms.ComboBox();
            this.dgvSchoolFees = new System.Windows.Forms.DataGridView();
            this.lnkCreateYearLevel = new System.Windows.Forms.LinkLabel();
            this.lnkCreateSchoolFeeDetails = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchoolFees)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 58);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(0, 575);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(627, 39);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(526, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "  Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboYearLevel);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 52);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " YEAR LEVEL ";
            // 
            // cboYearLevel
            // 
            this.cboYearLevel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearLevel.FormattingEnabled = true;
            this.cboYearLevel.Location = new System.Drawing.Point(14, 20);
            this.cboYearLevel.Name = "cboYearLevel";
            this.cboYearLevel.Size = new System.Drawing.Size(233, 23);
            this.cboYearLevel.TabIndex = 0;
            // 
            // dgvSchoolFees
            // 
            this.dgvSchoolFees.AllowUserToAddRows = false;
            this.dgvSchoolFees.AllowUserToDeleteRows = false;
            this.dgvSchoolFees.AllowUserToResizeColumns = false;
            this.dgvSchoolFees.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSchoolFees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSchoolFees.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvSchoolFees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSchoolFees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchoolFees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSchoolFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchoolFees.Location = new System.Drawing.Point(12, 134);
            this.dgvSchoolFees.Name = "dgvSchoolFees";
            this.dgvSchoolFees.RowHeadersVisible = false;
            this.dgvSchoolFees.RowHeadersWidth = 15;
            this.dgvSchoolFees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.dgvSchoolFees.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSchoolFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchoolFees.Size = new System.Drawing.Size(600, 413);
            this.dgvSchoolFees.TabIndex = 75;
            // 
            // lnkCreateYearLevel
            // 
            this.lnkCreateYearLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkCreateYearLevel.AutoSize = true;
            this.lnkCreateYearLevel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreateYearLevel.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkCreateYearLevel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreateYearLevel.Location = new System.Drawing.Point(279, 91);
            this.lnkCreateYearLevel.Name = "lnkCreateYearLevel";
            this.lnkCreateYearLevel.Size = new System.Drawing.Size(180, 15);
            this.lnkCreateYearLevel.TabIndex = 77;
            this.lnkCreateYearLevel.TabStop = true;
            this.lnkCreateYearLevel.Text = "[ Create New School Fee Level ]";
            this.lnkCreateYearLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkCreateYearLevel.Visible = false;
            // 
            // lnkCreateSchoolFeeDetails
            // 
            this.lnkCreateSchoolFeeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkCreateSchoolFeeDetails.AutoSize = true;
            this.lnkCreateSchoolFeeDetails.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreateSchoolFeeDetails.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkCreateSchoolFeeDetails.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreateSchoolFeeDetails.Location = new System.Drawing.Point(453, 550);
            this.lnkCreateSchoolFeeDetails.Name = "lnkCreateSchoolFeeDetails";
            this.lnkCreateSchoolFeeDetails.Size = new System.Drawing.Size(159, 15);
            this.lnkCreateSchoolFeeDetails.TabIndex = 78;
            this.lnkCreateSchoolFeeDetails.TabStop = true;
            this.lnkCreateSchoolFeeDetails.Text = "[ Create School Fee Details ]";
            this.lnkCreateSchoolFeeDetails.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkCreateSchoolFeeDetails.Visible = false;
            // 
            // SchoolFeeMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(624, 613);
            this.Controls.Add(this.lnkCreateSchoolFeeDetails);
            this.Controls.Add(this.lnkCreateYearLevel);
            this.Controls.Add(this.dgvSchoolFees);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SchoolFeeMaintenance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchoolFees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.ComboBox cboYearLevel;
        private System.Windows.Forms.DataGridView dgvSchoolFees;
        private System.Windows.Forms.LinkLabel lnkCreateYearLevel;
        private System.Windows.Forms.LinkLabel lnkCreateSchoolFeeDetails;
        protected System.Windows.Forms.Panel panel1;
    }
}