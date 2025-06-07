namespace FilesInDirectory
{
    public class File
    {
        public delegate void SendFileNameHandler(string fileName);
        public event SendFileNameHandler? FileNameSent;
        public void DisplayAllFilesNames(string directoryName)
        {
            foreach (string file in Directory.GetFiles(directoryName))
            {
                FileNameSent?.Invoke(file);
            }
            foreach (string directory in Directory.GetDirectories(directoryName))
            {
                DisplayAllFilesNames(directory);
            }
        }
    }
}