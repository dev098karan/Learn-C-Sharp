using BusinessLogicToDoList;
using System;
using System.Collections.Generic;
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
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertTask";
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

        public List<Task> GetAllTasks()
        {
            try
            {
                List<Task> tasks = new List<Task>();
                SqlConnection connection = CreateSqlConnectionAndOpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllTasks";

                SqlDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    Task task = new Task();
                    task.TaskId = Convert.ToInt32(dataReader["TaskId"]);
                    task.TaskName = dataReader["TaskName"].ToString();
                    task.TaskStatusName = dataReader["StatusName"].ToString();
                    task.TimeRemaining = Convert.ToInt32(dataReader["TimeRemaining"]);
                    task.DueDate = Convert.ToDateTime(dataReader["DueDate"]);
                    tasks.Add(task);
                }

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
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateTask";
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
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteTask";
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
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllTaskStatuses";

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

        public void SaveAllTasks(List<Task> tasks)
        {
            try
            {
                foreach (Task task in tasks)
                {
                    if (task.IsDeleted)
                    {
                        DeleteTask(task.TaskId);
                    }
                    else
                    {
                        if (task.TaskId > 0)
                        {
                            UpdateTask(task.TaskId, task);
                        }
                        else
                        {
                            AddTask(task);
                        }
                    }
                }
            }
            catch(Exception exception)
            {
                throw new Exception($"Error while saving tasks to the database: {exception.Message}");
            }
        }
    }
}