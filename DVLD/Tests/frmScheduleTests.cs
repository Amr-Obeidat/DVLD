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
    public partial class frmScheduleTests : Form
    {


        private int _LocalDrivingLicenseApplicationId = -1;
        private clsTestTypesDTO.enTestType TestTypeID = clsTestTypesDTO.enTestType.VisionTest;
        private int _TestAppointmentId = -1;    

        public frmScheduleTests()
        {
            InitializeComponent();
           

        }
public bool LoadInfo( int LocalAppId, clsTestTypesDTO.enTestType TestId, int AppointmentId = -1)
        {
            ctrScheduleTests1.TestTypeID = TestId;

            return ctrScheduleTests1.LoadInfo(LocalAppId, AppointmentId);
        }



        private void ctrScheduleTests1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmScheduleTests_Load(object sender, EventArgs e)
        {

        }
    }
}
