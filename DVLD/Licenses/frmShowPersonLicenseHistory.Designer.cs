namespace DVLD.Licenses
{
    partial class frmShowPersonLicenseHistory
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
            this.ctrPersonCardWithFiltercs1 = new DVLD.Controls.ctrPersonCardWithFiltercs();
            this.ctrDrivingLicense1 = new DVLD.Drivers.Driver_Controls.ctrDrivingLicense();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.Red;
            this.lbltitle.Location = new System.Drawing.Point(339, 24);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(257, 38);
            this.lbltitle.TabIndex = 4;
            this.lbltitle.Text = "License History";
            // 
            // ctrPersonCardWithFiltercs1
            // 
            this.ctrPersonCardWithFiltercs1.EnableEditPerson = true;
            this.ctrPersonCardWithFiltercs1.FilterEnabled = true;
            this.ctrPersonCardWithFiltercs1.Location = new System.Drawing.Point(12, 65);
            this.ctrPersonCardWithFiltercs1.Name = "ctrPersonCardWithFiltercs1";
            this.ctrPersonCardWithFiltercs1.ShowAddPerson = true;
            this.ctrPersonCardWithFiltercs1.Size = new System.Drawing.Size(867, 477);
            this.ctrPersonCardWithFiltercs1.TabIndex = 5;
            // 
            // ctrDrivingLicense1
            // 
            this.ctrDrivingLicense1.Location = new System.Drawing.Point(-2, 548);
            this.ctrDrivingLicense1.Name = "ctrDrivingLicense1";
            this.ctrDrivingLicense1.Size = new System.Drawing.Size(859, 257);
            this.ctrDrivingLicense1.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(737, 802);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 46);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 851);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrDrivingLicense1);
            this.Controls.Add(this.ctrPersonCardWithFiltercs1);
            this.Controls.Add(this.lbltitle);
            this.Name = "frmShowPersonLicenseHistory";
            this.Text = "frmShowPersonLicenseHistory";
            this.Load += new System.EventHandler(this.frmShowPersonLicenseHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitle;
        private Controls.ctrPersonCardWithFiltercs ctrPersonCardWithFiltercs1;
        private Drivers.Driver_Controls.ctrDrivingLicense ctrDrivingLicense1;
        private System.Windows.Forms.Button btnClose;
    }
}