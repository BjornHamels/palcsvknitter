using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalCSVKnitter
{
    internal class PalCSVFile : IComparable<PalCSVFile>
    {
        private readonly string filename;
        private List<PalCSVLine> lines = new();
        private DateTime first;
        private DateTime last;

        public PalCSVFile(string filename)
        {
            this.filename = filename;
            LoadFileToLines();
        }

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

                    lines.Add(new PalCSVLine(time, dataCount, interval, activityCode,
                                             cumulativeStepCount, activityScore,
                                             sumAbsDiffX, sumAbsDiffY, sumAbsDiffZ));
                }
            }

            // Populate first and last DateTime.
            string firstString = fileLines[1];
            string lastString = fileLines[fileLines.Length - 1];
            string[] firstCol = firstString.Split(',');
            string[] lastCol = lastString.Split(',');
            first = DateTime.FromOADate(Convert.ToDouble(firstCol[0], CultureInfo.InvariantCulture)); // Decimal seperator = .));
            last = DateTime.FromOADate(Convert.ToDouble(lastCol[0], CultureInfo.InvariantCulture)); // Decimal seperator = .));
        }

        public override string? ToString()
        {
            return $"File {Path.GetFileName(filename)} " +
                   $"{lines.Count + 1} lines. " +
                   $"Starts at {first.ToString("yyyy-MM-dd")} to {last.ToString("yyyy-MM-dd")} " +
                   $"{Math.Round((last - first).TotalDays, 1)} days.";
        }

        public int CompareTo(PalCSVFile? other)
        {
            if (other == null)
                return 0;
            return this.first.CompareTo(other.first);
        }
    }
}
