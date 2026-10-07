namespace DVLD.Licenses.International_Licenses
{
    partial class frmListInternationalLicenses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.lblNumRecordsTag = new System.Windows.Forms.Label();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterList = new System.Windows.Forms.ComboBox();
            this.lblFilterByTag = new System.Windows.Forms.Label();
            this.dgvInternational = new System.Windows.Forms.DataGridView();
            this.cmsInternationalInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPeronInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbManagDrivers = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternational)).BeginInit();
            this.cmsInternationalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbManagDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(106, 692);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(36, 25);
            this.lblNumOfRecords.TabIndex = 48;
            this.lblNumOfRecords.Text = "??";
            // 
            // lblNumRecordsTag
            // 
            this.lblNumRecordsTag.AutoSize = true;
            this.lblNumRecordsTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecordsTag.Location = new System.Drawing.Point(1, 692);
            this.lblNumRecordsTag.Name = "lblNumRecordsTag";
            this.lblNumRecordsTag.Size = new System.Drawing.Size(109, 25);
            this.lblNumRecordsTag.TabIndex = 47;
            this.lblNumRecordsTag.Text = "# Records";
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterBy.Location = new System.Drawing.Point(330, 291);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(224, 28);
            this.txtFilterBy.TabIndex = 46;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged_1);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress_1);
            // 
            // cbFilterList
            // 
            this.cbFilterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterList.FormattingEnabled = true;
            this.cbFilterList.Location = new System.Drawing.Point(122, 289);
            this.cbFilterList.Name = "cbFilterList";
            this.cbFilterList.Size = new System.Drawing.Size(202, 30);
            this.cbFilterList.TabIndex = 45;
            this.cbFilterList.SelectedIndexChanged += new System.EventHandler(this.cbFilterList_SelectedIndexChanged);
            // 
            // lblFilterByTag
            // 
            this.lblFilterByTag.AutoSize = true;
            this.lblFilterByTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterByTag.Location = new System.Drawing.Point(12, 290);
            this.lblFilterByTag.Name = "lblFilterByTag";
            this.lblFilterByTag.Size = new System.Drawing.Size(104, 25);
            this.lblFilterByTag.TabIndex = 44;
            this.lblFilterByTag.Text = "Filter By :";
            // 
            // dgvInternational
            // 
            this.dgvInternational.AllowUserToAddRows = false;
            this.dgvInternational.AllowUserToDeleteRows = false;
            this.dgvInternational.AllowUserToOrderColumns = true;
            this.dgvInternational.AllowUserToResizeColumns = false;
            this.dgvInternational.AllowUserToResizeRows = false;
            this.dgvInternational.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvInternational.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternational.ContextMenuStrip = this.cmsInternationalInfo;
            this.dgvInternational.Location = new System.Drawing.Point(6, 327);
            this.dgvInternational.MultiSelect = false;
            this.dgvInternational.Name = "dgvInternational";
            this.dgvInternational.ReadOnly = true;
            this.dgvInternational.RowHeadersWidth = 51;
            this.dgvInternational.RowTemplate.Height = 26;
            this.dgvInternational.Size = new System.Drawing.Size(1079, 343);
            this.dgvInternational.TabIndex = 43;
            this.dgvInternational.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInternational_CellMouseDown);
            // 
            // cmsInternationalInfo
            // 
            this.cmsInternationalInfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInternationalInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPeronInfoToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem});
            this.cmsInternationalInfo.Name = "cmsDriverInfo";
            this.cmsInternationalInfo.Size = new System.Drawing.Size(269, 82);
            this.cmsInternationalInfo.Opening += new System.ComponentModel.CancelEventHandler(this.cmsInternationalInfo_Opening);
            // 
            // showPeronInfoToolStripMenuItem
            // 
            this.showPeronInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.showPeronInfoToolStripMenuItem.Name = "showPeronInfoToolStripMenuItem";
            this.showPeronInfoToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showPeronInfoToolStripMenuItem.Text = "Show Person Info";
            this.showPeronInfoToolStripMenuItem.Click += new System.EventHandler(this.showPeronInfoToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.International;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(320, 145);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(355, 38);
            this.lblTitle.TabIndex = 41;
            this.lblTitle.Text = "International Licenses";
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(947, 676);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 38);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbManagDrivers
            // 
            this.pbManagDrivers.Image = global::DVLD.Properties.Resources.international_100;
            this.pbManagDrivers.Location = new System.Drawing.Point(398, 4);
            this.pbManagDrivers.Name = "pbManagDrivers";
            this.pbManagDrivers.Size = new System.Drawing.Size(204, 138);
            this.pbManagDrivers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbManagDrivers.TabIndex = 42;
            this.pbManagDrivers.TabStop = false;
            // 
            // frmListInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 728);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.lblNumRecordsTag);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.cbFilterList);
            this.Controls.Add(this.lblFilterByTag);
            this.Controls.Add(this.dgvInternational);
            this.Controls.Add(this.pbManagDrivers);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmListInternationalLicenses";
            this.Text = "frmListInternationalLicenses";
            this.Load += new System.EventHandler(this.frmListInternationalLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternational)).EndInit();
            this.cmsInternationalInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbManagDrivers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.Label lblNumRecordsTag;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.ComboBox cbFilterList;
        private System.Windows.Forms.Label lblFilterByTag;
        private System.Windows.Forms.DataGridView dgvInternational;
        private System.Windows.Forms.PictureBox pbManagDrivers;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalInfo;
        private System.Windows.Forms.ToolStripMenuItem showPeronInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
    }
}