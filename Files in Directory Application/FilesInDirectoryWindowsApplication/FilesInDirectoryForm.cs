namespace FilesInDirectoryWindowsApplication
{
    public partial class filesNamesForm : Form
    {
        public filesNamesForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnShowFiles_Click(object sender, EventArgs e)
        {
            FilesInDirectory.File file = new FilesInDirectory.File();
            file.FileNameSent += ShowFileName;
            file.DisplayAllFilesNames(txtDirectoryName.Text);
        }

        private void ShowFileName(string fileName)
        {
            listFiles.Items.Add(fileName);
        }
    }
}
