namespace DVLD.People
{
    partial class frmFindPerson
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
            this.lblFinPerson = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrPersonCardWithFiltercs1 = new DVLD.Controls.ctrPersonCardWithFiltercs();
            this.SuspendLayout();
            // 
            // lblFinPerson
            // 
            this.lblFinPerson.AutoSize = true;
            this.lblFinPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinPerson.ForeColor = System.Drawing.Color.Red;
            this.lblFinPerson.Location = new System.Drawing.Point(365, 17);
            this.lblFinPerson.Name = "lblFinPerson";
            this.lblFinPerson.Size = new System.Drawing.Size(246, 46);
            this.lblFinPerson.TabIndex = 1;
            this.lblFinPerson.Text = "Find Person";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(810, 544);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 44);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrPersonCardWithFiltercs1
            // 
            this.ctrPersonCardWithFiltercs1.EnableEditPerson = true;
            this.ctrPersonCardWithFiltercs1.FilterEnabled = true;
            this.ctrPersonCardWithFiltercs1.Location = new System.Drawing.Point(1, 66);
            this.ctrPersonCardWithFiltercs1.Name = "ctrPersonCardWithFiltercs1";
            this.ctrPersonCardWithFiltercs1.ShowAddPerson = true;
            this.ctrPersonCardWithFiltercs1.Size = new System.Drawing.Size(937, 472);
            this.ctrPersonCardWithFiltercs1.TabIndex = 0;
            // 
            // frmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 594);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblFinPerson);
            this.Controls.Add(this.ctrPersonCardWithFiltercs1);
            this.Name = "frmFindPerson";
            this.Text = "frmFindPerson";
            this.Load += new System.EventHandler(this.frmFindPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrPersonCardWithFiltercs ctrPersonCardWithFiltercs1;
        private System.Windows.Forms.Label lblFinPerson;
        private System.Windows.Forms.Button btnClose;
    }
}