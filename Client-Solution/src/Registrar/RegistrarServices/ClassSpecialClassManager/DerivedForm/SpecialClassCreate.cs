using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    internal partial class SpecialClassCreate : SpecialClass
    {

        private Button btnCreate;
        private Button btnCancel;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialClassCreate));
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.tabSpecialInformation.SuspendLayout();
            this.tbpInformation.SuspendLayout();
            this.tbpEnrolled.SuspendLayout();
            this.tbpWithdrawn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxSysID.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLocked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.TabIndex = 1;
            // 
            // lblCountEnrolled
            // 
            this.lblCountEnrolled.Size = new System.Drawing.Size(62, 13);
            this.lblCountEnrolled.Text = "0 Student";
            // 
            // lblCountWithdrawn
            // 
            this.lblCountWithdrawn.Size = new System.Drawing.Size(62, 13);
            this.lblCountWithdrawn.Text = "0 Student";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            // 
            // tabControl1
            // 
            this.tabSpecialInformation.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.TabIndex = 1;
            // 
            // btnSearchSubject
            // 
            this.btnSearchSubject.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.Text = "0.00";
            // 
            // btnSearchEmployee
            // 
            this.btnSearchEmployee.TabIndex = 0;
            // 
            // pbxUnlock
            // 
            this.pbxUnlock.Visible = true;
            // 
            // btnCreate
            // 
            this.btnCreate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreate.BackgroundImage")));
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(457, 8);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(86, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "  Create";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(549, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "  Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SpecialClassCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(649, 695);
            this.Name = "SpecialClassCreate";
            this.panel2.ResumeLayout(false);
            this.tabSpecialInformation.ResumeLayout(false);
            this.tbpInformation.ResumeLayout(false);
            this.tbpEnrolled.ResumeLayout(false);
            this.tbpEnrolled.PerformLayout();
            this.tbpWithdrawn.ResumeLayout(false);
            this.tbpWithdrawn.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gbxSysID.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLocked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
