using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.FromTests
{
    public partial class frmTestPersonControlCard : Form
    {
        public frmTestPersonControlCard()
        {
            InitializeComponent();
        }

        private void frmTestPersonControlCard_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInfo(7041);
        }
    }
}
