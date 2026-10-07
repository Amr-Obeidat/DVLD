using DVLD_Business.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmUpdateApplicationType : Form
    {

        private int _applicationID;
        private clsApplicationTypes _applicationType;
        public frmUpdateApplicationType(int ApplicationID)
        {
            InitializeComponent();
            _applicationID = ApplicationID;
            txtTitle.ReadOnly = true;

        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {


            _applicationType = clsApplicationTypes.Find(_applicationID);
            if (_applicationType != null)
            {

                lblID.Text = _applicationType.DTO.ApplicationTypeID.ToString();
                txtTitle.Text = _applicationType.DTO.ApplicationTypeTitle;
                txtFees.Text = _applicationType.DTO.ApplicationFees.ToString();




            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {
                MessageBox.Show("correct the validation errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_applicationType != null)
            {
                decimal newFees;
                if (decimal.TryParse(txtFees.Text, out newFees))
                {
                    _applicationType.DTO.ApplicationFees = newFees;
                    bool isUpdated = _applicationType.Save();
                    if (isUpdated)
                    {
                        MessageBox.Show("Application type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update application type. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid fee amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFees.Text) || !decimal.TryParse(txtFees.Text, out _))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Please enter a valid fee amount.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, null);
            }
        }
    }
}
