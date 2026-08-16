namespace DVLD.FormTests.User_control_tests
{
    partial class frmTestUserControlCardcs
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
            this.ctrUserCard1 = new DVLD.Users.UserControls.ctrUserCard();
            this.SuspendLayout();
            // 
            // ctrUserCard1
            // 
            this.ctrUserCard1.Location = new System.Drawing.Point(12, 12);
            this.ctrUserCard1.Name = "ctrUserCard1";
            this.ctrUserCard1.Size = new System.Drawing.Size(882, 426);
            this.ctrUserCard1.TabIndex = 0;
           // this.ctrUserCard1.UserId = 0;
            // 
            // frmTestUserControlCardcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.ctrUserCard1);
            this.Name = "frmTestUserControlCardcs";
            this.Text = "frmTestUserControlCardcs";
            this.Load += new System.EventHandler(this.frmTestUserControlCardcs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Users.UserControls.ctrUserCard ctrUserCard1;
    }
}