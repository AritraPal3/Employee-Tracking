using DAL.Data_Transfer_Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data_Access_Obj
{
    public class EmployeeDetailDAO : EmployeeContext
    {
        public static void AddEmployee(Employee emp)
        {
            try
            {
                db.Employees.InsertOnSubmit(emp);
                db.SubmitChanges();

            }
            catch(Exception ex) { throw ex; }
        }

        public static List<EmployeeDetailDTO> GetEmployee()
        {
            List<EmployeeDetailDTO> employeeList = new List<EmployeeDetailDTO>();
            var list = (from e in db.Employees
                        join d in db.Departments on e.DepartmentID equals d.ID
                        join p in db.Positions on e.PositionID equals p.ID
                        select new
                        {
                            UserNo= e.UserNo,
                            Name= e.Name,
                            SurName=e.Surname,
                            EmployeeID=e.ID,
                            Password=e.Password,
                            DepartmentName=d.Department_Name,
                            PositionName=p.Position_Name,
                            DepartmentID=e.DepartmentID,
                            PositionID=e.PositionID,
                            isAdmin=e.isAdmin,
                            Salary=e.Salaray,
                            ImagePath=e.ImagePath,
                            Address=e.Adress,
                            birthday=e.BirthDay
                        }).OrderBy(x=>x.UserNo).ToList();

            foreach( var item in list )
            {
                EmployeeDetailDTO dto = new EmployeeDetailDTO();
                dto.UserNo = item.UserNo;
                dto.Name = item.Name;
                dto.Password = item.Password;
                dto.Surname = item.SurName;
                dto.EmployeeID = item.EmployeeID;
                dto.ImagePath = item.ImagePath;
                dto.DepartmentName = item.DepartmentName;
                dto.DepartmentID = item.DepartmentID;
                dto.PositionName = item.PositionName;
                dto.Adress = item.Address;    
                dto.isAdmin = item.isAdmin;
                dto.Salary = item.Salary;
                dto.Birthday = item.birthday;
                employeeList.Add(dto);

            }

            return employeeList;
        }

        public static List<Employee> GetEmployee(int v, string text)
        {
            try
            {
                List<Employee> list = db.Employees.Where(x => x.UserNo == v && x.Password == text).ToList();
                return list;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public static List<Employee> GetUsers(int v)
        {
            return db.Employees.Where(x=>x.UserNo==v).ToList();
        }
    }
}
