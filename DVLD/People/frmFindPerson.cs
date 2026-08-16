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
    public partial class frmFindPerson : Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
            ctrPersonCardWithFiltercs1.ShowAddPerson = false;
            ctrPersonCardWithFiltercs1.EnableEditPerson=false;
        }


        public delegate void DataBackEventHandler( object sender,int personId);

        public event DataBackEventHandler DataBack;

        private void frmFindPerson_Load(object sender, EventArgs e)
        {
          ctrPersonCardWithFiltercs1.Focus();   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this,ctrPersonCardWithFiltercs1.PersonId);
            this.Close();
        }
    }
}
