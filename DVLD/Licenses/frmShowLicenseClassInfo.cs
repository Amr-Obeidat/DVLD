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
    public partial class frmShowLicenseClassInfo : Form
    {
        public frmShowLicenseClassInfo(int LicenseClassInfo)
        {
            InitializeComponent();

            ctrlLicenseClassInfo1.LoadLicenseClassInfo(LicenseClassInfo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
