namespace RegistrarServices
{
    partial class Classroom
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
            this.gbxSysID = new System.Windows.Forms.GroupBox();
            this.lblSysID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxClassroom = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOtherInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassroomCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbxSysID.SuspendLayout();
            this.gbxClassroom.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSysID
            // 
            this.gbxSysID.Controls.Add(this.lblSysID);
            this.gbxSysID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSysID.ForeColor = System.Drawing.Color.Navy;
            this.gbxSysID.Location = new System.Drawing.Point(326, 63);
            this.gbxSysID.Name = "gbxSysID";
            this.gbxSysID.Size = new System.Drawing.Size(206, 72);
            this.gbxSysID.TabIndex = 12;
            this.gbxSysID.TabStop = false;
            this.gbxSysID.Text = " SYSTEM ID ";
            // 
            // lblSysID
            // 
            this.lblSysID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSysID.ForeColor = System.Drawing.Color.Black;
            this.lblSysID.Location = new System.Drawing.Point(6, 32);
            this.lblSysID.Name = "lblSysID";
            this.lblSysID.Size = new System.Drawing.Size(194, 18);
            this.lblSysID.TabIndex = 0;
            this.lblSysID.Text = "Acquiring...";
            this.lblSysID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 58);
            this.panel1.TabIndex = 13;
            // 
            // gbxClassroom
            // 
            this.gbxClassroom.Controls.Add(this.label4);
            this.gbxClassroom.Controls.Add(this.label3);
            this.gbxClassroom.Controls.Add(this.txtOtherInfo);
            this.gbxClassroom.Controls.Add(this.label2);
            this.gbxClassroom.Controls.Add(this.txtCapacity);
            this.gbxClassroom.Controls.Add(this.txtDescription);
            this.gbxClassroom.Controls.Add(this.label1);
            this.gbxClassroom.Controls.Add(this.txtClassroomCode);
            this.gbxClassroom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxClassroom.ForeColor = System.Drawing.Color.Navy;
            this.gbxClassroom.Location = new System.Drawing.Point(12, 63);
            this.gbxClassroom.Name = "gbxClassroom";
            this.gbxClassroom.Size = new System.Drawing.Size(306, 192);
            this.gbxClassroom.TabIndex = 0;
            this.gbxClassroom.TabStop = false;
            this.gbxClassroom.Text = " CLASSROOM ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Other Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(172, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Maximum Capacity";
            // 
            // txtOtherInfo
            // 
            this.txtOtherInfo.BackColor = System.Drawing.Color.White;
            this.txtOtherInfo.Location = new System.Drawing.Point(9, 151);
            this.txtOtherInfo.MaxLength = 1000;
            this.txtOtherInfo.Name = "txtOtherInfo";
            this.txtOtherInfo.Size = new System.Drawing.Size(283, 23);
            this.txtOtherInfo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(172, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Classroom Description";
            // 
            // txtCapacity
            // 
            this.txtCapacity.BackColor = System.Drawing.Color.White;
            this.txtCapacity.Location = new System.Drawing.Point(122, 90);
            this.txtCapacity.MaxLength = 2;
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(47, 23);
            this.txtCapacity.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(9, 61);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(160, 23);
            this.txtDescription.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(172, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Classroom Code";
            // 
            // txtClassroomCode
            // 
            this.txtClassroomCode.BackColor = System.Drawing.Color.White;
            this.txtClassroomCode.Location = new System.Drawing.Point(65, 32);
            this.txtClassroomCode.MaxLength = 50;
            this.txtClassroomCode.Name = "txtClassroomCode";
            this.txtClassroomCode.Size = new System.Drawing.Size(104, 23);
            this.txtClassroomCode.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(-1, 278);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 35);
            this.panel2.TabIndex = 1;
            // 
            // Classroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(544, 312);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbxClassroom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbxSysID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Classroom";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxSysID.ResumeLayout(false);
            this.gbxClassroom.ResumeLayout(false);
            this.gbxClassroom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSysID;
        private System.Windows.Forms.GroupBox gbxClassroom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label lblSysID;
        protected System.Windows.Forms.TextBox txtCapacity;
        protected System.Windows.Forms.TextBox txtDescription;
        protected System.Windows.Forms.TextBox txtClassroomCode;
        protected System.Windows.Forms.TextBox txtOtherInfo;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel panel2;
    }
}