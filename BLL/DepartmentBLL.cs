using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data_Access_Obj;

namespace BLL
{
    public class DepartmentBLL
    {
        public static void AddDepertment(Department department)
        {
            DepartmentDAO.AddDepartment(department);
        }

        public static List<Department> GetDepartments()
        {
            return DepartmentDAO.GetDepartment();
        }
    }
}
