using BusinessLogicToDoList;
using System;
using System.Data;
using System.Security.Policy;
using System.Windows.Forms;
using ToDoListDataAccessLayer;

namespace ToDoList
{
    public partial class formToDoList : Form
    {
        public formToDoList()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                Task task = new Task();
                task.TaskName = txtTaskName.Text;
                task.TimeRemaining = Convert.ToInt32(TimeSpan.ParseExact(txtTimeRemaining.Text, "hh\\:mm\\:ss", null).TotalSeconds);
                task.Status = (TaskStatus)cBoxStatus.SelectedIndex;
                task.DueDate = dueDatePicker.Value;

                if (task.Validate())
                {
                    DataAccessLayer dataAccessLayer = new DataAccessLayer();
                    dataAccessLayer.AddTask(task);
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
                Task updatedTask = new Task();
                updatedTask.TaskName = txtTaskName.Text;
                updatedTask.TimeRemaining = Convert.ToInt32(TimeSpan.ParseExact(txtTimeRemaining.Text, "hh\\:mm\\:ss", null).TotalSeconds);
                updatedTask.Status = (TaskStatus)cBoxStatus.SelectedIndex;
                updatedTask.DueDate = dueDatePicker.Value;

                if (updatedTask.Validate())
                {
                    DataAccessLayer dataAccessLayer = new DataAccessLayer();
                    dataAccessLayer.UpdateTask(Convert.ToInt32(lblSelectedTaskIdValue.Text), updatedTask);
                }

                ToastNotification.Show("Task Updated Successfully!");
            }
            catch(Exception exception)
            {
                MessageBox.Show($"Error while updating task: {exception.Message}");
            }
            finally
            {
                resetToDoListForm();
            }
        }

        private void resetToDoListForm()
        {
            lblSelectedTaskIdValue.Text = "N/A";
            txtTaskName.Text = string.Empty;
            txtTimeRemaining.Text = "00:00:00";
            cBoxStatus.SelectedIndex = 0;
            dueDatePicker.Value = DateTime.Now.AddDays(1);
        }

        private void tasksListView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblSelectedTaskIdValue.Text = tasksListView.Rows[e.RowIndex].Cells["Task Id"].Value.ToString();
            txtTaskName.Text = tasksListView.Rows[e.RowIndex].Cells["Task Name"].Value.ToString();
            cBoxStatus.SelectedValue = tasksListView.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            txtTimeRemaining.Text = tasksListView.Rows[e.RowIndex].Cells["Time Remaining"].Value.ToString();
            dueDatePicker.Value = Convert.ToDateTime(tasksListView.Rows[e.RowIndex].Cells["Due Date"].Value);
        }

        private void btnShowAllTasks_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessLayer dataAccessLayer = new DataAccessLayer();
                DataSet tasks = dataAccessLayer.GetAllTasks();

                DataTable tasksTable = new DataTable();
                tasksTable.Columns.Add("Task Id", typeof(int));
                tasksTable.Columns.Add("Task Name", typeof(string));
                tasksTable.Columns.Add("Status", typeof(string));
                tasksTable.Columns.Add("Time Remaining", typeof(string));
                tasksTable.Columns.Add("Due Date", typeof(DateTime));

                foreach (DataRow row in tasks.Tables[0].Rows)
                {
                    DataRow taskRow = tasksTable.NewRow();
                    taskRow["Task Id"] = row["TaskId"];
                    taskRow["Task Name"] = row["TaskName"];
                    taskRow["Status"] = ((TaskStatus)Convert.ToByte(row["Status"])).ToString();
                    taskRow["Time Remaining"] = TimeSpan.FromSeconds(Convert.ToInt32(row["TimeRemaining"])).ToString(@"hh\:mm\:ss");
                    taskRow["Due Date"] = Convert.ToDateTime(row["DueDate"]);
                    tasksTable.Rows.Add(taskRow);
                }

                tasksListView.DataSource = tasksTable;

                this.tasksListView.Columns["Task Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tasksListView.Columns["Task Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.tasksListView.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tasksListView.Columns["Time Remaining"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tasksListView.Columns["Due Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error while loading tasks: {exception.Message}");
            }
        }

        private void formToDoList_Load(object sender, EventArgs e)
        {
            resetToDoListForm();
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessLayer dataAccessLayer = new DataAccessLayer();
                dataAccessLayer.DeleteTask(Convert.ToInt32(lblSelectedTaskIdValue.Text));
                ToastNotification.Show("Task Deleted Successfully!");
            }
            catch(Exception exception)
            {
                MessageBox.Show($"Error while deleting task: {exception.Message}");
            }
            finally
            {
                resetToDoListForm();
            }
        }
    }
}
