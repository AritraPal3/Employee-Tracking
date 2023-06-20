using DAL.Data_Transfer_Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data_Access_Obj
{
    public class PermissionDAO : EmployeeContext
    {
        public static void AddPermission(Permission permission)
        {
            try
            {
                db.Permissions.InsertOnSubmit(permission);
                db.SubmitChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<PermissionDetailDTO> GetPermission()
        {
            List<PermissionDetailDTO> permission = new List<PermissionDetailDTO>();
            var list =(from p in db.Permissions
                       join s in db.PermissionStates on p.PermissionState equals s.ID
                       join e in db.Employees on p.EmployeeID equals e.ID
                       select new
                       {
                           UserNo=e.UserNo,
                           name=e.Name,
                           surname=e.Surname,
                           Statename=s.StateName,
                           stateID=p.PermissionState,
                           startdate=p.PermissionStartDate, 
                           enddate=p.PermissionEndDate,
                           EmployeeID=p.EmployeeID,
                           permissionID=p.ID,
                           explanation=p.PermissionExplanation,
                           dayamount=p.PermissionDay,
                           DepartmentID=e.DepartmentID,
                           positionID=e.PositionID
                       }).OrderBy(x=>x.startdate).ToList();
            foreach(var item in list)
            {
                PermissionDetailDTO detail = new PermissionDetailDTO();
                detail.UserNo = item.UserNo;
                detail.Name = item.name;
                detail.Surname = item.surname;
                detail.StateName = item.Statename;
                detail.State = item.stateID;
                detail.StartDate=item.startdate;
                detail.EndDate=item.enddate;
                detail.DepartmentID=item.DepartmentID;
                detail.PositionID=item.positionID;
                detail.PermissionDayAmount = item.dayamount;
                detail.Explanation = item.explanation;
                detail.EmployeeID = item.EmployeeID;
                permission.Add(detail);
            }

            return permission;
        }

        public static List<PermissionState> getPState()
        {
           return db.PermissionStates.ToList();
        }
    }
}
