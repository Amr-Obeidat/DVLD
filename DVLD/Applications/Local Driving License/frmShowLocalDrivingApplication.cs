using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmShowLocalDrivingApplication : Form
    {

        private int _LocalDrivingLicenseApplicaion;
        public frmShowLocalDrivingApplication(int LocalDrivingLicenseApplicaion)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicaion = LocalDrivingLicenseApplicaion;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLocalDrivingApplication_Load(object sender, EventArgs e)
        {
            ctrLocalDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicaion);
        }
    }
}
