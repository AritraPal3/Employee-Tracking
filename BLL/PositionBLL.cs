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
    public class PositionBLL
    {
        public static void addPosition(Position position)
        {
            PositionDAO.addPosition(position);
        }

        public static List<PositionDTO> getPosition()
        {
            return PositionDAO.getPosition();
        }
    }
}
