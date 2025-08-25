namespace ToDoList
{
    partial class formToDoList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTimeRemaining = new System.Windows.Forms.MaskedTextBox();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.tasksListView = new System.Windows.Forms.DataGridView();
            this.lblSelectedTaskId = new System.Windows.Forms.Label();
            this.lblSelectedTaskIdValue = new System.Windows.Forms.Label();
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.cBoxStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.btnShowAllTasks = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tasksListView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTimeRemaining
            // 
            this.txtTimeRemaining.Location = new System.Drawing.Point(506, 24);
            this.txtTimeRemaining.Mask = "00:00:00";
            this.txtTimeRemaining.Name = "txtTimeRemaining";
            this.txtTimeRemaining.Size = new System.Drawing.Size(168, 22);
            this.txtTimeRemaining.TabIndex = 3;
            this.txtTimeRemaining.Text = "000000";
            this.txtTimeRemaining.ValidatingType = typeof(System.DateTime);
            this.txtTimeRemaining.Leave += new System.EventHandler(this.txtTimeRemaining_Leave);
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.Location = new System.Drawing.Point(369, 27);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(103, 16);
            this.lblTimeRemaining.TabIndex = 2;
            this.lblTimeRemaining.Text = "Required Time :";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(182, 24);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(168, 22);
            this.txtTaskName.TabIndex = 7;
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Location = new System.Drawing.Point(29, 27);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(84, 16);
            this.lblTaskName.TabIndex = 6;
            this.lblTaskName.Text = "Task Name :";
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(356, 64);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(318, 23);
            this.btnAddTask.TabIndex = 9;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // tasksListView
            // 
            this.tasksListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tasksListView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tasksListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksListView.Location = new System.Drawing.Point(32, 109);
            this.tasksListView.Name = "tasksListView";
            this.tasksListView.RowHeadersWidth = 51;
            this.tasksListView.RowTemplate.Height = 24;
            this.tasksListView.Size = new System.Drawing.Size(1298, 259);
            this.tasksListView.TabIndex = 10;
            this.tasksListView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tasksListView_RowEnter);
            // 
            // lblSelectedTaskId
            // 
            this.lblSelectedTaskId.AutoSize = true;
            this.lblSelectedTaskId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedTaskId.Location = new System.Drawing.Point(967, 386);
            this.lblSelectedTaskId.Name = "lblSelectedTaskId";
            this.lblSelectedTaskId.Size = new System.Drawing.Size(237, 29);
            this.lblSelectedTaskId.TabIndex = 12;
            this.lblSelectedTaskId.Text = "Selected Task ID :";
            // 
            // lblSelectedTaskIdValue
            // 
            this.lblSelectedTaskIdValue.AutoSize = true;
            this.lblSelectedTaskIdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedTaskIdValue.Location = new System.Drawing.Point(1275, 386);
            this.lblSelectedTaskIdValue.Name = "lblSelectedTaskIdValue";
            this.lblSelectedTaskIdValue.Size = new System.Drawing.Size(55, 29);
            this.lblSelectedTaskIdValue.TabIndex = 13;
            this.lblSelectedTaskIdValue.Text = "N/A";
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.Location = new System.Drawing.Point(680, 64);
            this.btnUpdateTask.Name = "btnUpdateTask";
            this.btnUpdateTask.Size = new System.Drawing.Size(324, 23);
            this.btnUpdateTask.TabIndex = 14;
            this.btnUpdateTask.Text = "Update Task";
            this.btnUpdateTask.UseVisualStyleBackColor = true;
            this.btnUpdateTask.Click += new System.EventHandler(this.btnUpdateTask_Click);
            // 
            // dueDatePicker
            // 
            this.dueDatePicker.Location = new System.Drawing.Point(1162, 22);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(168, 22);
            this.dueDatePicker.TabIndex = 18;
            this.dueDatePicker.Value = new System.DateTime(2025, 8, 24, 0, 0, 0, 0);
            // 
            // cBoxStatus
            // 
            this.cBoxStatus.FormattingEnabled = true;
            this.cBoxStatus.Items.AddRange(new object[] {
            "To-Do",
            "In-Progress",
            "Done"});
            this.cBoxStatus.Location = new System.Drawing.Point(836, 24);
            this.cBoxStatus.Name = "cBoxStatus";
            this.cBoxStatus.Size = new System.Drawing.Size(168, 24);
            this.cBoxStatus.TabIndex = 17;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(711, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 16);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status :";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(1054, 27);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(70, 16);
            this.lblDueDate.TabIndex = 15;
            this.lblDueDate.Text = "Due Date :";
            // 
            // btnShowAllTasks
            // 
            this.btnShowAllTasks.Location = new System.Drawing.Point(32, 64);
            this.btnShowAllTasks.Name = "btnShowAllTasks";
            this.btnShowAllTasks.Size = new System.Drawing.Size(318, 23);
            this.btnShowAllTasks.TabIndex = 19;
            this.btnShowAllTasks.Text = "Show All Tasks";
            this.btnShowAllTasks.UseVisualStyleBackColor = true;
            this.btnShowAllTasks.Click += new System.EventHandler(this.btnShowAllTasks_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Location = new System.Drawing.Point(1010, 64);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(320, 23);
            this.btnDeleteTask.TabIndex = 20;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // formToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 450);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnShowAllTasks);
            this.Controls.Add(this.dueDatePicker);
            this.Controls.Add(this.cBoxStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.btnUpdateTask);
            this.Controls.Add(this.lblSelectedTaskIdValue);
            this.Controls.Add(this.lblSelectedTaskId);
            this.Controls.Add(this.tasksListView);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.lblTaskName);
            this.Controls.Add(this.txtTimeRemaining);
            this.Controls.Add(this.lblTimeRemaining);
            this.Name = "formToDoList";
            this.Text = "To-Do List";
            this.Load += new System.EventHandler(this.formToDoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tasksListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.MaskedTextBox txtTimeRemaining;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cBoxPriority;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridView tasksListView;
        private System.Windows.Forms.Label lblSelectedTaskId;
        private System.Windows.Forms.Label lblSelectedTaskIdValue;
        private System.Windows.Forms.Button btnUpdateTask;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.ComboBox cBoxStatus;
        private System.Windows.Forms.Button btnShowAllTasks;
        private System.Windows.Forms.Button btnDeleteTask;
    }
}

