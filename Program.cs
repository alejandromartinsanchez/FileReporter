using System.IO;

namespace FileReporter


{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            Console.WriteLine("List of all drives:");
            DriveInfo[] drives = DriveInfo.GetDrives();
            /*Call GetDrives to list the available drives, then iterate the array to print 
              in console as a number list adding the drive name and the drive size.*/
            for (int i = 0; i < drives.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {drives[i].Name} {Utilities.ConvertFromBytes(drives[i].TotalSize)}");
            }
            int choice;
            do
            {
                Console.WriteLine("\nChoose the drive you want to analyze.\n");
                choice = int.Parse(Console.ReadLine());
                //TODO: Handle wrong text inputs, example "Hola".

            } while (choice > drives.Length || choice <= 0);

            DriveInfo selectedDrive = drives[choice - 1];
            Console.WriteLine($"The drive you have selected is {selectedDrive}");

            int result = Utilities.GetDriveInfo(selectedDrive.Name);

            foreach (var item in Utilities.Drive)
            {
                string[] fragmentPaths = item.Key.Split(@"\");
                //fragmentPaths = fragmentPaths.Where(x => !string.IsNullOrEmpty(x)).ToArray(); (delete the void array items, test)
                string currentPath = "";                
                foreach (string fragmentPath in fragmentPaths) 
                {
                    currentPath = currentPath + fragmentPath + @"\";
                    if (Utilities.AggregatedDrive.ContainsKey(currentPath))
                    {
                        long tsCurrentPath = 0;
                        int niCurrentPath = 0;
                        tsCurrentPath = Utilities.AggregatedDrive[currentPath].TotalSize;
                        niCurrentPath = Utilities.AggregatedDrive[currentPath].NumberItems;
                        
                        //Take the current stats value and add the ones from the path being analyzed
                    }
                    else
                    {

                         Utilities.AggregatedDrive.Add(currentPath, item.Value); 
                        //Create it in the new diccionary
                    }
                }
                
            }
            
            // How to access a dictionary by the key DictionaryName["key"]
            //Utilities.Drive.ContainsKey("E:\\");

            // Split
            //  var aaa = @"a\asdasdwfwef\sdffweftwwg\weggwsaff\efwfsdfsdfsefwse\".Split(@"\");







        }
    }
}