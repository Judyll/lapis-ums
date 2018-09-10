using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace RegistrarServices
{
    internal class TranscriptLogic 
    {
        #region Class Data Member Declaration
        private DataTable _transcriptInformationTable;
        private DataTable _transcriptDetailsTable;
        private DataTable _copiedSubjectTable;
        private DataTable _cutTranscriptDetailsTable;
        private DataTable _copiedTranscriptDetailsTable;
        #endregion

        #region Class Properties Declarations
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }
        #endregion

        #region Class Constructors
        public TranscriptLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure initializes the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //----------------------

            _copiedSubjectTable = new DataTable("CopiedSubjectTable");
            _copiedSubjectTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            _copiedSubjectTable.Columns.Add("subject_no", System.Type.GetType("System.String"));
            _copiedSubjectTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            _copiedSubjectTable.Columns.Add("credit_units", System.Type.GetType("System.String"));
            _copiedSubjectTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            _copiedSubjectTable.Columns.Add("sysid_special", System.Type.GetType("System.String"));

            _cutTranscriptDetailsTable = new DataTable("CutTranscriptDetailsTable");
            _cutTranscriptDetailsTable.Columns.Add("term_session", System.Type.GetType("System.String"));
            _cutTranscriptDetailsTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            _cutTranscriptDetailsTable.Columns.Add("subject_no", System.Type.GetType("System.String"));
            _cutTranscriptDetailsTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            _cutTranscriptDetailsTable.Columns.Add("credit_units", System.Type.GetType("System.String"));
            _cutTranscriptDetailsTable.Columns.Add("final_grade", System.Type.GetType("System.String"));
            _cutTranscriptDetailsTable.Columns.Add("re_exam", System.Type.GetType("System.String"));
            _cutTranscriptDetailsTable.Columns.Add("no_of_hours", System.Type.GetType("System.String"));
            _cutTranscriptDetailsTable.Columns.Add("sequence_no", System.Type.GetType("System.Int16"));
            _cutTranscriptDetailsTable.Columns.Add("transcript_id", System.Type.GetType("System.Int64"));
            _cutTranscriptDetailsTable.Columns.Add("sysid_schedule_no_freeze", System.Type.GetType("System.String"));
            _cutTranscriptDetailsTable.Columns.Add("sysid_special_no_freeze", System.Type.GetType("System.String"));

            _copiedTranscriptDetailsTable  = new DataTable("CopiedTranscriptDetailsTable");
            _copiedTranscriptDetailsTable.Columns.Add("term_session", System.Type.GetType("System.String"));
            _copiedTranscriptDetailsTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            _copiedTranscriptDetailsTable.Columns.Add("subject_no", System.Type.GetType("System.String"));
            _copiedTranscriptDetailsTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            _copiedTranscriptDetailsTable.Columns.Add("credit_units", System.Type.GetType("System.String"));
            _copiedTranscriptDetailsTable.Columns.Add("final_grade", System.Type.GetType("System.String"));
            _copiedTranscriptDetailsTable.Columns.Add("re_exam", System.Type.GetType("System.String"));
            _copiedTranscriptDetailsTable.Columns.Add("no_of_hours", System.Type.GetType("System.String"));
            _copiedTranscriptDetailsTable.Columns.Add("sequence_no", System.Type.GetType("System.Int16"));
            _copiedTranscriptDetailsTable.Columns.Add("transcript_id", System.Type.GetType("System.Int64"));
            _copiedTranscriptDetailsTable.Columns.Add("sysid_schedule_no_freeze", System.Type.GetType("System.String"));
            _copiedTranscriptDetailsTable.Columns.Add("sysid_special_no_freeze", System.Type.GetType("System.String"));
        }//---------------------------     

        //this procedure refreshes the special class data
        public void RefreshSpecialClassData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        } //--------------------------------

        //this procedure will print student transcript of record
        public void PrintStudentTranscriptOfRecord(CommonExchange.SysAccess userInfo, CommonExchange.TranscriptInformation transcriptInfo,
            Image studentImage, DataTable transcriptDetailsTable, Boolean includePicture)
        {
            DataTable studentImageTable = new DataTable("StudentImageTable");
            studentImageTable.Columns.Add("image", System.Type.GetType("System.Byte[]"));
            studentImageTable.Columns.Add("is_null", System.Type.GetType("System.Boolean"));

            if (!includePicture)
            {
                studentImage = null;
            }

            ImageConverter converter = new ImageConverter();

            Byte[] imgByte = (Byte[])converter.ConvertTo(studentImage, typeof(Byte[]));

            DataRow imageRow = studentImageTable.NewRow();

            imageRow["image"] = imgByte;
            imageRow["is_null"] = imgByte.Length <= 0 ? true : false;

            studentImageTable.Rows.Add(imageRow);            

            using (ClassTranscriptManager.CrystalReport.CrystalStudentTranscript rpttranscript =
                new RegistrarServices.ClassTranscriptManager.CrystalReport.CrystalStudentTranscript())
            {
                String courseTitle = !String.IsNullOrEmpty(transcriptInfo.CourseTitle) ?" (" + transcriptInfo.CourseTitle + ")" : String.Empty;

                rpttranscript.Database.Tables["student_image_table"].SetDataSource(studentImageTable);
                rpttranscript.Database.Tables["transcript_details_table"].SetDataSource(transcriptDetailsTable);

                rpttranscript.SetParameterValue("@school_code","Institutional Identifier: " + CommonExchange.SchoolInformation.InstitutionalIdentifier);
                rpttranscript.SetParameterValue("@transcript_code", CommonExchange.SchoolInformation.TranscriptFormCode);
                rpttranscript.SetParameterValue("@name", RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(transcriptInfo.LastName,
                    transcriptInfo.FirstName, transcriptInfo.MiddleName).ToUpper());
                rpttranscript.SetParameterValue("@student_id", transcriptInfo.StudentId);
                rpttranscript.SetParameterValue("@course", transcriptInfo.DepartmentName + courseTitle);
                rpttranscript.SetParameterValue("@department", transcriptInfo.DepartmentName);
                rpttranscript.SetParameterValue("@entrance_data", transcriptInfo.EntranceData);
                rpttranscript.SetParameterValue("@record_of_graduation", transcriptInfo.RecordsOfGraduation);
                rpttranscript.SetParameterValue("@purpose_of_request", transcriptInfo.PurposeOfRequest);
                rpttranscript.SetParameterValue("@date", DateTime.Parse(_serverDateTime).ToShortDateString());
                rpttranscript.SetParameterValue("@university_registrar", CommonExchange.SchoolInformation.UniversityRegistrar);
                rpttranscript.SetParameterValue("@print_info", "Prepared by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));
                rpttranscript.SetParameterValue("@checked_by", "Checked by: " + CommonExchange.SchoolInformation.RegistrarClerk);
    
                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rpttranscript))
                {
                    frmViewer.Text = "   Transcript Information";
                    frmViewer.ShowDialog();
                }
            }
        }//-------------------------------

        //this procedure will insert transcript information
        public void InsertTranscriptInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.TranscriptInformation transcriptInfo, 
            DataTable transcriptDetailsTable)
        {
            using (RemoteClient.RemCntTranscriptManager remClient = new RemoteClient.RemCntTranscriptManager())
            {
                remClient.InsertTranscriptInformation(userInfo, ref transcriptInfo);

                if (transcriptDetailsTable != null)
                {
                    remClient.InsertUpdateDeleteTranscriptDetails(userInfo, transcriptInfo.TranscriptSysId, transcriptDetailsTable);
                }
            }
        }//------------------------

        //this procedure will update transcript information
        public void UpdateTranscriptInformation(CommonExchange.SysAccess userInfo, CommonExchange.TranscriptInformation transcriptInfo, DataTable transcriptDetailsTable)
        {
            using (RemoteClient.RemCntTranscriptManager remClient = new RemoteClient.RemCntTranscriptManager())
            {
                remClient.UpdateTranscriptInformation(userInfo, transcriptInfo);

                if (transcriptDetailsTable != null)
                {
                    remClient.InsertUpdateDeleteTranscriptDetails(userInfo, transcriptInfo.TranscriptSysId, transcriptDetailsTable);
                }
            }
        }
        //------------------------

        //this function gets the student image path
        public String GetPersonImagePathTranscript(CommonExchange.SysAccess userInfo, String transcriptSysIdList, String imagePath)
        {
            try
            {
                //creates the directory
                DirectoryInfo dirInfo = new DirectoryInfo(imagePath);
                dirInfo.Create();
                dirInfo.Attributes = FileAttributes.Hidden;

                DataTable imageTable;

                using (RemoteClient.RemCntTranscriptManager remClient = new RemoteClient.RemCntTranscriptManager())
                {
                    imageTable = remClient.SelectTranscriptImagesTranscriptInformation(userInfo, transcriptSysIdList);
                }

                using (DataTableReader tableReader = new DataTableReader(imageTable))
                {
                    if (tableReader.HasRows)
                    {
                        Int32 picColumn = 1;

                        while (tableReader.Read())
                        {
                            if (!tableReader.IsDBNull(picColumn))
                            {
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
                                    else
                                    {
                                        File.Delete(imagePath);

                                        studentImage.Save(imagePath);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        imagePath = null;
                    }

                    tableReader.Close();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error");
            }

            return imagePath;
        }//------------------------------

        //this function gets the student image path
        public void InitializePersonImages(CommonExchange.SysAccess userInfo, String transcriptSysIdList, 
            List<CommonExchange.TranscriptInformation> transcriptInfoList, String startUp)
        {
            try
            {
                DataTable imageTable;

                using (RemoteClient.RemCntTranscriptManager remClient = new RemoteClient.RemCntTranscriptManager())
                {
                    imageTable = remClient.SelectTranscriptImagesTranscriptInformation(userInfo, transcriptSysIdList);
                }

                using (DataTableReader tableReader = new DataTableReader(imageTable))
                {
                    if (tableReader.HasRows)
                    {
                        Int32 picColumn = 1;

                        while (tableReader.Read())
                        {
                            CommonExchange.TranscriptInformation transcriptInfo = new CommonExchange.TranscriptInformation();

                            String imagePath = String.Empty;

                            foreach (CommonExchange.TranscriptInformation list in transcriptInfoList)
                            {
                                if (String.Equals(tableReader["sysid_transcript"].ToString(), list.TranscriptSysId))
                                {
                                    transcriptInfo = list;

                                    imagePath = transcriptInfo.PersonImagesFolder(startUp);

                                    break;
                                }
                            }

                            RemoteClient.ProcStatic.DeleteDirectory(imagePath);

                            //creates the directory
                            DirectoryInfo dirInfo = new DirectoryInfo(imagePath);
                            dirInfo.Create();
                            dirInfo.Attributes = FileAttributes.Hidden;


                            if (!tableReader.IsDBNull(picColumn))
                            {
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
                        }
                    }


                    tableReader.Close();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message,"Error");
            }
        }//------------------------------

        //this procedure will populate copied subject table
        public void SetCopiedSubjectTable(ListView lsvBase, Boolean isForSpecialClass)
        {
            if (_copiedSubjectTable != null)
            {
                _copiedSubjectTable.Rows.Clear();

                foreach (ListViewItem lstItem in lsvBase.CheckedItems)
                {
                    String[] strBaseString = lstItem.SubItems[1].Text.Split('-');
                    String[] strSubjectCodeNo = strBaseString[0].Split(' ');

                    String creditUnits = creditUnits = (Int32.Parse(lstItem.SubItems[2].Text) + Int32.Parse(lstItem.SubItems[3].Text)).ToString();
                    Boolean isNonAccademic = false;

                    if (Boolean.TryParse(lstItem.SubItems[5].Text.ToString(), out isNonAccademic))
                    {
                        if (isNonAccademic)
                        {
                            creditUnits = "(" + (Int32.Parse(lstItem.SubItems[2].Text) + Int32.Parse(lstItem.SubItems[3].Text)).ToString() + ")";
                        }
                    }

                    DataRow newRow = _copiedSubjectTable.NewRow();

                    newRow["subject_code"] = RemoteClient.ProcStatic.TrimStartEndString(strSubjectCodeNo[0]);

                    if (strSubjectCodeNo.Length > 1)
                    {
                        newRow["subject_no"] = RemoteClient.ProcStatic.TrimStartEndString(strSubjectCodeNo[1]);
                    }

                    if (strBaseString.Length > 1)
                    {
                        newRow["descriptive_title"] = RemoteClient.ProcStatic.TrimStartEndString(strBaseString[1]);
                    }

                    newRow["credit_units"] = creditUnits;

                    if (!isForSpecialClass)
                    {
                        newRow["sysid_schedule"] = lstItem.SubItems[7].Text;
                        newRow["sysid_special"] = String.Empty;
                    }
                    else
                    {
                        newRow["sysid_schedule"] = String.Empty;
                        newRow["sysid_special"] = lstItem.SubItems[7].Text;
                    }

                    _copiedSubjectTable.Rows.Add(newRow);
                }
            }
        }//-----------------------

        //this procedure will copy transcript details
        public void SetCopyTranscriptDetails(DataGridView dgvBase)
        {
            DataTable detailsTable = new DataTable("DetailsTable");

            if (dgvBase != null && _copiedTranscriptDetailsTable != null)
            {
                _copiedTranscriptDetailsTable.Rows.Clear();

                List<DataGridViewRow> selectedRowList = new List<DataGridViewRow>();

                foreach (DataGridViewRow sRow in dgvBase.SelectedRows)
                {
                    selectedRowList.Add(sRow);
                }

                detailsTable = (DataTable)dgvBase.DataSource;

                foreach (DataGridViewRow list in selectedRowList)
                {
                    foreach (DataRow detailsRow in detailsTable.Rows)
                    {
                        if (detailsRow.RowState != DataRowState.Deleted)
                        {
                            if (String.Equals(list.Cells["sequence_no"].Value.ToString(),
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sequence_no", Int16.Parse("0")).ToString()))
                            {
                                DataRow newRow = _copiedTranscriptDetailsTable.NewRow();

                                newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "term_session", String.Empty);
                                newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "subject_code", String.Empty);
                                newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "subject_no", String.Empty);
                                newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "descriptive_title", String.Empty);
                                newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "credit_units", String.Empty);
                                newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "final_grade", String.Empty);
                                newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "re_exam", String.Empty);
                                newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "no_of_hours", String.Empty);
                                newRow["sequence_no"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sequence_no", Int16.Parse("0"));
                                newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "transcript_id", String.Empty);

                                if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_schedule_no_freeze", String.Empty)))
                                {
                                    newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_schedule_no_freeze", String.Empty);
                                }
                                else
                                {
                                    newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                                }

                                if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_special_no_freeze", String.Empty)))
                                {
                                    newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_special_no_freeze", String.Empty);
                                }
                                else
                                {
                                    newRow["sysid_special_no_freeze"] = DBNull.Value;
                                }

                                _copiedTranscriptDetailsTable.Rows.Add(newRow);

                            }
                        }
                    }
                }
            }
        }//--------------------------
        #endregion

        #region Programmer-Defined Void Procedures
        //this function will select transcript information
        public DataTable SelectTranscriptInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            using (RemoteClient.RemCntTranscriptManager remClient = new RemoteClient.RemCntTranscriptManager())
            {
                _transcriptInformationTable = remClient.SelectTranscriptInformation(userInfo, queryString);                
            }

            DataTable newTable = new DataTable("TranscriptTable");
            newTable.Columns.Add("sysid_transcript", System.Type.GetType("System.String"));
            newTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            
           
            if (_transcriptInformationTable != null)
            {
                foreach (DataRow transRow in _transcriptInformationTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_transcript"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "sysid_transcript", String.Empty);
                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "student_id", String.Empty);
                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(transRow, "last_name", "first_name", "middle_name");
                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "course_title", String.Empty);
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "department_name", String.Empty);                    
                   
                    newTable.Rows.Add(newRow);
                }
            }
            
            return newTable;
        }//-------------------------

        //this function will select transcript informatiod details
        public DataTable SelectBySysIDTranscriptDetails(CommonExchange.SysAccess userInfo, String transcriptSysId, Boolean isCreate)
        {
            DataTable newTable = new DataTable("TranscriptDetailsTable");
            newTable.Columns.Add("term_session", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_no", System.Type.GetType("System.String"));
            newTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("credit_units", System.Type.GetType("System.String"));
            newTable.Columns.Add("final_grade", System.Type.GetType("System.String"));
            newTable.Columns.Add("re_exam", System.Type.GetType("System.String"));
            newTable.Columns.Add("no_of_hours", System.Type.GetType("System.String"));
            newTable.Columns.Add("sequence_no", System.Type.GetType("System.Int16"));
            newTable.Columns.Add("transcript_id", System.Type.GetType("System.Int64"));
            newTable.Columns.Add("sysid_schedule_no_freeze", System.Type.GetType("System.String"));
            newTable.Columns.Add("sysid_special_no_freeze", System.Type.GetType("System.String"));

            if (!isCreate)
            {
                using (RemoteClient.RemCntTranscriptManager remClient = new RemoteClient.RemCntTranscriptManager())
                {
                    _transcriptDetailsTable = remClient.SelectBySysIDTranscriptDetails(userInfo, transcriptSysId);                    

                    if (_transcriptDetailsTable != null)
                    {
                        foreach (DataRow detailsRow in _transcriptDetailsTable.Rows)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["term_session"] = RemoteClient.ProcStatic.TrimStartEndString(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "term_session", String.Empty));
                            newRow["subject_code"] = RemoteClient.ProcStatic.TrimStartEndString(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "subject_code", String.Empty));
                            newRow["subject_no"] = RemoteClient.ProcStatic.TrimStartEndString(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "subject_no", String.Empty));
                            newRow["descriptive_title"] = RemoteClient.ProcStatic.TrimStartEndString(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "descriptive_title", String.Empty));
                            newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "credit_units", String.Empty);
                            newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "final_grade", String.Empty);
                            newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "re_exam", String.Empty);
                            newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "no_of_hours", String.Empty);
                            newRow["sequence_no"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sequence_no", Int16.Parse("0"));
                            newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_schedule", String.Empty)))
                            {
                                newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_schedule", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_special", String.Empty)))
                            {
                                newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_special", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRow);
                        }

                        newTable.AcceptChanges();
                    }                    
                }
            }
            else
            {
                DataRow newRow = newTable.NewRow();

                newRow["term_session"] = String.Empty;
                newRow["subject_code"] = String.Empty;
                newRow["subject_no"] = String.Empty;
                newRow["descriptive_title"] = String.Empty;
                newRow["credit_units"] = String.Empty;
                newRow["final_grade"] = String.Empty;
                newRow["re_exam"] = String.Empty;
                newRow["no_of_hours"] = String.Empty;
                newRow["sequence_no"] = 1;
                newRow["transcript_id"] = 0;
                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                newRow["sysid_special_no_freeze"] = DBNull.Value;

                newTable.Rows.Add(newRow);
            }

            return newTable;
        }//----------------------------

        //this function wil get transcript information
        public CommonExchange.TranscriptInformation GetTranscriptInformation(String sysIdTranscript)
        {
            CommonExchange.TranscriptInformation transcriptInfo = new CommonExchange.TranscriptInformation();

            if (_transcriptInformationTable != null)
            {
                String strFilter = "sysid_transcript = '" + sysIdTranscript + "'";
                DataRow[] selectRow = _transcriptInformationTable.Select(strFilter);

                foreach (DataRow transRow in selectRow)
                {
                    transcriptInfo.TranscriptSysId = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "sysid_transcript", String.Empty);
                    transcriptInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "student_id", String.Empty);
                    transcriptInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "last_name", String.Empty);
                    transcriptInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "first_name", String.Empty);
                    transcriptInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "middle_name", String.Empty);
                    transcriptInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "department_name", String.Empty);
                    transcriptInfo.CourseTitle = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "course_title", String.Empty);
                    transcriptInfo.EntranceData = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "entrance_data", String.Empty);
                    transcriptInfo.RecordsOfGraduation = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "records_of_graduation", String.Empty);
                    transcriptInfo.PurposeOfRequest = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "purpose_of_request", String.Empty);
                    
                    break;
                }
            }

            return transcriptInfo;
        }//---------------------------

        //this functionw will get transcript sysid by student id
        public CommonExchange.TranscriptInformation GetTranscriptInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable tempTable;

            using (RemoteClient.RemCntTranscriptManager remClient = new RemoteClient.RemCntTranscriptManager())
            {
                tempTable = remClient.SelectTranscriptInformation(userInfo, queryString);
            }

            CommonExchange.TranscriptInformation transcriptInfo = new CommonExchange.TranscriptInformation();

            if (tempTable != null)
            {
                foreach (DataRow transRow in tempTable.Rows)
                {
                    if (String.Equals(queryString.ToUpper(), RemoteServerLib.ProcStatic.DataRowConvert(transRow, "student_id", String.Empty).ToUpper()))
                    {
                        transcriptInfo.TranscriptSysId = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "sysid_transcript", String.Empty);
                        transcriptInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "student_id", String.Empty);
                        transcriptInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "last_name", String.Empty);
                        transcriptInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "first_name", String.Empty);
                        transcriptInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "middle_name", String.Empty);
                        transcriptInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "department_name", String.Empty);
                        transcriptInfo.CourseTitle = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "course_title", String.Empty);
                        transcriptInfo.EntranceData = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "entrance_data", String.Empty);
                        transcriptInfo.RecordsOfGraduation = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "records_of_graduation", String.Empty);
                        transcriptInfo.PurposeOfRequest = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "purpose_of_request", String.Empty);
                        
                        break;
                    }
                }
            }

            return transcriptInfo;
        }//----------------------

        //this function will delete a row in datagridview
        public DataTable DeleteRow(DataTable detailsTable, Int16 sequenceNo)
        {
            Int32 deletedIndex = 0;
            Int16 lastSequenceNo = 0;

            foreach (DataRow detailsRow in detailsTable.Rows)
            {
                if (detailsRow.RowState != DataRowState.Deleted)
                {
                    if (sequenceNo == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sequence_no", Int16.Parse("0")))
                    {
                        DataRow delRow = detailsTable.Rows[deletedIndex];

                        lastSequenceNo = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sequence_no", Int16.Parse("0"));

                        DataRowState rowState = delRow.RowState;
                        
                        delRow.Delete();                       

                        break;
                    }
                }

                deletedIndex++;
            }

            Int32 index = 0;

            foreach (DataRow detailsRow in detailsTable.Rows)
            {
                if (detailsRow.RowState != DataRowState.Deleted)
                {
                    if (index >= deletedIndex)
                    {
                        DataRow editRow = detailsTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["sequence_no"] = lastSequenceNo;

                        lastSequenceNo++;

                        editRow.EndEdit();

                        if (detailsRow.RowState == DataRowState.Added)
                        {
                            detailsTable.Rows[index].AcceptChanges();
                            detailsTable.Rows[index].SetAdded();
                        }
                        else if (detailsRow.RowState == DataRowState.Modified)
                        {
                            detailsTable.Rows[index].AcceptChanges();
                            detailsTable.Rows[index].SetModified();
                        }
                        
                    }
                }

                index++;
            }
            

            return detailsTable;
        }//------------------------

        //this fucntion will delete the selected rows in transcript information details
        public DataTable DeleteSelectedRowsTranscriptDetails(DataGridView dgvBase)
        {
            DataTable detailsTable = new DataTable("DetailsTable");

            if (dgvBase != null)
            {
                List<DataGridViewRow> selectedRowList = new List<DataGridViewRow>();

                foreach (DataGridViewRow sRow in dgvBase.SelectedRows)
                {
                    selectedRowList.Add(sRow);
                }

                detailsTable = (DataTable)dgvBase.DataSource;

                foreach (DataGridViewRow list in selectedRowList)
                {
                    Int16 countDetails = 0;

                    foreach (DataRow detailsRow in detailsTable.Rows)
                    {
                        if (detailsRow.RowState != DataRowState.Deleted)
                        {
                            if (String.Equals(list.Cells["sequence_no"].Value.ToString(),
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sequence_no", Int16.Parse("0")).ToString()))
                            {
                                DataRow delRow = detailsTable.Rows[countDetails];

                                delRow.Delete();

                                break;
                            }
                        }

                        countDetails++;
                    }
                }
            }

            return detailsTable;
        }//-------------------------------

        //this fucntion will add row in datagridview form student load table
        public DataTable AddRowsFormStudentLoadTable(DataTable detailsTable, Int32 rowIndex, Int32 indexSequenceNo)
        {
            DataTable newTable = new DataTable("TempTable");
            newTable.Columns.Add("term_session", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_no", System.Type.GetType("System.String"));
            newTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("credit_units", System.Type.GetType("System.String"));
            newTable.Columns.Add("final_grade", System.Type.GetType("System.String"));
            newTable.Columns.Add("re_exam", System.Type.GetType("System.String"));
            newTable.Columns.Add("no_of_hours", System.Type.GetType("System.String"));
            newTable.Columns.Add("sequence_no", System.Type.GetType("System.Int16"));
            newTable.Columns.Add("transcript_id", System.Type.GetType("System.Int64"));
            newTable.Columns.Add("sysid_schedule_no_freeze", System.Type.GetType("System.String"));
            newTable.Columns.Add("sysid_special_no_freeze", System.Type.GetType("System.String"));

            if (detailsTable != null)
            {                
                Int32 rowCount = 0;

                foreach (DataRow dRow in detailsTable.Rows)
                {
                    if (dRow.RowState != DataRowState.Deleted)
                    {
                        if (rowCount == rowIndex)                        
                        {
                            if (_copiedSubjectTable != null)
                            {
                                foreach (DataRow subRow in _copiedSubjectTable.Rows)
                                {
                                    DataRow newRow = newTable.NewRow();

                                    newRow["term_session"] = String.Empty;
                                    newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", String.Empty);
                                    newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no", String.Empty);
                                    newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", String.Empty);
                                    newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "credit_units", String.Empty);
                                    newRow["final_grade"] = String.Empty;
                                    newRow["re_exam"] = String.Empty;
                                    newRow["no_of_hours"] = String.Empty;
                                    newRow["sequence_no"] = indexSequenceNo;
                                    newRow["transcript_id"] = 0;

                                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_schedule", String.Empty)))
                                    {
                                        newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_schedule", String.Empty);
                                    }
                                    else
                                    {
                                        newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                                    }

                                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_special", String.Empty)))
                                    {
                                        newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_special", String.Empty);
                                    }
                                    else
                                    {
                                        newRow["sysid_special_no_freeze"] = DBNull.Value;
                                    }

                                    newTable.Rows.Add(newRow);

                                    indexSequenceNo++;
                                    rowCount++;
                                }
                            }

                            if (rowIndex < 0)
                            {
                                rowIndex = 0;
                            }

                            DataRow newRowDetails = newTable.NewRow();

                            newRowDetails["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRowDetails["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRowDetails["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRowDetails["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRowDetails["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRowDetails["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRowDetails["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRowDetails["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRowDetails["sequence_no"] = indexSequenceNo;
                            newRowDetails["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRowDetails["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRowDetails["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRowDetails["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRowDetails["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRowDetails);

                            if (dRow.RowState == DataRowState.Modified || dRow.RowState == DataRowState.Unchanged)
                            {
                                //rowCount++;
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }

                            indexSequenceNo++;
                        }
                        else if (rowCount < rowIndex)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRow["sequence_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sequence_no", Int16.Parse("0"));
                            newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRow);

                            if (dRow.RowState == DataRowState.Modified)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }
                            else if (dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                            }
                        }
                        else if (rowCount > rowIndex)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRow["sequence_no"] = indexSequenceNo;
                            newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRow);

                            if (dRow.RowState == DataRowState.Modified || dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }

                            indexSequenceNo++;
                        }                        
                    }
                    else
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["term_session"] = dRow["term_session", DataRowVersion.Original].ToString();
                        newRow["subject_code"] = dRow["subject_code", DataRowVersion.Original].ToString();
                        newRow["subject_no"] = dRow["subject_no", DataRowVersion.Original].ToString();
                        newRow["descriptive_title"] = dRow["descriptive_title", DataRowVersion.Original].ToString();
                        newRow["credit_units"] = dRow["credit_units", DataRowVersion.Original].ToString();
                        newRow["final_grade"] = dRow["final_grade", DataRowVersion.Original].ToString();
                        newRow["re_exam"] = dRow["re_exam", DataRowVersion.Original].ToString();
                        newRow["no_of_hours"] = dRow["no_of_hours", DataRowVersion.Original].ToString();
                        newRow["sequence_no"] = dRow["sequence_no", DataRowVersion.Original];
                        newRow["transcript_id"] = dRow["transcript_id", DataRowVersion.Original];

                        if (!String.IsNullOrEmpty(dRow["sysid_schedule_no_freeze", DataRowVersion.Original].ToString()))
                        {
                            newRow["sysid_schedule_no_freeze"] = dRow["sysid_schedule_no_freeze", DataRowVersion.Original].ToString();
                        }
                        else
                        {
                            newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                        }

                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                        {
                            newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                        }
                        else
                        {
                            newRow["sysid_special_no_freeze"] = DBNull.Value;
                        }

                        newTable.Rows.Add(newRow);

                        DataRow delRow = newTable.Rows[rowCount];

                        delRow.AcceptChanges();

                        delRow.Delete();

                        rowIndex++;
                    }

                    rowCount++;
                }
            }

            return newTable;
        }//---------------------------

        //this function will add row (before and after) in the datagridview
        public DataTable AddRowBreakPointBeforeOrAfter(DataTable detailsTable, Int32 rowIndex, Int32 indexSequenceNo, Int32 noRowTobeAdded,
            Boolean isBefore, Boolean isBreakPoint, ref Int32 addedRow)
        {
            DataTable newTable = new DataTable("TempTable");
            newTable.Columns.Add("term_session", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_no", System.Type.GetType("System.String"));
            newTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("credit_units", System.Type.GetType("System.String"));
            newTable.Columns.Add("final_grade", System.Type.GetType("System.String"));
            newTable.Columns.Add("re_exam", System.Type.GetType("System.String"));
            newTable.Columns.Add("no_of_hours", System.Type.GetType("System.String"));
            newTable.Columns.Add("sequence_no", System.Type.GetType("System.Int16"));
            newTable.Columns.Add("transcript_id", System.Type.GetType("System.Int64"));
            newTable.Columns.Add("sysid_schedule_no_freeze", System.Type.GetType("System.String"));
            newTable.Columns.Add("sysid_special_no_freeze", System.Type.GetType("System.String"));

            if (detailsTable != null && rowIndex != -1)
            {
                Int32 sequenceNoStart = 0;
                Int32 insertIndex = 0;
                Int32 rowCount = 0;

                if (isBefore)
                {
                    insertIndex = addedRow = rowIndex;
                    sequenceNoStart = indexSequenceNo;
                }
                else
                {
                    insertIndex = addedRow = rowIndex + 1;
                    sequenceNoStart = indexSequenceNo + 1;
                }

                if (sequenceNoStart == 0)
                {
                    sequenceNoStart = addedRow = 0;

                    for(Int32 addedIndex = 1; addedIndex <= noRowTobeAdded; addedIndex++)
                    {
                        String descriptiveTitle = isBreakPoint ? "x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x" : String.Empty;

                        DataRow newRow = newTable.NewRow();

                        newRow["term_session"] = String.Empty;
                        newRow["subject_code"] = String.Empty;
                        newRow["subject_no"] = String.Empty;
                        newRow["descriptive_title"] = descriptiveTitle;
                        newRow["credit_units"] = String.Empty;
                        newRow["final_grade"] = String.Empty;
                        newRow["re_exam"] = String.Empty;
                        newRow["no_of_hours"] = String.Empty;
                        newRow["sequence_no"] = sequenceNoStart;
                        newRow["transcript_id"] = 0;
                        newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                        newRow["sysid_special_no_freeze"] = DBNull.Value;

                        newTable.Rows.Add(newRow);

                        sequenceNoStart++;

                        rowCount++;
                    }
                }

                foreach (DataRow dRow in detailsTable.Rows)
                {
                    if (dRow.RowState != DataRowState.Deleted)
                    {
                        if (rowCount == insertIndex || insertIndex < 0)
                        {
                            for (Int32 addedIndex = 1; addedIndex <= noRowTobeAdded; addedIndex++)
                            {
                                String descriptiveTitle = isBreakPoint ? "x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x" : String.Empty;

                                DataRow newRow = newTable.NewRow();

                                newRow["term_session"] = String.Empty;
                                newRow["subject_code"] = String.Empty;
                                newRow["subject_no"] = String.Empty;
                                newRow["descriptive_title"] = descriptiveTitle;
                                newRow["credit_units"] = String.Empty;
                                newRow["final_grade"] = String.Empty;
                                newRow["re_exam"] = String.Empty;
                                newRow["no_of_hours"] = String.Empty;
                                newRow["sequence_no"] = sequenceNoStart;
                                newRow["transcript_id"] = 0;
                                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                                newRow["sysid_special_no_freeze"] = DBNull.Value;

                                newTable.Rows.Add(newRow);

                                sequenceNoStart++;

                                rowCount++;
                            }

                            if (insertIndex < 0)
                            {
                                insertIndex = 0;
                            }

                            DataRow newRowDetails = newTable.NewRow();

                            newRowDetails["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRowDetails["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRowDetails["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRowDetails["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRowDetails["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRowDetails["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRowDetails["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRowDetails["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRowDetails["sequence_no"] = sequenceNoStart;
                            newRowDetails["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRowDetails["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRowDetails["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRowDetails["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRowDetails["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRowDetails);

                            if (dRow.RowState == DataRowState.Modified || dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }

                            sequenceNoStart++;
                        }
                        else if (rowCount < insertIndex)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRow["sequence_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sequence_no", Int16.Parse("0"));
                            newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRow);

                            if (dRow.RowState == DataRowState.Modified)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }
                            else if (dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                            }

                        }
                        else if (rowCount > insertIndex)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRow["sequence_no"] = sequenceNoStart;
                            newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRow);

                            if (dRow.RowState == DataRowState.Modified || dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }

                            sequenceNoStart++;
                        }
                    }
                    else
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["term_session"] = dRow["term_session", DataRowVersion.Original].ToString();
                        newRow["subject_code"] = dRow["subject_code", DataRowVersion.Original].ToString();
                        newRow["subject_no"] = dRow["subject_no", DataRowVersion.Original].ToString();
                        newRow["descriptive_title"] = dRow["descriptive_title", DataRowVersion.Original].ToString();
                        newRow["credit_units"] = dRow["credit_units", DataRowVersion.Original].ToString();
                        newRow["final_grade"] = dRow["final_grade", DataRowVersion.Original].ToString();
                        newRow["re_exam"] = dRow["re_exam", DataRowVersion.Original].ToString();
                        newRow["no_of_hours"] = dRow["no_of_hours", DataRowVersion.Original].ToString();
                        newRow["sequence_no"] = dRow["sequence_no", DataRowVersion.Original];
                        newRow["transcript_id"] = dRow["transcript_id", DataRowVersion.Original];

                        if (!String.IsNullOrEmpty(dRow["sysid_schedule_no_freeze", DataRowVersion.Original].ToString()))
                        {
                            newRow["sysid_schedule_no_freeze"] = dRow["sysid_schedule_no_freeze", DataRowVersion.Original].ToString();
                        }
                        else
                        {
                            newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                        }

                        if (!String.IsNullOrEmpty(dRow["sysid_special_no_freeze", DataRowVersion.Original].ToString()))
                        {
                            newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                        }
                        else
                        {
                            newRow["sysid_special_no_freeze"] = DBNull.Value;
                        }

                        newTable.Rows.Add(newRow);

                        DataRow delRow = newTable.Rows[rowCount];

                        delRow.AcceptChanges();

                        delRow.Delete();

                        insertIndex++;
                    }

                    rowCount++;
                }

                if (insertIndex == rowCount)
                {
                    for (Int32 addedIndex = 1; addedIndex <= noRowTobeAdded; addedIndex++)
                    {
                        String descriptiveTitle = isBreakPoint ? "x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x" : String.Empty;

                        DataRow newRow = newTable.NewRow();

                        newRow["term_session"] = String.Empty;
                        newRow["subject_code"] = String.Empty;
                        newRow["subject_no"] = String.Empty;
                        newRow["descriptive_title"] = descriptiveTitle;
                        newRow["credit_units"] = String.Empty;
                        newRow["final_grade"] = String.Empty;
                        newRow["re_exam"] = String.Empty;
                        newRow["no_of_hours"] = String.Empty;
                        newRow["sequence_no"] = sequenceNoStart;
                        newRow["transcript_id"] = 0;
                        newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                        newRow["sysid_special_no_freeze"] = DBNull.Value;

                        newTable.Rows.Add(newRow);

                        sequenceNoStart++;
                    }
                }
            }

            return newTable;
        }//--------------------------------

        //this function will cut student transcript information details
        public DataTable CutStudentTranscriptDetails(DataGridView dgvBase)
        {
            DataTable detailsTable = new DataTable("DetailsTable");

            if (dgvBase != null)
            {
                _cutTranscriptDetailsTable.Rows.Clear();

                List<DataGridViewRow> selectedRowList = new List<DataGridViewRow>();

                foreach (DataGridViewRow sRow in dgvBase.SelectedRows)
                {
                    selectedRowList.Add(sRow);
                }

                Int32 firstSequenceNo = -1;

                detailsTable = (DataTable)dgvBase.DataSource;

                foreach (DataGridViewRow list in selectedRowList)
                {
                    Int16 countDetails = 0;

                    foreach (DataRow detailsRow in detailsTable.Rows)
                    {
                        if (detailsRow.RowState != DataRowState.Deleted)
                        {
                            if (String.Equals(list.Cells["sequence_no"].Value.ToString(),
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sequence_no", Int16.Parse("0")).ToString()))
                            {
                                if (firstSequenceNo == -1)
                                {
                                    firstSequenceNo = (Int16)list.Cells["sequence_no"].Value;
                                }

                                DataRow newRow = _cutTranscriptDetailsTable.NewRow();

                                newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "term_session", String.Empty);
                                newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "subject_code", String.Empty);
                                newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "subject_no", String.Empty);
                                newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "descriptive_title", String.Empty);
                                newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "credit_units", String.Empty);
                                newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "final_grade", String.Empty);
                                newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "re_exam", String.Empty);
                                newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "no_of_hours", String.Empty);
                                newRow["sequence_no"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sequence_no", Int16.Parse("0"));
                                newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "transcript_id", String.Empty);

                                if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_schedule_no_freeze", String.Empty)))
                                {
                                    newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_schedule_no_freeze", String.Empty);
                                }
                                else
                                {
                                    newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                                }

                                if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_special_no_freeze", String.Empty)))
                                {
                                    newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_special_no_freeze", String.Empty);
                                }
                                else
                                {
                                    newRow["sysid_special_no_freeze"] = DBNull.Value;
                                }

                                _cutTranscriptDetailsTable.Rows.Add(newRow);

                                DataRow delRow = detailsTable.Rows[countDetails];

                                delRow.Delete();

                                break;
                            }

                            countDetails++;
                        }
                    }
                }
            }

            return detailsTable != null ? detailsTable : null;
        }//--------------------------        

        //this fucntion will paste the cut student transcript information details
        public DataTable PasteToStudentTranscriptDetails(DataTable detailsTable, Int32 rowIndex, Int32 indexSequenceNo, ref Int32 rowStartPaste)
        {
            DataTable newTable = new DataTable("TempTable");
            newTable.Columns.Add("term_session", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_no", System.Type.GetType("System.String"));
            newTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("credit_units", System.Type.GetType("System.String"));
            newTable.Columns.Add("final_grade", System.Type.GetType("System.String"));
            newTable.Columns.Add("re_exam", System.Type.GetType("System.String"));
            newTable.Columns.Add("no_of_hours", System.Type.GetType("System.String"));
            newTable.Columns.Add("sequence_no", System.Type.GetType("System.Int16"));
            newTable.Columns.Add("transcript_id", System.Type.GetType("System.Int64"));
            newTable.Columns.Add("sysid_schedule_no_freeze", System.Type.GetType("System.String"));
            newTable.Columns.Add("sysid_special_no_freeze", System.Type.GetType("System.String"));

            if (_cutTranscriptDetailsTable != null)
            {
                Int32 rowCount = 0;

                foreach (DataRow dRow in detailsTable.Rows)
                {
                    if (dRow.RowState != DataRowState.Deleted)
                    {
                        if (rowCount == rowIndex)
                        {
                            if (_cutTranscriptDetailsTable != null)
                            {
                                rowStartPaste = rowCount;

                                DataRow[] selectRow = _cutTranscriptDetailsTable.Select(String.Empty, "sequence_no ASC");

                                foreach (DataRow cutRow in selectRow)
                                {
                                    DataRow newRow = newTable.NewRow();

                                    newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "term_session", String.Empty);
                                    newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "subject_code", String.Empty);
                                    newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "subject_no", String.Empty);
                                    newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "descriptive_title", String.Empty);
                                    newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "credit_units", String.Empty);
                                    newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "final_grade", String.Empty);
                                    newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                                    newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "no_of_hours", String.Empty);
                                    newRow["sequence_no"] = indexSequenceNo;
                                    newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "transcript_id", Int64.Parse("0"));

                                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "sysid_schedule_no_freeze", String.Empty)))
                                    {
                                        newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "sysid_schedule_no_freeze", String.Empty);
                                    }
                                    else
                                    {
                                        newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                                    }

                                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "sysid_special_no_freeze", String.Empty)))
                                    {
                                        newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "sysid_special_no_freeze", String.Empty);
                                    }
                                    else
                                    {
                                        newRow["sysid_special_no_freeze"] = DBNull.Value;
                                    }

                                    newTable.Rows.Add(newRow);

                                    indexSequenceNo++;
                                    rowCount++;
                                }
                            }

                            if (rowIndex < 0)
                            {
                                rowIndex = 0;
                            }

                            DataRow newRowDetails = newTable.NewRow();

                            newRowDetails["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRowDetails["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRowDetails["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRowDetails["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRowDetails["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRowDetails["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRowDetails["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRowDetails["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRowDetails["sequence_no"] = indexSequenceNo;
                            newRowDetails["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRowDetails["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRowDetails["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRowDetails["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRowDetails["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRowDetails);

                            if (dRow.RowState == DataRowState.Modified || dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }

                            indexSequenceNo++;
                        }
                        else if (rowCount < rowIndex)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRow["sequence_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sequence_no", Int16.Parse("0"));
                            newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRow);

                            if (dRow.RowState == DataRowState.Modified)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }
                            else if (dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                            }
                        }
                        else if (rowCount > rowIndex)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRow["sequence_no"] = indexSequenceNo;
                            newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRow);

                            if (dRow.RowState == DataRowState.Modified || dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }

                            indexSequenceNo++;
                        }
                    }
                    else
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["term_session"] = dRow["term_session", DataRowVersion.Original].ToString();
                        newRow["subject_code"] = dRow["subject_code", DataRowVersion.Original].ToString();
                        newRow["subject_no"] = dRow["subject_no", DataRowVersion.Original].ToString();
                        newRow["descriptive_title"] = dRow["descriptive_title", DataRowVersion.Original].ToString();
                        newRow["credit_units"] = dRow["credit_units", DataRowVersion.Original].ToString();
                        newRow["final_grade"] = dRow["final_grade", DataRowVersion.Original].ToString();
                        newRow["re_exam"] = dRow["re_exam", DataRowVersion.Original].ToString();
                        newRow["no_of_hours"] = dRow["no_of_hours", DataRowVersion.Original].ToString();
                        newRow["sequence_no"] = dRow["sequence_no", DataRowVersion.Original];
                        newRow["transcript_id"] = dRow["transcript_id", DataRowVersion.Original];

                        if (!String.IsNullOrEmpty(dRow["sysid_schedule_no_freeze", DataRowVersion.Original].ToString()))
                        {
                            newRow["sysid_schedule_no_freeze"] = dRow["sysid_schedule_no_freeze", DataRowVersion.Original].ToString();
                        }
                        else
                        {
                            newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                        }

                        if (!String.IsNullOrEmpty(dRow["sysid_special_no_freeze", DataRowVersion.Original].ToString()))
                        {
                            newRow["sysid_special_no_freeze"] = dRow["sysid_special_no_freeze", DataRowVersion.Original].ToString();
                        }
                        else
                        {
                            newRow["sysid_special_no_freeze"] = DBNull.Value;
                        }

                        newTable.Rows.Add(newRow);

                        DataRow delRow = newTable.Rows[rowCount];

                        delRow.AcceptChanges();

                        delRow.Delete();

                        rowIndex++;
                    }

                    rowCount++;
                }
            }

            _cutTranscriptDetailsTable.Rows.Clear();

            return newTable;
        }//--------------------------

        //this fucntion will paste the copied transcript information details
        public DataTable PasteCopiedTranscriptDetails(DataTable detailsTable, Int32 rowIndex, Int32 indexSequenceNo, ref Int32 rowStartPaste)
        {
            DataTable newTable = new DataTable("TempTable");
            newTable.Columns.Add("term_session", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_no", System.Type.GetType("System.String"));
            newTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("credit_units", System.Type.GetType("System.String"));
            newTable.Columns.Add("final_grade", System.Type.GetType("System.String"));
            newTable.Columns.Add("re_exam", System.Type.GetType("System.String"));
            newTable.Columns.Add("no_of_hours", System.Type.GetType("System.String"));
            newTable.Columns.Add("sequence_no", System.Type.GetType("System.Int16"));
            newTable.Columns.Add("transcript_id", System.Type.GetType("System.Int64"));
            newTable.Columns.Add("sysid_schedule_no_freeze", System.Type.GetType("System.String"));
            newTable.Columns.Add("sysid_special_no_freeze", System.Type.GetType("System.String"));

            if (_copiedTranscriptDetailsTable != null)
            {
                Int32 rowCount = 0;

                foreach (DataRow dRow in detailsTable.Rows)
                {
                    if (dRow.RowState != DataRowState.Deleted)
                    {
                        if (rowCount == rowIndex)
                        {
                            if (_copiedTranscriptDetailsTable != null)
                            {
                                rowStartPaste = rowCount;

                                DataRow[] selectRow = _copiedTranscriptDetailsTable.Select(String.Empty, "sequence_no ASC");

                                foreach (DataRow cutRow in selectRow)
                                {
                                    DataRow newRow = newTable.NewRow();

                                    newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "term_session", String.Empty);
                                    newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "subject_code", String.Empty);
                                    newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "subject_no", String.Empty);
                                    newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "descriptive_title", String.Empty);
                                    newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "credit_units", String.Empty);
                                    newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "final_grade", String.Empty);
                                    newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                                    newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "no_of_hours", String.Empty);
                                    newRow["sequence_no"] = indexSequenceNo;
                                    newRow["transcript_id"] = 0;// RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "transcript_id", Int64.Parse("0"));

                                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "sysid_schedule_no_freeze", String.Empty)))
                                    {
                                        newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "sysid_schedule_no_freeze", String.Empty);
                                    }
                                    else
                                    {
                                        newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                                    }

                                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "sysid_special_no_freeze", String.Empty)))
                                    {
                                        newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(cutRow, "sysid_special_no_freeze", String.Empty);
                                    }
                                    else
                                    {
                                        newRow["sysid_special_no_freeze"] = DBNull.Value;
                                    }

                                    newTable.Rows.Add(newRow);

                                    indexSequenceNo++;
                                    rowCount++;
                                }
                            }

                            if (rowIndex < 0)
                            {
                                rowIndex = 0;
                            }

                            DataRow newRowDetails = newTable.NewRow();

                            newRowDetails["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRowDetails["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRowDetails["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRowDetails["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRowDetails["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRowDetails["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRowDetails["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRowDetails["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRowDetails["sequence_no"] = indexSequenceNo;
                            newRowDetails["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRowDetails["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRowDetails["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRowDetails["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRowDetails["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRowDetails);

                            if (dRow.RowState == DataRowState.Modified || dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }

                            indexSequenceNo++;
                        }
                        else if (rowCount < rowIndex)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRow["sequence_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sequence_no", Int16.Parse("0"));
                            newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRow);

                            if (dRow.RowState == DataRowState.Modified)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }
                            else if (dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                            }
                        }
                        else if (rowCount > rowIndex)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "term_session", String.Empty);
                            newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", String.Empty);
                            newRow["subject_no"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_no", String.Empty);
                            newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", String.Empty);
                            newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "credit_units", String.Empty);
                            newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "final_grade", String.Empty);
                            newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "re_exam", String.Empty);
                            newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_of_hours", String.Empty);
                            newRow["sequence_no"] = indexSequenceNo;
                            newRow["transcript_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "transcript_id", Int64.Parse("0"));

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty)))
                            {
                                newRow["sysid_schedule_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty)))
                            {
                                newRow["sysid_special_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_special_no_freeze", String.Empty);
                            }
                            else
                            {
                                newRow["sysid_special_no_freeze"] = DBNull.Value;
                            }

                            newTable.Rows.Add(newRow);

                            if (dRow.RowState == DataRowState.Modified || dRow.RowState == DataRowState.Unchanged)
                            {
                                newTable.Rows[rowCount].AcceptChanges();
                                newTable.Rows[rowCount].SetModified();
                            }

                            indexSequenceNo++;
                        }
                    }
                    else
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["term_session"] = dRow["term_session", DataRowVersion.Original].ToString();
                        newRow["subject_code"] = dRow["subject_code", DataRowVersion.Original].ToString();
                        newRow["subject_no"] = dRow["subject_no", DataRowVersion.Original].ToString();
                        newRow["descriptive_title"] = dRow["descriptive_title", DataRowVersion.Original].ToString();
                        newRow["credit_units"] = dRow["credit_units", DataRowVersion.Original].ToString();
                        newRow["final_grade"] = dRow["final_grade", DataRowVersion.Original].ToString();
                        newRow["re_exam"] = dRow["re_exam", DataRowVersion.Original].ToString();
                        newRow["no_of_hours"] = dRow["no_of_hours", DataRowVersion.Original].ToString();
                        newRow["sequence_no"] = dRow["sequence_no", DataRowVersion.Original];
                        newRow["transcript_id"] = dRow["transcript_id", DataRowVersion.Original];

                        if (!String.IsNullOrEmpty(dRow["sysid_schedule_no_freeze", DataRowVersion.Original].ToString()))
                        {
                            newRow["sysid_schedule_no_freeze"] = dRow["sysid_schedule_no_freeze", DataRowVersion.Original].ToString();
                        }
                        else
                        {
                            newRow["sysid_schedule_no_freeze"] = DBNull.Value;
                        }

                        if (!String.IsNullOrEmpty(dRow["sysid_special_no_freeze", DataRowVersion.Original].ToString()))
                        {
                            newRow["sysid_special_no_freeze"] = dRow["sysid_special_no_freeze", DataRowVersion.Original].ToString();
                        }
                        else
                        {
                            newRow["sysid_special_no_freeze"] = DBNull.Value;
                        }

                        newTable.Rows.Add(newRow);

                        DataRow delRow = newTable.Rows[rowCount];

                        delRow.AcceptChanges();

                        delRow.Delete();

                        rowIndex++;
                    }

                    rowCount++;
                }
            }

            return newTable;
        }//--------------------------

        //this function will determine if the student already exist in the transcript information
        public Boolean IsExistStudentIDTranscriptInformation(CommonExchange.SysAccess userInfo, String studentId, String transcriptSysId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntTranscriptManager remClient = new RemoteClient.RemCntTranscriptManager())
            {
                isExist = remClient.IsExistStudentIDTranscriptInformation(userInfo, studentId, transcriptSysId);
            }

            return isExist;
        }//------------------------

        //this function will determine if the copy transcript details
        public Boolean HasCopiedTranscriptDetails()
        {
            Boolean hasCopied = false;

            if (_copiedTranscriptDetailsTable != null)
            {
                hasCopied = _copiedTranscriptDetailsTable.Rows.Count > 0 ? true : false;
            }

            return hasCopied;
        }//--------------------------------

        //this function returns the extension name of the file
        public String GetImageExtensionName(String imagePath)
        {
            String strExt = "";

            if (File.Exists(imagePath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(imagePath);
                strExt = dirInfo.Extension;
            }

            return strExt;
        } //----------------------------------

        //this function will get list transcript system id
        public String GetTranscriptSysIdList()
        {
            String transcriptSysIdList = String.Empty;

            if (_transcriptInformationTable != null)
            {
                foreach (DataRow transRow in _transcriptInformationTable.Rows)
                {
                    transcriptSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(transRow, "sysid_transcript", String.Empty) + ",";
                }

                transcriptSysIdList = transcriptSysIdList.Length > 2 ? transcriptSysIdList.Remove(transcriptSysIdList.Length - 1, 1) : String.Empty;
            }

            return transcriptSysIdList;
        }//--------------------------

        //this funtion will get list of transcript information
        public List<CommonExchange.TranscriptInformation> GetTranscriptInformationList()
        {
            List<CommonExchange.TranscriptInformation> transcriptInformationList = new List<CommonExchange.TranscriptInformation>();

            if (_transcriptInformationTable != null)
            {
                foreach (DataRow transRow in _transcriptInformationTable.Rows)
                {
                    CommonExchange.TranscriptInformation transcriptInfo = new CommonExchange.TranscriptInformation();

                    transcriptInfo.TranscriptSysId = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "sysid_transcript", String.Empty);
                    transcriptInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "student_id", String.Empty);
                    transcriptInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "last_name", String.Empty);
                    transcriptInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "first_name", String.Empty);
                    transcriptInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "middle_name", String.Empty);

                    transcriptInformationList.Add(transcriptInfo);
                }
            }

            return transcriptInformationList;
        }//------------------------------

        //this procedure will get student information details
        public CommonExchange.Student SelectByStudentIDStudentInformation(CommonExchange.SysAccess userInfo, String studentId)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                studentInfo = remClient.SelectByStudentIDStudentInformation(userInfo, studentId);
            }          

            return studentInfo;
        }//------------------------
        #endregion
    }
}
