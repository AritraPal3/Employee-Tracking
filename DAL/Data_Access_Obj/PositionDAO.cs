using DAL.Data_Transfer_Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data_Access_Obj
{
    public class PositionDAO : EmployeeContext
    {
        public static void addPosition(Position position)
        {
            try
            {
                db.Positions.InsertOnSubmit(position);
                db.SubmitChanges();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public static List<PositionDTO> getPosition()
        {
            try
            {
                var list = (from p in db.Positions
                            join d in db.Departments on p.Department_ID equals d.ID
                            select new
                            {
                                PositionID = p.ID,
                                PositionName = p.Position_Name,
                                DepartmentName = d.Department_Name,
                                DepartmentId = p.Department_ID
                            }
                 ).OrderBy( x => x.PositionID ).ToList();

                List<PositionDTO> positionList= new List<PositionDTO>();
                foreach( var item in list ) 
                {
                    PositionDTO dto = new PositionDTO();
                    dto.ID = item.PositionID;
                    dto.Position_Name = item.PositionName;
                    dto.DepartmentName = item.DepartmentName;
                    dto.Department_ID = item.DepartmentId;
                    positionList.Add( dto );
                }
                return positionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
