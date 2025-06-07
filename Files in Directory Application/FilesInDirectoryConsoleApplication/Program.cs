Console.Write("Enter Full Path of Directory: ");
string? directoryPath = Console.ReadLine();
if(directoryPath != null)
{
    FilesInDirectory.File file = new FilesInDirectory.File();
    file.FileNameSent += DisplayFileName;
    Thread thread = new Thread(() => file.DisplayAllFilesNames(directoryPath));
    thread.Start();
}

void DisplayFileName(string fileName)
{
    Console.WriteLine(fileName);
}