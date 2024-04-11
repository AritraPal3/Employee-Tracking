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
using DAL.Data_Transfer_Obj;

namespace PetsonnelTracker
{
    public partial class FrmEmployeeList : Form
    {
        public FrmEmployeeList()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        EmployeeDTO dto = new EmployeeDTO();
        private bool combofull=false;

        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            dto = EmployeeBLL.GetAll();
            dataGridView1.DataSource = dto.Employess;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].HeaderText = "Department";
            dataGridView1.Columns[5].HeaderText = "Position";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Salary";
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            combofull = false;
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "Department_Name";
            cmbDepartment.ValueMember = "ID";
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "Position_Name";
            cmbPosition.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            combofull = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmEmployee frm= new FrmEmployee();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmEmployee frm = new FrmEmployee();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combofull)
            {
                cmbPosition.DataSource=dto.Positions.Where(x=>x.Department_ID==Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
                cmbPosition.SelectedIndex = -1;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<EmployeeDetailDTO> list = dto.Employess;
            if(txtUserNo.Text.Trim()!="")
                list=list.Where(x=>x.UserNo==Convert.ToInt32(txtUserNo.Text.Trim())).ToList();
            if(txtName.Text.Trim()!="")
                list=list.Where(x=>x.Name.Contains(txtName.Text)).ToList();
            if(txtSurname.Text.Trim()!="")
                list=list.Where(x=>x.Surname.Contains(txtSurname.Text)).ToList();
            if(cmbDepartment.SelectedIndex!=-1)
                list=list.Where(x=>x.DepartmentID==Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            if(cmbPosition.SelectedIndex!=-1)
                list=list.Where(x=>x.PositionID==Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            dataGridView1.DataSource=list;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            combofull = false;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.SelectedIndex = -1;
            combofull=true;
            dataGridView1.DataSource = dto.Employess;
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
