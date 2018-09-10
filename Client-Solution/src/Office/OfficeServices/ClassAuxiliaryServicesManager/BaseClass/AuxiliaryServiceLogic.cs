using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    internal class AuxiliaryServiceLogic
    {

        #region Class Nested Class
        internal class ScheduleDetailsList
        {
            public ScheduleDetailsList()
            {
            }

            private DataRowState _rowState;
            public DataRowState RowState
            {
                get { return _rowState; }
                set { _rowState = value; }
            }

            private CommonExchange.AuxiliaryServiceDetails _serviceInfoDetails;
            public CommonExchange.AuxiliaryServiceDetails ServiceInfoDetails
            {
                get { return _serviceInfoDetails; }
                set { _serviceInfoDetails = value; }
            }
        }
        #endregion

        #region Class Data Member Declaration
        private DataSet _classDataSet;
        private DataTable _auxiliaryServiceDetailsTable;
        private DataTable _auxiliaryInfromationDetailsTable;
        private DataTable _semesterTable;
        private DataTable _yearTable;

        private Int32 _detailsCounter = 0;

        private List<ScheduleDetailsList> _schedList = new List<ScheduleDetailsList>();
        #endregion

        #region Class Properties Declarations
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }

        public DataTable AuxiliaryTableFormat
        {
            get
            {
                DataTable subjectTable = new DataTable("AuxiliaryTableFormat");
                subjectTable.Columns.Add("sysid_auxservice", System.Type.GetType("System.String"));
                subjectTable.Columns.Add("service_code_title", System.Type.GetType("System.String"));
                subjectTable.Columns.Add("department_name", System.Type.GetType("System.String"));

                return subjectTable;
            }
        } 

        public DataTable AuxiliaryDetailsTableFormat
        {
            get
            {
                DataTable detailsTable = new DataTable("AuxiliaryDetailsTableFormat");
                detailsTable.Columns.Add("sysid_auxdetails", System.Type.GetType("System.String"));
                detailsTable.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
                detailsTable.Columns.Add("lab_units", System.Type.GetType("System.Single"));
                detailsTable.Columns.Add("no_hours", System.Type.GetType("System.String"));

                return detailsTable;
            }
        }

        #endregion

        #region Class Constructor

        public AuxiliaryServiceLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);

            _auxiliaryInfromationDetailsTable = new DataTable("AuxiliaryServiceInfoTable");
            _auxiliaryInfromationDetailsTable.Columns.Add("sysid_auxservice", System.Type.GetType("System.String"));
            _auxiliaryInfromationDetailsTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
            _auxiliaryInfromationDetailsTable.Columns.Add("department_id", System.Type.GetType("System.String"));
            _auxiliaryInfromationDetailsTable.Columns.Add("service_code", System.Type.GetType("System.String"));
            _auxiliaryInfromationDetailsTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            _auxiliaryInfromationDetailsTable.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
            _auxiliaryInfromationDetailsTable.Columns.Add("lab_units", System.Type.GetType("System.Single"));
            _auxiliaryInfromationDetailsTable.Columns.Add("no_hours", System.Type.GetType("System.String"));
            _auxiliaryInfromationDetailsTable.Columns.Add("other_information", System.Type.GetType("System.String"));
            _auxiliaryInfromationDetailsTable.Columns.Add("group_no", System.Type.GetType("System.Byte"));
            _auxiliaryInfromationDetailsTable.Columns.Add("is_semestral", System.Type.GetType("System.Boolean"));
            _auxiliaryInfromationDetailsTable.Columns.Add("department_name", System.Type.GetType("System.String"));
        }

        #endregion

        #region Programes-Defined Procedure

        //this procedure will clear cached data
        public void ClearCachedData()
        {
            if (_schedList != null)
            {
                _schedList.Clear();
            }
        }

        //this procedure will Insert New Auxiliary Information
        public void InsertAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceInformation serviceInfo)
        {
            using (RemoteClient.RemCntAuxiliaryServicesManager remClient = new RemoteClient.RemCntAuxiliaryServicesManager())
            {
                remClient.InsertAuxiliaryServiceInformation(userInfo, ref serviceInfo);
            }
        }//----------------------------

        //this procedure will Insert new Auxiliary Schedule Information
        public void InsertAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceInfoSchedule)
        {
            using (RemoteClient.RemCntAuxiliaryServicesManager remClient = new RemoteClient.RemCntAuxiliaryServicesManager())
            {
                remClient.InsertAuxiliaryServiceSchedule(userInfo, ref serviceInfoSchedule);

                if (_schedList != null)
                {
                    foreach (ScheduleDetailsList schedList in _schedList)
                    {
                        if (String.Equals(schedList.ServiceInfoDetails.AuxServiceDetailsSysId.Substring(0, 6), "SYSTMP") &&
                            schedList.RowState != DataRowState.Deleted)
                        {
                            CommonExchange.AuxiliaryServiceDetails serviceInfoDetails = schedList.ServiceInfoDetails;

                            serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId = serviceInfoSchedule.AuxServiceScheduleSysId;

                            remClient.InsertAuxiliaryServiceDetails(userInfo, ref serviceInfoDetails);

                            if (_auxiliaryServiceDetailsTable != null)
                            {
                                DataRow newRow = _auxiliaryServiceDetailsTable.NewRow();

                                newRow["sysid_auxdetails"] = serviceInfoDetails.AuxServiceDetailsSysId;
                                newRow["sysid_auxserviceschedule"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId;
                                newRow["lecture_units_details"] = serviceInfoDetails.LectureUnits;
                                newRow["lab_units_details"] = serviceInfoDetails.LabUnits;
                                newRow["no_hours_details"] = serviceInfoDetails.NoHours;
                                newRow["is_marked_deleted_details"] = false;
                                newRow["service_code"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.ServiceCode;
                                newRow["descriptive_title"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DescriptiveTitle;
                                newRow["department_id"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DepartmentInfo.DepartmentId;

                                newRow["lecture_units_schedule"] = serviceInfoSchedule.AuxiliaryServiceInfo.LectureUnits;
                                newRow["lab_units_schedule"] = serviceInfoSchedule.AuxiliaryServiceInfo.LabUnits;
                                newRow["no_hours_schedule"] = serviceInfoSchedule.AuxiliaryServiceInfo.NoHours;
                                newRow["is_semestral"] = serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral;
                                newRow["sysid_auxservice"] = serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId;
                                newRow["is_fixed_amount"] = serviceInfoSchedule.IsFixedAmount;
                                newRow["amount"] = serviceInfoSchedule.Amount;

                                if (!String.IsNullOrEmpty(serviceInfoSchedule.SchoolYearInfo.YearId))
                                {
                                    newRow["year_semester_id"] = serviceInfoSchedule.SchoolYearInfo.YearId;
                                }
                                else if (!String.IsNullOrEmpty(serviceInfoSchedule.SemesterInfo.SemesterSysId))
                                {
                                    newRow["year_semester_id"] = serviceInfoSchedule.SemesterInfo.SemesterSysId;
                                }

                                newRow["is_marked_deleted_schedule"] = false;
                                newRow["service_department_name"] = serviceInfoSchedule.AuxiliaryServiceInfo.DepartmentInfo.DepartmentName;
                                newRow["sysid_employee"] = DBNull.Value;
                                newRow["last_name"] = DBNull.Value;
                                newRow["first_name"] = DBNull.Value;
                                newRow["middle_name"] = DBNull.Value;
                                newRow["type_description"] = DBNull.Value;
                                newRow["status_description"] = DBNull.Value;
                                newRow["employee_department_name"] = DBNull.Value;

                                _auxiliaryServiceDetailsTable.Rows.Add(newRow);
                                _auxiliaryServiceDetailsTable.AcceptChanges();
                            }
                        }
                    }
                }
            }

            this.ClearCachedData();
        }//-----------------------------

        //this procedure will Insert new Auxiliary Schedule Details
        public void InsertAuxiliaryServiceScheduleDetails(CommonExchange.AuxiliaryServiceDetails serviceInfoDetails)
        {
            if (_schedList != null)
            {
                serviceInfoDetails.AuxServiceDetailsSysId = "SYSTMP" + RemoteServerLib.ProcStatic.NineDigitZero(++_detailsCounter);
                serviceInfoDetails.IsMarkedDeleted = false;

                ScheduleDetailsList list = new ScheduleDetailsList();

                list.RowState = DataRowState.Added;
                list.ServiceInfoDetails = serviceInfoDetails;

                _schedList.Add(list);
            }
        }//------------------------------

        //this procedure will Update Existing Auxiliary Information
        public void UpdateAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceInformation serviceInfo)
        {
            using (RemoteClient.RemCntAuxiliaryServicesManager remClient = new RemoteClient.RemCntAuxiliaryServicesManager())
            {
                remClient.UpdateAuxiliaryServiceInformation(userInfo, serviceInfo);
            }
        }//---------------------------

        //this procedure will Update Existing Auxiliary Service Schedule
        public void UpdateAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceInfoSchedule)
        {
            using (RemoteClient.RemCntAuxiliaryServicesManager remClient = new RemoteClient.RemCntAuxiliaryServicesManager())
            {
                remClient.UpdateAuxiliaryServiceSchedule(userInfo, serviceInfoSchedule);

                Int32 count = 0;

                foreach (DataRow serviceRow in _auxiliaryServiceDetailsTable.Rows)
                {
                    if (String.Equals(serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId, RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, 
                        "sysid_auxdetails", "")))
                    {
                        DataRow editRow = _auxiliaryServiceDetailsTable.Rows[count];

                        editRow.BeginEdit();

                        editRow["is_fixed_amount"] = serviceInfoSchedule.IsFixedAmount;
                        editRow["amount"] = serviceInfoSchedule.Amount;

                        editRow.EndEdit();
                    }

                    count++;
                }

                if (_schedList != null)
                {
                    foreach (ScheduleDetailsList schedList in _schedList)
                    {
                        if (schedList.RowState == DataRowState.Added &&
                            String.Equals(schedList.ServiceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId, serviceInfoSchedule.
                                AuxServiceScheduleSysId) &&
                            String.Equals(schedList.ServiceInfoDetails.AuxServiceDetailsSysId.Substring(0, 6), "SYSTMP"))
                        {
                            CommonExchange.AuxiliaryServiceDetails serviceInfoDetails = schedList.ServiceInfoDetails;

                            serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId = serviceInfoSchedule.AuxServiceScheduleSysId;

                            remClient.InsertAuxiliaryServiceDetails(userInfo, ref serviceInfoDetails);

                            if (_auxiliaryServiceDetailsTable != null)
                            {
                                DataRow newRow = _auxiliaryServiceDetailsTable.NewRow();

                                newRow["sysid_auxdetails"] = serviceInfoDetails.AuxServiceDetailsSysId;
                                newRow["sysid_auxserviceschedule"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId;
                                newRow["lecture_units_details"] = serviceInfoDetails.LectureUnits;
                                newRow["lab_units_details"] = serviceInfoDetails.LabUnits;
                                newRow["no_hours_details"] = serviceInfoDetails.NoHours;
                                newRow["is_marked_deleted_details"] = false;
                                newRow["service_code"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.ServiceCode;
                                newRow["descriptive_title"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DescriptiveTitle;
                                newRow["department_id"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DepartmentInfo.DepartmentId;

                                newRow["lecture_units_schedule"] = serviceInfoSchedule.AuxiliaryServiceInfo.LectureUnits;
                                newRow["lab_units_schedule"] = serviceInfoSchedule.AuxiliaryServiceInfo.LabUnits;
                                newRow["no_hours_schedule"] = serviceInfoSchedule.AuxiliaryServiceInfo.NoHours;
                                newRow["is_semestral"] = serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral;
                                newRow["sysid_auxservice"] = serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId;
                                newRow["is_fixed_amount"] = serviceInfoSchedule.IsFixedAmount;
                                newRow["amount"] = serviceInfoSchedule.Amount;

                                if (!String.IsNullOrEmpty(serviceInfoSchedule.SchoolYearInfo.YearId))
                                {
                                    newRow["year_semester_id"] = serviceInfoSchedule.SchoolYearInfo.YearId;
                                }
                                else if (!String.IsNullOrEmpty(serviceInfoSchedule.SemesterInfo.SemesterSysId))
                                {
                                    newRow["year_semester_id"] = serviceInfoSchedule.SemesterInfo.SemesterSysId;
                                }

                                newRow["is_marked_deleted_schedule"] = false;
                                newRow["service_department_name"] = serviceInfoSchedule.AuxiliaryServiceInfo.DepartmentInfo.DepartmentName;
                                newRow["sysid_employee"] = DBNull.Value;
                                newRow["last_name"] = DBNull.Value;
                                newRow["first_name"] = DBNull.Value;
                                newRow["middle_name"] = DBNull.Value;
                                newRow["type_description"] = DBNull.Value;
                                newRow["status_description"] = DBNull.Value;
                                newRow["employee_department_name"] = DBNull.Value;

                                _auxiliaryServiceDetailsTable.Rows.Add(newRow);
                                _auxiliaryServiceDetailsTable.AcceptChanges();
                            }
                        }
                        else if (schedList.RowState == DataRowState.Modified &&
                            String.Equals(schedList.ServiceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId, serviceInfoSchedule.
                                AuxServiceScheduleSysId))
                        {
                            CommonExchange.AuxiliaryServiceDetails serviceInfoDetails = schedList.ServiceInfoDetails;

                            remClient.UpdateAuxiliaryServiceDetails(userInfo, serviceInfoDetails);

                            if (_auxiliaryServiceDetailsTable != null)
                            {
                                Int32 index = 0;

                                foreach (DataRow serviceRow in _auxiliaryServiceDetailsTable.Rows)
                                {
                                    if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "sysid_auxdetails", ""), 
                                        serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId))
                                    {
                                        DataRow editRow = _auxiliaryServiceDetailsTable.Rows[index];

                                        editRow.BeginEdit();

                                        editRow["lecture_units_details"] = serviceInfoDetails.LectureUnits;
                                        editRow["lab_units_details"] = serviceInfoDetails.LabUnits;
                                        editRow["no_hours_details"] = serviceInfoSchedule.AuxiliaryServiceInfo.NoHours;
                                        editRow["is_marked_deleted_details"] = false;
                                        editRow["service_code"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.ServiceCode;
                                        editRow["descriptive_title"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DescriptiveTitle;
                                        editRow["department_id"] = serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DepartmentInfo.DepartmentId;

                                        editRow.EndEdit();

                                        break;
                                    }
                                    index++;
                                }
                                _auxiliaryServiceDetailsTable.AcceptChanges();
                            }
                        }
                        else if (schedList.RowState == DataRowState.Deleted &&
                            String.Equals(schedList.ServiceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId, serviceInfoSchedule.
                                AuxServiceScheduleSysId))
                        {
                            CommonExchange.AuxiliaryServiceDetails serviceInfoDetails = schedList.ServiceInfoDetails;

                            remClient.UpdateAuxiliaryServiceDetails(userInfo, serviceInfoDetails);

                            if (_auxiliaryServiceDetailsTable != null)
                            {
                                Int32 index = 0;

                                foreach (DataRow serviceRow in _auxiliaryServiceDetailsTable.Rows)
                                {
                                    if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "sysid_auxdetails", ""),
                                        serviceInfoDetails.AuxServiceDetailsSysId))
                                    {
                                        DataRow editRow = _auxiliaryServiceDetailsTable.Rows[index];

                                        editRow.BeginEdit();

                                        editRow["is_marked_deleted_details"] = true;

                                        editRow.EndEdit();

                                        break;
                                    }
                                    index++;
                                }

                                _auxiliaryServiceDetailsTable.AcceptChanges();
                            }
                        }
                    }
                }
            }

            this.ClearCachedData();
        }//----------------------------

        //this procedure will Update Existing Auxiliary Service Schedule Details Infomation
        public void UpdateAuxiliaryServiceDetailsInfomation(CommonExchange.AuxiliaryServiceDetails serviceInfoDetails)
        {
            if (_schedList != null)
            {
                Int32 index = 0;

                foreach (ScheduleDetailsList schedList in _schedList)
                {
                    if (String.Equals(schedList.ServiceInfoDetails.AuxServiceDetailsSysId, serviceInfoDetails.AuxServiceDetailsSysId))
                    {
                        _schedList.RemoveAt(index);

                        break;
                    }

                    index++;
                }
               
                serviceInfoDetails.IsMarkedDeleted = false;

                ScheduleDetailsList list = new ScheduleDetailsList();

                list.RowState = DataRowState.Modified;
                list.ServiceInfoDetails = serviceInfoDetails;

                _schedList.Add(list);
            }
        }//----------------------------

        //this procedure will Delete Existing Auxiliary Service Schedule Details Infomation
        public void DeleteAuxiliaryServiceDetailsInformation(CommonExchange.AuxiliaryServiceDetails serviceInfoDetails)
        {
            if (_schedList != null)
            {
                Int32 index = 0;

                foreach (ScheduleDetailsList schedList in _schedList)
                {
                    if (String.Equals(schedList.ServiceInfoDetails.AuxServiceDetailsSysId, serviceInfoDetails.AuxServiceDetailsSysId))
                    {
                        _schedList.RemoveAt(index);

                        break;
                    }

                    index++;
                }

                serviceInfoDetails.IsMarkedDeleted = true;

                ScheduleDetailsList list = new ScheduleDetailsList();

                list.RowState = DataRowState.Deleted;
                list.ServiceInfoDetails = serviceInfoDetails;

                _schedList.Add(list);
            }
        }//---------------------------

        //this procedure will Delete Existing Auxiliary Service Schedule
        public void DeleteAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceInfoSchedule)
        {
            using (RemoteClient.RemCntAuxiliaryServicesManager remClient = new RemoteClient.RemCntAuxiliaryServicesManager())
            {
                remClient.DeleteAuxiliaryServiceSchedule(userInfo, serviceInfoSchedule);
            }

            if (_auxiliaryServiceDetailsTable != null)
            {
                Int32 index = 0;

                foreach (DataRow serviceRow in _auxiliaryServiceDetailsTable.Rows)
                {
                    if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "sysid_auxserviceschedule", ""), 
                        serviceInfoSchedule.AuxServiceScheduleSysId))
                    {
                        DataRow editRow = _auxiliaryServiceDetailsTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["is_marked_deleted_details"] = true;
                        editRow["is_marked_deleted_schedule"] = true;

                        editRow.EndEdit();
                    }

                    index++;
                }
                _auxiliaryServiceDetailsTable.AcceptChanges();
            }

            this.ClearCachedData();
        }//--------------------------

        //this procedure initializes the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //----------------------

            //gets the dataset for the DataSet For Auxiliary Services
            using (RemoteClient.RemCntAuxiliaryServicesManager remClient = new RemoteClient.RemCntAuxiliaryServicesManager())
            {
                _classDataSet = remClient.GetDataSetForAuxiliaryService(userInfo, _serverDateTime);
            }
            //-----------------------
        } //-----------------------

        //this proceduer will Initialized Service Group Combo Box
        public void InitializeServiceGroupCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow groupRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "group_description", ""));
            }
        }//-----------------------------

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

        }//---------------------------

        //this procedure will Initialize Department Combo Box
        public void InitializeDepartmentCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow depRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", "") + " [" +
                    RemoteServerLib.ProcStatic.DataRowConvert(depRow, "acronym", "") + "]");
            }

        }//-------------------------------

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
        } //-----------------------------

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

        } //---------------------------

        //this procedure initializes the school year and semester combo box
        public void InitializeSchoolYearSemesterCombo(ComboBox cboBase, Boolean isSemester)
        {
            cboBase.Items.Clear();

            DateTime serverDate = DateTime.Parse(_serverDateTime);

            if (isSemester)
            {
                DataTable newTable = new DataTable("SemesterWithDateStartEndInformationTable");
                newTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
                newTable.Columns.Add("year_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("semester_id", System.Type.GetType("System.Byte"));
                newTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
                newTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));
                newTable.Columns.Add("year_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

                foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
                    newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_id", "");
                    newRow["semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_id", Byte.Parse("0"));
                    newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_start", DateTime.Parse(_serverDateTime));
                    newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_end", DateTime.Parse(_serverDateTime));
                    newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_description", "");
                    newRow["semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", "");

                    newTable.Rows.Add(newRow);
                }

                newTable.AcceptChanges();

                _semesterTable = new DataTable("SemesterSelectedDateStartEndInformationTable");
                _semesterTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
                _semesterTable.Columns.Add("year_id", System.Type.GetType("System.String"));
                _semesterTable.Columns.Add("semester_id", System.Type.GetType("System.Byte"));
                _semesterTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
                _semesterTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));
                _semesterTable.Columns.Add("year_description", System.Type.GetType("System.String"));
                _semesterTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

                String strFilter = "(date_end >= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "') AND " +
                    "(date_start <= '" + serverDate.ToShortDateString() +
                    "' OR date_start <= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "')";
                DataRow[] selectRow = newTable.Select(strFilter);

                foreach (DataRow semRow in selectRow)
                {
                    DataRow newRow = _semesterTable.NewRow();

                    newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
                    newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_id", "");
                    newRow["semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_id", Byte.Parse("0"));
                    newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_start", DateTime.Parse(_serverDateTime));
                    newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_end", DateTime.Parse(_serverDateTime));
                    newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_description", "");
                    newRow["semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", "");

                    _semesterTable.Rows.Add(newRow);

                    cboBase.Items.Add(semRow["year_description"].ToString() + " - " + semRow["semester_description"].ToString());
                }

                _semesterTable.AcceptChanges();

            }
            else
            {
                DataTable newTable = new DataTable("SchoolYearWithDateStartEndInformationTable");
                newTable.Columns.Add("year_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("year_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
                newTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));

                foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", "");
                    newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
                    newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", DateTime.Parse(_serverDateTime));
                    newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", DateTime.Parse(_serverDateTime));

                    newTable.Rows.Add(newRow);
                }

                newTable.AcceptChanges();

                _yearTable = new DataTable("SchoolYearSelectedDateStartEndInformationTable");
                _yearTable.Columns.Add("year_id", System.Type.GetType("System.String"));
                _yearTable.Columns.Add("year_description", System.Type.GetType("System.String"));
                _yearTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
                _yearTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));

                String strFilter = "(date_end >= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "') AND " +
                    "(date_start <= '" + serverDate.ToShortDateString() +
                    "' OR date_start <= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "')";
                DataRow[] selectRow = newTable.Select(strFilter);

                foreach (DataRow yearRow in selectRow)
                {
                    DataRow newRow = _yearTable.NewRow();

                    newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", "");
                    newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
                    newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", DateTime.Parse(_serverDateTime));
                    newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", DateTime.Parse(_serverDateTime));

                    _yearTable.Rows.Add(newRow);

                    cboBase.Items.Add(yearRow["year_description"].ToString());
                }

                _yearTable.AcceptChanges();

            }

            if (cboBase.Items.Count > 0)
            {
                cboBase.SelectedIndex = 0;
            }

        } //-----------------------------

        //this procedure initializes the school year and semester combo box
        public void InitializeSchoolYearSemesterCombo(ComboBox cboBase, String yearId, String semesterSysId)
        {
            cboBase.Items.Clear();

            if (!String.IsNullOrEmpty(semesterSysId))
            {
                foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
                {
                    if (String.Equals(semesterSysId, semRow["sysid_semester"].ToString()))
                    {
                        cboBase.Items.Add(semRow["year_description"].ToString() + " - " + semRow["semester_description"].ToString());

                        cboBase.SelectedIndex = 0;

                        break;
                    }
                }
            }
            else if (!String.IsNullOrEmpty(yearId))
            {
                foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
                {
                    if (String.Equals(yearId, yearRow["year_id"].ToString()))
                    {
                        cboBase.Items.Add(yearRow["year_description"].ToString());

                        cboBase.SelectedIndex = 0;

                        break;
                    }
                }
            }

        } //-----------------------------

        //this function determines if there is a schedule details that has a load
        public Boolean IsScheduleHasScheduleDetailsLoaded(String scheduleSysId)
        {
            Boolean hasLoad = false;

            if (_auxiliaryServiceDetailsTable != null)
            {
                String strFilter = "sysid_auxdetails = '" + scheduleSysId + "'";
                DataRow[] selectRow = _auxiliaryServiceDetailsTable.Select(strFilter, "sysid_auxdetails ASC");

                foreach (DataRow schedRow in selectRow)
                {
                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_employee", "")))
                    {
                        hasLoad = true;
                        break;
                    }
                }
            }

            return hasLoad;
        } //--------------------------

        //this procedure will refres the cached data
        public void RefreshAuxiliaryServiceInformationClassData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }//-----------------------------
          
        //this procedure will get Auxiliary Services Details
        public void SelectByDateStartEndAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, String queryString, String dateStart, 
            String dateEnd, Boolean isMarkedDeleted)
        {
            using (RemoteClient.RemCntAuxiliaryServicesManager remClient = new RemoteClient.RemCntAuxiliaryServicesManager())
            {
                _auxiliaryServiceDetailsTable = remClient.SelectByDateStartEndAuxiliaryServiceDetails(userInfo, queryString, dateStart, dateEnd, isMarkedDeleted);
            }
        }//---------------------------
        #endregion

        #region Programers-Defined Functions

        //this function gets the school year year id
        public String GetSchoolYearYearId(Int32 index)
        {
            DataRow _yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[index];

            return _yearRow["year_id"].ToString();
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
        } //----------------------------------------

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
        } //------------------------------

        //this function gets the semester date start
        public DateTime GetSemesterDateStart(String semSysId)
        {
            DateTime dateStart = DateTime.Parse(_serverDateTime);

            foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                if (String.Equals(semSysId, semRow["sysid_semester"].ToString()) &&
                    DateTime.TryParse(semRow["date_start"].ToString(), out dateStart))
                {
                    break;
                }
            }

            return dateStart;
        } //----------------------------------------

        //this function gets the semester date end
        public DateTime GetSemesterDateEnd(String semSysId)
        {
            DateTime dateEnd = DateTime.Parse(_serverDateTime);

            foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                if (String.Equals(semSysId, semRow["sysid_semester"].ToString()) &&
                    DateTime.TryParse(semRow["date_end"].ToString(), out dateEnd))
                {
                    break;
                }
            }

            return dateEnd;
        } //------------------------------

        //this function gets the semester system id
        public String GetSemesterSystemId(Int32 yearIndex, Int32 semIndex)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            DataRow semRow = selectRow[semIndex];

            return semRow["sysid_semester"].ToString();
        } //-----------------------------------------

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
            String typeId = String.Empty;

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

        //this function gets the year or semester id
        public String GetYearSemesterId(Boolean isSemester, Int32 index)
        {
            String yearSemesterId = "";

            if (isSemester && _semesterTable != null)
            {
                DataRow semRow = _semesterTable.Rows[index];

                yearSemesterId = semRow["sysid_semester"].ToString();
            }
            else if (!isSemester && _yearTable != null)
            {
                DataRow yearRow = _yearTable.Rows[index];

                yearSemesterId = yearRow["year_id"].ToString();
            }

            return yearSemesterId;
        } //-------------------------------

        //this fucntion returns the auxiliary service information details
        public CommonExchange.AuxiliaryServiceInformation GetDetailsAuxiliaryServiceInfomation(String auxSysId)
        {
            CommonExchange.AuxiliaryServiceInformation serviceInfo = new CommonExchange.AuxiliaryServiceInformation();

            if (_auxiliaryInfromationDetailsTable != null)
            {
                String strFilter = "sysid_auxservice = '" + auxSysId + "'";
                DataRow[] selectRow = _auxiliaryInfromationDetailsTable.Select(strFilter, "sysid_auxservice ASC");

                foreach (DataRow auxRow in selectRow)
                {
                    serviceInfo.AuxServiceSysId = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "sysid_auxservice", "");
                    serviceInfo.CourseGroupInfo.CourseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "course_group_id", "");
                    serviceInfo.DepartmentInfo.DepartmentId = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "department_id", "");
                    serviceInfo.ServiceCode = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "service_code", "");
                    serviceInfo.DescriptiveTitle = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "descriptive_title", "");
                    serviceInfo.LectureUnits = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "lecture_units", Byte.Parse("0"));
                    serviceInfo.LabUnits = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "lab_units", Byte.Parse("0"));
                    serviceInfo.NoHours = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "no_hours", "");
                    serviceInfo.OtherInformation = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "other_information", "");
                    serviceInfo.CourseGroupInfo.GroupNo = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "group_no", Byte.Parse("0"));
                    serviceInfo.CourseGroupInfo.IsSemestral = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "is_semestral", false);
                    serviceInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "department_name", "");
                }
            }

            return serviceInfo;
        }//------------------------------------

        //this fucntion returns the auxiliary service schedule 
        public CommonExchange.AuxiliaryServiceSchedule GetDetailsAuxiliarySchedule(String auxSysId)
        {
            CommonExchange.AuxiliaryServiceSchedule serviceInfoSchedule = new CommonExchange.AuxiliaryServiceSchedule();

            if (_auxiliaryServiceDetailsTable != null)
            {
                String strFilter = "sysid_auxserviceschedule = '" + auxSysId + "'";
                DataRow[] selectRow = _auxiliaryServiceDetailsTable.Select(strFilter);

                foreach (DataRow serviceRow in selectRow)
                {
                    serviceInfoSchedule.AuxServiceScheduleSysId = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "sysid_auxserviceschedule", "");
                    serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "sysid_auxdetails", "");
                    serviceInfoSchedule.AuxiliaryServiceInfo.DepartmentInfo.DepartmentId = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, 
                        "department_id", "");
                    serviceInfoSchedule.AuxiliaryServiceInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, 
                        "service_department_name", "");
                    serviceInfoSchedule.AuxiliaryServiceInfo.DescriptiveTitle = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "descriptive_title", "");
                    serviceInfoSchedule.IsMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "is_marked_deleted_schedule", false);
                    serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, 
                        "is_semestral", false);

                    if (serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral)
                    {
                        serviceInfoSchedule.SchoolYearInfo.YearId = "";
                        serviceInfoSchedule.SemesterInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "year_semester_id", "");
                    }
                    else
                    {
                        serviceInfoSchedule.SchoolYearInfo.YearId = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "year_semester_id", "");
                        serviceInfoSchedule.SemesterInfo.SemesterSysId = "";
                    }

                    serviceInfoSchedule.AuxiliaryServiceInfo.LabUnits = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, 
                        "lab_units_schedule", Byte.Parse("0"));
                    serviceInfoSchedule.AuxiliaryServiceInfo.LectureUnits = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, 
                        "lecture_units_schedule", Byte.Parse("0"));
                    serviceInfoSchedule.AuxiliaryServiceInfo.NoHours = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "no_hours_schedule", "");
                    serviceInfoSchedule.AuxiliaryServiceInfo.ServiceCode = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "service_code", "");
                    serviceInfoSchedule.IsFixedAmount = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "is_fixed_amount", false);
                    serviceInfoSchedule.Amount = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "amount", Decimal.Parse("0"));

                    break;
                }
            }

            return serviceInfoSchedule;
        }//-------------------------------

        //this fucntion returns the auxiliary service schedule details
        public CommonExchange.AuxiliaryServiceDetails GetDetailsAuxiliaryScheduleDetails(String auxSysId)
        {
            CommonExchange.AuxiliaryServiceDetails serviceInfoDetails = new CommonExchange.AuxiliaryServiceDetails();

            Boolean isFound = false;

            if (_schedList != null)
            {
                foreach (ScheduleDetailsList schedList in _schedList)
                {
                    if (String.Equals(schedList.ServiceInfoDetails.AuxServiceDetailsSysId, auxSysId))
                    {
                        serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DepartmentInfo.DepartmentName = 
                            schedList.ServiceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DepartmentInfo.DepartmentName;
                        serviceInfoDetails.AuxServiceDetailsSysId = schedList.ServiceInfoDetails.AuxServiceDetailsSysId;
                        serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId = 
                            schedList.ServiceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId;
                        serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DepartmentInfo.DepartmentId = 
                            schedList.ServiceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DepartmentInfo.DepartmentId;
                        serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DescriptiveTitle = 
                            schedList.ServiceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DescriptiveTitle;
                        serviceInfoDetails.EmployeeInfo.SalaryInfo.DepartmentInfo.DepartmentName = 
                            schedList.ServiceInfoDetails.EmployeeInfo.SalaryInfo.DepartmentInfo.DepartmentName;
                        serviceInfoDetails.EmployeeInfo.EmployeeSysId = schedList.ServiceInfoDetails.EmployeeInfo.EmployeeSysId;
                        serviceInfoDetails.EmployeeInfo.PersonInfo.FirstName = schedList.ServiceInfoDetails.EmployeeInfo.PersonInfo.FirstName;
                        serviceInfoDetails.IsMarkedDeleted = schedList.ServiceInfoDetails.IsMarkedDeleted;
                        serviceInfoDetails.LabUnits = schedList.ServiceInfoDetails.LabUnits;
                        serviceInfoDetails.EmployeeInfo.PersonInfo.LastName = schedList.ServiceInfoDetails.EmployeeInfo.PersonInfo.LastName;
                        serviceInfoDetails.LectureUnits = schedList.ServiceInfoDetails.LectureUnits;
                        serviceInfoDetails.EmployeeInfo.PersonInfo.MiddleName = schedList.ServiceInfoDetails.EmployeeInfo.PersonInfo.MiddleName;
                        serviceInfoDetails.NoHours = schedList.ServiceInfoDetails.NoHours;
                        serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.ServiceCode = 
                            schedList.ServiceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.ServiceCode;
                        serviceInfoDetails.EmployeeInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription = 
                            schedList.ServiceInfoDetails.EmployeeInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription;
                        serviceInfoDetails.EmployeeInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription = 
                            schedList.ServiceInfoDetails.EmployeeInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription;

                        isFound = true;

                        break;
                    }
                }
            }

            if (!isFound && _auxiliaryServiceDetailsTable != null)
            {
                String strFilter = "sysid_auxdetails = '" + auxSysId + "'";
                DataRow[] selectRow = _auxiliaryServiceDetailsTable.Select(strFilter);

                foreach (DataRow schedRow in selectRow)
                {
                    serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DepartmentInfo.DepartmentName = 
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "service_department_name", "");
                    serviceInfoDetails.AuxServiceDetailsSysId = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_auxdetails", "");
                    serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, 
                        "sysid_auxserviceschedule", "");
                    serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DepartmentInfo.DepartmentId =
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "department_id", "");
                    serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DescriptiveTitle = 
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "descriptive_title", "");
                    serviceInfoDetails.EmployeeInfo.SalaryInfo.DepartmentInfo.DepartmentName = 
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "employee_department_name", "");
                    serviceInfoDetails.EmployeeInfo.EmployeeSysId =RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_employee", "");
                    serviceInfoDetails.EmployeeInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "first_name", "");
                    serviceInfoDetails.IsMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_marked_deleted_details", false);
                    serviceInfoDetails.LabUnits = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lab_units_details", Single.Parse("0"));
                    serviceInfoDetails.EmployeeInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "last_name", "");
                    serviceInfoDetails.LectureUnits = RemoteServerLib.ProcStatic.DataRowConvert(schedRow,"lecture_units_details", Single.Parse("0"));
                    serviceInfoDetails.EmployeeInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "middle_name", "");
                    serviceInfoDetails.NoHours = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "no_hours_details", "");
                    serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.ServiceCode = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, 
                        "service_code", "");
                    serviceInfoDetails.EmployeeInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, 
                        "status_description", "");
                    serviceInfoDetails.EmployeeInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, 
                        "type_description", "");

                    break;
                }
            }

            return serviceInfoDetails;
        }//---------------------------------------

        //this fucntion will return searched auxiliary service schedule details information
        public DataTable GetAuxiliaryServiceScheduleDetailsInfomation()
        {
            DataTable newTable = new DataTable("AuxiliaryServiceScheduleDetailsTable");
            newTable.Columns.Add("sysid_auxserviceschedule", System.Type.GetType("System.String"));
            newTable.Columns.Add("service_code_title", System.Type.GetType("System.String"));

            foreach (DataRow auxRow in _auxiliaryServiceDetailsTable.Rows)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_auxserviceschedule"] = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "sysid_auxserviceschedule", "");
                newRow["service_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "service_code", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "descriptive_title", "");

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;

        }//-----------------------------

        //this fucntion will return searched auxiliary infromation
        public DataTable GetAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, String queryString, Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntAuxiliaryServicesManager remClient = new RemoteClient.RemCntAuxiliaryServicesManager())
                {
                    _auxiliaryInfromationDetailsTable = remClient.SelectByServiceCodeTitleAuxiliaryServiceInformation(userInfo, queryString);
                }
            }

            DataTable newTable = new DataTable("AuxiliaryServiceInfoSearch");
            newTable.Columns.Add("sysid_auxservice", System.Type.GetType("System.String"));
            newTable.Columns.Add("service_code_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            if (_auxiliaryInfromationDetailsTable != null)
            {
                foreach (DataRow auxRow in _auxiliaryInfromationDetailsTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_auxservice"] = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "sysid_auxservice", "");
                    newRow["service_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "service_code", "") +
                        " - " + RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "descriptive_title", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(auxRow, "department_name", "");

                    newTable.Rows.Add(newRow);
                }
            }

            newTable.AcceptChanges();

            return newTable;
        }//------------------------------------

        //this fuction will return Auxiliary Service Details By ScheduleID
        public DataTable GetBySysIdAuxiliaryServiceDetailsTable(String serviceSysId, Boolean isMarkedDeleted)
        {
            DataTable detailsTable = new DataTable("AuxiliaryDetailsTableFormat");
            detailsTable.Columns.Add("sysid_auxdetails", System.Type.GetType("System.String"));
            detailsTable.Columns.Add("lecture_units_details", System.Type.GetType("System.Single"));
            detailsTable.Columns.Add("lab_units_details", System.Type.GetType("System.Single"));
            detailsTable.Columns.Add("no_hours_details", System.Type.GetType("System.String"));

            if (_auxiliaryServiceDetailsTable != null)
            {
                String strFilter = "sysid_auxserviceschedule ='" + serviceSysId + "'";
                DataRow[] selectRow = _auxiliaryServiceDetailsTable.Select(strFilter, "sysid_auxserviceschedule DESC");

                foreach (DataRow serviceRow in selectRow)
                {
                    if (serviceRow.RowState != DataRowState.Deleted &&
                        RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "is_marked_deleted_details", false) == isMarkedDeleted)
                    {
                        Boolean isFound = false;

                        if (_schedList != null)
                        {
                            foreach (ScheduleDetailsList list in _schedList)
                            {
                                if (String.Equals(list.ServiceInfoDetails.AuxServiceDetailsSysId, 
                                    RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "sysid_auxdetails", "")))
                                {
                                    isFound = true;

                                    break;
                                }
                            }
                        }

                        if (!isFound)
                        {
                            DataRow newRow = detailsTable.NewRow();

                            newRow["sysid_auxdetails"] = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "sysid_auxdetails", "");
                            newRow["lecture_units_details"] = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "lecture_units_details", Single.Parse("0"));
                            newRow["lab_units_details"] = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "lab_units_details", Single.Parse("0"));
                            newRow["no_hours_details"] = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "no_hours_details", "");

                            detailsTable.Rows.Add(newRow);
                        }
                    }
                }
            }

            if (_schedList != null && !isMarkedDeleted)
            {
                foreach (ScheduleDetailsList list in _schedList)
                {
                    if (list.RowState == DataRowState.Added || list.RowState == DataRowState.Modified)
                    {
                        CommonExchange.AuxiliaryServiceDetails serviceInfoDetails = list.ServiceInfoDetails;

                        DataRow newRow = detailsTable.NewRow();

                        newRow["sysid_auxdetails"] = serviceInfoDetails.AuxServiceDetailsSysId;
                        newRow["lecture_units_details"] = serviceInfoDetails.LectureUnits;
                        newRow["lab_units_details"] = serviceInfoDetails.LabUnits;
                        newRow["no_hours_details"] = serviceInfoDetails.NoHours;

                        detailsTable.Rows.Add(newRow);
                    }
                }
            }
            else if (_schedList != null && isMarkedDeleted)
            {
                foreach (ScheduleDetailsList list in _schedList)
                {
                    if (list.RowState == DataRowState.Deleted) 
                    {
                        CommonExchange.AuxiliaryServiceDetails serviceInfoDetails = list.ServiceInfoDetails;

                        DataRow newRow = detailsTable.NewRow();

                        newRow["sysid_auxdetails"] = serviceInfoDetails.AuxServiceDetailsSysId;
                        newRow["lecture_units_details"] = serviceInfoDetails.LectureUnits;
                        newRow["lab_units_details"] = serviceInfoDetails.LabUnits;
                        newRow["no_hours_details"] = serviceInfoDetails.NoHours;

                        detailsTable.Rows.Add(newRow);
                    }
                }                
            }

            detailsTable.AcceptChanges();

            DataTable newTable = new DataTable("AuxiliaryServiceNewTable");
            newTable.Columns.Add("sysid_auxdetails", System.Type.GetType("System.String"));
            newTable.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
            newTable.Columns.Add("lab_units", System.Type.GetType("System.Single"));
            newTable.Columns.Add("no_hours", System.Type.GetType("System.String"));

            DataRow[] selectRowNew = detailsTable.Select("", "sysid_auxdetails DESC");

            foreach (DataRow serviceRow in selectRowNew)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_auxdetails"] = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "sysid_auxdetails", "");
                newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "lecture_units_details", Single.Parse("0"));
                newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "lab_units_details", Single.Parse("0"));
                newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(serviceRow, "no_hours_details", "");

                newTable.Rows.Add(newRow);
            }

            return newTable;
        }//----------------------------------

        //this function determines if the subject code and descriptive title exist
        public Boolean IsExistCodeDescriptionAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceInformation serviceInfo)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntAuxiliaryServicesManager remClient = new RemoteClient.RemCntAuxiliaryServicesManager())
            {
                isExist = remClient.IsExistCodeDescriptionAuxiliaryServiceInformation(userInfo, serviceInfo);
            }

            return isExist;
        } //--------------------------------

        //this function determines if the school year / semester must be opened
        public Boolean MustOpenSchoolYearSemester()
        {
            Boolean mustOpen = false;

            DateTime serverDate = DateTime.Parse(_serverDateTime);

            DataTable semTable = new DataTable("SemesterWithDateStartEndInformationTable");
            semTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
            semTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            semTable.Columns.Add("semester_id", System.Type.GetType("System.Byte"));
            semTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
            semTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));
            semTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            semTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

            foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                DataRow newRow = semTable.NewRow();

                newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
                newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_id", "");
                newRow["semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_id", Byte.Parse("0"));
                newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_start", DateTime.Parse(_serverDateTime));
                newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_end", DateTime.Parse(_serverDateTime));
                newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_description", "");
                newRow["semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", "");

                semTable.Rows.Add(newRow);
            }

            semTable.AcceptChanges();

            String semFilter = "(date_end >= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "') AND " +
                "(date_start <= '" + serverDate.ToShortDateString() +
                "' OR date_start <= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "')";
            DataRow[] selectSemRow = semTable.Select(semFilter);

            if (selectSemRow.Length == 0)
            {
                mustOpen = true;
            }

            DataTable yearTable = new DataTable("SchoolYearWithDateStartEndInformationTable");
            yearTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            yearTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            yearTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
            yearTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                DataRow newRow = yearTable.NewRow();

                newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", "");
                newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
                newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", DateTime.Parse(_serverDateTime));
                newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", DateTime.Parse(_serverDateTime));

                yearTable.Rows.Add(newRow);
            }

            yearTable.AcceptChanges();

            String yearFilter = "(date_end >= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "') AND " +
                "(date_start <= '" + serverDate.ToShortDateString() +
                "' OR date_start <= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "')";
            DataRow[] selectYearRow = yearTable.Select(yearFilter);

            if (selectYearRow.Length == 0)
            {
                mustOpen = true;
            }

            return mustOpen;
        } //--------------------------------------------

        //this function gets the units hours string
        public String GetAuxiliaryUnitsHours(Byte lectUnits, Byte labUnits, String noHours)
        {
            return "Lecture: " + lectUnits.ToString() + " " + ((lectUnits > 1) ? "units" : "unit") + "     " +
                "Laboratory / RLE: " + labUnits.ToString() + " " + ((labUnits > 1) ? "units" : "unit") + "     " +
                "No. of Hours: " + noHours;
        } //-----------------------------------
        #endregion
    }
}
