using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing;

namespace OfficeServices
{
    public class ScholarshipLogic : BaseServices.BaseServicesLogic
    {
        #region Data Member Declaration
        private DataSet _classDataSet;
        private DataTable _studentTable;
        private DataTable _studentScholarshipTable;
        #endregion

        #region Class Properties Declarations
        public DataTable ScholarshpTableFormat
        {
            get
            {

                DataTable scholarTable = new DataTable("ScholarshipTableFormat");
                scholarTable.Columns.Add("sysid_scholarship", System.Type.GetType("System.String"));
                scholarTable.Columns.Add("scholarship_description", System.Type.GetType("System.String"));
                scholarTable.Columns.Add("department_name", System.Type.GetType("System.String"));
                scholarTable.Columns.Add("group_description", System.Type.GetType("System.String"));

                return scholarTable;
            }
        }

        public DataTable StudentTableFormat
        {
            get
            {
                DataTable newTable = new DataTable("StudentSearchByStudentNameIdCardNumberTable");
                newTable.Columns.Add("student_id", System.Type.GetType("System.String"));               
                newTable.Columns.Add("student_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("card_number", System.Type.GetType("System.String"));
                newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
                newTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("department_name", System.Type.GetType("System.String"));

                return newTable;
            }
        }
        #endregion

        #region ClassConstructor
        public ScholarshipLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);

        }
        #endregion

