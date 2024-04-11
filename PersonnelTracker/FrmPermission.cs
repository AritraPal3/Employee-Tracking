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
    public partial class FrmPermission : Form
    {
        public FrmPermission()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        TimeSpan PermssionDay;
        private void FrmPermission_Load(object sender, EventArgs e)
        {

        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            txtUserNo.Text = UserStatic.UserNo.ToString();
            PermssionDay = dtEnd.Value.Date - dtStart.Value.Date;
            txtDayAmount.Text = PermssionDay.TotalDays.ToString();
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            txtUserNo.Text = UserStatic.UserNo.ToString();
            PermssionDay = dtEnd.Value.Date - dtStart.Value.Date;
            txtDayAmount.Text = PermssionDay.TotalDays.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDayAmount.Text.Trim() == "")
                MessageBox.Show("Please Change end or start date");
            else if (Convert.ToInt32(txtDayAmount.Text) <= 0)
                MessageBox.Show("Permissiom day must be bigger than 0 ");
            else if (txtExp.Text.Trim() == "")
                MessageBox.Show("Explanantion is empty");
            else
            {
                Permission permission = new Permission();
                permission.EmployeeID = UserStatic.EmployeeID;
                permission.PermissionState = 1;
                permission.PermissionStartDate= dtStart.Value.Date;
                permission.PermissionEndDate= dtEnd.Value.Date;
                permission.PermissionDay=Convert.ToInt32(txtDayAmount.Text);
                permission.PermissionExplanation = txtExp.Text;
                PermissionBLL.AddPermission(permission);
                MessageBox.Show("Permssion has been added");
                permission=new Permission();
                dtStart.Value= DateTime.Now;
                dtEnd.Value= DateTime.Now;
                txtDayAmount.Clear();
                txtExp.Clear();
            }
        }
    }
}
