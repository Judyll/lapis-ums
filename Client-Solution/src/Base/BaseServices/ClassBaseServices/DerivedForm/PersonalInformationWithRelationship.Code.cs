using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonInformationWithRelationship : IDisposable
    {
        #region Class Data Member Declaration
        protected Boolean _hasAddedRelationship = false;
        protected Boolean _hasUpdateRelationship = false;

        private Int32 _primaryIndex = 0;
        private Int32 _rowIndex = -1;
        private String _primaryId = "";
        #endregion

        #region Class Constructors
        public PersonInformationWithRelationship()
        {
            this.InitializeComponent();
        }

        public PersonInformationWithRelationship(CommonExchange.SysAccess userInfo)
            : base(userInfo)
        {
            this.InitializeComponent();

            this.lnkCreateRelationship.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCreateRelationshipLinkClicked);
            this.dgvRelationship.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvRelationship.DoubleClick += new EventHandler(dgvListDoubleClick);
            this.dgvRelationship.KeyPress += new KeyPressEventHandler(dgvListKeyPress);
            this.dgvRelationship.KeyDown += new KeyEventHandler(dgvListKeyDown);
            this.dgvRelationship.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.dgvRelationship.SelectionChanged += new EventHandler(dgvListSelectionChanged); 
        }
        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (this.pbxPerson.Image != null)
            {
                this.pbxPerson.Image.Dispose();
                this.pbxPerson.Image = null;

                this.pbxPerson.Dispose();
                this.pbxPerson = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################LINKLABEL lnkVerify EVENTS###############################################
        //event is raised when the control is clicked
        protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.lnkVerifyLinkClicked(sender, e);

            if (base.HasSelectedPersonFromVerification)
            {
                _baseServiceManager.InitializePersonRelationshipDataGridView(this.dgvRelationship, _personInfo.PersonRelationshipList, this.lblEmerStatus);
            }
        }//-------------------------
        //####################################################END LINKLABEL lnkVerify EVENTS###############################################

        //####################################################LINKLABEL lnkPersonArchive EVENTS###############################################
        //event is raised when the control is clicked
        protected override void lnkPersonArchiveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.lnkPersonArchiveLinkClicked(sender, e);

            if (_hasSelectedForPersonUpdate)
            {
                _baseServiceManager.InitializePersonRelationshipDataGridView(this.dgvRelationship, _personInfo.PersonRelationshipList, this.lblEmerStatus);
            }
        }//------------------------
        //####################################################END LINKLABEL lnkPersonArchive EVENTS###############################################

        //####################################################LINKLABEL lnkCreateRelationship EVENTS###############################################
        //event is raised when the control is clicked
        protected virtual void lnkCreateRelationshipLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                using (PersonRelationshipCreate frmCreate = new PersonRelationshipCreate(_userInfo, _baseServiceManager, 
                    _baseServiceManager.GetPersonRelationshipExcludeListStringFormat(_personInfo.PersonRelationshipList, _personInfo.PersonSysId)))
                {
                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasAdded)
                    {
                        _personInfo.PersonRelationshipList.Add(frmCreate.PersonRelationshipInfo);

                        _baseServiceManager.InitializePersonRelationshipDataGridView(this.dgvRelationship, _personInfo.PersonRelationshipList, this.lblEmerStatus);

                        _hasAddedRelationship = true;                        
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//-----------------------
        //####################################################END LINKLABEL lnkCreateRelationship EVENTS###############################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################
        //event is raised when the mouse is down
        private void dgvListMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView dgvBase = (DataGridView)sender;

                DataGridView.HitTestInfo hitTest = dgvBase.HitTest(e.X, e.Y);

                _rowIndex = -1;

                switch (hitTest.Type)
                {
                    case DataGridViewHitTestType.Cell:
                        _rowIndex = hitTest.RowIndex;
                        break;
                    case DataGridViewHitTestType.RowHeader:
                        _rowIndex = hitTest.RowIndex;
                        break;
                    default:
                        _rowIndex = -1;
                        _primaryId = "";
                        break;
                }

                if (_rowIndex != -1)
                {
                    _primaryId = dgvBase[_primaryIndex, _rowIndex].Value.ToString();
                }
            }
        }//-----------------------------

        //event is raised when the mouse is double clicked
        private void dgvListDoubleClick(object sender, EventArgs e)
        {
            if (_rowIndex >= 0)
            {
                using (BaseServices.PersonRelationshipUpdate frmUpdate = new BaseServices.PersonRelationshipUpdate(_userInfo, _baseServiceManager,
                    _baseServiceManager.GetDetailsPersonRelationship(_userInfo, _personInfo.PersonRelationshipList, _primaryId, Application.StartupPath),
                    _personInfo.PersonSysId))
                {
                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated || frmUpdate.HasDeleted)
                    {
                        _baseServiceManager.UpdatePersonRelationship(_personInfo.PersonRelationshipList, frmUpdate.PersonRelationshipInfo);

                        _baseServiceManager.InitializePersonRelationshipDataGridView(this.dgvRelationship, _personInfo.PersonRelationshipList, this.lblEmerStatus);
                        _hasUpdateRelationship = true;
                    }
                }
            }
        }//---------------------------------

        //event is raised when the key is pressed        
        private void dgvListKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DataGridView dgvBase = (DataGridView)sender;

                if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
                {
                    DataGridViewRow row = dgvBase.SelectedRows[0];

                    _primaryId = row.Cells[_primaryIndex].Value.ToString();
                    _rowIndex = row.Index;
                }
            }
            else
            {
                e.Handled = true;
            }
        } //-----------------------------------

        //event is raised when the key is up
        private void dgvListKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        } //--------------------------------------

        //event is raised when the data source is changed
        private void dgvListDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 1)
            {
                _primaryId = dgvBase[_primaryIndex, 0].Value.ToString();
            }
            else
            {
                _primaryId = "";
            }
        } //--------------------------------

        //event is raised when the selection is changed
        protected virtual void dgvListSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;

            if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = dgvBase.SelectedRows[0];

                _primaryId = row.Cells[_primaryIndex].Value.ToString();
            }
        } //------------------------------------
        //################################################END DATAGRIDVIEW dgvList EVENTS####################################################
        #endregion
    }
}
