namespace FilesInDirectoryWindowsApplication
{
    partial class filesNamesForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtDirectoryName = new TextBox();
            btnShowFiles = new Button();
            listFiles = new ListBox();
            SuspendLayout();
            // 
            // txtDirectoryName
            // 
            txtDirectoryName.Location = new Point(62, 40);
            txtDirectoryName.Name = "txtDirectoryName";
            txtDirectoryName.Size = new Size(737, 27);
            txtDirectoryName.TabIndex = 0;
            txtDirectoryName.Text = "Full Path of Directory";
            // 
            // btnShowFiles
            // 
            btnShowFiles.Location = new Point(837, 38);
            btnShowFiles.Name = "btnShowFiles";
            btnShowFiles.Size = new Size(113, 29);
            btnShowFiles.TabIndex = 1;
            btnShowFiles.Text = "Show Files";
            btnShowFiles.UseVisualStyleBackColor = true;
            btnShowFiles.Click += btnShowFiles_Click;
            // 
            // listFiles
            // 
            listFiles.FormattingEnabled = true;
            listFiles.Location = new Point(62, 114);
            listFiles.Name = "listFiles";
            listFiles.Size = new Size(888, 224);
            listFiles.TabIndex = 2;
            // 
            // filesNamesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 450);
            Controls.Add(listFiles);
            Controls.Add(btnShowFiles);
            Controls.Add(txtDirectoryName);
            Name = "filesNamesForm";
            Text = "Files In Directory Windows Application";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDirectoryName;
        private Button btnShowFiles;
        private ListBox listFiles;
    }
}
