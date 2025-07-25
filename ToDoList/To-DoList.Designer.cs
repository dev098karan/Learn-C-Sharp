﻿namespace ToDoList
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
            this.lblDueDate = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cBoxPriority = new System.Windows.Forms.ComboBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.tasksListView = new System.Windows.Forms.DataGridView();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.tasksListView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(391, 67);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(70, 16);
            this.lblDueDate.TabIndex = 0;
            this.lblDueDate.Text = "Due Date :";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(512, 24);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(168, 22);
            this.txtDuration.TabIndex = 3;
            this.txtDuration.Text = "0";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(391, 27);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(92, 16);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Duration (hrs) :";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(150, 24);
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
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(29, 67);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(54, 16);
            this.lblPriority.TabIndex = 4;
            this.lblPriority.Text = "Priority :";
            // 
            // cBoxPriority
            // 
            this.cBoxPriority.FormattingEnabled = true;
            this.cBoxPriority.Items.AddRange(new object[] {
            "None",
            "High",
            "Medium",
            "Low"});
            this.cBoxPriority.Location = new System.Drawing.Point(150, 64);
            this.cBoxPriority.Name = "cBoxPriority";
            this.cBoxPriority.Size = new System.Drawing.Size(168, 24);
            this.cBoxPriority.TabIndex = 8;
            this.cBoxPriority.Text = "None";
            this.cBoxPriority.SelectedIndexChanged += new System.EventHandler(this.cBoxPriority_SelectedIndexChanged);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(32, 109);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(648, 23);
            this.btnAddTask.TabIndex = 9;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.button1_Click);
            // 
            // tasksListView
            // 
            this.tasksListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksListView.Location = new System.Drawing.Point(32, 154);
            this.tasksListView.Name = "tasksListView";
            this.tasksListView.RowHeadersWidth = 51;
            this.tasksListView.RowTemplate.Height = 24;
            this.tasksListView.Size = new System.Drawing.Size(648, 214);
            this.tasksListView.TabIndex = 10;
            // 
            // dueDatePicker
            // 
            this.dueDatePicker.Location = new System.Drawing.Point(512, 62);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(168, 22);
            this.dueDatePicker.TabIndex = 11;
            this.dueDatePicker.Value = new System.DateTime(2025, 6, 29, 22, 55, 28, 0);
            // 
            // formToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 450);
            this.Controls.Add(this.dueDatePicker);
            this.Controls.Add(this.tasksListView);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.cBoxPriority);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.lblTaskName);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblDueDate);
            this.Name = "formToDoList";
            this.Text = "To-Do List";
            this.Load += new System.EventHandler(this.formToDoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tasksListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cBoxPriority;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridView tasksListView;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
    }
}

