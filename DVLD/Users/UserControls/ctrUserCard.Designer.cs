namespace DVLD.Users.UserControls
{
    partial class ctrUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbUserctrl = new System.Windows.Forms.GroupBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblIsActiveTag = new System.Windows.Forms.Label();
            this.lblUserNameTag = new System.Windows.Forms.Label();
            this.lblUserIdTag = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new DVLD.Controls.ctrlPersonCard();
            this.gbUserctrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUserctrl
            // 
            this.gbUserctrl.Controls.Add(this.lblIsActive);
            this.gbUserctrl.Controls.Add(this.lblUserName);
            this.gbUserctrl.Controls.Add(this.lblUserId);
            this.gbUserctrl.Controls.Add(this.lblIsActiveTag);
            this.gbUserctrl.Controls.Add(this.lblUserNameTag);
            this.gbUserctrl.Controls.Add(this.lblUserIdTag);
            this.gbUserctrl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUserctrl.Location = new System.Drawing.Point(10, 328);
            this.gbUserctrl.Name = "gbUserctrl";
            this.gbUserctrl.Size = new System.Drawing.Size(872, 100);
            this.gbUserctrl.TabIndex = 1;
            this.gbUserctrl.TabStop = false;
            this.gbUserctrl.Text = "Login Information";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActive.Location = new System.Drawing.Point(689, 50);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(43, 24);
            this.lblIsActive.TabIndex = 19;
            this.lblIsActive.Text = "???";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(434, 49);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(43, 24);
            this.lblUserName.TabIndex = 18;
            this.lblUserName.Text = "???";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.Location = new System.Drawing.Point(147, 49);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(43, 24);
            this.lblUserId.TabIndex = 17;
            this.lblUserId.Text = "???";
            // 
            // lblIsActiveTag
            // 
            this.lblIsActiveTag.AutoSize = true;
            this.lblIsActiveTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActiveTag.Location = new System.Drawing.Point(588, 49);
            this.lblIsActiveTag.Name = "lblIsActiveTag";
            this.lblIsActiveTag.Size = new System.Drawing.Size(108, 25);
            this.lblIsActiveTag.TabIndex = 3;
            this.lblIsActiveTag.Text = "Is Active :";
            // 
            // lblUserNameTag
            // 
            this.lblUserNameTag.AutoSize = true;
            this.lblUserNameTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameTag.Location = new System.Drawing.Point(296, 49);
            this.lblUserNameTag.Name = "lblUserNameTag";
            this.lblUserNameTag.Size = new System.Drawing.Size(132, 25);
            this.lblUserNameTag.TabIndex = 2;
            this.lblUserNameTag.Text = "User Name :";
            // 
            // lblUserIdTag
            // 
            this.lblUserIdTag.AutoSize = true;
            this.lblUserIdTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIdTag.Location = new System.Drawing.Point(53, 49);
            this.lblUserIdTag.Name = "lblUserIdTag";
            this.lblUserIdTag.Size = new System.Drawing.Size(97, 25);
            this.lblUserIdTag.TabIndex = 1;
            this.lblUserIdTag.Text = "User ID :";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.EnableEditPersonLink = true;
            this.ctrlPersonCard1.EnableEditPersonLinkVisibility = true;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(7, 3);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(872, 319);
            this.ctrlPersonCard1.TabIndex = 0;
            this.ctrlPersonCard1.Load += new System.EventHandler(this.ctrlPersonCard1_Load);
            // 
            // ctrUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbUserctrl);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrUserCard";
            this.Size = new System.Drawing.Size(882, 434);
            this.gbUserctrl.ResumeLayout(false);
            this.gbUserctrl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox gbUserctrl;
        private System.Windows.Forms.Label lblUserIdTag;
        private System.Windows.Forms.Label lblIsActiveTag;
        private System.Windows.Forms.Label lblUserNameTag;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserId;
    }
}
