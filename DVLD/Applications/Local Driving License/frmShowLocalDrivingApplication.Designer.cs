namespace DVLD.Applications.Local_Driving_License
{
    partial class frmShowLocalDrivingApplication
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
            this.ctrLocalDrivingLicenseApplication1 = new DVLD.Applications.Applications_Controls.ctrLocalDrivingLicenseApplication();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrLocalDrivingLicenseApplication1
            // 
            this.ctrLocalDrivingLicenseApplication1.Location = new System.Drawing.Point(3, 2);
            this.ctrLocalDrivingLicenseApplication1.Name = "ctrLocalDrivingLicenseApplication1";
            this.ctrLocalDrivingLicenseApplication1.Size = new System.Drawing.Size(949, 518);
            this.ctrLocalDrivingLicenseApplication1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(802, 547);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 38);
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowLocalDrivingApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 597);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrLocalDrivingLicenseApplication1);
            this.Name = "frmShowLocalDrivingApplication";
            this.Text = "frmShowLocalDrivingApplication";
            this.Load += new System.EventHandler(this.frmShowLocalDrivingApplication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Applications_Controls.ctrLocalDrivingLicenseApplication ctrLocalDrivingLicenseApplication1;
        private System.Windows.Forms.Button btnClose;
    }
}