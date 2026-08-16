using DVLD_Business.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD.People
{
  
    public partial class frmListPeople : Form
    {
        public frmListPeople()
        {
            InitializeComponent();
           _ConfigureDataGridView();    
        }

        private  static DataTable _dtAllPeople=clsPerson.GetAllPeople();   


        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(true,
                    PersonColumns.colPersonId,
                    PersonColumns.colNationalId,
                    PersonColumns.colFirstName,
                    PersonColumns.colSecondName,
                    PersonColumns.colThirdName,
                    PersonColumns.colLastName,
                    PersonColumns.colBirthDate,
                    PersonColumns.colGenderCaption,
                    PersonColumns.colNationality,
                    PersonColumns.colPhone,
                    PersonColumns.colEmail);

        private void _ConfigureDataGridView()
        {
            dgvPeople.AllowUserToAddRows = false;
            dgvPeople.AllowUserToDeleteRows = false;
            dgvPeople.ReadOnly = true;
            dgvPeople.BackgroundColor = Color.White;
            dgvPeople.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeople.MultiSelect = false;


        }
        private void _PopulateFilterComboBox()
        {

            cbFilterList.Items.Clear();

            cbFilterList.Items.Add(PersonColumns.FILTER_NONE);
            cbFilterList.Items.Add(PersonColumns.FILTER_PERSON_ID);
            cbFilterList.Items.Add(PersonColumns.FILTER_NATIONAL_NO);
            cbFilterList.Items.Add(PersonColumns.FILTER_FIRST_NAME);
            cbFilterList.Items.Add(PersonColumns.FILTER_SECOND_NAME);
            cbFilterList.Items.Add(PersonColumns.FILTER_THIRD_NAME);
            cbFilterList.Items.Add(PersonColumns.FILTER_LAST_NAME);
            cbFilterList.Items.Add(PersonColumns.FILTER_DATE_OF_BIRTH);
            cbFilterList.Items.Add(PersonColumns.FILTER_GENDER);
            cbFilterList.Items.Add(PersonColumns.FILTER_NATIONALITY);
            cbFilterList.Items.Add(PersonColumns.FILTER_PHONE);
            cbFilterList.Items.Add(PersonColumns.FILTER_EMAIL);

            cbFilterList.SelectedIndex = 0;
        }
        private void _ConfigureColumns()
        {
            if (dgvPeople.Columns.Count == 0)
                return;

                      // the index name should be sync with the one in the data base
            dgvPeople.Columns[PersonColumns.colPersonId].HeaderText =
                "Person ID";

            dgvPeople.Columns[PersonColumns.colPersonId].Width = 110;


            dgvPeople.Columns[PersonColumns.colNationalId].HeaderText =
                "National No.";

            dgvPeople.Columns[PersonColumns.colNationalId].Width = 120;


            dgvPeople.Columns[PersonColumns.colFirstName].HeaderText =
                "First Name";

            dgvPeople.Columns[PersonColumns.colFirstName].Width = 130;


            dgvPeople.Columns[PersonColumns.colSecondName].HeaderText =
                "Second Name";

            dgvPeople.Columns[PersonColumns.colSecondName].Width = 130;


            dgvPeople.Columns[PersonColumns.colThirdName].HeaderText =
                "Third Name";

            dgvPeople.Columns[PersonColumns.colThirdName].Width = 130;


            dgvPeople.Columns[PersonColumns.colLastName].HeaderText =
                "Last Name";

            dgvPeople.Columns[PersonColumns.colLastName].Width = 130;


            dgvPeople.Columns[PersonColumns.colBirthDate].HeaderText =
                "Birth Date";

            dgvPeople.Columns[PersonColumns.colBirthDate].Width = 110;


            dgvPeople.Columns[PersonColumns.colGenderCaption].HeaderText =
                "Gender";

            dgvPeople.Columns[PersonColumns.colGenderCaption].Width = 80;


            dgvPeople.Columns[PersonColumns.colNationality].HeaderText =
                "Nationality";

            dgvPeople.Columns[PersonColumns.colNationality].Width = 120;


            dgvPeople.Columns[PersonColumns.colPhone].HeaderText =
                "Phone";

            dgvPeople.Columns[PersonColumns.colPhone].Width = 120;


            dgvPeople.Columns[PersonColumns.colEmail].HeaderText =
                "Email";

            dgvPeople.Columns[PersonColumns.colEmail].Width = 200;
        }
        private void frmListPeople_Load(object sender, EventArgs e)
        {
            _PopulateFilterComboBox();

            if(_dtAllPeople!=null && _dtPeople!=null && _dtPeople.Rows.Count > 0)
            {
                dgvPeople.DataSource = _dtPeople;
                cbFilterList.SelectedIndex = 0; 
                lblNumOfRecords.Text=dgvPeople.Rows.Count.ToString();


                _ConfigureColumns();// set the size , the order of the columns

                }

            }


        private void _RefreshPersonRow(int personID)
        {
            clsPerson person = clsPerson.Find(personID);

            if (person == null)
                return;


            DataRow[] rows = _dtPeople.Select($"{PersonColumns.colPersonId} = {personID}"
            );
            


            
            if (rows.Length == 0)
                return;


          
            DataRow row = rows[0];


            
            row[PersonColumns.colNationalId] =
                person.PersonDTO.NationalNo;

            row[PersonColumns.colFirstName] =
                person.PersonDTO.FirstName;

            row[PersonColumns.colSecondName] =
                person.PersonDTO.SecondName;

            row[PersonColumns.colThirdName] =
                person.PersonDTO.ThirdName;

            row[PersonColumns.colLastName] =
                person.PersonDTO.LastName;

            row[PersonColumns.colBirthDate] =
                person.PersonDTO.DateOfBirth;

            row[PersonColumns.colGenderCaption] =
                person.PersonDTO.Gender == 0
                    ? "Male"
                    : "Female";

            row[PersonColumns.colPhone] =
                person.PersonDTO.Phone;

            row[PersonColumns.colEmail] =
                string.IsNullOrEmpty(person.PersonDTO.Email)
                    ? ""
                    : person.PersonDTO.Email;


            clsCountry country =
                clsCountry.Find(
                    person.PersonDTO.NationalityCountryID
                );


            row[PersonColumns.colNationality] =  country != null ? country.DTO.CountryName : "[????]";



            lblNumOfRecords.Text = _dtPeople.DefaultView.Count.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {                                                
            int PersonId = (int)dgvPeople.CurrentRow.Cells[PersonColumns.colPersonId].Value;
            Form frmEditPersonInfo = new frmAddUpdatePerson(PersonId);
            frmEditPersonInfo.ShowDialog();

            _RefreshPersonRow(PersonId);


            

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonId = (int)dgvPeople.CurrentRow.Cells[PersonColumns.colPersonId].Value;
            Form frmShowPersonDetails = new frmShowPersonInfo(PersonId);
            frmShowPersonDetails.ShowDialog();   

        }


        private void _AddNewPersonToGrid(int newPersonID)
        {
            clsPerson person = clsPerson.Find(newPersonID);

            if (person == null)
                return;


          
            DataRow[] existingRows = _dtPeople.Select( $"{PersonColumns.colPersonId} = {newPersonID}"
            );


            if (existingRows.Length > 0) 
                return;


          
            DataRow newRow = _dtPeople.NewRow();


            newRow[PersonColumns.colPersonId] =
                person.PersonDTO.PersonID;

            newRow[PersonColumns.colNationalId] =
                person.PersonDTO.NationalNo;

            newRow[PersonColumns.colFirstName] =
                person.PersonDTO.FirstName;

            newRow[PersonColumns.colSecondName] =
                person.PersonDTO.SecondName;

            newRow[PersonColumns.colThirdName] =
                person.PersonDTO.ThirdName;

            newRow[PersonColumns.colLastName] =
                person.PersonDTO.LastName;

            newRow[PersonColumns.colBirthDate] =
                person.PersonDTO.DateOfBirth;

            newRow[PersonColumns.colGenderCaption] =
                person.PersonDTO.Gender == 0
                    ? "Male"
                    : "Female";

            newRow[PersonColumns.colPhone] =
                person.PersonDTO.Phone;

            newRow[PersonColumns.colEmail] =
                string.IsNullOrEmpty(person.PersonDTO.Email)
                    ? ""
                    : person.PersonDTO.Email;


            clsCountry country =
                clsCountry.Find(
                    person.PersonDTO.NationalityCountryID
                );


            newRow[PersonColumns.colNationality] =
                country != null
                    ? country.DTO.CountryName
                    : "[????]";


           
            _dtPeople.Rows.Add(newRow);


            lblNumOfRecords.Text =
                _dtPeople.DefaultView.Count.ToString();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddPerson=new frmAddUpdatePerson();
            frmAddPerson.DataBack += FrmAddPerson_DataBack;
            frmAddPerson.ShowDialog();
        }


          

        private void FrmAddPerson_DataBack(object sender, int PersonId)
        {
           _AddNewPersonToGrid(PersonId);
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
          
            string filterColumn = cbFilterList.Text.Trim();
            string filterValue = txtFilterBy.Text.Trim();

          
            if (string.IsNullOrEmpty(filterValue) || string.IsNullOrEmpty(filterColumn) || filterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = ""; 
                lblNumOfRecords.Text = _dtPeople.DefaultView.Count.ToString();
                return;
            }

       
            string selectedColumn = GetSelectedColumnName(filterColumn);


            if (selectedColumn == PersonColumns.colPersonId)
            {

                if (int.TryParse(filterValue, out int personId))
                {
                  _dtPeople.DefaultView.RowFilter= $"[{selectedColumn}] = {personId}";
                }
                else
                {
             
                    _dtPeople.DefaultView.RowFilter = "1 = 0";
                }
            }
            else
            {
              
                string safeValue = filterValue.Replace("'", "''");
                _dtPeople.DefaultView.RowFilter = $"[{selectedColumn}] LIKE '{safeValue}%'";
            }

          
            dgvPeople.DataSource = _dtPeople.DefaultView;
            lblNumOfRecords.Text = _dtPeople.DefaultView.Count.ToString();


        }
        private string GetSelectedColumnName(string displayColumn)
        {
            switch (displayColumn)
            {
                case "Person ID":
                    return PersonColumns.colPersonId;
                case "National No.":
                    return PersonColumns.colNationalId;
                case "First Name":
                    return PersonColumns.colFirstName;
                case "Second Name":
                    return PersonColumns.colSecondName;
                case "Third Name":
                    return PersonColumns.colThirdName;
                case "Last Name":
                    return PersonColumns.colLastName;
                case "Nationality":
                case "Country Name":
                    return "CountryName"; 
                case "Phone":
                    return PersonColumns.colPhone;
                case "Email":
                    return PersonColumns.colEmail;
                default:
                    return displayColumn;
            }
        }
        private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
          txtFilterBy.Visible=(cbFilterList.Text!=PersonColumns.FILTER_NONE); 


            if (txtFilterBy.Visible)
            {
                txtFilterBy.Text = "";
                txtFilterBy.Focus();    
                 
            }
        }

        private void dgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPeople_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                dgvPeople.ClearSelection();
                dgvPeople.Rows[e.RowIndex].Selected = true;
                dgvPeople.CurrentCell = dgvPeople.Rows[e.RowIndex].Cells[e.ColumnIndex];

                cmsPeople.Show(Cursor.Position);

            }
        }

        private void cmsPeople_Opening(object sender, CancelEventArgs e)
        {

        }
    }
    }
    public static class PersonColumns
    {
        public const string colPersonId = "PersonID";
        public const string colNationalId = "NationalNo";
        public const string colFirstName = "FirstName";
        public const string colSecondName = "SecondName";
        public const string colThirdName = "ThirdName";
        public const string colLastName = "LastName";
        public const string colBirthDate = "DateOfBirth";
        public const string colGenderCaption = "GenderCaption";
        public const string colPhone = "Phone";
        public const string colEmail = "Email";
        public const string colCountryId = "NationalityCountryID";
        public const string colNationality = "CountryName"; 
        public const string colImagePath = "ImagePath";
        public const string colAddress = "Address";
        public const string TableName = "DVLD.dbo.People";

       
      public const string FILTER_NONE = "None";
      public const string FILTER_PERSON_ID = "Person ID";
      public const string FILTER_NATIONAL_NO = "National No.";
      public const string FILTER_FIRST_NAME = "First Name";
      public const string FILTER_SECOND_NAME = "Second Name";
      public const string FILTER_THIRD_NAME = "Third Name";
      public const string FILTER_LAST_NAME = "Last Name";
      public const string FILTER_GENDER = "Gender";
      public const string FILTER_DATE_OF_BIRTH = "Date Of Birth";
      public const string FILTER_NATIONALITY = "Nationality";
      public const string FILTER_PHONE = "Phone";
      public const string FILTER_EMAIL = "Email";
    }

