namespace DVLD.Applications
{
    partial class frmListApplicationTypes
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
            this.pbManageAppTypes = new System.Windows.Forms.PictureBox();
            this.dgvAppTypes = new System.Windows.Forms.DataGridView();
            this.cmsApplicationTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.lblNumRecordsTag = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageAppTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppTypes)).BeginInit();
            this.cmsApplicationTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblManageApplicationTypes
            // 
            this.lblManageApplicationTypes.AutoSize = true;
            this.lblManageApplicationTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageApplicationTypes.ForeColor = System.Drawing.Color.Red;
            this.lblManageApplicationTypes.Location = new System.Drawing.Point(290, 219);
            this.lblManageApplicationTypes.Name = "lblManageApplicationTypes";
            this.lblManageApplicationTypes.Size = new System.Drawing.Size(374, 32);
            this.lblManageApplicationTypes.TabIndex = 0;
            this.lblManageApplicationTypes.Text = "Manage Application Types";
            // 
            // pbManageAppTypes
            // 
            this.pbManageAppTypes.Image = global::DVLD.Properties.Resources.Application_Types_512;
            this.pbManageAppTypes.Location = new System.Drawing.Point(402, 52);
            this.pbManageAppTypes.Name = "pbManageAppTypes";
            this.pbManageAppTypes.Size = new System.Drawing.Size(161, 164);
            this.pbManageAppTypes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbManageAppTypes.TabIndex = 1;
            this.pbManageAppTypes.TabStop = false;
            // 
            // dgvAppTypes
            // 
            this.dgvAppTypes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAppTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppTypes.ContextMenuStrip = this.cmsApplicationTypes;
            this.dgvAppTypes.Location = new System.Drawing.Point(0, 284);
            this.dgvAppTypes.Name = "dgvAppTypes";
            this.dgvAppTypes.RowHeadersWidth = 51;
            this.dgvAppTypes.RowTemplate.Height = 26;
            this.dgvAppTypes.Size = new System.Drawing.Size(1010, 328);
            this.dgvAppTypes.TabIndex = 2;
            this.dgvAppTypes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppTypes_CellContentClick);
            // 
            // cmsApplicationTypes
            // 
            this.cmsApplicationTypes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplicationTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationTypeToolStripMenuItem});
            this.cmsApplicationTypes.Name = "cmsApplicationTypes";
            this.cmsApplicationTypes.Size = new System.Drawing.Size(225, 58);
            // 
            // editApplicationTypeToolStripMenuItem
            // 
            this.editApplicationTypeToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_32;
            this.editApplicationTypeToolStripMenuItem.Name = "editApplicationTypeToolStripMenuItem";
            this.editApplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.editApplicationTypeToolStripMenuItem.Text = "Edit Application Type";
            this.editApplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.editApplicationTypeToolStripMenuItem_Click);
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(127, 633);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(36, 25);
            this.lblNumOfRecords.TabIndex = 9;
            this.lblNumOfRecords.Text = "??";
            // 
            // lblNumRecordsTag
            // 
            this.lblNumRecordsTag.AutoSize = true;
            this.lblNumRecordsTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecordsTag.Location = new System.Drawing.Point(12, 633);
            this.lblNumRecordsTag.Name = "lblNumRecordsTag";
            this.lblNumRecordsTag.Size = new System.Drawing.Size(109, 25);
            this.lblNumRecordsTag.TabIndex = 8;
            this.lblNumRecordsTag.Text = "# Records";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(890, 618);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 53);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmListApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 667);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.lblNumRecordsTag);
            this.Controls.Add(this.dgvAppTypes);
            this.Controls.Add(this.pbManageAppTypes);
            this.Controls.Add(this.lblManageApplicationTypes);
            this.Name = "frmListApplicationTypes";
            this.Text = "frmApplicationTypes";
            this.Load += new System.EventHandler(this.frmApplicationTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbManageAppTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppTypes)).EndInit();
            this.cmsApplicationTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblManageApplicationTypes;
        private System.Windows.Forms.PictureBox pbManageAppTypes;
        private System.Windows.Forms.DataGridView dgvAppTypes;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.Label lblNumRecordsTag;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsApplicationTypes;
        private System.Windows.Forms.ToolStripMenuItem editApplicationTypeToolStripMenuItem;
    }
}