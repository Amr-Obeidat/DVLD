namespace DVLD.Tests
{
    partial class frmEditTestType
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.lblFeesTag = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitleTag = new System.Windows.Forms.Label();
            this.lblIdTag = new System.Windows.Forms.Label();
            this.lblEditTestType = new System.Windows.Forms.Label();
            this.pbDescription = new System.Windows.Forms.PictureBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescriptionTag = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(381, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 38);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(255, 398);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 38);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(128, 87);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(45, 25);
            this.lblID.TabIndex = 50;
            this.lblID.Text = "???";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox1.Location = new System.Drawing.Point(133, 334);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 31);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // pbTitle
            // 
            this.pbTitle.Image = global::DVLD.Properties.Resources.ApplicationTitle;
            this.pbTitle.Location = new System.Drawing.Point(128, 143);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(31, 31);
            this.pbTitle.TabIndex = 48;
            this.pbTitle.TabStop = false;
            // 
            // txtFees
            // 
            this.txtFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFees.Location = new System.Drawing.Point(165, 335);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(325, 27);
            this.txtFees.TabIndex = 47;
            this.txtFees.Validating += new System.ComponentModel.CancelEventHandler(this.txtFees_Validating);
            // 
            // lblFeesTag
            // 
            this.lblFeesTag.AutoSize = true;
            this.lblFeesTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeesTag.Location = new System.Drawing.Point(55, 337);
            this.lblFeesTag.Name = "lblFeesTag";
            this.lblFeesTag.Size = new System.Drawing.Size(67, 25);
            this.lblFeesTag.TabIndex = 46;
            this.lblFeesTag.Text = "Fees :";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(165, 144);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(325, 24);
            this.txtTitle.TabIndex = 45;
            // 
            // lblTitleTag
            // 
            this.lblTitleTag.AutoSize = true;
            this.lblTitleTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTag.Location = new System.Drawing.Point(62, 143);
            this.lblTitleTag.Name = "lblTitleTag";
            this.lblTitleTag.Size = new System.Drawing.Size(60, 25);
            this.lblTitleTag.TabIndex = 44;
            this.lblTitleTag.Text = "Title :";
            // 
            // lblIdTag
            // 
            this.lblIdTag.AutoSize = true;
            this.lblIdTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdTag.Location = new System.Drawing.Point(80, 87);
            this.lblIdTag.Name = "lblIdTag";
            this.lblIdTag.Size = new System.Drawing.Size(42, 25);
            this.lblIdTag.TabIndex = 43;
            this.lblIdTag.Text = "ID :";
            // 
            // lblEditTestType
            // 
            this.lblEditTestType.AutoSize = true;
            this.lblEditTestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditTestType.ForeColor = System.Drawing.Color.Red;
            this.lblEditTestType.Location = new System.Drawing.Point(173, 22);
            this.lblEditTestType.Name = "lblEditTestType";
            this.lblEditTestType.Size = new System.Drawing.Size(202, 32);
            this.lblEditTestType.TabIndex = 42;
            this.lblEditTestType.Text = "Edit TestType";
            // 
            // pbDescription
            // 
            this.pbDescription.Image = global::DVLD.Properties.Resources.ApplicationTitle;
            this.pbDescription.Location = new System.Drawing.Point(128, 208);
            this.pbDescription.Name = "pbDescription";
            this.pbDescription.Size = new System.Drawing.Size(31, 31);
            this.pbDescription.TabIndex = 55;
            this.pbDescription.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(165, 215);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(325, 114);
            this.txtDescription.TabIndex = 54;
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescription_Validating);
            // 
            // lblDescriptionTag
            // 
            this.lblDescriptionTag.AutoSize = true;
            this.lblDescriptionTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionTag.Location = new System.Drawing.Point(2, 215);
            this.lblDescriptionTag.Name = "lblDescriptionTag";
            this.lblDescriptionTag.Size = new System.Drawing.Size(120, 25);
            this.lblDescriptionTag.TabIndex = 53;
            this.lblDescriptionTag.Text = "Description :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmEditTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 448);
            this.Controls.Add(this.pbDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescriptionTag);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbTitle);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.lblFeesTag);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitleTag);
            this.Controls.Add(this.lblIdTag);
            this.Controls.Add(this.lblEditTestType);
            this.Name = "frmEditTestType";
            this.Text = "frmEditTestType";
            this.Load += new System.EventHandler(this.frmEditTestType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.Label lblFeesTag;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitleTag;
        private System.Windows.Forms.Label lblIdTag;
        private System.Windows.Forms.Label lblEditTestType;
        private System.Windows.Forms.PictureBox pbDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescriptionTag;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}