namespace DVLD.Licenses.Detain_License
{
    partial class frmDetainLicense
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
            this.gbDetainLicense = new System.Windows.Forms.GroupBox();
            this.txtDetainfees = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDetainfeestag = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblDetainDatetag = new System.Windows.Forms.Label();
            this.lblDetainId = new System.Windows.Forms.Label();
            this.lblDetainDTag = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.pbCreatedBy = new System.Windows.Forms.PictureBox();
            this.lblCreatedBytag = new System.Windows.Forms.Label();
            this.linklblShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linklblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrDriverLicenseInfoWithFilterscs1 = new DVLD.Licenses.License_controls.ctrDriverLicenseInfoWithFilterscs();
            this.gbDetainLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDetainLicense
            // 
            this.gbDetainLicense.Controls.Add(this.txtDetainfees);
            this.gbDetainLicense.Controls.Add(this.pictureBox1);
            this.gbDetainLicense.Controls.Add(this.lblDetainfeestag);
            this.gbDetainLicense.Controls.Add(this.lblDetainDate);
            this.gbDetainLicense.Controls.Add(this.pictureBox2);
            this.gbDetainLicense.Controls.Add(this.lblDetainDatetag);
            this.gbDetainLicense.Controls.Add(this.lblDetainId);
            this.gbDetainLicense.Controls.Add(this.lblDetainDTag);
            this.gbDetainLicense.Controls.Add(this.pictureBox3);
            this.gbDetainLicense.Controls.Add(this.lblCreatedBy);
            this.gbDetainLicense.Controls.Add(this.pbCreatedBy);
            this.gbDetainLicense.Controls.Add(this.lblCreatedBytag);
            this.gbDetainLicense.Location = new System.Drawing.Point(2, 505);
            this.gbDetainLicense.Name = "gbDetainLicense";
            this.gbDetainLicense.Size = new System.Drawing.Size(1005, 183);
            this.gbDetainLicense.TabIndex = 1;
            this.gbDetainLicense.TabStop = false;
            this.gbDetainLicense.Text = "Detain  Info";
            this.gbDetainLicense.Enter += new System.EventHandler(this.gbDetainLicense_Enter);
            // 
            // txtDetainfees
            // 
            this.txtDetainfees.Location = new System.Drawing.Point(871, 108);
            this.txtDetainfees.Name = "txtDetainfees";
            this.txtDetainfees.Size = new System.Drawing.Size(100, 24);
            this.txtDetainfees.TabIndex = 52;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox1.Location = new System.Drawing.Point(820, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 31);
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // lblDetainfeestag
            // 
            this.lblDetainfeestag.AutoSize = true;
            this.lblDetainfeestag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainfeestag.Location = new System.Drawing.Point(669, 107);
            this.lblDetainfeestag.Name = "lblDetainfeestag";
            this.lblDetainfeestag.Size = new System.Drawing.Size(134, 25);
            this.lblDetainfeestag.TabIndex = 50;
            this.lblDetainfeestag.Text = "Detain fees :";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(207, 108);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(140, 24);
            this.lblDetainDate.TabIndex = 49;
            this.lblDetainDate.Text = "[??/??/????]";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pictureBox2.Location = new System.Drawing.Point(157, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 31);
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            // 
            // lblDetainDatetag
            // 
            this.lblDetainDatetag.AutoSize = true;
            this.lblDetainDatetag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDatetag.Location = new System.Drawing.Point(6, 107);
            this.lblDetainDatetag.Name = "lblDetainDatetag";
            this.lblDetainDatetag.Size = new System.Drawing.Size(138, 25);
            this.lblDetainDatetag.TabIndex = 47;
            this.lblDetainDatetag.Text = "Detain Date :";
            // 
            // lblDetainId
            // 
            this.lblDetainId.AutoSize = true;
            this.lblDetainId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainId.Location = new System.Drawing.Point(207, 61);
            this.lblDetainId.Name = "lblDetainId";
            this.lblDetainId.Size = new System.Drawing.Size(61, 24);
            this.lblDetainId.TabIndex = 46;
            this.lblDetainId.Text = "[???]";
            // 
            // lblDetainDTag
            // 
            this.lblDetainDTag.AutoSize = true;
            this.lblDetainDTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDTag.Location = new System.Drawing.Point(26, 61);
            this.lblDetainDTag.Name = "lblDetainDTag";
            this.lblDetainDTag.Size = new System.Drawing.Size(114, 25);
            this.lblDetainDTag.TabIndex = 44;
            this.lblDetainDTag.Text = "Detain ID :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(157, 60);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 31);
            this.pictureBox3.TabIndex = 45;
            this.pictureBox3.TabStop = false;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(863, 60);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(61, 24);
            this.lblCreatedBy.TabIndex = 37;
            this.lblCreatedBy.Text = "[???]";
            // 
            // pbCreatedBy
            // 
            this.pbCreatedBy.Image = global::DVLD.Properties.Resources.User_32__2;
            this.pbCreatedBy.Location = new System.Drawing.Point(818, 54);
            this.pbCreatedBy.Name = "pbCreatedBy";
            this.pbCreatedBy.Size = new System.Drawing.Size(33, 31);
            this.pbCreatedBy.TabIndex = 36;
            this.pbCreatedBy.TabStop = false;
            // 
            // lblCreatedBytag
            // 
            this.lblCreatedBytag.AutoSize = true;
            this.lblCreatedBytag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBytag.Location = new System.Drawing.Point(670, 59);
            this.lblCreatedBytag.Name = "lblCreatedBytag";
            this.lblCreatedBytag.Size = new System.Drawing.Size(133, 25);
            this.lblCreatedBytag.TabIndex = 35;
            this.lblCreatedBytag.Text = "Created By :";
            // 
            // linklblShowNewLicenseInfo
            // 
            this.linklblShowNewLicenseInfo.AutoSize = true;
            this.linklblShowNewLicenseInfo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblShowNewLicenseInfo.Location = new System.Drawing.Point(196, 701);
            this.linklblShowNewLicenseInfo.Name = "linklblShowNewLicenseInfo";
            this.linklblShowNewLicenseInfo.Size = new System.Drawing.Size(182, 21);
            this.linklblShowNewLicenseInfo.TabIndex = 48;
            this.linklblShowNewLicenseInfo.TabStop = true;
            this.linklblShowNewLicenseInfo.Text = "Show New License Info";
            this.linklblShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowNewLicenseInfo_LinkClicked_1);
            // 
            // linklblShowLicenseHistory
            // 
            this.linklblShowLicenseHistory.AutoSize = true;
            this.linklblShowLicenseHistory.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblShowLicenseHistory.Location = new System.Drawing.Point(9, 701);
            this.linklblShowLicenseHistory.Name = "linklblShowLicenseHistory";
            this.linklblShowLicenseHistory.Size = new System.Drawing.Size(167, 21);
            this.linklblShowLicenseHistory.TabIndex = 47;
            this.linklblShowLicenseHistory.TabStop = true;
            this.linklblShowLicenseHistory.Text = "Show License History";
            this.linklblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseHistory_LinkClicked_1);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(745, 694);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 47);
            this.btnClose.TabIndex = 45;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnDetain
            // 
            this.btnDetain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetain.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDetain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetain.Image = global::DVLD.Properties.Resources.Detain;
            this.btnDetain.Location = new System.Drawing.Point(873, 694);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(120, 47);
            this.btnDetain.TabIndex = 44;
            this.btnDetain.Text = "Detain";
            this.btnDetain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrDriverLicenseInfoWithFilterscs1
            // 
            this.ctrDriverLicenseInfoWithFilterscs1.FilterEnabled = true;
            this.ctrDriverLicenseInfoWithFilterscs1.Location = new System.Drawing.Point(2, 3);
            this.ctrDriverLicenseInfoWithFilterscs1.Name = "ctrDriverLicenseInfoWithFilterscs1";
            this.ctrDriverLicenseInfoWithFilterscs1.Size = new System.Drawing.Size(1005, 496);
            this.ctrDriverLicenseInfoWithFilterscs1.TabIndex = 0;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 781);
            this.Controls.Add(this.linklblShowNewLicenseInfo);
            this.Controls.Add(this.linklblShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.gbDetainLicense);
            this.Controls.Add(this.ctrDriverLicenseInfoWithFilterscs1);
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetainLicense";
            this.Load += new System.EventHandler(this.frmDetainLicense_Load);
            this.gbDetainLicense.ResumeLayout(false);
            this.gbDetainLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private License_controls.ctrDriverLicenseInfoWithFilterscs ctrDriverLicenseInfoWithFilterscs1;
        private System.Windows.Forms.GroupBox gbDetainLicense;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.PictureBox pbCreatedBy;
        private System.Windows.Forms.Label lblCreatedBytag;
        private System.Windows.Forms.Label lblDetainId;
        private System.Windows.Forms.Label lblDetainDTag;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblDetainDatetag;
        private System.Windows.Forms.TextBox txtDetainfees;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDetainfeestag;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.LinkLabel linklblShowNewLicenseInfo;
        private System.Windows.Forms.LinkLabel linklblShowLicenseHistory;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}