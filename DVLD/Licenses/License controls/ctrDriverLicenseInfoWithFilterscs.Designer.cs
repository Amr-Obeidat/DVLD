namespace DVLD.Licenses.License_controls
{
    partial class ctrDriverLicenseInfoWithFilterscs
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
            this.gbDriverLicenseFilter = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.lblLicenseIdtag = new System.Windows.Forms.Label();
            this.txtLicenseId = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrDriverLicenseInfo1 = new DVLD.Licenses.License_controls.ctrDriverLicenseInfo();
            this.gbDriverLicenseFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDriverLicenseFilter
            // 
            this.gbDriverLicenseFilter.Controls.Add(this.btnFindLicense);
            this.gbDriverLicenseFilter.Controls.Add(this.lblLicenseIdtag);
            this.gbDriverLicenseFilter.Controls.Add(this.txtLicenseId);
            this.gbDriverLicenseFilter.Location = new System.Drawing.Point(3, 3);
            this.gbDriverLicenseFilter.Name = "gbDriverLicenseFilter";
            this.gbDriverLicenseFilter.Size = new System.Drawing.Size(999, 88);
            this.gbDriverLicenseFilter.TabIndex = 1;
            this.gbDriverLicenseFilter.TabStop = false;
            this.gbDriverLicenseFilter.Text = "Filter";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindLicense.Image = global::DVLD.Properties.Resources.License_Type_32;
            this.btnFindLicense.Location = new System.Drawing.Point(489, 40);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(90, 38);
            this.btnFindLicense.TabIndex = 2;
            this.btnFindLicense.Text = "Find";
            this.btnFindLicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFindLicense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFindLicense.UseVisualStyleBackColor = true;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // lblLicenseIdtag
            // 
            this.lblLicenseIdtag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseIdtag.Location = new System.Drawing.Point(13, 49);
            this.lblLicenseIdtag.Name = "lblLicenseIdtag";
            this.lblLicenseIdtag.Size = new System.Drawing.Size(121, 36);
            this.lblLicenseIdtag.TabIndex = 1;
            this.lblLicenseIdtag.Text = "LicenseID :";
            // 
            // txtLicenseId
            // 
            this.txtLicenseId.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenseId.Location = new System.Drawing.Point(140, 40);
            this.txtLicenseId.Multiline = true;
            this.txtLicenseId.Name = "txtLicenseId";
            this.txtLicenseId.Size = new System.Drawing.Size(343, 33);
            this.txtLicenseId.TabIndex = 0;
            this.txtLicenseId.TextChanged += new System.EventHandler(this.txtLicenseId_TextChanged);
            this.txtLicenseId.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicenseId_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrDriverLicenseInfo1
            // 
            this.ctrDriverLicenseInfo1.Location = new System.Drawing.Point(9, 91);
            this.ctrDriverLicenseInfo1.Name = "ctrDriverLicenseInfo1";
            this.ctrDriverLicenseInfo1.Size = new System.Drawing.Size(992, 405);
            this.ctrDriverLicenseInfo1.TabIndex = 0;
            this.ctrDriverLicenseInfo1.Load += new System.EventHandler(this.ctrDriverLicenseInfo1_Load);
            // 
            // ctrDriverLicenseInfoWithFilterscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDriverLicenseFilter);
            this.Controls.Add(this.ctrDriverLicenseInfo1);
            this.Name = "ctrDriverLicenseInfoWithFilterscs";
            this.Size = new System.Drawing.Size(1005, 496);
            this.gbDriverLicenseFilter.ResumeLayout(false);
            this.gbDriverLicenseFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrDriverLicenseInfo ctrDriverLicenseInfo1;
        private System.Windows.Forms.GroupBox gbDriverLicenseFilter;
        private System.Windows.Forms.Label lblLicenseIdtag;
        private System.Windows.Forms.TextBox txtLicenseId;
        private System.Windows.Forms.Button btnFindLicense;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
