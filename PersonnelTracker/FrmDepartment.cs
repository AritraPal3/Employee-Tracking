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
    public partial class FrmDepartment : Form
    {
        public FrmDepartment()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dpName.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the name field");
            }
            else {
                Department department = new Department();
                department.Department_Name = dpName.Text;
                BLL.DepartmentBLL.AddDepertment(department);
                MessageBox.Show("Department has been added successfully");
                dpName.Clear();
            }
        }
    }
}
