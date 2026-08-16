using DVLD_Business.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users.UserControls
{
    public partial class ctrUserCard : UserControl
    {
        public ctrUserCard()
        {
            InitializeComponent();
        }


        private clsUser _User;
        int _UserId;

        public int UserId
        {
            get => _UserId;
        }

        public bool EnableEditUserLink
        {
            get => ctrlPersonCard1.EnableEditPersonLink;
            set => ctrlPersonCard1.EnableEditPersonLink = value;
        }

        public bool EnableEditUserLinkVisibility
        {
            get => ctrlPersonCard1.EnableEditPersonLinkVisibility;
            set => ctrlPersonCard1.EnableEditPersonLinkVisibility = value;
        }
        public void ResetUserInfo()
        {
            _UserId = -1;
            _User = null;

            ctrlPersonCard1.ResetPersonInfo();

            lblUserId.Text = "[????]";
            lblUserName.Text = "[????]";
            lblIsActive.Text = "[????]";
        }
        private void _FillUserInfo()
        {
            _UserId =_User.UserDTO.UserID;

            ctrlPersonCard1.LoadPersonInfo(_User.PersonInfo.PersonDTO.PersonID);

            lblUserId.Text = _User.UserDTO.UserID.ToString();
            lblUserName.Text = _User.UserDTO.UserName;
            lblIsActive.Text = _User.UserDTO.IsActive ? "Yes" : "No";
        }


        public void LoadUserInfo(int UserID)
        {


            _UserId = UserID;

            if (_UserId == -1)
            {
                ResetUserInfo();
                return;
            }

            _User = clsUser.Find(_UserId);

            if (_User != null)
            {
                _FillUserInfo();
            }
            else
            {
                MessageBox.Show($"No User with UserID = {_UserId} found in the system.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
        

       
        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
