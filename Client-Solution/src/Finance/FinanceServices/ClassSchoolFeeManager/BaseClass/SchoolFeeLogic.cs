using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    internal class SchoolFeeLogic
    {
        #region Class Nested Classes
        internal class SchoolFeeDetailsList
        {
            public SchoolFeeDetailsList()
            {
            }

            private DataRowState _rowState;
            public DataRowState RowState
            {
                get { return _rowState; }
                set { _rowState = value; }
            }

            private CommonExchange.SchoolFeeDetails _detailsInfo;
            public CommonExchange.SchoolFeeDetails DetailsInfo
            {
                get { return _detailsInfo; }
                set { _detailsInfo = value; }
            }
        }
        #endregion

        #region Class General Variable Declaration
        private DataSet _classDataSet;
        private DataTable _schoolFeeDetailsTable;
        private DataTable _schoolFeeLevelTable;

        private Int32 _detailsCounter = 0;

        private List<SchoolFeeDetailsList> _detailsList = new List<SchoolFeeDetailsList>();
        #endregion

        #region Class Properties Declarations
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }

        public DataTable FeeParticularTable
        {
            get
            {
                DataTable particularTable = new DataTable("FeeParticularTableFormat");
                particularTable.Columns.Add("sysid_feeparticular", System.Type.GetType("System.String"));
                particularTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
                particularTable.Columns.Add("category_description", System.Type.GetType("System.String"));
                particularTable.Columns.Add("is_optional", System.Type.GetType("System.String"));
                particularTable.Columns.Add("is_office_access", System.Type.GetType("System.String"));
                particularTable.Columns.Add("is_entry_level_included", System.Type.GetType("System.String"));
                particularTable.Columns.Add("is_graduation_fee", System.Type.GetType("System.String"));

                return particularTable;
            }
        }

        public DataTable FeeDetailsTable
        {
            get
            {
                DataTable detailsTable = new DataTable("FeeDetailsTableFormat");
                detailsTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
                detailsTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
                detailsTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

                return detailsTable;
            }
        }

        #endregion

        #region Class Constructors
        public SchoolFeeLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }
        #endregion

        #region Programers-Defined Void Procedures
        
        //this procedure will Print School Fees Details
        public void PrintSchoolFeesDetails(CommonExchange.SysAccess userInfo, ListView lstGradeSchool, 
            ListView lstHighSchool, ListView lstCollege, ListView lstGraudateSchoolDoctorate, String schoolYearSemester)
        {           
            //TABLES FOR PRINTING   
            DataTable courseGroupTable = new DataTable("CourseGroupTable");
            courseGroupTable.Columns.Add("group_no", System.Type.GetType("System.String"));
            courseGroupTable.Columns.Add("group_description", System.Type.GetType("System.String"));

            DataTable schoolFeeTable = new DataTable("SchoolFeeTable");
            schoolFeeTable.Columns.Add("group_no", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("particular_description", System.Type.GetType("System.String"));           
            schoolFeeTable.Columns.Add("col_1", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("col_2", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("col_3", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("col_4", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("col_5", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("col_6", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("col_7", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("col_8", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("col_9", System.Type.GetType("System.String"));            

            Int32 index = 0;

            if (CommonExchange.EnrolmentComponent.IncludeGradeSchoolKinder)
            {
                DataRow newRowCourseGroup1 = courseGroupTable.NewRow();

                foreach (ListViewItem gsItem in lstGradeSchool.Items)
                {
                    DataRow newRow = schoolFeeTable.NewRow();
                    
                    newRow["group_no"] = "GN1";

                    if (index == 0)
                    {
                        newRowCourseGroup1["group_no"] = "GN1";
                        newRowCourseGroup1["group_description"] = "GRADE SCHOOL";

                        newRow["particular_description"] = gsItem.Text;
                    }
                    else if (gsItem.SubItems.Count <= 1)
                    {
                        newRow["particular_description"] = gsItem.Text;
                    }
                    else
                    {
                        newRow["particular_description"] = "    " + gsItem.Text;
                        newRow["col_1"] = gsItem.SubItems[1].Text;
                        newRow["col_2"] = gsItem.SubItems[2].Text;
                        newRow["col_3"] = gsItem.SubItems[3].Text;
                        newRow["col_4"] = gsItem.SubItems[4].Text;
                        newRow["col_5"] = gsItem.SubItems[5].Text;
                        newRow["col_6"] = gsItem.SubItems[6].Text;
                        newRow["col_7"] = gsItem.SubItems[7].Text;
                        newRow["col_8"] = gsItem.SubItems[8].Text;
                        newRow["col_9"] = gsItem.SubItems[9].Text;
                    }

                    schoolFeeTable.Rows.Add(newRow);

                    index++;
                }

                schoolFeeTable.AcceptChanges();

                courseGroupTable.Rows.Add(newRowCourseGroup1);
                courseGroupTable.AcceptChanges();
            }

            index = 0;

            if (CommonExchange.EnrolmentComponent.IncludeHighSchool)
            {
                DataRow newRowCourseGroup2 = courseGroupTable.NewRow();

                foreach (ListViewItem gsItem in lstHighSchool.Items)
                {
                    DataRow newRow = schoolFeeTable.NewRow();

                    newRow["group_no"] = "GN2";

                    if (index == 0)
                    {
                        newRowCourseGroup2["group_no"] = "GN2";
                        newRowCourseGroup2["group_description"] = "HIGH SCHOOL";

                        newRow["particular_description"] = gsItem.Text;
                    }
                    else if (gsItem.SubItems.Count <= 1)
                    {
                        newRow["particular_description"] = gsItem.Text;
                    }
                    else
                    {
                        newRow["particular_description"] = "    " + gsItem.Text;
                        newRow["col_1"] = gsItem.SubItems[1].Text;
                        newRow["col_2"] = gsItem.SubItems[2].Text;
                        newRow["col_3"] = gsItem.SubItems[3].Text;
                        newRow["col_4"] = gsItem.SubItems[4].Text;
                    }

                    schoolFeeTable.Rows.Add(newRow);

                    index++;
                }
                schoolFeeTable.AcceptChanges();

                courseGroupTable.Rows.Add(newRowCourseGroup2);
                courseGroupTable.AcceptChanges();
            }

            index = 0;

            if (CommonExchange.EnrolmentComponent.IncludeCollege)
            {
                DataRow newRowCourseGroup3 = courseGroupTable.NewRow();

                foreach (ListViewItem gsItem in lstCollege.Items)
                {
                    DataRow newRow = schoolFeeTable.NewRow();

                    newRow["group_no"] = "GN3";

                    if (index == 0)
                    {
                        newRowCourseGroup3["group_no"] = "GN3";
                        newRowCourseGroup3["group_description"] = "COLLEGE";

                        newRow["particular_description"] = gsItem.Text;
                    }
                    if (gsItem.SubItems.Count <= 1)
                    {
                        newRow["particular_description"] = gsItem.Text;
                    }
                    else
                    {
                        newRow["particular_description"] = "    " + gsItem.Text;
                        newRow["col_1"] = gsItem.SubItems[1].Text;
                        newRow["col_2"] = gsItem.SubItems[2].Text;
                        newRow["col_3"] = gsItem.SubItems[3].Text;
                        newRow["col_4"] = gsItem.SubItems[4].Text;
                        newRow["col_5"] = gsItem.SubItems[5].Text;
                    }

                    schoolFeeTable.Rows.Add(newRow);

                    index++;
                }
                schoolFeeTable.AcceptChanges();

                courseGroupTable.Rows.Add(newRowCourseGroup3);
                courseGroupTable.AcceptChanges();
            }

            index = 0;

            if (CommonExchange.EnrolmentComponent.IncludeGradeSchoolKinder)
            {
                DataRow newRowCourseGroup4 = courseGroupTable.NewRow();

                foreach (ListViewItem gsItem in lstGraudateSchoolDoctorate.Items)
                {
                    DataRow newRow = schoolFeeTable.NewRow();

                    newRow["group_no"] = "GN4";

                    if (index == 0)
                    {
                        newRowCourseGroup4["group_no"] = "GN4";
                        newRowCourseGroup4["group_description"] = "GRADUATE SCHOOL / DOCTORATE";

                        newRow["particular_description"] = gsItem.Text;
                    }
                    else if (gsItem.SubItems.Count <= 1)
                    {
                        newRow["particular_description"] = gsItem.Text;
                    }
                    else
                    {
                        newRow["particular_description"] = "    " + gsItem.Text;
                        newRow["col_1"] = gsItem.SubItems[1].Text;
                        newRow["col_2"] = gsItem.SubItems[2].Text;
                    }

                    schoolFeeTable.Rows.Add(newRow);

                    index++;
                }
                schoolFeeTable.AcceptChanges();

                courseGroupTable.Rows.Add(newRowCourseGroup4);
                courseGroupTable.AcceptChanges();
            }

            if (schoolFeeTable.Rows.Count >= 1)
            {
                using (ClassSchoolFeeManager.CrystalReport.CrystalSchoolFees rptSchoolFee =
                    new FinanceServices.ClassSchoolFeeManager.CrystalReport.CrystalSchoolFees())
                {
                    rptSchoolFee.Database.Tables["CourseGroupTable"].SetDataSource(courseGroupTable);
                    rptSchoolFee.Database.Tables["SchoolFeeTable"].SetDataSource(schoolFeeTable);

                    rptSchoolFee.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptSchoolFee.SetParameterValue("@address", CommonExchange.SchoolInformation.Address);
                    rptSchoolFee.SetParameterValue("@school_year", schoolYearSemester);
                    rptSchoolFee.SetParameterValue("@print_Info", "Date/Time Printed: " +
                        DateTime.Parse(this.ServerDateTime).ToShortDateString() + " " +
                        DateTime.Parse(this.ServerDateTime).ToShortTimeString() + "      Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName, userInfo.PersonInfo.FirstName,
                        userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptSchoolFee))
                    {
                        frmViewer.Text = "School Fees";
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("The school fee is empty.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }//-----------------------------

        //this procedure will Insert new School Fee Information
        public void InsertNewSchoolFeeInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeInformation feeInfo)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                remClient.InsertSchoolFeeInformation(userInfo, ref feeInfo);

                if (_classDataSet.Tables["SchoolFeeInformationTable"] != null)
                {
                    DataRow newRow = _classDataSet.Tables["SchoolFeeInformationTable"].NewRow();

                    newRow["sysid_schoolfee"] = feeInfo.FeeInformationSysId;
                    newRow["year_id"] = feeInfo.SchoolYearInfo.YearId;

                    _classDataSet.Tables["SchoolFeeInformationTable"].Rows.Add(newRow);
                    _classDataSet.Tables["SchoolFeeInformationTable"].AcceptChanges();
                }
            }
        }//------------------------

        //this procedure will Insert New School Feel Level
        public void InsertSchoolFeeLevel(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeLevel levelInfo)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                remClient.InsertSchoolFeeLevel(userInfo, ref levelInfo);

                if (_schoolFeeLevelTable != null)
                {
                    DataRow newRow = _schoolFeeLevelTable.NewRow();

                    newRow["sysid_feelevel"] = levelInfo.FeeLevelSysId;
                    newRow["sysid_schoolfee"] = levelInfo.SchoolFeeInfo.FeeInformationSysId;
                    newRow["year_level_id"] = levelInfo.YearLevelInfo.YearLevelId;
                    newRow["year_id"] = levelInfo.SchoolFeeInfo.SchoolYearInfo.YearId;
                    newRow["year_level_no"] = levelInfo.YearLevelInfo.YearLevelNo;
                    newRow["group_description"] = levelInfo.YearLevelInfo.CourseGroupInfo.GroupDescription;
                    newRow["is_semestral"] = levelInfo.YearLevelInfo.CourseGroupInfo.IsSemestral;
                    newRow["is_per_unit"] = levelInfo.YearLevelInfo.CourseGroupInfo.IsPerUnit;

                    _schoolFeeLevelTable.Rows.Add(newRow);
                    _schoolFeeLevelTable.AcceptChanges();
                }
            }
        }//----------------------------------

        //this procedure will Insert new School Fee Particular
        public void InsertSchoolFeeParticular(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeParticular particularInfo)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                remClient.InsertSchoolFeeParticular(userInfo, ref particularInfo);

                if (_classDataSet.Tables["SchoolFeeParticularTable"] != null)
                {
                    DataRow newRow = _classDataSet.Tables["SchoolFeeParticularTable"].NewRow();

                    newRow["sysid_feeparticular"] = particularInfo.FeeParticularSysId;
                    newRow["fee_category_id"] = particularInfo.SchoolFeeCategoryInfo.FeeCategoryId;
                    newRow["particular_description"] = particularInfo.ParticularDescription;
                    newRow["category_description"] = this.GetFeeCategoryDescription(particularInfo.SchoolFeeCategoryInfo.FeeCategoryId);
                    newRow["is_optional"] = particularInfo.IsOptional;
                    newRow["is_office_access"] = particularInfo.IsOfficeAccess;
                    newRow["is_entry_level_included"] = particularInfo.IsEntryLevelIncluded;
                    newRow["category_no"] = particularInfo.SchoolFeeCategoryInfo.CategoryNo;

                    _classDataSet.Tables["SchoolFeeParticularTable"].Rows.Add(newRow);
                    _classDataSet.Tables["SchoolFeeParticularTable"].AcceptChanges();
                }

            }
        }//-------------------------

        //this procedure will Record New School Fees Details
        public void RecordSchoolFeeDetails(CommonExchange.SysAccess userInfo)
        {
            if (_detailsList != null)
            {
                using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
                {
                    foreach (SchoolFeeDetailsList detailsList in _detailsList)
                    {
                        if (detailsList.RowState == DataRowState.Added)
                        {
                            CommonExchange.SchoolFeeDetails detailsInfo = new CommonExchange.SchoolFeeDetails();

                            detailsInfo = detailsList.DetailsInfo;
                 
                            remClient.InsertSchoolFeeDetails(userInfo, ref detailsInfo);
                        }
                        else if (detailsList.RowState == DataRowState.Modified)
                        {
                            remClient.UpdateSchoolFeeDetails(userInfo, detailsList.DetailsInfo);
                        }
                        else if (detailsList.RowState == DataRowState.Deleted)
                        {
                            remClient.DeleteSchoolFeeDetails(userInfo, detailsList.DetailsInfo);
                        }
                    }
                }
            }
        }//-------------------------

        //this procedure will Insert New School Fee Details
        public void InsertSchoolFeeDetails(CommonExchange.SchoolFeeDetails detailsInfo)
        {
            if (_detailsList != null)
            {
                detailsInfo.FeeDetailsSysId = "SYSTMP" + RemoteServerLib.ProcStatic.NineDigitZero(++_detailsCounter);

                SchoolFeeDetailsList list = new SchoolFeeDetailsList();

                list.RowState = DataRowState.Added;
                list.DetailsInfo = detailsInfo;

                _detailsList.Add(list);

                if (_schoolFeeDetailsTable != null)
                {
                    DataRow newRow = _schoolFeeDetailsTable.NewRow();

                    newRow["sysid_feedetails"] = detailsInfo.FeeDetailsSysId;
                    newRow["sysid_feelevel"] = detailsInfo.SchoolFeeLevelInfo.FeeLevelSysId;
                    newRow["sysid_feeparticular"] = detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId;
                    newRow["is_level_increase"] = detailsInfo.IsLevelIncrease;
                    newRow["amount"] = detailsInfo.Amount;
                    newRow["sysid_schoolfee"] = detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.FeeInformationSysId;
                    newRow["year_level_id"] = detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId;
                    newRow["year_id"] = detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.SchoolYearInfo.YearId;
                    newRow["course_group_id"] = detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId;
                    newRow["year_level_description"] = this.GetYearLevelDescription(detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId);
                    newRow["fee_category_id"] = this.GetFeeCategoryId(detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId);
                    newRow["particular_description"] = this.GetParticularDescription(detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId);
                    newRow["is_optional"] = detailsInfo.SchoolFeeParticularInfo.IsOptional;
                    newRow["is_office_access"] = detailsInfo.SchoolFeeParticularInfo.IsOfficeAccess;
                    newRow["is_entry_level_included"] = detailsInfo.SchoolFeeParticularInfo.IsEntryLevelIncluded;
                    newRow["category_description"] = this.GetFeeCategoryDescription(this.GetFeeCategoryId(detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId));

                    _schoolFeeDetailsTable.Rows.Add(newRow);
                    _schoolFeeDetailsTable.AcceptChanges();
                }
            }
        }//--------------------

        //this procedure will Update School Fee Details
        public void UpdateSchoolFeeDetails(CommonExchange.SchoolFeeDetails detailsInfo)
        {
            if (_detailsList != null)
            {
                Int32 index = 0;

                DataRowState rowState = DataRowState.Modified;

                foreach (SchoolFeeDetailsList detailsList in _detailsList)
                {
                    if (String.Equals(detailsList.DetailsInfo.FeeDetailsSysId, detailsInfo.FeeDetailsSysId))
                    {
                        rowState = detailsList.RowState == DataRowState.Added ? DataRowState.Added : DataRowState.Modified;

                        _detailsList.RemoveAt(index);

                        break;
                    }

                    index++;
                }

                detailsInfo.IsMarkedDeleted = false;

                SchoolFeeDetailsList list = new SchoolFeeDetailsList();

                list.RowState = rowState;
                list.DetailsInfo = detailsInfo;

                _detailsList.Add(list);

                if (_schoolFeeDetailsTable != null)
                {
                    Int32 editIndex = 0;

                    foreach (DataRow feeRow in _schoolFeeDetailsTable.Rows)
                    {
                        if (String.Equals(list.DetailsInfo.FeeDetailsSysId, RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feedetails", "")))
                        {
                            DataRow editRow = _schoolFeeDetailsTable.Rows[editIndex];

                            editRow.BeginEdit();

                            editRow["sysid_feedetails"] = list.DetailsInfo.FeeDetailsSysId;
                            editRow["sysid_feelevel"] = list.DetailsInfo.SchoolFeeLevelInfo.FeeLevelSysId;
                            editRow["sysid_feeparticular"] = list.DetailsInfo.SchoolFeeParticularInfo.FeeParticularSysId;
                            editRow["is_level_increase"] = list.DetailsInfo.IsLevelIncrease;
                            editRow["amount"] = list.DetailsInfo.Amount;
                            editRow["sysid_schoolfee"] = list.DetailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.FeeInformationSysId;
                            editRow["year_level_id"] = list.DetailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId;
                            editRow["year_id"] = list.DetailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.SchoolYearInfo.YearId;
                            editRow["course_group_id"] = list.DetailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId;
                            editRow["year_level_description"] = this.GetYearLevelDescription(list.DetailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId);
                            editRow["fee_category_id"] = this.GetFeeCategoryId(list.DetailsInfo.SchoolFeeParticularInfo.FeeParticularSysId);
                            editRow["particular_description"] = this.GetParticularDescription(list.DetailsInfo.SchoolFeeParticularInfo.FeeParticularSysId);
                            editRow["is_optional"] = list.DetailsInfo.SchoolFeeParticularInfo.IsOptional;
                            editRow["is_office_access"] = list.DetailsInfo.SchoolFeeParticularInfo.IsOfficeAccess;
                            editRow["is_entry_level_included"] = list.DetailsInfo.SchoolFeeParticularInfo.IsEntryLevelIncluded;
                            editRow["category_description"] = this.GetFeeCategoryDescription(this.GetFeeCategoryId(list.DetailsInfo.SchoolFeeParticularInfo.FeeParticularSysId));

                            editRow.EndEdit();

                            break;
                        }

                        editIndex++;
                    }

                    _schoolFeeDetailsTable.AcceptChanges();
                }
            }      

        }//-----------------------

        //this procedure will Update School Fee Particular
        public void UpdateSchoolFeeParticular(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeParticular particularInfo)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                remClient.UpdateSchoolFeeParticular(userInfo, particularInfo);

                if (_classDataSet.Tables["SchoolFeeParticularTable"] != null)
                {
                    Int32 index = 0;

                    foreach (DataRow pRow in _classDataSet.Tables["SchoolFeeParticularTable"].Rows)
                    {
                        if (String.Equals(particularInfo.FeeParticularSysId, RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_feeparticular", "")))
                        {
                            DataRow editRow = _classDataSet.Tables["SchoolFeeParticularTable"].Rows[index];

                            editRow.BeginEdit();

                            editRow["sysid_feeparticular"] = particularInfo.FeeParticularSysId;
                            editRow["fee_category_id"] = particularInfo.SchoolFeeCategoryInfo.FeeCategoryId;
                            editRow["is_office_access"] = particularInfo.IsOfficeAccess;
                            editRow["is_optional"] = particularInfo.IsOptional;
                            editRow["is_entry_level_included"] = particularInfo.IsEntryLevelIncluded;
                            editRow["particular_description"] = particularInfo.ParticularDescription;
                            editRow["category_no"] = particularInfo.SchoolFeeCategoryInfo.CategoryNo;

                            editRow.EndEdit();

                            break;
                        }

                        index++;
                    }
                }
            }
        }//------------------------

        //this procedure will Delete School Fee Particular
        public void DeleteSchoolFeeParticular(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeParticular particularInfo)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                remClient.DeleteSchoolFeeParticular(userInfo, particularInfo);

                if (_classDataSet.Tables["SchoolFeeParticularTable"] != null)
                {
                    Int32 index = 0;

                    foreach (DataRow pRow in _classDataSet.Tables["SchoolFeeParticularTable"].Rows)
                    {
                        if (String.Equals(particularInfo.FeeParticularSysId, RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_feeparticular", "")))
                        {
                            DataRow editRow = _classDataSet.Tables["SchoolFeeParticularTable"].Rows[index];

                            editRow.BeginEdit();

                            editRow["is_marked_deleted"] = true;
                          
                            editRow.EndEdit();

                            break;
                        }

                        index++;
                    }
                }
            }
        }//------------------------

        //this procedure will Delete School Fee Details
        public void DeleteSchoolFeeDetails(CommonExchange.SchoolFeeDetails detailsInfo)
        {
            if (_detailsList != null)
            {
                Int32 index = 0;

                foreach (SchoolFeeDetailsList detailsList in _detailsList)
                {
                    if (String.Equals(detailsList.DetailsInfo.FeeDetailsSysId, detailsInfo.FeeDetailsSysId))
                    {
                        _detailsList.RemoveAt(index);

                        break;
                    }

                    index++;
                }
            }

            detailsInfo.IsMarkedDeleted = true;

            SchoolFeeDetailsList list = new SchoolFeeDetailsList();

            list.RowState = DataRowState.Deleted;
            list.DetailsInfo = detailsInfo;

            _detailsList.Add(list);

            if (_schoolFeeDetailsTable != null)
            {
                Int32 delIndex = 0;

                foreach (DataRow feeRow in _schoolFeeDetailsTable.Rows)
                {
                    if (String.Equals(list.DetailsInfo.FeeDetailsSysId, RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feedetails", "")))
                    {
                        DataRow editRow = _schoolFeeDetailsTable.Rows[delIndex];

                        editRow.Delete();

                        break;
                    }

                    delIndex++;
                }

                _schoolFeeDetailsTable.AcceptChanges();
            }
        }//----------------------------

        //this procedure will get school fee details by start end
        public void SelectByDateStartEndSchoolFeeDetails(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, String schoolFeeSysId)
        {        
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                _schoolFeeDetailsTable = remClient.SelectByDateStartEndSchoolFeeDetails(userInfo, dateStart, dateEnd);
                _schoolFeeLevelTable = remClient.SelectBySysIDSchoolFeeSchoolFeeLevel(userInfo, schoolFeeSysId);
            }
        }//----------------------

        //this procedure will initialized the class 
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //----------------------
           
            //gets the dataset of School Fees
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                _classDataSet = remClient.GetDataSetForSchoolFee(userInfo, _serverDateTime);
            }
            //------------------------

            //initialize the school fee details table
            _schoolFeeDetailsTable = new DataTable("SchoolFeeDetailsTable");
            _schoolFeeDetailsTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
            _schoolFeeDetailsTable.Columns.Add("sysid_schoofee", System.Type.GetType("System.String"));
            _schoolFeeDetailsTable.Columns.Add("sysid_feeparticular", System.Type.GetType("System.String"));
            _schoolFeeDetailsTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            _schoolFeeDetailsTable.Columns.Add("is_optional", System.Type.GetType("System.Boolean"));
            _schoolFeeDetailsTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            _schoolFeeDetailsTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            _schoolFeeDetailsTable.Columns.Add("fee_category_id", System.Type.GetType("System.String"));
            _schoolFeeDetailsTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            _schoolFeeDetailsTable.Columns.Add("category_description", System.Type.GetType("System.String"));
            _schoolFeeDetailsTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
            _schoolFeeDetailsTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            _schoolFeeDetailsTable.Columns.Add("group_description", System.Type.GetType("System.String"));
            //----------------------------

            //initialize the school fee level table
            _schoolFeeLevelTable = new DataTable("SchoolFeeLevelTable");
            _schoolFeeLevelTable.Columns.Add("sysid_feelevel", System.Type.GetType("System.String"));
            _schoolFeeLevelTable.Columns.Add("sysid_schoolfee", System.Type.GetType("System.String"));
            _schoolFeeLevelTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            _schoolFeeLevelTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            _schoolFeeLevelTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            _schoolFeeLevelTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
            _schoolFeeLevelTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            _schoolFeeLevelTable.Columns.Add("acronym", System.Type.GetType("System.String"));
            _schoolFeeLevelTable.Columns.Add("year_level_no", System.Type.GetType("System.Int32"));
            _schoolFeeLevelTable.Columns.Add("group_no", System.Type.GetType("System.Byte"));
            _schoolFeeLevelTable.Columns.Add("group_description", System.Type.GetType("System.String"));
            _schoolFeeLevelTable.Columns.Add("is_semestral", System.Type.GetType("System.Boolean"));
            _schoolFeeLevelTable.Columns.Add("is_per_unit", System.Type.GetType("System.Boolean"));
            //-----------------------
        }//--------------------------

        //this procedure will initialize school fee particular checkedboxes
        public void InitializeSchoolFeeParticularCheckedBox(String feeParticularSysId, CheckBox chkOptional, CheckBox chkOfficeAccess,
            CheckBox chkEntryLevelIncluded, CheckBox chkGraduationFee, ref CommonExchange.SchoolFeeDetails detailsInfo)
        {
            String strFilter = "sysid_feeparticular = '" + feeParticularSysId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeParticularTable"].Select(strFilter);

            foreach (DataRow particularRow in selectRow)
            {
                chkOptional.Checked = detailsInfo.SchoolFeeParticularInfo.IsOptional
                    = RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "is_optional", false);
                chkOfficeAccess.Checked = detailsInfo.SchoolFeeParticularInfo.IsOfficeAccess
                    = RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "is_office_access", false);
                chkEntryLevelIncluded.Checked = detailsInfo.SchoolFeeParticularInfo.IsEntryLevelIncluded
                    = RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "is_entry_level_included", false);
                chkGraduationFee.Checked = detailsInfo.SchoolFeeParticularInfo.IsGraduationFee
                    = RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "is_graduation_fee", false);
            }
        }//--------------------

        //this procedure will initialized School Fee Particular combo
        public void InitializedSchoolFeeParticularCombo(ComboBox cboBase, String yearLevelId)
        {
            cboBase.Items.Clear();

            DataRow[] selectFeeParticular = _classDataSet.Tables["SchoolFeeParticularTable"].Select("", "category_no, particular_description ASC");

            foreach (DataRow pRow in selectFeeParticular)
            {
                if (!RemoteServerLib.ProcStatic.DataRowConvert(pRow, "is_marked_deleted", false))
                {
                    String strFilter = "year_level_id = '" + yearLevelId + "' AND sysid_feeparticular = '" +
                        RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_feeparticular", "") + "'";
                    DataRow[] selectRow = _schoolFeeDetailsTable.Select(strFilter);

                    if (selectRow.Length == 0)
                    {
                        cboBase.Items.Add("[" + RemoteServerLib.ProcStatic.DataRowConvert(pRow, "category_description", "") + "]  " +
                            RemoteServerLib.ProcStatic.DataRowConvert(pRow, "particular_description", ""));
                    }
                }
            }
        }//---------------------------

        //this procedure will initialized School Fee Particular combo
        public void InitializedSchoolFeeParticularCombo(ComboBox cboBase, String sysidFeeParticular, String yearLevelId)
        {
            cboBase.Items.Clear();

            DataRow[] selectFeeParticular = _classDataSet.Tables["SchoolFeeParticularTable"].Select("", "category_no, particular_description ASC");

            foreach (DataRow pRow in _classDataSet.Tables["SchoolFeeParticularTable"].Rows)
            {
                String strFilter = "year_level_id = '" + yearLevelId + "' AND sysid_feeparticular = '" +
                    RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_feeparticular", "") + "'";
                DataRow[] selectRow = _schoolFeeDetailsTable.Select(strFilter);         

                if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_feeparticular", ""), sysidFeeParticular))
                {
                    cboBase.Items.Add("[" + RemoteServerLib.ProcStatic.DataRowConvert(pRow, "category_description", "") + "]  " +
                        RemoteServerLib.ProcStatic.DataRowConvert(pRow, "particular_description", ""));
                }            
            }

            if (cboBase.Items.Count > -1)
            {
                cboBase.SelectedIndex = 0;
            }
        }//---------------------------

        //this procedure will initialized year level combo
        public void InitializedYearLevelCombo(ComboBox cboBase, String courseGroup)
        {
            cboBase.Items.Clear();

            String strFilter = "course_group_id = '" + courseGroup + "'";
            DataRow[] selectRow = _classDataSet.Tables["YearLevelInformationTable"].Select(strFilter, "group_no ASC");

            foreach (DataRow levelRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", ""));
            }
        }//---------------------------

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearCombo(ToolStripComboBox cboBase)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolYearTable"].Rows)
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

        //this procedure will initialize the Fee Category Combo
        public void InitializeFeeCategoryCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow cRow in _classDataSet.Tables["SchoolFeeCategoryTable"].Rows)
            {      
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(cRow, "category_description", ""));
            }

            cboBase.SelectedIndex = -1;
        }//--------------------------

        //this procedure will initialize the Fee Category Combo
        public void InitializeFeeCategoryCombo(ComboBox cboBase, String categoryId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            foreach (DataRow cRow in _classDataSet.Tables["SchoolFeeCategoryTable"].Rows)
            {         
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(cRow, "category_description", ""));

                if (String.Equals(categoryId, RemoteServerLib.ProcStatic.DataRowConvert(cRow, "fee_category_id", "")))
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }
        }//--------------------------

        //this procedure will initialize list View columns 
        public void InitializeListViewColumns(String strCriteria, ListView lsvBase, Int32 width)
        {
            lsvBase.Columns.Clear();

            String strFilter = "course_group_id = '" + strCriteria + "'";
            DataRow[] selectRow = _classDataSet.Tables["YearLevelInformationTable"].Select(strFilter);

            lsvBase.Columns.Add("                          Particulars", 230, HorizontalAlignment.Right);
            
            foreach (DataRow groupRow in selectRow)
            {                
                lsvBase.Columns.Add(RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "year_level_description", "") + "      ", width, HorizontalAlignment.Right);
            }
        }//---------------------------

        //this procedure will initialize listview control Details
        public void InitializeListViewDetails(ListView lsvBase, String courseGroupId, Boolean hasTotal)
        {
            lsvBase.Items.Clear();

            String categoryId = "";

            String strFilter = "course_group_id = '" + courseGroupId + "'";
            DataRow[] selectLevel = _classDataSet.Tables["YearLevelInformationTable"].Select(strFilter);

            String[] yearLevel = new String[selectLevel.Length];

            Int32 count = 0;
            Int32 itemAdded = 0;

            foreach (DataRow levelRow in selectLevel)
            {
                yearLevel[count] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", "");

                count++;
            }

            foreach (DataRow pRow in _classDataSet.Tables["SchoolFeeParticularTable"].Rows)
            {
                Boolean hasValue = false;
                Int32 index = 0;

                ListViewItem item = new ListViewItem("   " + RemoteServerLib.ProcStatic.DataRowConvert(pRow, "particular_description", ""));
                String categoryDescription = "";

                for (Int32 x = 0; x < yearLevel.Length; x++)
                {                   
                    String strFilterDetails = "course_group_id = '" + courseGroupId.ToString() + "' AND sysid_feeparticular = '" +
                        RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_feeparticular", "") + "' AND year_level_id = '" +
                        yearLevel[x] + "'";                    
                    DataRow[] selectRowDetails = _schoolFeeDetailsTable.Select(strFilterDetails);

                    if (selectRowDetails.Length == 0)
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(null, "", Color.White, Color.White, lsvBase.Font));
                    }
                    else
                    {
                        foreach (DataRow dRow in selectRowDetails)
                        {
                            if (!String.Equals(categoryId, RemoteServerLib.ProcStatic.DataRowConvert(dRow, "fee_category_id", "")))
                            {
                                categoryDescription = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "category_description", "");
                                categoryId = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "fee_category_id", "");
                            }

                            item.SubItems.Add(new ListViewItem.ListViewSubItem(null, this.GetSchoolFeeDetailsAmount(
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schoolfee", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_feeparticular", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "year_level_id", "")),
                                this.GetForeColor(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_feedetails", "")),
                                this.GetBackColor(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_feedetails", "")), lsvBase.Font));

                            itemAdded++;

                            if (index == 0 && !String.IsNullOrEmpty(item.Text))
                            {
                                hasValue = true;

                                index++;
                            }
                        }
                    }
                }

                if (hasValue)
                {
                    item.UseItemStyleForSubItems = false;                    

                    if (!String.IsNullOrEmpty(categoryDescription))
                    {
                        lsvBase.Items.Add(categoryDescription).ForeColor = Color.Red;
                    }

                    lsvBase.Items.Add(item);
                }
            }

            if (itemAdded > 0)
            {
                Int32 insertIndex = 0;
                Int32 numRep = 0;
                Decimal[] subTotal = new Decimal[selectLevel.Length];
                Decimal[] total = new Decimal[selectLevel.Length];

                foreach (ListViewItem feeList in lsvBase.Items)
                {
                    if (feeList.SubItems.Count <= 1)
                    {
                        if (numRep >= 1)
                        {
                            ListViewItem tItem = new ListViewItem("      Sub Total");

                            for (Int32 y = 0; y < subTotal.Length; y++)
                            {
                                if (subTotal[y] > 0)
                                {
                                    tItem.SubItems.Add(new ListViewItem.ListViewSubItem(null, subTotal[y].ToString("N"), Color.White, Color.LightCoral, lsvBase.Font));
                                }
                                else
                                {
                                    tItem.SubItems.Add(new ListViewItem.ListViewSubItem(null, "" , Color.White, Color.LightCoral, lsvBase.Font));
                                }
                            }                            

                            tItem.UseItemStyleForSubItems = false;
                            tItem.BackColor = Color.LightCoral;
                            tItem.ForeColor = Color.White;
                            lsvBase.Items.Insert(insertIndex, tItem);
                            insertIndex++;

                            ListViewItem emptyItem = new ListViewItem(String.Empty);
                        
                            lsvBase.Items.Insert(insertIndex, emptyItem);
                            insertIndex++;
                        }

                        for (Int32 i = 0; i < subTotal.Length; i++)
                        {
                            total[i] += subTotal[i];
                        }

                        numRep = 0;
                        subTotal = new Decimal[selectLevel.Length];
                    }
                    else
                    {
                        for (Int32 x = 0; x < feeList.SubItems.Count - 1; x++)
                        {
                            Decimal result = 0;

                            if (Decimal.TryParse(feeList.SubItems[x + 1].Text, out result))
                            {
                                subTotal[x] += result;
                            }
                        }

                        numRep++;
                    }

                    insertIndex++;
                }

                ListViewItem tsItem = new ListViewItem("        Sub Total");
                ListViewItem totalItem = new ListViewItem("Total School Fees");

                for (Int32 i = 0; i < subTotal.Length; i++)
                {
                    total[i] += subTotal[i];
                }

                for (Int32 y = 0; y < subTotal.Length; y++)
                {
                    if (subTotal[y] > 0 || total[y] > 0)
                    {
                        tsItem.SubItems.Add(new ListViewItem.ListViewSubItem(null, subTotal[y].ToString("N"), Color.White, Color.LightCoral, lsvBase.Font));

                        totalItem.SubItems.Add(new ListViewItem.ListViewSubItem(null, total[y].ToString("N"), Color.White, Color.Red, lsvBase.Font));
                    }
                    else
                    {
                        tsItem.SubItems.Add(new ListViewItem.ListViewSubItem(null, "", Color.White, Color.LightCoral, lsvBase.Font));

                        totalItem.SubItems.Add(new ListViewItem.ListViewSubItem(null, "", Color.White, Color.Red, lsvBase.Font));
                    }
                }

                tsItem.UseItemStyleForSubItems = false;
                tsItem.BackColor = Color.LightCoral;
                tsItem.ForeColor = Color.White;
                lsvBase.Items.Add(tsItem);

                lsvBase.Items.Add("");

                if (hasTotal)
                {
                    totalItem.ForeColor = Color.Red;
                    totalItem.Font = new Font("Calibri", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    lsvBase.Items.Add(totalItem);
                }
            }
        }//-----------------------------      

        //this procedure will clear cached data
        public void ClearCachedData()
        {
            _schoolFeeDetailsTable.Clear();
            _schoolFeeLevelTable.Clear();
            _detailsList.Clear();
        }//-------------------------------
        #endregion

        #region Programers-Defined Fucntions        

        //this function will Get ListView BackColor
        private Color GetBackColor(String strCriteria)
        {
            Boolean isOptional = false;
            Boolean isOfficeAccess = false;
            Boolean isLevelIncrease = false;
            Boolean isEntryLevelIncluded = false;
            Boolean isGraduationFee = false;

            Color clrBack = Color.White;

            String strFilter = "sysid_feedetails = '" + strCriteria + "'";
            DataRow[] selectRow = _schoolFeeDetailsTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                isOptional = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_optional", false);
                isOfficeAccess = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", false);
                isLevelIncrease = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_level_increase", false);
                isEntryLevelIncluded = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_entry_level_included", false);
                isGraduationFee = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_graduation_fee", false);

                break;
            }

            //this nested ele if is based on Binary simulation
            if (!isOptional && !isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Silver;
            }
            else if (!isOptional && !isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.IndianRed;
            }
            else if (!isOptional && !isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Salmon;
            }
            else if (!isOptional && !isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.Chocolate;
            }
            else if (!isOptional && !isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Orange;
            }
            else if (!isOptional && !isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.RosyBrown;
            }
            else if (!isOptional && !isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Sienna;
            }
            else if (!isOptional && isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.Peru;
            }
            else if (!isOptional && isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Goldenrod;
            }
            else if (!isOptional && isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.Gold;
            }
            else if (!isOptional && isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.YellowGreen;
            }
            else if (!isOptional && isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.DarkKhaki;
            }
            else if (!isOptional && isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Olive;
            }
            else if (!isOptional && isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.DarkSeaGreen;
            }
            else if (!isOptional && isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.LightGreen;
            }
            else if (isOptional && !isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.Tan;
            }
            else if (isOptional && !isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.ForestGreen;
            }
            else if (isOptional && !isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.Lime;
            }
            else if (isOptional && !isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.SpringGreen;
            }
            else if (isOptional && !isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.Aquamarine;
            }
            else if (isOptional && !isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Turquoise;
            }
            else if (isOptional && !isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.DarkSlateGray;
            }
            else if (isOptional && !isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.CadetBlue;
            }
            else if (isOptional && isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.SteelBlue;
            }
            else if (isOptional && isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Navy;
            }
            else if (isOptional && isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.MediumPurple;
            }
            else if (isOptional && isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Indigo;
            }
            else if (isOptional && isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.MediumOrchid;
            }
            else if (isOptional && isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Thistle;
            }
            else if (isOptional && isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrBack = Color.Magenta;
            }
            else if (isOptional && isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrBack = Color.Pink;
            }
            else
            {
                clrBack = Color.White;
            }
            //--------------------------
            
            return clrBack;
        }//------------------------------

        //this function will Get ListView ForeColor
        private Color GetForeColor(String strCriteria)
        {
            Boolean isOptional = false;
            Boolean isOfficeAccess = false;
            Boolean isLevelIncrease = false;
            Boolean isEntryLevelIncluded = false;
            Boolean isGraduationFee = false;

            Color clrFore = Color.Black;

            String strFilter = "sysid_feedetails = '" + strCriteria + "'";
            DataRow[] selectRow = _schoolFeeDetailsTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                isOptional = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_optional", false);
                isOfficeAccess = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", false);
                isLevelIncrease = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_level_increase", false);
                isEntryLevelIncluded = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_entry_level_included", false);
            }

            //this nested ele if is based on Binary simulation
            if (!isOptional && !isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (!isOptional && !isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (!isOptional && !isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (!isOptional && !isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (!isOptional && !isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (!isOptional && !isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (!isOptional && !isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (!isOptional && isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (!isOptional && isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (!isOptional && isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (!isOptional && isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (!isOptional && isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (!isOptional && isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (!isOptional && isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (!isOptional && isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (isOptional && !isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (isOptional && !isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (isOptional && !isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (isOptional && !isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (isOptional && !isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (isOptional && !isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (isOptional && !isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (isOptional && !isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (isOptional && isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (isOptional && isOfficeAccess && !isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (isOptional && isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (isOptional && isOfficeAccess && !isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (isOptional && isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.White;
            }
            else if (isOptional && isOfficeAccess && isLevelIncrease && !isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (isOptional && isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && !isGraduationFee)
            {
                clrFore = Color.Black;
            }
            else if (isOptional && isOfficeAccess && isLevelIncrease && isEntryLevelIncluded && isGraduationFee)
            {
                clrFore = Color.Black;
            }
            //--------------------------

            return clrFore;
        }//------------------------------

        //this function will Get SchoolFeelDetails Amount
        private String GetSchoolFeeDetailsAmount(String sysidSchoolFee, String sysidSchoolFeeParticular, String sysidYearLevel)
        {            
            Decimal result = 0;
           
            String strFilter = "sysid_schoolfee = '" + sysidSchoolFee + "' AND sysid_feeparticular = '" + sysidSchoolFeeParticular + 
                "' AND year_level_id = '" + sysidYearLevel + "'";
            DataRow[] selectRow = _schoolFeeDetailsTable.Select(strFilter);

            foreach (DataRow detailsRow in selectRow)
            {
                result = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
            }
            
            return result.ToString("N");
        }//------------------------------                  

        //this function will Get the FeeCategoryDescription
        private String GetFeeCategoryDescription(String sysIdFeeParticular)
        {
            String value = "";

            String strFilter = "fee_category_id = '" + sysIdFeeParticular + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeParticularTable"].Select(strFilter);

            foreach (DataRow cRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(cRow, "category_description", "");
            }

            return value;
        }//----------------------------

        //this function will DETERMINE IF THE SCHOOL YEAR HAS ALREADY A SCHOOL FEE INFORMATION
        public Boolean IsExistsYearIDSchoolFeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeInformation feeInfo)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                return remClient.IsExistsYearIDSchoolFeeInformation(userInfo, feeInfo);
            }
        }
        //-----------------------------

        //this function will determine if the school year has already a school fee information
        public Boolean IsExistsYearIDSchoolFeeInformation(String yearId)
        {
            Boolean result = true;

            String strFilter = "year_id = '" + yearId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);

            return result = selectRow.Length == 0 ? false : true;
        }//------------------------------

        //this function will determine if the school fee year id and and year level already exist
        public Boolean IsExistsSchoolFeeYearLevel(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeLevel levelInfo)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                return remClient.IsExistsSchoolFeeYearLevel(userInfo, levelInfo);
            }
        }//---------------------------------

        //this function will determine if the school fee year id and and year level already exist
        public Boolean IsExistsSchoolFeeYearLevel(String yearLevelId)
        {
            Boolean result = true;

            String strFilter = "year_level_id = '" + yearLevelId + "'";
            DataRow[] selectRow = _schoolFeeLevelTable.Select(strFilter);

            return result = selectRow.Length == 0 ? false : true;
        }//---------------------------------

        //this fucntion will DETERMINE IF THE SCHOOL FEE PARTICULAR DESCRIPTION ALREADY EXISTS
        public Boolean IsExistParticularDescriptionSchoolFeeParticular(CommonExchange.SysAccess userInfo, String particularSysId, String particularDescrioption)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                return remClient.IsExistsParticularDescriptionSchoolFeeParticular(userInfo, particularSysId, particularDescrioption);
            }
        }//---------------------------

        //this function will determine if the school fee particular and year level already exist
        public Boolean IsExistsLevelParticularSchoolFeeDetails(String feeLevelSysId, String particularSysId)
        {
            Boolean isValid = true;

            String strFilter = "sysid_feeparticular = '" + particularSysId + "' AND year_level_id = '" + feeLevelSysId + "'";
            DataRow[] selectRow = _schoolFeeDetailsTable.Select(strFilter);

            if (selectRow.Length <= 0)
            {
                isValid = false;
            }

            foreach (SchoolFeeDetailsList list in _detailsList)
            {
                if ((String.Equals(particularSysId, list.DetailsInfo.SchoolFeeParticularInfo.FeeParticularSysId)) && 
                    (String.Equals(feeLevelSysId, list.DetailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId)))
                {
                    isValid = false;

                    break;
                }
            }

            return isValid;
        }//------------------------

        //this function will Get School Fees By year level
        public DataTable GetSchoolFeeByYearLevel(String courseGroupId, String strYearId)
        {
            DataTable newTable = new DataTable("SchoolFeeTable");
            newTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
            newTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("amount", System.Type.GetType("System.String"));
                       
            if (_schoolFeeDetailsTable != null)
            {
                String strFilter = "course_group_id = '" + courseGroupId + "' AND year_level_id = '" + strYearId + "'";
                DataRow[] selectRow = _schoolFeeDetailsTable.Select(strFilter);

                foreach (DataRow feeRow in selectRow)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feedetails", "");
                    newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "") + "  [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "category_description", "") + "]";
                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0")).ToString("N");

                    newTable.Rows.Add(newRow);
                }
            }

            newTable.AcceptChanges();

            return newTable;
        }//---------------------------

        //this fuction will return Searched School Fee Particulars
        public DataTable GetSearchedSchoolFeeParticular(String strCriteria)
        {
            DataTable newTable = new DataTable("ParticularSearchedTable");
            newTable.Columns.Add("sysid_feeparticular", System.Type.GetType("System.String"));
            newTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("category_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("is_optional", System.Type.GetType("System.String"));
            newTable.Columns.Add("is_office_access", System.Type.GetType("System.String"));
            newTable.Columns.Add("is_entry_level_included", System.Type.GetType("System.String"));
            newTable.Columns.Add("is_graduation_fee", System.Type.GetType("System.String"));

            strCriteria = strCriteria.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "category_description LIKE '%" + strCriteria + "%' OR particular_description LIKE '%" + strCriteria +
                "%' OR sysid_feeparticular LIKE '%" + strCriteria + "%'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeParticularTable"].Select(strFilter, "category_no, particular_description ASC");

            foreach (DataRow pRow in selectRow)
            {
                if (!RemoteServerLib.ProcStatic.DataRowConvert(pRow, "is_marked_deleted", false))
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_feeparticular"] = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_feeparticular", "");
                    newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "particular_description", "");
                    newRow["category_description"] = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "category_description", "");
                    newRow["is_optional"] = !RemoteServerLib.ProcStatic.DataRowConvert(pRow, "is_optional", false) ? "No" : "Yes";
                    newRow["is_office_access"] = !RemoteServerLib.ProcStatic.DataRowConvert(pRow, "is_office_access", false) ? "No" : "Yes";
                    newRow["is_entry_level_included"] = !RemoteServerLib.ProcStatic.DataRowConvert(pRow, "is_entry_level_included", false) ? "No" : "Yes";
                    newRow["is_graduation_fee"] = !RemoteServerLib.ProcStatic.DataRowConvert(pRow, "is_graduation_fee", false) ? "No" : "Yes";

                    newTable.Rows.Add(newRow);
                }
            }

            newTable.AcceptChanges();

            return newTable;
        }//---------------------------

        //this function get the particular information by particular ID
        public CommonExchange.SchoolFeeParticular GetParticularInfoBySysId(String sysIdParticular)
        {
            CommonExchange.SchoolFeeParticular particularInfo = new CommonExchange.SchoolFeeParticular();

            String strFilter = "sysid_feeparticular = '" + sysIdParticular + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeParticularTable"].Select(strFilter);

            foreach (DataRow pRow in selectRow)
            {
                particularInfo.FeeParticularSysId = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_feeparticular", "");
                particularInfo.SchoolFeeCategoryInfo.FeeCategoryId = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "fee_category_id", "");
                particularInfo.ParticularDescription = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "particular_description", "");
                particularInfo.IsOfficeAccess = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "is_office_access", false);
                particularInfo.IsOptional = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "is_optional", false);
                particularInfo.IsEntryLevelIncluded = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "is_entry_level_included", false);
                particularInfo.IsGraduationFee = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "is_graduation_fee", false);
            }

            return particularInfo;
        }//-----------------------------

        //this function gets School Fee Details By syid_feedetails
        public CommonExchange.SchoolFeeDetails GetSchoolFeeDetails(String sysidFeeDetails)
        {
            CommonExchange.SchoolFeeDetails detailsInfo = new CommonExchange.SchoolFeeDetails();

            Boolean isFound = false;

            if (_detailsList != null)
            {
                foreach (SchoolFeeDetailsList list in _detailsList)
                {
                    if (String.Equals(list.DetailsInfo.FeeDetailsSysId, sysidFeeDetails))
                    {
                        detailsInfo.Amount = list.DetailsInfo.Amount;
                        detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId = 
                            list.DetailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId;
                        detailsInfo.SchoolFeeParticularInfo.SchoolFeeCategoryInfo.FeeCategoryId = 
                            list.DetailsInfo.SchoolFeeParticularInfo.SchoolFeeCategoryInfo.FeeCategoryId;
                        detailsInfo.FeeDetailsSysId = list.DetailsInfo.FeeDetailsSysId;
                        detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.FeeInformationSysId = list.DetailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.FeeInformationSysId;
                        detailsInfo.SchoolFeeLevelInfo.FeeLevelSysId = list.DetailsInfo.SchoolFeeLevelInfo.FeeLevelSysId;
                        detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId = list.DetailsInfo.SchoolFeeParticularInfo.FeeParticularSysId;
                        detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.GroupDescription = 
                            list.DetailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.GroupDescription;
                        detailsInfo.IsLevelIncrease = list.DetailsInfo.IsLevelIncrease;

                        detailsInfo.IsEntryLevelIncluded = list.DetailsInfo.IsEntryLevelIncluded;
                        detailsInfo.IsOfficeAccess = list.DetailsInfo.IsOfficeAccess;
                        detailsInfo.IsOptional = list.DetailsInfo.IsOptional;
                        detailsInfo.IsGraduationFee = list.DetailsInfo.IsGraduationFee;
                        detailsInfo.IncludeFirstSemester = list.DetailsInfo.IncludeFirstSemester;
                        detailsInfo.IncludeSecondSemester = list.DetailsInfo.IncludeSecondSemester;
                        detailsInfo.IncludeSummer = list.DetailsInfo.IncludeSummer;
                        detailsInfo.IncludeMale = list.DetailsInfo.IncludeMale;
                        detailsInfo.IncludeFemale = list.DetailsInfo.IncludeFemale;

                        detailsInfo.SchoolFeeParticularInfo.ParticularDescription = list.DetailsInfo.SchoolFeeParticularInfo.ParticularDescription;
                        detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.SchoolYearInfo.YearId = list.DetailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.SchoolYearInfo.YearId;
                        detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelDescription = list.DetailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelDescription;
                        detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId = list.DetailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId;
                      
                        isFound = true;

                        break;
                    }
                }
            }

            if (!isFound && _schoolFeeDetailsTable != null)
            {
                String strFilter = "sysid_feedetails = '" + sysidFeeDetails + "'";
                DataRow[] selectRow = _schoolFeeDetailsTable.Select(strFilter);

                foreach (DataRow detailsRow in selectRow)
                {
                    detailsInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                    detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId =
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "course_group_id", "");
                    detailsInfo.SchoolFeeParticularInfo.SchoolFeeCategoryInfo.FeeCategoryId = 
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "");
                    detailsInfo.FeeDetailsSysId = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_feedetails", "");
                    detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.FeeInformationSysId = 
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_schoolfee", "");
                    detailsInfo.SchoolFeeLevelInfo.FeeLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_feelevel", "");
                    detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_feeparticular", "");
                    detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.GroupDescription = 
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "group_description", "");
                    detailsInfo.IsLevelIncrease = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_level_increase", false);

                    detailsInfo.IsEntryLevelIncluded = 
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_entry_level_included", false);                    
                    detailsInfo.IsOfficeAccess = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_office_access", false);
                    detailsInfo.IsOptional = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_optional", false);
                    detailsInfo.IsGraduationFee = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_graduation_fee", false);
                    detailsInfo.IncludeFirstSemester = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "include_first_semester", false);
                    detailsInfo.IncludeSecondSemester = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "include_second_semester", false);
                    detailsInfo.IncludeSummer = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "include_summer", false);
                    detailsInfo.IncludeMale = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "include_male", false);
                    detailsInfo.IncludeFemale = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "include_female", false);

                    detailsInfo.SchoolFeeParticularInfo.ParticularDescription = 
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "particular_description", "");
                    detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.SchoolYearInfo.YearId = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "year_id", "");
                    detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelDescription = 
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "year_level_description", "");
                    detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "year_level_id", "");

                    break;
                }
            }

            return detailsInfo;
        }//----------------------------------      

        //this function gets the school year date start
        public DateTime GetSchoolYearDateStart(String yearId)
        {
            DateTime dateStart = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolYearTable"].Rows)
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

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolYearTable"].Rows)
            {
                if (String.Equals(yearId, yearRow["year_id"].ToString()) &&
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd))
                {
                    break;
                }
            }

            return dateEnd;
        }//------------------------------

        //this fucntion gets the School Fee Information System Id
        public String GetSysIdSchoolFeeInformation(String yearId)
        {
            String value = "";

            String strFilter = "year_id = '" + yearId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);

            foreach (DataRow sRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(sRow, "sysid_schoolfee", "");
            }

            return value;
        }//---------------------------------

        //this function gets the school year year id
        public String GetSchoolYearYearId(Int32 index)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolYearTable"].Rows[index];

            return yearRow["year_id"].ToString();
        }//----------------------------

        //this function gets the fee category id
        public String GetFeeCategoryId(Int32 index, ref Byte categoryNo)
        {
            DataRow categoryRow = _classDataSet.Tables["SchoolFeeCategoryTable"].Rows[index];

            categoryNo = Byte.Parse(categoryRow["category_no"].ToString());

            return categoryRow["fee_category_id"].ToString();
        }//---------------------

        //this function will get the fee category id
        private String GetFeeCategoryId(String sysIdFeeParticular)
        {
            String value = "";

            String stfFiler = "sysid_feeparticular = '" + sysIdFeeParticular + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeParticularTable"].Select(stfFiler);

            foreach (DataRow pRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "fee_category_id", "");
            }

            return value;
        }//----------------------------

        //this function will determine if the shool year is summer
        public Boolean IsSummer(String yearId)
        {
            Boolean isSummer = false;

            String strFilter = "year_id = '" + yearId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolYearTable"].Select(strFilter);

            foreach (DataRow yearRow in selectRow)
            {
                isSummer = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "is_summer", false);
            }

            return isSummer;
        }//---------------

        //this fucntion will get School Year Description
        public String GetSchoolYearDescription(String yearId)
        {
            String value = "";

            String strFilter = "year_id = '" + yearId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolYearTable"].Select(strFilter);

            foreach (DataRow yearRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
            }

            return value;
        }//----------------------

        //this function will get YearLevelId
        public String GetYearLevelId(String courseGroupId, String yearLevelDescription)
        {
            String value = "";
            
            String strFilter = "course_group_id = '" + courseGroupId + "' AND year_level_description = '" + yearLevelDescription + "'";
            DataRow[] selectRow = _classDataSet.Tables["YearLevelInformationTable"].Select(strFilter);

            foreach (DataRow levelRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", "");
            }

            return value;
        }//--------------------------

        //this function will get YearLevelDescription
        public String GetYearLevelDescription(String yearLevelId)
        {
            String value = "";

            String strFilter = "year_level_id = '" + yearLevelId + "'";
            DataRow[] selectRow = _classDataSet.Tables["YearLevelInformationTable"].Select(strFilter);

            foreach (DataRow levelRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "");
            }

            return value;
        }//--------------------------

        //this fucntion will get Course Group Description
        public String GetCourseGroupDescription(String courseGroupId)
        {
            String value = "";

            String strFilter = "course_group_id = '" + courseGroupId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseGroupTable"].Select(strFilter);

            foreach (DataRow groupRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "group_description", "");
            }

            return value;
        }//----------------------

        //this fucntion will get Particular sysId
        public String GetConcatParticularSysId(String strValue)
        {
            return strValue.Remove(strValue.IndexOf("["), strValue.IndexOf("]") + 3);
        }//------------------------

        //this function will get Particular System Id
        public String GetParticularSysId(String particularDescription)
        {
            String value = "";

            particularDescription = particularDescription.Replace("'", "''");

            String strFilter = "particular_description = '" + particularDescription + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeParticularTable"].Select(strFilter);

            foreach (DataRow pRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_feeparticular", "");
            }

            return value;
        }//-------------------------

        //this function will get Particular Description
        private String GetParticularDescription(String sysIdFeeParticular)
        {
            String value = "";

            String stfFiler = "sysid_feeparticular = '" + sysIdFeeParticular + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeParticularTable"].Select(stfFiler);

            foreach (DataRow pRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "particular_description", "");
            }

            return value;
        }//----------------------------

        //this function will get Feel Level Id By yaerlevelid
        public String GetFeelLevelId(String yearLevelId)
        {
            String value = "";

            String strFilter = "year_level_id = '" + yearLevelId + "'";
            DataRow[] selectRow = _schoolFeeLevelTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feelevel", "");
            }

            return value;
        }//----------------------------

        //this fucntion will set legend text
        public String SetLegendText(Color baseColor)
        {
            String value = String.Empty;

            if (baseColor == Color.Silver)
            {
                value = "Is a graduation fee";
            }
            else if (baseColor == Color.IndianRed)
            {
                value = "Is a entry level included";
            }
            else if (baseColor == Color.Salmon)
            {
                value = "Is a entry level included and Is a graduation fee";
            }
            else if (baseColor == Color.Chocolate)
            {
                value = "Is a level increase";
            }
            else if (baseColor == Color.Orange)
            {
                value = "Is a level increase and Is a graduation fee";
            }
            else if (baseColor == Color.RosyBrown)
            {
                value = "Is a level increase and Is an entry level included";
            }
            else if (baseColor == Color.Sienna)
            {
                value = "Is a level increase and Is an entry level included and Is a graduation fee";
            }
            else if (baseColor == Color.Peru)
            {
                value = "Is an office access";
            }
            else if (baseColor == Color.Goldenrod)
            {
                value = "Is an office access and Is a graduation fee";
            }
            else if (baseColor == Color.Gold)
            {
                value = "Is an office access and Is an entry level included";
            }
            else if (baseColor == Color.YellowGreen)
            {
                value = "Is an office access and Is an entry level included and Is a graduation fee";
            }
            else if (baseColor == Color.DarkKhaki)
            {
                value = "Is an office access and Is a level increase ";
            }
            else if (baseColor == Color.Olive)
            {
                value = "Is an office access and Is a level increase and Is a graduation fee";
            }
            else if (baseColor == Color.DarkSeaGreen)
            {
                value = "Is an office access and Is a level increase and Is an entry level included";
            }
            else if (baseColor == Color.LightGreen)
            {
                value = "Is an office access and Is a level increase and Is an entry level included and Is a graduation fee";
            }
            else if (baseColor == Color.Tan)
            {
                value = "Is an optional fee";
            }
            else if (baseColor == Color.ForestGreen)
            {
                value = "Is an optional fee and Is a graduation fee";
            }
            else if (baseColor == Color.Lime)
            {
                value = "Is an optional fee and Is an entry level included";
            }
            else if (baseColor == Color.SpringGreen)
            {
                value = "Is an optional fee and Is an entry level included and Is a graduation fee";
            }
            else if (baseColor == Color.Aquamarine)
            {
                value = "Is an optional fee and Is a level increase";
            }
            else if (baseColor == Color.Turquoise)
            {
                value = "Is an optional fee and Is a level increase and Is a graduation fee";
            }
            else if (baseColor == Color.DarkSlateGray)
            {
                value = "Is an optional fee and Is a level increase and Is an entry level included";
            }
            else if (baseColor == Color.CadetBlue)
            {
                value = "Is an optional fee and Is a level increase and Is an entry level included and Is a graduation fee";
            }
            else if (baseColor == Color.SteelBlue)
            {
                value = "Is an optional fee and Is an office access";
            }
            else if (baseColor == Color.Navy)
            {
                value = "Is an optional fee and Is an office access and Is a gradiation fee";
            }
            else if (baseColor == Color.MediumPurple)
            {
                value = "Is an optional fee and Is an office access and Is a entry level included";
            }
            else if (baseColor == Color.Indigo)
            {
                value = "Is an optional fee and Is an office access and Is an entry level included and Is a graduation fee";
            }
            else if (baseColor == Color.MediumOrchid)
            {
                value = "Is an optional fee and Is an office access and Is a level increase";
            }
            else if (baseColor == Color.Thistle)
            {
                value = "Is an optioanl fee and Is an office access and Is a level increase and Is a graduation fee";
            }
            else if (baseColor == Color.Magenta)
            {
                value = "Is an optional fee and Is an office access and Is a level increase and Is an entry level included";
            }
            else if (baseColor == Color.Pink)
            {
                value = "Is an optional fee and Is an office access and Is a level increase and Is an entry level included and Is a graduation fee";
            }

            return value;
        }//-------------------------
        #endregion
    }
}
