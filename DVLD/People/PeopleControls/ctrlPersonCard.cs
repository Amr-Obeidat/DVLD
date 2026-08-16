using DVLD.People;
using DVLD_Business.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrlPersonCard : UserControl
    {



        int _PersonId = -1;
        clsPerson _Person;


        public int PersonId
        {
            get { return _PersonId; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }

        }
        private bool _EnableEditPersonLink = true;

        public bool EnableEditPersonLink
        {
            get => _EnableEditPersonLink;
            set
            {
                _EnableEditPersonLink = value;
                llEditPersonInfo.Enabled = _EnableEditPersonLink;
            }
        }
        public bool EnableEditPersonLinkVisibility
        {
            get => llEditPersonInfo.Visible;
            set => llEditPersonInfo.Visible = value;
        }

        public class ctrPersonEventArgs : EventArgs
        {

            public int PersonId { get; }

            public ctrPersonEventArgs(int _PersonId)
            {
                PersonId = _PersonId;

               
            }

           

        }
     
        public event EventHandler<ctrPersonEventArgs> OnPersonCtrUpdate;
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

       
        public void ResetPersonInfo()
        {
            _PersonId = -1;
            _Person = null;

            lblPersonID.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblAddress.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblPhone.Text = "[????]";
            lblCountry.Text = "[????]";

            pbPersonImage.Image = Properties.Resources.Male_512;
            //  llEditPersonInfo.Enabled = true;  

            llEditPersonInfo.Enabled = EnableEditPersonLink;
        }

        private void _SetDefaultAvatar()
        {

            if (_Person != null)
            {

                if (_Person.PersonDTO.Gender == 0)
                {
                    pbPersonImage.Image=Properties.Resources.Male_512;  
                }
                else
                {
                    pbPersonImage.Image=Properties.Resources.Female_512;
                }
            }
        }


       
   private void _FillPersonInfo()
      {

            _PersonId = _Person.PersonDTO.PersonID;

            lblPersonID.Text = _Person.PersonDTO.PersonID.ToString();
            lblName.Text = _Person.PersonDTO.FullName();
            lblNationalNo.Text = _Person.PersonDTO.NationalNo;
            lblGendor.Text = _Person.PersonDTO.Gender == 0 ? "Male" : "Female";
            lblEmail.Text = string.IsNullOrEmpty(_Person.PersonDTO.Email) ? "N/A" : _Person.PersonDTO.Email;
            lblAddress.Text = _Person.PersonDTO.Address;
            lblDateOfBirth.Text = _Person.PersonDTO.DateOfBirth.ToShortDateString();
            lblPhone.Text = _Person.PersonDTO.Phone;

           
            clsCountry country = clsCountry.Find(_Person.PersonDTO.NationalityCountryID);
            lblCountry.Text = country != null ? country.DTO.CountryName : "[????]";

            
            if (!string.IsNullOrEmpty(_Person.PersonDTO.ImagePath) && File.Exists(_Person.PersonDTO.ImagePath))
            {
                pbPersonImage.ImageLocation = _Person.PersonDTO.ImagePath;
            }
            else
            {
                _SetDefaultAvatar();
            }

            llEditPersonInfo.Enabled = EnableEditPersonLink;
        }


      

        public void LoadPersonInfo(int PersonId)
        {
            _Person = clsPerson.Find(PersonId);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"No person found with PersonID = [{_PersonId}]", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillPersonInfo();
            }
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"No person found with PersonID = [{_PersonId}]", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillPersonInfo();
            }
        }

      
        private void pbPersonImage_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadPersonInfo(_PersonId);

                    OnPersonCtrUpdate?.Invoke(this,new ctrPersonEventArgs(_PersonId));
                }
            }
        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }
    }
}
