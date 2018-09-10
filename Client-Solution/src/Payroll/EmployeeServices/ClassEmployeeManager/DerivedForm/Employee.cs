using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeServices
{
    internal partial class Employee : BaseServices.PersonInformationWithRelationship
    {
        private System.Windows.Forms.TabPage tabPersonalInformation;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox11;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.Label label31;
        public System.Windows.Forms.TextBox textBox6;
        public System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox10;
        public System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtPresentPhone;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.TextBox txtPresentAddress;
        public System.Windows.Forms.Label label24;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label27;
        public System.Windows.Forms.Label label28;
        public System.Windows.Forms.LinkLabel lnkChangeDate;
        public System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.Label label29;
        public System.Windows.Forms.TextBox textBox9;
        public System.Windows.Forms.TextBox textBox10;
        public System.Windows.Forms.Label label33;
        public System.Windows.Forms.TextBox textBox11;
        public System.Windows.Forms.Label label34;
        private System.Windows.Forms.TabPage tabEmployment;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        public System.Windows.Forms.Label label44;
        public System.Windows.Forms.Label label45;
        public System.Windows.Forms.Label label46;
        public System.Windows.Forms.TextBox textBox12;
        public System.Windows.Forms.Label lblEcode;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label label47;
        public System.Windows.Forms.Label label48;
        public System.Windows.Forms.Label label49;
        public System.Windows.Forms.Label label50;
        public System.Windows.Forms.GroupBox groupBox12;
        public System.Windows.Forms.Label label51;
        private System.Windows.Forms.TabPage tblEmployment;
        private System.Windows.Forms.Label lblEmp;
        public System.Windows.Forms.GroupBox gbxDailyTime;
        protected System.Windows.Forms.GroupBox gbxRestDay;
        public System.Windows.Forms.ComboBox cboRestDay;
        protected System.Windows.Forms.GroupBox gbxSecondPart;
        public RemoteClient.TimeInput tmeSecondOut;
        private System.Windows.Forms.Label label74;
        public RemoteClient.TimeInput tmeSecondIn;
        private System.Windows.Forms.Label label75;
        protected System.Windows.Forms.GroupBox gbxFirstPart;
        public RemoteClient.TimeInput tmeFirstOut;
        public RemoteClient.TimeInput tmeFirstIn;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        public System.Windows.Forms.GroupBox gbxType;
        public System.Windows.Forms.ComboBox cboDepartment;
        public System.Windows.Forms.Label label78;
        public System.Windows.Forms.Label label79;
        public System.Windows.Forms.ComboBox cboStatus;
        public System.Windows.Forms.Label label80;
        public System.Windows.Forms.ComboBox cboType;
        public System.Windows.Forms.GroupBox gbxJobInfo;
        public System.Windows.Forms.Label label82;
        public System.Windows.Forms.TextBox txtPagibigId;
        public System.Windows.Forms.Label label83;
        public System.Windows.Forms.TextBox txtSssId;
        public System.Windows.Forms.Label label85;
        public System.Windows.Forms.TextBox txtPhilHealthId;
        public System.Windows.Forms.ComboBox cboPoints;
        public System.Windows.Forms.ComboBox cboDegree;
        public System.Windows.Forms.ComboBox cboCategory;
        public System.Windows.Forms.ComboBox cboLevel;
        public System.Windows.Forms.Label label87;
        public System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label label52;
        public System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label label53;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox15;
        public RemoteClient.TimeInput timeInput1;
        private System.Windows.Forms.Label label54;
        public RemoteClient.TimeInput timeInput2;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.GroupBox groupBox16;
        public RemoteClient.TimeInput timeInput3;
        public RemoteClient.TimeInput timeInput4;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        public System.Windows.Forms.GroupBox groupBox17;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.Label label58;
        public System.Windows.Forms.Label label59;
        public System.Windows.Forms.ComboBox comboBox3;
        public System.Windows.Forms.Label label60;
        public System.Windows.Forms.ComboBox comboBox4;
        public System.Windows.Forms.GroupBox groupBox18;
        public System.Windows.Forms.TextBox textBox13;
        public System.Windows.Forms.Label label61;
        public System.Windows.Forms.GroupBox groupBox19;
        public System.Windows.Forms.Label label62;
        public System.Windows.Forms.TextBox textBox14;
        public System.Windows.Forms.TextBox textBox15;
        public System.Windows.Forms.Label label63;
        public System.Windows.Forms.TextBox textBox16;
        public System.Windows.Forms.Label label64;
        public System.Windows.Forms.Label label65;
        public System.Windows.Forms.TextBox textBox17;
        public System.Windows.Forms.GroupBox groupBox20;
        public System.Windows.Forms.ComboBox comboBox5;
        public System.Windows.Forms.Label label66;
        public System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.ComboBox comboBox6;
        public System.Windows.Forms.ComboBox comboBox7;
        public System.Windows.Forms.ComboBox comboBox8;
        public System.Windows.Forms.Label label67;
        public System.Windows.Forms.TextBox textBox18;
        public System.Windows.Forms.Label label68;
        public System.Windows.Forms.Label label69;
        public System.Windows.Forms.Label label70;
        public System.Windows.Forms.Label label71;
        public System.Windows.Forms.TextBox textBox19;
        public System.Windows.Forms.Label lblAlert;
        protected System.Windows.Forms.CheckBox chkFixedTime;
        public System.Windows.Forms.TextBox txtBasicRate;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblLevelPoints;
        private System.Windows.Forms.Label lblEmpIdLabel;
        private System.Windows.Forms.TabControl tabEmpRate;
        private System.Windows.Forms.TabPage tblRankBaseRate;
        private System.Windows.Forms.TabPage tnlOtherInformation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label73;
        public System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.Label label89;
        public System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label91;
        public System.Windows.Forms.ComboBox comboBox10;
        public System.Windows.Forms.TextBox textBox20;
        public System.Windows.Forms.ComboBox comboBox11;
        public System.Windows.Forms.ComboBox comboBox12;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label97;
        public System.Windows.Forms.TextBox textBox21;
        public System.Windows.Forms.TextBox textBox22;
        public System.Windows.Forms.TextBox textBox23;
        public System.Windows.Forms.TextBox textBox24;
        public System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.TabPage tabPage5;
        protected System.Windows.Forms.TextBox textBox26;
        protected System.Windows.Forms.TextBox txtOtherInformationEmployee;

        private void InitializeComponent()
        {
            this.tabPersonalInformation = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPresentPhone = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPresentAddress = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lnkChangeDate = new System.Windows.Forms.LinkLabel();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tabEmployment = new System.Windows.Forms.TabPage();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.lblEcode = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label53 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.timeInput1 = new RemoteClient.TimeInput();
            this.label54 = new System.Windows.Forms.Label();
            this.timeInput2 = new RemoteClient.TimeInput();
            this.label55 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.timeInput3 = new RemoteClient.TimeInput();
            this.timeInput4 = new RemoteClient.TimeInput();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label60 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.label62 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label66 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label67 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.tblEmployment = new System.Windows.Forms.TabPage();
            this.lblEmp = new System.Windows.Forms.Label();
            this.gbxDailyTime = new System.Windows.Forms.GroupBox();
            this.chkFixedTime = new System.Windows.Forms.CheckBox();
            this.gbxRestDay = new System.Windows.Forms.GroupBox();
            this.cboRestDay = new System.Windows.Forms.ComboBox();
            this.gbxSecondPart = new System.Windows.Forms.GroupBox();
            this.tmeSecondOut = new RemoteClient.TimeInput();
            this.label74 = new System.Windows.Forms.Label();
            this.tmeSecondIn = new RemoteClient.TimeInput();
            this.label75 = new System.Windows.Forms.Label();
            this.gbxFirstPart = new System.Windows.Forms.GroupBox();
            this.tmeFirstOut = new RemoteClient.TimeInput();
            this.tmeFirstIn = new RemoteClient.TimeInput();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.gbxType = new System.Windows.Forms.GroupBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label80 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.gbxJobInfo = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label82 = new System.Windows.Forms.Label();
            this.txtEmployeeId = new System.Windows.Forms.TextBox();
            this.txtPagibigId = new System.Windows.Forms.TextBox();
            this.lblEmpIdLabel = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.txtPhilHealthId = new System.Windows.Forms.TextBox();
            this.txtSssId = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.tabEmpRate = new System.Windows.Forms.TabControl();
            this.tblRankBaseRate = new System.Windows.Forms.TabPage();
            this.lblLevelPoints = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.txtBasicRate = new System.Windows.Forms.TextBox();
            this.cboDegree = new System.Windows.Forms.ComboBox();
            this.cboPoints = new System.Windows.Forms.ComboBox();
            this.lblDegree = new System.Windows.Forms.Label();
            this.tnlOtherInformation = new System.Windows.Forms.TabPage();
            this.txtOtherInformationEmployee = new System.Windows.Forms.TextBox();
            this.lblAlert = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label73 = new System.Windows.Forms.Label();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.label92 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label93 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.tblRelationship.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerson)).BeginInit();
            this.TabCntPerson.SuspendLayout();
            this.tblPersonalDetails.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errProvider)).BeginInit();
            this.tabPersonalInformation.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabEmployment.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.tblEmployment.SuspendLayout();
            this.gbxDailyTime.SuspendLayout();
            this.gbxRestDay.SuspendLayout();
            this.gbxSecondPart.SuspendLayout();
            this.gbxFirstPart.SuspendLayout();
            this.gbxType.SuspendLayout();
            this.gbxJobInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabEmpRate.SuspendLayout();
            this.tblRankBaseRate.SuspendLayout();
            this.tnlOtherInformation.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblRelationship
            // 
            this.tblRelationship.Size = new System.Drawing.Size(744, 470);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblAlert);
            this.panel3.Location = new System.Drawing.Point(-1, 581);
            // 
            // tblPerson
            // 
            this.tblPerson.Size = new System.Drawing.Size(744, 470);
            // 
            // TabCntPerson
            // 
            this.TabCntPerson.Controls.Add(this.tblEmployment);
            this.TabCntPerson.Size = new System.Drawing.Size(752, 498);
            this.TabCntPerson.Controls.SetChildIndex(this.tblRelationship, 0);
            this.TabCntPerson.Controls.SetChildIndex(this.tblEmployment, 0);
            this.TabCntPerson.Controls.SetChildIndex(this.tblPerson, 0);
            // 
            // tabPersonalInformation
            // 
            this.tabPersonalInformation.Controls.Add(this.groupBox7);
            this.tabPersonalInformation.Controls.Add(this.groupBox2);
            this.tabPersonalInformation.Location = new System.Drawing.Point(4, 23);
            this.tabPersonalInformation.Name = "tabPersonalInformation";
            this.tabPersonalInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonalInformation.Size = new System.Drawing.Size(621, 466);
            this.tabPersonalInformation.TabIndex = 0;
            this.tabPersonalInformation.Text = "Personal";
            this.tabPersonalInformation.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox11);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.Navy;
            this.groupBox7.Location = new System.Drawing.Point(323, 53);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(292, 363);
            this.groupBox7.TabIndex = 47;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = " CONTACTS/OTHERS ";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.textBox1);
            this.groupBox11.Controls.Add(this.textBox2);
            this.groupBox11.Controls.Add(this.textBox3);
            this.groupBox11.Controls.Add(this.label19);
            this.groupBox11.Controls.Add(this.label22);
            this.groupBox11.Controls.Add(this.label20);
            this.groupBox11.Controls.Add(this.textBox4);
            this.groupBox11.Controls.Add(this.label18);
            this.groupBox11.Location = new System.Drawing.Point(6, 213);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(280, 136);
            this.groupBox11.TabIndex = 48;
            this.groupBox11.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(12, 73);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 23);
            this.textBox1.TabIndex = 34;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(12, 99);
            this.textBox2.MaxLength = 100;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(176, 23);
            this.textBox2.TabIndex = 36;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(12, 21);
            this.textBox3.MaxLength = 100;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(176, 23);
            this.textBox3.TabIndex = 30;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(196, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 15);
            this.label19.TabIndex = 33;
            this.label19.Text = "Citizenship";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label22.Location = new System.Drawing.Point(196, 102);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 15);
            this.label22.TabIndex = 37;
            this.label22.Text = "Religion";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(196, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 15);
            this.label20.TabIndex = 31;
            this.label20.Text = "Place of Birth";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(12, 47);
            this.textBox4.MaxLength = 100;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(176, 23);
            this.textBox4.TabIndex = 32;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label18.Location = new System.Drawing.Point(196, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 15);
            this.label18.TabIndex = 35;
            this.label18.Text = "Nationality";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox5);
            this.groupBox8.Controls.Add(this.label31);
            this.groupBox8.Controls.Add(this.textBox6);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.label30);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.label37);
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Controls.Add(this.textBox7);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.txtPresentPhone);
            this.groupBox8.Controls.Add(this.label23);
            this.groupBox8.Controls.Add(this.txtPresentAddress);
            this.groupBox8.Controls.Add(this.label24);
            this.groupBox8.Location = new System.Drawing.Point(6, 13);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(280, 194);
            this.groupBox8.TabIndex = 38;
            this.groupBox8.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(12, 159);
            this.textBox5.MaxLength = 100;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(176, 23);
            this.textBox5.TabIndex = 32;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label31.Location = new System.Drawing.Point(196, 162);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 15);
            this.label31.TabIndex = 33;
            this.label31.Text = "Phone No.";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(12, 133);
            this.textBox6.MaxLength = 500;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(176, 23);
            this.textBox6.TabIndex = 30;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label32.Location = new System.Drawing.Point(196, 138);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(51, 15);
            this.label32.TabIndex = 31;
            this.label32.Text = "Address";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.SteelBlue;
            this.label30.Location = new System.Drawing.Point(222, 115);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(40, 15);
            this.label30.TabIndex = 27;
            this.label30.Text = "Home";
            // 
            // groupBox9
            // 
            this.groupBox9.Location = new System.Drawing.Point(6, 122);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(250, 4);
            this.groupBox9.TabIndex = 26;
            this.groupBox9.TabStop = false;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.SteelBlue;
            this.label37.Location = new System.Drawing.Point(222, 45);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(50, 15);
            this.label37.TabIndex = 25;
            this.label37.Text = "Present";
            // 
            // groupBox10
            // 
            this.groupBox10.Location = new System.Drawing.Point(6, 48);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(250, 4);
            this.groupBox10.TabIndex = 24;
            this.groupBox10.TabStop = false;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.White;
            this.textBox7.Location = new System.Drawing.Point(12, 19);
            this.textBox7.MaxLength = 50;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(176, 23);
            this.textBox7.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(196, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 15);
            this.label16.TabIndex = 21;
            this.label16.Text = "Email";
            // 
            // txtPresentPhone
            // 
            this.txtPresentPhone.BackColor = System.Drawing.Color.White;
            this.txtPresentPhone.Location = new System.Drawing.Point(12, 89);
            this.txtPresentPhone.MaxLength = 100;
            this.txtPresentPhone.Name = "txtPresentPhone";
            this.txtPresentPhone.Size = new System.Drawing.Size(176, 23);
            this.txtPresentPhone.TabIndex = 24;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label23.Location = new System.Drawing.Point(196, 66);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 15);
            this.label23.TabIndex = 23;
            this.label23.Text = "Address";
            // 
            // txtPresentAddress
            // 
            this.txtPresentAddress.BackColor = System.Drawing.Color.White;
            this.txtPresentAddress.Location = new System.Drawing.Point(12, 63);
            this.txtPresentAddress.MaxLength = 500;
            this.txtPresentAddress.Name = "txtPresentAddress";
            this.txtPresentAddress.Size = new System.Drawing.Size(176, 23);
            this.txtPresentAddress.TabIndex = 22;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label24.Location = new System.Drawing.Point(196, 92);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 15);
            this.label24.TabIndex = 25;
            this.label24.Text = "Phone No.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(6, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 136);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " IN CASE OF EMERGENCY ";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label27.Location = new System.Drawing.Point(233, 52);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(51, 15);
            this.label27.TabIndex = 41;
            this.label27.Text = "Address";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label28.Location = new System.Drawing.Point(233, 78);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 15);
            this.label28.TabIndex = 43;
            this.label28.Text = "Phone No.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Orange;
            this.label12.Location = new System.Drawing.Point(445, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 20);
            this.label12.TabIndex = 48;
            this.label12.Text = "Personal Information";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label26.Location = new System.Drawing.Point(233, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 15);
            this.label26.TabIndex = 39;
            this.label26.Text = "Name";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label25.Location = new System.Drawing.Point(233, 104);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 15);
            this.label25.TabIndex = 45;
            this.label25.Text = "Relationship";
            // 
            // lnkChangeDate
            // 
            this.lnkChangeDate.AutoSize = true;
            this.lnkChangeDate.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lnkChangeDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkChangeDate.Location = new System.Drawing.Point(251, 106);
            this.lnkChangeDate.Name = "lnkChangeDate";
            this.lnkChangeDate.Size = new System.Drawing.Size(46, 15);
            this.lnkChangeDate.TabIndex = 18;
            this.lnkChangeDate.TabStop = true;
            this.lnkChangeDate.Text = "change";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.Lavender;
            this.textBox8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(12, 99);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(176, 21);
            this.textBox8.TabIndex = 3;
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.Navy;
            this.label29.Location = new System.Drawing.Point(9, 128);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(108, 15);
            this.label29.TabIndex = 4;
            this.label29.Text = "Other Information";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.White;
            this.textBox9.Location = new System.Drawing.Point(12, 22);
            this.textBox9.MaxLength = 100;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(176, 20);
            this.textBox9.TabIndex = 0;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.White;
            this.textBox10.Location = new System.Drawing.Point(12, 73);
            this.textBox10.MaxLength = 100;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(176, 20);
            this.textBox10.TabIndex = 2;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label33.Location = new System.Drawing.Point(194, 78);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(81, 15);
            this.label33.TabIndex = 19;
            this.label33.Text = "Middle Name";
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.White;
            this.textBox11.Location = new System.Drawing.Point(12, 47);
            this.textBox11.MaxLength = 100;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(176, 20);
            this.textBox11.TabIndex = 1;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label34.Location = new System.Drawing.Point(194, 106);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(59, 15);
            this.label34.TabIndex = 20;
            this.label34.Text = "Birthdate";
            // 
            // tabEmployment
            // 
            this.tabEmployment.Controls.Add(this.label35);
            this.tabEmployment.Location = new System.Drawing.Point(4, 23);
            this.tabEmployment.Name = "tabEmployment";
            this.tabEmployment.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployment.Size = new System.Drawing.Size(621, 466);
            this.tabEmployment.TabIndex = 1;
            this.tabEmployment.Text = "Employment";
            this.tabEmployment.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Orange;
            this.label35.Location = new System.Drawing.Point(411, 19);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(204, 20);
            this.label35.TabIndex = 49;
            this.label35.Text = "Employment Information";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(12, 52);
            this.textBox12.MaxLength = 50;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(176, 20);
            this.textBox12.TabIndex = 2;
            // 
            // lblEcode
            // 
            this.lblEcode.AutoSize = true;
            this.lblEcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEcode.Location = new System.Drawing.Point(194, 55);
            this.lblEcode.Name = "lblEcode";
            this.lblEcode.Size = new System.Drawing.Size(45, 15);
            this.lblEcode.TabIndex = 2;
            this.lblEcode.Text = "E-Code";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label47);
            this.groupBox4.Controls.Add(this.label48);
            this.groupBox4.Controls.Add(this.label49);
            this.groupBox4.Controls.Add(this.label50);
            this.groupBox4.Location = new System.Drawing.Point(6, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(327, 120);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label47.Location = new System.Drawing.Point(187, 95);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(69, 13);
            this.label47.TabIndex = 13;
            this.label47.Text = "PhilHealth ID";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label48.Location = new System.Drawing.Point(187, 69);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(42, 13);
            this.label48.TabIndex = 12;
            this.label48.Text = "SSS ID";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label49.Location = new System.Drawing.Point(188, 18);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(105, 13);
            this.label49.TabIndex = 4;
            this.label49.Text = "Pag-Ibig Contribution";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label50.Location = new System.Drawing.Point(188, 43);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(60, 13);
            this.label50.TabIndex = 11;
            this.label50.Text = "Pag-Ibig ID";
            // 
            // groupBox12
            // 
            this.groupBox12.BackColor = System.Drawing.Color.Transparent;
            this.groupBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox12.Controls.Add(this.label51);
            this.groupBox12.Location = new System.Drawing.Point(6, 207);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(327, 168);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label51.Location = new System.Drawing.Point(188, 135);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(61, 15);
            this.label51.TabIndex = 15;
            this.label51.Text = "Basic Rate";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label44.Location = new System.Drawing.Point(9, 102);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(75, 15);
            this.label44.TabIndex = 49;
            this.label44.Text = "Department";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label45.Location = new System.Drawing.Point(9, 58);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(41, 15);
            this.label45.TabIndex = 51;
            this.label45.Text = "Status";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label46.Location = new System.Drawing.Point(9, 15);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(33, 15);
            this.label46.TabIndex = 50;
            this.label46.Text = "Type";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Location = new System.Drawing.Point(8, 217);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(233, 57);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label36.Location = new System.Drawing.Point(148, 25);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(51, 13);
            this.label36.TabIndex = 18;
            this.label36.Text = "Rest Day";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Location = new System.Drawing.Point(8, 121);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(235, 90);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Second Part";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label40.Location = new System.Drawing.Point(148, 31);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(42, 13);
            this.label40.TabIndex = 16;
            this.label40.Text = "Time-In";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label41.Location = new System.Drawing.Point(148, 62);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(50, 13);
            this.label41.TabIndex = 17;
            this.label41.Text = "Time-Out";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label42);
            this.groupBox3.Controls.Add(this.label43);
            this.groupBox3.Location = new System.Drawing.Point(6, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 90);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "First Part";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label42.Location = new System.Drawing.Point(148, 33);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(42, 13);
            this.label42.TabIndex = 16;
            this.label42.Text = "Time-In";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label43.Location = new System.Drawing.Point(148, 64);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(50, 13);
            this.label43.TabIndex = 17;
            this.label43.Text = "Time-Out";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Orange;
            this.label52.Location = new System.Drawing.Point(411, 19);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(204, 20);
            this.label52.TabIndex = 49;
            this.label52.Text = "Employment Information";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.groupBox14);
            this.groupBox13.Controls.Add(this.groupBox15);
            this.groupBox13.Controls.Add(this.groupBox16);
            this.groupBox13.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.ForeColor = System.Drawing.Color.Navy;
            this.groupBox13.Location = new System.Drawing.Point(5, 176);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(249, 281);
            this.groupBox13.TabIndex = 9;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "DAILY TIME RECORD";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label53);
            this.groupBox14.Controls.Add(this.comboBox1);
            this.groupBox14.Location = new System.Drawing.Point(8, 217);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(233, 57);
            this.groupBox14.TabIndex = 2;
            this.groupBox14.TabStop = false;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label53.Location = new System.Drawing.Point(148, 25);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(54, 15);
            this.label53.TabIndex = 18;
            this.label53.Text = "Rest Day";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.timeInput1);
            this.groupBox15.Controls.Add(this.label54);
            this.groupBox15.Controls.Add(this.timeInput2);
            this.groupBox15.Controls.Add(this.label55);
            this.groupBox15.Location = new System.Drawing.Point(8, 121);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(235, 90);
            this.groupBox15.TabIndex = 1;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Second Part";
            // 
            // timeInput1
            // 
            this.timeInput1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeInput1.Location = new System.Drawing.Point(8, 53);
            this.timeInput1.Name = "timeInput1";
            this.timeInput1.Size = new System.Drawing.Size(131, 32);
            this.timeInput1.TabIndex = 1;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label54.Location = new System.Drawing.Point(148, 31);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(48, 15);
            this.label54.TabIndex = 16;
            this.label54.Text = "Time-In";
            // 
            // timeInput2
            // 
            this.timeInput2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeInput2.Location = new System.Drawing.Point(8, 22);
            this.timeInput2.Name = "timeInput2";
            this.timeInput2.Size = new System.Drawing.Size(131, 32);
            this.timeInput2.TabIndex = 0;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label55.Location = new System.Drawing.Point(148, 62);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(59, 15);
            this.label55.TabIndex = 17;
            this.label55.Text = "Time-Out";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.timeInput3);
            this.groupBox16.Controls.Add(this.timeInput4);
            this.groupBox16.Controls.Add(this.label56);
            this.groupBox16.Controls.Add(this.label57);
            this.groupBox16.Location = new System.Drawing.Point(6, 25);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(235, 90);
            this.groupBox16.TabIndex = 0;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "First Part";
            // 
            // timeInput3
            // 
            this.timeInput3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeInput3.Location = new System.Drawing.Point(10, 55);
            this.timeInput3.Name = "timeInput3";
            this.timeInput3.Size = new System.Drawing.Size(131, 32);
            this.timeInput3.TabIndex = 1;
            // 
            // timeInput4
            // 
            this.timeInput4.BackColor = System.Drawing.Color.GhostWhite;
            this.timeInput4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeInput4.Location = new System.Drawing.Point(10, 24);
            this.timeInput4.Name = "timeInput4";
            this.timeInput4.Size = new System.Drawing.Size(131, 32);
            this.timeInput4.TabIndex = 0;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label56.Location = new System.Drawing.Point(148, 33);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(48, 15);
            this.label56.TabIndex = 16;
            this.label56.Text = "Time-In";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label57.Location = new System.Drawing.Point(148, 64);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(59, 15);
            this.label57.TabIndex = 17;
            this.label57.Text = "Time-Out";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.comboBox2);
            this.groupBox17.Controls.Add(this.label58);
            this.groupBox17.Controls.Add(this.label59);
            this.groupBox17.Controls.Add(this.comboBox3);
            this.groupBox17.Controls.Add(this.label60);
            this.groupBox17.Controls.Add(this.comboBox4);
            this.groupBox17.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox17.ForeColor = System.Drawing.Color.Navy;
            this.groupBox17.Location = new System.Drawing.Point(5, 11);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(249, 159);
            this.groupBox17.TabIndex = 5;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "EMPLOYEE DESIGNATION";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 120);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(235, 21);
            this.comboBox2.TabIndex = 48;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label58.Location = new System.Drawing.Point(9, 102);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(75, 15);
            this.label58.TabIndex = 49;
            this.label58.Text = "Department";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label59.Location = new System.Drawing.Point(9, 58);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(41, 15);
            this.label59.TabIndex = 51;
            this.label59.Text = "Status";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(6, 76);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(235, 21);
            this.comboBox3.TabIndex = 0;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label60.Location = new System.Drawing.Point(9, 15);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(33, 15);
            this.label60.TabIndex = 50;
            this.label60.Text = "Type";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(6, 32);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(235, 21);
            this.comboBox4.TabIndex = 1;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.textBox13);
            this.groupBox18.Controls.Add(this.label61);
            this.groupBox18.Controls.Add(this.groupBox19);
            this.groupBox18.Controls.Add(this.groupBox20);
            this.groupBox18.Controls.Add(this.label71);
            this.groupBox18.Controls.Add(this.textBox19);
            this.groupBox18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox18.ForeColor = System.Drawing.Color.Navy;
            this.groupBox18.Location = new System.Drawing.Point(276, 58);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(339, 380);
            this.groupBox18.TabIndex = 7;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "JOB INFORMATION";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(12, 52);
            this.textBox13.MaxLength = 50;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(176, 23);
            this.textBox13.TabIndex = 2;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label61.Location = new System.Drawing.Point(194, 55);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(45, 15);
            this.label61.TabIndex = 2;
            this.label61.Text = "E-Code";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.label62);
            this.groupBox19.Controls.Add(this.textBox14);
            this.groupBox19.Controls.Add(this.textBox15);
            this.groupBox19.Controls.Add(this.label63);
            this.groupBox19.Controls.Add(this.textBox16);
            this.groupBox19.Controls.Add(this.label64);
            this.groupBox19.Controls.Add(this.label65);
            this.groupBox19.Controls.Add(this.textBox17);
            this.groupBox19.Location = new System.Drawing.Point(6, 81);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(327, 120);
            this.groupBox19.TabIndex = 3;
            this.groupBox19.TabStop = false;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label62.Location = new System.Drawing.Point(187, 95);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(77, 15);
            this.label62.TabIndex = 13;
            this.label62.Text = "PhilHealth ID";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(6, 40);
            this.textBox14.MaxLength = 50;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(176, 23);
            this.textBox14.TabIndex = 1;
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.Color.White;
            this.textBox15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.ForeColor = System.Drawing.Color.Red;
            this.textBox15.Location = new System.Drawing.Point(6, 15);
            this.textBox15.MaxLength = 12;
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(176, 23);
            this.textBox15.TabIndex = 0;
            this.textBox15.Text = "0.00";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label63.Location = new System.Drawing.Point(187, 69);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(39, 15);
            this.label63.TabIndex = 12;
            this.label63.Text = "SSS ID";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(6, 65);
            this.textBox16.MaxLength = 50;
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(176, 23);
            this.textBox16.TabIndex = 2;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label64.Location = new System.Drawing.Point(188, 18);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(122, 15);
            this.label64.TabIndex = 4;
            this.label64.Text = "Pag-Ibig Contribution";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label65.Location = new System.Drawing.Point(188, 43);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(63, 15);
            this.label65.TabIndex = 11;
            this.label65.Text = "Pag-Ibig ID";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(6, 90);
            this.textBox17.MaxLength = 50;
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(176, 23);
            this.textBox17.TabIndex = 3;
            // 
            // groupBox20
            // 
            this.groupBox20.BackColor = System.Drawing.Color.Transparent;
            this.groupBox20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox20.Controls.Add(this.comboBox5);
            this.groupBox20.Controls.Add(this.label66);
            this.groupBox20.Controls.Add(this.linkLabel1);
            this.groupBox20.Controls.Add(this.comboBox6);
            this.groupBox20.Controls.Add(this.comboBox7);
            this.groupBox20.Controls.Add(this.comboBox8);
            this.groupBox20.Controls.Add(this.label67);
            this.groupBox20.Controls.Add(this.textBox18);
            this.groupBox20.Controls.Add(this.label68);
            this.groupBox20.Controls.Add(this.label69);
            this.groupBox20.Controls.Add(this.label70);
            this.groupBox20.Location = new System.Drawing.Point(6, 207);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(327, 168);
            this.groupBox20.TabIndex = 4;
            this.groupBox20.TabStop = false;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(6, 94);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(176, 21);
            this.comboBox5.TabIndex = 20;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label66.Location = new System.Drawing.Point(188, 97);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(73, 15);
            this.label66.TabIndex = 21;
            this.label66.Text = "Level Points";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(243, 19);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(81, 15);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Masteral Rate";
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(6, 67);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(176, 21);
            this.comboBox6.TabIndex = 2;
            // 
            // comboBox7
            // 
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(6, 41);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(176, 21);
            this.comboBox7.TabIndex = 1;
            // 
            // comboBox8
            // 
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(6, 15);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(176, 21);
            this.comboBox8.TabIndex = 0;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label67.Location = new System.Drawing.Point(188, 135);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(61, 15);
            this.label67.TabIndex = 15;
            this.label67.Text = "Basic Rate";
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.Color.Lavender;
            this.textBox18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.ForeColor = System.Drawing.Color.Red;
            this.textBox18.Location = new System.Drawing.Point(6, 131);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(176, 27);
            this.textBox18.TabIndex = 3;
            this.textBox18.Text = "0.00";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label68.Location = new System.Drawing.Point(188, 19);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(36, 15);
            this.label68.TabIndex = 10;
            this.label68.Text = "Level";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label69.Location = new System.Drawing.Point(188, 70);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(47, 15);
            this.label69.TabIndex = 12;
            this.label69.Text = "Degree";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label70.Location = new System.Drawing.Point(188, 44);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(56, 15);
            this.label70.TabIndex = 11;
            this.label70.Text = "Category";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label71.Location = new System.Drawing.Point(194, 26);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(75, 15);
            this.label71.TabIndex = 1;
            this.label71.Text = "Employee ID";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(12, 23);
            this.textBox19.MaxLength = 50;
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(176, 23);
            this.textBox19.TabIndex = 0;
            // 
            // tblEmployment
            // 
            this.tblEmployment.Controls.Add(this.lblEmp);
            this.tblEmployment.Controls.Add(this.gbxDailyTime);
            this.tblEmployment.Controls.Add(this.gbxType);
            this.tblEmployment.Controls.Add(this.gbxJobInfo);
            this.tblEmployment.Location = new System.Drawing.Point(4, 24);
            this.tblEmployment.Name = "tblEmployment";
            this.tblEmployment.Padding = new System.Windows.Forms.Padding(3);
            this.tblEmployment.Size = new System.Drawing.Size(744, 470);
            this.tblEmployment.TabIndex = 2;
            this.tblEmployment.Text = "Employment";
            this.tblEmployment.UseVisualStyleBackColor = true;
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmp.ForeColor = System.Drawing.Color.Orange;
            this.lblEmp.Location = new System.Drawing.Point(521, 10);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(204, 20);
            this.lblEmp.TabIndex = 49;
            this.lblEmp.Text = "Employment Information";
            // 
            // gbxDailyTime
            // 
            this.gbxDailyTime.Controls.Add(this.chkFixedTime);
            this.gbxDailyTime.Controls.Add(this.gbxRestDay);
            this.gbxDailyTime.Controls.Add(this.gbxSecondPart);
            this.gbxDailyTime.Controls.Add(this.gbxFirstPart);
            this.gbxDailyTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDailyTime.ForeColor = System.Drawing.Color.Navy;
            this.gbxDailyTime.Location = new System.Drawing.Point(15, 172);
            this.gbxDailyTime.Name = "gbxDailyTime";
            this.gbxDailyTime.Size = new System.Drawing.Size(322, 281);
            this.gbxDailyTime.TabIndex = 9;
            this.gbxDailyTime.TabStop = false;
            this.gbxDailyTime.Text = "DAILY TIME RECORD";
            // 
            // chkFixedTime
            // 
            this.chkFixedTime.AutoSize = true;
            this.chkFixedTime.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFixedTime.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFixedTime.ForeColor = System.Drawing.Color.Red;
            this.chkFixedTime.Location = new System.Drawing.Point(227, 3);
            this.chkFixedTime.Name = "chkFixedTime";
            this.chkFixedTime.Size = new System.Drawing.Size(93, 76);
            this.chkFixedTime.TabIndex = 3;
            this.chkFixedTime.Text = "\r\n\r\n\r\nIs Fixed Time\r\n";
            this.chkFixedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFixedTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.chkFixedTime.UseVisualStyleBackColor = true;
            // 
            // gbxRestDay
            // 
            this.gbxRestDay.Controls.Add(this.cboRestDay);
            this.gbxRestDay.Enabled = false;
            this.gbxRestDay.Location = new System.Drawing.Point(8, 217);
            this.gbxRestDay.Name = "gbxRestDay";
            this.gbxRestDay.Size = new System.Drawing.Size(208, 57);
            this.gbxRestDay.TabIndex = 2;
            this.gbxRestDay.TabStop = false;
            this.gbxRestDay.Text = " Rest Day ";
            // 
            // cboRestDay
            // 
            this.cboRestDay.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboRestDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRestDay.FormattingEnabled = true;
            this.cboRestDay.Location = new System.Drawing.Point(12, 22);
            this.cboRestDay.Name = "cboRestDay";
            this.cboRestDay.Size = new System.Drawing.Size(182, 23);
            this.cboRestDay.TabIndex = 0;
            // 
            // gbxSecondPart
            // 
            this.gbxSecondPart.Controls.Add(this.tmeSecondOut);
            this.gbxSecondPart.Controls.Add(this.label74);
            this.gbxSecondPart.Controls.Add(this.tmeSecondIn);
            this.gbxSecondPart.Controls.Add(this.label75);
            this.gbxSecondPart.Enabled = false;
            this.gbxSecondPart.Location = new System.Drawing.Point(8, 121);
            this.gbxSecondPart.Name = "gbxSecondPart";
            this.gbxSecondPart.Size = new System.Drawing.Size(208, 90);
            this.gbxSecondPart.TabIndex = 1;
            this.gbxSecondPart.TabStop = false;
            this.gbxSecondPart.Text = " Second Part ";
            // 
            // tmeSecondOut
            // 
            this.tmeSecondOut.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmeSecondOut.Location = new System.Drawing.Point(8, 53);
            this.tmeSecondOut.Name = "tmeSecondOut";
            this.tmeSecondOut.Size = new System.Drawing.Size(131, 32);
            this.tmeSecondOut.TabIndex = 1;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.ForeColor = System.Drawing.Color.Black;
            this.label74.Location = new System.Drawing.Point(145, 28);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(48, 15);
            this.label74.TabIndex = 16;
            this.label74.Text = "Time-In";
            // 
            // tmeSecondIn
            // 
            this.tmeSecondIn.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmeSecondIn.Location = new System.Drawing.Point(8, 22);
            this.tmeSecondIn.Name = "tmeSecondIn";
            this.tmeSecondIn.Size = new System.Drawing.Size(131, 32);
            this.tmeSecondIn.TabIndex = 0;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.ForeColor = System.Drawing.Color.Black;
            this.label75.Location = new System.Drawing.Point(145, 59);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(59, 15);
            this.label75.TabIndex = 17;
            this.label75.Text = "Time-Out";
            // 
            // gbxFirstPart
            // 
            this.gbxFirstPart.Controls.Add(this.tmeFirstOut);
            this.gbxFirstPart.Controls.Add(this.tmeFirstIn);
            this.gbxFirstPart.Controls.Add(this.label76);
            this.gbxFirstPart.Controls.Add(this.label77);
            this.gbxFirstPart.Enabled = false;
            this.gbxFirstPart.Location = new System.Drawing.Point(6, 25);
            this.gbxFirstPart.Name = "gbxFirstPart";
            this.gbxFirstPart.Size = new System.Drawing.Size(210, 90);
            this.gbxFirstPart.TabIndex = 0;
            this.gbxFirstPart.TabStop = false;
            this.gbxFirstPart.Text = " First Part ";
            // 
            // tmeFirstOut
            // 
            this.tmeFirstOut.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmeFirstOut.Location = new System.Drawing.Point(10, 55);
            this.tmeFirstOut.Name = "tmeFirstOut";
            this.tmeFirstOut.Size = new System.Drawing.Size(131, 32);
            this.tmeFirstOut.TabIndex = 1;
            // 
            // tmeFirstIn
            // 
            this.tmeFirstIn.BackColor = System.Drawing.Color.GhostWhite;
            this.tmeFirstIn.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmeFirstIn.Location = new System.Drawing.Point(10, 24);
            this.tmeFirstIn.Name = "tmeFirstIn";
            this.tmeFirstIn.Size = new System.Drawing.Size(131, 32);
            this.tmeFirstIn.TabIndex = 0;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.ForeColor = System.Drawing.Color.Black;
            this.label76.Location = new System.Drawing.Point(147, 31);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(48, 15);
            this.label76.TabIndex = 16;
            this.label76.Text = "Time-In";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.ForeColor = System.Drawing.Color.Black;
            this.label77.Location = new System.Drawing.Point(147, 62);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(59, 15);
            this.label77.TabIndex = 17;
            this.label77.Text = "Time-Out";
            // 
            // gbxType
            // 
            this.gbxType.Controls.Add(this.cboDepartment);
            this.gbxType.Controls.Add(this.label78);
            this.gbxType.Controls.Add(this.label79);
            this.gbxType.Controls.Add(this.cboStatus);
            this.gbxType.Controls.Add(this.label80);
            this.gbxType.Controls.Add(this.cboType);
            this.gbxType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxType.ForeColor = System.Drawing.Color.Navy;
            this.gbxType.Location = new System.Drawing.Point(15, 42);
            this.gbxType.Name = "gbxType";
            this.gbxType.Size = new System.Drawing.Size(322, 124);
            this.gbxType.TabIndex = 5;
            this.gbxType.TabStop = false;
            this.gbxType.Text = " EMPLOYEE DESIGNATION ";
            // 
            // cboDepartment
            // 
            this.cboDepartment.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(86, 84);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(221, 23);
            this.cboDepartment.TabIndex = 48;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.ForeColor = System.Drawing.Color.Black;
            this.label78.Location = new System.Drawing.Point(5, 86);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(79, 15);
            this.label78.TabIndex = 49;
            this.label78.Text = "Department:";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.ForeColor = System.Drawing.Color.Black;
            this.label79.Location = new System.Drawing.Point(5, 58);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(45, 15);
            this.label79.TabIndex = 51;
            this.label79.Text = "Status:";
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(86, 55);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(221, 23);
            this.cboStatus.TabIndex = 0;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.ForeColor = System.Drawing.Color.Black;
            this.label80.Location = new System.Drawing.Point(3, 29);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(37, 15);
            this.label80.TabIndex = 50;
            this.label80.Text = "Type:";
            // 
            // cboType
            // 
            this.cboType.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(86, 26);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(221, 23);
            this.cboType.TabIndex = 1;
            // 
            // gbxJobInfo
            // 
            this.gbxJobInfo.Controls.Add(this.tabControl1);
            this.gbxJobInfo.Controls.Add(this.tabEmpRate);
            this.gbxJobInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxJobInfo.ForeColor = System.Drawing.Color.Navy;
            this.gbxJobInfo.Location = new System.Drawing.Point(343, 42);
            this.gbxJobInfo.Name = "gbxJobInfo";
            this.gbxJobInfo.Size = new System.Drawing.Size(382, 411);
            this.gbxJobInfo.TabIndex = 7;
            this.gbxJobInfo.TabStop = false;
            this.gbxJobInfo.Text = " JOB INFORMATION ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(6, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 179);
            this.tabControl1.TabIndex = 66;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage7.Controls.Add(this.label82);
            this.tabPage7.Controls.Add(this.txtEmployeeId);
            this.tabPage7.Controls.Add(this.txtPagibigId);
            this.tabPage7.Controls.Add(this.lblEmpIdLabel);
            this.tabPage7.Controls.Add(this.label83);
            this.tabPage7.Controls.Add(this.txtPhilHealthId);
            this.tabPage7.Controls.Add(this.txtSssId);
            this.tabPage7.Controls.Add(this.label85);
            this.tabPage7.Location = new System.Drawing.Point(4, 24);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(362, 151);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Basic Information";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.ForeColor = System.Drawing.Color.Black;
            this.label82.Location = new System.Drawing.Point(254, 107);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(77, 15);
            this.label82.TabIndex = 13;
            this.label82.Text = "PhilHealth ID";
            // 
            // txtEmployeeId
            // 
            this.txtEmployeeId.BackColor = System.Drawing.Color.White;
            this.txtEmployeeId.Location = new System.Drawing.Point(27, 21);
            this.txtEmployeeId.MaxLength = 50;
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.Size = new System.Drawing.Size(219, 23);
            this.txtEmployeeId.TabIndex = 0;
            // 
            // txtPagibigId
            // 
            this.txtPagibigId.BackColor = System.Drawing.Color.White;
            this.txtPagibigId.Location = new System.Drawing.Point(27, 50);
            this.txtPagibigId.MaxLength = 50;
            this.txtPagibigId.Name = "txtPagibigId";
            this.txtPagibigId.Size = new System.Drawing.Size(219, 23);
            this.txtPagibigId.TabIndex = 1;
            // 
            // lblEmpIdLabel
            // 
            this.lblEmpIdLabel.AutoSize = true;
            this.lblEmpIdLabel.ForeColor = System.Drawing.Color.Black;
            this.lblEmpIdLabel.Location = new System.Drawing.Point(254, 23);
            this.lblEmpIdLabel.Name = "lblEmpIdLabel";
            this.lblEmpIdLabel.Size = new System.Drawing.Size(75, 15);
            this.lblEmpIdLabel.TabIndex = 64;
            this.lblEmpIdLabel.Text = "Employee ID";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.ForeColor = System.Drawing.Color.Black;
            this.label83.Location = new System.Drawing.Point(254, 81);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(39, 15);
            this.label83.TabIndex = 12;
            this.label83.Text = "SSS ID";
            // 
            // txtPhilHealthId
            // 
            this.txtPhilHealthId.BackColor = System.Drawing.Color.White;
            this.txtPhilHealthId.Location = new System.Drawing.Point(27, 106);
            this.txtPhilHealthId.MaxLength = 50;
            this.txtPhilHealthId.Name = "txtPhilHealthId";
            this.txtPhilHealthId.Size = new System.Drawing.Size(219, 23);
            this.txtPhilHealthId.TabIndex = 3;
            // 
            // txtSssId
            // 
            this.txtSssId.BackColor = System.Drawing.Color.White;
            this.txtSssId.Location = new System.Drawing.Point(27, 79);
            this.txtSssId.MaxLength = 50;
            this.txtSssId.Name = "txtSssId";
            this.txtSssId.Size = new System.Drawing.Size(219, 23);
            this.txtSssId.TabIndex = 2;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.ForeColor = System.Drawing.Color.Black;
            this.label85.Location = new System.Drawing.Point(254, 53);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(63, 15);
            this.label85.TabIndex = 11;
            this.label85.Text = "Pag-Ibig ID";
            // 
            // tabEmpRate
            // 
            this.tabEmpRate.Controls.Add(this.tblRankBaseRate);
            this.tabEmpRate.Controls.Add(this.tnlOtherInformation);
            this.tabEmpRate.Location = new System.Drawing.Point(6, 207);
            this.tabEmpRate.Name = "tabEmpRate";
            this.tabEmpRate.SelectedIndex = 0;
            this.tabEmpRate.Size = new System.Drawing.Size(370, 197);
            this.tabEmpRate.TabIndex = 65;
            // 
            // tblRankBaseRate
            // 
            this.tblRankBaseRate.BackColor = System.Drawing.Color.GhostWhite;
            this.tblRankBaseRate.Controls.Add(this.lblLevelPoints);
            this.tblRankBaseRate.Controls.Add(this.cboCategory);
            this.tblRankBaseRate.Controls.Add(this.lblCategory);
            this.tblRankBaseRate.Controls.Add(this.label87);
            this.tblRankBaseRate.Controls.Add(this.lblLevel);
            this.tblRankBaseRate.Controls.Add(this.cboLevel);
            this.tblRankBaseRate.Controls.Add(this.txtBasicRate);
            this.tblRankBaseRate.Controls.Add(this.cboDegree);
            this.tblRankBaseRate.Controls.Add(this.cboPoints);
            this.tblRankBaseRate.Controls.Add(this.lblDegree);
            this.tblRankBaseRate.Location = new System.Drawing.Point(4, 24);
            this.tblRankBaseRate.Name = "tblRankBaseRate";
            this.tblRankBaseRate.Padding = new System.Windows.Forms.Padding(3);
            this.tblRankBaseRate.Size = new System.Drawing.Size(362, 169);
            this.tblRankBaseRate.TabIndex = 0;
            this.tblRankBaseRate.Text = "Rank Base Rate";
            this.tblRankBaseRate.UseVisualStyleBackColor = true;
            // 
            // lblLevelPoints
            // 
            this.lblLevelPoints.AutoSize = true;
            this.lblLevelPoints.ForeColor = System.Drawing.Color.Black;
            this.lblLevelPoints.Location = new System.Drawing.Point(254, 109);
            this.lblLevelPoints.Name = "lblLevelPoints";
            this.lblLevelPoints.Size = new System.Drawing.Size(73, 15);
            this.lblLevelPoints.TabIndex = 33;
            this.lblLevelPoints.Text = "Level Points";
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(27, 46);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(219, 23);
            this.cboCategory.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.ForeColor = System.Drawing.Color.Black;
            this.lblCategory.Location = new System.Drawing.Point(254, 51);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(56, 15);
            this.lblCategory.TabIndex = 32;
            this.lblCategory.Text = "Category";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.Black;
            this.label87.Location = new System.Drawing.Point(254, 138);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(61, 15);
            this.label87.TabIndex = 15;
            this.label87.Text = "Basic Rate";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.ForeColor = System.Drawing.Color.Black;
            this.lblLevel.Location = new System.Drawing.Point(254, 17);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(36, 15);
            this.lblLevel.TabIndex = 31;
            this.lblLevel.Text = "Level";
            // 
            // cboLevel
            // 
            this.cboLevel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.Location = new System.Drawing.Point(27, 17);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(219, 23);
            this.cboLevel.TabIndex = 0;
            // 
            // txtBasicRate
            // 
            this.txtBasicRate.BackColor = System.Drawing.Color.LightGray;
            this.txtBasicRate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBasicRate.ForeColor = System.Drawing.Color.Red;
            this.txtBasicRate.Location = new System.Drawing.Point(27, 133);
            this.txtBasicRate.MaxLength = 12;
            this.txtBasicRate.Name = "txtBasicRate";
            this.txtBasicRate.Size = new System.Drawing.Size(219, 23);
            this.txtBasicRate.TabIndex = 22;
            this.txtBasicRate.Text = "0.00";
            this.txtBasicRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboDegree
            // 
            this.cboDegree.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDegree.FormattingEnabled = true;
            this.cboDegree.Location = new System.Drawing.Point(27, 75);
            this.cboDegree.Name = "cboDegree";
            this.cboDegree.Size = new System.Drawing.Size(219, 23);
            this.cboDegree.TabIndex = 2;
            // 
            // cboPoints
            // 
            this.cboPoints.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPoints.FormattingEnabled = true;
            this.cboPoints.Location = new System.Drawing.Point(27, 104);
            this.cboPoints.Name = "cboPoints";
            this.cboPoints.Size = new System.Drawing.Size(219, 23);
            this.cboPoints.TabIndex = 20;
            // 
            // lblDegree
            // 
            this.lblDegree.AutoSize = true;
            this.lblDegree.ForeColor = System.Drawing.Color.Black;
            this.lblDegree.Location = new System.Drawing.Point(254, 80);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(47, 15);
            this.lblDegree.TabIndex = 30;
            this.lblDegree.Text = "Degree";
            // 
            // tnlOtherInformation
            // 
            this.tnlOtherInformation.BackColor = System.Drawing.Color.GhostWhite;
            this.tnlOtherInformation.Controls.Add(this.txtOtherInformationEmployee);
            this.tnlOtherInformation.Location = new System.Drawing.Point(4, 24);
            this.tnlOtherInformation.Name = "tnlOtherInformation";
            this.tnlOtherInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tnlOtherInformation.Size = new System.Drawing.Size(362, 169);
            this.tnlOtherInformation.TabIndex = 2;
            this.tnlOtherInformation.Text = "Other Information";
            this.tnlOtherInformation.UseVisualStyleBackColor = true;
            // 
            // txtOtherInformationEmployee
            // 
            this.txtOtherInformationEmployee.BackColor = System.Drawing.Color.White;
            this.txtOtherInformationEmployee.Location = new System.Drawing.Point(8, 10);
            this.txtOtherInformationEmployee.MaxLength = 10000;
            this.txtOtherInformationEmployee.Multiline = true;
            this.txtOtherInformationEmployee.Name = "txtOtherInformationEmployee";
            this.txtOtherInformationEmployee.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOtherInformationEmployee.Size = new System.Drawing.Size(348, 151);
            this.txtOtherInformationEmployee.TabIndex = 62;
            // 
            // lblAlert
            // 
            this.lblAlert.AutoSize = true;
            this.lblAlert.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlert.ForeColor = System.Drawing.Color.Red;
            this.lblAlert.Location = new System.Drawing.Point(11, 11);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(66, 14);
            this.lblAlert.TabIndex = 51;
            this.lblAlert.Text = "Level Points";
            this.lblAlert.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage3.Controls.Add(this.label73);
            this.tabPage3.Controls.Add(this.comboBox9);
            this.tabPage3.Controls.Add(this.label89);
            this.tabPage3.Controls.Add(this.label90);
            this.tabPage3.Controls.Add(this.label91);
            this.tabPage3.Controls.Add(this.comboBox10);
            this.tabPage3.Controls.Add(this.textBox20);
            this.tabPage3.Controls.Add(this.comboBox11);
            this.tabPage3.Controls.Add(this.comboBox12);
            this.tabPage3.Controls.Add(this.label92);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(362, 188);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Rank Base Rate";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.ForeColor = System.Drawing.Color.Black;
            this.label73.Location = new System.Drawing.Point(241, 119);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(65, 13);
            this.label73.TabIndex = 33;
            this.label73.Text = "Level Points";
            // 
            // comboBox9
            // 
            this.comboBox9.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(14, 56);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(219, 21);
            this.comboBox9.TabIndex = 1;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.ForeColor = System.Drawing.Color.Black;
            this.label89.Location = new System.Drawing.Point(241, 61);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(49, 13);
            this.label89.TabIndex = 32;
            this.label89.Text = "Category";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.ForeColor = System.Drawing.Color.Black;
            this.label90.Location = new System.Drawing.Point(241, 148);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(61, 15);
            this.label90.TabIndex = 15;
            this.label90.Text = "Basic Rate";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.ForeColor = System.Drawing.Color.Black;
            this.label91.Location = new System.Drawing.Point(241, 27);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(33, 13);
            this.label91.TabIndex = 31;
            this.label91.Text = "Level";
            // 
            // comboBox10
            // 
            this.comboBox10.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.comboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Location = new System.Drawing.Point(14, 27);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(219, 21);
            this.comboBox10.TabIndex = 0;
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.Color.LightGray;
            this.textBox20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox20.ForeColor = System.Drawing.Color.Red;
            this.textBox20.Location = new System.Drawing.Point(14, 143);
            this.textBox20.MaxLength = 12;
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(219, 23);
            this.textBox20.TabIndex = 22;
            this.textBox20.Text = "0.00";
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBox11
            // 
            this.comboBox11.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.comboBox11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Location = new System.Drawing.Point(14, 85);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(219, 21);
            this.comboBox11.TabIndex = 2;
            // 
            // comboBox12
            // 
            this.comboBox12.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.comboBox12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.Location = new System.Drawing.Point(14, 114);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(219, 21);
            this.comboBox12.TabIndex = 20;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.ForeColor = System.Drawing.Color.Black;
            this.label92.Location = new System.Drawing.Point(241, 90);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(42, 13);
            this.label92.TabIndex = 30;
            this.label92.Text = "Degree";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage4.Controls.Add(this.label93);
            this.tabPage4.Controls.Add(this.label94);
            this.tabPage4.Controls.Add(this.label95);
            this.tabPage4.Controls.Add(this.label96);
            this.tabPage4.Controls.Add(this.label97);
            this.tabPage4.Controls.Add(this.textBox21);
            this.tabPage4.Controls.Add(this.textBox22);
            this.tabPage4.Controls.Add(this.textBox23);
            this.tabPage4.Controls.Add(this.textBox24);
            this.tabPage4.Controls.Add(this.textBox25);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(362, 188);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Manual Rate";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.ForeColor = System.Drawing.Color.Black;
            this.label93.Location = new System.Drawing.Point(241, 146);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(45, 13);
            this.label93.TabIndex = 36;
            this.label93.Text = "Per Day";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.ForeColor = System.Drawing.Color.Black;
            this.label94.Location = new System.Drawing.Point(241, 117);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(56, 13);
            this.label94.TabIndex = 35;
            this.label94.Text = "Per Month";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.ForeColor = System.Drawing.Color.Black;
            this.label95.Location = new System.Drawing.Point(241, 88);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(45, 13);
            this.label95.TabIndex = 34;
            this.label95.Text = "Per Unit";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.ForeColor = System.Drawing.Color.Black;
            this.label96.Location = new System.Drawing.Point(241, 59);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(49, 13);
            this.label96.TabIndex = 33;
            this.label96.Text = "Per Hour";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.ForeColor = System.Drawing.Color.Black;
            this.label97.Location = new System.Drawing.Point(241, 30);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(47, 13);
            this.label97.TabIndex = 32;
            this.label97.Text = "Masteral";
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.Color.White;
            this.textBox21.ForeColor = System.Drawing.Color.Red;
            this.textBox21.Location = new System.Drawing.Point(14, 143);
            this.textBox21.MaxLength = 12;
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(219, 20);
            this.textBox21.TabIndex = 6;
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.Color.White;
            this.textBox22.ForeColor = System.Drawing.Color.Red;
            this.textBox22.Location = new System.Drawing.Point(14, 114);
            this.textBox22.MaxLength = 12;
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(219, 20);
            this.textBox22.TabIndex = 5;
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox23
            // 
            this.textBox23.BackColor = System.Drawing.Color.White;
            this.textBox23.ForeColor = System.Drawing.Color.Red;
            this.textBox23.Location = new System.Drawing.Point(14, 85);
            this.textBox23.MaxLength = 12;
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(219, 20);
            this.textBox23.TabIndex = 4;
            this.textBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox24
            // 
            this.textBox24.BackColor = System.Drawing.Color.White;
            this.textBox24.ForeColor = System.Drawing.Color.Red;
            this.textBox24.Location = new System.Drawing.Point(14, 56);
            this.textBox24.MaxLength = 12;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(219, 20);
            this.textBox24.TabIndex = 3;
            this.textBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox25
            // 
            this.textBox25.BackColor = System.Drawing.Color.White;
            this.textBox25.ForeColor = System.Drawing.Color.Red;
            this.textBox25.Location = new System.Drawing.Point(14, 27);
            this.textBox25.MaxLength = 12;
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(219, 20);
            this.textBox25.TabIndex = 2;
            this.textBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage5.Controls.Add(this.textBox26);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(362, 188);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Other Information";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.Color.White;
            this.textBox26.Location = new System.Drawing.Point(8, 10);
            this.textBox26.MaxLength = 10000;
            this.textBox26.Multiline = true;
            this.textBox26.Name = "textBox26";
            this.textBox26.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox26.Size = new System.Drawing.Size(348, 167);
            this.textBox26.TabIndex = 62;
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(780, 616);
            this.Name = "Employee";
            this.tblRelationship.ResumeLayout(false);
            this.tblRelationship.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerson)).EndInit();
            this.TabCntPerson.ResumeLayout(false);
            this.tblPersonalDetails.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errProvider)).EndInit();
            this.tabPersonalInformation.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabEmployment.ResumeLayout(false);
            this.tabEmployment.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.tblEmployment.ResumeLayout(false);
            this.tblEmployment.PerformLayout();
            this.gbxDailyTime.ResumeLayout(false);
            this.gbxDailyTime.PerformLayout();
            this.gbxRestDay.ResumeLayout(false);
            this.gbxSecondPart.ResumeLayout(false);
            this.gbxSecondPart.PerformLayout();
            this.gbxFirstPart.ResumeLayout(false);
            this.gbxFirstPart.PerformLayout();
            this.gbxType.ResumeLayout(false);
            this.gbxType.PerformLayout();
            this.gbxJobInfo.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabEmpRate.ResumeLayout(false);
            this.tblRankBaseRate.ResumeLayout(false);
            this.tblRankBaseRate.PerformLayout();
            this.tnlOtherInformation.ResumeLayout(false);
            this.tnlOtherInformation.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        
      
    }
}
