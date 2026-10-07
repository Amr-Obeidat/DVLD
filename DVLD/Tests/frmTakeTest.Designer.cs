namespace DVLD.Tests
{
    partial class frmTakeTest
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
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotestag = new System.Windows.Forms.Label();
            this.pbNotes = new System.Windows.Forms.PictureBox();
            this.btnFail = new System.Windows.Forms.RadioButton();
            this.btnPass = new System.Windows.Forms.RadioButton();
            this.lblResulttag = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrScheduledTests1 = new DVLD.Tests.Controls.ctrScheduledTests();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.AutoSize = true;
            this.lblUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.Location = new System.Drawing.Point(302, 677);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(344, 29);
            this.lblUserMessage.TabIndex = 104;
            this.lblUserMessage.Text = "You can\'t Change the results";
            this.lblUserMessage.Visible = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(146, 707);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(435, 109);
            this.txtNotes.TabIndex = 103;
            // 
            // lblNotestag
            // 
            this.lblNotestag.AutoSize = true;
            this.lblNotestag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotestag.Location = new System.Drawing.Point(6, 726);
            this.lblNotestag.Name = "lblNotestag";
            this.lblNotestag.Size = new System.Drawing.Size(81, 25);
            this.lblNotestag.TabIndex = 101;
            this.lblNotestag.Text = "Notes :";
            // 
            // pbNotes
            // 
            this.pbNotes.Image = global::DVLD.Properties.Resources.Notes_32;
            this.pbNotes.Location = new System.Drawing.Point(96, 726);
            this.pbNotes.Name = "pbNotes";
            this.pbNotes.Size = new System.Drawing.Size(33, 31);
            this.pbNotes.TabIndex = 102;
            this.pbNotes.TabStop = false;
            // 
            // btnFail
            // 
            this.btnFail.AutoSize = true;
            this.btnFail.Location = new System.Drawing.Point(224, 680);
            this.btnFail.Name = "btnFail";
            this.btnFail.Size = new System.Drawing.Size(47, 21);
            this.btnFail.TabIndex = 100;
            this.btnFail.TabStop = true;
            this.btnFail.Text = "Fail";
            this.btnFail.UseVisualStyleBackColor = true;
            // 
            // btnPass
            // 
            this.btnPass.AutoSize = true;
            this.btnPass.Location = new System.Drawing.Point(162, 680);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(56, 21);
            this.btnPass.TabIndex = 99;
            this.btnPass.TabStop = true;
            this.btnPass.Text = "Pass";
            this.btnPass.UseVisualStyleBackColor = true;
            // 
            // lblResulttag
            // 
            this.lblResulttag.AutoSize = true;
            this.lblResulttag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResulttag.Location = new System.Drawing.Point(5, 680);
            this.lblResulttag.Name = "lblResulttag";
            this.lblResulttag.Size = new System.Drawing.Size(85, 25);
            this.lblResulttag.TabIndex = 97;
            this.lblResulttag.Text = "Result :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(96, 680);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 31);
            this.pictureBox3.TabIndex = 98;
            this.pictureBox3.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(491, 822);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 51);
            this.btnSave.TabIndex = 106;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(385, 822);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 51);
            this.btnClose.TabIndex = 107;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrScheduledTests1
            // 
            this.ctrScheduledTests1.Location = new System.Drawing.Point(10, 15);
            this.ctrScheduledTests1.Name = "ctrScheduledTests1";
            this.ctrScheduledTests1.Size = new System.Drawing.Size(587, 663);
            this.ctrScheduledTests1.TabIndex = 105;
            this.ctrScheduledTests1.TestTypeID = DVLD_Business.Tests.clsTestTypesDTO.enTestType.VisionTest;
            this.ctrScheduledTests1.Load += new System.EventHandler(this.ctrScheduledTests1_Load);
            // 
            // frmTakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(642, 940);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrScheduledTests1);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotestag);
            this.Controls.Add(this.pbNotes);
            this.Controls.Add(this.btnFail);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.lblResulttag);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTakeTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTakeTest";
            this.Load += new System.EventHandler(this.frmTakeTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserMessage;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotestag;
        private System.Windows.Forms.PictureBox pbNotes;
        private System.Windows.Forms.RadioButton btnFail;
        private System.Windows.Forms.RadioButton btnPass;
        private System.Windows.Forms.Label lblResulttag;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Controls.ctrScheduledTests ctrScheduledTests1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}