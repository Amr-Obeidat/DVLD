using DVLD_Business.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonId);
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 1, Update = 0 }
        enMode _Mode = enMode.AddNew;


        private int _PersonId = -1;
        private clsPerson _Person;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
         
        }

        public frmAddUpdatePerson(int PersonId)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonId = PersonId;
            btnSave.CausesValidation = false;
        }

        private void _FillCountriesInComboBox()
        {

            DataTable DtCountries = clsCountry.GetAllCountries();
            cbCountry.Items.Clear();
            foreach (DataRow row in DtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);


            }
        }
        private void _ResetDeafultValues()
        {
            _FillCountriesInComboBox();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                this.Text = "Add / Edit Person Info.";
                lblPersonId.Text = "N/A";
                _Person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
                this.Text = "Update Person Info.";
            }
            txtFirst.Text = string.Empty;
            txtSecond.Text = string.Empty;
            txtThird.Text = string.Empty;
            txtLast.Text = string.Empty;
            txtNatNo.Text = string.Empty;
            rbMale.Checked = true;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;


            if (cbCountry.Items.Count > 0)
            {

                cbCountry.SelectedIndex = cbCountry.FindString("Jordan");

                if (cbCountry.SelectedIndex == -1)
                {
                    cbCountry.SelectedIndex = 0;
                }

            }
            pbPersonImage.Image = Properties.Resources.Male_512;
            llRemoveImage.Visible = false;
        }


        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonId);

            if (_Person == null)
            {
                MessageBox.Show($"No person found with ID [{_PersonId}]", "Person Not Found",
             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblPersonId.Text = _Person.PersonDTO.PersonID.ToString();
            txtFirst.Text = _Person.PersonDTO.FirstName;
            txtSecond.Text = _Person.PersonDTO.SecondName;
            txtThird.Text = _Person.PersonDTO.ThirdName;
            txtLast.Text = _Person.PersonDTO.LastName;
            txtNatNo.Text = _Person.PersonDTO.NationalNo;
            dtpDateOfBirth.Value = _Person.PersonDTO.DateOfBirth;

            if (_Person.PersonDTO.Gender == 0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }
            txtPhone.Text = _Person.PersonDTO.Phone;
            txtEmail.Text = _Person.PersonDTO.Email;
            txtAddress.Text = _Person.PersonDTO.Address;



            clsCountry country = clsCountry.Find(_Person.PersonDTO.NationalityCountryID);
            if (country != null)
            {
                cbCountry.SelectedIndex = cbCountry.FindString(country.DTO.CountryName);


            }

            if (!string.IsNullOrEmpty(_Person.PersonDTO.ImagePath) && File.Exists(_Person.PersonDTO.ImagePath))
            {
                pbPersonImage.ImageLocation = _Person.PersonDTO.ImagePath;
                llRemoveImage.Visible = true;
            }
            else
            {

            }

        }


        private void _SetDefaultAvatar()
        {

            if (rbFemale.Checked)
            {
                pbPersonImage.Image = Properties.Resources.Female_512;
            }
            else
            {
                pbPersonImage.Image = Properties.Resources.Male_512;
            }
            llRemoveImage.Visible = false;

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                _SetDefaultAvatar();
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                _SetDefaultAvatar();
            }
        }
        private void lblGendor_Click(object sender, EventArgs e)
        {

        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDeafultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }

        }
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string SelectedFile = openFileDialog1.FileName;
                pbPersonImage.Load(SelectedFile);
                llRemoveImage.Visible = true;
            }
        }
        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            _SetDefaultAvatar();
        }

        private void ValidateEmptyTextBox(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (string.IsNullOrEmpty(txt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txt,null);
            }
        }


        private void txtNationalNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNatNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNatNo, "National number cannot be Blank !");
                return;

            }
            if (txtNatNo.Text.Trim() != _Person.PersonDTO.NationalNo && clsPerson.IsPersonExists(txtNatNo.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtNatNo, "National Number is already assigned to another person!");

            }
            else
            {
                errorProvider1.SetError(txtNatNo, null);

            }

        }


        private string _GetControlFriendlyName(Control control)
        {
           
            if (control.Tag != null && !string.IsNullOrWhiteSpace(control.Tag.ToString()))
            {
                return control.Tag.ToString();
            }

            
            switch (control.Name)
            {
                case "txtFirst": return "First Name";
                case "txtSecond": return "Second Name";
                case "txtThird": return "Third Name";
                case "txtLast": return "Last Name";
                case "txtNatNo": return "National No";
                case "txtPhone": return "Phone";
                case "txtEmail": return "Email";
                case "txtAddress": return "Address";
                case "cbCountry": return "Country";
                default: return control.Name; 
            }
        }

        private string _GetValidationErrors(Control parentControl)
        {
            StringBuilder sbErrors = new StringBuilder();

            foreach (Control control in parentControl.Controls)
            {
                string errorMsg = errorProvider1.GetError(control);
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    string fieldName = _GetControlFriendlyName(control);
                    sbErrors.AppendLine($"• {fieldName}: {errorMsg}");
                }

                if (control.HasChildren)
                {
                    string nestedErrors = _GetValidationErrors(control);
                    if (!string.IsNullOrEmpty(nestedErrors))
                    {
                        sbErrors.Append(nestedErrors);
                    }
                }
            }

            return sbErrors.ToString();
        }

        private bool _HandlePersonImage()
        {

            if (_Person.PersonDTO.ImagePath == pbPersonImage.ImageLocation)
                return true;

            // Case 2: User had an existing custom image and either deleted or replaced it
            if (!string.IsNullOrEmpty(_Person.PersonDTO.ImagePath) && File.Exists(_Person.PersonDTO.ImagePath))
            {
                try
                {
                    File.Delete(_Person.PersonDTO.ImagePath);
                }
                catch
                {
                    // Handle file lock edge cases 
                }
            }


            if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                string destinationFolder = @"C:\DVLD-People-Images\";

                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                string fileExtension = Path.GetExtension(pbPersonImage.ImageLocation);
                string newFileName = Guid.NewGuid().ToString() + fileExtension;
                string destinationPath = Path.Combine(destinationFolder, newFileName);

                try
                {
                    File.Copy(pbPersonImage.ImageLocation, destinationPath, true);
                    _Person.PersonDTO.ImagePath = destinationPath;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not save profile image: {ex.Message}", "Image Save Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {

                _Person.PersonDTO.ImagePath = string.Empty;
                return true;
            }
        }

        private void btn_SaveClick(object sender, System.EventArgs e)
        {
         
            if (!this.ValidateChildren())
            {
                string validationErrors = _GetValidationErrors(this);

                if (string.IsNullOrEmpty(validationErrors))
                {
                    validationErrors = "Some fields are invalid! Please check the form.";
                }

                MessageBox.Show(
                    validationErrors,
                    "Validation Errors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (!_HandlePersonImage())
            {
                return;
            }

            clsCountry country = clsCountry.Find(cbCountry.Text);


            _Person.PersonDTO.FirstName = txtFirst.Text.Trim();
            _Person.PersonDTO.SecondName = txtSecond.Text.Trim();
            _Person.PersonDTO.ThirdName = txtThird.Text.Trim();
            _Person.PersonDTO.LastName = txtLast.Text.Trim();
            _Person.PersonDTO.NationalNo = txtNatNo.Text.Trim();
            _Person.PersonDTO.DateOfBirth = dtpDateOfBirth.Value;
            _Person.PersonDTO.Gender = rbMale.Checked ? (byte)0 : (byte)1;
            _Person.PersonDTO.Phone = txtPhone.Text.Trim();
            _Person.PersonDTO.Email = txtEmail.Text.Trim();
            _Person.PersonDTO.Address = txtAddress.Text.Trim();
            _Person.PersonDTO.NationalityCountryID = country.DTO.CountryID;


            if (_Person.Save())
            {
                lblPersonId.Text = _Person.PersonDTO.PersonID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult= DialogResult.OK;
                DataBack?.Invoke(this, _Person.PersonDTO.PersonID);

            }
            else
            {
                MessageBox.Show($"Error: {_Person.PersonDTO.LastValidationError}", "Save Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btn_Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}