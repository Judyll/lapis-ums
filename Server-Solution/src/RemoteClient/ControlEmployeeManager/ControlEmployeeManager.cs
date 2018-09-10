using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteClient
{
    public partial class ControlEmployeeManager: ControlManager
    {
        protected System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPartTime;
        private System.Windows.Forms.CheckBox chkLayOff;
        private System.Windows.Forms.CheckBox chkRegular;
        private System.Windows.Forms.CheckBox chkProbationary;
        protected System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkMaintenance;
        private System.Windows.Forms.CheckBox chkAcademic;
        private System.Windows.Forms.CheckBox chkStaff;
        private System.Windows.Forms.CheckBox chkGradeKinder;
        private System.Windows.Forms.CheckBox chkHighSchool;
        private System.Windows.Forms.CheckBox chkCollege;
        private System.Windows.Forms.CheckBox chkGraduate;
        private System.Windows.Forms.CheckBox chkGraduateCollege;
        private System.Windows.Forms.CheckBox chkGraduateGSK;
        private System.Windows.Forms.CheckBox chkGraduateHS;
        protected System.Windows.Forms.PictureBox pbxAdd;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlEmployeeManager));
            this.pbxAdd = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLayOff = new System.Windows.Forms.CheckBox();
            this.chkRegular = new System.Windows.Forms.CheckBox();
            this.chkProbationary = new System.Windows.Forms.CheckBox();
            this.chkPartTime = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkGraduateGSK = new System.Windows.Forms.CheckBox();
            this.chkGraduateHS = new System.Windows.Forms.CheckBox();
            this.chkGraduate = new System.Windows.Forms.CheckBox();
            this.chkGraduateCollege = new System.Windows.Forms.CheckBox();
            this.chkMaintenance = new System.Windows.Forms.CheckBox();
            this.chkAcademic = new System.Windows.Forms.CheckBox();
            this.chkStaff = new System.Windows.Forms.CheckBox();
            this.chkGradeKinder = new System.Windows.Forms.CheckBox();
            this.chkHighSchool = new System.Windows.Forms.CheckBox();
            this.chkCollege = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAdd)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpMain
            // 
            this.ttpMain.AutoPopDelay = 3000;
            this.ttpMain.InitialDelay = 500;
            this.ttpMain.IsBalloon = true;
            this.ttpMain.ReshowDelay = 100;
            this.ttpMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpMain.ToolTipTitle = "Console";
            // 
            // pbxClose
            // 
            this.ttpMain.SetToolTip(this.pbxClose, "Close");
            // 
            // pbxRefresh
            // 
            this.ttpMain.SetToolTip(this.pbxRefresh, "Refresh");
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(260, 28);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.pbxAdd);
            this.pnlMain.Size = new System.Drawing.Size(254, 483);
            this.pnlMain.Controls.SetChildIndex(this.txtSearch, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxAdd, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxClose, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxFind, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox2, 0);
            this.pnlMain.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // pbxAdd
            // 
            this.pbxAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxAdd.BackColor = System.Drawing.Color.Transparent;
            this.pbxAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxAdd.Image = ((System.Drawing.Image)(resources.GetObject("pbxAdd.Image")));
            this.pbxAdd.Location = new System.Drawing.Point(136, 37);
            this.pbxAdd.Name = "pbxAdd";
            this.pbxAdd.Size = new System.Drawing.Size(33, 41);
            this.pbxAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAdd.TabIndex = 12;
            this.pbxAdd.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.chkLayOff);
            this.groupBox1.Controls.Add(this.chkRegular);
            this.groupBox1.Controls.Add(this.chkProbationary);
            this.groupBox1.Controls.Add(this.chkPartTime);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 111);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employment Status";
            // 
            // chkLayOff
            // 
            this.chkLayOff.AutoSize = true;
            this.chkLayOff.Location = new System.Drawing.Point(39, 88);
            this.chkLayOff.Name = "chkLayOff";
            this.chkLayOff.Size = new System.Drawing.Size(62, 17);
            this.chkLayOff.TabIndex = 3;
            this.chkLayOff.Text = "LAY-OFF";
            this.chkLayOff.UseVisualStyleBackColor = true;
            // 
            // chkRegular
            // 
            this.chkRegular.AutoSize = true;
            this.chkRegular.Location = new System.Drawing.Point(39, 65);
            this.chkRegular.Name = "chkRegular";
            this.chkRegular.Size = new System.Drawing.Size(62, 17);
            this.chkRegular.TabIndex = 2;
            this.chkRegular.Text = "Regular";
            this.chkRegular.UseVisualStyleBackColor = true;
            // 
            // chkProbationary
            // 
            this.chkProbationary.AutoSize = true;
            this.chkProbationary.Location = new System.Drawing.Point(39, 42);
            this.chkProbationary.Name = "chkProbationary";
            this.chkProbationary.Size = new System.Drawing.Size(88, 17);
            this.chkProbationary.TabIndex = 1;
            this.chkProbationary.Text = "Probationary";
            this.chkProbationary.UseVisualStyleBackColor = true;
            // 
            // chkPartTime
            // 
            this.chkPartTime.AutoSize = true;
            this.chkPartTime.Location = new System.Drawing.Point(39, 19);
            this.chkPartTime.Name = "chkPartTime";
            this.chkPartTime.Size = new System.Drawing.Size(130, 17);
            this.chkPartTime.TabIndex = 0;
            this.chkPartTime.Text = "Temporary / Part-time";
            this.chkPartTime.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.chkGraduateGSK);
            this.groupBox2.Controls.Add(this.chkGraduateHS);
            this.groupBox2.Controls.Add(this.chkGraduate);
            this.groupBox2.Controls.Add(this.chkGraduateCollege);
            this.groupBox2.Controls.Add(this.chkMaintenance);
            this.groupBox2.Controls.Add(this.chkAcademic);
            this.groupBox2.Controls.Add(this.chkStaff);
            this.groupBox2.Controls.Add(this.chkGradeKinder);
            this.groupBox2.Controls.Add(this.chkHighSchool);
            this.groupBox2.Controls.Add(this.chkCollege);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 251);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employment Type";
            // 
            // chkGraduateGSK
            // 
            this.chkGraduateGSK.AutoSize = true;
            this.chkGraduateGSK.Location = new System.Drawing.Point(39, 91);
            this.chkGraduateGSK.Name = "chkGraduateGSK";
            this.chkGraduateGSK.Size = new System.Drawing.Size(193, 17);
            this.chkGraduateGSK.TabIndex = 11;
            this.chkGraduateGSK.Text = "Graduate School and G.S./K. Faculty";
            this.chkGraduateGSK.UseVisualStyleBackColor = true;
            // 
            // chkGraduateHS
            // 
            this.chkGraduateHS.AutoSize = true;
            this.chkGraduateHS.Location = new System.Drawing.Point(39, 68);
            this.chkGraduateHS.Name = "chkGraduateHS";
            this.chkGraduateHS.Size = new System.Drawing.Size(180, 17);
            this.chkGraduateHS.TabIndex = 10;
            this.chkGraduateHS.Text = "Graduate School and H.S. Faculty";
            this.chkGraduateHS.UseVisualStyleBackColor = true;
            // 
            // chkGraduate
            // 
            this.chkGraduate.AutoSize = true;
            this.chkGraduate.Location = new System.Drawing.Point(39, 22);
            this.chkGraduate.Name = "chkGraduate";
            this.chkGraduate.Size = new System.Drawing.Size(140, 17);
            this.chkGraduate.TabIndex = 8;
            this.chkGraduate.Text = "Graduate School Faculty";
            this.chkGraduate.UseVisualStyleBackColor = true;
            // 
            // chkGraduateCollege
            // 
            this.chkGraduateCollege.AutoSize = true;
            this.chkGraduateCollege.Location = new System.Drawing.Point(39, 45);
            this.chkGraduateCollege.Name = "chkGraduateCollege";
            this.chkGraduateCollege.Size = new System.Drawing.Size(197, 17);
            this.chkGraduateCollege.TabIndex = 7;
            this.chkGraduateCollege.Text = "Graduate School and College Faculty";
            this.chkGraduateCollege.UseVisualStyleBackColor = true;
            // 
            // chkMaintenance
            // 
            this.chkMaintenance.AutoSize = true;
            this.chkMaintenance.Location = new System.Drawing.Point(39, 229);
            this.chkMaintenance.Name = "chkMaintenance";
            this.chkMaintenance.Size = new System.Drawing.Size(89, 17);
            this.chkMaintenance.TabIndex = 6;
            this.chkMaintenance.Text = "Maintenance";
            this.chkMaintenance.UseVisualStyleBackColor = true;
            // 
            // chkAcademic
            // 
            this.chkAcademic.AutoSize = true;
            this.chkAcademic.Location = new System.Drawing.Point(39, 206);
            this.chkAcademic.Name = "chkAcademic";
            this.chkAcademic.Size = new System.Drawing.Size(138, 17);
            this.chkAcademic.TabIndex = 5;
            this.chkAcademic.Text = "Academic Non-Teaching";
            this.chkAcademic.UseVisualStyleBackColor = true;
            // 
            // chkStaff
            // 
            this.chkStaff.AutoSize = true;
            this.chkStaff.Location = new System.Drawing.Point(39, 183);
            this.chkStaff.Name = "chkStaff";
            this.chkStaff.Size = new System.Drawing.Size(119, 17);
            this.chkStaff.TabIndex = 4;
            this.chkStaff.Text = "Non-Teaching / Staff";
            this.chkStaff.UseVisualStyleBackColor = true;
            // 
            // chkGradeKinder
            // 
            this.chkGradeKinder.AutoSize = true;
            this.chkGradeKinder.Location = new System.Drawing.Point(39, 160);
            this.chkGradeKinder.Name = "chkGradeKinder";
            this.chkGradeKinder.Size = new System.Drawing.Size(163, 17);
            this.chkGradeKinder.TabIndex = 3;
            this.chkGradeKinder.Text = "Grade School / Kinder Faculty";
            this.chkGradeKinder.UseVisualStyleBackColor = true;
            // 
            // chkHighSchool
            // 
            this.chkHighSchool.AutoSize = true;
            this.chkHighSchool.Location = new System.Drawing.Point(39, 137);
            this.chkHighSchool.Name = "chkHighSchool";
            this.chkHighSchool.Size = new System.Drawing.Size(116, 17);
            this.chkHighSchool.TabIndex = 2;
            this.chkHighSchool.Text = "High School Faculty";
            this.chkHighSchool.UseVisualStyleBackColor = true;
            // 
            // chkCollege
            // 
            this.chkCollege.AutoSize = true;
            this.chkCollege.Location = new System.Drawing.Point(39, 114);
            this.chkCollege.Name = "chkCollege";
            this.chkCollege.Size = new System.Drawing.Size(97, 17);
            this.chkCollege.TabIndex = 0;
            this.chkCollege.Text = "College Faculty";
            this.chkCollege.UseVisualStyleBackColor = true;
            // 
            // ControlEmployeeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlEmployeeManager";
            this.Size = new System.Drawing.Size(254, 483);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAdd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        
    }
}
