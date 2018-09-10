namespace RegistrarServices
{
    partial class TempNavigator
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
            this.btnSchoolYear = new System.Windows.Forms.Button();
            this.btnClassroom = new System.Windows.Forms.Button();
            this.btnSpecial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSchoolYear
            // 
            this.btnSchoolYear.Location = new System.Drawing.Point(11, 21);
            this.btnSchoolYear.Name = "btnSchoolYear";
            this.btnSchoolYear.Size = new System.Drawing.Size(269, 35);
            this.btnSchoolYear.TabIndex = 0;
            this.btnSchoolYear.Text = "School Year / Semester Manager";
            this.btnSchoolYear.UseVisualStyleBackColor = true;
            // 
            // btnClassroom
            // 
            this.btnClassroom.Location = new System.Drawing.Point(12, 62);
            this.btnClassroom.Name = "btnClassroom";
            this.btnClassroom.Size = new System.Drawing.Size(269, 35);
            this.btnClassroom.TabIndex = 1;
            this.btnClassroom.Text = "Course Manager";
            this.btnClassroom.UseVisualStyleBackColor = true;
            // 
            // btnSpecial
            // 
            this.btnSpecial.Location = new System.Drawing.Point(12, 103);
            this.btnSpecial.Name = "btnSpecial";
            this.btnSpecial.Size = new System.Drawing.Size(269, 35);
            this.btnSpecial.TabIndex = 2;
            this.btnSpecial.Text = "Special Class Manager";
            this.btnSpecial.UseVisualStyleBackColor = true;
            // 
            // TempNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 156);
            this.Controls.Add(this.btnSpecial);
            this.Controls.Add(this.btnClassroom);
            this.Controls.Add(this.btnSchoolYear);
            this.Name = "TempNavigator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TempNavigator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSchoolYear;
        private System.Windows.Forms.Button btnClassroom;
        private System.Windows.Forms.Button btnSpecial;
    }
}