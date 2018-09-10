using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace RegistrarServices
{
    internal class SchoolYearLogic
    {
        #region Class General Variable Declarations
        private DataSet _classDataSet;
        private CommonExchange.RegistrarStandard _stdRegistrar;
        private DataTable _schoolYearTable;
        private DataTable _semesterTable;
        #endregion

        #region Class Properties Declarations
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }
        #endregion

        #region Class Constructor

        public SchoolYearLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure insterst a school semester information
        public void InsertSemesterInformation(CommonExchange.SysAccess userInfo, CommonExchange.SemesterInformation semInfo)
        {
            using (RemoteClient.RemCntSchoolYearSemesterManager remClient = new RemoteClient.RemCntSchoolYearSemesterManager())
            {
                remClient.InsertSemesterInformation(userInfo, ref semInfo);
            }

            if (_semesterTable != null)
            {
                DataRow newRow = _semesterTable.NewRow();

                newRow["sysid_semester"] = semInfo.SemesterSysId;
                newRow["year_id"] = semInfo.YearId;
                newRow["semester_id"] = semInfo.SemesterId;
                newRow["date_start"] = semInfo.DateStart;
                newRow["date_end"] = semInfo.DateEnd;
                newRow["year_description"] = semInfo.SchoolYearDescription;
                newRow["semester_description"] = semInfo.SchoolSemesterDescription;

                _semesterTable.Rows.Add(newRow);
                _semesterTable.AcceptChanges();
            }            

        } //---------------------------------

        //this procedure inserts a school year
        public void InsertSchoolYear(CommonExchange.SysAccess userInfo, CommonExchange.SchoolYear yearInfo)
        {
            using (RemoteClient.RemCntSchoolYearSemesterManager remClient = new RemoteClient.RemCntSchoolYearSemesterManager())
            {
                remClient.InsertSchoolYear(userInfo, ref yearInfo);
            }

            if (_schoolYearTable != null)
            {
                DataRow newRow = _schoolYearTable.NewRow();

                newRow["year_id"] = yearInfo.YearId;
                newRow["year_description"] = yearInfo.Description;
                newRow["date_start"] = yearInfo.DateStart;
                newRow["date_end"] = yearInfo.DateEnd;

                _schoolYearTable.Rows.Add(newRow);
                _schoolYearTable.AcceptChanges();
            }
            
        } //------------------------------------

        //this procedure initializes the school semester combo box
        public void InitializeSchoolSemesterCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow semRow in _classDataSet.Tables["SchoolSemesterTable"].Rows)
            {
                cboBase.Items.Add(semRow["semester_description"].ToString());
            }

        } //--------------------------

        //this procedure initializes the school semester combo box
        public void InitializeSchoolSemesterCombo(ComboBox cboBase, Byte semId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            foreach (DataRow semRow in _classDataSet.Tables["SchoolSemesterTable"].Rows)
            {
                cboBase.Items.Add(semRow["semester_description"].ToString());

                if (semId == (Byte)semRow["semester_id"])
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }
        } //----------------------------------

        //this procedure refreshes the school year semester data
        public void RefreshSchoolYearSemesterData(CommonExchange.SysAccess userInfo)
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

            //gets the dataset for the school year information
            using (RemoteClient.RemCntSchoolYearSemesterManager remClient = new RemoteClient.RemCntSchoolYearSemesterManager())
            {
                _classDataSet = remClient.GetDataSetForSchoolYearSemeter(userInfo);
            } //-----------------------

            //gets the registrar standard
            using (RemoteClient.RemCntSchoolYearSemesterManager remClient = new RemoteClient.RemCntSchoolYearSemesterManager())
            {
                _stdRegistrar = remClient.SelectRegistrarStandard(userInfo);
            } //------------------

        } //-----------------------

        #endregion

        #region Programmer-Defined Void Procedures

        //this function returns the last opened semeter information
        public CommonExchange.SemesterInformation GetNextOpenedSemesterInformation(CommonExchange.SysAccess userInfo, ref Boolean hasErrors)
        {
            CommonExchange.SemesterInformation nextSemInfo = new CommonExchange.SemesterInformation();

            nextSemInfo.YearId = this.GetSchoolYearIdForSemester(userInfo, ref hasErrors);

            if (!hasErrors)
            {
                nextSemInfo.SemesterId = this.GetSchoolSemesterId(nextSemInfo.YearId);                
                nextSemInfo.DateStart = this.GetSemesterInformationDateStart(userInfo).ToString();
                nextSemInfo.DateEnd = this.GetSemesterInformationDateEnd(DateTime.Parse(nextSemInfo.DateStart), 
                                            nextSemInfo.SemesterId).ToString();
                nextSemInfo.SchoolYearDescription = this.GetSchoolYearInformationDescription(nextSemInfo.YearId);
                nextSemInfo.SchoolSemesterDescription = this.GetSchoolSemesterDescription(nextSemInfo.SemesterId);
            }
            
            return nextSemInfo;

        } //---------------------------------        

        //this function gets the next opened school year
        public CommonExchange.SchoolYear GetNextOpenedSchoolYearInformation(CommonExchange.SysAccess userInfo)
        {
            CommonExchange.SchoolYear nextYearInfo = new CommonExchange.SchoolYear();

            nextYearInfo.DateStart = this.GetSchoolYearDateStart(userInfo).ToString();
            nextYearInfo.DateEnd = this.GetSchoolYearDateEnd(DateTime.Parse(nextYearInfo.DateStart)).ToString();
            nextYearInfo.Description = this.GetSchoolYearDescription(DateTime.Parse(nextYearInfo.DateStart), DateTime.Parse(nextYearInfo.DateEnd));

            return nextYearInfo;

        } //-----------------------------------

        //this function gets the school year information details
        public CommonExchange.SchoolYear GetSchoolYearInformationDetails(String yearId)
        {
            CommonExchange.SchoolYear yearInfo = new CommonExchange.SchoolYear();

            if (_schoolYearTable != null)
            {
                String strFilter = "year_id = '" + yearId + "'";
                DataRow[] selectRow = _schoolYearTable.Select(strFilter, "year_id DESC");

                foreach (DataRow yearRow in selectRow)
                {
                    yearInfo.YearId = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", "");
                    yearInfo.Description = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
                    yearInfo.DateStart = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", "");
                    yearInfo.DateEnd = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", "");
                } 
            }

            return yearInfo;
        } //----------------------------

        //this function gets the semester information details
        public CommonExchange.SemesterInformation GetSemesterInformationDetails(String semId)
        {
            CommonExchange.SemesterInformation semInfo = new CommonExchange.SemesterInformation();

            if (_semesterTable != null)
            {
                String strFilter = "sysid_semester = '" + semId + "'";
                DataRow[] selectRow = _semesterTable.Select(strFilter, "sysid_semester DESC");

                foreach (DataRow semRow in selectRow)
                {
                    semInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
                    semInfo.YearId = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_id", "");
                    semInfo.SemesterId = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_id", Byte.Parse("0"));
                    semInfo.DateStart = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_start", "");
                    semInfo.DateEnd = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_end", "");
                    semInfo.SchoolYearDescription = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_description", "");
                    semInfo.SchoolSemesterDescription = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", "");
                }
            }            

            return semInfo;
        } //-----------------------------------

        //this function returns a searched school year
        public DataTable GetSearchedSchoolYearInformation(CommonExchange.SysAccess userInfo, String queryString, Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntSchoolYearSemesterManager remClient = new RemoteClient.RemCntSchoolYearSemesterManager())
                {
                    _schoolYearTable = remClient.SelectByYearDescriptionSchoolYearTable(userInfo, queryString);
                }
            }

            DataTable newTable = new DataTable("SchoolYearInformationSearchTable");
            newTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("year_description", System.Type.GetType("System.String"));

            if (_schoolYearTable != null)
            {
                foreach (DataRow yearRow in _schoolYearTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["year_id"] = yearRow["year_id"].ToString();
                    newRow["year_description"] = yearRow["year_description"].ToString();

                    newTable.Rows.Add(newRow);
                }
            }            

            newTable.AcceptChanges();

            return newTable;

        } //---------------------------

        //this function returns a searched semester information
        public DataTable GetSearchedSemesterInformation(CommonExchange.SysAccess userInfo, String queryString, Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntSchoolYearSemesterManager remClient = new RemoteClient.RemCntSchoolYearSemesterManager())
                {
                    _semesterTable = remClient.SelectYearSemesterDescriptionSemesterInformationTable(userInfo, queryString);
                }
            }

            DataTable newTable = new DataTable("SemesterInformationSearchedTable");
            newTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
            newTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

            if (_semesterTable != null)
            {
                foreach (DataRow semRow in _semesterTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_semester"] = semRow["sysid_semester"];
                    newRow["year_description"] = semRow["year_description"];
                    newRow["semester_description"] = semRow["semester_description"];

                    newTable.Rows.Add(newRow);
                }
            }            

            newTable.AcceptChanges();

            return newTable;

        } //----------------------------

        //this function gets the school year start date
        private DateTime GetSchoolYearDateStart(CommonExchange.SysAccess userInfo)
        {
            DateTime dateStart;

            using (RemoteClient.RemCntSchoolYearSemesterManager remClient = new RemoteClient.RemCntSchoolYearSemesterManager())
            {
                DateTime dateEnd;

                if (DateTime.TryParse(remClient.GetMaxDateEndSchoolYear(userInfo), out dateEnd))
                {
                    dateStart = DateTime.Parse(_stdRegistrar.SchoolYearStart.ToString() + "/01/" +
                                        dateEnd.Year.ToString() + " 12:00:00 AM");
                }
                else
                {
                    dateStart = DateTime.Parse(_stdRegistrar.SchoolYearStart.ToString() + "/01/" +
                                        DateTime.Parse(_serverDateTime).Year.ToString() + " 12:00:00 AM");
                }
            }

            return dateStart;

        } //-------------------------

        //this function gets the school year end date
        private DateTime GetSchoolYearDateEnd(DateTime dateStart)
        {
            return DateTime.Parse(dateStart.AddMonths(11).Month.ToString() + "/" +
                DateTime.DaysInMonth(dateStart.AddMonths(11).Year, dateStart.AddMonths(11).Month).ToString() + "/" + 
                dateStart.AddMonths(11).Year.ToString() + " 11:59:59 PM");

        } //------------------------------

        //this function gets the school year description
        private String GetSchoolYearDescription(DateTime dateStart, DateTime dateEnd)
        {
            return "S.Y. " + dateStart.Year.ToString() + " - " + dateEnd.Year.ToString();
        } //----------------------------

        //this function returns the school semester description
        private String GetSchoolSemesterDescription(Byte semId)
        {
            String description = "";

            String strFilter = "semester_id = '" + semId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolSemesterTable"].Select(strFilter, "semester_id DESC");

            foreach (DataRow semRow in selectRow)
            {
                description = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", "");
            }

            return description;
        } //----------------------------------

        //this function gets the school year information description
        private String GetSchoolYearInformationDescription(String yearId)
        {
            String description = "";

            if (_schoolYearTable != null)
            {
                String strFilter = "year_id = '" + yearId + "'";
                DataRow[] selectRow = _schoolYearTable.Select(strFilter, "year_id DESC");

                foreach (DataRow yearRow in selectRow)
                {
                    description = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
                }
            }            

            return description;
        } //----------------------------

        //this function returns a school semester id
        private Byte GetSchoolSemesterId(String yearId)
        {
            if (_semesterTable != null)
            {
                String strFilter = "year_id = '" + yearId + "'";
                DataRow[] selectRow = _semesterTable.Select(strFilter, "sysid_semester DESC");

                return (Byte)(selectRow.Length + 1);
            }
            else
            {
                return 0;
            }
            
        } //-----------------------------

        //this function returns the school year id for a semester
        private String GetSchoolYearIdForSemester(CommonExchange.SysAccess userInfo, ref Boolean hasErrors)
        {
            String semId = "";

            using (RemoteClient.RemCntSchoolYearSemesterManager remClient = new RemoteClient.RemCntSchoolYearSemesterManager())
            {
                _schoolYearTable = remClient.SelectByYearDescriptionSchoolYearTable(userInfo, "*");
            }

            using (RemoteClient.RemCntSchoolYearSemesterManager remClient = new RemoteClient.RemCntSchoolYearSemesterManager())
            {
                _semesterTable = remClient.SelectYearSemesterDescriptionSemesterInformationTable(userInfo, "*");
            }

            if (_schoolYearTable != null && _semesterTable != null)
            {
                foreach (DataRow yearRow in _schoolYearTable.Rows)
                {
                    String yearId = yearRow["year_id"].ToString();

                    String strFilter = "year_id = '" + yearId + "'";
                    DataRow[] selectRow = _semesterTable.Select(strFilter, "sysid_semester DESC");

                    if (selectRow.Length < (Int32)CommonExchange.SchoolSemester.Summer)
                    {
                        semId = yearId;

                        break;
                    }
                }
            }            

            if (String.IsNullOrEmpty(semId))
            {
                hasErrors = true;
            }
            else
            {
                hasErrors = false;
            }

            return semId;

        } //---------------------------

        //this function gets the semester information start date
        private DateTime GetSemesterInformationDateStart(CommonExchange.SysAccess userInfo)
        {
            DateTime maxDate;

            using (RemoteClient.RemCntSchoolYearSemesterManager remClient = new RemoteClient.RemCntSchoolYearSemesterManager())
            {
                if (!DateTime.TryParse(remClient.GetMaxDateEndSemesterInformation(userInfo), out maxDate))
                {
                    maxDate = DateTime.Parse(_stdRegistrar.SchoolYearStart.ToString() + "/01/" +
                                        DateTime.Parse(_serverDateTime).Year.ToString() + " 12:00:00 AM");
                }
            }

            return DateTime.Parse(maxDate.AddMonths(1).Month.ToString() + "/01/" + maxDate.AddMonths(1).Year.ToString() + " 12:00:00 AM");

        } //-------------------------------

        //this function gets the semester information end date
        private DateTime GetSemesterInformationDateEnd(DateTime dateStart, Byte schoolSemId)
        {
            Byte addMonths;

            if (schoolSemId == (Byte)CommonExchange.SchoolSemester.Summer)
            {
                addMonths = (Byte)(_stdRegistrar.SummerMonths - 1);
            }
            else
            {
                addMonths = (Byte)(_stdRegistrar.SemesterMonths - 1);
            }

            return DateTime.Parse(dateStart.AddMonths(addMonths).Month.ToString() + "/" +
                    DateTime.DaysInMonth(dateStart.AddMonths(addMonths).Year, dateStart.AddMonths(addMonths).Month).ToString() + "/" +
                    dateStart.AddMonths(addMonths).Year.ToString() + " 11:59:59 PM");
        } //-------------------------------------

        #endregion
    }
}
