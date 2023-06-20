using DAL.Data_Transfer_Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data_Access_Obj
{
    public class SalaryDAO : EmployeeContext
    {
        public static void addSalary(Salary salary)
        {
            try
            {
                db.Salaries.InsertOnSubmit(salary);
                db.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<Month> GetMonths()
        {
            return db.Months.ToList();
        }

        public static List<SalaryDetailDTO> getSalary()
        {
            List<SalaryDetailDTO> salarylist = new List<SalaryDetailDTO>();
            var list = (from s in db.Salaries
                        join e in db.Employees on s.EmployeeID equals e.ID
                        join m in db.Months on s.MonthID equals m.ID

                        select new
                        {
                            UserNo = e.UserNo,
                            name= e.Name,
                            surname= e.Surname,
                            EmployeeID=s.EmployeeID,
                            amount=s.Amount,
                            year=s.Year,
                            monthName=m.MonthName,
                            monthID=s.MonthID,
                            salaryID=s.ID,
                            DepartmentID=e.DepartmentID,
                            positionID=e.PositionID
                        }).OrderBy(x=>x.year).ToList();
            foreach(var item in list)
            {
                SalaryDetailDTO dto=new SalaryDetailDTO();
                dto.UserNo = item.UserNo;
                dto.Name = item.name;
                dto.Surname = item.surname;
                dto.EmployeeID = item.EmployeeID;
                dto.SalaryAmount = item.amount;
                dto.SalaryYear = item.year;
                dto.MonthName=item.monthName;
                dto.MonthID=item.monthID;
                dto.SalaryID = item.salaryID;
                dto.PositionID=item.positionID;
                dto.OldSalary = item.amount;
                salarylist.Add(dto);
            }

            return salarylist;
        }
    }
}
