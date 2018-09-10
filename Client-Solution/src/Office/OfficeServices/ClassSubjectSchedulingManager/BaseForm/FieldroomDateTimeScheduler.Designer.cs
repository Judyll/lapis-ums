namespace OfficeServices
{
    partial class FieldroomDateTimeScheduler
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
            this.gbxDayTime = new System.Windows.Forms.GroupBox();
            this.ctfDayTime = new RemoteClient.ControlTimeFrame();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbxDayTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDayTime
            // 
            this.gbxDayTime.BackColor = System.Drawing.Color.Transparent;
            this.gbxDayTime.Controls.Add(this.ctfDayTime);
            this.gbxDayTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDayTime.ForeColor = System.Drawing.Color.Navy;
            this.gbxDayTime.Location = new System.Drawing.Point(10, 59);
            this.gbxDayTime.Name = "gbxDayTime";
            this.gbxDayTime.Size = new System.Drawing.Size(618, 627);
            this.gbxDayTime.TabIndex = 80;
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
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-3, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 58);
            this.panel1.TabIndex = 78;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Location = new System.Drawing.Point(-3, 658);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(861, 35);
            this.panel2.TabIndex = 79;
            // 
            // DateTimeScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(853, 693);
            this.Controls.Add(this.gbxDayTime);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateTimeScheduler";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxDayTime.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox gbxDayTime;
        protected RemoteClient.ControlTimeFrame ctfDayTime;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel panel2;
    }
}