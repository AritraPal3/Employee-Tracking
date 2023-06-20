using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data_Access_Obj;
using DAL.Data_Transfer_Obj;

namespace BLL
{
    public class PermissionBLL
    {
        public static void AddPermission(Permission permission)
        {
            PermissionDAO.AddPermission(permission);
        }

        public static PermssionDTO GetAll()
        {
            PermssionDTO dto= new PermssionDTO();
            dto.Departments = DepartmentDAO.GetDepartment();
            dto.Positions=PositionDAO.getPosition();
            dto.States = PermissionDAO.getPState();
            dto.Permissions = PermissionDAO.GetPermission();
            return dto;
        }
    }
}
