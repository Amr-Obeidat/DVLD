namespace DVLD.Tests
{
    partial class frmListTestAppointments
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
            this.dgvLicenseTestAppointments = new System.Windows.Forms.DataGridView();
            this.lblAppointmentsTag = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddAppointmnet = new System.Windows.Forms.Button();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.lblNumRecordsTag = new System.Windows.Forms.Label();
            this.cmsTakeTest = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrLocalDrivingLicenseApplication1 = new DVLD.Applications.Applications_Controls.ctrLocalDrivingLicenseApplication();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseTestAppointments)).BeginInit();
            this.cmsTakeTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLicenseTestAppointments
            // 
            this.dgvLicenseTestAppointments.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLicenseTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicenseTestAppointments.ContextMenuStrip = this.cmsTakeTest;
            this.dgvLicenseTestAppointments.Location = new System.Drawing.Point(12, 552);
            this.dgvLicenseTestAppointments.Name = "dgvLicenseTestAppointments";
            this.dgvLicenseTestAppointments.RowHeadersWidth = 51;
            this.dgvLicenseTestAppointments.RowTemplate.Height = 26;
            this.dgvLicenseTestAppointments.Size = new System.Drawing.Size(824, 234);
            this.dgvLicenseTestAppointments.TabIndex = 69;
            // 
            // lblAppointmentsTag
            // 
            this.lblAppointmentsTag.AutoSize = true;
            this.lblAppointmentsTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsTag.Location = new System.Drawing.Point(16, 524);
            this.lblAppointmentsTag.Name = "lblAppointmentsTag";
            this.lblAppointmentsTag.Size = new System.Drawing.Size(157, 25);
            this.lblAppointmentsTag.TabIndex = 70;
            this.lblAppointmentsTag.Text = "Appointments :";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(842, 735);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 51);
            this.btnClose.TabIndex = 71;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddAppointmnet
            // 
            this.btnAddAppointmnet.Image = global::DVLD.Properties.Resources.AddAppointment_32;
            this.btnAddAppointmnet.Location = new System.Drawing.Point(851, 552);
            this.btnAddAppointmnet.Name = "btnAddAppointmnet";
            this.btnAddAppointmnet.Size = new System.Drawing.Size(48, 40);
            this.btnAddAppointmnet.TabIndex = 72;
            this.btnAddAppointmnet.UseVisualStyleBackColor = true;
            this.btnAddAppointmnet.Click += new System.EventHandler(this.btnAddAppointmnet_Click);
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(131, 800);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(36, 25);
            this.lblNumOfRecords.TabIndex = 74;
            this.lblNumOfRecords.Text = "??";
            // 
            // lblNumRecordsTag
            // 
            this.lblNumRecordsTag.AutoSize = true;
            this.lblNumRecordsTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecordsTag.Location = new System.Drawing.Point(16, 800);
            this.lblNumRecordsTag.Name = "lblNumRecordsTag";
            this.lblNumRecordsTag.Size = new System.Drawing.Size(109, 25);
            this.lblNumRecordsTag.TabIndex = 73;
            this.lblNumRecordsTag.Text = "# Records";
            // 
            // cmsTakeTest
            // 
            this.cmsTakeTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsTakeTest.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTakeTest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.takeTestToolStripMenuItem,
            this.editToolStripMenuItem});
            this.cmsTakeTest.Name = "cmsTakeTest";
            this.cmsTakeTest.Size = new System.Drawing.Size(167, 56);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.TestType_32;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // ctrLocalDrivingLicenseApplication1
            // 
            this.ctrLocalDrivingLicenseApplication1.Location = new System.Drawing.Point(3, 3);
            this.ctrLocalDrivingLicenseApplication1.Name = "ctrLocalDrivingLicenseApplication1";
            this.ctrLocalDrivingLicenseApplication1.Size = new System.Drawing.Size(949, 518);
            this.ctrLocalDrivingLicenseApplication1.TabIndex = 0;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(985, 836);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.lblNumRecordsTag);
            this.Controls.Add(this.btnAddAppointmnet);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAppointmentsTag);
            this.Controls.Add(this.dgvLicenseTestAppointments);
            this.Controls.Add(this.ctrLocalDrivingLicenseApplication1);
            this.Name = "frmListTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListTestAppointmentscs";
            this.Load += new System.EventHandler(this.frmListTestAppointmentscs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseTestAppointments)).EndInit();
            this.cmsTakeTest.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Applications_Controls.ctrLocalDrivingLicenseApplication ctrLocalDrivingLicenseApplication1;
        private System.Windows.Forms.DataGridView dgvLicenseTestAppointments;
        private System.Windows.Forms.Label lblAppointmentsTag;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddAppointmnet;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.Label lblNumRecordsTag;
        private System.Windows.Forms.ContextMenuStrip cmsTakeTest;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}