using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Add the thousands separator.
//TODO: Add two decimals.

namespace FileReporter
{
    //We create the class "Utilities" to process some information of the directorys and archives.
    public static class Utilities
    {
        public static long GlobalTotalSize { get; set; }
        public static int GlobalNumberItems { get; set; }

        public const int Sucess = 0;
        public const int Error = 1;
        public const int Warning = 2;

        public static string selectedDrivetxt;

        public static Dictionary<string, Stats> Drives = new Dictionary<string, Stats>();
        public static Dictionary<string, Stats> AggregatedDrives = new Dictionary<string, Stats>();
        public static Dictionary<string, Stats> Formats = new Dictionary<string, Stats>();
        public static int GetDriveInfo(string path)
        {
            DirectoryInformation currentDirectoryInformation = GetFilesInfo(path);
            string drivePathWithoutSlash = currentDirectoryInformation.Path.Substring(0, currentDirectoryInformation.Path.Length - 1); 
            Drives.Add(drivePathWithoutSlash, currentDirectoryInformation.Stats);
            GetDirectoryInfo(path);
            return Sucess;
        }
        public static DirectoryInformation GetFilesInfo(string path)
        {
            long currentPathSize = 0;
            int currentPathItems = 0;            
            DirectoryInfo directory = new DirectoryInfo(path);

            try
            {
                FileInfo[] files = directory.GetFiles();                
                foreach (FileInfo file in files)
                {
                    Stats extensionValue = new Stats(file.Length, 1);
                    if (Formats.ContainsKey(file.Extension))
                    {
                        Formats[file.Extension].TotalSize += extensionValue.TotalSize;
                        Formats[file.Extension].NumberItems++;
                    
                    }  
                    else 
                    {
                        Formats.Add(file.Extension, extensionValue);
                    }
                    currentPathSize += file.Length;
                    currentPathItems++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\t{path}");                
            }

            Stats pathStats = new Stats(currentPathSize, currentPathItems);
            DirectoryInformation result = new DirectoryInformation(path, pathStats);

            return result;
        }

        public static void GetDirectoryInfo(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            try
            {
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    DirectoryInformation currentDirectoryInformation = GetFilesInfo(subDirectory.FullName);
                    Drives.Add(currentDirectoryInformation.Path, currentDirectoryInformation.Stats);
                    GetDirectoryInfo(subDirectory.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\t{path}");                
            }
        }

        // The method "FormatBytes" will transform the information from bytes to kilobytes , megabytes and gigabytes.
        public static string ConvertFromBytes(long bytes)


        {          
            long gigabytes = 0;
            string suffix;
            
            if (bytes > 0 && bytes < 1024)
            {
                gigabytes = bytes;
                suffix = "B";
            }
            //With this step we transform from bytes to kilobytes.
            else if (bytes > 1023 && bytes < 1048576)
            {
                gigabytes = bytes / 1024;
                suffix = "KB";
            }
            //With this step we transform from bytes to megabytes.
            else if (bytes > 1048575 && bytes < 1073741824)
            {
                gigabytes = bytes / (1024 * 1024);
                suffix = "MB";
            }
            //With this step we transform from bytes to gigabytes.
            else
            {
                gigabytes = bytes / (1024 * 1024 * 1024);
                suffix = "GB";
            }
            //Then we ask the method to return the value plus the suffix
            return gigabytes.ToString() + suffix;
        }

        public static void Txt()
        {
            string filePath = $"FileReport{selectedDrivetxt}.txt";
            WriteToFile(filePath);
        }
        static void WriteToFile (string filePath)
        {
            //Write to the file
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var items in Utilities.AggregatedDrives)
                {
                    sw.WriteLine($"{items.Key}\t{Utilities.ConvertFromBytes(items.Value.TotalSize)}\t{items.Value.NumberItems}");
                }
            }
        }
    }
}
