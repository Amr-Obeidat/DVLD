namespace DVLD.Drivers.Driver_Controls
{
    partial class ctrDrivingLicense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbDriver = new System.Windows.Forms.GroupBox();
            this.tcDriver = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.lblLocalnumcnt = new System.Windows.Forms.Label();
            this.lblNumRecordsTag = new System.Windows.Forms.Label();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.lblInternationalnumcnt = new System.Windows.Forms.Label();
            this.lblRecordstag = new System.Windows.Forms.Label();
            this.dgvInternationalLicense = new System.Windows.Forms.DataGridView();
            this.dgvLocal = new System.Windows.Forms.DataGridView();
            this.cmsLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsInternational = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDriver.SuspendLayout();
            this.tcDriver.SuspendLayout();
            this.tpLocal.SuspendLayout();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).BeginInit();
            this.cmsLocal.SuspendLayout();
            this.cmsInternational.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDriver
            // 
            this.gbDriver.Controls.Add(this.tcDriver);
            this.gbDriver.Location = new System.Drawing.Point(3, 3);
            this.gbDriver.Name = "gbDriver";
            this.gbDriver.Size = new System.Drawing.Size(853, 248);
            this.gbDriver.TabIndex = 1;
            this.gbDriver.TabStop = false;
            this.gbDriver.Text = "Driver License";
            this.gbDriver.Enter += new System.EventHandler(this.gbDriver_Enter);
            // 
            // tcDriver
            // 
            this.tcDriver.Controls.Add(this.tpLocal);
            this.tcDriver.Controls.Add(this.tpInternational);
            this.tcDriver.Location = new System.Drawing.Point(6, 23);
            this.tcDriver.Name = "tcDriver";
            this.tcDriver.SelectedIndex = 0;
            this.tcDriver.Size = new System.Drawing.Size(850, 223);
            this.tcDriver.TabIndex = 1;
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.dgvLocal);
            this.tpLocal.Controls.Add(this.lblLocalnumcnt);
            this.tpLocal.Controls.Add(this.lblNumRecordsTag);
            this.tpLocal.Location = new System.Drawing.Point(4, 25);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(842, 194);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // lblLocalnumcnt
            // 
            this.lblLocalnumcnt.AutoSize = true;
            this.lblLocalnumcnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalnumcnt.Location = new System.Drawing.Point(121, 159);
            this.lblLocalnumcnt.Name = "lblLocalnumcnt";
            this.lblLocalnumcnt.Size = new System.Drawing.Size(36, 25);
            this.lblLocalnumcnt.TabIndex = 9;
            this.lblLocalnumcnt.Text = "??";
            // 
            // lblNumRecordsTag
            // 
            this.lblNumRecordsTag.AutoSize = true;
            this.lblNumRecordsTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecordsTag.Location = new System.Drawing.Point(6, 159);
            this.lblNumRecordsTag.Name = "lblNumRecordsTag";
            this.lblNumRecordsTag.Size = new System.Drawing.Size(109, 25);
            this.lblNumRecordsTag.TabIndex = 8;
            this.lblNumRecordsTag.Text = "# Records";
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.lblInternationalnumcnt);
            this.tpInternational.Controls.Add(this.lblRecordstag);
            this.tpInternational.Controls.Add(this.dgvInternationalLicense);
            this.tpInternational.Location = new System.Drawing.Point(4, 25);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(842, 194);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // lblInternationalnumcnt
            // 
            this.lblInternationalnumcnt.AutoSize = true;
            this.lblInternationalnumcnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalnumcnt.Location = new System.Drawing.Point(121, 159);
            this.lblInternationalnumcnt.Name = "lblInternationalnumcnt";
            this.lblInternationalnumcnt.Size = new System.Drawing.Size(36, 25);
            this.lblInternationalnumcnt.TabIndex = 12;
            this.lblInternationalnumcnt.Text = "??";
            // 
            // lblRecordstag
            // 
            this.lblRecordstag.AutoSize = true;
            this.lblRecordstag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordstag.Location = new System.Drawing.Point(6, 159);
            this.lblRecordstag.Name = "lblRecordstag";
            this.lblRecordstag.Size = new System.Drawing.Size(109, 25);
            this.lblRecordstag.TabIndex = 11;
            this.lblRecordstag.Text = "# Records";
            // 
            // dgvInternationalLicense
            // 
            this.dgvInternationalLicense.AllowUserToAddRows = false;
            this.dgvInternationalLicense.AllowUserToDeleteRows = false;
            this.dgvInternationalLicense.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicense.ContextMenuStrip = this.cmsInternational;
            this.dgvInternationalLicense.Location = new System.Drawing.Point(3, 6);
            this.dgvInternationalLicense.Name = "dgvInternationalLicense";
            this.dgvInternationalLicense.ReadOnly = true;
            this.dgvInternationalLicense.RowHeadersWidth = 51;
            this.dgvInternationalLicense.RowTemplate.Height = 26;
            this.dgvInternationalLicense.Size = new System.Drawing.Size(832, 150);
            this.dgvInternationalLicense.TabIndex = 10;
            // 
            // dgvLocal
            // 
            this.dgvLocal.AllowUserToAddRows = false;
            this.dgvLocal.AllowUserToDeleteRows = false;
            this.dgvLocal.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocal.ContextMenuStrip = this.cmsLocal;
            this.dgvLocal.Location = new System.Drawing.Point(3, 6);
            this.dgvLocal.Name = "dgvLocal";
            this.dgvLocal.ReadOnly = true;
            this.dgvLocal.RowHeadersWidth = 51;
            this.dgvLocal.RowTemplate.Height = 26;
            this.dgvLocal.Size = new System.Drawing.Size(836, 150);
            this.dgvLocal.TabIndex = 11;
            // 
            // cmsLocal
            // 
            this.cmsLocal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLocal.Name = "cmsLocal";
            this.cmsLocal.Size = new System.Drawing.Size(201, 30);
            // 
            // cmsInternational
            // 
            this.cmsInternational.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInternational.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem1});
            this.cmsInternational.Name = "cmsInternational";
            this.cmsInternational.Size = new System.Drawing.Size(201, 30);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // showLicenseInfoToolStripMenuItem1
            // 
            this.showLicenseInfoToolStripMenuItem1.Image = global::DVLD.Properties.Resources.International_32;
            this.showLicenseInfoToolStripMenuItem1.Name = "showLicenseInfoToolStripMenuItem1";
            this.showLicenseInfoToolStripMenuItem1.Size = new System.Drawing.Size(200, 26);
            this.showLicenseInfoToolStripMenuItem1.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem1.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem1_Click);
            // 
            // ctrDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDriver);
            this.Name = "ctrDrivingLicense";
            this.Size = new System.Drawing.Size(859, 257);
            this.gbDriver.ResumeLayout(false);
            this.tcDriver.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).EndInit();
            this.cmsLocal.ResumeLayout(false);
            this.cmsInternational.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDriver;
        private System.Windows.Forms.TabControl tcDriver;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.Label lblLocalnumcnt;
        private System.Windows.Forms.Label lblNumRecordsTag;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.Label lblInternationalnumcnt;
        private System.Windows.Forms.Label lblRecordstag;
        private System.Windows.Forms.DataGridView dgvInternationalLicense;
        private System.Windows.Forms.DataGridView dgvLocal;
        private System.Windows.Forms.ContextMenuStrip cmsLocal;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsInternational;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem1;
    }
}
