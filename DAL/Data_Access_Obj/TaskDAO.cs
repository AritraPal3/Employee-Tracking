using DAL.Data_Transfer_Obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data_Access_Obj
{
    public class TaskDAO : EmployeeContext
    {
        public static void AddTask(Task task)
        {
            try
            {
                db.Tasks.InsertOnSubmit(task);
                db.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<TaskDetailDTO> GetTasks()
        {
            List<TaskDetailDTO> tasklist = new List<TaskDetailDTO>();

            var list = (from t in db.Tasks
                        join s in db.TaskStates on t.TaskState equals s.ID
                        join e in db.Employees on t.EmployeeID equals e.ID
                        join d in db.Departments on e.DepartmentID equals d.ID
                        join p in db.Positions on e.PositionID equals p.ID
                        select new
                        {
                            taskID = t.ID,
                            title=t.TaskTitle,
                            content=t.TaskContent,
                            startdate=t.TaskStartDate,
                            deliverydate=t.TaskDeliveryDate,
                            taskStateName=s.StateName,
                            taskStateID=t.TaskState,
                            UserNo=e.UserNo,
                            Name=e.Name,
                            EmploueeID=t.EmployeeID,
                            Surname=e.Surname,
                            positionName=p.Position_Name,
                            departmentName=d.Department_Name,
                            positionID=e.PositionID,
                            departmentID=e.DepartmentID
                        }).OrderBy(x=>x.startdate).ToList();

            foreach (var item in list)
            {
                TaskDetailDTO dto = new TaskDetailDTO();
                dto.TaskID=item.taskID;
                dto.Title=item.title;
                dto.Content=item.content;
                dto.TaskStartDate = item.startdate;
                dto.TaskDeliveryDate = item.deliverydate;
                dto.TaskStateName = item.taskStateName;
                dto.TaskStateID=item.taskStateID;
                dto.UserNo = item.UserNo;
                dto.Name=item.Name;
                dto.Surname=item.Surname;
                dto.DepartmentName = item.departmentName;
                dto.PositionID=item.positionID;
                dto.PositionName = item.positionName;
                dto.EmployeeID = item.EmploueeID;
                tasklist.Add(dto);
            }

            return tasklist;
        }

        public static List<TaskState> getTaskStates()
        {
            return db.TaskStates.ToList();
        }
    }
}
