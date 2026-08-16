using DVLD_Business.People;
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

namespace DVLD.Users
{
    public partial class frmListUsers : Form
    {

        private static DataTable _dtAllUsers = clsUser.GetAllUsers();


        private DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(true,
            UserAttributes.colUserId,
            PersonColumns.colPersonId,
            UserAttributes.colFullName,
            UserAttributes.colUserName,
            UserAttributes.colIsActive




            );

        public frmListUsers()
        {
            InitializeComponent();
            this.Text = "Manage Users";
            _ConfigureDataGridView();
        }

        private void _ConfigureDataGridView()
        {
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;


        }

        private void _PopulateFilterComboBox()
        {

            cbFilterList.Items.Clear();

            cbFilterList.Items.Add(UserFilters.FilterNone);
            cbFilterList.Items.Add(UserFilters.UserId);
            cbFilterList.Items.Add(UserFilters.PersonID);
            cbFilterList.Items.Add(UserFilters.FullName);
            cbFilterList.Items.Add(UserFilters.UserName);
            cbFilterList.Items.Add(UserFilters.IsActive);
            cbFilterList.SelectedIndex = 0;





        }


        private void _ConfigureColumns()
        {
            if (dgvUsers.Columns.Count == 0)
                return;

            dgvUsers.Columns[UserAttributes.colUserId].HeaderText = "User ID";
            dgvUsers.Columns[UserAttributes.colUserId].Width = 110;

            dgvUsers.Columns[UserAttributes.colPersonId].HeaderText = "Person ID";
            dgvUsers.Columns[UserAttributes.colPersonId].Width = 110;

            dgvUsers.Columns[UserAttributes.colFullName].HeaderText = "Full Name";
            dgvUsers.Columns[UserAttributes.colFullName].Width = 350;

            dgvUsers.Columns[UserAttributes.colUserName].HeaderText = "User Name";
            dgvUsers.Columns[UserAttributes.colUserName].Width = 140;

            dgvUsers.Columns[UserAttributes.colIsActive].HeaderText = "Is Active";
            dgvUsers.Columns[UserAttributes.colIsActive].Width = 100;
        }
        private void frmListUsers_Load(object sender, EventArgs e)
        {

            _PopulateFilterComboBox();
            dgvUsers.DataSource = _dtAllUsers;

            if (_dtAllUsers != null && _dtUsers != null && _dtUsers.Rows.Count > 0)
            {
                _ConfigureColumns();
                dgvUsers.DataSource = _dtUsers;
                lblNumOfRecords.Text = dgvUsers.Rows.Count.ToString();

            }
        }


        private void _RefreshUserRow(int UserId)
        {
            clsUser user = clsUser.Find(UserId);

            if (user == null)
                return;


            DataRow[] rows = _dtUsers.Select($"{UserAttributes.colUserId} = {UserId}"
            );




            if (rows.Length == 0)
                return;



            DataRow row = rows[0];



            row[UserAttributes.colUserId] = user.UserDTO.UserID;



            row[UserAttributes.colPersonId] = user.UserDTO.PersonID;


            row[UserAttributes.colFullName] = user.PersonInfo.PersonDTO.FullName();

            row[UserAttributes.colUserName] = user.UserDTO.UserName;

            row[UserAttributes.colIsActive] = user.UserDTO.IsActive;





            lblNumOfRecords.Text = _dtUsers.DefaultView.Count.ToString();
        }



        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserId = (int)dgvUsers.CurrentRow.Cells[UserAttributes.colUserId].Value;

            frmShowUserInfo frm = new frmShowUserInfo(UserId);
            frm.ShowDialog();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.DataBack += Frm_DataBack;
        }

