using System;
using System.Data.SqlClient;

namespace ToDoListDataAccessLayer
{
    public class DataAccessLayer
    {
        public bool AddTask(BusinessLogicToDoList.Task task)
        {
            try
            {
                string connectionString = "Data Source=KARANDEV\\SQLEXPRESS;Initial Catalog=ToDoListDB;User ID=sa;Password=DBpassword;TrustServerCertificate=True";
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"SET DATEFORMAT dmy;INSERT INTO dbo.Tasks (TaskName, TimeRemaining, Status, DueDate) VALUES ('{task.TaskName}', {task.TimeRemaining}, '{(int)task.Status}', '{task.DueDate}')";
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch(Exception exception)
            {
                return false;
            }
        }
    }
}