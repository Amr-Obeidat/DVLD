using DVLD.Controls;
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
    public partial class frmShowLicenseInfo : Form
    {

        int _LicenseId;
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseId = LicenseID; 
            
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {


            ctrDriverLicenseInfo1.LoadInfo(_LicenseId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
