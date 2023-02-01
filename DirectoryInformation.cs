using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReporter
{
    public class DirectoryInformation
    {
        public string Path { get; set; }
        public PathStats Stats { get; set; }

        public DirectoryInformation(string path, PathStats stats)
        {
            this.Path = path;
            this.Stats = stats;
        }
        public override string ToString()
        {
            return Path + " " + Stats.TotalSize.ToString() + " " + Stats.NumberItems.ToString();
        }
    }
}
