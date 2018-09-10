using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class Subject
    {
        #region Class General Variable Declarations
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.SubjectInformation _subjectInfo;
        protected CourseLogic _courseManager;

        private Int64 _preRequisiteId;
        private ErrorProvider _errProvider;
        
        #endregion

        #region Class Contructor
        public Subject()
        {
            this.InitializeComponent();

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.cboDepartment.SelectedIndexChanged += new EventHandler(cboDepartmentSelectedIndexChanged);
            this.txtCode.Validated += new EventHandler(txtCodeValidated);
            this.txtTitle.Validated += new EventHandler(txtTitleValidated);
            this.lnkOtherInfo.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkOtherInfoLinkClicked);
            this.cboCourseGroup.SelectedIndexChanged += new EventHandler(cboCourseGroupSelectedIndexChanged);
            this.cboSubjectCategory.SelectedIndexChanged += new EventHandler(cboSubjectCategorySelectedIndexChanged);
            this.optUnits.CheckedChanged += new EventHandler(UnitsHoursCheckedChanged);
            this.optHours.CheckedChanged += new EventHandler(UnitsHoursCheckedChanged);
            this.txtLecture.KeyPress += new KeyPressEventHandler(UnitsKeyPress);
            this.txtLecture.Validating += new System.ComponentModel.CancelEventHandler(UnitsValidating);
            this.txtLecture.Validated += new EventHandler(txtLectureValidated);
            this.txtLaboratory.KeyPress += new KeyPressEventHandler(UnitsKeyPress);
            this.txtLaboratory.Validating += new System.ComponentModel.CancelEventHandler(UnitsValidating);
            this.txtLaboratory.Validated += new EventHandler(txtLaboratoryValidated);
            this.hrmHours.Validated += new EventHandler(hrmHoursValidated);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvList.KeyPress += new KeyPressEventHandler(dgvListKeyPress);
            this.dgvList.KeyUp += new KeyEventHandler(dgvListKeyUp);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.dgvList.SelectionChanged += new EventHandler(dgvListSelectionChanged);
            this.lnkAdd.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkAddLinkClicked);
            this.lnkRemove.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRemoveLinkClicked);
            this.chkNonAcademic.CheckedChanged += new EventHandler(chkNonAcademicCheckedChanged);
            this.chkIsOpenAccess.CheckedChanged += new EventHandler(chkIsOpenAccessCheckedChanged);
        }       
        #endregion

        #region Class Event Void Procedures

        //#########################################CLASS Subject EVENTS###########################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _subjectInfo = new CommonExchange.SubjectInformation();
            _subjectInfo.NoHours = hrmHours.SelectedHourMinute;
            _subjectInfo.LectureUnits = 0;
            _subjectInfo.LabUnits = 0;

            this.lnkRemove.Enabled = false;
            this.lblResult.Text = "0 Subject";
            this.optUnits.Checked = true;

            this.lnkAdd.Enabled = false;
        }//--------------------------------
        //########################################END CLASS Subject EVENTS#########################################################

        //###########################################COMBOBOX cboDepartment EVENTS##################################################
        //event is raised when the selected index is changed
        private void cboDepartmentSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                _subjectInfo.DepartmentInfo.DepartmentId = _courseManager.GetDepartmentId(((ComboBox)sender).SelectedIndex);
                _subjectInfo.DepartmentInfo.DepartmentName = _courseManager.GetDepartmentName(((ComboBox)sender).SelectedIndex);

                this.lnkAdd.Enabled = true;
            }
        } //-------------------------------------
        //##########################################END COMBOBOX cboDepartment EVENTS###############################################

        //###########################################COMBOBOX cboSubjectCategory EVENTS##################################################
        //event is raised when the selected index is changed
        private void cboSubjectCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                _subjectInfo.CategoryInfo = _courseManager.GetDetailsSubjectCategoryDetails(((ComboBox)sender).SelectedIndex);
            }
        }//------------------------------------------
        //###########################################END COMBOBOX cboSubjectCategory EVENTS##################################################

        //###########################################TEXTBOX txtCode EVENTS###########################################################
        //event is raised when the control is validated
        private void txtCodeValidated(object sender, EventArgs e)
        {
            _subjectInfo.SubjectCode = RemoteClient.ProcStatic.TrimStartEndString(txtCode.Text);
        } //-----------------------------
        //#########################################END TEXTBOX txtCode EVENTS#########################################################

        //############################################TEXTBOX txtTitle EVENTS########################################################
        //event is raised when the control is validated
        private void txtTitleValidated(object sender, EventArgs e)
        {
            _subjectInfo.DescriptiveTitle = RemoteClient.ProcStatic.TrimStartEndString(txtTitle.Text);
        } //--------------------------------
        //###########################################END TEXTBOX txtTitle EVENTS######################################################

        //############################################LINKLABEL lnkOtherInfo EVENTS#####################################################
        //event is raised when the link is clicked
        private void lnkOtherInfoLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OtherInformation frmInfo = new OtherInformation())
            {
                frmInfo.SubjectOtherInformation = _subjectInfo.OtherInformation;

                frmInfo.ShowDialog(this);

                _subjectInfo.OtherInformation = RemoteClient.ProcStatic.TrimStartEndString(frmInfo.SubjectOtherInformation);
            }
        } //---------------------------------------
        //#########################################END LINKLABEL lnkOtherInfo EVENTS####################################################

        //################################################COMBOBOX cboEmployment EVENTS###############################################
        //event is raised when the selected index is changed
        private void cboCourseGroupSelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 index = ((ComboBox)sender).SelectedIndex;

            if (index != -1)
            {               
                index += 1;

                _subjectInfo.CourseGroupInfo.CourseGroupId = _courseManager.GetCourseGroupId(index);
                _subjectInfo.CourseGroupInfo.GroupNo = _courseManager.GetCourseGroupNo(_subjectInfo.CourseGroupInfo.CourseGroupId);
                _subjectInfo.CourseGroupInfo.IsSemestral = _courseManager.GetCourseGroupIsSemestral(_subjectInfo.CourseGroupInfo.CourseGroupId);

                if (!_subjectInfo.CourseGroupInfo.IsSemestral)
                {
                    this.optHours.Checked = true;
                    this.optHours.Enabled = true;
                    this.optUnits.Checked = false;
                    this.optUnits.Enabled = false;

                    this.txtCode.MaxLength = 49;
                }
                else
                {
                    this.optHours.Checked = false;
                    this.optHours.Enabled = false;
                    this.optUnits.Checked = true;
                    this.optUnits.Enabled = true;

                    this.txtCode.MaxLength = 9;
                }
            }

        } //----------------------------------
        //#############################################END COMBOBOX cboEmployment EVENTS##############################################

        //#################################################OPTIONBUTTONS EVENTS#######################################################
        //event is raised when the checked is changed
        private void UnitsHoursCheckedChanged(object sender, EventArgs e)
        {
            this.SetUnitsHoursControl();
        } //-------------------------------
        //###############################################END OPTIONBUTTONS EVENTS#####################################################

        //################################################TEXTBOX EVENTS###############################################################
        //event is raised when the key is pressed
        private void UnitsKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxIntegersOnly(e);
        } //---------------------------------------

        //event is raised when the control is validating
        private void UnitsValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateInteger((TextBox)sender);
        } //-------------------------------
        //##############################################END TEXTBOX EVENTS#############################################################

        //################################################TEXTBOX txtLecture EVENTS####################################################
        //event is raised when the control is validated
        private void txtLectureValidated(object sender, EventArgs e)
        {
            Byte lecUnits;

            if (Byte.TryParse(txtLecture.Text, out lecUnits))
            {
                _subjectInfo.LectureUnits = lecUnits;
            }
        } //----------------------------
        //#############################################END TEXTBOX txtLecture EVENTS###################################################

        //#################################################TEXTBOX txtLaboratory EVENTS###################################################
        //event is raised when the control is validated
        private void txtLaboratoryValidated(object sender, EventArgs e)
        {
            Byte labUnits;

            if (Byte.TryParse(txtLaboratory.Text, out labUnits))
            {
                _subjectInfo.LabUnits = labUnits;
            }
        } //---------------------------------
        //###############################################END TEXTBOX txtLaboratory EVENTS#################################################

        //#################################################HOURMINUTE hrmHours EVENTS#####################################################
        //event is raised when the control is validated
        private void hrmHoursValidated(object sender, EventArgs e)
        {
            _subjectInfo.NoHours = hrmHours.SelectedHourMinute;
        } //--------------------------------
        //##############################################END HOURMINUTE hrmHours EVENTS####################################################

        //#################################################DATAGRIDVIEW dgvList EVENTS###############################################
        //event is raised when the mouse is down
        private void dgvListMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView dgvBase = (DataGridView)sender;

                DataGridView.HitTestInfo hitTest = dgvBase.HitTest(e.X, e.Y);

                Int32 rowIndex = -1;

                switch (hitTest.Type)
                {
                    case DataGridViewHitTestType.Cell:
                        rowIndex = hitTest.RowIndex;
                        break;
                    case DataGridViewHitTestType.RowHeader:
                        rowIndex = hitTest.RowIndex;
                        break;
                    default:
                        rowIndex = -1;
                        _preRequisiteId = 0;
                        break;
                }

                if (rowIndex != -1)
                {
                    Int64 id;

                    if (Int64.TryParse(dgvBase[0, rowIndex].Value.ToString(), out id))
                    {
                        _preRequisiteId = id;
                    }                    

                    this.lnkRemove.Enabled = true;
                }
            }
        } //----------------------------------------

        //event is raised when the key is pressed
        private void dgvListKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }  //-----------------------------

        //event is raised when the key is up
        private void dgvListKeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        } //------------------------------

        //event is raised when the data source is changed
        private void dgvListDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 1)
            {
                Int64 id;

                if (Int64.TryParse(dgvBase[0, 0].Value.ToString(), out id))
                {
                    _preRequisiteId = id;
                }                
            }
            else
            {                
                _preRequisiteId = 0;
            }

            if (dgvBase.Rows.Count >= 1)
            {
                dgvBase.Rows[0].Selected = false;
            }

            if (result == 0 || result == 1)
            {
                this.lblResult.Text = result.ToString() + " Subject";
            }
            else
            {
                this.lblResult.Text = result.ToString() + " Subjects";
            }

            this.lnkRemove.Enabled = false;
        } //---------------------------

        //event is raised when the selection is changed
        private void dgvListSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;

            if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = dgvBase.SelectedRows[0];

                Int64 id;

                if (Int64.TryParse(row.Cells[0].Value.ToString(), out id))
                {
                    _preRequisiteId = id;
                }     
            }

            this.lnkRemove.Enabled = true;
        } //-----------------------------------
        //#############################################END DATAGRIDVIEW dgvList EVENTS###############################################

        //###########################################LINKBUTTON lnkAdd EVENTS########################################################
        //event is raised when the link is clicked
        private void lnkAddLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (PrerequisiteSearchOnTextboxList frmSearch = new PrerequisiteSearchOnTextboxList(_userInfo, _courseManager, 
                _subjectInfo.DepartmentInfo.DepartmentId))
            {
                frmSearch.ShowDialog(this);

                if (frmSearch.HasSelected)
                {
                    if (_courseManager.IsExistsPrerequisiteSubject(frmSearch.PrimaryId))
                    {
                        String strMsg = "The selected subject is already in the pre-requisite list.";

                        MessageBox.Show(strMsg, "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                        
                    }
                    else if (String.Equals(_subjectInfo.SubjectSysId, frmSearch.PrimaryId))
                    {
                        String strMsg = "Cannot add the selected subject in the pre-requisite list.";

                        MessageBox.Show(strMsg, "Entry Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                        
                    }
                    else
                    {
                        this.dgvList.DataSource = _courseManager.AddPrerequisiteSubject(_courseManager.GetDetailsSubjectInformation(frmSearch.PrimaryId));
                    }
                    
                }
            }
        }//---------------------------
        //##########################################END LINKBUTTON lnkAdd EVENTS#####################################################

        //##########################################LINKBUTTON lnkRemove EVENTS#######################################################
        //event is raised when the link is clicked
        private void lnkRemoveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String msgConfirm = "Are you sure you want to remove the selected pre-requisite subject?";

            if (MessageBox.Show(msgConfirm, "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.dgvList.DataSource = _courseManager.DeletePrerequisiteSubject(_preRequisiteId);
            }
        } //-----------------------------
        //#########################################END LINKBUTTON lnkRemove EVENTS####################################################

        //##########################################CHECKEDBOX chkNonAcademicSubject EVENTS#######################################################
        //event is raised when the link is clicked
        private void chkNonAcademicCheckedChanged(object sender, EventArgs e)
        {
            _subjectInfo.IsNonAcademic = this.chkNonAcademic.Checked;
        }//-----------------------------
        //##########################################END CHECKEDBOX chkNonAcademicSubject EVENTS#######################################################

        //##########################################CHECKEDBOX chkIsOpenAccess EVENTS#######################################################
        //event is raised when the link is clicked
        private void chkIsOpenAccessCheckedChanged(object sender, EventArgs e)
        {
            _subjectInfo.IsOpenAccess = this.chkIsOpenAccess.Checked;
        }//-----------------------------
        //##########################################END CHECKEDBOX chkIsOpenAccess EVENTS#######################################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure sets the units hours control
        private void SetUnitsHoursControl()
        {
            this.txtLecture.Enabled = optUnits.Checked;
            this.txtLaboratory.Enabled = optUnits.Checked;
            this.lblLecture.Enabled = optUnits.Checked;
            this.lblLaboratory.Enabled = optUnits.Checked;

            this.hrmHours.EnableControl = optHours.Checked;
            this.lblHours.Enabled = optHours.Checked;

            if (this.optUnits.Checked)
            {
                this.hrmHours.ResetHoursMinutes();

                _subjectInfo.NoHours = hrmHours.SelectedHourMinute;
            }
            else
            {
                this.txtLecture.Text = "0";
                this.txtLaboratory.Text = "0";

                _subjectInfo.LectureUnits = 0;
                _subjectInfo.LabUnits = 0;
            }            
            
            
        } //---------------------------
        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the controls are validated
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboDepartment, "");
            _errProvider.SetError(this.txtCode, "");
            _errProvider.SetError(this.txtTitle, "");
            _errProvider.SetError(this.cboCourseGroup, "");
            _errProvider.SetError(this.lblLecture, "");
            _errProvider.SetError(this.lblHours, "");
            
            if (this.cboDepartment.SelectedIndex == -1)
            {
                _errProvider.SetError(this.cboDepartment, "Please select a department.");
                isValid = false;
            }

            if (String.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                _errProvider.SetError(this.txtCode, "A subject code is required.");
                isValid = false;
            }
            else
            {
                if (String.IsNullOrEmpty(this.txtTitle.Text.Trim()))
                {
                    _errProvider.SetError(this.txtTitle, "A subject descriptive title is required.");
                    isValid = false;
                }
                else if (_courseManager.IsExistCodeDescriptionSubjectInformation(_userInfo, _subjectInfo))
                {
                    _errProvider.SetError(this.txtCode, "The subject code and descriptive title already exist.");
                    _errProvider.SetError(this.txtTitle, "The subject code and descriptive title already exist.");
                    isValid = false;
                }
            }

            if (this.cboCourseGroup.SelectedIndex == -1)
            {
                _errProvider.SetError(this.cboCourseGroup, "Please select a course group for the subject.");
                isValid = false;
            }

            //---------------------- disable traps because of nursing subjects ----------------------
            //Byte lecUnits;

            //if (Byte.TryParse(this.txtLecture.Text, out lecUnits))
            //{
            //    if (this.optUnits.Checked && lecUnits == 0)
            //    {
            //        _errProvider.SetError(this.lblLecture, "A lecture units is required.");
            //        isValid = false;
            //    }
            //}

            //if (this.optHours.Checked && this.hrmHours.IsHourMinuteZero())
            //{
            //    _errProvider.SetError(this.lblHours, "A number of hours/minutes must not be equal to zero.");
            //    isValid = false;
            //}            

            return isValid;
        }        

        #endregion
    }
}
