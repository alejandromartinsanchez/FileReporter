using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReporter
{
    public class Stats
    {
        public long TotalSize { get; set; }
        public int NumberItems { get; set; }

        public Stats(long totalSize, int numberItems)
        {
            this.TotalSize = totalSize;
            this.NumberItems = numberItems;
        }
        public override string ToString()
        {
            return TotalSize.ToString() + "\t" + NumberItems.ToString();
        }
    }
}
