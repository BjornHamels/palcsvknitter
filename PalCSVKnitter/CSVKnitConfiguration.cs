using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalCSVKnitter
{
    /// <summary>
    /// The configuration block between two PalCSVFiles.
    /// </summary>
    internal class CSVKnitConfiguration
    {
        public DateTime stop;
        public DateTime start;

        /// <summary>
        /// Configuration between two PalCSVFiles.
        /// </summary>
        /// <param name="stop">At what DateTime the top file should stop.</param>
        /// <param name="start">At what DateTime the bottom file should start.</param>
        public CSVKnitConfiguration(DateTime stop, DateTime start)
        {
            this.stop = stop;
            this.start = start;
        }

        /// <summary>
        /// Configuration between two PalCSVFiles.
        /// </summary>
        /// <param name="cross">At what DateTime the top file should be cut off, and
        /// the bottom file should start.</param>
        public CSVKnitConfiguration(DateTime cross)
        {
            stop = cross;
            start = cross;
        }

        public override string? ToString()
        {
            if (stop == start)
                return $" + Cross stitch at {stop.ToString("yyyy-MM-dd HH:mm")}";
            return $" + Top file stops at {stop.ToString("yyyy-MM-dd HH:mm")} bottom starts at {start.ToString("yyyy-MM-dd HH:mm")}";
        }
    }
}
