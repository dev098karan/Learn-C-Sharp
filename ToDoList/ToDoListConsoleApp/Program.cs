using BusinessLogicToDoList;
using System;
using System.Data;
using System.Threading;
using ToDoListDataAccessLayer;

namespace ToDoListConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int choice;
                do
                {
                    Console.WriteLine("- - - - - - - - - - - - - - - -");
                    Console.WriteLine("1. Add a Task");
                    Console.WriteLine("2. View All Tasks");
                    Console.WriteLine("3. Update a Task");
                    Console.WriteLine("4. Delete a Task");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    DataAccessLayer dataAccessLayer = new DataAccessLayer();
                    Task task = new Task();

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Task Name: ");
                            task.TaskName = Console.ReadLine();
                            Console.Write("Enter Time Required (hh:mm:ss): ");
                            task.TimeRemaining = Convert.ToInt32(TimeSpan.ParseExact(Console.ReadLine(), "hh\\:mm\\:ss", null).TotalSeconds);
                            Console.Write("Enter Status (ToDo, InProgress, Done): ");
                            task.Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), Console.ReadLine());
                            Console.Write("Enter Due Date (yyyy-mm-dd): ");
                            task.DueDate = Convert.ToDateTime(Console.ReadLine());
                            if (task.Validate())
                            {
                                dataAccessLayer.AddTask(task);
                            };
                            Console.WriteLine("Task added successfully.");
                            break;
                        case 2:
                            DataSet tasks = dataAccessLayer.GetAllTasks();
                            foreach (DataRow row in tasks.Tables[0].Rows)
                            {
                                Console.Write($"Task Id: {row["TaskId"]}, ");
                                Console.Write($"Task Name: {row["TaskName"]}, ");
                                Console.Write($"Status: {((TaskStatus)Convert.ToByte(row["Status"])).ToString()}, ");
                                Console.Write($"Time Remaining: {TimeSpan.FromSeconds(Convert.ToInt32(row["TimeRemaining"])).ToString(@"hh\:mm\:ss")}, ");
                                Console.WriteLine($"Due Date: {Convert.ToDateTime(row["DueDate"])}");
                            }
                            break;
                        case 3:
                            Console.Write("Enter Task Id to update: ");
                            int taskIdToUpdate = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Updated Task Name: ");
                            task.TaskName = Console.ReadLine();
                            Console.Write("Enter Updated Time Required (hh:mm:ss): ");
                            task.TimeRemaining = Convert.ToInt32(TimeSpan.ParseExact(Console.ReadLine(), "hh\\:mm\\:ss", null).TotalSeconds);
                            Console.Write("Enter Updated Status (ToDo, InProgress, Done): ");
                            task.Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), Console.ReadLine());
                            Console.Write("Enter Updated Due Date (yyyy-mm-dd): ");
                            task.DueDate = Convert.ToDateTime(Console.ReadLine());
                            if (task.Validate())
                            {
                                dataAccessLayer.UpdateTask(taskIdToUpdate, task);
                            }
                            Console.WriteLine("Task updated successfully.");
                            break;
                        case 4:
                            Console.Write("Enter Task Id to delete: ");
                            int taskIdToDelete = Convert.ToInt32(Console.ReadLine());
                            dataAccessLayer.DeleteTask(taskIdToDelete);
                            Console.WriteLine("Task deleted successfully.");
                            break;
                        case 5:
                            Console.Write("Exiting the application");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(1000);
                            break;
                        default:
                            Console.WriteLine("Incorrect Choice. Please try again.");
                            break;
                    }
                } while (choice != 5);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }
    }
}
