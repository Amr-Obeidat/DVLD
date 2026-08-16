using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(NationalNo);

            ctrlPersonCard1.EnableEditPersonLink = false;  
            ctrlPersonCard1.EnableEditPersonLinkVisibility = false;

        }

        public frmShowPersonInfo(int PesonId)
        {
            InitializeComponent();
        
            ctrlPersonCard1.LoadPersonInfo(PesonId);
            ctrlPersonCard1.EnableEditPersonLink = false;
            ctrlPersonCard1.EnableEditPersonLinkVisibility = false;
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
