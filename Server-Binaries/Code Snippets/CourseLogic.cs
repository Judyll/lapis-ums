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

        //this procedure inserts a new course information
        public void InsertCourseInformation(CommonExchange.SysAccess userInfo, CommonExchange.CourseInformation courseInfo)
        {
            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                remClient.InsertCourseInformation(userInfo, ref courseInfo);
            }

            if (_courseTable != null)
            {
                DataRow newRow = _courseTable.NewRow();

                newRow["course_id"] = courseInfo.CourseId;
                newRow["course_title"] = courseInfo.CourseTitle;
                newRow["acronym"] = courseInfo.Acronym;

                _courseTable.Rows.Add(newRow);
                _courseTable.AcceptChanges();
            }
            

        } //---------------------------

        //this procedure updates a course information
        public void UpdateCourseInformation(CommonExchange.SysAccess userInfo, CommonExchange.CourseInformation courseInfo)
        {
            using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
            {
                remClient.UpdateCourseInformation(userInfo, courseInfo);
            }

            if (_courseTable != null)
            {
                Int32 index = 0;

                foreach (DataRow courseRow in _courseTable.Rows)
                {
                    if (String.Equals(courseInfo.CourseId, courseRow["course_id"].ToString()))
                    {
                        DataRow editRow = _courseTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["course_title"] = courseInfo.CourseTitle;
                        editRow["acronym"] = courseInfo.Acronym;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }

                _courseTable.AcceptChanges();

            }
            
        } //-----------------------------------------

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
                newRow["employment_id"] = subjectInfo.EmploymentId;
                newRow["department_id"] = subjectInfo.DepartmentId;
                newRow["subject_code"] = subjectInfo.SubjectCode;
                newRow["descriptive_title"] = subjectInfo.DescriptiveTitle;
                newRow["lecture_units"] = subjectInfo.LectureUnits;
                newRow["lab_units"] = subjectInfo.LabUnits;
                newRow["no_hours"] = subjectInfo.NoHours;
                newRow["other_information"] = subjectInfo.OtherInformation;
                newRow["is_semestral"] = subjectInfo.IsSemestral;
                newRow["type_no"] = this.GetEmploymentTypeNo(subjectInfo.EmploymentId);
                newRow["department_name"] = subjectInfo.DepartmentName;

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

                        editRow["employment_id"] = subjectInfo.EmploymentId;
                        editRow["department_id"] = subjectInfo.DepartmentId;
                        editRow["subject_code"] = subjectInfo.SubjectCode;
                        editRow["descriptive_title"] = subjectInfo.DescriptiveTitle;
                        editRow["lecture_units"] = subjectInfo.LectureUnits;
                        editRow["lab_units"] = subjectInfo.LabUnits;
                        editRow["no_hours"] = subjectInfo.NoHours;
                        editRow["other_information"] = subjectInfo.OtherInformation;
                        editRow["is_semestral"] = subjectInfo.IsSemestral;
                        editRow["type_no"] = subjectInfo.TypeNo;
                        editRow["department_name"] = subjectInfo.DepartmentName;

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
        public void InitializeEmploymentTypeCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow typeRow in _classDataSet.Tables["EmploymentTypeTable"].Rows)
            {
                Byte typeNo = (Byte)typeRow["type_no"];

                if (typeNo <= (Byte)CommonExchange.EmploymentType.GradeKinderFaculty)
                {
                    cboBase.Items.Add(typeRow["type_description"].ToString());
                }
            }

        } //---------------------------

        //this procedure initializes the employment type combo box
        public void InitializeEmploymentTypeCombo(ComboBox cboBase, String typeId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            foreach (DataRow typeRow in _classDataSet.Tables["EmploymentTypeTable"].Rows)
            {
                Byte typeNo = (Byte)typeRow["type_no"];

                if (typeNo <= (Byte)CommonExchange.EmploymentType.GradeKinderFaculty)
                {
                    cboBase.Items.Add(typeRow["type_description"].ToString());
                }

                if (String.Equals(typeId, typeRow["employment_id"].ToString()))
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
            using (RemoteClient.RemCntGeneral remClient = new RemoteClient.RemCntGeneral())
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
            _requisiteTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
        } //----------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

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

        //this function gets the employment type id
        public String GetEmploymentTypeId(Int32 index)
        {
            String typeId = "";

            foreach (DataRow typeRow in _classDataSet.Tables["EmploymentTypeTable"].Rows)
            {
                if (index == (Byte)typeRow["type_no"])
                {
                    typeId = typeRow["employment_id"].ToString();
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
            newRow["descriptive_title"] = subjectInfo.DescriptiveTitle;

            _requisiteTable.Rows.Add(newRow);

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
                dbTable = remClient.GetBySubjectIdSubjectPrerequisiteTable(userInfo, subjectSysId);
            }

            _requisiteTable.Clear();

            foreach (DataRow preRow in dbTable.Rows)
            {
                DataRow newRow = _requisiteTable.NewRow();

                newRow["prerequisite_id"] = preRow["prerequisite_id"];
                newRow["prerequisite_subject"] = preRow["prerequisite_subject"];
                newRow["subject_code"] = preRow["subject_code"];
                newRow["descriptive_title"] = preRow["descriptive_title"];

                _requisiteTable.Rows.Add(newRow);
            }

            _requisiteTable.AcceptChanges();

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

        } //---------------------------------

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
        public CommonExchange.CourseInformation GetCourseInformationDetails(String courseSysId)
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
                    courseInfo.Acronym = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "acronym", "");
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
                    _courseTable = remClient.SelectByTitleAcronymCourseInformation(userInfo, queryString);
                }
            }

            DataTable newTable = new DataTable("CourseInformationSearchTable");
            newTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("acronym", System.Type.GetType("System.String"));

            if (_courseTable != null)
            {
                foreach (DataRow courseRow in _courseTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["course_id"] = courseRow["course_id"].ToString();
                    newRow["course_title"] = courseRow["course_title"].ToString();
                    newRow["acronym"] = courseRow["acronym"].ToString();

                    newTable.Rows.Add(newRow);
                }
            }            

            newTable.AcceptChanges();

            return newTable;
        } //--------------------------

        //this function returns a subject information details
        public CommonExchange.SubjectInformation GetSubjectInformationDetails(String subjectSysId)
        {
            CommonExchange.SubjectInformation subjectInfo = new CommonExchange.SubjectInformation();

            if (_subjectTable != null)
            {
                String strFilter = "sysid_subject = '" + subjectSysId + "'";
                DataRow[] selectRow = _subjectTable.Select(strFilter, "subject_code ASC");

                foreach (DataRow subjectRow in selectRow)
                {
                    subjectInfo.SubjectSysId = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "sysid_subject", "");
                    subjectInfo.EmploymentId = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "employment_id", "");
                    subjectInfo.DepartmentId = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "department_id", "");
                    subjectInfo.SubjectCode = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "subject_code", "");
                    subjectInfo.DescriptiveTitle = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "descriptive_title", "");
                    subjectInfo.LectureUnits = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "lecture_units", Byte.Parse("0"));
                    subjectInfo.LabUnits = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "lab_units", Byte.Parse("0"));
                    subjectInfo.NoHours = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "no_hours", "");
                    subjectInfo.OtherInformation = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "other_information", "");
                    subjectInfo.IsSemestral = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "is_semestral", false);
                    subjectInfo.TypeNo = this.GetEmploymentTypeNo(subjectInfo.EmploymentId);
                    subjectInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "department_name", "");
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
                    _subjectTable = remClient.SelectBySubjectCodeTitleSubjectInformation(userInfo, queryString);
                }
            }

            DataTable subjectTable = new DataTable("SubjectConcatCodeTitleTable");
            subjectTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
            subjectTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            subjectTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            if (_subjectTable != null)
            {
                foreach (DataRow subjectRow in _subjectTable.Rows)
                {
                    DataRow newRow = subjectTable.NewRow();

                    newRow["sysid_subject"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "sysid_subject", "");
                    newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "subject_code", "") + " - " +
                                            RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "descriptive_title", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "department_name", "");

                    subjectTable.Rows.Add(newRow);
                }
            }

            subjectTable.AcceptChanges();

            return subjectTable;

        } //--------------------------- 

        //this function returns a classroom information details
        public CommonExchange.ClassroomInformation GetClassroomInformationDetails(String roomId)
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
                    _classroomTable = remClient.SelectByCodeDescriptionCapacityClassroomInformation(userInfo, queryString);
                }
            }

            DataTable newTable = new DataTable("ClassroomInformationSearchTable");
            newTable.Columns.Add("sysid_classroom", System.Type.GetType("System.String"));
            newTable.Columns.Add("classroom_code", System.Type.GetType("System.String"));

            if (_classroomTable != null)
            {
                foreach (DataRow roomRow in _classroomTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_classroom"] = roomRow["sysid_classroom"].ToString();
                    newRow["classroom_code"] = roomRow["classroom_code"].ToString();

                    newTable.Rows.Add(newRow);
                }

            }
            
            newTable.AcceptChanges();

            return newTable;

        } //---------------------------    

        //this function gets the employment type no
        public Byte GetEmploymentTypeNo(String typeId)
        {
            Byte typeNo = 0;

            foreach (DataRow typeRow in _classDataSet.Tables["EmploymentTypeTable"].Rows)
            {
                if (String.Equals(typeId, typeRow["employment_id"].ToString()))
                {
                    typeNo = (Byte)typeRow["type_no"];
                    break;
                }
            }

            return typeNo;

        } //----------------------------

        
        #endregion
    }
}

