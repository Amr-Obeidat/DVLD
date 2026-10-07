namespace DVLD.FromTests.User_control_tests
{
    partial class Test_User_Control_With_Froms
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
            this.ctrPersonCardWithFiltercs1 = new DVLD.Controls.ctrPersonCardWithFiltercs();
            this.SuspendLayout();
            // 
            // ctrPersonCardWithFiltercs1
            // 
            this.ctrPersonCardWithFiltercs1.FilterEnabled = true;
            this.ctrPersonCardWithFiltercs1.Location = new System.Drawing.Point(23, 12);
            this.ctrPersonCardWithFiltercs1.Name = "ctrPersonCardWithFiltercs1";
            this.ctrPersonCardWithFiltercs1.ShowAddPerson = true;
            this.ctrPersonCardWithFiltercs1.Size = new System.Drawing.Size(1086, 480);
            this.ctrPersonCardWithFiltercs1.TabIndex = 0;
            // 
            // Test_User_Control_With_Froms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 523);
            this.Controls.Add(this.ctrPersonCardWithFiltercs1);
            this.Name = "Test_User_Control_With_Froms";
            this.Text = "Test_User_Control_With_Froms";
            this.Load += new System.EventHandler(this.Test_User_Control_With_Froms_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrPersonCardWithFiltercs ctrPersonCardWithFiltercs1;
    }
}