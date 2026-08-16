namespace DVLD.Users
{
    partial class frmAddUpdateUser
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
            this.tcUser = new System.Windows.Forms.TabControl();
            this.tbPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrPersonCardWithFiltercs1 = new DVLD.Controls.ctrPersonCardWithFiltercs();
            this.tbLogInInfo = new System.Windows.Forms.TabPage();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblConfirmPasswordTag = new System.Windows.Forms.Label();
            this.lblPasswordTag = new System.Windows.Forms.Label();
            this.lblUserNameTag = new System.Windows.Forms.Label();
            this.lblUserIdTag = new System.Windows.Forms.Label();
            this.PicBName = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbNationalNoIcon = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcUser.SuspendLayout();
            this.tbPersonalInfo.SuspendLayout();
            this.tbLogInInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNationalNoIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcUser
            // 
            this.tcUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tcUser.Controls.Add(this.tbPersonalInfo);
            this.tcUser.Controls.Add(this.tbLogInInfo);
            this.tcUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcUser.Location = new System.Drawing.Point(12, 19);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(1021, 559);
            this.tcUser.TabIndex = 2;
            // 
            // tbPersonalInfo
            // 
            this.tbPersonalInfo.BackColor = System.Drawing.Color.White;
            this.tbPersonalInfo.Controls.Add(this.ctrPersonCardWithFiltercs1);
            this.tbPersonalInfo.Location = new System.Drawing.Point(4, 27);
            this.tbPersonalInfo.Name = "tbPersonalInfo";
            this.tbPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonalInfo.Size = new System.Drawing.Size(1013, 528);
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
            this.ctrPersonCardWithFiltercs1.Size = new System.Drawing.Size(1007, 522);
            this.ctrPersonCardWithFiltercs1.TabIndex = 0;
            this.ctrPersonCardWithFiltercs1.Load += new System.EventHandler(this.ctrPersonCardWithFiltercs1_Load);
            // 
            // tbLogInInfo
            // 
            this.tbLogInInfo.Controls.Add(this.chkIsActive);
            this.tbLogInInfo.Controls.Add(this.txtConfirmPassword);
            this.tbLogInInfo.Controls.Add(this.txtPassword);
            this.tbLogInInfo.Controls.Add(this.txtUserName);
            this.tbLogInInfo.Controls.Add(this.lblUserId);
            this.tbLogInInfo.Controls.Add(this.lblConfirmPasswordTag);
            this.tbLogInInfo.Controls.Add(this.lblPasswordTag);
            this.tbLogInInfo.Controls.Add(this.lblUserNameTag);
            this.tbLogInInfo.Controls.Add(this.lblUserIdTag);
            this.tbLogInInfo.Controls.Add(this.PicBName);
            this.tbLogInInfo.Controls.Add(this.pictureBox2);
            this.tbLogInInfo.Controls.Add(this.pictureBox1);
            this.tbLogInInfo.Controls.Add(this.pbNationalNoIcon);
            this.tbLogInInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbLogInInfo.Location = new System.Drawing.Point(4, 27);
            this.tbLogInInfo.Name = "tbLogInInfo";
            this.tbLogInInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbLogInInfo.Size = new System.Drawing.Size(1013, 528);
            this.tbLogInInfo.TabIndex = 1;
            this.tbLogInInfo.Text = "LogIn Info";
            this.tbLogInInfo.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(358, 313);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(87, 22);
            this.chkIsActive.TabIndex = 20;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(358, 264);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(148, 26);
            this.txtConfirmPassword.TabIndex = 19;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(358, 216);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(148, 26);
            this.txtPassword.TabIndex = 18;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(358, 174);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(148, 26);
            this.txtUserName.TabIndex = 17;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.Location = new System.Drawing.Point(354, 126);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(43, 24);
            this.lblUserId.TabIndex = 16;
            this.lblUserId.Text = "???";
            // 
            // lblConfirmPasswordTag
            // 
            this.lblConfirmPasswordTag.AutoSize = true;
            this.lblConfirmPasswordTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPasswordTag.Location = new System.Drawing.Point(53, 247);
            this.lblConfirmPasswordTag.Name = "lblConfirmPasswordTag";
            this.lblConfirmPasswordTag.Size = new System.Drawing.Size(200, 25);
            this.lblConfirmPasswordTag.TabIndex = 3;
            this.lblConfirmPasswordTag.Text = "Confirm Password :";
            // 
            // lblPasswordTag
            // 
            this.lblPasswordTag.AutoSize = true;
            this.lblPasswordTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordTag.Location = new System.Drawing.Point(134, 213);
            this.lblPasswordTag.Name = "lblPasswordTag";
            this.lblPasswordTag.Size = new System.Drawing.Size(119, 25);
            this.lblPasswordTag.TabIndex = 2;
            this.lblPasswordTag.Text = "Password :";
            // 
            // lblUserNameTag
            // 
            this.lblUserNameTag.AutoSize = true;
            this.lblUserNameTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameTag.Location = new System.Drawing.Point(121, 174);
            this.lblUserNameTag.Name = "lblUserNameTag";
            this.lblUserNameTag.Size = new System.Drawing.Size(132, 25);
            this.lblUserNameTag.TabIndex = 1;
            this.lblUserNameTag.Text = "User Name :";
            // 
            // lblUserIdTag
            // 
            this.lblUserIdTag.AutoSize = true;
            this.lblUserIdTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIdTag.Location = new System.Drawing.Point(156, 126);
            this.lblUserIdTag.Name = "lblUserIdTag";
            this.lblUserIdTag.Size = new System.Drawing.Size(97, 25);
            this.lblUserIdTag.TabIndex = 0;
            this.lblUserIdTag.Text = "User ID :";
            // 
            // PicBName
            // 
            this.PicBName.Image = global::DVLD.Properties.Resources.Person_32;
            this.PicBName.Location = new System.Drawing.Point(292, 170);
            this.PicBName.Name = "PicBName";
            this.PicBName.Size = new System.Drawing.Size(33, 29);
            this.PicBName.TabIndex = 15;
            this.PicBName.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox2.Location = new System.Drawing.Point(292, 261);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 31);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(292, 213);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 31);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
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
            // btnNext
            // 
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNext.CausesValidation = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNext.Location = new System.Drawing.Point(909, 584);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 45);
            this.btnNext.TabIndex = 44;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(433, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 36);
            this.lblTitle.TabIndex = 41;
            this.lblTitle.Text = "Add New User";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(783, 584);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 45);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
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
            this.btnClose.Location = new System.Drawing.Point(657, 584);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 45);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1031, 658);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tcUser);
            this.Name = "frmAddUpdateUser";
            this.Text = "frmAddUpdateUser";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.tcUser.ResumeLayout(false);
            this.tbPersonalInfo.ResumeLayout(false);
            this.tbLogInInfo.ResumeLayout(false);
            this.tbLogInInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNationalNoIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcUser;
        private System.Windows.Forms.TabPage tbPersonalInfo;
        private System.Windows.Forms.TabPage tbLogInInfo;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.PictureBox PicBName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbNationalNoIcon;
        private System.Windows.Forms.Label lblConfirmPasswordTag;
        private System.Windows.Forms.Label lblPasswordTag;
        private System.Windows.Forms.Label lblUserNameTag;
        private System.Windows.Forms.Label lblUserIdTag;
        private Controls.ctrPersonCardWithFiltercs ctrPersonCardWithFiltercs1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}