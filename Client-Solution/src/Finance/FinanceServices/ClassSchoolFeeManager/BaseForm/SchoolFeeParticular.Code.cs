using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class SchoolFeeParticular
    {       

        #region Class General Variable Declaration
         protected CommonExchange.SysAccess _userInfo;
         protected CommonExchange.SchoolFeeParticular _particularInfo;
         protected SchoolFeeLogic _schoolFeeManager;


         private ErrorProvider _errProvider;
        #endregion

        #region Class Constructors
         public SchoolFeeParticular()
         {
             this.InitializeComponent();
         }

        public SchoolFeeParticular(CommonExchange.SysAccess userInfo, SchoolFeeLogic schoolFeeManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _schoolFeeManager = schoolFeeManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.cboFeeCategory.SelectedIndexChanged += new EventHandler(cboFeeCategorySelectedIndexChanged);
            this.txtParticularDescription.Validated += new EventHandler(txtParticularDescriptionValidated);
            this.txtParticularDescription.KeyPress += new KeyPressEventHandler(txtParticularDescriptionKeyPress);
            this.chkIsOptional.CheckedChanged += new EventHandler(chkIsOptionalCheckedChanged);
            this.chkIsOfficesAccess.CheckedChanged += new EventHandler(chkIsOfficesAccessCheckedChanged);
            this.chkIsGraduationFee.CheckedChanged += new EventHandler(chkIsGraduationFeeCheckedChanged);
            this.chkEntryLevelIncluded.CheckedChanged += new EventHandler(chkEntryLevelIncludedCheckedChanged);
        }       
        #endregion

        #region Class Event Void Procedures
        //#####################################################CLASS SCHOOLFEEPARTICULAR EVENTS #################################################################
        //event is raised when the class is loaded
         protected virtual void ClassLoad(object sender, EventArgs e)
         {
             _particularInfo = new CommonExchange.SchoolFeeParticular();

             _schoolFeeManager.InitializeFeeCategoryCombo(this.cboFeeCategory);
         }//------------------------------
         //#####################################################END CLASS SCHOOLFEEPARTICULAR EVENTS ###########################################################

         //#####################################################COMBOBOX cboFeeCategory EVENTS#####################################################
         //event is raised when the control selected index is changed
         private void cboFeeCategorySelectedIndexChanged(object sender, EventArgs e)
         {
             Byte categoryNo = 0;

             _particularInfo.SchoolFeeCategoryInfo.FeeCategoryId = _schoolFeeManager.GetFeeCategoryId(this.cboFeeCategory.SelectedIndex,
                 ref categoryNo);

             _particularInfo.SchoolFeeCategoryInfo.CategoryNo = categoryNo;
         }//------------------------
         //#####################################################COMBOBOX cboFeeCategory EVENTS#####################################################

         //#####################################################TEXTBOX txtParticularDescirption EVENTS#####################################################
         //event is raised when the control is validated
         private void txtParticularDescriptionValidated(object sender, EventArgs e)
         {
             _particularInfo.ParticularDescription = RemoteClient.ProcStatic.TrimStartEndString(this.txtParticularDescription.Text);
         }//--------------------------------

         //event is raised when the key is pressed
         private void txtParticularDescriptionKeyPress(object sender, KeyPressEventArgs e)
         {
             if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
             {
                 e.Handled = true;
             }
         }//---------------------
         //#####################################################END TEXTBOX txtParticularDescirption EVENTS##################################################

         //#####################################################CHECKBOX chkIsOfficesAccess EVENTS#####################################################
         //event is raised when the control checked changed
         protected virtual void chkIsOfficesAccessCheckedChanged(object sender, EventArgs e)
         {
             _particularInfo.IsOfficeAccess = this.chkIsOfficesAccess.Checked;
         }//-------------------------------
         //#####################################################END CHECKBOX chkIsOfficesAccess EVENTS#####################################################

         //#####################################################CHECKEBOX chkIsOptional EVENTS#####################################################
         //event is raised when the control checked change
         protected virtual void chkIsOptionalCheckedChanged(object sender, EventArgs e)
         {
             _particularInfo.IsOptional = this.chkIsOptional.Checked;

             if (_particularInfo.IsOptional)
             {
                 this.chkEntryLevelIncluded.Enabled = this.chkIsOfficesAccess.Enabled = true;

                 this.chkIsGraduationFee.Checked = false;
             }
             else
             {
                 this.chkEntryLevelIncluded.Enabled = this.chkIsOfficesAccess.Enabled = false;

                 this.chkEntryLevelIncluded.Checked = this.chkIsOfficesAccess.Checked = false;
             }
         }//--------------------------------
         //#####################################################END CHECKEBOX chkIsOptional EVENTS#####################################################

         //#####################################################CHECKEBOX chkIsGraduationFee EVENTS#####################################################
         //event is raised when the control checked change
         protected virtual void chkIsGraduationFeeCheckedChanged(object sender, EventArgs e)
         {
             _particularInfo.IsGraduationFee = this.chkIsGraduationFee.Checked;

             if (_particularInfo.IsGraduationFee)
             {
                 this.chkIsOptional.Checked = false;
             }
         }//-------------------
         //#####################################################END CHECKEBOX chkIsGraduationFee EVENTS#####################################################

         //#####################################################CHECKEBOX chkEntryLevelIncluded EVENTS#####################################################
         //event is raised when the control checked change
         protected virtual void chkEntryLevelIncludedCheckedChanged(object sender, EventArgs e)
         {
             _particularInfo.IsEntryLevelIncluded = this.chkEntryLevelIncluded.Checked;
         }//-----------------------------------
         //#####################################################END CHECKEBOX chkEntryLevelIncluded EVENTS#####################################################

        #endregion

        #region Programers-Defined Functions
        //this fucntion will validate Controls
        public Boolean ValidateControls() 
        {
            Boolean isValid = true;

            _errProvider.SetError(cboFeeCategory, "");
            _errProvider.SetError(txtParticularDescription, "");

            if (cboFeeCategory.SelectedIndex == -1)
            {
                _errProvider.SetIconAlignment(cboFeeCategory, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(cboFeeCategory, "A Fee Category is required.");
                isValid = false;
            }

            if (String.IsNullOrEmpty(_particularInfo.ParticularDescription))
            {
                _errProvider.SetIconAlignment(txtParticularDescription, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(txtParticularDescription, "A Particular Description is required.");
                isValid = false;
            }

            if (_schoolFeeManager.IsExistParticularDescriptionSchoolFeeParticular(_userInfo, _particularInfo.FeeParticularSysId, 
                _particularInfo.ParticularDescription))
            {
                _errProvider.SetIconAlignment(txtParticularDescription, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(txtParticularDescription, "A Particular Description already exist.");
                isValid = false;
            }
            return isValid;
        }//=----------------------------------
        #endregion
     }
}
