using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalCSVKnitter
{
    /// <summary>
    /// Represents a Pal CSV File with data lines.
    /// </summary>
    internal class PalCSVFile : IComparable<PalCSVFile>
    {
        public readonly string filename;
        public readonly List<PalCSVLine> lines = new();
        public readonly HashSet<char> activitySeen = new();
        public PalCSVLine first { get; private set; }
        public PalCSVLine last { get; private set; }

        /// <summary>
        /// Represents a Pal CSV File with data lines.
        /// </summary>
        /// <param name="filename">Path plus filename of the CSV file that is loaded in memory.</param>
        public PalCSVFile(string filename)
        {
            this.filename = filename;
            LoadFileToLines();
        }

        /// <summary>
        /// Does the workload of loading the file into the list of structs.
        /// </summary>
        private void LoadFileToLines()
        {
            // Load all lines in the struct list.
            string[] fileLines = System.IO.File.ReadAllLines(filename);
            foreach (string line in fileLines)
            {
                string[] col = line.Split(',');
                if (col[0] != "\"Time\"") // Ignore first line containing the headers.
                {
                    double time = Convert.ToDouble(col[0], CultureInfo.InvariantCulture); // Decimal seperator = .
                    long dataCount = Convert.ToInt64(col[1]);
                    double interval = Convert.ToDouble(col[2], CultureInfo.InvariantCulture); // Decimal seperator = .
                    byte activityCode = Convert.ToByte(col[3]);
                    long cumulativeStepCount = Convert.ToInt64(col[4]);
                    decimal activityScore = Convert.ToDecimal(col[5]);
                    int sumAbsDiffX = Convert.ToInt32(col[6]);
                    int sumAbsDiffY = Convert.ToInt32(col[7]);
                    int sumAbsDiffZ = Convert.ToInt32(col[8]);

                    activitySeen.Add(activityCode.ToString()[0]);
                    lines.Add(new PalCSVLine(time, dataCount, interval, activityCode,
                                             cumulativeStepCount, activityScore,
                                             sumAbsDiffX, sumAbsDiffY, sumAbsDiffZ));
                }
            }

            // Populate first and last PalCSVLine.
            first = lines[0];
            last = lines[lines.Count - 1];
        }

        /// <summary>
        /// Made for the ListBox.
        /// </summary>
        /// <returns>A line summarizing this file.</returns>
        public override string? ToString()
        {
            return $"File {Path.GetFileName(filename)} " +
                   $"{lines.Count + 1} lines. " +
                   $"Starts at {first.GetDateTime().ToString("yyyy-MM-dd")} to {last.GetDateTime().ToString("yyyy-MM-dd")} " +
                   $"{Math.Round((last.GetDateTime() - first.GetDateTime()).TotalDays, 1)} days.";
        }

        /// <summary>
        /// Used for sorting. Sorts by first DateTime seen.
        /// </summary>
        public int CompareTo(PalCSVFile? other)
        {
            if (other == null)
                return 0;
            return this.first.GetDateTime().CompareTo(other.first.GetDateTime());
        }
    }
}
