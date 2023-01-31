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
        
        public static PathStats GetDirectoryInfo(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            PathStats result = new PathStats(GlobalTotalSize, GlobalNumberItems);
            return (result);
        }
        //public static PathStats GetDirectoryInfo(string path)
        //{

        //    try
        //    {
        //        DirectoryInfo directory = new DirectoryInfo(path);
        //        FileInfo[] files = directory.GetFiles();
        //        DirectoryInfo[] subDirectories = directory.GetDirectories();

        //        //Add the size of the files in the directory.
        //        foreach (FileInfo file in files)
        //        {
        //            GlobalTotalSize += file.Length;
        //            GlobalNumberItems++;
        //        }

        //        //Add the number of items and the subdirectories and add its total size.
        //        foreach (DirectoryInfo subDirectory in subDirectories)
        //        {
        //            PathStats subDirectoryInfo = GetDirectoryInfo(subDirectory.FullName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error getting directory information: {ex.Message}");
        //    }

        //    PathStats result = new PathStats(GlobalTotalSize, GlobalNumberItems);
        //    return result;
        //}

        //Create a method to analyze the path, total size and number of items of a file (GetFileInfo).
        public static PathStats GetFileInfo(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();

            foreach (FileInfo file in files)
            {
                GlobalTotalSize += file.Length;
                GlobalNumberItems++;
            }

            PathStats result = new PathStats(GlobalTotalSize, GlobalNumberItems);
            return result;
        }
        //Create a method to analyze the path, total size and number of items of a directory (GetDirectoryInfo).
        //Create a method to fill a dictionary with the info of GetFileInfo and GetDirectoryInfo.

        public static string ConvertFromBytes(long bytes)

        // The method "FormatBytes" will transform the information from bytes to kilobytes , megabytes and gigabytes.
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
    }
}
