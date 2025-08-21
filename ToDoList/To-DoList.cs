using BusinessLogicToDoList;
using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Task task = new Task()
                {
                    TaskName = txtTaskName.Text,
                    TimeRemaining = Convert.ToInt32(TimeSpan.ParseExact(txtTimeRemaining.Text, "hh\\:mm\\:ss", null).TotalSeconds),
                    Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), cBoxPriority.SelectedItem.ToString()),
                    DueDate = dueDatePicker.Value
                };
                if (task.Validate())
                {
                    DataAccessLayer dataAccessLayer = new DataAccessLayer();
                    dataAccessLayer.AddTask(task);
                };
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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
            }
        }
    }
}
