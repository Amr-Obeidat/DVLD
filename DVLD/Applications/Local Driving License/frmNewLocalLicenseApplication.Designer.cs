namespace DVLD.Applications.Local_Driving_License
{
    partial class frmNewLocalLicenseApplication
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
            this.tcAppInfo = new System.Windows.Forms.TabControl();
            this.tbPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrPersonCardWithFiltercs1 = new DVLD.Controls.ctrPersonCardWithFiltercs();
            this.tbAppInfo = new System.Windows.Forms.TabPage();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.pbCreatedBy = new System.Windows.Forms.PictureBox();
            this.lblCreatedBytag = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblApplicationFeestag = new System.Windows.Forms.Label();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.pbLicenseClass = new System.Windows.Forms.PictureBox();
            this.lblLicenseClasstag = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.pbDate = new System.Windows.Forms.PictureBox();
            this.lblApplicationDatetag = new System.Windows.Forms.Label();
            this.lblL_D_App_ID = new System.Windows.Forms.Label();
            this.lblL_D_App_tag = new System.Windows.Forms.Label();
            this.pbNationalNoIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tcAppInfo.SuspendLayout();
            this.tbPersonalInfo.SuspendLayout();
            this.tbAppInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLicenseClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNationalNoIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAppInfo
            // 
            this.tcAppInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tcAppInfo.Controls.Add(this.tbPersonalInfo);
            this.tcAppInfo.Controls.Add(this.tbAppInfo);
            this.tcAppInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAppInfo.Location = new System.Drawing.Point(22, 79);
            this.tcAppInfo.Name = "tcAppInfo";
            this.tcAppInfo.SelectedIndex = 0;
            this.tcAppInfo.Size = new System.Drawing.Size(1021, 581);
            this.tcAppInfo.TabIndex = 3;
            this.tcAppInfo.SelectedIndexChanged += new System.EventHandler(this.tcAppInfo_SelectedIndexChanged);
            // 
            // tbPersonalInfo
            // 
            this.tbPersonalInfo.BackColor = System.Drawing.Color.White;
            this.tbPersonalInfo.Controls.Add(this.ctrPersonCardWithFiltercs1);
            this.tbPersonalInfo.Location = new System.Drawing.Point(4, 27);
            this.tbPersonalInfo.Name = "tbPersonalInfo";
            this.tbPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonalInfo.Size = new System.Drawing.Size(1013, 550);
            this.tbPersonalInfo.TabIndex = 0;
            this.tbPersonalInfo.Text = "Person Info";
            // 
            // ctrPersonCardWithFiltercs1
            // 
            this.ctrPersonCardWithFiltercs1.BackColor = System.Drawing.Color.Transparent;
            this.ctrPersonCardWithFiltercs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrPersonCardWithFiltercs1.EnableEditPerson = true;
            this.ctrPersonCardWithFiltercs1.FilterEnabled = true;
            this.ctrPersonCardWithFiltercs1.Location = new System.Drawing.Point(3, 3);
            this.ctrPersonCardWithFiltercs1.Name = "ctrPersonCardWithFiltercs1";
            this.ctrPersonCardWithFiltercs1.ShowAddPerson = true;
            this.ctrPersonCardWithFiltercs1.Size = new System.Drawing.Size(1007, 544);
            this.ctrPersonCardWithFiltercs1.TabIndex = 0;
            // 
            // tbAppInfo
            // 
            this.tbAppInfo.Controls.Add(this.lblCreatedBy);
            this.tbAppInfo.Controls.Add(this.pbCreatedBy);
            this.tbAppInfo.Controls.Add(this.lblCreatedBytag);
            this.tbAppInfo.Controls.Add(this.lblApplicationFees);
            this.tbAppInfo.Controls.Add(this.pictureBox1);
            this.tbAppInfo.Controls.Add(this.lblApplicationFeestag);
            this.tbAppInfo.Controls.Add(this.cbLicenseClass);
            this.tbAppInfo.Controls.Add(this.pbLicenseClass);
            this.tbAppInfo.Controls.Add(this.lblLicenseClasstag);
            this.tbAppInfo.Controls.Add(this.lblAppDate);
            this.tbAppInfo.Controls.Add(this.pbDate);
            this.tbAppInfo.Controls.Add(this.lblApplicationDatetag);
            this.tbAppInfo.Controls.Add(this.lblL_D_App_ID);
            this.tbAppInfo.Controls.Add(this.lblL_D_App_tag);
            this.tbAppInfo.Controls.Add(this.pbNationalNoIcon);
            this.tbAppInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbAppInfo.Location = new System.Drawing.Point(4, 27);
            this.tbAppInfo.Name = "tbAppInfo";
            this.tbAppInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbAppInfo.Size = new System.Drawing.Size(1013, 550);
            this.tbAppInfo.TabIndex = 1;
            this.tbAppInfo.Text = "Application Info";
            this.tbAppInfo.UseVisualStyleBackColor = true;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(354, 374);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(43, 24);
            this.lblCreatedBy.TabIndex = 28;
            this.lblCreatedBy.Text = "???";
            // 
            // pbCreatedBy
            // 
            this.pbCreatedBy.Image = global::DVLD.Properties.Resources.User_32__2;
            this.pbCreatedBy.Location = new System.Drawing.Point(292, 367);
            this.pbCreatedBy.Name = "pbCreatedBy";
            this.pbCreatedBy.Size = new System.Drawing.Size(33, 31);
            this.pbCreatedBy.TabIndex = 27;
            this.pbCreatedBy.TabStop = false;
            // 
            // lblCreatedBytag
            // 
            this.lblCreatedBytag.AutoSize = true;
            this.lblCreatedBytag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBytag.Location = new System.Drawing.Point(108, 367);
            this.lblCreatedBytag.Name = "lblCreatedBytag";
            this.lblCreatedBytag.Size = new System.Drawing.Size(133, 25);
            this.lblCreatedBytag.TabIndex = 26;
            this.lblCreatedBytag.Text = "Created By :";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(354, 323);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(43, 24);
            this.lblApplicationFees.TabIndex = 25;
            this.lblApplicationFees.Text = "???";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox1.Location = new System.Drawing.Point(292, 316);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 31);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // lblApplicationFeestag
            // 
            this.lblApplicationFeestag.AutoSize = true;
            this.lblApplicationFeestag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFeestag.Location = new System.Drawing.Point(55, 316);
            this.lblApplicationFeestag.Name = "lblApplicationFeestag";
            this.lblApplicationFeestag.Size = new System.Drawing.Size(186, 25);
            this.lblApplicationFeestag.TabIndex = 23;
            this.lblApplicationFeestag.Text = "Application Fees :";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(343, 256);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(144, 26);
            this.cbLicenseClass.TabIndex = 22;
            // 
            // pbLicenseClass
            // 
            this.pbLicenseClass.Image = global::DVLD.Properties.Resources.License_Type_32;
            this.pbLicenseClass.Location = new System.Drawing.Point(292, 251);
            this.pbLicenseClass.Name = "pbLicenseClass";
            this.pbLicenseClass.Size = new System.Drawing.Size(33, 31);
            this.pbLicenseClass.TabIndex = 21;
            this.pbLicenseClass.TabStop = false;
            // 
            // lblLicenseClasstag
            // 
            this.lblLicenseClasstag.AutoSize = true;
            this.lblLicenseClasstag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseClasstag.Location = new System.Drawing.Point(80, 254);
            this.lblLicenseClasstag.Name = "lblLicenseClasstag";
            this.lblLicenseClasstag.Size = new System.Drawing.Size(161, 25);
            this.lblLicenseClasstag.TabIndex = 20;
            this.lblLicenseClasstag.Text = "License Class :";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(354, 192);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(43, 24);
            this.lblAppDate.TabIndex = 19;
            this.lblAppDate.Text = "???";
            // 
            // pbDate
            // 
            this.pbDate.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pbDate.Location = new System.Drawing.Point(292, 192);
            this.pbDate.Name = "pbDate";
            this.pbDate.Size = new System.Drawing.Size(33, 31);
            this.pbDate.TabIndex = 18;
            this.pbDate.TabStop = false;
            // 
            // lblApplicationDatetag
            // 
            this.lblApplicationDatetag.AutoSize = true;
            this.lblApplicationDatetag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDatetag.Location = new System.Drawing.Point(58, 191);
            this.lblApplicationDatetag.Name = "lblApplicationDatetag";
            this.lblApplicationDatetag.Size = new System.Drawing.Size(183, 25);
            this.lblApplicationDatetag.TabIndex = 17;
            this.lblApplicationDatetag.Text = "Application Date :";
            // 
            // lblL_D_App_ID
            // 
            this.lblL_D_App_ID.AutoSize = true;
            this.lblL_D_App_ID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblL_D_App_ID.Location = new System.Drawing.Point(354, 126);
            this.lblL_D_App_ID.Name = "lblL_D_App_ID";
            this.lblL_D_App_ID.Size = new System.Drawing.Size(43, 24);
            this.lblL_D_App_ID.TabIndex = 16;
            this.lblL_D_App_ID.Text = "???";
            // 
            // lblL_D_App_tag
            // 
            this.lblL_D_App_tag.AutoSize = true;
            this.lblL_D_App_tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblL_D_App_tag.Location = new System.Drawing.Point(43, 132);
            this.lblL_D_App_tag.Name = "lblL_D_App_tag";
            this.lblL_D_App_tag.Size = new System.Drawing.Size(198, 25);
            this.lblL_D_App_tag.TabIndex = 0;
            this.lblL_D_App_tag.Text = "D.L.Application ID :";
            // 
            // pbNationalNoIcon
            // 
            this.pbNationalNoIcon.Image = global::DVLD.Properties.Resources.Number_32;
            this.pbNationalNoIcon.Location = new System.Drawing.Point(292, 126);
            this.pbNationalNoIcon.Name = "pbNationalNoIcon";
            this.pbNationalNoIcon.Size = new System.Drawing.Size(33, 31);
            this.pbNationalNoIcon.TabIndex = 12;
            this.pbNationalNoIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(270, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(562, 36);
            this.lblTitle.TabIndex = 42;
            this.lblTitle.Text = "New Local Driving License Application";
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNext.CausesValidation = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNext.Location = new System.Drawing.Point(919, 681);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 45);
            this.btnNext.TabIndex = 46;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(793, 681);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 45);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(667, 681);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 45);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.CausesValidation = false;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::DVLD.Properties.Resources.Prev_32;
            this.btnBack.Location = new System.Drawing.Point(26, 681);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 45);
            this.btnBack.TabIndex = 48;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmNewLocalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1065, 738);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tcAppInfo);
            this.Name = "frmNewLocalLicenseApplication";
            this.Text = "frmNewLocalLicenseApplication";
            this.Load += new System.EventHandler(this.frmNewLocalLicenseApplication_Load);
            this.tcAppInfo.ResumeLayout(false);
            this.tbPersonalInfo.ResumeLayout(false);
            this.tbAppInfo.ResumeLayout(false);
            this.tbAppInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLicenseClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNationalNoIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcAppInfo;
        private System.Windows.Forms.TabPage tbPersonalInfo;
        private Controls.ctrPersonCardWithFiltercs ctrPersonCardWithFiltercs1;
        private System.Windows.Forms.TabPage tbAppInfo;
        private System.Windows.Forms.Label lblL_D_App_ID;
        private System.Windows.Forms.Label lblL_D_App_tag;
        private System.Windows.Forms.PictureBox pbNationalNoIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.PictureBox pbDate;
        private System.Windows.Forms.Label lblApplicationDatetag;
        private System.Windows.Forms.Label lblLicenseClasstag;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.PictureBox pbLicenseClass;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.PictureBox pbCreatedBy;
        private System.Windows.Forms.Label lblCreatedBytag;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblApplicationFeestag;
        private System.Windows.Forms.Button btnBack;
    }
}