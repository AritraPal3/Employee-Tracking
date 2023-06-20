using DAL.Data_Transfer_Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data_Access_Obj;
using DAL;

namespace BLL
{
    public class SalaryBLL
    {
        public static void AddSalary(Salary salary)
        {
            SalaryDAO.addSalary(salary);
        }

        public static SalaryDTO GetAll()
        {
            SalaryDTO dto= new SalaryDTO();
            dto.Employees = EmployeeDetailDAO.GetEmployee();
            dto.Departments=DepartmentDAO.GetDepartment();
            dto.Positions=PositionDAO.getPosition();
            dto.Months = SalaryDAO.GetMonths();
            dto.Salaries = SalaryDAO.getSalary();
            return dto;

        }
    }
}
