using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServices
{
    internal partial class StudentEnrolmentHistory : StudentCashier
    {
        protected System.Windows.Forms.Button btnClose;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentEnrolmentHistory));
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStudent)).BeginInit();
            this.gbxPersonalInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbxEnrolmentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            // 
            // txtScholarship
            // 
            this.txtScholarship.ReadOnly = true;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.ReadOnly = true;
            // 
            // txtStudentFirstName
            // 
            this.txtStudentFirstName.ReadOnly = true;
            // 
            // txtStudentLastName
            // 
            this.txtStudentLastName.ReadOnly = true;
            // 
            // txtStudentId
            // 
            this.txtStudentId.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            // 
            // trvStudentEnrolment
            // 
            this.trvStudentEnrolment.LineColor = System.Drawing.Color.Black;
            // 
            // chkRequiredDownPayment
            // 
            this.chkRequiredDownPayment.Enabled = false;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(528, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 92;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // StudentEnrolmentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(626, 651);
            this.Name = "StudentEnrolmentHistory";
            this.Controls.SetChildIndex(this.gbxEnrolmentInfo, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gbxPersonalInfo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbxStudent)).EndInit();
            this.gbxPersonalInfo.ResumeLayout(false);
            this.gbxPersonalInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.gbxEnrolmentInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
