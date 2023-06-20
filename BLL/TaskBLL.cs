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
    public class TaskBLL
    {
        public static void addTask(DAL.Task task)
        {
            TaskDAO.AddTask(task);
        }

        public static TaskDTO GetALL()
        {
            TaskDTO taskDto = new TaskDTO();
            taskDto.Employees=EmployeeDetailDAO.GetEmployee();
            taskDto.Departments=DepartmentDAO.GetDepartment();
            taskDto.Positions=PositionDAO.getPosition();
            taskDto.TaskStates = TaskDAO.getTaskStates();
            taskDto.Tasks = TaskDAO.GetTasks();
            return taskDto;
        }
    }
}
