using BusinessLogicToDoList;
using System;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class formToDoList : Form
    {
        public formToDoList()
        {
            InitializeComponent();
        }

        private void txtTask_TextChanged(object sender, EventArgs e)
        {

        }

        private void cBoxPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Task task = new Task()
                {
                    TaskName = txtTaskName.Text,
                    Duration = Convert.ToInt16(txtDuration.Text),
                    Priority = cBoxPriority.SelectedItem.ToString(),
                    DueDate = dueDatePicker.Value
                };
                task.Validate();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void formToDoList_Load(object sender, EventArgs e)
        {

        }
    }
}