        #region Programers-Defined Void Procedures
        //this procedure will insert scholarship information
        public void InsertScholarshipInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScholarshipInformation scholarshipInfo)
        {
            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                remClient.InsertScholarshipInformation(userInfo, ref scholarshipInfo);
            }

            DataRow newRow = _classDataSet.Tables["ScholarshipInformationTable"].NewRow();

            newRow["sysid_scholarship"] = scholarshipInfo.ScholarshipSysId;
            newRow["course_group_id"] = scholarshipInfo.CourseGroupInfo.CourseGroupId;
            newRow["group_description"] = scholarshipInfo.CourseGroupInfo.GroupDescription;
            newRow["department_id"] = scholarshipInfo.DepartmentInfo.DepartmentId;
            newRow["department_name"] = this.GetDepartmentDescription(scholarshipInfo.DepartmentInfo.DepartmentId);
            newRow["department_acronym"] = this.GetDepartmentAcronym(scholarshipInfo.DepartmentInfo.DepartmentId);
            newRow["is_non_academic"] = scholarshipInfo.IsNonAcademic;
            newRow["scholarship_description"] = scholarshipInfo.ScholarshipDescription;

            _classDataSet.Tables["ScholarshipInformationTable"].Rows.Add(newRow);
        }//-------------------

        //this procedure will insert student scholarship information
        public void InsertStudentScholarship(CommonExchange.SysAccess userInfo, CommonExchange.StudentScholarship studentScholarshipInfo)
        {
            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                remClient.InsertStudentScholarship(userInfo, ref studentScholarshipInfo);
            }

            DataRow newRow = _studentScholarshipTable.NewRow();

            newRow["sysid_enrolmentlevel"] = studentScholarshipInfo.StudentEnrolmentLevelInfo.EnrolmentLevelSysId;
            newRow["is_non_academic"] = studentScholarshipInfo.ScholarshipInfo.IsNonAcademic;
            newRow["scholarship_description"] = studentScholarshipInfo.ScholarshipInfo.ScholarshipDescription;
            newRow["sysid_scholarship"] = studentScholarshipInfo.ScholarshipInfo.ScholarshipSysId;
            newRow["sysid_studentscholarship"] = studentScholarshipInfo.StudentScholarshipSysId;

            _studentScholarshipTable.Rows.Add(newRow);

        }//------------------

        //this procedure will update student scholarship information
        public void UpdateStudentScholarshipInformation(CommonExchange.SysAccess userInfo, CommonExchange.StudentScholarship studentScholarshipInfo)
        {
            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                remClient.UpdateStudentScholarship(userInfo, studentScholarshipInfo);
            }

            Int32 index = 0;

            foreach (DataRow scholarRow in _studentScholarshipTable.Rows)
            {
                if (scholarRow.RowState != DataRowState.Deleted)
                {
                    DataRow editRow = _studentScholarshipTable.Rows[index];

                    editRow.BeginEdit();
                                        
                    editRow["sysid_enrolmentlevel"] = studentScholarshipInfo.StudentEnrolmentLevelInfo.EnrolmentLevelSysId;
                    editRow["is_non_academic"] = studentScholarshipInfo.ScholarshipInfo.IsNonAcademic;
                    editRow["scholarship_description"] = studentScholarshipInfo.ScholarshipInfo.ScholarshipDescription;
                    editRow["sysid_scholarship"] = studentScholarshipInfo.ScholarshipInfo.ScholarshipSysId;
                    editRow["sysid_studentscholarship"] = studentScholarshipInfo.StudentScholarshipSysId;
                    
                    editRow.EndEdit();
                }
                index++;
            }
        }//-------------------

        //this procedure will update scholarship information
        public void UpdateScholarshipInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScholarshipInformation scholarshipInfo)
        {
            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                remClient.UpdateScholarshipInformation(userInfo, scholarshipInfo);
            }

            Int32 index = 0;
            foreach (DataRow scholarRow in _classDataSet.Tables["ScholarshipInformationTable"].Rows)
            {
                if (String.Equals(scholarshipInfo.ScholarshipSysId, RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "sysid_scholarship", "")))
                {
                    DataRow editRow = _classDataSet.Tables["ScholarshipInformationTable"].Rows[index];

                    editRow.BeginEdit();

                    editRow["sysid_scholarship"] = scholarshipInfo.ScholarshipSysId;
                    editRow["course_group_id"] = scholarshipInfo.CourseGroupInfo.CourseGroupId;
                    editRow["department_id"] = scholarshipInfo.DepartmentInfo.DepartmentId;
                    editRow["department_name"] = scholarshipInfo.DepartmentInfo.DepartmentName;
                    editRow["department_acronym"] = scholarshipInfo.DepartmentInfo.Acronym;
                    editRow["is_non_academic"] = scholarshipInfo.IsNonAcademic;
                    editRow["scholarship_description"] = scholarshipInfo.ScholarshipDescription;
                   
                    editRow.EndEdit();
                }

                index++;
            }
        }//----------------------

        //this procedure will delete student scholarship information
        public void DeleteStudentScholarshipInformation(CommonExchange.SysAccess userInfo, CommonExchange.StudentScholarship studentScholarshipInfo)
        {
            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                remClient.DeleteStudentScholarship(userInfo, studentScholarshipInfo);
            }

            Int32 index = 0;

            foreach (DataRow scholarRow in _studentScholarshipTable.Rows)
            {
                if (scholarRow.RowState != DataRowState.Deleted && String.Equals(studentScholarshipInfo.StudentScholarshipSysId,
                    RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "sysid_studentscholarship", "")))
                {
                    DataRow delRow = _studentScholarshipTable.Rows[index];

                    delRow.Delete();
                }

                index++;
            }
        }//-------------------------

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                cboBase.Items.Add(yearRow["year_description"].ToString());

                if (!isIndexed)
                {
                    DateTime serverDateTime = DateTime.Parse(_serverDateTime);
                    DateTime dateStart = serverDateTime;
                    DateTime dateEnd = serverDateTime;

                    DateTime.TryParse(yearRow["date_start"].ToString(), out dateStart);
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd);

                    //if ((DateTime.Compare(serverDateTime, dateStart) >= 0 && DateTime.Compare(serverDateTime, dateEnd) <= 0) ||
                    //    (DateTime.Compare(serverDateTime.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance), dateStart) >= 0 &&
                    //     DateTime.Compare(serverDateTime.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance), dateEnd) <= 0))
                    //{
                    //    cboBase.SelectedIndex = index;
                    //    isIndexed = true;
                    //}

                    if (DateTime.Compare(serverDateTime, dateStart) >= 0 && DateTime.Compare(serverDateTime, dateEnd) <= 0)
                    {
                        cboBase.SelectedIndex = index;
                        isIndexed = true;
                    }

                    index++;
                }
            }
        } //---------------------------

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearComboManager(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                cboBase.Items.Add(yearRow["year_description"].ToString());

                if (!isIndexed)
                {
                    DateTime serverDateTime = DateTime.Parse(_serverDateTime);
                    DateTime dateStart = serverDateTime;
                    DateTime dateEnd = serverDateTime;

                    DateTime.TryParse(yearRow["date_start"].ToString(), out dateStart);
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd);

                    if ((DateTime.Compare(serverDateTime, dateStart) >= 0 && DateTime.Compare(serverDateTime, dateEnd) <= 0) ||
                        (DateTime.Compare(serverDateTime.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance), dateStart) >= 0 &&
                         DateTime.Compare(serverDateTime.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance), dateEnd) <= 0))
                    {
                        cboBase.SelectedIndex = index;
                        isIndexed = true;
                    }     

                    index++;
                }
            }
        } //---------------------------   

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearComboManagerWithOutSelectedIndex(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                cboBase.Items.Add(yearRow["year_description"].ToString());
            }

            cboBase.SelectedIndex = -1;
        } //---------------------------  

        //this procedure initializes the semester combo box
        public void InitializeSemesterCombo(ComboBox cboBase, Int32 yearIndex)
        {
            cboBase.Items.Clear();

            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            foreach (DataRow semRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", ""));
            }

            cboBase.SelectedIndex = -1;
        }//-----------------------------         

        //this procedure will initialize the course group combo
        public void InitializeCourseGroupCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow depRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(depRow, "group_description", ""));
            }

            cboBase.SelectedIndex = -1;
        }//-----------------------

        //this procedure will initialize the course group combo
        public void InitializeCourseGroupCombo(ComboBox cboBase, String courseGroupId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            foreach (DataRow depRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(depRow, "group_description", ""));

                if (!isIndexed)
                {
                    if (String.Equals(courseGroupId, RemoteServerLib.ProcStatic.DataRowConvert(depRow, "course_group_id", "")))
                    {
                        cboBase.SelectedIndex = index;
                        isIndexed = true;
                    }

                    index++;
                }
            }            
        }//-----------------------

        //this procedure will initialize scholarship combo
        public void InitializeDepartmentCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow depRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", "") + " [" +
                    RemoteServerLib.ProcStatic.DataRowConvert(depRow, "acronym", "") + "]");
            }

            cboBase.SelectedIndex = -1;
        }//----------------------

        //this procedure will initialize scholarship combo
        public void InitializeDepartmentCombo(ComboBox cboBase, String departmentId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndex = false;

            foreach (DataRow depRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", "") + " [" +
                   RemoteServerLib.ProcStatic.DataRowConvert(depRow, "acronym", "") + "]");

                if (!isIndex)
                {
                    if (String.Equals(departmentId, RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_id", "")))
                    {
                        cboBase.SelectedIndex = index;
                        isIndex = true;
                    }

                    index++;
                }
            }                       
        }//----------------------

        //this procedure initializes the department checkedlist box
        public void InitializeDepartmentCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            foreach (DataRow depRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
            {
                cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", "") + " [" +
                    RemoteServerLib.ProcStatic.DataRowConvert(depRow, "acronym", "") + "]");
            }
        }//------------------------

        //this procedure initialize the year level list box
        public void InitializeYearLevelCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["YearLevelInformationTable"] != null)
            {
                foreach (DataRow levelRow in _classDataSet.Tables["YearLevelInformationTable"].Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "group_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", ""));
                }
            }
        }//-----------------------------

        //this procedure initialized the course checked list box
        public void InitializeCourseCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["CourseInformationTable"] != null)
            {
                foreach (DataRow courseRow in _classDataSet.Tables["CourseInformationTable"].Rows)
                {
                    cbxBase.Items.Add(courseRow["course_title"].ToString() + " [" + courseRow["course_acronym"].ToString() + "]");
                }
            }
        }//-----------------------------------

        //this procedure initialize the scholarship list box
        public void InitializeScholarshipListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["ScholarshipInformationTable"] != null)
            {
                foreach (DataRow scholarRow in _classDataSet.Tables["ScholarshipInformationTable"].Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "scholarship_description", "") + " [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "department_acronym", "") + "]");
                }
            }
        }//---------------------

        //this procedure will initialized the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //--------------------------------

            //get dataset for scholarship manager
            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                _classDataSet = remClient.GetDataSetForScholarship(userInfo, _serverDateTime);
            }
        }//-------------------------       

        //this procedure refreshes the data
        public void RefreshScholarshipData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }//-------------------------------

        #endregion

        #region Programer-Defined Functions
        //this fucntion gets the search student scholarship
        public DataTable GetSearchedStudentScholarship(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd,
            String scholarshipSysIdList, String departmentIdList, String yearLevelIdList)
        {
            DataTable newTable = new DataTable("StudentSearchByStudentNameIdCardNumberTable");
            newTable.Columns.Add("sysid_studentscholarship", System.Type.GetType("System.String"));           
            newTable.Columns.Add("student_name", System.Type.GetType("System.String"));         
            newTable.Columns.Add("scholarship_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("card_number", System.Type.GetType("System.String"));
            newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("present_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
            newTable.Columns.Add("home_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("home_phone_nos", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_contact_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_relationship_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_present_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_present_phone_nos", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_home_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_home_phone_nos", System.Type.GetType("System.String"));

            if (!String.IsNullOrEmpty(queryString))
            {
                using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
                {
                    _studentScholarshipTable = remClient.SelectStudentScholarship(userInfo, queryString, dateStart, dateEnd,
                        scholarshipSysIdList, departmentIdList, yearLevelIdList);
                }
            }

            foreach (DataRow studentRow in _studentScholarshipTable.Rows)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_studentscholarship"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "sysid_studentscholarship", "");
                newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "last_name", "first_name", "middle_name");                
                newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_title", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_acronym", "");               
                newRow["scholarship_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "scholarship_description", "");
                newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "student_id", "");
                newRow["card_number"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "card_number", "");
                newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "year_level_description", "");
                newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_name", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_acronym", "");
                newRow["present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "present_address", "");
                newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "present_phone_nos", "");
                newRow["home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "home_address", "");
                newRow["home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "home_phone_nos", "");
                newRow["emer_contact_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "emer_last_name", "emer_first_name",
                    "emer_middle_name");
                newRow["emer_relationship_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_relationship_description", String.Empty);
                newRow["emer_present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_address", String.Empty);
                newRow["emer_present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_phone_nos", String.Empty);
                newRow["emer_home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_address", String.Empty);
                newRow["emer_home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_phone_nos", String.Empty);


                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();        

            return newTable;
        }//------------------------------

        //this function gets the selected student
        public DataTable GetSearchedStudentInformation(CommonExchange.SysAccess userInfo,
            String queryString, String dateStart, String dateEnd, String yearLevelId, String courseId)
        {
            DataTable newTable = new DataTable("StudentSearchByStudentNameIdCardNumberTable");
            newTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("card_number", System.Type.GetType("System.String"));
            newTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                _studentTable = remClient.SelectStudentInformation(userInfo, queryString, dateStart, dateEnd, courseId, yearLevelId);
            }

            foreach (DataRow studentRow in _studentTable.Rows)
            {
                DataRow newRow = newTable.NewRow();

                newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "student_id", "");
                newRow["card_number"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "card_number", "");
                newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "last_name", "first_name", "middle_name");
                newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_title", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_acronym", "");
                newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "year_level_description", "");
                newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_name", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_acronym", "");

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;
        }//-----------------------------

        //this function returns the student details
        public CommonExchange.Student GetDetailsStudentInformation(CommonExchange.SysAccess userInfo, String query, String startUp, Boolean isCreate)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            if (isCreate)
            {
                String strFilter = "student_id = '" + query + "'";
                DataRow[] selectRow = _studentTable.Select(strFilter);

                foreach (DataRow studRow in selectRow)
                {
                    studentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                    studentInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                    studentInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", "");
                    studentInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", "");
                    studentInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "");
                    studentInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_person", "");
                    studentInfo.CourseInfo.CourseTitle = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_title", String.Empty);
                    studentInfo.CourseInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "department_name", String.Empty);

                    break;
                }

            }
            else
            {
                String strFilter = "sysid_studentscholarship = '" + query + "'";
                DataRow[] selectRow = _studentScholarshipTable.Select(strFilter);

                foreach (DataRow studRow in selectRow)
                {
                    if (studRow.RowState != DataRowState.Deleted)
                    {
                        studentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                        studentInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                        studentInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", "");
                        studentInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", "");
                        studentInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "");
                        studentInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_person", "");

                        break;
                    }
                }
            }

            studentInfo.PersonInfo.FilePath = base.GetPersonImagePath(userInfo, studentInfo.PersonInfo.PersonSysId,
                studentInfo.PersonInfo.PersonImagesFolder(startUp));

            return studentInfo;
        }//----------------------------

        //this fucntion get the searched scholarship information
        public DataTable GetSearchedScholarshipInformation(String queryString)
        {
            DataTable newTable = new DataTable("NewTable");
            newTable.Columns.Add("sysid_scholarship", System.Type.GetType("System.String"));
            newTable.Columns.Add("scholarship_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("group_description", System.Type.GetType("System.String"));

            queryString = queryString.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "scholarship_description LIKE '%" + queryString + "%' OR department_name LIKE '%" + queryString + "%'";
            DataRow[] selectRow = _classDataSet.Tables["ScholarshipInformationTable"].Select(strFilter);

            foreach (DataRow scholarRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_scholarship"] = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "sysid_scholarship", "");
                newRow["scholarship_description"] = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "scholarship_description", "");
                newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "department_name", "") + " [" +
                    RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "department_acronym", "") + "]";
                newRow["group_description"] = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "group_description", String.Empty);

                newTable.Rows.Add(newRow);
            }

            return newTable;
        }//----------------------------
        
        //this function get student scholarship details
        public CommonExchange.StudentScholarship GetDetailsStudentScholarshipInformation(String sysidStudentScholarship)
        {
            CommonExchange.StudentScholarship studentScholarshipInfo = new CommonExchange.StudentScholarship();

            String strFilter = "sysid_studentscholarship = '" + sysidStudentScholarship + "'";
            DataRow[] selectRow = _studentScholarshipTable.Select(strFilter);

            foreach (DataRow studRow in selectRow)
            {
                if (studRow.RowState != DataRowState.Deleted)
                {
                    studentScholarshipInfo.StudentEnrolmentLevelInfo.EnrolmentLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");
                    studentScholarshipInfo.ScholarshipInfo.IsNonAcademic = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_non_academic", false);
                    studentScholarshipInfo.ScholarshipInfo.ScholarshipDescription = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "scholarship_description", "");
                    studentScholarshipInfo.ScholarshipInfo.ScholarshipSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_scholarship", "");
                    studentScholarshipInfo.StudentScholarshipSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_studentscholarship", "");
          
                    break;
                }                
            }

            return studentScholarshipInfo;
        }//-------------------------

        //this fucntion get scholarship details
        public CommonExchange.ScholarshipInformation GetDetailsScholarshipInformation(String sysidScolarship)
        {
            CommonExchange.ScholarshipInformation scholarshipInfo = new CommonExchange.ScholarshipInformation();

            String strFilter = "sysid_scholarship = '" + sysidScolarship + "'";
            DataRow[] selectRow = _classDataSet.Tables["ScholarshipInformationTable"].Select(strFilter);

            foreach (DataRow scholarRow in selectRow)
            {
                scholarshipInfo.CourseGroupInfo.CourseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "course_group_id", "");
                scholarshipInfo.DepartmentInfo.DepartmentId = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "department_id", "");
                scholarshipInfo.IsNonAcademic = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "is_non_academic", false);
                scholarshipInfo.ScholarshipDescription = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "scholarship_description", "");
                scholarshipInfo.ScholarshipSysId = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "sysid_scholarship", "");

                break;
            }

            return scholarshipInfo;
        }//------------------------

        //this fucntion determines if scholarship description already exist
        public Boolean IsExistsScholarshipDescriptionScholarshipInformation(CommonExchange.SysAccess userInfo, 
            CommonExchange.ScholarshipInformation scholarshipInfo)
        {
            Boolean value;

            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                value = remClient.IsExistsScholarshipDescriptionScholarshipInformation(userInfo, scholarshipInfo);
            }

            return value;
        }//---------------------------

        //this function determines if student scholarship already exsits
        public Boolean IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship(CommonExchange.SysAccess userInfo,
            CommonExchange.StudentScholarship studentScholarship)
        {
            Boolean value;

            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                value = remClient.IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship(userInfo, studentScholarship);
            }

            return value;
        }//--------------------------

        //this function returns enrolment level system id
        public String GetEnrolmentLevelSysId(String sysIdStudent)
        {
            String value = String.Empty;

            String strFilter = "sysid_student = '" + sysIdStudent + "'";
            DataRow[] selectRow = _studentTable.Select(strFilter);

            foreach (DataRow studRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");

                break;
            }

            return value;
        }//----------------------------

        //this function gets the school year date start
        public DateTime GetSchoolYearDateStart(String yearId)
        {
            DateTime dateStart = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                if (String.Equals(yearId, yearRow["year_id"].ToString()) &&
                    DateTime.TryParse(yearRow["date_start"].ToString(), out dateStart))
                {
                    break;
                }
            }

            return dateStart;
        }//----------------------------------------    

        //this function gets the school year date end
        public DateTime GetSchoolYearDateEnd(String yearId)
        {
            DateTime dateEnd = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                if (String.Equals(yearId, yearRow["year_id"].ToString()) &&
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd))
                {
                    break;
                }
            }

            return dateEnd;
        }//------------------------------

        //this function gets the semester date start
        public DateTime GetSemesterDateStart(String sysIdSemester)
        {
            DateTime dateStart = DateTime.Parse(_serverDateTime);

            foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                if (String.Equals(sysIdSemester, semRow["sysid_semester"].ToString()) &&
                    DateTime.TryParse(semRow["date_start"].ToString(), out dateStart))
                {
                    break;
                }
            }

            return dateStart;
        }//----------------------------------------    

        //this function gets the semester date end
        public DateTime GetSemesterDateEnd(String sysIdSemester)
        {
            DateTime dateEnd = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                if (String.Equals(sysIdSemester, yearRow["sysid_semester"].ToString()) &&
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd))
                {
                    break;
                }
            }

            return dateEnd;
        }//------------------------------

        //this function gets the school year year id
        public String GetSchoolYearYearId(Int32 index)
        {
            DataRow _yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[index];

            return _yearRow["year_id"].ToString();
        }//----------------------------

        //this function gets the semester system id
        public String GetSemesterSystemId(Int32 yearIndex, Int32 semIndex)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            DataRow semRow = selectRow[semIndex];

            return RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
        } //-----------------------------------------

        //this function gets year level id -- based on checklistbox
        private String GetYearLevelId(Int32 index)
        {
            DataRow levelRow = _classDataSet.Tables["YearLevelInformationTable"].Rows[index];

            return RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", "");
        }//-------------------------------

        //this fucntion gets the department description
        public String GetDepartmentDescription(String departmentId)
        {
            String value = String.Empty;

            String strFilter = "department_id = '" + departmentId + "'";
            DataRow[] selectRow = _classDataSet.Tables["DepartmentInformationTable"].Select(strFilter);

            foreach (DataRow depRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", "");

                break;
            }

            return value;
        }//---------------------

        //this fucntion gets the department description acronym
        public String GetDepartmentAcronym(String departmentId)
        {
            String value = String.Empty;

            String strFilter = "department_id = '" + departmentId + "'";
            DataRow[] selectRow = _classDataSet.Tables["DepartmentInformationTable"].Select(strFilter);

            foreach (DataRow depRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "acronym", "");

                break;
            }

            return value;
        }//---------------------

        //this function gets department id
        public CommonExchange.Department GetDepartmentInfo(Int32 index)
        {
            CommonExchange.Department departmentInfo = new CommonExchange.Department();

            DataRow depRow = _classDataSet.Tables["DepartmentInformationTable"].Rows[index];

            departmentInfo.Acronym = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "acronym", String.Empty);
            departmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", String.Empty);
            departmentInfo.DepartmentId = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_id", String.Empty);


            return departmentInfo;
        }//-------------------------------

        //this fucntion gets the course group id
        public CommonExchange.CourseGroup GetCourseGroupInformationDetails(Int32 index)
        {
            DataRow depRow = _classDataSet.Tables["CourseGroupTable"].Rows[index];

            CommonExchange.CourseGroup groupInfo = new CommonExchange.CourseGroup();

            groupInfo.CourseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "course_group_id", "");
            groupInfo.GroupDescription = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "group_description", "");

            return groupInfo;
        }//---------------------------

        //this function gets the course id
        private String GetCourseId(Int32 index)
        {
            if (_classDataSet.Tables["CourseInformationTable"] != null)
            {
                DataRow courseRow = _classDataSet.Tables["CourseInformationTable"].Rows[index];

                return courseRow["course_id"].ToString();
            }
            else
            {
                return String.Empty;
            }
        }//----------------------------

        //this fucntion gets the course group description
        public String GetCourseGroupDescription(String courseGroupId)
        {
            String value = String.Empty;

            String strFilter = "course_group_id = '" + courseGroupId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseGroupTable"].Select(strFilter);

            foreach (DataRow depRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "group_description", "");

                break;
            }

            return value;
        }//---------------------
        //this function gets scholarship id
        public String GetScholarshipId(Int32 index)
        {
            DataRow schlarRow = _classDataSet.Tables["ScholarshipInformationTable"].Rows[index];

            return RemoteServerLib.ProcStatic.DataRowConvert(schlarRow, "sysid_scholarship", "");
        }//-------------------------------

        //this fucntion gets the course yearlevel string format
        public String GetDepartmentYearLevelScholarshipStringFormat(CheckedListBox cbXBase, Boolean isYearLevel, Boolean isDepartment, Boolean isScholarship)
        {
            StringBuilder strValue = new StringBuilder();

            if (cbXBase.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = cbXBase.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    if (isYearLevel && (!isDepartment && !isScholarship))
                    {
                        strValue.Append(this.GetYearLevelId(x) + ", ");
                    }
                    else if (isDepartment && (!isYearLevel && !isScholarship))
                    {
                        strValue.Append(this.GetDepartmentInfo(x).DepartmentId + ", ");
                    }
                    else if (isScholarship && (!isYearLevel && !isDepartment))
                    {
                        strValue.Append(this.GetScholarshipId(x) + ", ");
                    }
                }
            }

            if (strValue.Length >= 2)
            {
                return strValue.ToString().Substring(0, strValue.Length - 2);
            }
            else
            {
                return String.Empty;
            }
        }//-------------------------

        //this fucntion gets the course yearlevel string format
        public String GetCourseYearLevelStringFormat(CheckedListBox cbXBase, Boolean isCourse)
        {
            StringBuilder strValue = new StringBuilder();

            if (cbXBase.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = cbXBase.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    if (isCourse)
                    {
                        strValue.Append(this.GetCourseId(x) + ", ");
                    }
                    else
                    {
                        strValue.Append(this.GetYearLevelId(x) + ", ");
                    }
                }
            }

            if (strValue.Length >= 2)
            {
                return strValue.ToString().Substring(0, strValue.Length - 2);
            }
            else
            {
                return String.Empty;
            }
        }//-------------------------        
        #endregion
    }
}

