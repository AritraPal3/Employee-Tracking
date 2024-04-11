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
using System.IO;

namespace PetsonnelTracker
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }
        EmployeeDTO dto = new EmployeeDTO();
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            dto = EmployeeBLL.GetAll();
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "Department_Name";
            cmbDepartment.ValueMember = "ID";
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "Position_Name";
            cmbPosition.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            combofull=true;
        }
        bool combofull = false;
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                int departmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbPosition.DataSource = dto.Positions.Where(x => x.Department_ID == departmentId).ToList();
            }
        }
        string fileName = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                pictureBox1.Load(openFileDialog1.FileName);
                textBox5.Text = openFileDialog1.FileName;
                string unique=Guid.NewGuid().ToString();
                fileName += unique + openFileDialog1.SafeFileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
                MessageBox.Show("User No. is Empty");
            else if (!EmployeeBLL.isUnique(Convert.ToInt32(textUserNo.Text)))
                MessageBox.Show("This user no is already used by another employee please change ");
            else if (txtPassword.Text.Trim() == "")
                MessageBox.Show("Password is Empty");
            else if (textName.Text.Trim() == "")
                MessageBox.Show("Name is Empty");
            else if (textSurname.Text.Trim() == "")
                MessageBox.Show("Surname is Empty");
            else if (textSalary.Text.Trim() == "")
                MessageBox.Show("Salary is Empty");
            else if(cmbDepartment.SelectedIndex == -1)
                MessageBox.Show("Selectt a Department ");
            else if(cmbPosition.SelectedIndex == -1)
                MessageBox.Show("Selectt a Position ");
            else
            {
                Employee emp=new Employee();
                emp.UserNo=Convert.ToInt32(textUserNo.Text);
                emp.Password=txtPassword.Text;
                emp.isAdmin=ckbAdmin.Checked;
                emp.Name=textName.Text;
                emp.Surname = textSurname.Text;
                emp.Salaray=Convert.ToInt32(textSalary.Text);
                emp.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                emp.PositionID = Convert.ToInt32(cmbPosition.SelectedValue);
                emp.Adress=textAddress.Text;
                emp.BirthDay = dateTimePicker1.Value;
                emp.ImagePath = fileName;
                EmployeeBLL.AddEmployee(emp);
                File.Copy(textBox5.Text, @"images\\" + fileName);
                MessageBox.Show("Employee was Added");
                txtPassword.Clear();
                textUserNo.Clear();
                textName.Clear();
                textSurname.Clear();
                textSalary.Clear();
                ckbAdmin.Checked = false;
                cmbDepartment.SelectedIndex = -1;
                textBox5.Clear();
                pictureBox1.Image = null;
                combofull = false;
                cmbPosition.DataSource = dto.Positions;
                cmbPosition.SelectedIndex = -1;
                cmbDepartment.DataSource = dto.Departments;
                combofull = true;
                dateTimePicker1.Value = DateTime.Now;
                textAddress.Clear();
            }
        }
        bool isUnique = false; 
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (textUserNo.Text.Trim() == "")
                MessageBox.Show("User No. is Empty");
            else 
            {
                isUnique = EmployeeBLL.isUnique(Convert.ToInt32(textUserNo.Text));
                if (!isUnique)
                    MessageBox.Show("This user no is already used by another employee please change ");
                else
                    MessageBox.Show("This user no is usable");
            }
        }
    }
}
