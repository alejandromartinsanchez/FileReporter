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
            //Call GetDrives to list the available drives, then iterate the array to print in console as a number list adding the drive name and the drive size.
            for (int i = 0; i < drives.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {drives[i].Name} {Utilities.FormatBytes(drives[i].TotalSize)}");
            }
            int choice;
            do
            {
                Console.WriteLine("Choose the drive you want to analyze.");
                choice = int.Parse(Console.ReadLine());


            } while (choice > drives.Length || choice <= 0);

            DriveInfo selectedDrive = drives[choice - 1];
            Console.WriteLine($"The drive you have selected is {selectedDrive}.");            
        }
    }
}