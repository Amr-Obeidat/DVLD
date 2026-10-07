namespace DVLD.Tests
{
    partial class frmScheduleTests
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrScheduleTests1 = new DVLD.Tests.Controls.ctrScheduleTests();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(340, 776);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 60);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrScheduleTests1
            // 
            this.ctrScheduleTests1.Location = new System.Drawing.Point(-10, 12);
            this.ctrScheduleTests1.Name = "ctrScheduleTests1";
            this.ctrScheduleTests1.Size = new System.Drawing.Size(655, 824);
            this.ctrScheduleTests1.TabIndex = 0;
            this.ctrScheduleTests1.TestTypeID = DVLD_Business.Tests.clsTestTypesDTO.enTestType.VisionTest;
            this.ctrScheduleTests1.Load += new System.EventHandler(this.ctrScheduleTests1_Load);
            // 
            // frmScheduleTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(657, 928);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrScheduleTests1);
            this.Name = "frmScheduleTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScheduleTests";
            this.Load += new System.EventHandler(this.frmScheduleTests_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrScheduleTests ctrScheduleTests1;
        private System.Windows.Forms.Button btnClose;
    }
}