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
                //choice = int.Parse(Console.ReadLine());
                choice = 3;
                //TODO: Handle wrong text inputs, example "Hola".

            } while (choice > drives.Length || choice <= 0);

            DriveInfo selectedDrive = drives[choice - 1];
            Console.WriteLine($"The drive you have selected is {selectedDrive}");

            int result = Utilities.GetDriveInfo(selectedDrive.Name);

            //Print dicctionary:
            //foreach (var drive in Utilities.Drive)
            //{
            //    Console.WriteLine($"{drive.Key}\t{drive.Value}");
            //}


            foreach (var item in Utilities.Drives)
            {
                Console.WriteLine("--------------");
                string path = item.Key;
                string[] fragments = path.Split(@"\");
                string currentFragment = "";
                foreach (string fragment in fragments)
                {
                    currentFragment = currentFragment + fragment + @"\";
                    Console.WriteLine(currentFragment);
                    if (Utilities.AggregatedDrives.ContainsKey(currentFragment))
                    {
                        Utilities.AggregatedDrives[currentFragment].TotalSize += item.Value.TotalSize;
                        Utilities.AggregatedDrives[currentFragment].NumberItems += item.Value.NumberItems;
                    }
                    else
                    {
                        Utilities.AggregatedDrives.Add(currentFragment, item.Value);

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