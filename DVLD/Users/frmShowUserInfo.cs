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

namespace DVLD.Users
{
    public partial class frmShowUserInfo : Form
    {


        private int _UserdId;
        public frmShowUserInfo(int Userid)
        {
           
           
            InitializeComponent();
            _UserdId = Userid;

          
            ctrUserCard1.EnableEditUserLinkVisibility = false;
            ctrUserCard1.EnableEditUserLink=false;




        }
        

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {

        }

        private void ctrUserCard1_Load(object sender, EventArgs e)
        {
            ctrUserCard1.LoadUserInfo(_UserdId);
        }
    }
}
