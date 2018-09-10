using System;
using System.Collections.Generic;
using System.Text;

namespace MemberServices
{
    internal partial class MemberInformation : BaseServices.PersonInformationWithBeneficiaryReference
    {
        protected System.Windows.Forms.Label label22;
        protected System.Windows.Forms.Label lblSalaryIncome;
        protected System.Windows.Forms.Label label20;
        protected System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tblMemberInformation;
        protected System.Windows.Forms.ComboBox cboMemberClassification;
        protected System.Windows.Forms.Label label29;
        protected System.Windows.Forms.LinkLabel lnkMembershipDate;
        protected System.Windows.Forms.TextBox txtMembershipDate;
        protected System.Windows.Forms.Label label26;
        protected System.Windows.Forms.Label label27;
        protected System.Windows.Forms.TextBox txtReasonOfMembership;
        protected System.Windows.Forms.Label label34;
        protected System.Windows.Forms.Label label32;
        protected System.Windows.Forms.TextBox txtOtherMemberInformation;
        protected System.Windows.Forms.TextBox txtOtherCooperativeMembership;
        protected System.Windows.Forms.TextBox txtCertificationInformation;
        protected System.Windows.Forms.Label lblMemberStatus;
        private System.Windows.Forms.Label lblMemberInfo;
        protected System.Windows.Forms.Label label28;
        public System.Windows.Forms.Label label37;
        protected System.Windows.Forms.PictureBox pbxMemberInformation;
        protected System.Windows.Forms.ComboBox cboMemberType;
        protected System.Windows.Forms.Label label40;
        protected System.Windows.Forms.Label label41;
        protected System.Windows.Forms.TextBox txtMemberId;
        protected System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSalaryIncome = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tblMemberInformation = new System.Windows.Forms.TabPage();
            this.label41 = new System.Windows.Forms.Label();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.cboMemberType = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblMemberInfo = new System.Windows.Forms.Label();
            this.txtOtherMemberInformation = new System.Windows.Forms.TextBox();
            this.txtOtherCooperativeMembership = new System.Windows.Forms.TextBox();
            this.txtCertificationInformation = new System.Windows.Forms.TextBox();
            this.lblMemberStatus = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.cboMemberClassification = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.lnkMembershipDate = new System.Windows.Forms.LinkLabel();
            this.txtMembershipDate = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtReasonOfMembership = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.pbxMemberInformation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReferences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBeneficiaries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPersonalDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errProvider)).BeginInit();
            this.tblPerson.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGeneralInformation)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPersonImage)).BeginInit();
            this.tabCntPerson.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tblMemberInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMemberInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label37);
            this.panel2.Controls.Add(this.pbxMemberInformation);
            this.panel2.Controls.SetChildIndex(this.pbxGeneralInformation, 0);
            this.panel2.Controls.SetChildIndex(this.pbxBeneficiaries, 0);
            this.panel2.Controls.SetChildIndex(this.pbxReferences, 0);
            this.panel2.Controls.SetChildIndex(this.pbxPersonalDocument, 0);
            this.panel2.Controls.SetChildIndex(this.label23, 0);
            this.panel2.Controls.SetChildIndex(this.pbxMemberInformation, 0);
            this.panel2.Controls.SetChildIndex(this.label37, 0);
            // 
            // tabCntPerson
            // 
            this.tabCntPerson.Controls.Add(this.tblMemberInformation);
            this.tabCntPerson.Controls.SetChildIndex(this.tblMemberInformation, 0);
            this.tabCntPerson.Controls.SetChildIndex(this.tblPerson, 0);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(82, 52);
            this.label19.Size = new System.Drawing.Size(43, 15);
            this.label19.TabIndex = 38;
            this.label19.Text = "Office:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lblSalaryIncome);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(6, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(732, 364);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " EMPLOYMENT INFORMATION ";
            this.groupBox2.Controls.SetChildIndex(this.lblSalaryIncome, 0);
            this.groupBox2.Controls.SetChildIndex(this.label19, 0);
            this.groupBox2.Controls.SetChildIndex(this.lblStatus, 0);
            this.groupBox2.Controls.SetChildIndex(this.textBox1, 0);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(130, 50);
            this.textBox1.MaxLength = 500;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(246, 22);
            this.textBox1.TabIndex = 44;
            // 
            // lblStatus
            // 
            this.lblStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(382, 52);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(344, 23);
            this.lblStatus.TabIndex = 43;
            this.lblStatus.Text = "ACTIVE";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalaryIncome
            // 
            this.lblSalaryIncome.AutoSize = true;
            this.lblSalaryIncome.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalaryIncome.ForeColor = System.Drawing.Color.Black;
            this.lblSalaryIncome.Location = new System.Drawing.Point(30, 108);
            this.lblSalaryIncome.Name = "lblSalaryIncome";
            this.lblSalaryIncome.Size = new System.Drawing.Size(95, 15);
            this.lblSalaryIncome.TabIndex = 35;
            this.lblSalaryIncome.Text = "Salary / Income:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(3, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 15);
            this.label22.TabIndex = 39;
            this.label22.Text = "Appointment Status:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(53, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 15);
            this.label20.TabIndex = 32;
            this.label20.Text = "Occupation:";
            // 
            // tblMemberInformation
            // 
            this.tblMemberInformation.BackColor = System.Drawing.Color.GhostWhite;
            this.tblMemberInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tblMemberInformation.Controls.Add(this.label41);
            this.tblMemberInformation.Controls.Add(this.txtMemberId);
            this.tblMemberInformation.Controls.Add(this.cboMemberType);
            this.tblMemberInformation.Controls.Add(this.label40);
            this.tblMemberInformation.Controls.Add(this.label28);
            this.tblMemberInformation.Controls.Add(this.lblMemberInfo);
            this.tblMemberInformation.Controls.Add(this.txtOtherMemberInformation);
            this.tblMemberInformation.Controls.Add(this.txtOtherCooperativeMembership);
            this.tblMemberInformation.Controls.Add(this.txtCertificationInformation);
            this.tblMemberInformation.Controls.Add(this.lblMemberStatus);
            this.tblMemberInformation.Controls.Add(this.label34);
            this.tblMemberInformation.Controls.Add(this.label32);
            this.tblMemberInformation.Controls.Add(this.cboMemberClassification);
            this.tblMemberInformation.Controls.Add(this.label29);
            this.tblMemberInformation.Controls.Add(this.lnkMembershipDate);
            this.tblMemberInformation.Controls.Add(this.txtMembershipDate);
            this.tblMemberInformation.Controls.Add(this.label26);
            this.tblMemberInformation.Controls.Add(this.label27);
            this.tblMemberInformation.Controls.Add(this.txtReasonOfMembership);
            this.tblMemberInformation.Location = new System.Drawing.Point(4, 22);
            this.tblMemberInformation.Name = "tblMemberInformation";
            this.tblMemberInformation.Size = new System.Drawing.Size(812, 581);
            this.tblMemberInformation.TabIndex = 4;
            this.tblMemberInformation.Text = "Member Information";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(125, 33);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(95, 15);
            this.label41.TabIndex = 92;
            this.label41.Text = "Membership ID:";
            // 
            // txtMemberId
            // 
            this.txtMemberId.BackColor = System.Drawing.Color.White;
            this.txtMemberId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberId.Location = new System.Drawing.Point(240, 31);
            this.txtMemberId.MaxLength = 50;
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(353, 23);
            this.txtMemberId.TabIndex = 0;
            // 
            // cboMemberType
            // 
            this.cboMemberType.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboMemberType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMemberType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMemberType.FormattingEnabled = true;
            this.cboMemberType.Location = new System.Drawing.Point(240, 117);
            this.cboMemberType.Name = "cboMemberType";
            this.cboMemberType.Size = new System.Drawing.Size(353, 22);
            this.cboMemberType.TabIndex = 4;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(183, 118);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(37, 15);
            this.label40.TabIndex = 90;
            this.label40.Text = "Type:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(110, 61);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(110, 15);
            this.label28.TabIndex = 88;
            this.label28.Text = "Membership Date:";
            // 
            // lblMemberInfo
            // 
            this.lblMemberInfo.AutoSize = true;
            this.lblMemberInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberInfo.ForeColor = System.Drawing.Color.Orange;
            this.lblMemberInfo.Location = new System.Drawing.Point(637, 6);
            this.lblMemberInfo.Name = "lblMemberInfo";
            this.lblMemberInfo.Size = new System.Drawing.Size(170, 20);
            this.lblMemberInfo.TabIndex = 87;
            this.lblMemberInfo.Text = "Member Information";
            // 
            // txtOtherMemberInformation
            // 
            this.txtOtherMemberInformation.BackColor = System.Drawing.Color.White;
            this.txtOtherMemberInformation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherMemberInformation.Location = new System.Drawing.Point(240, 448);
            this.txtOtherMemberInformation.MaxLength = 500;
            this.txtOtherMemberInformation.Multiline = true;
            this.txtOtherMemberInformation.Name = "txtOtherMemberInformation";
            this.txtOtherMemberInformation.Size = new System.Drawing.Size(353, 95);
            this.txtOtherMemberInformation.TabIndex = 8;
            // 
            // txtOtherCooperativeMembership
            // 
            this.txtOtherCooperativeMembership.BackColor = System.Drawing.Color.White;
            this.txtOtherCooperativeMembership.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherCooperativeMembership.Location = new System.Drawing.Point(240, 347);
            this.txtOtherCooperativeMembership.MaxLength = 500;
            this.txtOtherCooperativeMembership.Multiline = true;
            this.txtOtherCooperativeMembership.Name = "txtOtherCooperativeMembership";
            this.txtOtherCooperativeMembership.Size = new System.Drawing.Size(353, 95);
            this.txtOtherCooperativeMembership.TabIndex = 7;
            // 
            // txtCertificationInformation
            // 
            this.txtCertificationInformation.BackColor = System.Drawing.Color.White;
            this.txtCertificationInformation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCertificationInformation.Location = new System.Drawing.Point(240, 246);
            this.txtCertificationInformation.MaxLength = 500;
            this.txtCertificationInformation.Multiline = true;
            this.txtCertificationInformation.Name = "txtCertificationInformation";
            this.txtCertificationInformation.Size = new System.Drawing.Size(353, 95);
            this.txtCertificationInformation.TabIndex = 6;
            // 
            // lblMemberStatus
            // 
            this.lblMemberStatus.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblMemberStatus.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberStatus.ForeColor = System.Drawing.Color.Green;
            this.lblMemberStatus.Location = new System.Drawing.Point(240, 544);
            this.lblMemberStatus.Name = "lblMemberStatus";
            this.lblMemberStatus.Size = new System.Drawing.Size(353, 38);
            this.lblMemberStatus.TabIndex = 9;
            this.lblMemberStatus.Text = "ACTIVE";
            this.lblMemberStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(57, 449);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(163, 15);
            this.label34.TabIndex = 82;
            this.label34.Text = "Other Member Information:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(74, 247);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(146, 15);
            this.label32.TabIndex = 81;
            this.label32.Text = "Certification Information:";
            // 
            // cboMemberClassification
            // 
            this.cboMemberClassification.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboMemberClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMemberClassification.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMemberClassification.FormattingEnabled = true;
            this.cboMemberClassification.Location = new System.Drawing.Point(240, 89);
            this.cboMemberClassification.Name = "cboMemberClassification";
            this.cboMemberClassification.Size = new System.Drawing.Size(353, 22);
            this.cboMemberClassification.TabIndex = 3;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(140, 90);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(80, 15);
            this.label29.TabIndex = 80;
            this.label29.Text = "Classification:";
            // 
            // lnkMembershipDate
            // 
            this.lnkMembershipDate.AutoSize = true;
            this.lnkMembershipDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkMembershipDate.ForeColor = System.Drawing.Color.Navy;
            this.lnkMembershipDate.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkMembershipDate.LinkColor = System.Drawing.Color.Blue;
            this.lnkMembershipDate.Location = new System.Drawing.Point(547, 62);
            this.lnkMembershipDate.Name = "lnkMembershipDate";
            this.lnkMembershipDate.Size = new System.Drawing.Size(46, 15);
            this.lnkMembershipDate.TabIndex = 2;
            this.lnkMembershipDate.TabStop = true;
            this.lnkMembershipDate.Text = "change";
            // 
            // txtMembershipDate
            // 
            this.txtMembershipDate.BackColor = System.Drawing.Color.White;
            this.txtMembershipDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMembershipDate.Location = new System.Drawing.Point(240, 60);
            this.txtMembershipDate.MaxLength = 500;
            this.txtMembershipDate.Name = "txtMembershipDate";
            this.txtMembershipDate.Size = new System.Drawing.Size(301, 22);
            this.txtMembershipDate.TabIndex = 1;
            this.txtMembershipDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(33, 348);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(187, 15);
            this.label26.TabIndex = 77;
            this.label26.Text = "Other Cooperative Membership:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(83, 146);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(137, 15);
            this.label27.TabIndex = 73;
            this.label27.Text = "Reason of Membership:";
            // 
            // txtReasonOfMembership
            // 
            this.txtReasonOfMembership.BackColor = System.Drawing.Color.White;
            this.txtReasonOfMembership.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReasonOfMembership.Location = new System.Drawing.Point(240, 145);
            this.txtReasonOfMembership.MaxLength = 500;
            this.txtReasonOfMembership.Multiline = true;
            this.txtReasonOfMembership.Name = "txtReasonOfMembership";
            this.txtReasonOfMembership.Size = new System.Drawing.Size(353, 95);
            this.txtReasonOfMembership.TabIndex = 5;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(42, 121);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 13);
            this.label37.TabIndex = 9;
            this.label37.Text = "Member Information";
            // 
            // pbxMemberInformation
            // 
            this.pbxMemberInformation.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.pbxMemberInformation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxMemberInformation.Location = new System.Drawing.Point(0, 115);
            this.pbxMemberInformation.Name = "pbxMemberInformation";
            this.pbxMemberInformation.Size = new System.Drawing.Size(161, 25);
            this.pbxMemberInformation.TabIndex = 8;
            this.pbxMemberInformation.TabStop = false;
            // 
            // MemberInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(994, 712);
            this.Name = "MemberInformation";
            ((System.ComponentModel.ISupportInitialize)(this.pbxReferences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBeneficiaries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPersonalDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errProvider)).EndInit();
            this.tblPerson.ResumeLayout(false);
            this.tblPerson.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGeneralInformation)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPersonImage)).EndInit();
            this.tabCntPerson.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tblMemberInformation.ResumeLayout(false);
            this.tblMemberInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMemberInformation)).EndInit();
            this.ResumeLayout(false);

        }
        
    }
}
