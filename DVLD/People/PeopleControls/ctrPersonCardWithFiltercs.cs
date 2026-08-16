using DVLD.People;
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

namespace DVLD.Controls
{


    public partial class ctrPersonCardWithFiltercs : UserControl
    {


      

        public event Action<int> OnPersonSelected;
        public event Action<int> OnPersonUpdated;


        protected virtual void PersonSelected(int PersonId)
        {
            Action<int> handler = OnPersonSelected;

            if (handler != null)
            {
                handler(PersonId);
            }
        }

        private bool _ShowAddPerson = true;
        private bool _FilterEnabled = true;

        [Category("Person Filter Properties")]
        public bool ShowAddPerson
        {

            get
            {
                return _ShowAddPerson;
            }

            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }





        [Category("Person Filter Properties")]
        public bool FilterEnabled
        {

            get
            {
                return _FilterEnabled;

            }

            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public int PersonId => ctrlPersonCard1.PersonId;

        public clsPerson SelectedPersonInfo => ctrlPersonCard1.SelectedPersonInfo;



        [Category("Person Filter Properties")]
        public bool EnableEditPerson
        {
            get => ctrlPersonCard1.EnableEditPersonLink;
            set => ctrlPersonCard1.EnableEditPersonLink = value;
        }


        public ctrPersonCardWithFiltercs()
        {
            InitializeComponent();
            btnAddNewPerson.CausesValidation = false;
            ctrlPersonCard1.OnPersonCtrUpdate += (sender, e) =>
            {
                OnPersonUpdated?.Invoke(e.PersonId);
            };
        }


        public void LoadPersonInfo(int PersonId)
        {
            cbFilterBy.SelectedIndex = cbFilterBy.FindString("Person ID");
            if (cbFilterBy.SelectedIndex == -1 && cbFilterBy.Items.Count > 0)
                cbFilterBy.SelectedIndex = 0;

            txtFilterValue.Text = PersonId.ToString();
            FindPersonCardInfo();

        }

        public void FindPersonCardInfo()
        {

            switch (cbFilterBy.Text.Trim())
            {
                case "National No.":
                case "National No":
                    ctrlPersonCard1.LoadPersonInfo(txtFilterValue.Text.Trim());
                    break;


                case "Person ID":
                    if (int.TryParse(txtFilterValue.Text.Trim(), out int personID))
                    {
                        ctrlPersonCard1.LoadPersonInfo(personID);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid numeric Person ID.", "Invalid Input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;


                default:
                    break;

            }

            if (OnPersonSelected != null && FilterEnabled&& ctrlPersonCard1.PersonId!=-1)
            {

                OnPersonSelected(ctrlPersonCard1.PersonId);
            }

        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        private void ctrPersonCardWithFiltercs_Load(object sender, EventArgs e)
        {

            cbFilterBy.SelectedIndex = 1;
            FilterFocus();
        }

        public void ResetPersonInfo()
        {
            txtFilterValue.Text = string.Empty;
            ctrlPersonCard1.ResetPersonInfo();
        }

       
        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

              if(!this.ValidateChildren())
            {
                MessageBox.Show("Please enter a valid value to search for.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
              FindPersonCardInfo();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(e.KeyChar== (char)Keys.Enter)
            {
                btnFind.PerformClick();
                e.Handled = true;
                return;
            }
            if(cbFilterBy.Text.Trim()== "Person ID")
            {
                
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Ignore the input
                }


            }
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text))
            {
                errorProvider1.SetError(txtFilterValue, "Filter field cannot be empty!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void cbFilterBy_TextChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = string.Empty;
            errorProvider1.SetError(txtFilterValue, null);
            txtFilterValue.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

          
            frmAddUpdatePerson frm=new frmAddUpdatePerson();

            using (frm)
            {


                frm.DataBack += _OnNewPersonSaved;

                frm.ShowDialog();
            }
            ;

              
            }




        private void _OnNewPersonSaved(object sender, int NewPersonId)
        {

            cbFilterBy.SelectedIndex = cbFilterBy.FindString("Person ID");
            txtFilterValue.Text=NewPersonId.ToString();
            ctrlPersonCard1.LoadPersonInfo(NewPersonId);

            if (FilterEnabled)
            {
                OnPersonSelected?.Invoke(NewPersonId);
            }

        }
    }
}
