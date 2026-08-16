namespace DVLD.People
{
    partial class frmAddUpdatePerson
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPersonId = new System.Windows.Forms.Label();
            this.PnlPerson = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.llSetImage = new System.Windows.Forms.LinkLabel();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.pbAddress = new System.Windows.Forms.PictureBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.pbCountryIcon = new System.Windows.Forms.PictureBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.PbEmail = new System.Windows.Forms.PictureBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.pbPhoneIcon = new System.Windows.Forms.PictureBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.pbGendorWomen = new System.Windows.Forms.PictureBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.pbGendorMan = new System.Windows.Forms.PictureBox();
            this.lblGendor = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.pbDateOfBirthIcon = new System.Windows.Forms.PictureBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.txtNatNo = new System.Windows.Forms.TextBox();
            this.pbNationalNoIcon = new System.Windows.Forms.PictureBox();
            this.lblNational = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblThird = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.txtThird = new System.Windows.Forms.TextBox();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.PicBName = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblPersonIdTag = new System.Windows.Forms.Label();
            this.pbPersonIDIcon = new System.Windows.Forms.PictureBox();
            this.PnlPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCountryIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoneIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGendorWomen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGendorMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDateOfBirthIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNationalNoIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonIDIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(490, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Person";
            // 
            // lblPersonId
            // 
            this.lblPersonId.AutoSize = true;
            this.lblPersonId.BackColor = System.Drawing.Color.White;
            this.lblPersonId.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonId.ForeColor = System.Drawing.Color.Black;
            this.lblPersonId.Location = new System.Drawing.Point(287, 99);
            this.lblPersonId.Name = "lblPersonId";
            this.lblPersonId.Size = new System.Drawing.Size(69, 36);
            this.lblPersonId.TabIndex = 1;
            this.lblPersonId.Text = "N/A";
            // 
            // PnlPerson
            // 
            this.PnlPerson.Controls.Add(this.btnSave);
            this.PnlPerson.Controls.Add(this.btnClose);
            this.PnlPerson.Controls.Add(this.llRemoveImage);
            this.PnlPerson.Controls.Add(this.llSetImage);
            this.PnlPerson.Controls.Add(this.pbPersonImage);
            this.PnlPerson.Controls.Add(this.txtAddress);
            this.PnlPerson.Controls.Add(this.pbAddress);
            this.PnlPerson.Controls.Add(this.lblAddress);
            this.PnlPerson.Controls.Add(this.cbCountry);
            this.PnlPerson.Controls.Add(this.pbCountryIcon);
            this.PnlPerson.Controls.Add(this.lblCountry);
            this.PnlPerson.Controls.Add(this.txtEmail);
            this.PnlPerson.Controls.Add(this.PbEmail);
            this.PnlPerson.Controls.Add(this.lblEmail);
            this.PnlPerson.Controls.Add(this.pbPhoneIcon);
            this.PnlPerson.Controls.Add(this.txtPhone);
            this.PnlPerson.Controls.Add(this.lblPhone);
            this.PnlPerson.Controls.Add(this.pbGendorWomen);
            this.PnlPerson.Controls.Add(this.rbFemale);
            this.PnlPerson.Controls.Add(this.rbMale);
            this.PnlPerson.Controls.Add(this.pbGendorMan);
            this.PnlPerson.Controls.Add(this.lblGendor);
            this.PnlPerson.Controls.Add(this.dtpDateOfBirth);
            this.PnlPerson.Controls.Add(this.pbDateOfBirthIcon);
            this.PnlPerson.Controls.Add(this.lblDateOfBirth);
            this.PnlPerson.Controls.Add(this.txtNatNo);
            this.PnlPerson.Controls.Add(this.pbNationalNoIcon);
            this.PnlPerson.Controls.Add(this.lblNational);
            this.PnlPerson.Controls.Add(this.lblLast);
            this.PnlPerson.Controls.Add(this.lblThird);
            this.PnlPerson.Controls.Add(this.lblSecond);
            this.PnlPerson.Controls.Add(this.lblFirst);
            this.PnlPerson.Controls.Add(this.txtLast);
            this.PnlPerson.Controls.Add(this.txtThird);
            this.PnlPerson.Controls.Add(this.txtSecond);
            this.PnlPerson.Controls.Add(this.txtFirst);
            this.PnlPerson.Controls.Add(this.PicBName);
            this.PnlPerson.Controls.Add(this.lblName);
            this.PnlPerson.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlPerson.Location = new System.Drawing.Point(-4, 138);
            this.PnlPerson.Name = "PnlPerson";
            this.PnlPerson.Size = new System.Drawing.Size(1379, 497);
            this.PnlPerson.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1164, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 38);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btn_SaveClick);
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1026, 405);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 38);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btn_Close);
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.AutoSize = true;
            this.llRemoveImage.Location = new System.Drawing.Point(1094, 322);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.Size = new System.Drawing.Size(129, 23);
            this.llRemoveImage.TabIndex = 35;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "Remove Image";
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked);
            // 
            // llSetImage
            // 
            this.llSetImage.AutoSize = true;
            this.llSetImage.Location = new System.Drawing.Point(1094, 269);
            this.llSetImage.Name = "llSetImage";
            this.llSetImage.Size = new System.Drawing.Size(91, 23);
            this.llSetImage.TabIndex = 34;
            this.llSetImage.TabStop = true;
            this.llSetImage.Text = "Set Image";
            this.llSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetImage_LinkClicked);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonImage.Image = global::DVLD.Properties.Resources.Male_512;
            this.pbPersonImage.Location = new System.Drawing.Point(1059, 52);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(165, 155);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 33;
            this.pbPersonImage.TabStop = false;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(282, 273);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(635, 143);
            this.txtAddress.TabIndex = 32;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // pbAddress
            // 
            this.pbAddress.Image = global::DVLD.Properties.Resources.Address_32;
            this.pbAddress.Location = new System.Drawing.Point(243, 273);
            this.pbAddress.Name = "pbAddress";
            this.pbAddress.Size = new System.Drawing.Size(33, 31);
            this.pbAddress.TabIndex = 31;
            this.pbAddress.TabStop = false;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAddress.Location = new System.Drawing.Point(36, 264);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(116, 29);
            this.lblAddress.TabIndex = 30;
            this.lblAddress.Text = "Address:";
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(710, 222);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(121, 31);
            this.cbCountry.TabIndex = 29;
            // 
            // pbCountryIcon
            // 
            this.pbCountryIcon.Image = global::DVLD.Properties.Resources.Country_32;
            this.pbCountryIcon.Location = new System.Drawing.Point(671, 222);
            this.pbCountryIcon.Name = "pbCountryIcon";
            this.pbCountryIcon.Size = new System.Drawing.Size(33, 31);
            this.pbCountryIcon.TabIndex = 28;
            this.pbCountryIcon.TabStop = false;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCountry.Location = new System.Drawing.Point(556, 220);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(109, 29);
            this.lblCountry.TabIndex = 27;
            this.lblCountry.Text = "Country:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(279, 222);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(153, 30);
            this.txtEmail.TabIndex = 26;
            // 
            // PbEmail
            // 
            this.PbEmail.Image = global::DVLD.Properties.Resources.Email_32;
            this.PbEmail.Location = new System.Drawing.Point(243, 220);
            this.PbEmail.Name = "PbEmail";
            this.PbEmail.Size = new System.Drawing.Size(33, 31);
            this.PbEmail.TabIndex = 25;
            this.PbEmail.TabStop = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEmail.Location = new System.Drawing.Point(66, 220);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(86, 29);
            this.lblEmail.TabIndex = 24;
            this.lblEmail.Text = "Email:";
            // 
            // pbPhoneIcon
            // 
            this.pbPhoneIcon.Image = global::DVLD.Properties.Resources.Phone_32;
            this.pbPhoneIcon.Location = new System.Drawing.Point(671, 157);
            this.pbPhoneIcon.Name = "pbPhoneIcon";
            this.pbPhoneIcon.Size = new System.Drawing.Size(33, 31);
            this.pbPhoneIcon.TabIndex = 23;
            this.pbPhoneIcon.TabStop = false;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(710, 159);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(153, 30);
            this.txtPhone.TabIndex = 22;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPhone.Location = new System.Drawing.Point(556, 158);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(95, 29);
            this.lblPhone.TabIndex = 21;
            this.lblPhone.Text = "Phone:";
            // 
            // pbGendorWomen
            // 
            this.pbGendorWomen.Image = global::DVLD.Properties.Resources.Woman_32;
            this.pbGendorWomen.Location = new System.Drawing.Point(378, 161);
            this.pbGendorWomen.Name = "pbGendorWomen";
            this.pbGendorWomen.Size = new System.Drawing.Size(33, 31);
            this.pbGendorWomen.TabIndex = 20;
            this.pbGendorWomen.TabStop = false;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(417, 161);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(88, 27);
            this.rbFemale.TabIndex = 19;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(297, 159);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(70, 27);
            this.rbMale.TabIndex = 18;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // pbGendorMan
            // 
            this.pbGendorMan.Image = global::DVLD.Properties.Resources.Man_32;
            this.pbGendorMan.Location = new System.Drawing.Point(243, 159);
            this.pbGendorMan.Name = "pbGendorMan";
            this.pbGendorMan.Size = new System.Drawing.Size(33, 31);
            this.pbGendorMan.TabIndex = 17;
            this.pbGendorMan.TabStop = false;
            // 
            // lblGendor
            // 
            this.lblGendor.AutoSize = true;
            this.lblGendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGendor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGendor.Location = new System.Drawing.Point(38, 159);
            this.lblGendor.Name = "lblGendor";
            this.lblGendor.Size = new System.Drawing.Size(114, 29);
            this.lblGendor.TabIndex = 16;
            this.lblGendor.Text = "Gendor :";
            this.lblGendor.Click += new System.EventHandler(this.lblGendor_Click);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(710, 103);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(200, 30);
            this.dtpDateOfBirth.TabIndex = 15;
            // 
            // pbDateOfBirthIcon
            // 
            this.pbDateOfBirthIcon.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pbDateOfBirthIcon.Location = new System.Drawing.Point(674, 103);
            this.pbDateOfBirthIcon.Name = "pbDateOfBirthIcon";
            this.pbDateOfBirthIcon.Size = new System.Drawing.Size(30, 30);
            this.pbDateOfBirthIcon.TabIndex = 14;
            this.pbDateOfBirthIcon.TabStop = false;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDateOfBirth.Location = new System.Drawing.Point(514, 108);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(137, 25);
            this.lblDateOfBirth.TabIndex = 13;
            this.lblDateOfBirth.Text = "DateOfBirth :";
            // 
            // txtNatNo
            // 
            this.txtNatNo.Location = new System.Drawing.Point(282, 108);
            this.txtNatNo.Name = "txtNatNo";
            this.txtNatNo.Size = new System.Drawing.Size(153, 30);
            this.txtNatNo.TabIndex = 12;
            this.txtNatNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtNationalNo_Validating);
            // 
            // pbNationalNoIcon
            // 
            this.pbNationalNoIcon.Image = global::DVLD.Properties.Resources.Number_32;
            this.pbNationalNoIcon.Location = new System.Drawing.Point(243, 113);
            this.pbNationalNoIcon.Name = "pbNationalNoIcon";
            this.pbNationalNoIcon.Size = new System.Drawing.Size(33, 31);
            this.pbNationalNoIcon.TabIndex = 11;
            this.pbNationalNoIcon.TabStop = false;
            // 
            // lblNational
            // 
            this.lblNational.AutoSize = true;
            this.lblNational.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNational.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNational.Location = new System.Drawing.Point(16, 108);
            this.lblNational.Name = "lblNational";
            this.lblNational.Size = new System.Drawing.Size(137, 25);
            this.lblNational.TabIndex = 10;
            this.lblNational.Text = "National No :";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(828, 14);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(42, 23);
            this.lblLast.TabIndex = 9;
            this.lblLast.Text = "Last";
            // 
            // lblThird
            // 
            this.lblThird.AutoSize = true;
            this.lblThird.Location = new System.Drawing.Point(652, 13);
            this.lblThird.Name = "lblThird";
            this.lblThird.Size = new System.Drawing.Size(53, 23);
            this.lblThird.TabIndex = 8;
            this.lblThird.Text = "Third";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(479, 15);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(68, 23);
            this.lblSecond.TabIndex = 7;
            this.lblSecond.Text = "Second";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(312, 13);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(45, 23);
            this.lblFirst.TabIndex = 6;
            this.lblFirst.Text = "First";
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(790, 51);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(127, 30);
            this.txtLast.TabIndex = 5;
            this.txtLast.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // txtThird
            // 
            this.txtThird.Location = new System.Drawing.Point(623, 51);
            this.txtThird.Name = "txtThird";
            this.txtThird.Size = new System.Drawing.Size(127, 30);
            this.txtThird.TabIndex = 4;
            // 
            // txtSecond
            // 
            this.txtSecond.Location = new System.Drawing.Point(453, 51);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(127, 30);
            this.txtSecond.TabIndex = 3;
            this.txtSecond.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(282, 50);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(150, 30);
            this.txtFirst.TabIndex = 2;
            this.txtFirst.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // PicBName
            // 
            this.PicBName.Image = global::DVLD.Properties.Resources.Person_32;
            this.PicBName.Location = new System.Drawing.Point(243, 50);
            this.PicBName.Name = "PicBName";
            this.PicBName.Size = new System.Drawing.Size(33, 29);
            this.PicBName.TabIndex = 1;
            this.PicBName.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblName.Location = new System.Drawing.Point(56, 52);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(96, 29);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            this.openFileDialog1.Title = "Choose Profile Image";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblPersonIdTag
            // 
            this.lblPersonIdTag.AutoSize = true;
            this.lblPersonIdTag.BackColor = System.Drawing.Color.White;
            this.lblPersonIdTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonIdTag.ForeColor = System.Drawing.Color.Black;
            this.lblPersonIdTag.Location = new System.Drawing.Point(22, 99);
            this.lblPersonIdTag.Name = "lblPersonIdTag";
            this.lblPersonIdTag.Size = new System.Drawing.Size(174, 36);
            this.lblPersonIdTag.TabIndex = 4;
            this.lblPersonIdTag.Text = "Person ID :";
            // 
            // pbPersonIDIcon
            // 
            this.pbPersonIDIcon.Image = global::DVLD.Properties.Resources.Number_32;
            this.pbPersonIDIcon.Location = new System.Drawing.Point(215, 104);
            this.pbPersonIDIcon.Name = "pbPersonIDIcon";
            this.pbPersonIDIcon.Size = new System.Drawing.Size(33, 31);
            this.pbPersonIDIcon.TabIndex = 12;
            this.pbPersonIDIcon.TabStop = false;
            // 
            // frmAddUpdatePerson
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1371, 703);
            this.Controls.Add(this.pbPersonIDIcon);
            this.Controls.Add(this.lblPersonIdTag);
            this.Controls.Add(this.PnlPerson);
            this.Controls.Add(this.lblPersonId);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdatePerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdatePerson";
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            this.PnlPerson.ResumeLayout(false);
            this.PnlPerson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCountryIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoneIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGendorWomen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGendorMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDateOfBirthIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNationalNoIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonIDIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPersonId;
        private System.Windows.Forms.Panel PnlPerson;
        private System.Windows.Forms.PictureBox pbDateOfBirthIcon;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.TextBox txtNatNo;
        private System.Windows.Forms.PictureBox pbNationalNoIcon;
        private System.Windows.Forms.Label lblNational;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblThird;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.TextBox txtThird;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.PictureBox PicBName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGendor;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.PictureBox pbGendorMan;
        private System.Windows.Forms.PictureBox pbGendorWomen;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.PictureBox pbCountryIcon;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.PictureBox PbEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.PictureBox pbPhoneIcon;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.PictureBox pbAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pbPersonIDIcon;
        private System.Windows.Forms.Label lblPersonIdTag;
    }
}