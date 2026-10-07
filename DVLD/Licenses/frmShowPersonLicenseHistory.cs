using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {

        int _PersonId = -1;

        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
            ctrPersonCardWithFiltercs1.EnableEditPerson = false;
            ctrPersonCardWithFiltercs1.CreatePersonbtnenabled = false;

        }
        public frmShowPersonLicenseHistory(int PersonId)
        {
            InitializeComponent();
            _PersonId = PersonId;
            ctrPersonCardWithFiltercs1.EnableEditPerson = false;
            ctrPersonCardWithFiltercs1.CreatePersonbtnenabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonId != -1)
            {
                ctrPersonCardWithFiltercs1.LoadPersonInfo(_PersonId);
                ctrPersonCardWithFiltercs1.FilterEnabled = false;
                ctrDrivingLicense1.LoadInfoByPersonID(_PersonId);

            }
            else
            {
                ctrDrivingLicense1.Enabled = true;
                ctrPersonCardWithFiltercs1.FilterFocues();
                ctrPersonCardWithFiltercs1.OnPersonSelected += CtrPersonCardWithFiltercs1_OnPersonSelected;
            }
        }

        private void CtrPersonCardWithFiltercs1_OnPersonSelected(int obj)
        {
            _PersonId = obj;

            if (_PersonId == -1)
            {
                ctrDrivingLicense1.Clear();
            }
            else
            {
                ctrDrivingLicense1.LoadInfoByPersonID(_PersonId);
            }
        }
    }
}
