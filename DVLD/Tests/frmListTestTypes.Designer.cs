namespace DVLD.Tests
{
    partial class frmListTestTypes
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
            this.lblManageApplicationTypes = new System.Windows.Forms.Label();
            this.dgvTestTypes = new System.Windows.Forms.DataGridView();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.lblNumRecordsTag = new System.Windows.Forms.Label();
            this.cmsManageTestTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.pbManageTests = new System.Windows.Forms.PictureBox();
            this.editTestTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).BeginInit();
            this.cmsManageTestTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageTests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblManageApplicationTypes
            // 
            this.lblManageApplicationTypes.AutoSize = true;
            this.lblManageApplicationTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageApplicationTypes.ForeColor = System.Drawing.Color.Red;
            this.lblManageApplicationTypes.Location = new System.Drawing.Point(314, 161);
            this.lblManageApplicationTypes.Name = "lblManageApplicationTypes";
            this.lblManageApplicationTypes.Size = new System.Drawing.Size(244, 29);
            this.lblManageApplicationTypes.TabIndex = 1;
            this.lblManageApplicationTypes.Text = "Manage Test Types";
            // 
            // dgvTestTypes
            // 
            this.dgvTestTypes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestTypes.ContextMenuStrip = this.cmsManageTestTypes;
            this.dgvTestTypes.Location = new System.Drawing.Point(2, 217);
            this.dgvTestTypes.Name = "dgvTestTypes";
            this.dgvTestTypes.RowHeadersWidth = 51;
            this.dgvTestTypes.RowTemplate.Height = 26;
            this.dgvTestTypes.Size = new System.Drawing.Size(927, 309);
            this.dgvTestTypes.TabIndex = 3;
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(127, 539);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(36, 25);
            this.lblNumOfRecords.TabIndex = 11;
            this.lblNumOfRecords.Text = "??";
            // 
            // lblNumRecordsTag
            // 
            this.lblNumRecordsTag.AutoSize = true;
            this.lblNumRecordsTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecordsTag.Location = new System.Drawing.Point(12, 539);
            this.lblNumRecordsTag.Name = "lblNumRecordsTag";
            this.lblNumRecordsTag.Size = new System.Drawing.Size(109, 25);
            this.lblNumRecordsTag.TabIndex = 10;
            this.lblNumRecordsTag.Text = "# Records";
            // 
            // cmsManageTestTypes
            // 
            this.cmsManageTestTypes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageTestTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestTypeToolStripMenuItem});
            this.cmsManageTestTypes.Name = "cmsManageTestTypes";
            this.cmsManageTestTypes.Size = new System.Drawing.Size(174, 30);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(809, 532);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 44);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbManageTests
            // 
            this.pbManageTests.Image = global::DVLD.Properties.Resources.TestType_512;
            this.pbManageTests.Location = new System.Drawing.Point(362, 22);
            this.pbManageTests.Name = "pbManageTests";
            this.pbManageTests.Size = new System.Drawing.Size(151, 127);
            this.pbManageTests.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbManageTests.TabIndex = 2;
            this.pbManageTests.TabStop = false;
            // 
            // editTestTypeToolStripMenuItem
            // 
            this.editTestTypeToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_32;
            this.editTestTypeToolStripMenuItem.Name = "editTestTypeToolStripMenuItem";
            this.editTestTypeToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.editTestTypeToolStripMenuItem.Text = "Edit Test Type";
            this.editTestTypeToolStripMenuItem.Click += new System.EventHandler(this.editTestTypeToolStripMenuItem_Click);
            // 
            // frmListTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 573);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.lblNumRecordsTag);
            this.Controls.Add(this.dgvTestTypes);
            this.Controls.Add(this.pbManageTests);
            this.Controls.Add(this.lblManageApplicationTypes);
            this.Name = "frmListTestTypes";
            this.Text = "frmListTestTypes";
            this.Load += new System.EventHandler(this.frmListTestTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).EndInit();
            this.cmsManageTestTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbManageTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblManageApplicationTypes;
        private System.Windows.Forms.PictureBox pbManageTests;
        private System.Windows.Forms.DataGridView dgvTestTypes;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.Label lblNumRecordsTag;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem editTestTypeToolStripMenuItem;
    }
}