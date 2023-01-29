﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Add the thousands separator.
//TODO: Add two decimals.

namespace FileReporter
{
    public static class Utilities
    {
        //We create the class "Utilities" to process some information of the directorys and archives.

        public static string FormatBytes(long bytes)

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