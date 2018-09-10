namespace OfficeServices
{
    partial class ClassroomDateTimeScheduler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassroomDateTimeScheduler));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbxClassroom = new System.Windows.Forms.GroupBox();
            this.lblMaxCapacity = new System.Windows.Forms.Label();
            this.lblClassroomCode = new System.Windows.Forms.Label();
            this.lblMCapacity = new System.Windows.Forms.Label();
            this.lblClassCode = new System.Windows.Forms.Label();
            this.btnSearchClassroom = new System.Windows.Forms.Button();
            this.gbxDayTime = new System.Windows.Forms.GroupBox();
            this.ctfDayTime = new RemoteClient.ControlTimeFrame();
            this.gbxClassroom.SuspendLayout();
            this.gbxDayTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 58);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Location = new System.Drawing.Point(-1, 663);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 35);
            this.panel2.TabIndex = 75;
            // 
            // gbxClassroom
            // 
            this.gbxClassroom.BackColor = System.Drawing.Color.Transparent;
            this.gbxClassroom.Controls.Add(this.lblMaxCapacity);
            this.gbxClassroom.Controls.Add(this.lblClassroomCode);
            this.gbxClassroom.Controls.Add(this.lblMCapacity);
            this.gbxClassroom.Controls.Add(this.lblClassCode);
            this.gbxClassroom.Controls.Add(this.btnSearchClassroom);
            this.gbxClassroom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxClassroom.ForeColor = System.Drawing.Color.Navy;
            this.gbxClassroom.Location = new System.Drawing.Point(638, 64);
            this.gbxClassroom.Name = "gbxClassroom";
            this.gbxClassroom.Size = new System.Drawing.Size(246, 90);
            this.gbxClassroom.TabIndex = 76;
            this.gbxClassroom.TabStop = false;
            this.gbxClassroom.Text = " CLASSROOM ";
            // 
            // lblMaxCapacity
            // 
            this.lblMaxCapacity.AutoSize = true;
            this.lblMaxCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxCapacity.ForeColor = System.Drawing.Color.Black;
            this.lblMaxCapacity.Location = new System.Drawing.Point(125, 63);
            this.lblMaxCapacity.Name = "lblMaxCapacity";
            this.lblMaxCapacity.Size = new System.Drawing.Size(16, 16);
            this.lblMaxCapacity.TabIndex = 24;
            this.lblMaxCapacity.Text = "--";
            // 
            // lblClassroomCode
            // 
            this.lblClassroomCode.AutoSize = true;
            this.lblClassroomCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassroomCode.ForeColor = System.Drawing.Color.Black;
            this.lblClassroomCode.Location = new System.Drawing.Point(125, 45);
            this.lblClassroomCode.Name = "lblClassroomCode";
            this.lblClassroomCode.Size = new System.Drawing.Size(16, 16);
            this.lblClassroomCode.TabIndex = 23;
            this.lblClassroomCode.Text = "--";
            // 
            // lblMCapacity
            // 
            this.lblMCapacity.AutoSize = true;
            this.lblMCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMCapacity.ForeColor = System.Drawing.Color.DimGray;
            this.lblMCapacity.Location = new System.Drawing.Point(19, 66);
            this.lblMCapacity.Name = "lblMCapacity";
            this.lblMCapacity.Size = new System.Drawing.Size(95, 13);
            this.lblMCapacity.TabIndex = 22;
            this.lblMCapacity.Text = "Max. Capacity :";
            this.lblMCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClassCode
            // 
            this.lblClassCode.AutoSize = true;
            this.lblClassCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassCode.ForeColor = System.Drawing.Color.DimGray;
            this.lblClassCode.Location = new System.Drawing.Point(19, 48);
            this.lblClassCode.Name = "lblClassCode";
            this.lblClassCode.Size = new System.Drawing.Size(105, 13);
            this.lblClassCode.TabIndex = 21;
            this.lblClassCode.Text = "Classroom Code :";
            this.lblClassCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearchClassroom
            // 
            this.btnSearchClassroom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchClassroom.BackgroundImage")));
            this.btnSearchClassroom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchClassroom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchClassroom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchClassroom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchClassroom.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearchClassroom.Location = new System.Drawing.Point(207, 12);
            this.btnSearchClassroom.Name = "btnSearchClassroom";
            this.btnSearchClassroom.Size = new System.Drawing.Size(35, 35);
            this.btnSearchClassroom.TabIndex = 3;
            this.btnSearchClassroom.UseVisualStyleBackColor = true;
            // 
            // gbxDayTime
            // 
            this.gbxDayTime.BackColor = System.Drawing.Color.Transparent;
            this.gbxDayTime.Controls.Add(this.ctfDayTime);
            this.gbxDayTime.Enabled = false;
            this.gbxDayTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDayTime.ForeColor = System.Drawing.Color.Navy;
            this.gbxDayTime.Location = new System.Drawing.Point(10, 64);
            this.gbxDayTime.Name = "gbxDayTime";
            this.gbxDayTime.Size = new System.Drawing.Size(618, 627);
            this.gbxDayTime.TabIndex = 77;
            this.gbxDayTime.TabStop = false;
            this.gbxDayTime.Text = " DAY AND TIME ";
            // 
            // ctfDayTime
            // 
            this.ctfDayTime.Location = new System.Drawing.Point(6, 15);
            this.ctfDayTime.Name = "ctfDayTime";
            this.ctfDayTime.ReadOnlySubjectCodeFieldName = "subject_code";
            this.ctfDayTime.Size = new System.Drawing.Size(606, 606);
            this.ctfDayTime.TabIndex = 0;
            this.ctfDayTime.TimeDescriptionFieldName = "time_description";
            this.ctfDayTime.TimeIdFieldName = "time_id";
            this.ctfDayTime.WeekDayAcronymFieldName = "acronym";
            this.ctfDayTime.WeekDayDescriptionFieldName = "week_description";
            this.ctfDayTime.WeekDayIdFieldName = "week_id";
            // 
            // ClassroomDateTimeScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(896, 698);
            this.Controls.Add(this.gbxClassroom);
            this.Controls.Add(this.gbxDayTime);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassroomDateTimeScheduler";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxClassroom.ResumeLayout(false);
            this.gbxClassroom.PerformLayout();
            this.gbxDayTime.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.GroupBox gbxClassroom;
        protected System.Windows.Forms.Label lblMaxCapacity;
        protected System.Windows.Forms.Label lblClassroomCode;
        protected System.Windows.Forms.Label lblMCapacity;
        protected System.Windows.Forms.Label lblClassCode;
        protected System.Windows.Forms.Button btnSearchClassroom;
        protected System.Windows.Forms.GroupBox gbxDayTime;
        protected System.Windows.Forms.Panel panel2;
        protected RemoteClient.ControlTimeFrame ctfDayTime;
    }
}