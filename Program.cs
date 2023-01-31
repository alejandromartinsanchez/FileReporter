﻿using System.IO;

namespace FileReporter

/*
  * Collect all files and folders for a given drive (First enumerate all drives and then ask the user about the drive he want to analyze)
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
                Console.WriteLine($"{i + 1}. {drives[i].Name} {Utilities.ConvertFromBytes(drives[i].TotalSize)}");
            }
            int choice;
            do
            {
                Console.WriteLine("Choose the drive you want to analyze.");
                choice = int.Parse(Console.ReadLine());
                //TODO: Handle wrong text inputs, example "Hola".

            } while (choice > drives.Length || choice <= 0);

            DriveInfo selectedDrive = drives[choice - 1];
            Console.WriteLine($"The drive you have selected is {selectedDrive}");

            int result = Utilities.GetDriveInfo(selectedDrive.Name);

            //PathStats mystats = Utilities.GetDirectoryInfo(selectedDrive.Name);
            //long size = mystats.TotalSize;
            //int items = mystats.NumberItems;
            //string convertedSizes = Utilities.ConvertFromBytes(size);
            //Console.WriteLine($"{selectedDrive.Name}\t\t\t\t\t\t{convertedSizes}\t{items}");




            //string archiveDirectory = selectedDrive.name;
            //List<string> directories = Directory.EnumerateDirectories(archiveDirectory).ToList();
            //foreach (string itemD in directories)
            //{
            //    Console.WriteLine(itemD);
            //}
            //Console.WriteLine();
            //List<string> archives = Directory.EnumerateFiles(archiveDirectory).ToList();
            //foreach (string itemA in archives)
            //{
            //    Console.WriteLine(itemA);
            //}







        }
    }
}