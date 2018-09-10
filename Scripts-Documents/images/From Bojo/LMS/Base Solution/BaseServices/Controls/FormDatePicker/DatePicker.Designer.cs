namespace BaseServices.Control
{
    partial class DatePicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatePicker));
            this.cboDay = new System.Windows.Forms.ComboBox();
            this.calMain = new System.Windows.Forms.MonthCalendar();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.btnUseDate = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboDay
            // 
            this.cboDay.BackColor = System.Drawing.Color.GhostWhite;
            this.cboDay.FormattingEnabled = true;
            this.cboDay.Location = new System.Drawing.Point(114, 5);
            this.cboDay.MaxLength = 2;
            this.cboDay.Name = "cboDay";
            this.cboDay.Size = new System.Drawing.Size(54, 21);
            this.cboDay.TabIndex = 8;
            // 
            // calMain
            // 
            this.calMain.BackColor = System.Drawing.Color.GhostWhite;
            this.calMain.Location = new System.Drawing.Point(9, 13);
            this.calMain.MaxSelectionCount = 1;
            this.calMain.Name = "calMain";
            this.calMain.ShowWeekNumbers = true;
            this.calMain.TabIndex = 4;
            this.calMain.TitleBackColor = System.Drawing.Color.SeaGreen;
            this.calMain.TitleForeColor = System.Drawing.Color.GhostWhite;
            // 
            // cboYear
            // 
            this.cboYear.BackColor = System.Drawing.Color.GhostWhite;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(171, 5);
            this.cboYear.MaxLength = 5;
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(60, 21);
            this.cboYear.TabIndex = 9;
            // 
            // btnUseDate
            // 
            this.btnUseDate.Image = ((System.Drawing.Image)(resources.GetObject("btnUseDate.Image")));
            this.btnUseDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUseDate.Location = new System.Drawing.Point(124, 216);
            this.btnUseDate.Name = "btnUseDate";
            this.btnUseDate.Size = new System.Drawing.Size(107, 25);
            this.btnUseDate.TabIndex = 10;
            this.btnUseDate.Text = "Use Date";
            this.btnUseDate.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel2.Controls.Add(this.calMain);
            this.Panel2.Location = new System.Drawing.Point(7, 35);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(224, 178);
            this.Panel2.TabIndex = 6;
            // 
            // cboMonth
            // 
            this.cboMonth.BackColor = System.Drawing.Color.GhostWhite;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(7, 5);
            this.cboMonth.MaxLength = 12;
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(104, 21);
            this.cboMonth.TabIndex = 7;
            // 
            // CFBDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 248);
            this.Controls.Add(this.cboDay);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.btnUseDate);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.cboMonth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CFBDatePicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Date Picker";
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboDay;
        internal System.Windows.Forms.MonthCalendar calMain;
        internal System.Windows.Forms.ComboBox cboYear;
        internal System.Windows.Forms.Button btnUseDate;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ComboBox cboMonth;
    }
}