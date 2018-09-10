using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class Course
    {
        #region Class General Variable Declarations
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.CourseInformation _courseInfo;
        protected CourseLogic _courseManager;

        private ErrorProvider _errProvider;

        #endregion

        #region Class Constructor
        public Course()
        {
            this.InitializeComponent();

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.txtTitle.Validated += new EventHandler(txtTitleValidated);
            this.txtAcronym.Validated += new EventHandler(txtAcronymValidated);
        }
        
        #endregion

        #region Class Event Void Procedures

        //#########################################CLASS Course EVENTS###########################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _courseInfo = new CommonExchange.CourseInformation();
           
        }//--------------------------------
        //########################################END CLASS Course EVENTS#########################################################

        //########################################TEXTBOX txtTitle EVENTS#########################################################
        //event is raised when the control is validated
        private void txtTitleValidated(object sender, EventArgs e)
        {
            _courseInfo.CourseTitle = RemoteClient.ProcStatic.TrimStartEndString(txtTitle.Text);
        } //------------------------------
        //#######################################END TEXTBOX txtTitle EVENTS#######################################################

        //########################################TEXTBOX txtAcronym EVENTS########################################################
        //event is raised when the control is validated
        private void txtAcronymValidated(object sender, EventArgs e)
        {
            _courseInfo.Acronym = RemoteClient.ProcStatic.TrimStartEndString(txtAcronym.Text);
        } //---------------------------------
        //######################################END TEXTBOX txtAcronym EVENTS######################################################

        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the controls are validated
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.txtTitle, "");
            _errProvider.SetError(this.txtAcronym, "");

            if (_courseManager.IsExistTitleAcronymCourseInformation(_userInfo, _courseInfo))
            {
                _errProvider.SetError(this.txtTitle, "The course title or the course acronym already exists.");
                _errProvider.SetError(this.txtAcronym, "The course title or the course acronym already exists.");
                isValid = false;
            }
            else
            {
                if (String.IsNullOrEmpty(this.txtTitle.Text.Trim()))
                {
                    _errProvider.SetError(this.txtTitle, "A course title is required.");
                    isValid = false;
                }

                if (String.IsNullOrEmpty(this.txtAcronym.Text.Trim()))
                {
                    _errProvider.SetError(this.txtAcronym, "A course acronym is required.");
                    isValid = false;
                }
            }
            
            return isValid;
        } //-------------------------

        #endregion
    }
}
