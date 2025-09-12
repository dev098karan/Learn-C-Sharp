using BetterConsoleTables;
using BusinessLogicToDoList;
using System;
using System.Collections.Generic;
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
                DataAccessLayer dataAccessLayer = new DataAccessLayer();
                List<Task> tasks = dataAccessLayer.GetAllTasks();
                do
                {
                    Table tasksTable = new Table("Task Id", "Task Name", "Status Id", "Task Status", "Time Remaining", "Due Date", "Is Deleted");
                    Task selectedTask = new Task();

                    foreach (Task task in tasks)
                    {
                        tasksTable.AddRow(task.TaskId,
                            task.TaskName,
                            task.TaskStatusId,
                            task.TaskStatusName ?? "",
                            TimeSpan.FromSeconds(Convert.ToInt32(task.TimeRemaining)).ToString(@"hh\:mm\:ss"),
                            Convert.ToDateTime(task.DueDate),
                            task.IsDeleted);
                    }
                    Console.WriteLine(tasksTable.ToString());

                    Console.WriteLine("1. Add a Task");
                    Console.WriteLine("2. Update a Task");
                    Console.WriteLine("3. Delete a Task");
                    Console.WriteLine("4. Save Changes");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("- - - - - - - - - - - - - - - -");
                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Task task = new Task();
                            Console.Write("Enter Task Name: ");
                            task.TaskName = Console.ReadLine();
                            Console.Write("Enter Time Required (hh:mm:ss): ");
                            task.TimeRemaining = Convert.ToInt32(TimeSpan.ParseExact(Console.ReadLine(), "hh\\:mm\\:ss", null).TotalSeconds);
                            Console.Write("Enter Status Id (1 - ToDo, 2 - InProgress, 3 - Done): ");
                            task.TaskStatusId = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Enter Due Date (yyyy-mm-dd): ");
                            task.DueDate = Convert.ToDateTime(Console.ReadLine());
                            if (task.Validate())
                            {
                                tasks.Add(task);
                            };
                            Console.WriteLine("Task added successfully.");
                            break;
                        case 2:
                            Console.Write("Enter Row Index to update: ");
                            selectedTask = tasks[Convert.ToInt32(Console.ReadLine())];
                            Console.Write("Enter Updated Task Name: ");
                            selectedTask.TaskName = Console.ReadLine();
                            Console.Write("Enter Updated Time Required (hh:mm:ss): ");
                            selectedTask.TimeRemaining = Convert.ToInt32(TimeSpan.ParseExact(Console.ReadLine(), "hh\\:mm\\:ss", null).TotalSeconds);
                            Console.Write("Enter Updated Status Id (1 - ToDo, 2 - InProgress, 3 - Done): ");
                            selectedTask.TaskStatusId = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Enter Updated Due Date (yyyy-mm-dd): ");
                            selectedTask.DueDate = Convert.ToDateTime(Console.ReadLine());
                            selectedTask.Validate();
                            Console.WriteLine("Task updated successfully.");
                            break;
                        case 3:
                            Console.Write("Enter Row Index to delete: ");
                            selectedTask = tasks[Convert.ToInt32(Console.ReadLine())];
                            selectedTask.IsDeleted = true;
                            Console.WriteLine("Task deleted successfully.");
                            break;
                        case 4:
                            dataAccessLayer.SaveAllTasks(tasks);
                            tasks = dataAccessLayer.GetAllTasks();
                            Console.WriteLine("All changes saved to the database.");
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
