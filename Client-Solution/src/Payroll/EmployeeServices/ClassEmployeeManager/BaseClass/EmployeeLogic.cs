using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace EmployeeServices
{    
    internal class EmployeeLogic : BaseServices.BaseServicesLogic
    {
        #region Class General Variable Declarations
        private DataSet _classDataSet;
        private String _imagePath;        
        #endregion

        #region Class Constructor
        public EmployeeLogic(CommonExchange.SysAccess userInfo) 
            : base(userInfo)
        {
            this.InitializeClass(userInfo);

            _imagePath = "\\EmployeeImages";
        }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new employee
        public void InsertEmployeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo)
        {
            using (RemoteClient.RemCntEmployeeManager remClient = new RemoteClient.RemCntEmployeeManager())
            {
                remClient.InsertEmployeeInformation(userInfo, ref empInfo);
            }

            DataRow newRow = _classDataSet.Tables["EmployeeInformationTable"].NewRow();

            newRow["sysid_employee"] = empInfo.EmployeeSysId;
            newRow["employee_id"] = empInfo.EmployeeId;
            newRow["card_number"] = empInfo.CardNumber;
            newRow["last_name"] = empInfo.PersonInfo.LastName;
            newRow["first_name"] = empInfo.PersonInfo.FirstName;
            newRow["middle_name"] = empInfo.PersonInfo.MiddleName;
            newRow["type_no"] = empInfo.SalaryInfo.EmploymentTypeInfo.TypeNo;
            newRow["status_id"] = empInfo.SalaryInfo.EmployeeStatusInfo.StatusId;

            _classDataSet.Tables["EmployeeInformationTable"].Rows.Add(newRow);
            _classDataSet.Tables["EmployeeInformationTable"].AcceptChanges();


        } //-------------------------------

        //this procedure updates the employee information
        public void UpdateEmployeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo)
        {
            using (RemoteClient.RemCntEmployeeManager remClient = new RemoteClient.RemCntEmployeeManager())
            {
                remClient.UpdateEmployeeInformation(userInfo, empInfo);
            }

            Int32 index = 0;

            foreach (DataRow empRow in _classDataSet.Tables["EmployeeInformationTable"].Rows)
            {
                if (String.Equals(empInfo.EmployeeSysId, empRow["sysid_employee"].ToString()))
                {
                    DataRow editRow = _classDataSet.Tables["EmployeeInformationTable"].Rows[index];

                    editRow.BeginEdit();

                    editRow["employee_id"] = empInfo.EmployeeId;
                    editRow["card_number"] = empInfo.CardNumber;
                    editRow["last_name"] = empInfo.PersonInfo.LastName;
                    editRow["first_name"] = empInfo.PersonInfo.FirstName;
                    editRow["middle_name"] = empInfo.PersonInfo.MiddleName;
                    editRow["type_no"] = empInfo.SalaryInfo.EmploymentTypeInfo.TypeNo;
                    editRow["status_id"] = empInfo.SalaryInfo.EmployeeStatusInfo.StatusId;                    

                    editRow.EndEdit();

                    break;

                }

                index++;
            }

            _classDataSet.Tables["EmployeeInformationTable"].AcceptChanges();

        } //----------------------------------

        //this procedure initializes the employment type combo box
        public void InitializeEmploymentTypeCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow typeRow in _classDataSet.Tables["EmploymentTypeTable"].Rows)
            {
                cboBase.Items.Add(typeRow["type_description"].ToString());
            }

        } //---------------------------

        //this procedure initializes the employment type combo box
        public void InitializeEmploymentTypeCombo(ComboBox cboBase, String typeId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            foreach (DataRow typeRow in _classDataSet.Tables["EmploymentTypeTable"].Rows)
            {
                cboBase.Items.Add(typeRow["type_description"].ToString());

                if (String.Equals(typeId, typeRow["employment_id"].ToString()))
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }

        } //---------------------------

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

        //this procedure initializes the employment status combo box
        public void InitializeEmploymentStatusCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow statusRow in _classDataSet.Tables["EmploymentStatusTable"].Rows)
            {
                cboBase.Items.Add(statusRow["status_description"].ToString());
            }

        } //-------------------------------

        //this procedure initializes the employment status combo box
        public void InitializeEmploymentStatusCombo(ComboBox cboBase, Byte statusId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            foreach (DataRow statusRow in _classDataSet.Tables["EmploymentStatusTable"].Rows)
            {
                cboBase.Items.Add(statusRow["status_description"].ToString());

                if (statusId == (Byte)statusRow["status_id"])
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }

        } //-------------------------------

        //this procedure initializes the rest day combo box
        public void InitializeRestDayCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow statusRow in _classDataSet.Tables["WeekDayTable"].Rows)
            {
                cboBase.Items.Add(statusRow["week_description"].ToString());
            }

        } //------------------------------------

        //this procedure initializes the rest day combo box
        public void InitializeRestDayCombo(ComboBox cboBase, Byte restDay)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            foreach (DataRow restRow in _classDataSet.Tables["WeekDayTable"].Rows)
            {
                cboBase.Items.Add(restRow["week_description"].ToString());

                if (restDay == (Byte)restRow["week_id"])
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }

        } //------------------------------------
         
        //this procedure initializes the rank level combo box
        public void InitializeRankLevelCombo(ComboBox cboBase, String typeId)
        {
            cboBase.Items.Clear();

            String strFilter = "rank_group_id = '" + this.GetRankGroupId(typeId) + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankLevelTable"].Select(strFilter, "level_no ASC");

            foreach (DataRow levelRow in selectRow)
            {
                cboBase.Items.Add(levelRow["level_description"].ToString());                
            }

        } //--------------------------

        //this procedure initializes the rank level combo box
        public void InitializeRankLevelCombo(ComboBox cboBase, String typeId, String levelId)
        {
            String levelName = "";
            String strFilter = "rank_group_id = '" + this.GetRankGroupId(typeId) + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankLevelTable"].Select(strFilter, "level_no ASC");

            foreach (DataRow levelRow in selectRow)
            {
                if (String.Equals(levelId, levelRow["level_id"].ToString()))
                {
                    levelName = levelRow["level_description"].ToString();
                    break;
                }
            }
            
            if (cboBase.Items.Count > 0)
            {
                for (Int32 index = 0; index < cboBase.Items.Count; index++)
                {
                    if (String.Equals(levelName, cboBase.Items[index].ToString()))
                    {
                        cboBase.SelectedIndex = index;
                    }
                }
            }
        } //--------------------------

        //this procedure initializes the rank category combo box
        public void InitializeRankCategoryCombo(ComboBox cboBase, String levelId)//, Byte statusId, String typeId)
        {
            cboBase.Items.Clear();

            //Byte typeNo = this.GetEmploymentTypeNo(typeId);
            String strFilter = "";

            //if (statusId == (Byte)CommonExchange.EmploymentStatusNo.TemporaryPartTime) 
            //{
            //    strFilter = "level_id = '" + levelId + "' AND category_no = '" + statusId.ToString() + "'";
            //}
            //else if ((statusId == (Byte)CommonExchange.EmploymentStatusNo.Probitionary) &&
            //    ((typeNo >= (Byte)CommonExchange.EmploymentTypeNo.CollegeFaculty) && (typeNo <= (Byte)CommonExchange.EmploymentTypeNo.GradeKinderFaculty)))
            //{
            //    strFilter = "level_id = '" + levelId + "' AND category_no <= '" + statusId.ToString() + "'";
            //}
            //else
            //{
            strFilter = "level_id = '" + levelId + "'";
            //}

            DataRow[] selectRow = _classDataSet.Tables["RankCategoryTable"].Select(strFilter, "category_no ASC");

            foreach (DataRow catRow in selectRow)
            {
                cboBase.Items.Add(catRow["category_description"].ToString());
            }
        } //------------------------------

        //this procedure initializes the rank category combo box
        public void InitializeRankCategoryCombo(ComboBox cboBase, String levelId, Byte statusId, String typeId, String categoryId)
        {
            Byte catNo = 0;
            Byte typeNo = this.GetEmploymentTypeNo(typeId);
            String strFilter = "";

            //if (statusId == (Byte)CommonExchange.EmploymentStatusNo.TemporaryPartTime)
            //{
            //    strFilter = "level_id = '" + levelId + "' AND category_no = '" + statusId.ToString() + "'";
            //}
            //else if ((statusId == (Byte)CommonExchange.EmploymentStatusNo.Probitionary) &&
            //    ((typeNo >= (Byte)CommonExchange.EmploymentTypeNo.CollegeFaculty) && (typeNo <= (Byte)CommonExchange.EmploymentTypeNo.GradeKinderFaculty)))
            //{
            //    strFilter = "level_id = '" + levelId + "' AND category_no <= '" + statusId.ToString() + "'";
            //}
            //else
            //{
                strFilter = "level_id = '" + levelId + "'";
            //}

            DataRow[] selectRow = _classDataSet.Tables["RankCategoryTable"].Select(strFilter, "category_no ASC");

            foreach (DataRow catRow in selectRow)
            {
                if (String.Equals(categoryId, catRow["category_id"].ToString()))
                {
                    catNo = (Byte)catRow["category_no"];
                    break;
                }
            }

            if (cboBase.Items.Count >= catNo && catNo > 0)
            {
                cboBase.SelectedIndex = --catNo;
            }

        } //------------------------------

        //this procedure initializes the rank degree combo box
        public void InitializeRankDegreeCombo(ComboBox cboBase, String categoryId)
        {
            cboBase.Items.Clear();

            String strFilter = "category_id = '" + categoryId + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankDegreeTable"].Select(strFilter, "degree_no ASC");

            foreach (DataRow degRow in selectRow)
            {
                cboBase.Items.Add(degRow["degree_description"].ToString());
            }
        } //------------------------------  

        //this procedure initializes the rank degree combo box
        public void InitializeRankDegreeCombo(ComboBox cboBase, String categoryId, String degreeId)
        {
            Byte degNo = 0;
            String strFilter = "category_id = '" + categoryId + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankDegreeTable"].Select(strFilter, "degree_no ASC");

            foreach (DataRow degRow in selectRow)
            {
                if (String.Equals(degreeId, degRow["degree_id"].ToString()))
                {
                    degNo = (Byte)degRow["degree_no"];
                }
            }

            if (cboBase.Items.Count >= degNo && degNo > 0)
            {
                cboBase.SelectedIndex = --degNo;
            }

        } //------------------------------  

        //this procedure initializes the level points combo box
        public void InitializeLevelPointsCombo(ComboBox cboBase, String levelId)
        {
            cboBase.Items.Clear();

            String strFilter = "level_id = '" + levelId + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankDegreeTable"].Select(strFilter, "level_no, category_no, degree_no ASC");

            foreach (DataRow rateRow in selectRow)
            {
                cboBase.Items.Add(rateRow["category_description"].ToString() + " - " + rateRow["degree_description"].ToString() +
                    (String.IsNullOrEmpty(rateRow["level_points"].ToString()) ? "" : " (" + rateRow["level_points"].ToString() + ")"));
            }

        } //------------------------------  

        //this procedure initializes the level points combo box
        public void InitializeLevelPointsCombo(ComboBox cboBase, String levelId, String degreeIdLevelPoints)
        {
            Int32 index = 0;
            String strFilter = "level_id = '" + levelId + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankDegreeTable"].Select(strFilter, "level_no, category_no, degree_no ASC");

            foreach (DataRow rateRow in selectRow)
            {
                if (String.Equals(degreeIdLevelPoints, rateRow["degree_id"].ToString()))
                {
                    if (cboBase.Items.Count > index)
                    {
                        cboBase.SelectedIndex = index;
                    }
                }

                index++;
            }

        } //------------------------------  
        
        //this procedure deletes the image directory
        public void DeleteImageDirectory(String startUp)
        {
            String imagePath = startUp + _imagePath;

            RemoteClient.ProcStatic.DeleteDirectory(imagePath);

        } //--------------------

        //this procedure refreshes the data
        public void RefreshEmployeeData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);

        } //---------------------------

        //this procedure initializes the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //----------------------

            //get the dataset for employee information
            using (RemoteClient.RemCntEmployeeManager remClient = new RemoteClient.RemCntEmployeeManager())
            {
                _classDataSet = remClient.GetDataSetForEmployeeInfo(userInfo);
            } //---------------------------------

        } //--------------------------

        
        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the selected employee
        public DataTable GetSelectedEmployeeInformation(ClientExchange.EmployeeSearchFilter searchFilter)
        {
            DataTable employeeTable = RemoteClient.ProcStatic.GetEmployeeInformationFilterStatusAndType(searchFilter, 
                                                _classDataSet.Tables["EmployeeInformationTable"]);

            DataTable newTable = new DataTable("EmployeeSearchByEmployeeNameIdCardNumberTable");
            newTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("card_number", System.Type.GetType("System.String"));
            newTable.Columns.Add("employee_name", System.Type.GetType("System.String"));

            searchFilter.StringSearch = searchFilter.StringSearch.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "(employee_id LIKE '%" + searchFilter.StringSearch + "%' OR " +
                        "employee_name LIKE '%" + searchFilter.StringSearch + "%' OR " + 
                        "card_number LIKE '%" + searchFilter.StringSearch + "%')";

            DataRow[] selectRow = employeeTable.Select(strFilter.Trim("*".ToCharArray()), "employee_name ASC");

            foreach (DataRow empRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["employee_id"] = empRow["employee_id"].ToString();
                newRow["card_number"] = empRow["card_number"].ToString();
                newRow["employee_name"] = empRow["employee_name"].ToString();

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;

        } //-------------------------------

        //this function gets the employee information
        public CommonExchange.Employee GetDetailsEmployeeInformation(CommonExchange.SysAccess userInfo, String employeeIdPersonId, String startUpPath,
            Boolean searchByEmployeeId)
        {
            CommonExchange.Employee employeeInfo = new CommonExchange.Employee();

            using (RemoteClient.RemCntEmployeeManager remClient = new RemoteClient.RemCntEmployeeManager())
            {
                if (searchByEmployeeId)
                {
                    employeeInfo = remClient.SelectByEmployeeIDEmployeeInformation(userInfo, employeeIdPersonId);
                }
                else
                {
                    employeeInfo = remClient.SelectBySysIDPersonEmployeeInformation(userInfo, employeeIdPersonId);
                }

                if (!String.IsNullOrEmpty(employeeInfo.PersonInfo.BirthDate))
                {
                    DateTime bDate = DateTime.Parse(employeeInfo.PersonInfo.BirthDate);                   

                    if (DateTime.Compare(bDate, DateTime.MinValue) == 0)
                        employeeInfo.PersonInfo.BirthDate = String.Empty;
                }

                if (!String.IsNullOrEmpty(employeeInfo.PersonInfo.MarriageDate))
                {
                    DateTime mDate = DateTime.Parse(employeeInfo.PersonInfo.MarriageDate);

                    if (DateTime.Compare(mDate, DateTime.MinValue) == 0)
                        employeeInfo.PersonInfo.MarriageDate = String.Empty;
                }
            }

            employeeInfo.PersonInfo.FilePath = base.GetPersonImagePath(userInfo, employeeInfo.PersonInfo.PersonSysId, 
                employeeInfo.PersonInfo.PersonImagesFolder(startUpPath));

            return employeeInfo;
        } //-----------------------
        
        //this function gets the rank degree previous rate
        public Decimal GetRankDegreePreviousRate(String degreeId)
        {
            Decimal rate = 0;

            String strFilter = "degree_id = '" + degreeId + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankDegreeTable"].Select(strFilter, "degree_no ASC");

            foreach (DataRow degRow in selectRow)
            {
                rate = (Decimal)degRow["previous_rate"];
            }

            return rate;
        } //-----------------------------------

        //this function gets the rank degree increase rate
        public Decimal GetRankDegreeIncreaseRate(String degreeIdLevelPoints)
        {
            Decimal rate = 0;

            String strFilter = "degree_id = '" + degreeIdLevelPoints + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankDegreeTable"].Select(strFilter, "degree_no ASC");

            foreach (DataRow degRow in selectRow)
            {
                rate = (Decimal)degRow["increase_rate"];
            }

            return rate;
        } //----------------------------------

        //this function gets the rank rate rate id
        public Int64 GetRankRateId(String degreeIdLevelPoints)
        {
            Int64 rateId = 0;

            String strFilter = "degree_id = '" + degreeIdLevelPoints + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankDegreeTable"].Select(strFilter, "degree_no ASC");

            foreach (DataRow degRow in selectRow)
            {
                rateId = (Int64)degRow["rate_id"];
            }

            return rateId;
        } //----------------------------------

        //this function gets the rank degree id
        public String GetRankDegreeId(Int32 index, String categoryId)
        {
            String degId = "";

            String strFilter = "category_id = '" + categoryId + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankDegreeTable"].Select(strFilter, "degree_no ASC");

            foreach (DataRow degRow in selectRow)
            {
                if (index == (Byte)degRow["degree_no"])
                {
                    degId = degRow["degree_id"].ToString();
                    break;
                }
            }

            return degId;
        }

        //this function gets the rank degree id level points
        public String GetRankDegreeIdLevelPoints(Int32 index, String levelId)
        {
            String degId = "";
            Int32 rowCount = 0;

            String strFilter = "level_id = '" + levelId + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankDegreeTable"].Select(strFilter, "level_no, category_no, degree_no ASC");

            foreach (DataRow rateRow in selectRow)
            {
                if (index == rowCount)
                {
                    degId = rateRow["degree_id"].ToString();
                    break;
                }

                rowCount++;
            }

            return degId;
        } //--------------------------------

        //this function gets the rank category id
        public String GetRankCategoryId(Int32 index, String levelId)
        {
            String categoryId = "";

            String strFilter = "level_id = '" + levelId + "'";
            DataRow[] selectRow = _classDataSet.Tables["RankCategoryTable"].Select(strFilter, "category_no ASC");

            foreach (DataRow catRow in selectRow)
            {
                if (index == (Byte)catRow["category_no"]) 
                {
                    categoryId = catRow["category_id"].ToString();
                    break;
                }
            }

            return categoryId;
        }

        //this function gets the rank level id
        public String GetRankLevelId(String levelDescription, String typeId)
        {
            String levelId = "";
            String groupId = this.GetRankGroupId(typeId);

            foreach (DataRow levelRow in _classDataSet.Tables["RankLevelTable"].Rows)
            {
                if (String.Equals(levelDescription, levelRow["level_description"].ToString()) && 
                    String.Equals(groupId, levelRow["rank_group_id"].ToString()))
                {
                    levelId = levelRow["level_id"].ToString();
                    break;
                }
            }            

            return levelId;
        } //---------------------

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
               
        //this function gets the department id
        public String GetDepartmentId(Int32 index)
        {
            DataRow deptRow = _classDataSet.Tables["DepartmentInformationTable"].Rows[index];

            return deptRow["department_id"].ToString();

        } //----------------------------

        //this function gets the employment status id
        public Byte GetEmploymentStatusId(Int32 index)
        {
            Byte statusId = 0;

            foreach (DataRow statusRow in _classDataSet.Tables["EmploymentStatusTable"].Rows)
            {
                if (index == (Byte)statusRow["status_id"])
                {
                    statusId = (Byte)statusRow["status_id"];
                }
            }

            return statusId;

        } //---------------------------
        
        //this function determines if the employee id already exist
        public Boolean IsExistsEmployeeIdEmployeeInformation(CommonExchange.SysAccess userInfo, String empId, String sysId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntEmployeeManager remClient = new RemoteClient.RemCntEmployeeManager())
            {                
                isExist = remClient.IsExistsEmployeeIdEmployeeInformation(userInfo, empId, sysId);                
            }

            return isExist;

        } //----------------------------

        //this function gets the employment type description
        public String GetEmploymentTypeDescription(Byte typeNo)
        {
            String description = "";

            foreach (DataRow typeRow in _classDataSet.Tables["EmploymentTypeTable"].Rows)
            {
                if (typeNo == RemoteServerLib.ProcStatic.DataRowConvert(typeRow, "type_no", Byte.Parse("0")))
                {
                    description = RemoteServerLib.ProcStatic.DataRowConvert(typeRow, "type_description", "");
                    break;
                }
            }

            return description;

        } //------------------------------

        //this function gets the employment status description
        public String GetEmploymentStatusDescription(Byte statusId)
        {
            String description = "";

            foreach (DataRow typeRow in _classDataSet.Tables["EmploymentStatusTable"].Rows)
            {
                if (statusId == RemoteServerLib.ProcStatic.DataRowConvert(typeRow, "status_id", Byte.Parse("0")))
                {
                    description = RemoteServerLib.ProcStatic.DataRowConvert(typeRow, "status_description", "");
                    break;
                }
            }

            return description;

        } //-------------------------   
                
        //this function gets the rank group id
        private String GetRankGroupId(String typeId)
        {
            String groupId = "";

            foreach (DataRow typeRow in _classDataSet.Tables["EmploymentTypeTable"].Rows)
            {
                if (String.Equals(typeId, typeRow["employment_id"].ToString()))
                {
                    groupId = typeRow["rank_group_id"].ToString();
                    break;
                }
            }

            return groupId;

        } //------------------------
        #endregion
    }
}
