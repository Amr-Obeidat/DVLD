namespace DVLD.Licenses.International_Licenses
{
    partial class frmShowInternationalLicenseInfo
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
            this.lbltitle = new System.Windows.Forms.Label();
            this.pbdriverLicenseInfo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrDriverInternationalLicenseInfo1 = new DVLD.Licenses.License_controls.ctrDriverInternationalLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pbdriverLicenseInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.Red;
            this.lbltitle.Location = new System.Drawing.Point(271, 168);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(523, 38);
            this.lbltitle.TabIndex = 5;
            this.lbltitle.Text = "International Driving License Info";
            // 
            // pbdriverLicenseInfo
            // 
            this.pbdriverLicenseInfo.Image = global::DVLD.Properties.Resources.international_100;
            this.pbdriverLicenseInfo.Location = new System.Drawing.Point(377, 12);
            this.pbdriverLicenseInfo.Name = "pbdriverLicenseInfo";
            this.pbdriverLicenseInfo.Size = new System.Drawing.Size(249, 144);
            this.pbdriverLicenseInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbdriverLicenseInfo.TabIndex = 4;
            this.pbdriverLicenseInfo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(898, 646);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 46);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrDriverInternationalLicenseInfo1
            // 
            this.ctrDriverInternationalLicenseInfo1.Location = new System.Drawing.Point(5, 234);
            this.ctrDriverInternationalLicenseInfo1.Name = "ctrDriverInternationalLicenseInfo1";
            this.ctrDriverInternationalLicenseInfo1.Size = new System.Drawing.Size(1013, 406);
            this.ctrDriverInternationalLicenseInfo1.TabIndex = 41;
            // 
            // frmShowInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 703);
            this.Controls.Add(this.ctrDriverInternationalLicenseInfo1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.pbdriverLicenseInfo);
            this.Name = "frmShowInternationalLicenseInfo";
            this.Text = "fmrShowInternationalLicenseInfo";
            this.Load += new System.EventHandler(this.frmShowInternationalLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbdriverLicenseInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.PictureBox pbdriverLicenseInfo;
        private System.Windows.Forms.Button btnClose;
        private License_controls.ctrDriverInternationalLicenseInfo ctrDriverInternationalLicenseInfo1;
    }
}