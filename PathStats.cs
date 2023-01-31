using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReporter
{
    public class DriveInformation
    {
        public string Path { get; set; }
        public PathStats Stats { get; set; }
        
        public DriveInformation(string path, PathStats stats)
        {
            this.Path = path;
            this.Stats = stats; 
        }
    }
       public class PathStats 
    {
        public long TotalSize { get; set; }
        public int NumberItems { get; set; }

        public PathStats(long totalSize, int numberItems)
        {
            this.TotalSize = totalSize;
            this.NumberItems = numberItems;
        }
    }
}
