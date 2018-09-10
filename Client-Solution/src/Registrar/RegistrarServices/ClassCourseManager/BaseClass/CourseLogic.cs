using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace RegistrarServices
{
    internal class CourseLogic
    {
        #region Class General Variable Declarations
        private DataSet _classDataSet;        
        private Int64 _requisiteCounter;
        private DataTable _subjectTable;
        private DataTable _classroomTable;
        private DataTable _courseTable;
        #endregion

        #region Class Properties Declarations
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }

        private DataTable _requisiteTable;
        public DataTable PreRequisiteTableFormat
        {
            get { _requisiteTable.Rows.Clear(); return _requisiteTable; }
        }

        public DataTable SubjectTableFormat
        {
            get
            {
                DataTable subjectTableFormat = new DataTable("SubjectFormatTable");
                subjectTableFormat.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
                subjectTableFormat.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
                subjectTableFormat.Columns.Add("department_name", System.Type.GetType("System.String"));
                subjectTableFormat.Columns.Add("lecture_units", System.Type.GetType("System.Byte"));
                subjectTableFormat.Columns.Add("lab_units",  System.Type.GetType("System.Byte"));
                subjectTableFormat.Columns.Add("no_hours", System.Type.GetType("System.String"));

                return subjectTableFormat;
            }
        }
        #endregion

        #region Class Constructor

        public CourseLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
            this.InitializePreRequisiteTable();

            _requisiteCounter = 0;
        }       

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new subject information
        public void InsertSubjectInformation(CommonExchange.SysAccess userInfo, CommonExchange.SubjectInformation subjectInfo)
        {
            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                remClient.InsertSubjectInformation(userInfo, ref subjectInfo, _requisiteTable);
            }

            if (_subjectTable != null)
            {
                DataRow newRow = _subjectTable.NewRow();

                newRow["sysid_subject"] = subjectInfo.SubjectSysId;
                newRow["course_group_id"] = subjectInfo.CourseGroupInfo.CourseGroupId;
                newRow["department_id"] = subjectInfo.DepartmentInfo.DepartmentId;
                newRow["subject_code"] = subjectInfo.SubjectCode;
                newRow["descriptive_title"] = subjectInfo.DescriptiveTitle;
                newRow["lecture_units"] = subjectInfo.LectureUnits;
                newRow["lab_units"] = subjectInfo.LabUnits;
                newRow["no_hours"] = subjectInfo.NoHours;
                newRow["other_information"] = subjectInfo.OtherInformation;
                newRow["is_semestral"] = subjectInfo.CourseGroupInfo.IsSemestral;
                newRow["group_no"] = this.GetCourseGroupNo(subjectInfo.CourseGroupInfo.CourseGroupId);
                newRow["department_name"] = subjectInfo.DepartmentInfo.DepartmentName;
                newRow["is_non_academic"] = subjectInfo.IsNonAcademic;

                _subjectTable.Rows.Add(newRow);
                _subjectTable.AcceptChanges();

                _requisiteTable.AcceptChanges();

            }
        } //-------------------------------------

        //this procedure updates a subject information
        public void UpdateSubjectInformation(CommonExchange.SysAccess userInfo, CommonExchange.SubjectInformation subjectInfo)
        {
            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                remClient.UpdateSubjectInformation(userInfo, subjectInfo, _requisiteTable);
            }

            if (_subjectTable != null)
            {
                Int32 index = 0;

                foreach (DataRow subjectRow in _subjectTable.Rows)
                {
                    if (String.Equals(subjectInfo.SubjectSysId, subjectRow["sysid_subject"].ToString()))
                    {
                        DataRow editRow = _subjectTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["course_group_id"] = subjectInfo.CourseGroupInfo.CourseGroupId;
                        editRow["department_id"] = subjectInfo.DepartmentInfo.DepartmentId;
                        editRow["subject_code"] = subjectInfo.SubjectCode;
                        editRow["descriptive_title"] = subjectInfo.DescriptiveTitle;
                        editRow["lecture_units"] = subjectInfo.LectureUnits;
                        editRow["lab_units"] = subjectInfo.LabUnits;
                        editRow["no_hours"] = subjectInfo.NoHours;
                        editRow["other_information"] = subjectInfo.OtherInformation;
                        editRow["is_semestral"] = subjectInfo.CourseGroupInfo.IsSemestral;
                        editRow["group_no"] = subjectInfo.CourseGroupInfo.GroupNo;
                        editRow["department_name"] = subjectInfo.DepartmentInfo.DepartmentName;
                        editRow["is_non_academic"] = subjectInfo.IsNonAcademic;
                        
                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }

                _subjectTable.AcceptChanges();
                _requisiteTable.AcceptChanges();

            }
            
        } //--------------------------------

        //this procedure inserts a new classroom information
        public void InsertClassroomInformation(CommonExchange.SysAccess userInfo, CommonExchange.ClassroomInformation roomInfo)
        {
            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                remClient.InsertClassroomInformation(userInfo, ref roomInfo);
            }

            if (_classroomTable != null)
            {
                DataRow newRow = _classroomTable.NewRow();

                newRow["sysid_classroom"] = roomInfo.ClassroomSysId;
                newRow["classroom_code"] = roomInfo.ClassroomCode;
                newRow["classroom_description"] = roomInfo.Description;
                newRow["maximum_capacity"] = roomInfo.MaximumCapacity;
                newRow["other_information"] = roomInfo.OtherInformation;

                _classroomTable.Rows.Add(newRow);
                _classroomTable.AcceptChanges();
            }
            

        } //----------------------------

        //this procedure updates a classroom information
        public void UpdateClassroomInformation(CommonExchange.SysAccess userInfo, CommonExchange.ClassroomInformation roomInfo)
        {
            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                remClient.UpdateClassroomInformation(userInfo, roomInfo);
            }

            if (_classroomTable != null)
            {
                Int32 index = 0;

                foreach (DataRow roomRow in _classroomTable.Rows)
                {
                    if (String.Equals(roomInfo.ClassroomSysId, roomRow["sysid_classroom"].ToString()))
                    {
                        DataRow editRow = _classroomTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["classroom_code"] = roomInfo.ClassroomCode;
                        editRow["classroom_description"] = roomInfo.Description;
                        editRow["maximum_capacity"] = roomInfo.MaximumCapacity;
                        editRow["other_information"] = roomInfo.OtherInformation;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }

                _classroomTable.AcceptChanges();
            }
            

        } //-----------------------------------

        //this procedure initializes the department combo box
        public void InitializeDepartmentCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow deptRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
            {
                cboBase.Items.Add(deptRow["department_name"].ToString() + " [" + deptRow["acronym"].ToString() + "]");
            }

        } //---------------------------

        //this procedure initializes the department combo box
        public void InitializeSubjectCategoryCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow catRow in _classDataSet.Tables["SubjectCategoryTable"].Rows)
            {
                cboBase.Items.Add(catRow["category_name"].ToString() + " [" + catRow["acronym"].ToString() + "]");
            }

        } //---------------------------

        //this procedure initializes the employment type combo box
        public void InitializeDepartmentCombo(ComboBox cboBase, String deptId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            foreach (DataRow deptRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
            {
                cboBase.Items.Add(deptRow["department_name"].ToString() + " [" + deptRow["acronym"].ToString() + "]");

                if (String.Equals(deptId, deptRow["department_id"].ToString()))
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }

        } //---------------------------

        //this procedure initializes the employment type combo box
        public void InitializeSubjectCategoryCombo(ComboBox cboBase, String categoryId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            foreach (DataRow catRow in _classDataSet.Tables["SubjectCategoryTable"].Rows)
            {
                cboBase.Items.Add(catRow["category_name"].ToString() + " [" + catRow["acronym"].ToString() + "]");

                if (String.Equals(categoryId, catRow["category_id"].ToString()))
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }

        } //---------------------------

        //this procedure initializes the course group combo box
        public void InitializeCourseGroupCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow typeRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                cboBase.Items.Add(typeRow["group_description"].ToString());
            }

        } //---------------------------

        //this procedure initializes the course group combo box
        public void InitializeCourseGroupCombo(ComboBox cboBase, String groupId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            foreach (DataRow typeRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                cboBase.Items.Add(typeRow["group_description"].ToString());

                if (String.Equals(groupId, typeRow["course_group_id"].ToString()))
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }

        } //---------------------------

        //this procedure refreshes the classroom subject data
        public void RefreshClassroomSubjectData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        } //--------------------------------

        //this procedure initializes the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //----------------------

            //gets the dataset for the course manager
            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                _classDataSet = remClient.GetDataSetForClassroomSubject(userInfo);
            } //-----------------------
        } //-----------------------

        //this procedure initializes the prerequisite table
        private void InitializePreRequisiteTable()
        {
            _requisiteTable = new DataTable("SubjectPrerequisiteTable");
            _requisiteTable.Columns.Add("prerequisite_id", System.Type.GetType("System.Int64"));            
            _requisiteTable.Columns.Add("prerequisite_subject", System.Type.GetType("System.String"));
            _requisiteTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            _requisiteTable.Columns.Add("descriptive_title_no_freeze", System.Type.GetType("System.String"));
            _requisiteTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            _requisiteTable.Columns.Add("lecture_units", System.Type.GetType("System.Byte"));
            _requisiteTable.Columns.Add("lab_units", System.Type.GetType("System.Byte"));
            _requisiteTable.Columns.Add("no_hours", System.Type.GetType("System.String"));
        } //----------------------------------

        #endregion

        #region Programmer-Defined Function Procedures
        //this function will get subject category information details
        public CommonExchange.SubjectCategory GetDetailsSubjectCategoryDetails(Int32 categoryId)
        {
            CommonExchange.SubjectCategory categoryInfo = new CommonExchange.SubjectCategory();

            if (_classDataSet.Tables["SubjectCategoryTable"] != null)
            {
                DataRow catRow = _classDataSet.Tables["SubjectCategoryTable"].Rows[categoryId];

                categoryInfo.Acronym = RemoteServerLib.ProcStatic.DataRowConvert(catRow, "acronym", String.Empty);
                categoryInfo.CategoryId = RemoteServerLib.ProcStatic.DataRowConvert(catRow, "category_id", String.Empty);
                categoryInfo.CategoryName = RemoteServerLib.ProcStatic.DataRowConvert(catRow, "category_name", String.Empty);
                categoryInfo.CategoryNo = RemoteServerLib.ProcStatic.DataRowConvert(catRow, "category_no", Byte.Parse("0"));
                
            }

            return categoryInfo;
        }//-----------------------------

        //this function gets the department id
        public String GetDepartmentId(Int32 index)
        {
            DataRow deptRow = _classDataSet.Tables["DepartmentInformationTable"].Rows[index];
            
            return deptRow["department_id"].ToString();

        } //----------------------------

        //this function gets the department name
        public String GetDepartmentName(Int32 index)
        {
            DataRow deptRow = _classDataSet.Tables["DepartmentInformationTable"].Rows[index];

            return deptRow["department_name"].ToString();

        } //----------------------------

        //this function gets the group id
        public String GetCourseGroupId(Int32 index)
        {
            String typeId = "";

            foreach (DataRow typeRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                if (index == (Byte)typeRow["group_no"])
                {
                    typeId = typeRow["course_group_id"].ToString();
                    break;
                }
            }

            return typeId;

        } //----------------------------

        //this function determines if there has been changes in the pre-requisite list
        public Boolean HasPreRequisiteListChanges()
        {
            Boolean hasChanges = false;

            foreach (DataRow preRow in _requisiteTable.Rows)
            {
                if (preRow.RowState != DataRowState.Unchanged)
                {
                    hasChanges = true;
                    break;
                }
            }

            return hasChanges;
        } //-----------------------------------

        //this function determines if the prerequisite subject already exists
        public Boolean IsExistsPrerequisiteSubject(String subjectSysId)
        {
            Boolean isExist = false;

            foreach (DataRow preRow in _requisiteTable.Rows)
            {
                if (preRow.RowState != DataRowState.Deleted &&
                    String.Equals(subjectSysId, preRow["prerequisite_subject"].ToString()))
                {
                    isExist = true;
                    break;
                }
            }

            return isExist;
        } //---------------------------

        //this function adds a new prerequisite subject
        public DataTable AddPrerequisiteSubject(CommonExchange.SubjectInformation subjectInfo)
        {            
            DataRow newRow = _requisiteTable.NewRow();

            newRow["prerequisite_id"] = --_requisiteCounter;
            newRow["prerequisite_subject"] = subjectInfo.SubjectSysId;
            newRow["subject_code"] = subjectInfo.SubjectCode;
            newRow["descriptive_title_no_freeze"] = subjectInfo.DescriptiveTitle;
            newRow["department_name"] = subjectInfo.DepartmentInfo.DepartmentName;
            newRow["lecture_units"] =  subjectInfo.LectureUnits;
            newRow["lab_units"] = subjectInfo.LabUnits;
            newRow["no_hours"] = subjectInfo.NoHours;

            _requisiteTable.Rows.Add(newRow);

            DataTable newTable = new DataTable("SubjectPrerequisiteTempTable");
            newTable.Columns.Add("prerequisite_id", System.Type.GetType("System.Int64"));
            newTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("descriptive_title_no_freeze", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("lecture_units", System.Type.GetType("System.Byte"));
            newTable.Columns.Add("lab_units", System.Type.GetType("System.Byte"));
            newTable.Columns.Add("no_hours", System.Type.GetType("System.String"));


            DataRow[] selectRow = _requisiteTable.Select("", "subject_code ASC");

            foreach (DataRow preRow in selectRow)
            {
                DataRow tempRow = newTable.NewRow();

                tempRow["prerequisite_id"] = preRow["prerequisite_id"];
                tempRow["subject_code"] = preRow["subject_code"];
                tempRow["descriptive_title_no_freeze"] = preRow["descriptive_title_no_freeze"];
                tempRow["department_name"] = preRow["department_name"];
                tempRow["lecture_units"] = preRow["lecture_units"];
                tempRow["lab_units"] = preRow["lab_units"];
                tempRow["no_hours"] = preRow["no_hours"];

                newTable.Rows.Add(tempRow);
            }

            newTable.AcceptChanges();

            return newTable;
        } //--------------------------------

        //this function deletes a prerequisite subject
        public DataTable DeletePrerequisiteSubject(Int64 preRequisiteId)
        {
            Int32 index = 0;

            foreach (DataRow subjectRow in _requisiteTable.Rows)
            {
                if (subjectRow.RowState != DataRowState.Deleted &&
                    preRequisiteId == RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "prerequisite_id", Int64.Parse("0")))
                {
                    if (subjectRow.RowState == DataRowState.Modified || subjectRow.RowState == DataRowState.Added)
                    {
                        subjectRow.AcceptChanges();
                    }

                    DataRow delRow = _requisiteTable.Rows[index];

                    delRow.Delete();
                    
                }

                index++;
            }

            DataTable newTable = new DataTable("SubjectPrerequisiteTempTable");
            newTable.Columns.Add("prerequisite_id", System.Type.GetType("System.Int64"));
            newTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));

            DataRow[] selectRow = _requisiteTable.Select("", "subject_code ASC");

            foreach (DataRow preRow in selectRow)
            {
                DataRow tempRow = newTable.NewRow();

                tempRow["prerequisite_id"] = preRow["prerequisite_id"];
                tempRow["subject_code"] = preRow["subject_code"];
                tempRow["descriptive_title"] = preRow["descriptive_title"];

                newTable.Rows.Add(tempRow);
            }

            newTable.AcceptChanges();

            return newTable;
        } //--------------------------

        //this function is used to get the subject prerequisite by subject id
        public DataTable GetBySubjectIdSubjectPrerequisiteTable(CommonExchange.SysAccess userInfo, String subjectSysId)
        {
            DataTable dbTable;

            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                dbTable = remClient.SelectBySubjectIDSubjectPrerequisite(userInfo, subjectSysId);
            }

            _requisiteTable.Clear();

            foreach (DataRow preRow in dbTable.Rows)
            { 
                DataRow newRow = _requisiteTable.NewRow();
                
                newRow["prerequisite_id"] = preRow["prerequisite_id"];
                newRow["prerequisite_subject"] = preRow["prerequisite_subject"];
                newRow["subject_code"] = preRow["subject_code"];
                newRow["descriptive_title_no_freeze"] = preRow["descriptive_title"];
                newRow["department_name"] = preRow["department_name"];
                newRow["lecture_units"] = preRow["lecture_units"];
                newRow["lab_units"] = preRow["lab_units"];
                newRow["no_hours"] = preRow["no_hours"];

                _requisiteTable.Rows.Add(newRow);
            }

            _requisiteTable.AcceptChanges();

            DataTable newTable = new DataTable("SubjectPrerequisiteTempTable");
            newTable.Columns.Add("prerequisite_id", System.Type.GetType("System.Int64"));
            newTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("descriptive_title_no_freeze", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("lecture_units", System.Type.GetType("System.Byte"));
            newTable.Columns.Add("lab_units", System.Type.GetType("System.Byte"));
            newTable.Columns.Add("no_hours", System.Type.GetType("System.String"));

            DataRow[] selectRow = _requisiteTable.Select("", "subject_code ASC");

            foreach (DataRow preRow in selectRow)
            {
                DataRow tempRow = newTable.NewRow();

                tempRow["prerequisite_id"] = preRow["prerequisite_id"];
                tempRow["subject_code"] = preRow["subject_code"];
                tempRow["descriptive_title_no_freeze"] = preRow["descriptive_title_no_freeze"];
                tempRow["department_name"] = preRow["department_name"];
                tempRow["lecture_units"] = preRow["lecture_units"];
                tempRow["lab_units"] = preRow["lab_units"];
                tempRow["no_hours"] = preRow["no_hours"];

                newTable.Rows.Add(tempRow);
            }

            newTable.AcceptChanges();

            return newTable;

        }//---------------------------------

        //this function determines if the classroom code exist
        public Boolean IsExistCodeClassroomInformation(CommonExchange.SysAccess userInfo, String roomCode, String roomSysId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                isExist = remClient.IsExistCodeClassroomInformation(userInfo, roomCode, roomSysId);
            }

            return isExist;

        } //----------------------------------

        //this function determines if the subject code and descriptive title exist
        public Boolean IsExistCodeDescriptionSubjectInformation(CommonExchange.SysAccess userInfo, CommonExchange.SubjectInformation subjectInfo)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                isExist = remClient.IsExistCodeDescriptionSubjectInformation(userInfo, subjectInfo);
            }

            return isExist;
        } //--------------------------------

        //this function determines if the course title and acronym exist
        public Boolean IsExistTitleAcronymCourseInformation(CommonExchange.SysAccess userInfo, CommonExchange.CourseInformation courseInfo)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                isExist = remClient.IsExistTitleAcronymCourseInformation(userInfo, courseInfo);
            }

            return isExist;
        } //--------------------------------

        //this function returns a course information details
        public CommonExchange.CourseInformation GetDetailsCourseInformation(String courseSysId)
        {
            CommonExchange.CourseInformation courseInfo = new CommonExchange.CourseInformation();

            if (_courseTable != null)
            {
                String strFilter = "course_id = '" + courseSysId + "'";
                DataRow[] selectRow = _courseTable.Select(strFilter, "course_id ASC");

                foreach (DataRow courseRow in selectRow)
                {
                    courseInfo.CourseId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                    courseInfo.CourseTitle = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "");
                    courseInfo.Acronym = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "");
                }
            }            

            return courseInfo;
        } //-------------------------------------

        //this function returns a searched course information
        public DataTable GetSearchedCourseInformation(CommonExchange.SysAccess userInfo, String queryString, Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
                {
                    _courseTable = remClient.SelectCourseInformation(userInfo, queryString);
                }
            }

            DataTable newTable = new DataTable("CourseInformationSearchTable");
            newTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));

            if (_courseTable != null)
            {
                foreach (DataRow courseRow in _courseTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["course_id"] = courseRow["course_id"].ToString();
                    newRow["course_title"] = courseRow["course_title"].ToString();
                    newRow["course_acronym"] = courseRow["course_acronym"].ToString();

                    newTable.Rows.Add(newRow);
                }
            }            

            newTable.AcceptChanges();

            return newTable;
        } //--------------------------

        //this function returns a subject information details
        public CommonExchange.SubjectInformation GetDetailsSubjectInformation(String subjectSysId)
        {
            CommonExchange.SubjectInformation subjectInfo = new CommonExchange.SubjectInformation();

            if (_subjectTable != null)
            {
                String strFilter = "sysid_subject = '" + subjectSysId + "'";
                DataRow[] selectRow = _subjectTable.Select(strFilter, "subject_code ASC");

                foreach (DataRow subjectRow in selectRow)
                {
                    subjectInfo.SubjectSysId = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "sysid_subject", "");
                    subjectInfo.CourseGroupInfo.CourseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "course_group_id", "");
                    subjectInfo.DepartmentInfo.DepartmentId = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "department_id", "");
                    subjectInfo.SubjectCode = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "subject_code", "");
                    subjectInfo.DescriptiveTitle = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "descriptive_title", "");
                    subjectInfo.LectureUnits = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "lecture_units", Byte.Parse("0"));
                    subjectInfo.LabUnits = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "lab_units", Byte.Parse("0"));
                    subjectInfo.NoHours = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "no_hours", "");
                    subjectInfo.OtherInformation = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "other_information", "");
                    subjectInfo.CourseGroupInfo.IsSemestral = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "is_semestral", false);
                    subjectInfo.CourseGroupInfo.GroupNo = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "group_no", Byte.Parse("0"));
                    subjectInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "department_name", "");
                    subjectInfo.IsNonAcademic = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "is_non_academic", false);
                    subjectInfo.CategoryInfo.CategoryId = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "category_id", String.Empty);
                    subjectInfo.IsOpenAccess = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "is_open_access", false);
                }
            }            

            return subjectInfo;
        } //--------------------------------------

        //this function returns a searched subject information
        public DataTable GetSearchedSubjectInformation(CommonExchange.SysAccess userInfo, String queryString, Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
                {
                    _subjectTable = remClient.SelectSubjectInformation(userInfo, queryString);
                }
            }

            DataTable subjectTable = new DataTable("SubjectConcatCodeTitleTable");
            subjectTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
            subjectTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            subjectTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            subjectTable.Columns.Add("lecture_units", System.Type.GetType("System.Byte"));
            subjectTable.Columns.Add("lab_units", System.Type.GetType("System.Byte"));
            subjectTable.Columns.Add("no_hours", System.Type.GetType("System.String"));


            if (_subjectTable != null)
            {

                foreach (DataRow subjectRow in _subjectTable.Rows)
                {
                    DataRow newRow = subjectTable.NewRow();

                    newRow["sysid_subject"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "sysid_subject", String.Empty);
                    newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "subject_code", String.Empty) + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "descriptive_title", String.Empty);
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "department_name", String.Empty);
                    newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "lecture_units", Byte.Parse("0"));
                    newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "lab_units", Byte.Parse("0"));
                    newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "no_hours", String.Empty);

                    subjectTable.Rows.Add(newRow);
                }
            }

            subjectTable.AcceptChanges();

            return subjectTable;

        } //--------------------------- 

        //this function returns a searched subject information
        public DataTable GetSearchedSubjectInformation(CommonExchange.SysAccess userInfo, String queryString, String departmentId, Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
                {
                    _subjectTable = remClient.SelectSubjectInformation(userInfo, queryString);
                }
            }
            
            DataTable subjectTable = new DataTable("SubjectConcatCodeTitleTable");
            subjectTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
            subjectTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            subjectTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            subjectTable.Columns.Add("lecture_units", System.Type.GetType("System.Byte"));
            subjectTable.Columns.Add("lab_units", System.Type.GetType("System.Byte"));
            subjectTable.Columns.Add("no_hours", System.Type.GetType("System.String"));


            if (_subjectTable != null)
            {
                String strFilter = "department_id = '" + departmentId + "'";
                DataRow[] selectRow = _subjectTable.Select(strFilter);

                foreach (DataRow subjectRow in selectRow)
                {
                    DataRow newRow = subjectTable.NewRow();

                    newRow["sysid_subject"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "sysid_subject", String.Empty);
                    newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "subject_code", String.Empty) + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "descriptive_title", String.Empty);
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "department_name", String.Empty);
                    newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "lecture_units", Byte.Parse("0"));
                    newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "lab_units", Byte.Parse("0"));
                    newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "no_hours", String.Empty);

                    subjectTable.Rows.Add(newRow);
                }
            }

            subjectTable.AcceptChanges();

            return subjectTable;

        } //--------------------------- 

        //this function returns a classroom information details
        public CommonExchange.ClassroomInformation GetDetailsClassroomInformation(String roomId)
        {
            CommonExchange.ClassroomInformation roomInfo = new CommonExchange.ClassroomInformation();

            if (_classroomTable != null)
            {
                String strFilter = "sysid_classroom = '" + roomId + "'";
                DataRow[] selectRow = _classroomTable.Select(strFilter, "classroom_code ASC");

                foreach (DataRow roomRow in selectRow)
                {
                    roomInfo.ClassroomSysId = RemoteServerLib.ProcStatic.DataRowConvert(roomRow, "sysid_classroom", "");
                    roomInfo.ClassroomCode = RemoteServerLib.ProcStatic.DataRowConvert(roomRow, "classroom_code", "");
                    roomInfo.Description = RemoteServerLib.ProcStatic.DataRowConvert(roomRow, "classroom_description", "");
                    roomInfo.MaximumCapacity = RemoteServerLib.ProcStatic.DataRowConvert(roomRow, "maximum_capacity", Byte.Parse("0"));
                    roomInfo.OtherInformation = RemoteServerLib.ProcStatic.DataRowConvert(roomRow, "other_information", "");
                } 
            }            

            return roomInfo;
        } //--------------------------------------

        //this function returns a searched classroom information
        public DataTable GetSearchedClassroomInformation(CommonExchange.SysAccess userInfo, String queryString, Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
                {
                    _classroomTable = remClient.SelectClassroomInformation(userInfo, queryString);
                }
            }

            DataTable newTable = new DataTable("ClassroomInformationSearchTable");
            newTable.Columns.Add("sysid_classroom", System.Type.GetType("System.String"));
            newTable.Columns.Add("classroom_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("classroom_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("maximum_capacity", System.Type.GetType("System.Byte"));

            if (_classroomTable != null)
            {
                foreach (DataRow roomRow in _classroomTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_classroom"] = roomRow["sysid_classroom"].ToString();
                    newRow["classroom_code"] = roomRow["classroom_code"].ToString();
                    newRow["classroom_description"] = roomRow["classroom_description"].ToString();
                    newRow["maximum_capacity"] = roomRow["maximum_capacity"].ToString();

                    newTable.Rows.Add(newRow);
                }
            }
            
            newTable.AcceptChanges();

            return newTable;

        } //---------------------------    

        //this function gets the course group no
        public Byte GetCourseGroupNo(String groupId)
        {
            Byte groupNo = 0;

            foreach (DataRow typeRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                if (String.Equals(groupId, typeRow["course_group_id"].ToString()))
                {
                    groupNo = (Byte)typeRow["group_no"];
                    break;
                }
            }

            return groupNo;

        } //----------------------------

        //this function gets the course group no
        public Boolean GetCourseGroupIsSemestral(String groupId)
        {
            Boolean isSemestral = false;

            foreach (DataRow typeRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                if (String.Equals(groupId, typeRow["course_group_id"].ToString()))
                {
                    isSemestral = (Boolean)typeRow["is_semestral"];
                    break;
                }
            }

            return isSemestral;

        } //----------------------------

        
        #endregion
    }
}

