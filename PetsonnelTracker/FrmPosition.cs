using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace PetsonnelTracker
{
    public partial class FrmPosition : Form
    {
        public int x = 1;
        List<Department> departmentlist = new List<Department>(); 
        public FrmPosition()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtPos.Text.Trim()=="")
            {
                MessageBox.Show("Please enter the Position Name");
            }
            else if(cmbDepartment.SelectedIndex==-1)
            {
                MessageBox.Show("Please select a department");
            }
            else
            {
                Position position = new Position();
                position.Position_Name = txtPos.Text;
                position.Department_ID = Convert.ToInt32(cmbDepartment.SelectedValue);
                PositionBLL.addPosition(position);
                MessageBox.Show("New Position was added");
                txtPos.Clear();
                cmbDepartment.SelectedIndex = -1;
            }
        }

        private void FrmPosition_Load(object sender, EventArgs e)
        {
            departmentlist = DepartmentBLL.GetDepartments();
            cmbDepartment.DataSource = departmentlist;
            cmbDepartment.DisplayMember = "Department_Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
        }
    }
}
