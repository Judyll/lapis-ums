using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CampusAccessServices
{
    public class CampusAccessLogic
    {
        #region Class Data Member Decleration
        private DataSet _classDataSet;
        private DataTable _studentEmployeeTable;
        DataTable _campusAccessDetailsTable;
        #endregion

        #region Class Properties Decleration
        private String _serverDateTime = String.Empty;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }
        #endregion

        #region Class Constructos
        public CampusAccessLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }
        #endregion

        #region Programmers-Defined Void Procedures
        //this procedure will initialize the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //set data set
            using (RemoteClient.RemCntCampusAccessManager remClient = new RemoteClient.RemCntCampusAccessManager())
            {
                _classDataSet = remClient.GetDataSetForCampusAccess(userInfo);
            }

            //set serverdate and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            }

            //initialize tables
            _campusAccessDetailsTable = new DataTable("CampusAccessTable");
            _campusAccessDetailsTable.Columns.Add("sysid_person", System.Type.GetType("System.String"));
            _campusAccessDetailsTable.Columns.Add("access_date_time", System.Type.GetType("System.DateTime"));
            _campusAccessDetailsTable.Columns.Add("access_point_id", System.Type.GetType("System.String"));
            //------------------------------
        }//-------------------------

        //this procedure will initialize access point combo
        public void InitializeAccessPointComboBox(ComboBox cboBase)
        {
            cboBase.Items.Add("-- Select an Access Point --");

            if (_classDataSet.Tables["AccessPointInformationTable"] != null)
            {
                foreach (DataRow accessRow in _classDataSet.Tables["AccessPointInformationTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "access_description", String.Empty));
                }
            }

            cboBase.SelectedIndex = 0;
        }//-----------------------------

        //this procedure will insert campuss access details update to database
        public void InsertCampusAccessDetails(CommonExchange.SysAccess userInfo)
        {
            try
            {
                if (File.Exists(Application.StartupPath + @"\campusaccessdetails.xml"))
                {
                    DataSet xmlDataSet = new DataSet();
                    xmlDataSet.ReadXml(Application.StartupPath + @"\campusaccessdetails.xml");

                    DataTable campusAccessDetailsTable = new DataTable("CampusAccessTable");
                    campusAccessDetailsTable = xmlDataSet.Tables["CampusAccessTable"];

                    xmlDataSet.Dispose();

                    if (campusAccessDetailsTable != null)
                    {
                        using (RemoteClient.RemCntCampusAccessManager remClient = new RemoteClient.RemCntCampusAccessManager())
                        {
                            remClient.InsertCampusAccessDetails(userInfo, campusAccessDetailsTable);

                            campusAccessDetailsTable = new DataTable("CampusAccessTable");
                            campusAccessDetailsTable.WriteXml(Application.StartupPath + @"\campusaccessdetails.xml");
                        }
                    }

                }
            }
            catch { }
        }//--------------------------

        //this procedure will insert campuss access details to Xml File
        public void InsertCampusAccessDetails(String personSysId, DateTime accessDateTime, String accessPointId)
        {
            if (File.Exists(Application.StartupPath + @"\campusaccessdetails.xml"))
            {
                if (_campusAccessDetailsTable != null)
                {
                    DataSet xmlDataSet = new DataSet();
                    xmlDataSet.ReadXml(Application.StartupPath + @"\campusaccessdetails.xml");
                                       
                    _campusAccessDetailsTable = xmlDataSet.Tables["CampusAccessTable"];

                    if (_campusAccessDetailsTable == null)
                    {
                        _campusAccessDetailsTable = new DataTable("CampusAccessTable");
                        _campusAccessDetailsTable.Columns.Add("sysid_person", System.Type.GetType("System.String"));
                        _campusAccessDetailsTable.Columns.Add("access_date_time", System.Type.GetType("System.String"));
                        _campusAccessDetailsTable.Columns.Add("access_point_id", System.Type.GetType("System.String"));
                    }

                    DataRow newRow = _campusAccessDetailsTable.NewRow();

                    newRow["sysid_person"] = personSysId;
                    newRow["access_date_time"] = accessDateTime.ToShortDateString() + " " + accessDateTime.ToLongTimeString();
                    newRow["access_point_id"] = accessPointId;

                    _campusAccessDetailsTable.Rows.Add(newRow);

                    _campusAccessDetailsTable.WriteXml(Application.StartupPath + @"\campusaccessdetails.xml");
                }
            }
        }//-----------------------------

        //this procedure will select student employee information
        public void SelectForCampusAccessStudentEmployeeInformation(CommonExchange.SysAccess userInfo)
        {
            using (RemoteClient.RemCntCampusAccessManager remClient = new RemoteClient.RemCntCampusAccessManager())
            {
                _studentEmployeeTable = remClient.SelectForCampusAccessStudentEmployeeInformation(userInfo, "*");
            }
        }//--------------------------

        //this procedure gets the student image path
        public void InitializePersonImages(CommonExchange.SysAccess userInfo, String personSysIdList, String startUpPath, ProgressBar pgbBase, Label lblBase)
        {
            try
            {
                DataTable imageTable = new DataTable("ImageTable");

                using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
                {
                    Int32 count = 0;
                    String[] strSplit = personSysIdList.Split(',');
                    String newPersonSysIdList = String.Empty;

                    pgbBase.Maximum = strSplit.Length * 2;

                    this.DeletePersonImagesDirectory(startUpPath);

                    //creates the directory
                    DirectoryInfo dirInfo = new DirectoryInfo(CommonExchange.SystemConfiguration.PersonImagesFolder(startUpPath));
                    dirInfo.Create();
                    dirInfo.Attributes = FileAttributes.Hidden;

                    Int32 x = 0;

                    foreach (String id in strSplit)
                    {
                        if (count <= 200)
                        {
                            newPersonSysIdList += id + ", ";

                            strSplit[x] = String.Empty;

                            pgbBase.PerformStep();
                        }
                        else if (count > 200)
                        {
                            imageTable = remClient.SelectPersonImagesPersonInformation(userInfo, newPersonSysIdList);

                            using (DataTableReader tableReader = new DataTableReader(imageTable))
                            {
                                if (tableReader.HasRows)
                                {
                                    Int32 picColumn = 1;

                                    while (tableReader.Read())
                                    {
                                        if (!tableReader.IsDBNull(picColumn))
                                        {
                                            String imagePath = CommonExchange.SystemConfiguration.PersonImagesFolder(startUpPath) + @"\";

                                            imagePath += tableReader["original_name"].ToString();

                                            long len = tableReader.GetBytes(picColumn, 0, null, 0, 0);
                                            // Create a buffer to hold the bytes, and then
                                            // read the bytes from the DataTableReader.
                                            Byte[] buffer = new Byte[len];
                                            tableReader.GetBytes(picColumn, 0, buffer, 0, (int)len);

                                            // Create a new Bitmap object, passing the array 
                                            // of bytes to the constructor of a MemoryStream.
                                            using (Bitmap studentImage = new Bitmap(new MemoryStream(buffer)))
                                            {
                                                if (!File.Exists(imagePath))
                                                {
                                                    studentImage.Save(imagePath);
                                                }
                                            }
                                        }

                                        pgbBase.PerformStep();

                                        lblBase.Text = "Copying images..." + tableReader["original_name"].ToString();
                                        lblBase.Refresh();
                                        Application.DoEvents();
                                    }
                                }

                                tableReader.Close();
                            }

                            count = 0;
                            newPersonSysIdList = String.Empty;
                            imageTable.Rows.Clear();

                            Thread.Sleep(200);
                        }

                        //pgbBase.PerformStep();

                        count++;
                    }

                    if (!String.IsNullOrEmpty(newPersonSysIdList))
                    {
                        imageTable = remClient.SelectPersonImagesPersonInformation(userInfo, newPersonSysIdList);

                        using (DataTableReader tableReader = new DataTableReader(imageTable))
                        {
                            if (tableReader.HasRows)
                            {
                                Int32 picColumn = 1;

                                while (tableReader.Read())
                                {
                                    if (!tableReader.IsDBNull(picColumn))
                                    {
                                        String imagePath = CommonExchange.SystemConfiguration.PersonImagesFolder(startUpPath) + @"\";

                                        imagePath += tableReader["original_name"].ToString();

                                        long len = tableReader.GetBytes(picColumn, 0, null, 0, 0);
                                        // Create a buffer to hold the bytes, and then
                                        // read the bytes from the DataTableReader.
                                        Byte[] buffer = new Byte[len];
                                        tableReader.GetBytes(picColumn, 0, buffer, 0, (int)len);

                                        // Create a new Bitmap object, passing the array 
                                        // of bytes to the constructor of a MemoryStream.
                                        using (Bitmap studentImage = new Bitmap(new MemoryStream(buffer)))
                                        {
                                            if (!File.Exists(imagePath))
                                            {
                                                studentImage.Save(imagePath);
                                            }
                                        }
                                    }

                                    pgbBase.PerformStep();

                                    lblBase.Text = "Coping images..." + tableReader["original_name"].ToString();
                                    lblBase.Refresh();
                                    Application.DoEvents();
                                }
                            }

                            tableReader.Close();
                        }

                        //pgbBase.PerformStep();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error");
                //DataTable imageTable = new DataTable("ImageTable");

                //using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
                //{

                //    Int32 count = 0;
                //    String[] strSplit = personSysIdList.Split(',');
                //    String newPersonSysIdList = String.Empty;

                //    Int32 x = 0;

                //    foreach (String id in strSplit)
                //    {
                //        if (count <= 200)
                //        {
                //            newPersonSysIdList += id + ", ";

                //            strSplit[x] = String.Empty;

                //            pgbBase.PerformStep();
                //        }
                //        else if (count > 200)
                //        {
                //            imageTable = remClient.SelectPersonImagesPersonInformation(userInfo, newPersonSysIdList);

                //            using (DataTableReader tableReader = new DataTableReader(imageTable))
                //            {
                //                if (tableReader.HasRows)
                //                {
                //                    Int32 picColumn = 1;

                //                    while (tableReader.Read())
                //                    {
                //                        if (!tableReader.IsDBNull(picColumn))
                //                        {
                //                            String imagePath = CommonExchange.SystemConfiguration.PersonImagesFolder(startUpPath) + @"\";

                //                            imagePath += tableReader["original_name"].ToString();

                //                            long len = tableReader.GetBytes(picColumn, 0, null, 0, 0);
                //                            // Create a buffer to hold the bytes, and then
                //                            // read the bytes from the DataTableReader.
                //                            Byte[] buffer = new Byte[len];
                //                            tableReader.GetBytes(picColumn, 0, buffer, 0, (int)len);

                //                            // Create a new Bitmap object, passing the array 
                //                            // of bytes to the constructor of a MemoryStream.
                //                            using (Bitmap studentImage = new Bitmap(new MemoryStream(buffer)))
                //                            {
                //                                if (!File.Exists(imagePath))
                //                                {
                //                                    studentImage.Save(imagePath);
                //                                }
                //                            }
                //                        }
                //                    }
                //                }

                //                tableReader.Close();
                //            }

                //            count = 0;
                //            imageTable.Rows.Clear();

                //            pgbBase.PerformStep();
                //            Thread.Sleep(200);
                //        }

                //        count++;
                //        x++;
                //    }
                //}
            }
        }//------------------------------

        //this procedure will delete the person images directory
        public void DeletePersonImagesDirectory(String startUpPath)
        {
            if (Directory.Exists(CommonExchange.SystemConfiguration.PersonImagesFolder(startUpPath)))
            {
                RemoteClient.ProcStatic.DeleteDirectory(CommonExchange.SystemConfiguration.PersonImagesFolder(startUpPath));
            }
        }//--------------------------------
        #endregion

        #region Programmers-Defined Functions
        //this function will get access point id
        public String GetAccessPointId(Int32 index)
        {
            String value = String.Empty;

            if (_classDataSet.Tables["AccessPointInformationTable"] != null && index > 0)
            {
                DataRow accessRow = _classDataSet.Tables["AccessPointInformationTable"].Rows[index - 1];

                value = RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "access_point_id", String.Empty);
            }

            return value;
        }//----------------------

        //this function will get access point description
        public String GetAccessPointDescription(String accessPointId)
        {
            String value = String.Empty;

            if (_classDataSet.Tables["AccessPointInformationTable"] != null)
            {
                String strFilter = "access_point_id = '" + accessPointId + "'";
                DataRow[] selectRow = _classDataSet.Tables["AccessPointInformationTable"].Select(strFilter);

                foreach (DataRow pointRow in selectRow)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(pointRow, "access_description", String.Empty);
                    break;
                }
            }

            return value;
        }//--------------------------

        //this function will determin if a person person information exist
        public Boolean IsExistPersonInformation(String cardNo)
        {
            if (_studentEmployeeTable != null)
            {
                String strFilter = "card_number = '" + cardNo + "'";
                DataRow[] selectRow = _studentEmployeeTable.Select(strFilter);

                return selectRow.Length >= 1 ? true : false;
            }
            else
            {
                return false;
            }
        }//-----------------------------------

        //this function will get original name by card number
        public String GetImageOrignalName(String cardNo)
        {
            String strValue = String.Empty;

            if (_studentEmployeeTable != null)
            {
                String strFilter = "card_number = '" + cardNo + "'";
                DataRow[] selectRow = _studentEmployeeTable.Select(strFilter);

                foreach (DataRow cardRow in selectRow)
                {
                    strValue = RemoteServerLib.ProcStatic.DataRowConvert(cardRow, "original_name", String.Empty);

                    break;
                }
            }

            return strValue;
        }//---------------------

        //this fucntion will get person system id
        public String GetPersonSystemId(String cardNo)
        {
            String strValue = String.Empty;

            if (_studentEmployeeTable != null)
            {
                String strFilter = "card_number = '" + cardNo + "'";
                DataRow[] selectRow = _studentEmployeeTable.Select(strFilter);

                foreach (DataRow cardRow in selectRow)
                {
                    strValue = RemoteServerLib.ProcStatic.DataRowConvert(cardRow, "sysid_person", String.Empty);

                    break;
                }
            }

            return strValue;
        }//-------------------------

        //this fucntion will get person last name or first name middle name
        public String GetPersonLastNameFirstName(String cardNo, Boolean isLastName)
        {
            String strValue = String.Empty;

            if (_studentEmployeeTable != null)
            {
                String strFilter = "card_number = '" + cardNo + "'";
                DataRow[] selectRow = _studentEmployeeTable.Select(strFilter);

                foreach (DataRow cardRow in selectRow)
                {
                    strValue = isLastName ? RemoteServerLib.ProcStatic.DataRowConvert(cardRow, "last_name", String.Empty) :
                        RemoteServerLib.ProcStatic.DataRowConvert(cardRow, "first_name", String.Empty) + " " +
                        RemoteServerLib.ProcStatic.DataRowConvert(cardRow, "middle_name", String.Empty);

                    break;
                }
            }

            return strValue;
        }//-------------------------

        //this function will get image information by card number
        public String GetImageInformation(String cardNo, Boolean isName)
        {
            String strValue = String.Empty;

            if (_studentEmployeeTable != null)
            {
                String strFilter = "card_number = '" + cardNo + "'";
                DataRow[] selectRow = _studentEmployeeTable.Select(strFilter);

                foreach (DataRow cardRow in selectRow)
                {
                    strValue = isName ? RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(cardRow, "last_name", "first_name", "middle_name") :
                        RemoteServerLib.ProcStatic.DataRowConvert(cardRow, "student_employee_id", String.Empty);

                    break;
                }
            }

            return strValue;
        }//-------------------------

        //this fucntion will get person sysid list
        public String GetPersonSysIdListFormat(ProgressBar pgbBase,ref Label lblBase)
        {
            StringBuilder strValue = new StringBuilder();

            if (_studentEmployeeTable != null)
            {
                pgbBase.Maximum = _studentEmployeeTable.Rows.Count;

                foreach (DataRow studEmpRow in _studentEmployeeTable.Rows)
                {
                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studEmpRow, "sysid_person", String.Empty)))
                    {
                        strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studEmpRow, "sysid_person", "") + ", ");

                        pgbBase.PerformStep();

                        lblBase.Text = "Initializing person information..." +
                            RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(studEmpRow, "last_name", "first_name", "middle_name");

                        lblBase.Refresh();
                        Application.DoEvents();
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
        }//-----------------------------
        #endregion
    }
}
