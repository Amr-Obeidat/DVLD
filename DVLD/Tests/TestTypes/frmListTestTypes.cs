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
    public partial class frmListTestTypes : Form
    {
        public frmListTestTypes()
        {
            InitializeComponent();
            _ConfigureDataGridView();
        }

        DataTable _AllTestTypes = clsTestTypes.GetAllTestTypes();   

     

        

        private void _ConfigureDataGridView()
        {
            dgvTestTypes.AllowUserToAddRows = false;
            dgvTestTypes.AllowUserToDeleteRows = false;
            dgvTestTypes.ReadOnly = true;
            dgvTestTypes.BackgroundColor = Color.White;
            dgvTestTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTestTypes.MultiSelect = false;


        }

        private void _ConfigureDataGridViewColumns()
        {
            if (dgvTestTypes.Rows.Count > 0)
            {
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeId].HeaderText = "ID";
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeId].Width = 110;
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeId].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeId].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeTitle].HeaderText = "Title";
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeTitle].Width = 110;
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeTitle].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                 dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeDescription].HeaderText = "Description";
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeDescription].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeDescription].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeFees].HeaderText = "Fees";
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeFees].Width = 70;
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeFees].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeFees].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvTestTypes.Columns[clsTestTypeAttributes.colTestTypeFees].DefaultCellStyle.Format = "N2"; // Formats decimals
            }
        }
        private void frmListTestTypes_Load(object sender, EventArgs e)
        {

            dgvTestTypes.DataSource = _AllTestTypes;    

            if (dgvTestTypes.Rows.Count > 0)
            {
                _ConfigureDataGridViewColumns();
                lblNumOfRecords.Text = dgvTestTypes.Rows.Count.ToString();  
            }

        }
        private class clsTestTypeAttributes
        {
            public const string colTestTypeId = "TestTypeID";
            public const string colTestTypeTitle = "TestTypeTitle";
            public const string colTestTypeDescription = "TestTypeDescription";
            public const string colTestTypeFees = "TestTypeFees";
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           clsTestTypesDTO.enTestType TestTypeId = (clsTestTypesDTO.enTestType)Convert.ToInt16(dgvTestTypes.SelectedRows[0].Cells[clsTestTypeAttributes.colTestTypeId].Value);
            frmEditTestType frm = new frmEditTestType(TestTypeId);    
            if(frm.ShowDialog() == DialogResult.OK)
            {
                _AllTestTypes = clsTestTypes.GetAllTestTypes();  
                dgvTestTypes.DataSource = _AllTestTypes;    
              
               
            }
        }
    }
}
