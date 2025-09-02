using BusinessLogicToDoList;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ToDoListDataAccessLayer
{
    public class DataAccessLayer
    {
        private SqlConnection CreateSqlConnectionAndOpenConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ToDoListConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void AddTask(Task task)
        {
            try
            {
                SqlConnection connection = CreateSqlConnectionAndOpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"SET DATEFORMAT dmy;INSERT INTO dbo.Tasks (TaskName, TimeRemaining, TaskStatusId, DueDate) VALUES (@TaskName, @TimeRemaining, @TaskStatusId, @DueDate)";
                command.Parameters.AddWithValue("@TaskName", task.TaskName);
                command.Parameters.AddWithValue("@TimeRemaining", task.TimeRemaining);
                command.Parameters.AddWithValue("@TaskStatusId", task.TaskStatusId);
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
                SqlConnection connection = CreateSqlConnectionAndOpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT t.TaskId, t.TaskName, ts.StatusName, t.TimeRemaining, t.DueDate FROM dbo.Tasks AS t INNER JOIN dbo.TaskStatus AS ts ON t.TaskStatusId = ts.StatusId";

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
                SqlConnection connection = CreateSqlConnectionAndOpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE dbo.Tasks SET TaskName = @TaskName, TimeRemaining = @TimeRemaining, TaskStatusId = @TaskStatusId, DueDate = @DueDate WHERE TaskId = @TaskId";
                command.Parameters.AddWithValue("@TaskName", updatedTask.TaskName);
                command.Parameters.AddWithValue("@TimeRemaining", updatedTask.TimeRemaining);
                command.Parameters.AddWithValue("@TaskStatusId", updatedTask.TaskStatusId);
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
                SqlConnection connection = CreateSqlConnectionAndOpenConnection();

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

        public DataSet GetAllTaskStatuses()
        {
            try
            {
                SqlConnection connection = CreateSqlConnectionAndOpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT StatusId, StatusName FROM dbo.TaskStatus";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet taskStatuses = new DataSet();
                adapter.Fill(taskStatuses);

                connection.Close();

                return taskStatuses;
            }
            catch (Exception exception)
            {
                throw new Exception($"Error while retrieving task statuses from the database: {exception.Message}");
            }
        }
    }
}