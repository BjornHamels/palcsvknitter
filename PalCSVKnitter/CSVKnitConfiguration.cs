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
            if (start < stop)
                return " + INVALID STATE: start < stop";
            if (stop == start)
                return $" + {GetMode()} at {stop.ToString("yyyy-MM-dd HH:mm")}";
            return $" + {GetMode()} of {GetGapMinutes()} minutes, top stops: {stop.ToString("yyyy-MM-dd HH:mm")} bottom starts: {start.ToString("yyyy-MM-dd HH:mm")}";
        }

        /// <summary>
        /// Files can be knit either on 1 date (concatenate) or 2 dates (having a gap).
        /// </summary>
        /// <returns>The string Concatenate or Gap.</returns>
        public string GetMode()
        {
            if (stop == start)
                return "Concatenate";
            else
                return "Gap";
        }

        /// <summary>
        /// Calcualtes the duration between stop and start in minutes.
        /// </summary>
        /// <returns>Minutes between the two dates rounded to 1 decimal point.</returns>
        public double GetGapMinutes()
        {
            double minutes = (start - stop).Duration().TotalMinutes;
            return Math.Round(minutes, 1);
        }
    }
}
