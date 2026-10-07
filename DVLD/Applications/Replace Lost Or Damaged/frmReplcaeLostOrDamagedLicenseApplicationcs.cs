
using DVLD.GlobalClasses;
using DVLD.Licenses;
using DVLD_Business.Applications;
using DVLD_Business.Licenses;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.Replace_Lost_Or_Damaged
{
    public partial class frmReplcaeLostOrDamagedLicenseApplicationcs : Form
    {
        private int _NewLicenseId = -1;

        public frmReplcaeLostOrDamagedLicenseApplicationcs()
        {
            InitializeComponent();
        }

        private clsLicenseDTO.enIssueReason _GetIssueReason()
        {
            return rdbtnDamaged.Checked
                ? clsLicenseDTO.enIssueReason.ReplacementForDamaged
                : clsLicenseDTO.enIssueReason.ReplacementForLost;
        }

        private clsApplicationDTO.enApplicationType _GetApplicationType()
        {
            return rdbtnDamaged.Checked
                ? clsApplicationDTO.enApplicationType.ReplaceDamagedDrivingLicense
                : clsApplicationDTO.enApplicationType.ReplaceLostDrivingLicense;
        }

        private void _UpdateApplicationFees()
        {
            
            decimal applicationFees = clsApplicationTypes .Find((int)_GetApplicationType()).DTO.ApplicationFees;

            lblApplicationFees.Text = applicationFees.ToString("0.00");
        }

        private void frmReplcaeLostOrDamagedLicenseApplicationcs_Load(object sender, EventArgs e)
        {
            
            ctrDriverLicenseInfoWithFilterscs1.OnLicenseSelected += ctrDriverLicenseInfoWithFilterscs1_OnLicenseSelected;

            
            rdbtnDamaged.Checked = true;
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserDTO.UserName;

            _UpdateApplicationFees();

           
            btnIssueReplacment.Enabled = false;
            linklblShowNewLicenseInfo.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;

            ctrDriverLicenseInfoWithFilterscs1.txtLicenseIdFocus();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbltitle.Text = "Replacement for Damaged License";
            this.Text = lbltitle.Text;
            _UpdateApplicationFees();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbltitle.Text = "Replacement for Lost License";
            this.Text = lbltitle.Text;
            _UpdateApplicationFees();
        }

        private void ctrDriverLicenseInfoWithFilterscs1_OnLicenseSelected(int licenseId)
        {
            int selectedLicenseId = licenseId;

            if (selectedLicenseId == -1)
            {
                btnIssueReplacment.Enabled = false;
                linklblShowLicenseHistory.Enabled = false;
             
                return;
            }

            clsLicense selectedLicense = ctrDriverLicenseInfoWithFilterscs1.License;

          
            linklblShowLicenseHistory.Enabled = true;
            lblOldLicenseId.Text = selectedLicense.LicenseDTO.LicenseID.ToString();

            if (!selectedLicense.LicenseDTO.IsActive)
            {
                MessageBox.Show("Selected License is not active. You can only replace an active license.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacment.Enabled = false;
                return;
            }

           
            if (selectedLicense.IsDetained)
            {
                MessageBox.Show("Selected License is detained. You must release it before requesting a replacement.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacment.Enabled = false;
                return;
            }

           
            if (selectedLicense.LicenseDTO.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("Selected License is expired. You must renew the license rather than replace it.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacment.Enabled = false;
                return;
            }

            btnIssueReplacment.Enabled = true;
        }

        private void btnIssueReplacment_Click(object sender, EventArgs e)
        {
            string replacementType = rdbtnDamaged.Checked ? "Damaged" : "Lost";

            if (MessageBox.Show($"Are you sure you want to issue a replacement for this {replacementType} license?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            btnIssueReplacment.Enabled = false;

           
            clsLicense newLicense = ctrDriverLicenseInfoWithFilterscs1.License.Replace( _GetIssueReason(),
                clsGlobal.CurrentUser.UserDTO.UserID
            );

            if (newLicense == null)
            {
                MessageBox.Show("Failed to replace the driving license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacment.Enabled = true;
                return;
            }

          
            lblRLApplicationID.Text = newLicense.LicenseDTO.ApplicationID.ToString();
            _NewLicenseId = newLicense.LicenseDTO.LicenseID;
            lblReplacedLicenseId.Text = _NewLicenseId.ToString();

            MessageBox.Show($"License Replaced Successfully with License ID = {_NewLicenseId}",
                "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

         
            ctrDriverLicenseInfoWithFilterscs1.FilterEnabled = false;
            gbReplacmentReason.Enabled = false;
            linklblShowNewLicenseInfo.Enabled = true;
        }

        private void linklblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseId);
            frm.ShowDialog();
        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personId = ctrDriverLicenseInfoWithFilterscs1.License.DriverInfo.PersonInfo.PersonDTO.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(personId);
           frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbtnDamaged_Validated(object sender, EventArgs e)
        {
            _UpdateApplicationFees();
        }

        private void rdbtnLostLicense_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rdbtnDamaged_CheckedChanged(object sender, EventArgs e)
        {
            _UpdateApplicationFees();
        }

        private void rdbtnLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _UpdateApplicationFees();
        }
    }
}

