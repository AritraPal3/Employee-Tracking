using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Threading.Tasks;

namespace DAL.Data_Transfer_Obj
{
    public class EmployeeDTO
    {
        public List<Department>Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<EmployeeDetailDTO> Employess { get; set; }
    }
}
