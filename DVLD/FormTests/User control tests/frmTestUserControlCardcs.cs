using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.FormTests.User_control_tests
{
    public partial class frmTestUserControlCardcs : Form
    {
        public frmTestUserControlCardcs()
        {
            InitializeComponent();
        }

        private void frmTestUserControlCardcs_Load(object sender, EventArgs e)
        {

            
            ctrUserCard1.LoadUserInfo(3019);
        }
    }
}
