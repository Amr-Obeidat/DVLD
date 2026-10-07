using DVLD_Business.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmListApplicationTypes : Form
    {
        public frmListApplicationTypes()
        {
            InitializeComponent();
            _ConfigureDataGridView();
        }

        private DataTable _AllAppTypes=clsApplicationTypes.GetAllApplicationTypes();

        private void _ConfigureDataGridView()
        {
          dgvAppTypes.AllowUserToAddRows = false;
          dgvAppTypes.AllowUserToDeleteRows = false;
          dgvAppTypes.ReadOnly = true;
          dgvAppTypes.BackgroundColor = Color.White;
          dgvAppTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
          dgvAppTypes.MultiSelect = false;


        }



        private void _ConfigureDataGridViewColumns()
        {
            if (dgvAppTypes.Rows.Count > 0)
            {
                dgvAppTypes.Columns["ApplicationTypeID"].HeaderText = "ID";
                dgvAppTypes.Columns["ApplicationTypeID"].Width = 110;
                dgvAppTypes.Columns["ApplicationTypeID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvAppTypes.Columns["ApplicationTypeID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvAppTypes.Columns["ApplicationTypeTitle"].HeaderText = "Title";
                dgvAppTypes.Columns["ApplicationTypeTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAppTypes.Columns["ApplicationTypeTitle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvAppTypes.Columns["ApplicationFees"].HeaderText = "Fees";
                dgvAppTypes.Columns["ApplicationFees"].Width = 140;
                dgvAppTypes.Columns["ApplicationFees"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvAppTypes.Columns["ApplicationFees"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvAppTypes.Columns["ApplicationFees"].DefaultCellStyle.Format = "N2"; // Formats decimals
            }
        }
        private void dgvAppTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {
            dgvAppTypes.DataSource = _AllAppTypes;

            lblNumOfRecords.Text = dgvAppTypes.Rows.Count.ToString();
            _ConfigureDataGridViewColumns();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = Convert.ToInt32(dgvAppTypes.SelectedRows[0].Cells["ApplicationTypeID"].Value);
            frmUpdateApplicationType frm = new frmUpdateApplicationType(ApplicationTypeID);  
            frm.ShowDialog();
        }
    }
}
