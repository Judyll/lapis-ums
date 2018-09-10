using System;
using System.Collections.Generic;
using System.Text;

namespace BaseServices.Controls
{
    public partial class ControlMemberManager : BaseServices.Control.ControlManager
    {
        protected System.Windows.Forms.GroupBox gbxOfficeEmployer;
        protected System.Windows.Forms.LinkLabel lnkOfficeEmployer;
        protected System.Windows.Forms.Label lblOfficeCount;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.GroupBox gbxMemberStatus;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.LinkLabel lnkMemberTypeSelectNone;
        protected System.Windows.Forms.Label lblMemberTypeCount;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.CheckedListBox cbxMemberType;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.LinkLabel lnkMemberClassificationSelectNone;
        protected System.Windows.Forms.Label lblMemberClassificationCount;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.CheckedListBox cbxMemberClassification;
        protected System.Windows.Forms.CheckBox chkIncludeMemberStatus;
        protected System.Windows.Forms.RadioButton rdbInActive;
        protected System.Windows.Forms.RadioButton rdbActive;
        protected System.Windows.Forms.CheckedListBox cbxOfficeEmployer;

        private void InitializeComponent()
        {
            this.gbxOfficeEmployer = new System.Windows.Forms.GroupBox();
            this.lnkOfficeEmployer = new System.Windows.Forms.LinkLabel();
            this.lblOfficeCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxOfficeEmployer = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkMemberClassificationSelectNone = new System.Windows.Forms.LinkLabel();
            this.lblMemberClassificationCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxMemberClassification = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnkMemberTypeSelectNone = new System.Windows.Forms.LinkLabel();
            this.lblMemberTypeCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxMemberType = new System.Windows.Forms.CheckedListBox();
            this.gbxMemberStatus = new System.Windows.Forms.GroupBox();
            this.rdbInActive = new System.Windows.Forms.RadioButton();
            this.rdbActive = new System.Windows.Forms.RadioButton();
            this.chkIncludeMemberStatus = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.gbxOfficeEmployer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxMemberStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpMain
            // 
            this.ttpMain.AutoPopDelay = 3000;
            this.ttpMain.InitialDelay = 500;
            this.ttpMain.IsBalloon = true;
            this.ttpMain.ReshowDelay = 100;
            this.ttpMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpMain.ToolTipTitle = "Console";
            // 
            // pbxClose
            // 
            this.ttpMain.SetToolTip(this.pbxClose, "Done");
            // 
            // pbxRefresh
            // 
            this.ttpMain.SetToolTip(this.pbxRefresh, "Refresh");
            // 
            // txtSearch
            // 
            this.txtSearch.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.chkIncludeMemberStatus);
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.gbxOfficeEmployer);
            this.pnlMain.Controls.Add(this.gbxMemberStatus);
            this.pnlMain.Size = new System.Drawing.Size(255, 557);
            this.pnlMain.Controls.SetChildIndex(this.gbxMemberStatus, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtSearch, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxClose, 0);
            this.pnlMain.Controls.SetChildIndex(this.gbxOfficeEmployer, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxFind, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnlMain.Controls.SetChildIndex(this.chkIncludeMemberStatus, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox2, 0);
            this.pnlMain.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // gbxOfficeEmployer
            // 
            this.gbxOfficeEmployer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbxOfficeEmployer.Controls.Add(this.lnkOfficeEmployer);
            this.gbxOfficeEmployer.Controls.Add(this.lblOfficeCount);
            this.gbxOfficeEmployer.Controls.Add(this.label1);
            this.gbxOfficeEmployer.Controls.Add(this.cbxOfficeEmployer);
            this.gbxOfficeEmployer.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxOfficeEmployer.Location = new System.Drawing.Point(8, 122);
            this.gbxOfficeEmployer.Name = "gbxOfficeEmployer";
            this.gbxOfficeEmployer.Size = new System.Drawing.Size(238, 128);
            this.gbxOfficeEmployer.TabIndex = 1;
            this.gbxOfficeEmployer.TabStop = false;
            this.gbxOfficeEmployer.Text = "Query by Office/Employer";
            // 
            // lnkOfficeEmployer
            // 
            this.lnkOfficeEmployer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkOfficeEmployer.AutoSize = true;
            this.lnkOfficeEmployer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOfficeEmployer.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkOfficeEmployer.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkOfficeEmployer.Location = new System.Drawing.Point(152, 103);
            this.lnkOfficeEmployer.Name = "lnkOfficeEmployer";
            this.lnkOfficeEmployer.Size = new System.Drawing.Size(84, 14);
            this.lnkOfficeEmployer.TabIndex = 2;
            this.lnkOfficeEmployer.TabStop = true;
            this.lnkOfficeEmployer.Text = "| Select None |";
            // 
            // lblOfficeCount
            // 
            this.lblOfficeCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblOfficeCount.AutoSize = true;
            this.lblOfficeCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfficeCount.ForeColor = System.Drawing.Color.Red;
            this.lblOfficeCount.Location = new System.Drawing.Point(62, 100);
            this.lblOfficeCount.Name = "lblOfficeCount";
            this.lblOfficeCount.Size = new System.Drawing.Size(18, 19);
            this.lblOfficeCount.TabIndex = 1;
            this.lblOfficeCount.Text = "0";
            this.lblOfficeCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(6, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selected:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxOfficeEmployer
            // 
            this.cbxOfficeEmployer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbxOfficeEmployer.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxOfficeEmployer.CheckOnClick = true;
            this.cbxOfficeEmployer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOfficeEmployer.FormattingEnabled = true;
            this.cbxOfficeEmployer.HorizontalScrollbar = true;
            this.cbxOfficeEmployer.Location = new System.Drawing.Point(6, 17);
            this.cbxOfficeEmployer.Name = "cbxOfficeEmployer";
            this.cbxOfficeEmployer.Size = new System.Drawing.Size(226, 76);
            this.cbxOfficeEmployer.TabIndex = 0;
            this.cbxOfficeEmployer.ThreeDCheckBoxes = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.lnkMemberClassificationSelectNone);
            this.groupBox1.Controls.Add(this.lblMemberClassificationCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxMemberClassification);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 128);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Query by Member Classification";
            // 
            // lnkMemberClassificationSelectNone
            // 
            this.lnkMemberClassificationSelectNone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkMemberClassificationSelectNone.AutoSize = true;
            this.lnkMemberClassificationSelectNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkMemberClassificationSelectNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkMemberClassificationSelectNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkMemberClassificationSelectNone.Location = new System.Drawing.Point(152, 103);
            this.lnkMemberClassificationSelectNone.Name = "lnkMemberClassificationSelectNone";
            this.lnkMemberClassificationSelectNone.Size = new System.Drawing.Size(84, 14);
            this.lnkMemberClassificationSelectNone.TabIndex = 2;
            this.lnkMemberClassificationSelectNone.TabStop = true;
            this.lnkMemberClassificationSelectNone.Text = "| Select None |";
            // 
            // lblMemberClassificationCount
            // 
            this.lblMemberClassificationCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMemberClassificationCount.AutoSize = true;
            this.lblMemberClassificationCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberClassificationCount.ForeColor = System.Drawing.Color.Red;
            this.lblMemberClassificationCount.Location = new System.Drawing.Point(62, 100);
            this.lblMemberClassificationCount.Name = "lblMemberClassificationCount";
            this.lblMemberClassificationCount.Size = new System.Drawing.Size(18, 19);
            this.lblMemberClassificationCount.TabIndex = 1;
            this.lblMemberClassificationCount.Text = "0";
            this.lblMemberClassificationCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Selected:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxMemberClassification
            // 
            this.cbxMemberClassification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbxMemberClassification.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxMemberClassification.CheckOnClick = true;
            this.cbxMemberClassification.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMemberClassification.FormattingEnabled = true;
            this.cbxMemberClassification.HorizontalScrollbar = true;
            this.cbxMemberClassification.Location = new System.Drawing.Point(6, 17);
            this.cbxMemberClassification.Name = "cbxMemberClassification";
            this.cbxMemberClassification.Size = new System.Drawing.Size(226, 76);
            this.cbxMemberClassification.TabIndex = 0;
            this.cbxMemberClassification.ThreeDCheckBoxes = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.lnkMemberTypeSelectNone);
            this.groupBox2.Controls.Add(this.lblMemberTypeCount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbxMemberType);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 390);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 95);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query by Member Type";
            // 
            // lnkMemberTypeSelectNone
            // 
            this.lnkMemberTypeSelectNone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkMemberTypeSelectNone.AutoSize = true;
            this.lnkMemberTypeSelectNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkMemberTypeSelectNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkMemberTypeSelectNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkMemberTypeSelectNone.Location = new System.Drawing.Point(152, 68);
            this.lnkMemberTypeSelectNone.Name = "lnkMemberTypeSelectNone";
            this.lnkMemberTypeSelectNone.Size = new System.Drawing.Size(84, 14);
            this.lnkMemberTypeSelectNone.TabIndex = 2;
            this.lnkMemberTypeSelectNone.TabStop = true;
            this.lnkMemberTypeSelectNone.Text = "| Select None |";
            // 
            // lblMemberTypeCount
            // 
            this.lblMemberTypeCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMemberTypeCount.AutoSize = true;
            this.lblMemberTypeCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberTypeCount.ForeColor = System.Drawing.Color.Red;
            this.lblMemberTypeCount.Location = new System.Drawing.Point(62, 65);
            this.lblMemberTypeCount.Name = "lblMemberTypeCount";
            this.lblMemberTypeCount.Size = new System.Drawing.Size(18, 19);
            this.lblMemberTypeCount.TabIndex = 1;
            this.lblMemberTypeCount.Text = "0";
            this.lblMemberTypeCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "Selected:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxMemberType
            // 
            this.cbxMemberType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbxMemberType.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxMemberType.CheckOnClick = true;
            this.cbxMemberType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMemberType.FormattingEnabled = true;
            this.cbxMemberType.HorizontalScrollbar = true;
            this.cbxMemberType.Location = new System.Drawing.Point(6, 17);
            this.cbxMemberType.Name = "cbxMemberType";
            this.cbxMemberType.Size = new System.Drawing.Size(226, 40);
            this.cbxMemberType.TabIndex = 0;
            this.cbxMemberType.ThreeDCheckBoxes = true;
            // 
            // gbxMemberStatus
            // 
            this.gbxMemberStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbxMemberStatus.Controls.Add(this.rdbInActive);
            this.gbxMemberStatus.Controls.Add(this.rdbActive);
            this.gbxMemberStatus.Enabled = false;
            this.gbxMemberStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxMemberStatus.Location = new System.Drawing.Point(6, 492);
            this.gbxMemberStatus.Name = "gbxMemberStatus";
            this.gbxMemberStatus.Size = new System.Drawing.Size(238, 52);
            this.gbxMemberStatus.TabIndex = 19;
            this.gbxMemberStatus.TabStop = false;
            this.gbxMemberStatus.Text = "      ";
            // 
            // rdbInActive
            // 
            this.rdbInActive.AutoSize = true;
            this.rdbInActive.Location = new System.Drawing.Point(127, 24);
            this.rdbInActive.Name = "rdbInActive";
            this.rdbInActive.Size = new System.Drawing.Size(63, 17);
            this.rdbInActive.TabIndex = 1;
            this.rdbInActive.TabStop = true;
            this.rdbInActive.Text = "Inactive";
            this.rdbInActive.UseVisualStyleBackColor = true;
            // 
            // rdbActive
            // 
            this.rdbActive.AutoSize = true;
            this.rdbActive.Location = new System.Drawing.Point(46, 24);
            this.rdbActive.Name = "rdbActive";
            this.rdbActive.Size = new System.Drawing.Size(54, 17);
            this.rdbActive.TabIndex = 0;
            this.rdbActive.TabStop = true;
            this.rdbActive.Text = "Active";
            this.rdbActive.UseVisualStyleBackColor = true;
            // 
            // chkIncludeMemberStatus
            // 
            this.chkIncludeMemberStatus.AutoSize = true;
            this.chkIncludeMemberStatus.ForeColor = System.Drawing.Color.Sienna;
            this.chkIncludeMemberStatus.Location = new System.Drawing.Point(15, 492);
            this.chkIncludeMemberStatus.Name = "chkIncludeMemberStatus";
            this.chkIncludeMemberStatus.Size = new System.Drawing.Size(138, 17);
            this.chkIncludeMemberStatus.TabIndex = 4;
            this.chkIncludeMemberStatus.Text = " Include Member Status";
            this.chkIncludeMemberStatus.UseVisualStyleBackColor = true;
            // 
            // ControlMemberManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlMemberManager";
            this.Size = new System.Drawing.Size(255, 557);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.gbxOfficeEmployer.ResumeLayout(false);
            this.gbxOfficeEmployer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxMemberStatus.ResumeLayout(false);
            this.gbxMemberStatus.PerformLayout();
            this.ResumeLayout(false);

        }

    }
}
