using BusinessLogicToDoList;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ToDoListDataAccessLayer
{
    public class DataAccessLayer
    {
        public void AddTask(BusinessLogicToDoList.Task task)
        {
            try
            {
                string connectionString = "Data Source=KARANDEV\\SQLEXPRESS;Initial Catalog=ToDoListDB;User ID=sa;Password=DBpassword;TrustServerCertificate=True";
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"SET DATEFORMAT dmy;INSERT INTO dbo.Tasks (TaskName, TimeRemaining, Status, DueDate) VALUES (@TaskName, @TimeRemaining, @Status, @DueDate)";
                command.Parameters.AddWithValue("@TaskName", task.TaskName);
                command.Parameters.AddWithValue("@TimeRemaining", task.TimeRemaining);
                command.Parameters.AddWithValue("@Status", Convert.ToByte(task.Status));
                command.Parameters.AddWithValue("@DueDate", task.DueDate);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception exception)
            {
                throw new Exception($"Error while adding task to the database: {exception.Message}");
            }
        }

        public DataSet GetAllTasks()
        {
            try
            {
                string connectionString = "Data Source=KARANDEV\\SQLEXPRESS;Initial Catalog=ToDoListDB;User ID=sa;Password=DBpassword;TrustServerCertificate=True";
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT TaskId, TaskName, Status, TimeRemaining, DueDate FROM dbo.Tasks";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet tasks = new DataSet();
                adapter.Fill(tasks);

                connection.Close();

                return tasks;
            }
            catch(Exception exception)
            {
                throw new Exception($"Error while retrieving tasks from the database: {exception.Message}");
            }
        }

        public void UpdateTask(int taskId, Task updatedTask)
        {
            try
            {
                string connectionString = "Data Source=KARANDEV\\SQLEXPRESS;Initial Catalog=ToDoListDB;User ID=sa;Password=DBpassword;TrustServerCertificate=True";
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE dbo.Tasks SET TaskName = @TaskName, TimeRemaining = @TimeRemaining, Status = @Status, DueDate = @DueDate WHERE TaskId = @TaskId";
                command.Parameters.AddWithValue("@TaskName", updatedTask.TaskName);
                command.Parameters.AddWithValue("@TimeRemaining", updatedTask.TimeRemaining);
                command.Parameters.AddWithValue("@Status", Convert.ToByte(updatedTask.Status));
                command.Parameters.AddWithValue("@DueDate", updatedTask.DueDate);
                command.Parameters.AddWithValue("@TaskId", taskId);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception exception)
            {
                throw new Exception($"Error while updating task in the database: {exception.Message}");
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                string connectionString = "Data Source=KARANDEV\\SQLEXPRESS;Initial Catalog=ToDoListDB;User ID=sa;Password=DBpassword;TrustServerCertificate=True";
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM dbo.Tasks WHERE TaskId = @TaskId";
                command.Parameters.AddWithValue("@TaskId", taskId);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception exception)
            {
                throw new Exception($"Error while deleting task from the database: {exception.Message}");
            }
        }
    }
}