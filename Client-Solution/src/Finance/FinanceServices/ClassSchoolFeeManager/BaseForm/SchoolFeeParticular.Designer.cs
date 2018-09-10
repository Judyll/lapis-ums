namespace FinanceServices
{
    partial class SchoolFeeParticular
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboFeeCategory = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtParticularDescription = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkIsOptional = new System.Windows.Forms.CheckBox();
            this.chkIsOfficesAccess = new System.Windows.Forms.CheckBox();
            this.chkEntryLevelIncluded = new System.Windows.Forms.CheckBox();
            this.chkIsGraduationFee = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 58);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboFeeCategory);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 75);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Fee Category ";
            // 
            // cboFeeCategory
            // 
            this.cboFeeCategory.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboFeeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeeCategory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFeeCategory.FormattingEnabled = true;
            this.cboFeeCategory.Location = new System.Drawing.Point(18, 30);
            this.cboFeeCategory.Name = "cboFeeCategory";
            this.cboFeeCategory.Size = new System.Drawing.Size(333, 27);
            this.cboFeeCategory.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtParticularDescription);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 75);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Particular Description ";
            // 
            // txtParticularDescription
            // 
            this.txtParticularDescription.BackColor = System.Drawing.Color.White;
            this.txtParticularDescription.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParticularDescription.Location = new System.Drawing.Point(18, 29);
            this.txtParticularDescription.MaxLength = 100;
            this.txtParticularDescription.Name = "txtParticularDescription";
            this.txtParticularDescription.Size = new System.Drawing.Size(333, 27);
            this.txtParticularDescription.TabIndex = 0;
            this.txtParticularDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(133)))));
            this.panel2.Location = new System.Drawing.Point(0, 320);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 38);
            this.panel2.TabIndex = 29;
            // 
            // chkIsOptional
            // 
            this.chkIsOptional.AutoSize = true;
            this.chkIsOptional.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsOptional.ForeColor = System.Drawing.Color.Navy;
            this.chkIsOptional.Location = new System.Drawing.Point(25, 243);
            this.chkIsOptional.Name = "chkIsOptional";
            this.chkIsOptional.Size = new System.Drawing.Size(84, 19);
            this.chkIsOptional.TabIndex = 61;
            this.chkIsOptional.Text = "Is Optional";
            this.chkIsOptional.UseVisualStyleBackColor = true;
            // 
            // chkIsOfficesAccess
            // 
            this.chkIsOfficesAccess.AutoSize = true;
            this.chkIsOfficesAccess.Enabled = false;
            this.chkIsOfficesAccess.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsOfficesAccess.ForeColor = System.Drawing.Color.Navy;
            this.chkIsOfficesAccess.Location = new System.Drawing.Point(38, 293);
            this.chkIsOfficesAccess.Name = "chkIsOfficesAccess";
            this.chkIsOfficesAccess.Size = new System.Drawing.Size(206, 19);
            this.chkIsOfficesAccess.TabIndex = 62;
            this.chkIsOfficesAccess.Text = "Is Accessible to Office Secretaries";
            this.chkIsOfficesAccess.UseVisualStyleBackColor = true;
            // 
            // chkEntryLevelIncluded
            // 
            this.chkEntryLevelIncluded.AutoSize = true;
            this.chkEntryLevelIncluded.Enabled = false;
            this.chkEntryLevelIncluded.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEntryLevelIncluded.ForeColor = System.Drawing.Color.Navy;
            this.chkEntryLevelIncluded.Location = new System.Drawing.Point(38, 268);
            this.chkEntryLevelIncluded.Name = "chkEntryLevelIncluded";
            this.chkEntryLevelIncluded.Size = new System.Drawing.Size(147, 19);
            this.chkEntryLevelIncluded.TabIndex = 63;
            this.chkEntryLevelIncluded.Text = "Is Entry Level Included";
            this.chkEntryLevelIncluded.UseVisualStyleBackColor = true;
            // 
            // chkIsGraduationFee
            // 
            this.chkIsGraduationFee.AutoSize = true;
            this.chkIsGraduationFee.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsGraduationFee.ForeColor = System.Drawing.Color.Navy;
            this.chkIsGraduationFee.Location = new System.Drawing.Point(261, 243);
            this.chkIsGraduationFee.Name = "chkIsGraduationFee";
            this.chkIsGraduationFee.Size = new System.Drawing.Size(121, 19);
            this.chkIsGraduationFee.TabIndex = 64;
            this.chkIsGraduationFee.Text = "Is Graduation Fee";
            this.chkIsGraduationFee.UseVisualStyleBackColor = true;
            // 
            // SchoolFeeParticular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(395, 357);
            this.Controls.Add(this.chkIsGraduationFee);
            this.Controls.Add(this.chkEntryLevelIncluded);
            this.Controls.Add(this.chkIsOfficesAccess);
            this.Controls.Add(this.chkIsOptional);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SchoolFeeParticular";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.ComboBox cboFeeCategory;
        protected System.Windows.Forms.TextBox txtParticularDescription;
        protected System.Windows.Forms.CheckBox chkIsOptional;
        protected System.Windows.Forms.CheckBox chkIsOfficesAccess;
        protected System.Windows.Forms.CheckBox chkEntryLevelIncluded;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.CheckBox chkIsGraduationFee;
    }
}