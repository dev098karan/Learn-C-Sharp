using Microsoft.IdentityModel.Tokens;
using System;

namespace BusinessLogicToDoList
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int TimeRemaining { get; set; }
        public short TaskStatusId { get; set; }
        public DateTime DueDate { get; set; }
        public string TaskStatusName { get; set; }
        public bool IsDeleted { get; set; }

        public bool Validate()
        {
            if (TaskName.IsNullOrEmpty())
            {
                throw new Exception("Task Name is a required field.");
            }
            if (TimeRemaining <= 0)
            {
                throw new Exception("Required Time must be greater than zero.");
            }
            if(TaskStatusId <= 0)
            {
                throw new Exception("Status is a required field.");
            }
            return true;
        }
    }
}
