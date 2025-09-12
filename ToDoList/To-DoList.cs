using BusinessLogicToDoList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using ToDoListDataAccessLayer;

namespace ToDoList
{
    public partial class formToDoList : Form
    {
        private List<Task> tasks = new List<Task>();
        private DataAccessLayer dataAccessLayer = new DataAccessLayer();
        private Task selectedTask = new Task();
        public formToDoList()
        {
            InitializeComponent();
        }

        private void fillTaskStatusComboBox()
        {
            try
            {
                DataAccessLayer dataAccessLayer = new DataAccessLayer();
                DataSet taskStatuses = dataAccessLayer.GetAllTaskStatuses();
                cBoxStatus.DisplayMember = "StatusName";
                cBoxStatus.ValueMember = "StatusId";
                cBoxStatus.DataSource = taskStatuses.Tables[0];
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error while loading task statuses: {exception.Message}");
            }
        }

        private void resetToDoListForm()
        {
            lblSelectedTaskIdValue.Text = "N/A";
            txtTaskName.Text = string.Empty;
            txtTimeRemaining.Text = "00:00:00";
            cBoxStatus.SelectedIndex = -1;
            dueDatePicker.Value = DateTime.Now.AddDays(1);
            txtTaskName.Focus();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                Task task = new Task();
                task.TaskName = txtTaskName.Text;
                task.TimeRemaining = Convert.ToInt32(TimeSpan.ParseExact(txtTimeRemaining.Text, "hh\\:mm\\:ss", null).TotalSeconds);
                task.TaskStatusId = Convert.ToInt16(cBoxStatus.SelectedValue);
                task.DueDate = dueDatePicker.Value;

                if (task.Validate())
                {
                    tasks.Add(task);
                    loadTasksListView(tasks);
                };

                ToastNotification.Show("Task Added Successfully!");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error while adding task: {exception.Message}");
            }
            finally
            {
                resetToDoListForm();
            }
        }

        private void txtTimeRemaining_Leave(object sender, EventArgs e)
        {
            if (!DateTime.TryParseExact(txtTimeRemaining.Text, "HH:mm:ss",
                                null,
                                System.Globalization.DateTimeStyles.None,
                                out _))
            {
                MessageBox.Show("Please enter a valid time in hh:mm:ss format.");
                txtTimeRemaining.Focus();
                txtTimeRemaining.Text = "00:00:00";
            }
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            try
            {
                selectedTask.TaskName = txtTaskName.Text;
                selectedTask.TimeRemaining = Convert.ToInt32(TimeSpan.ParseExact(txtTimeRemaining.Text, "hh\\:mm\\:ss", null).TotalSeconds);
                selectedTask.TaskStatusId = Convert.ToInt16(cBoxStatus.SelectedValue);
                selectedTask.DueDate = dueDatePicker.Value;

                if (selectedTask.Validate())
                {
                    loadTasksListView(tasks);
                }

                ToastNotification.Show("Task Updated Successfully!");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error while updating task: {exception.Message}");
            }
            finally
            {
                resetToDoListForm();
            }
        }

        private void tasksListView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedTask = tasks[e.RowIndex];
            lblSelectedTaskIdValue.Text = selectedTask.TaskId.ToString();
            txtTaskName.Text = selectedTask.TaskName;
            cBoxStatus.Text = selectedTask.TaskStatusName;
            txtTimeRemaining.Text = TimeSpan.FromSeconds(Convert.ToInt32(selectedTask.TimeRemaining)).ToString(@"hh\:mm\:ss");
            dueDatePicker.Value = Convert.ToDateTime(selectedTask.DueDate);
        }

        private void loadTasksListView(List<Task> tasks)
        {
            try
            {
                DataTable tasksTable = new DataTable();
                tasksTable.Columns.Add("Task Id", typeof(int));
                tasksTable.Columns.Add("Task Name", typeof(string));
                tasksTable.Columns.Add("Status Id", typeof(int));
                tasksTable.Columns.Add("Task Status", typeof(string));
                tasksTable.Columns.Add("Time Remaining", typeof(string));
                tasksTable.Columns.Add("Due Date", typeof(DateTime));
                tasksTable.Columns.Add("Is Deleted", typeof(bool));

                foreach (Task task in tasks)
                {
                    DataRow taskRow = tasksTable.NewRow();
                    taskRow["Task Id"] = task.TaskId;
                    taskRow["Task Name"] = task.TaskName;
                    taskRow["Status Id"] = task.TaskStatusId;
                    taskRow["Task Status"] = task.TaskStatusName;
                    taskRow["Time Remaining"] = TimeSpan.FromSeconds(Convert.ToInt32(task.TimeRemaining)).ToString(@"hh\:mm\:ss");
                    taskRow["Due Date"] = Convert.ToDateTime(task.DueDate);
                    taskRow["Is Deleted"] = task.IsDeleted;
                    tasksTable.Rows.Add(taskRow);
                }

                tasksListView.DataSource = tasksTable;

                this.tasksListView.Columns["Task Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tasksListView.Columns["Task Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.tasksListView.Columns["Status Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tasksListView.Columns["Task Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tasksListView.Columns["Time Remaining"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tasksListView.Columns["Due Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tasksListView.Columns["Is Deleted"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error while loading tasks: {exception.Message}");
            }
        }

        private void formToDoList_Load(object sender, EventArgs e)
        {
            this.Text = ConfigurationManager.AppSettings["ApplicationName"].ToString();
            btnSaveAll.Text = ConfigurationManager.AppSettings["SaveAllButton"].ToString();
            btnAddTask.Text = ConfigurationManager.AppSettings["AddTaskButton"].ToString();
            btnUpdateTask.Text = ConfigurationManager.AppSettings["UpdateTaskButton"].ToString();
            btnDeleteTask.Text = ConfigurationManager.AppSettings["DeleteTaskButton"].ToString();

            fillTaskStatusComboBox();

            tasks = dataAccessLayer.GetAllTasks();
            loadTasksListView(tasks);

            resetToDoListForm();
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                selectedTask.IsDeleted = true;
                loadTasksListView(tasks);

                ToastNotification.Show("Task Deleted Successfully!");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error while deleting task: {exception.Message}");
            }
            finally
            {
                resetToDoListForm();
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                dataAccessLayer.SaveAllTasks(tasks);
                loadTasksListView(dataAccessLayer.GetAllTasks());

                ToastNotification.Show("All Tasks Saved Successfully!");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error while saving tasks: {exception.Message}");
            }
            finally
            {
                resetToDoListForm();
            }
        }
    }
}
