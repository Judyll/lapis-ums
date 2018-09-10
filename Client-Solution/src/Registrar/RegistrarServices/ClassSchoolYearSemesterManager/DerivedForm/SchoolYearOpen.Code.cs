using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace RegistrarServices
{
    partial class SchoolYearOpen
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructor
        public SchoolYearOpen(CommonExchange.SysAccess userInfo, SchoolYearLogic yearSemManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _yearSemManager = yearSemManager;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnOpen.Click += new EventHandler(btnOpenClick);
        }

        
        #endregion

        #region Class Event Void Procedures

        //############################################CLASS SchoolYearOpen EVENTS#######################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _yearInfo = _yearSemManager.GetNextOpenedSchoolYearInformation(_userInfo);

            lblDescription.Text = _yearInfo.Description;
            lblDateStart.Text = DateTime.Parse(_yearInfo.DateStart).ToString("MMMM, yyyy", DateTimeFormatInfo.InvariantInfo);
            lblDateEnd.Text = DateTime.Parse(_yearInfo.DateEnd).ToString("MMMM, yyyy", DateTimeFormatInfo.InvariantInfo);

        } //-------------------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the opening of a new school year?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        } //---------------------------

        //##########################################END CLASS SchoolYearOpen EVENTS#####################################################

        //##############################################BUTTON btnCancel EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        } //------------------------------
        //############################################END BUTTON btnCancel EVENTS######################################################

        //################################################BUTTON btnOpen EVENTS########################################################
        //event is raised when the button is clicked
        private void btnOpenClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to officially open a new school year?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Open", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The following has been officially opened:\n\nSchool Year: " + 
                        _yearInfo.Description + "\nSchool Year (SUMMER): " + _yearInfo.Description + 
                        "\n\nSemester: First Semester\nSemester: Second Semester\nSemester: Summer";

                    this.Cursor = Cursors.WaitCursor;

                    //inserts the regular school year
                    _yearSemManager.InsertSchoolYear(_userInfo, ref _yearInfo);
                    //------------------------------------

                    //inserts the first semester
                    CommonExchange.SemesterInformation firstSemInfo = _yearSemManager.GetNextOpenedSemesterInformation(_userInfo,
                        _yearInfo, CommonExchange.SchoolSemester.FirstSemester);

                    _yearSemManager.InsertSemesterInformation(_userInfo, firstSemInfo); 
                    //--------------------------------------

                    //inserts the second semester
                    CommonExchange.SemesterInformation secondSemInfo = _yearSemManager.GetNextOpenedSemesterInformation(_userInfo,
                        _yearInfo, CommonExchange.SchoolSemester.SecondSemester);

                    _yearSemManager.InsertSemesterInformation(_userInfo, secondSemInfo);

                    //inserts the school year SUMMER
                    CommonExchange.SchoolYear summerYearInfo = _yearSemManager.GetNextOpenedSchoolYearInformation(_userInfo, _yearInfo);

                    _yearSemManager.InsertSchoolYearSummer(_userInfo, _yearInfo, ref summerYearInfo);
                    //-----------------------------------

                    //inserts the summer semester
                    CommonExchange.SemesterInformation summerSemInfo = _yearSemManager.GetNextOpenedSemesterInformation(_userInfo,
                        summerYearInfo, CommonExchange.SchoolSemester.Summer);

                    _yearSemManager.InsertSemesterInformation(_userInfo, summerSemInfo);
                    //----------------------------------------

                    this.Cursor = Cursors.Arrow;

                    MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    _hasCreated = true;

                    this.Close();
                }
                else if (msgResult == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Opening A School Year");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        } //------------------------------------
        //##############################################END BUTTON btnOpen EVENTS######################################################

        #endregion
    }
}
