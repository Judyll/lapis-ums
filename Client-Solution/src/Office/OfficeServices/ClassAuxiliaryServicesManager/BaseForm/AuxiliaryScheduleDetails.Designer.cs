namespace OfficeServices
{
    partial class AuxiliaryScheduleDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuxiliaryScheduleDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblUnitsLabHours = new System.Windows.Forms.Label();
            this.lblSysIdAuxiliary = new System.Windows.Forms.Label();
            this.lblAuxiliaryDepartment = new System.Windows.Forms.Label();
            this.lblAuxiliaryServiceCodeDescription = new System.Windows.Forms.Label();
            this.gbxUnits = new System.Windows.Forms.GroupBox();
            this.hrmHours = new RemoteClient.HourMinute();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblLaboratory = new System.Windows.Forms.Label();
            this.lblLecture = new System.Windows.Forms.Label();
            this.optHours = new System.Windows.Forms.RadioButton();
            this.txtLaboratory = new System.Windows.Forms.TextBox();
            this.optUnits = new System.Windows.Forms.RadioButton();
            this.txtLecture = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbxLocked = new System.Windows.Forms.PictureBox();
            this.pbxUnlock = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.gbxUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLocked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 58);
            this.panel1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblUnitsLabHours);
            this.groupBox2.Controls.Add(this.lblSysIdAuxiliary);
            this.groupBox2.Controls.Add(this.lblAuxiliaryDepartment);
            this.groupBox2.Controls.Add(this.lblAuxiliaryServiceCodeDescription);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 131);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " SERVICE ";
            // 
            // lblUnitsLabHours
            // 
            this.lblUnitsLabHours.AutoSize = true;
            this.lblUnitsLabHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitsLabHours.ForeColor = System.Drawing.Color.Black;
            this.lblUnitsLabHours.Location = new System.Drawing.Point(16, 100);
            this.lblUnitsLabHours.Name = "lblUnitsLabHours";
            this.lblUnitsLabHours.Size = new System.Drawing.Size(16, 16);
            this.lblUnitsLabHours.TabIndex = 20;
            this.lblUnitsLabHours.Text = "--";
            // 
            // lblSysIdAuxiliary
            // 
            this.lblSysIdAuxiliary.AutoSize = true;
            this.lblSysIdAuxiliary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSysIdAuxiliary.ForeColor = System.Drawing.Color.Black;
            this.lblSysIdAuxiliary.Location = new System.Drawing.Point(16, 26);
            this.lblSysIdAuxiliary.Name = "lblSysIdAuxiliary";
            this.lblSysIdAuxiliary.Size = new System.Drawing.Size(16, 16);
            this.lblSysIdAuxiliary.TabIndex = 18;
            this.lblSysIdAuxiliary.Text = "--";
            // 
            // lblAuxiliaryDepartment
            // 
            this.lblAuxiliaryDepartment.AutoSize = true;
            this.lblAuxiliaryDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuxiliaryDepartment.ForeColor = System.Drawing.Color.DimGray;
            this.lblAuxiliaryDepartment.Location = new System.Drawing.Point(16, 76);
            this.lblAuxiliaryDepartment.Name = "lblAuxiliaryDepartment";
            this.lblAuxiliaryDepartment.Size = new System.Drawing.Size(18, 16);
            this.lblAuxiliaryDepartment.TabIndex = 21;
            this.lblAuxiliaryDepartment.Text = "--";
            // 
            // lblAuxiliaryServiceCodeDescription
            // 
            this.lblAuxiliaryServiceCodeDescription.AutoSize = true;
            this.lblAuxiliaryServiceCodeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuxiliaryServiceCodeDescription.ForeColor = System.Drawing.Color.Black;
            this.lblAuxiliaryServiceCodeDescription.Location = new System.Drawing.Point(16, 50);
            this.lblAuxiliaryServiceCodeDescription.Name = "lblAuxiliaryServiceCodeDescription";
            this.lblAuxiliaryServiceCodeDescription.Size = new System.Drawing.Size(262, 18);
            this.lblAuxiliaryServiceCodeDescription.TabIndex = 19;
            this.lblAuxiliaryServiceCodeDescription.Text = "Please select an auxiliary service.";
            // 
            // gbxUnits
            // 
            this.gbxUnits.Controls.Add(this.hrmHours);
            this.gbxUnits.Controls.Add(this.lblHours);
            this.gbxUnits.Controls.Add(this.lblLaboratory);
            this.gbxUnits.Controls.Add(this.lblLecture);
            this.gbxUnits.Controls.Add(this.optHours);
            this.gbxUnits.Controls.Add(this.txtLaboratory);
            this.gbxUnits.Controls.Add(this.optUnits);
            this.gbxUnits.Controls.Add(this.txtLecture);
            this.gbxUnits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxUnits.ForeColor = System.Drawing.Color.Navy;
            this.gbxUnits.Location = new System.Drawing.Point(286, 201);
            this.gbxUnits.Name = "gbxUnits";
            this.gbxUnits.Size = new System.Drawing.Size(270, 150);
            this.gbxUnits.TabIndex = 22;
            this.gbxUnits.TabStop = false;
            this.gbxUnits.Text = " UNITS/HOURS EQUIVALENT ";
            // 
            // hrmHours
            // 
            this.hrmHours.Enabled = false;
            this.hrmHours.Location = new System.Drawing.Point(40, 109);
            this.hrmHours.Name = "hrmHours";
            this.hrmHours.Size = new System.Drawing.Size(122, 35);
            this.hrmHours.TabIndex = 7;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.ForeColor = System.Drawing.Color.Black;
            this.lblHours.Location = new System.Drawing.Point(164, 119);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(90, 15);
            this.lblHours.TabIndex = 6;
            this.lblHours.Text = "Hours/Minutes";
            // 
            // lblLaboratory
            // 
            this.lblLaboratory.AutoSize = true;
            this.lblLaboratory.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaboratory.ForeColor = System.Drawing.Color.Black;
            this.lblLaboratory.Location = new System.Drawing.Point(164, 62);
            this.lblLaboratory.Name = "lblLaboratory";
            this.lblLaboratory.Size = new System.Drawing.Size(96, 15);
            this.lblLaboratory.TabIndex = 5;
            this.lblLaboratory.Text = "Laboratory / RLE";
            // 
            // lblLecture
            // 
            this.lblLecture.AutoSize = true;
            this.lblLecture.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLecture.ForeColor = System.Drawing.Color.Black;
            this.lblLecture.Location = new System.Drawing.Point(164, 36);
            this.lblLecture.Name = "lblLecture";
            this.lblLecture.Size = new System.Drawing.Size(46, 15);
            this.lblLecture.TabIndex = 4;
            this.lblLecture.Text = "Lecture";
            // 
            // optHours
            // 
            this.optHours.AutoSize = true;
            this.optHours.Location = new System.Drawing.Point(31, 89);
            this.optHours.Name = "optHours";
            this.optHours.Size = new System.Drawing.Size(70, 19);
            this.optHours.TabIndex = 3;
            this.optHours.Text = "In Hours";
            this.optHours.UseVisualStyleBackColor = true;
            // 
            // txtLaboratory
            // 
            this.txtLaboratory.BackColor = System.Drawing.Color.White;
            this.txtLaboratory.Enabled = false;
            this.txtLaboratory.Location = new System.Drawing.Point(118, 58);
            this.txtLaboratory.MaxLength = 5;
            this.txtLaboratory.Name = "txtLaboratory";
            this.txtLaboratory.Size = new System.Drawing.Size(44, 23);
            this.txtLaboratory.TabIndex = 2;
            this.txtLaboratory.Text = "0";
            this.txtLaboratory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // optUnits
            // 
            this.optUnits.AutoSize = true;
            this.optUnits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optUnits.Location = new System.Drawing.Point(31, 31);
            this.optUnits.Name = "optUnits";
            this.optUnits.Size = new System.Drawing.Size(66, 19);
            this.optUnits.TabIndex = 0;
            this.optUnits.Text = "In Units";
            this.optUnits.UseVisualStyleBackColor = true;
            // 
            // txtLecture
            // 
            this.txtLecture.BackColor = System.Drawing.Color.White;
            this.txtLecture.Enabled = false;
            this.txtLecture.Location = new System.Drawing.Point(118, 31);
            this.txtLecture.MaxLength = 5;
            this.txtLecture.Name = "txtLecture";
            this.txtLecture.Size = new System.Drawing.Size(44, 23);
            this.txtLecture.TabIndex = 1;
            this.txtLecture.Text = "0";
            this.txtLecture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(0, 386);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(572, 37);
            this.panel2.TabIndex = 23;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(37, 361);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(122, 13);
            this.lblStatus.TabIndex = 75;
            this.lblStatus.Text = "This record is OPEN";
            this.lblStatus.Visible = false;
            // 
            // pbxLocked
            // 
            this.pbxLocked.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxLocked.BackgroundImage")));
            this.pbxLocked.Location = new System.Drawing.Point(12, 351);
            this.pbxLocked.Name = "pbxLocked";
            this.pbxLocked.Size = new System.Drawing.Size(24, 24);
            this.pbxLocked.TabIndex = 90;
            this.pbxLocked.TabStop = false;
            this.pbxLocked.Visible = false;
            // 
            // pbxUnlock
            // 
            this.pbxUnlock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxUnlock.BackgroundImage")));
            this.pbxUnlock.Location = new System.Drawing.Point(12, 351);
            this.pbxUnlock.Name = "pbxUnlock";
            this.pbxUnlock.Size = new System.Drawing.Size(24, 24);
            this.pbxUnlock.TabIndex = 91;
            this.pbxUnlock.TabStop = false;
            this.pbxUnlock.Visible = false;
            // 
            // AuxiliaryScheduleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(570, 422);
            this.Controls.Add(this.pbxUnlock);
            this.Controls.Add(this.pbxLocked);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbxUnits);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuxiliaryScheduleDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxUnits.ResumeLayout(false);
            this.gbxUnits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLocked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Label lblUnitsLabHours;
        protected System.Windows.Forms.Label lblSysIdAuxiliary;
        protected System.Windows.Forms.Label lblAuxiliaryDepartment;
        protected System.Windows.Forms.Label lblAuxiliaryServiceCodeDescription;
        private System.Windows.Forms.GroupBox gbxUnits;
        protected RemoteClient.HourMinute hrmHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblLaboratory;
        private System.Windows.Forms.Label lblLecture;
        protected System.Windows.Forms.RadioButton optHours;
        protected System.Windows.Forms.TextBox txtLaboratory;
        protected System.Windows.Forms.RadioButton optUnits;
        protected System.Windows.Forms.TextBox txtLecture;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Label lblStatus;
        protected System.Windows.Forms.PictureBox pbxLocked;
        protected System.Windows.Forms.PictureBox pbxUnlock;
    }
}