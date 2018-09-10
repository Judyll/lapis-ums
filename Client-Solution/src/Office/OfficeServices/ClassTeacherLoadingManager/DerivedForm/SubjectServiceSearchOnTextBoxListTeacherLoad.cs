using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeServices
{
    internal partial class SubjectServiceSearchOnTextBoxListTeacherLoad : SearchOnTextboxListStudentLoad
    {
        private System.Windows.Forms.CheckBox chkIsIrregular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.PictureBox pbxChecked;
        protected System.Windows.Forms.PictureBox pbxInsertSubjects;
    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectServiceSearchOnTextBoxListTeacherLoad));
            this.chkIsIrregular = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbxChecked = new System.Windows.Forms.PictureBox();
            this.pbxInsertSubjects = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInsertSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(53, 373);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 373);
            // 
            // chkIsIrregular
            // 
            this.chkIsIrregular.AutoSize = true;
            this.chkIsIrregular.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsIrregular.ForeColor = System.Drawing.Color.Maroon;
            this.chkIsIrregular.Location = new System.Drawing.Point(75, 308);
            this.chkIsIrregular.Name = "chkIsIrregular";
            this.chkIsIrregular.Size = new System.Drawing.Size(264, 23);
            this.chkIsIrregular.TabIndex = 84;
            this.chkIsIrregular.Text = "Enable REPETITIVE LOADING Mode";
            this.chkIsIrregular.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(160, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 16);
            this.label3.TabIndex = 83;
            this.label3.Text = "|";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.ForeColor = System.Drawing.Color.Red;
            this.lblSelected.Location = new System.Drawing.Point(232, 371);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(15, 15);
            this.lblSelected.TabIndex = 82;
            this.lblSelected.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(172, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Selected:";
            // 
            // pbxChecked
            // 
            this.pbxChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxChecked.BackColor = System.Drawing.Color.Transparent;
            this.pbxChecked.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxChecked.Image = ((System.Drawing.Image)(resources.GetObject("pbxChecked.Image")));
            this.pbxChecked.Location = new System.Drawing.Point(17, 19);
            this.pbxChecked.Name = "pbxChecked";
            this.pbxChecked.Size = new System.Drawing.Size(22, 22);
            this.pbxChecked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxChecked.TabIndex = 80;
            this.pbxChecked.TabStop = false;
            // 
            // pbxInsertSubjects
            // 
            this.pbxInsertSubjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxInsertSubjects.BackColor = System.Drawing.Color.Transparent;
            this.pbxInsertSubjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxInsertSubjects.Image = ((System.Drawing.Image)(resources.GetObject("pbxInsertSubjects.Image")));
            this.pbxInsertSubjects.Location = new System.Drawing.Point(17, 290);
            this.pbxInsertSubjects.Name = "pbxInsertSubjects";
            this.pbxInsertSubjects.Size = new System.Drawing.Size(51, 51);
            this.pbxInsertSubjects.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxInsertSubjects.TabIndex = 79;
            this.pbxInsertSubjects.TabStop = false;
            // 
            // SubjectServiceSearchOnTextBoxListTeacherLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 395);
            this.Controls.Add(this.chkIsIrregular);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbxChecked);
            this.Controls.Add(this.pbxInsertSubjects);
            this.Name = "SubjectServiceSearchOnTextBoxListTeacherLoad";
            this.Text = "    Subject Schedule / Service List";
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblResult, 0);
            this.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.Controls.SetChildIndex(this.pbxDone, 0);
            this.Controls.SetChildIndex(this.pbxInsertSubjects, 0);
            this.Controls.SetChildIndex(this.pbxChecked, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblSelected, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.chkIsIrregular, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInsertSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
