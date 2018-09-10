using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServices
{
    internal partial class ReceiptInformationCancelRecord : ReceiptNumberInformation
    {
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnProceed;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptInformationCancelRecord));
            this.btnProceed = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.gbxAdditionalPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlockPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLockedPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnProceed);
            // 
            // btnProceed
            // 
            this.btnProceed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnProceed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProceed.BackgroundImage")));
            this.btnProceed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProceed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.Location = new System.Drawing.Point(299, 5);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(86, 24);
            this.btnProceed.TabIndex = 9;
            this.btnProceed.Text = "     Proceed";
            this.btnProceed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProceed.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(391, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "  Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ReceiptInformationCancelRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(495, 378);
            this.Name = "ReceiptInformationCancelRecord";
            this.panel2.ResumeLayout(false);
            this.gbxAdditionalPayment.ResumeLayout(false);
            this.gbxAdditionalPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlockPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLockedPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
