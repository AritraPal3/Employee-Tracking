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
    public class EmployeeBLL
    {
        public static void AddEmployee(Employee emp)
        {
            EmployeeDetailDAO.AddEmployee(emp);
        }

        public static EmployeeDTO GetAll()
        {
            EmployeeDTO dto = new EmployeeDTO();
            dto.Departments = DepartmentDAO.GetDepartment();
            dto.Positions=PositionDAO.getPosition();
            dto.Employess = EmployeeDetailDAO.GetEmployee();
            return dto;
        }

        public static List<Employee> GetEmployees(int v, string text)
        {
            return EmployeeDetailDAO.GetEmployee(v, text);
        }

        public static bool isUnique(int v)
        {
            List<Employee> list = EmployeeDetailDAO.GetUsers(v);
            if(list.Count > 0) { return false; }
            return true;
        }
    }
}
