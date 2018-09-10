using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteClient
{
    public partial class ControlManager: AnimatedPanel
    {
        protected System.Windows.Forms.PictureBox pbxFind;
        protected System.Windows.Forms.PictureBox pbxClose;
        protected System.Windows.Forms.PictureBox pbxRefresh;
        protected System.Windows.Forms.TextBox txtSearch;
    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlManager));
            this.pbxFind = new System.Windows.Forms.PictureBox();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.pbxRefresh = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlHeader.BackgroundImage")));
            this.pnlHeader.Size = new System.Drawing.Size(261, 28);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pbxFind);
            this.pnlMain.Controls.Add(this.pbxClose);
            this.pnlMain.Controls.Add(this.pbxRefresh);
            this.pnlMain.Controls.Add(this.txtSearch);
            this.pnlMain.Size = new System.Drawing.Size(255, 125);
            this.pnlMain.Controls.SetChildIndex(this.txtSearch, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxClose, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxFind, 0);
            this.pnlMain.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // pbxFind
            // 
            this.pbxFind.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxFind.BackColor = System.Drawing.Color.Transparent;
            this.pbxFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxFind.Image = ((System.Drawing.Image)(resources.GetObject("pbxFind.Image")));
            this.pbxFind.Location = new System.Drawing.Point(8, 75);
            this.pbxFind.Name = "pbxFind";
            this.pbxFind.Size = new System.Drawing.Size(38, 41);
            this.pbxFind.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxFind.TabIndex = 11;
            this.pbxFind.TabStop = false;
            // 
            // pbxClose
            // 
            this.pbxClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Image = ((System.Drawing.Image)(resources.GetObject("pbxClose.Image")));
            this.pbxClose.Location = new System.Drawing.Point(214, 37);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(33, 41);
            this.pbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxClose.TabIndex = 9;
            this.pbxClose.TabStop = false;
            // 
            // pbxRefresh
            // 
            this.pbxRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pbxRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pbxRefresh.Image")));
            this.pbxRefresh.Location = new System.Drawing.Point(175, 37);
            this.pbxRefresh.Name = "pbxRefresh";
            this.pbxRefresh.Size = new System.Drawing.Size(33, 41);
            this.pbxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxRefresh.TabIndex = 10;
            this.pbxRefresh.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSearch.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(52, 82);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(195, 26);
            this.txtSearch.TabIndex = 8;
            // 
            // ControlManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlManager";
            this.Size = new System.Drawing.Size(255, 125);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
