namespace DVLD.Licenses
{
    partial class frmShowLicenseInfo
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
            this.pbdriverLicenseInfo = new System.Windows.Forms.PictureBox();
            this.ctrDriverLicenseInfo1 = new DVLD.Licenses.License_controls.ctrDriverLicenseInfo();
            this.lbltitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbdriverLicenseInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbdriverLicenseInfo
            // 
            this.pbdriverLicenseInfo.Image = global::DVLD.Properties.Resources.LicenseView_400;
            this.pbdriverLicenseInfo.Location = new System.Drawing.Point(372, 25);
            this.pbdriverLicenseInfo.Name = "pbdriverLicenseInfo";
            this.pbdriverLicenseInfo.Size = new System.Drawing.Size(249, 144);
            this.pbdriverLicenseInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbdriverLicenseInfo.TabIndex = 1;
            this.pbdriverLicenseInfo.TabStop = false;
            // 
            // ctrDriverLicenseInfo1
            // 
            this.ctrDriverLicenseInfo1.Location = new System.Drawing.Point(1, 245);
            this.ctrDriverLicenseInfo1.Name = "ctrDriverLicenseInfo1";
            this.ctrDriverLicenseInfo1.Size = new System.Drawing.Size(1002, 409);
            this.ctrDriverLicenseInfo1.TabIndex = 2;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.Red;
            this.lbltitle.Location = new System.Drawing.Point(333, 192);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(337, 39);
            this.lbltitle.TabIndex = 3;
            this.lbltitle.Text = "Driving License Info";
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(883, 660);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 46);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 722);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.ctrDriverLicenseInfo1);
            this.Controls.Add(this.pbdriverLicenseInfo);
            this.Name = "frmShowLicenseInfo";
            this.Text = "frmShowLicenseInfo";
            this.Load += new System.EventHandler(this.frmShowLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbdriverLicenseInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbdriverLicenseInfo;
        private License_controls.ctrDriverLicenseInfo ctrDriverLicenseInfo1;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Button btnClose;
    }
}