        private void _AddNewUserToGrid(int UserId)
        {
            clsUser User = clsUser.Find(UserId);

            if (User == null)
            {
                return;
            }

            DataRow[] exisitngrow = _dtUsers.Select($"{UserAttributes.colUserId}={UserId}");

            if (exisitngrow.Length > 0)
            {
                return;
            }

            DataRow Newrow = _dtUsers.NewRow();


            Newrow[UserAttributes.colUserId] = User.UserDTO.UserID;
            Newrow[UserAttributes.colPersonId] = User.UserDTO.PersonID;
            Newrow[UserAttributes.colFullName] = User.PersonInfo.PersonDTO.FullName();
            Newrow[UserAttributes.colUserName] = User.UserDTO.UserName;
            Newrow[UserAttributes.colIsActive] = User.UserDTO.IsActive;
            _dtUsers.Rows.Add(Newrow);

            lblNumOfRecords.Text = _dtUsers.Rows.Count.ToString();


        }
        private void Frm_DataBack(object sender, int PersonId)
        {
            _AddNewUserToGrid((int)PersonId);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserId = (int)dgvUsers.CurrentRow.Cells[UserAttributes.colUserId].Value;
            frmAddUpdateUser frm = new frmAddUpdateUser(UserId);
            frm.ShowDialog();
            _RefreshUserRow(UserId);
        }


        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserId = (int)dgvUsers.CurrentRow.Cells[UserAttributes.colUserId].Value;
            frmChangePassword frm = new frmChangePassword(UserId);
            frm.ShowDialog();
            _RefreshUserRow(UserId);

        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// still not implemented 
        }

        private class UserAttributes
        {

            public const string colUserId = "UserID";
            public const string colUserName = "UserName";
            public const string colPersonId = "PersonID";
            public const string colIsActive = "IsActive";
            public const string colFullName = "FullName";



        }

        private class UserFilters
        {
            public const string FilterNone = "None";

            public const string UserId = "User ID";
            public const string PersonID = "Person ID";
            public const string UserName = "User Name";
            public const string FullName = "Full Name";
            public const string IsActive = "Is Active";



        }



        private string _GetFilterColumn(string selectedFilter)
        {
            switch (selectedFilter)
            {
                case UserFilters.UserId:
                    return UserAttributes.colUserId;
                case UserFilters.PersonID:
                    return UserAttributes.colPersonId;
                case UserFilters.UserName:
                    return UserAttributes.colUserName;
                case UserFilters.FullName:
                    return UserAttributes.colFullName;
                case UserFilters.IsActive:
                    return UserAttributes.colIsActive;
                default:
                    return string.Empty;
            }
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (_dtUsers == null) return;

            string filterText = cbFilterList.Text.Trim();
            string filterValue = txtFilterBy.Text.Trim();

          
            if (filterText == UserFilters.FilterNone || string.IsNullOrEmpty(filterValue))
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblNumOfRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            string selectedColumn = _GetFilterColumn(filterText);

            if (string.IsNullOrEmpty(selectedColumn))
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblNumOfRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

           
            if (selectedColumn == UserAttributes.colUserId || selectedColumn == UserAttributes.colPersonId)
            {
            
                if (int.TryParse(filterValue, out _))
                    _dtUsers.DefaultView.RowFilter = $"Convert([{selectedColumn}], 'System.String') LIKE '{filterValue}%'";
                else
                    _dtUsers.DefaultView.RowFilter = "1 = 0"; 
            }
            else if (selectedColumn == UserAttributes.colIsActive)
            {
                if (filterValue == "1")
                    _dtUsers.DefaultView.RowFilter = $"[{selectedColumn}] = true";
                else if (filterValue == "0")
                    _dtUsers.DefaultView.RowFilter = $"[{selectedColumn}] = false";
                else
                    _dtUsers.DefaultView.RowFilter = "1 = 0";
            }
            else
            {
                // for user name and full name, use LIKE operator with wildcards
                string safeValue = filterValue.Replace("'", "''");
                _dtUsers.DefaultView.RowFilter = $"[{selectedColumn}] LIKE '{safeValue}%'";
            }

            
            
            lblNumOfRecords.Text = dgvUsers.Rows.Count.ToString();
        }



        private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterList.SelectedItem.ToString() == UserFilters.FilterNone)
            {
                txtFilterBy.Visible = false;
                txtFilterBy.Clear();
                _dtUsers.DefaultView.RowFilter = "";
            }
            else
            {
                txtFilterBy.Visible = true;
                txtFilterBy.Clear();
                txtFilterBy.Focus();
            }
            lblNumOfRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();    
        }
    }

}
