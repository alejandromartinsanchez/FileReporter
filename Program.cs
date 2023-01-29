namespace FileReporter

    /*
      * Collect all files and folders for a given drive (First enumerate all drives and then ask the usuary about the drive he want to analyze)
       * Analyze all folders, subfolders and files inside and collect:
		* File size
		* File extension*/
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of all drives:");
            DriveInfo[] drives = DriveInfo.GetDrives();           
            Console.WriteLine(drives[0].Name + " " + drives[1].Name);
            Console.WriteLine("Choose the drive you want to analyze.");



        }
    }
}