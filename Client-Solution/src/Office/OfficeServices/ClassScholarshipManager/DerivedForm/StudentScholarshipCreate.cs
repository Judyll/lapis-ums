using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeServices
{
    internal partial class StudentScholarshipCreate : StudentScholarship
    {
        protected System.Windows.Forms.Button btnCreate;
        protected System.Windows.Forms.PictureBox pbxUnlock;
        protected System.Windows.Forms.Label lblStatus;
        protected System.Windows.Forms.PictureBox pbxLocked;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentScholarshipCreate));
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbxUnlock = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbxLocked = new System.Windows.Forms.PictureBox();
            this.gbxSysID.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxPersonalInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLocked)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSysID
            // 
            this.gbxSysID.Location = new System.Drawing.Point(14, 73);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(14, 195);
            // 
            // gbxPersonalInfo
            // 
            this.gbxPersonalInfo.Location = new System.Drawing.Point(317, 73);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Location = new System.Drawing.Point(-1, 372);
            // 
            // btnCreate
            // 
            this.btnCreate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreate.BackgroundImage")));
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(552, 6);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(86, 23);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "  Create";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(644, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "  Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pbxUnlock
            // 
            this.pbxUnlock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxUnlock.BackgroundImage")));
            this.pbxUnlock.Location = new System.Drawing.Point(16, 344);
            this.pbxUnlock.Name = "pbxUnlock";
            this.pbxUnlock.Size = new System.Drawing.Size(24, 24);
            this.pbxUnlock.TabIndex = 92;
            this.pbxUnlock.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(40, 352);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(122, 13);
            this.lblStatus.TabIndex = 91;
            this.lblStatus.Text = "This record is OPEN";
            // 
            // pbxLocked
            // 
            this.pbxLocked.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxLocked.BackgroundImage")));
            this.pbxLocked.Location = new System.Drawing.Point(16, 344);
            this.pbxLocked.Name = "pbxLocked";
            this.pbxLocked.Size = new System.Drawing.Size(24, 24);
            this.pbxLocked.TabIndex = 93;
            this.pbxLocked.TabStop = false;
            this.pbxLocked.Visible = false;
            // 
            // StudentScholarshipCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(747, 406);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbxUnlock);
            this.Controls.Add(this.pbxLocked);
            this.Name = "StudentScholarshipCreate";
            this.Controls.SetChildIndex(this.pbxLocked, 0);
            this.Controls.SetChildIndex(this.pbxUnlock, 0);
            this.Controls.SetChildIndex(this.gbxSysID, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.gbxPersonalInfo, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.gbxSysID.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxPersonalInfo.ResumeLayout(false);
            this.gbxPersonalInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLocked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
