using BusinessLogicToDoList;
using System;
using System.Threading;

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
                    Console.WriteLine("2. Exit");
                    Console.WriteLine("Enter your choice (1 or 2): ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Task task = new Task();
                            Console.Write("Enter Task Name: ");
                            task.TaskName = Console.ReadLine();
                            Console.Write("Enter Duration (in hours): ");
                            task.Duration = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Enter Priority (High, Medium, Low): ");
                            task.Priority = Console.ReadLine();
                            Console.Write("Enter Due Date (yyyy-mm-dd): ");
                            task.DueDate = Convert.ToDateTime(Console.ReadLine());
                            task.Validate();
                            Console.WriteLine("Task added successfully.");
                            break;
                        case 2:
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
                } while (choice != 2);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }
    }
}
