using DVLD_Business.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmEditTestType : Form
    {


        private short _TestTypeId;    
        clsTestTypes _TestType = new clsTestTypes();    

        public frmEditTestType(short TestTypeId)
        {
            InitializeComponent();
            _TestTypeId = TestTypeId;
            txtTitle.ReadOnly = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestTypes.Find(_TestTypeId);  

            if(_TestType != null)
            {
                txtTitle.Text = _TestType.clsTestTypesDTO.TestTypeTitle;  
                txtDescription.Text = _TestType.clsTestTypesDTO.TestTypeDescription;
                txtFees.Text = _TestType.clsTestTypesDTO.TestTypeFees.ToString();   


            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {
               MessageBox.Show("correct the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }   

            _TestType.clsTestTypesDTO.TestTypeDescription = txtDescription.Text.Trim();
            _TestType.clsTestTypesDTO.TestTypeFees = decimal.Parse(txtFees.Text.Trim());

            bool IsSaved = _TestType.Save();

            if(IsSaved)
            {
                MessageBox.Show("Test Type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;    
                Close();    
            }
            else
            {
                MessageBox.Show($"Failed to update Test Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                e.Cancel = true;    
                errorProvider1.SetError(txtDescription, "Description is required.");   
            }
            else
            {
                e.Cancel = false;    
                errorProvider1.SetError(txtDescription, null);
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFees.Text))
            {
                e.Cancel = true;    
                errorProvider1.SetError(txtFees, "Fees is required.");   
            }
            else if(!decimal.TryParse(txtFees.Text, out decimal fees) || fees < 0)
            {
                e.Cancel = true;    
                errorProvider1.SetError(txtFees, "Fees must be a non-negative number.");   
            }
            else
            {
                e.Cancel = false;    
                errorProvider1.SetError(txtFees, null);
            }
        }
    }
}
