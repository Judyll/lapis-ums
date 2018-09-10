using System;
using System.Collections.Generic;
using System.Text;

namespace BaseServices
{
    public partial class PersonInformationWithRelationship : PersonInformation
    {
        protected System.Windows.Forms.LinkLabel lnkCreateRelationship;
        protected System.Windows.Forms.DataGridView dgvRelationship;
        private System.Windows.Forms.Label label12;
        protected System.Windows.Forms.Label lblEmerStatus;
        protected System.Windows.Forms.TabPage tblRelationship;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblRelationship = new System.Windows.Forms.TabPage();
            this.lblEmerStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvRelationship = new System.Windows.Forms.DataGridView();
            this.lnkCreateRelationship = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerson)).BeginInit();
            this.TabCntPerson.SuspendLayout();
            this.tblRelationship.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationship)).BeginInit();
            this.SuspendLayout();
            // 
            // TabCntPerson
            // 
            this.TabCntPerson.Controls.Add(this.tblRelationship);
            this.TabCntPerson.Controls.SetChildIndex(this.tblRelationship, 0);
            this.TabCntPerson.Controls.SetChildIndex(this.tblPerson, 0);
            // 
            // tblRelationship
            // 
            this.tblRelationship.Controls.Add(this.lblEmerStatus);
            this.tblRelationship.Controls.Add(this.label12);
            this.tblRelationship.Controls.Add(this.dgvRelationship);
            this.tblRelationship.Controls.Add(this.lnkCreateRelationship);
            this.tblRelationship.Location = new System.Drawing.Point(4, 24);
            this.tblRelationship.Name = "tblRelationship";
            this.tblRelationship.Padding = new System.Windows.Forms.Padding(3);
            this.tblRelationship.Size = new System.Drawing.Size(744, 430);
            this.tblRelationship.TabIndex = 1;
            this.tblRelationship.Text = "Relationship Information";
            this.tblRelationship.UseVisualStyleBackColor = true;
            // 
            // lblEmerStatus
            // 
            this.lblEmerStatus.AutoSize = true;
            this.lblEmerStatus.ForeColor = System.Drawing.Color.Red;
            this.lblEmerStatus.Location = new System.Drawing.Point(6, 406);
            this.lblEmerStatus.Name = "lblEmerStatus";
            this.lblEmerStatus.Size = new System.Drawing.Size(182, 15);
            this.lblEmerStatus.TabIndex = 107;
            this.lblEmerStatus.Text = "No emergency contact assigned.";
            this.lblEmerStatus.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Orange;
            this.label12.Location = new System.Drawing.Point(532, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(206, 20);
            this.label12.TabIndex = 106;
            this.label12.Text = "Relationship Information";
            // 
            // dgvRelationship
            // 
            this.dgvRelationship.AllowUserToAddRows = false;
            this.dgvRelationship.AllowUserToDeleteRows = false;
            this.dgvRelationship.AllowUserToResizeColumns = false;
            this.dgvRelationship.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvRelationship.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRelationship.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvRelationship.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRelationship.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRelationship.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRelationship.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelationship.Location = new System.Drawing.Point(6, 33);
            this.dgvRelationship.Name = "dgvRelationship";
            this.dgvRelationship.RowHeadersVisible = false;
            this.dgvRelationship.RowHeadersWidth = 15;
            this.dgvRelationship.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.dgvRelationship.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRelationship.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelationship.Size = new System.Drawing.Size(732, 370);
            this.dgvRelationship.TabIndex = 105;
            // 
            // lnkCreateRelationship
            // 
            this.lnkCreateRelationship.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnkCreateRelationship.AutoSize = true;
            this.lnkCreateRelationship.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreateRelationship.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkCreateRelationship.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreateRelationship.Location = new System.Drawing.Point(606, 406);
            this.lnkCreateRelationship.Name = "lnkCreateRelationship";
            this.lnkCreateRelationship.Size = new System.Drawing.Size(132, 15);
            this.lnkCreateRelationship.TabIndex = 103;
            this.lnkCreateRelationship.TabStop = true;
            this.lnkCreateRelationship.Text = "[ Create Relationship ]";
            this.lnkCreateRelationship.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonInformationWithRelationship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(780, 575);
            this.Name = "PersonInformationWithRelationship";
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerson)).EndInit();
            this.TabCntPerson.ResumeLayout(false);
            this.tblRelationship.ResumeLayout(false);
            this.tblRelationship.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationship)).EndInit();
            this.ResumeLayout(false);

        }

      
    }
}
