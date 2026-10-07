namespace DVLD.Drivers
{
    partial class frmListDrivers
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
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterList = new System.Windows.Forms.ComboBox();
            this.lblFilterByTag = new System.Windows.Forms.Label();
            this.dgvDrivers = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.lblNumRecordsTag = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbManagDrivers = new System.Windows.Forms.PictureBox();
            this.cmsDriverInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPeronInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManagDrivers)).BeginInit();
            this.cmsDriverInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterBy.Location = new System.Drawing.Point(320, 246);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(224, 28);
            this.txtFilterBy.TabIndex = 11;
            // 
            // cbFilterList
            // 
            this.cbFilterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterList.FormattingEnabled = true;
            this.cbFilterList.Location = new System.Drawing.Point(112, 246);
            this.cbFilterList.Name = "cbFilterList";
            this.cbFilterList.Size = new System.Drawing.Size(202, 30);
            this.cbFilterList.TabIndex = 10;
            // 
            // lblFilterByTag
            // 
            this.lblFilterByTag.AutoSize = true;
            this.lblFilterByTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterByTag.Location = new System.Drawing.Point(2, 245);
            this.lblFilterByTag.Name = "lblFilterByTag";
            this.lblFilterByTag.Size = new System.Drawing.Size(104, 25);
            this.lblFilterByTag.TabIndex = 9;
            this.lblFilterByTag.Text = "Filter By :";
            // 
            // dgvDrivers
            // 
            this.dgvDrivers.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrivers.ContextMenuStrip = this.cmsDriverInfo;
            this.dgvDrivers.Location = new System.Drawing.Point(7, 298);
            this.dgvDrivers.Name = "dgvDrivers";
            this.dgvDrivers.RowHeadersWidth = 51;
            this.dgvDrivers.RowTemplate.Height = 26;
            this.dgvDrivers.Size = new System.Drawing.Size(1079, 343);
            this.dgvDrivers.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(417, 153);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 38);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Manage Drivers";
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(117, 674);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(36, 25);
            this.lblNumOfRecords.TabIndex = 39;
            this.lblNumOfRecords.Text = "??";
            // 
            // lblNumRecordsTag
            // 
            this.lblNumRecordsTag.AutoSize = true;
            this.lblNumRecordsTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecordsTag.Location = new System.Drawing.Point(2, 674);
            this.lblNumRecordsTag.Name = "lblNumRecordsTag";
            this.lblNumRecordsTag.Size = new System.Drawing.Size(109, 25);
            this.lblNumRecordsTag.TabIndex = 38;
            this.lblNumRecordsTag.Text = "# Records";
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(966, 658);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 38);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pbManagDrivers
            // 
            this.pbManagDrivers.Image = global::DVLD.Properties.Resources.Driverspng;
            this.pbManagDrivers.Location = new System.Drawing.Point(424, 12);
            this.pbManagDrivers.Name = "pbManagDrivers";
            this.pbManagDrivers.Size = new System.Drawing.Size(204, 138);
            this.pbManagDrivers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbManagDrivers.TabIndex = 7;
            this.pbManagDrivers.TabStop = false;
            // 
            // cmsDriverInfo
            // 
            this.cmsDriverInfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDriverInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPeronInfoToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsDriverInfo.Name = "cmsDriverInfo";
            this.cmsDriverInfo.Size = new System.Drawing.Size(269, 84);
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
            // frmListDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 708);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.lblNumRecordsTag);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.cbFilterList);
            this.Controls.Add(this.lblFilterByTag);
            this.Controls.Add(this.dgvDrivers);
            this.Controls.Add(this.pbManagDrivers);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmListDrivers";
            this.Text = "frmListDrivers";
            this.Load += new System.EventHandler(this.frmListDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrivers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManagDrivers)).EndInit();
            this.cmsDriverInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.ComboBox cbFilterList;
        private System.Windows.Forms.Label lblFilterByTag;
        private System.Windows.Forms.DataGridView dgvDrivers;
        private System.Windows.Forms.PictureBox pbManagDrivers;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.Label lblNumRecordsTag;
        private System.Windows.Forms.ContextMenuStrip cmsDriverInfo;
        private System.Windows.Forms.ToolStripMenuItem showPeronInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}