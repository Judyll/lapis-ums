using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace RegistrarServices
{
    internal class MajorExamScheduleLogic
    {
        #region Class Data Member Declaration
        private DataSet _classDataSet;
        private DataTable _majorExamScheduleTable;
        #endregion

        #region Class Properties Declarations
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }
        #endregion

        #region Class Constructor
        public MajorExamScheduleLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }
        #endregion

        #region Programer-Defined Procedures
        //this will initialize the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //----------------------

            //gets the dataset for the course manager
            using (RemoteClient.RemCntMajorExamScheduleManager remClient = new RemoteClient.RemCntMajorExamScheduleManager())
            {
                _classDataSet = remClient.GetDataSetForMajorExamSchedule(userInfo, _serverDateTime);
            } //-----------------------
        }//-------------------------------

        //this procedure refreshes the data
        public void RefreshStudentData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }//-------------------------------

        //this procedure will insert major exam schedule
        public void InsertMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule majorExamScheduleInfo)
        {
            using (RemoteClient.RemCntMajorExamScheduleManager remClient = new RemoteClient.RemCntMajorExamScheduleManager())
            {
                remClient.InsertMajorExamSchedule(userInfo, majorExamScheduleInfo);
            }
        }//--------------------------

        //this procedure will update major exam schedule
        public void UpdateMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule majorExamScheduleInfo)
        {
            using (RemoteClient.RemCntMajorExamScheduleManager remClient = new RemoteClient.RemCntMajorExamScheduleManager())
            {
                remClient.UpdateMajorExamSchedule(userInfo, majorExamScheduleInfo);
            }

            Int32 index = 0;
            foreach (DataRow examRow in _majorExamScheduleTable.Rows)
            {
                if (examRow.RowState != DataRowState.Deleted)
                {
                    if (majorExamScheduleInfo.MajorExamId == RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0")))
                    {
                        DataRow editRow = _majorExamScheduleTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["course_group_id"] = majorExamScheduleInfo.CourseGroupId;
                        editRow["exam_date"] = majorExamScheduleInfo.ExamDate;
                        editRow["exam_description"] = majorExamScheduleInfo.ExamDescription;
                        editRow["exam_information_id"] = majorExamScheduleInfo.ExamInformationId;
                        editRow["group_description"] = majorExamScheduleInfo.GroupDescription;
                        editRow["sysid_semester"] = majorExamScheduleInfo.SemesterSysId;
                        editRow["year_id"] = majorExamScheduleInfo.YearId;

                        editRow.EndEdit();
                    }

                    index++;
                }
            }
        }//----------------------------

        //this procedure will delete major exam schedule
        public void DeleteMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule majorExamScheduleInfo)
        {
            using (RemoteClient.RemCntMajorExamScheduleManager remClient = new RemoteClient.RemCntMajorExamScheduleManager())
            {
                remClient.DeleteMajorExamSchedule(userInfo, majorExamScheduleInfo);
            }

            Int32 index = 0;
            foreach (DataRow examRow in _majorExamScheduleTable.Rows)
            {
                if (examRow.RowState != DataRowState.Deleted)
                {
                    if (majorExamScheduleInfo.MajorExamId == RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0")))
                    {
                        DataRow delRow = _majorExamScheduleTable.Rows[index];

                        delRow.Delete();
                    }

                    index++;
                }
            }

        }//--------------------------

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
        }//---------------------------   

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearComboManager(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                cboBase.Items.Add(yearRow["year_description"].ToString());
            }

            cboBase.SelectedIndex = -1;
        } //---------------------------   

        //this procedure initialize school year combo
        public void InitializeSchoolYearCombo(ComboBox cboBase, String schoolYearId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            if (_classDataSet.Tables["SchoolFeeInformationTable"] != null)
            {
                foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
                {
                    cboBase.Items.Add(yearRow["year_description"].ToString());

                    if (!isIndexed)
                    {
                        if (String.Equals(schoolYearId, RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", "")))
                        {
                            cboBase.SelectedIndex = index;
                            isIndexed = true;
                        }

                        index++;
                    }
                }
            }
        }//--------------------

        //this procedure initializes the semester combo box
        public void InitializeSemesterCombo(ComboBox cboBase, Int32 yearIndex)
        {
            cboBase.Items.Clear();

            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            foreach (DataRow semRow in selectRow)
            {
                cboBase.Items.Add(semRow["semester_description"].ToString());
            }

            cboBase.SelectedIndex = -1;
        }//-----------------------------

        //this procedure initialize semester combo
        public void InitializeSemesterCombo(ComboBox cboBase, String sysIdSysmester, String yearId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            String strFilter = "year_id = '" + yearId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            foreach (DataRow semRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", ""));

                if (!isIndexed)
                {
                    if (String.Equals(sysIdSysmester, RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "")))
                    {
                        cboBase.SelectedIndex = index;
                        isIndexed = true;
                    }

                    index++;
                }
            }            
        }//--------------------

        //this procedure initialize the major exam schedule information combo
        public void InitializeMajorExamInfoCombo(ComboBox cboBase, String courseGroupId)
        {
            cboBase.Items.Clear();

            if (_classDataSet.Tables["MajorExamInformationTable"] != null)
            {
                String strFilter = "course_group_id = '" + courseGroupId + "'";
                DataRow[] selectRow = _classDataSet.Tables["MajorExamInformationTable"].Select(strFilter);

                foreach (DataRow examRow in selectRow)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "group_description", ""));
                }
            }
        }//--------------------

        //this procedure initialize the major exam schedule information combo
        public void InitializeMajorExamInfoCombo(ComboBox cboBase, String courseGroupId, String examInformationId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            if (_classDataSet.Tables["MajorExamInformationTable"] != null)
            {
                String strFilter = "course_group_id = '" + courseGroupId + "'";
                DataRow[] selectRow = _classDataSet.Tables["MajorExamInformationTable"].Select(strFilter);

                foreach (DataRow examRow in selectRow)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "group_description", ""));

                    if (!isIndexed)
                    {
                        if (String.Equals(examInformationId, RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_information_id", "")))
                        {
                            cboBase.SelectedIndex = index;
                            isIndexed = true;
                        }

                        index++;
                    }
                }
            }
        }//--------------------

        //this procedure initialize the course group combo
        public void InitializeCourseGroupCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            if (_classDataSet.Tables["CourseGroupTable"] != null)
            {
                foreach (DataRow courseRow in _classDataSet.Tables["CourseGroupTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "group_description", ""));
                }
            }

        }//-------------------

        //this procedure initialize the course group combo
        public void InitializeCourseGroupCombo(ComboBox cboBase, String courseGroupId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            if (_classDataSet.Tables["CourseGroupTable"] != null)
            {
                foreach (DataRow courseRow in _classDataSet.Tables["CourseGroupTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "group_description", ""));

                    if (!isIndexed)
                    {
                        if (String.Equals(courseGroupId, RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_group_id", "")))
                        {
                            cboBase.SelectedIndex = index;
                            isIndexed = true;
                        }

                        index++;
                    }
                }
            }
        }//--------------------

        //this procedure initialized the course group list box
        public void InitializeCourseGroupCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["CourseGroupTable"] != null)
            {
                foreach (DataRow courseRow in _classDataSet.Tables["CourseGroupTable"].Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "group_description", ""));
                }
            }
        }//-----------------------------------

        //this procedure initialize the exam schedule information list box
        public void InitializeMajorExamInformationCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["MajorExamInformationTable"] != null)
            {
                foreach (DataRow examRow in _classDataSet.Tables["MajorExamInformationTable"].Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "group_description", ""));
                }
            }
        }//-----------------------------
        #endregion

        #region Programer-Defined Functions       

        //this function will get search major exam schedule
        public DataTable GetSearchMajorExamSchedule(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String courseGoupList, String examInformationList)
        {
            DataTable newTable = new DataTable("MajorExamTable");
            newTable.Columns.Add("major_exam_id", System.Type.GetType("System.Int64"));
            newTable.Columns.Add("exam_date", System.Type.GetType("System.String"));
            newTable.Columns.Add("exam_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("group_description", System.Type.GetType("System.String"));

            using (RemoteClient.RemCntMajorExamScheduleManager remClient = new RemoteClient.RemCntMajorExamScheduleManager())
            {
                _majorExamScheduleTable = remClient.SelectMajorExamSchedule(userInfo, dateStart, dateEnd, courseGoupList, examInformationList, _serverDateTime);
            }

            foreach (DataRow examRow in _majorExamScheduleTable.Rows)
            {
                DataRow newRow = newTable.NewRow();

                newRow["major_exam_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0"));
                newRow["exam_date"] = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", "")).ToLongDateString();
                newRow["exam_description"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "");
                newRow["group_description"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "group_description", "");

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;
        }//-------------------------

        //this procedure will get details major exam schedule
        public CommonExchange.MajorExamSchedule GetDetailsMajorExamSchedule(String majorExamId)
        {
            CommonExchange.MajorExamSchedule majorExamScheduleInfo = new CommonExchange.MajorExamSchedule();

            String strFilter = "major_exam_id = '" + majorExamId + "'";
            DataRow[] selectRow = _majorExamScheduleTable.Select(strFilter);

            foreach (DataRow examRow in selectRow)
            {
                if (examRow.RowState != DataRowState.Deleted)
                {
                    majorExamScheduleInfo.CourseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "course_group_id", "");
                    majorExamScheduleInfo.ExamDate = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", "");
                    majorExamScheduleInfo.ExamDescription = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "");
                    majorExamScheduleInfo.ExamInformationId = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_information_id", "");
                    majorExamScheduleInfo.GroupDescription = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "group_description", "");
                    majorExamScheduleInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "sysid_semester", "");
                    majorExamScheduleInfo.YearId = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "year_id", "");
                    majorExamScheduleInfo.CourseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "course_group_id", "");
                    majorExamScheduleInfo.MajorExamId = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0"));
                  
                    break;
                }
            }

            return majorExamScheduleInfo;
        }//------------------------

        //this fucntion will determine if the course group is isSemestral
        public Boolean IsSemestral(Int32 index)
        {
            if (index >= 0)
            {
                DataRow courseRow = _classDataSet.Tables["CourseGroupTable"].Rows[index];

                return RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_semestral", false);
            }
            else
            {
                return false;
            }
        }//--------------------

        //this fucntion will determine if the major exam schedule already exist
        public Boolean IsExistsYearSemesterIDExamDateInformationIDExamSchedule(CommonExchange.SysAccess userInfo,
            CommonExchange.MajorExamSchedule majorExamScheduleInfo)
        {
            Boolean value = false;

            using (RemoteClient.RemCntMajorExamScheduleManager remClient = new RemoteClient.RemCntMajorExamScheduleManager())
            {
                value = remClient.IsExistsYearSemesterIDExamDateInformationIDExamSchedule(userInfo, majorExamScheduleInfo);
            }

            return value;
        }//-----------------------

        //this function will determine if the time inputed is a valid time
        public Boolean IsValidDate(DateTime dateStart, DateTime dateEnd, DateTime inputDate)
        {
            Boolean isValid = false;

            if ((DateTime.Compare(inputDate, dateStart) > 0 || DateTime.Compare(inputDate, dateStart) == 0) &&
                (DateTime.Compare(inputDate, dateEnd) < 0 || DateTime.Compare(inputDate, dateEnd) == 0))
            {
                isValid = true;
            }

            return isValid;
        }//----------------------

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

        //this function will get exam information list
        public String GetExamInformationIdDescription(Int32 index, String courseGroupId, Boolean isForId)
        {
            if (_classDataSet.Tables["MajorExamInformationTable"] != null)
            {
                String value = String.Empty;

                String strFilter = "course_group_id = '" + courseGroupId + "'";
                DataRow[] selectRow = _classDataSet.Tables["MajorExamInformationTable"].Select(strFilter);

                Int32 x = 0;

                foreach (DataRow examRow in selectRow)
                {
                    if (index == x)
                    {
                        if (isForId)
                        {
                            value = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_information_id", "");
                        }
                        else
                        {
                            value = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "");
                        }
                    }

                    x++;
                }

                return value;
            }
            else
            {
                return String.Empty;
            }
        }//-------------------------------

        //this function will get exam information list
        public String GetExamInformationId(Int32 index)
        {
            if (_classDataSet.Tables["MajorExamInformationTable"] != null)
            {
                DataRow examRow = _classDataSet.Tables["MajorExamInformationTable"].Rows[index];

                 return RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_information_id", ""); 
            }
            else
            {
                return String.Empty;
            }
        }//-------------------------------     

        //this fucntion will get course group id
        public String GetCourseGroupId(Int32 index)
        {
            if (_classDataSet.Tables["CourseGroupTable"] != null)
            {
                DataRow courseRow = _classDataSet.Tables["CourseGroupTable"].Rows[index];

                return RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_group_id", "");
            }
            else
            {
                return String.Empty;
            }
        }//---------------------

        //this fucntion will get course group id
        public String GetCourseGroupDescription(Int32 index)
        {
            if (_classDataSet.Tables["CourseGroupTable"] != null)
            {
                DataRow courseRow = _classDataSet.Tables["CourseGroupTable"].Rows[index];

                return RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "group_description", "");
            }
            else
            {
                return String.Empty;
            }
        }//---------------------

        //this fucntion gets the course group exam list format
        public String GetCourseGroupExamStringFormat(CheckedListBox cbXBase, Boolean isCourseGroup)
        {
            StringBuilder strValue = new StringBuilder();

            if (cbXBase.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = cbXBase.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    if (isCourseGroup)
                    {
                        strValue.Append(this.GetCourseGroupId(x) + ", ");
                    }
                    else
                    {
                        strValue.Append(this.GetExamInformationId(x) + ", ");
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
