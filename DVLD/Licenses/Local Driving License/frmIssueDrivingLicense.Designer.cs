namespace DVLD.Licenses
{
    partial class frmIssueDrivingLicense
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
            this.lblNotestag = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.pbClassDescription = new System.Windows.Forms.PictureBox();
            this.ctrLocalDrivingLicenseApplication1 = new DVLD.Applications.Applications_Controls.ctrLocalDrivingLicenseApplication();
            ((System.ComponentModel.ISupportInitialize)(this.pbClassDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNotestag
            // 
            this.lblNotestag.AutoSize = true;
            this.lblNotestag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotestag.Location = new System.Drawing.Point(34, 552);
            this.lblNotestag.Name = "lblNotestag";
            this.lblNotestag.Size = new System.Drawing.Size(81, 25);
            this.lblNotestag.TabIndex = 38;
            this.lblNotestag.Text = "Notes :";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(179, 552);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(602, 109);
            this.txtNotes.TabIndex = 39;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(533, 667);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 38);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIssue.Image = global::DVLD.Properties.Resources.Issue;
            this.btnIssue.Location = new System.Drawing.Point(661, 667);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(120, 38);
            this.btnIssue.TabIndex = 42;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // pbClassDescription
            // 
            this.pbClassDescription.Image = global::DVLD.Properties.Resources.icons8_description_641;
            this.pbClassDescription.Location = new System.Drawing.Point(121, 552);
            this.pbClassDescription.Name = "pbClassDescription";
            this.pbClassDescription.Size = new System.Drawing.Size(32, 33);
            this.pbClassDescription.TabIndex = 30;
            this.pbClassDescription.TabStop = false;
            // 
            // ctrLocalDrivingLicenseApplication1
            // 
            this.ctrLocalDrivingLicenseApplication1.Location = new System.Drawing.Point(5, 2);
            this.ctrLocalDrivingLicenseApplication1.Name = "ctrLocalDrivingLicenseApplication1";
            this.ctrLocalDrivingLicenseApplication1.Size = new System.Drawing.Size(949, 518);
            this.ctrLocalDrivingLicenseApplication1.TabIndex = 0;
            this.ctrLocalDrivingLicenseApplication1.Load += new System.EventHandler(this.ctrLocalDrivingLicenseApplication1_Load);
            // 
            // frmIssueDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 772);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotestag);
            this.Controls.Add(this.pbClassDescription);
            this.Controls.Add(this.ctrLocalDrivingLicenseApplication1);
            this.Name = "frmIssueDrivingLicense";
            this.Text = "frmIssueDrivingLicense";
            this.Load += new System.EventHandler(this.frmIssueDrivingLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbClassDescription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Applications_Controls.ctrLocalDrivingLicenseApplication ctrLocalDrivingLicenseApplication1;
        private System.Windows.Forms.PictureBox pbClassDescription;
        private System.Windows.Forms.Label lblNotestag;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
    }
}