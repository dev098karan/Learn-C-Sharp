using System;

namespace BusinessLogicToDoList
{
    public class Task
    {
        public string TaskName { get; set; }
        public short Duration { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }

        public void Validate()
        {
            if (TaskName.Length == 0)
            {
                throw new Exception("Task Name ia a required field.");
            }
            if (Duration <= 0)
            {
                throw new Exception("Duration must be greater than zero.");
            }
        }
    }
}
