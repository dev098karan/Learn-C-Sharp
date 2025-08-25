using Microsoft.IdentityModel.Tokens;
using System;

namespace BusinessLogicToDoList
{
    public class Task
    {
        public int TaskId { get; }
        public string TaskName { get; set; }
        public int TimeRemaining { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }

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
            return true;
        }
    }

    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }
}
