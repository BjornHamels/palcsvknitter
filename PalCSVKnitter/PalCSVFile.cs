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
        NumberFormatInfo nfiDecimalDot = new NumberFormatInfo();

        public PalCSVLine first { get; private set; }
        public PalCSVLine last { get; private set; }

        /// <summary>
        /// Represents a Pal CSV File with data lines.
        /// </summary>
        /// <param name="filename">Path plus filename of the CSV file that is loaded in memory.</param>
        public PalCSVFile(string filename)
        {
            this.filename = filename;
            nfiDecimalDot.NumberDecimalSeparator = ".";
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
                    double time = Convert.ToDouble(col[0], nfiDecimalDot); // Decimal seperator = .
                    long dataCount = Convert.ToInt64(col[1]);
                    double interval = Convert.ToDouble(col[2], nfiDecimalDot); // Decimal seperator = .
                    byte activityCode = Convert.ToByte(col[3]);
                    long cumulativeStepCount = Convert.ToInt64(col[4]);
                    decimal activityScore = Convert.ToDecimal(col[5], nfiDecimalDot); // Decimal seperator = .
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
            return $"File {GetFileName()} " +
                   $"{lines.Count + 1} lines. " +
                   $"Starts at {first.GetDateTime().ToString("yyyy-MM-dd")} to {last.GetDateTime().ToString("yyyy-MM-dd")} " +
                   $"{Math.Round((last.GetDateTime() - first.GetDateTime()).TotalDays, 1)} days.";
        }

        /// <summary>
        /// Returns only the filename.
        /// </summary>
        /// <returns>Filename of the CSV.</returns>
        public string GetFileName()
        {
            return Path.GetFileName(filename);
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

        /// <summary>
        /// Converts the file to a list of strings given de stopDateTime and startDateTime.
        /// It will (optionally) start at a certain DateTime or Stop at a certain DateTime.
        /// </summary>
        /// <param name="startDataCount">Start-value of the data count</param>
        /// <param name="startStepCount">Start-value of the step count</param>
        /// <param name="stopDT">Optional stop at DateTime</param>
        /// <param name="startDT">Optional start at DateTime</param>
        /// <returns>A tuple containing the list of strings, and the two current stepcounts)</returns>
        public (List<string>, long, long) ConvertToListString(long startDataCount, long startStepCount,
                                                              DateTime? stopDT, DateTime? startDT)
        {
            List<string> list = new();
            double stop = (stopDT.HasValue) ? stopDT.Value.ToOADate() : last.Time;
            double start = (startDT.HasValue) ? startDT.Value.ToOADate() : first.Time;
            long dataCountMax = 0;
            long stepCountMax = 0;

            // Aint pretty, this triggers at the last file and make sure that
            // the "t < stop" becomes "t <= stop" for the missing last line.
            if (startDT.HasValue && !stopDT.HasValue)
                stop++;

            foreach (PalCSVLine line in lines)
                if ((start <= line.Time) && (line.Time < stop))  // t < stop is deliberate to prevent overlap
                {
                    dataCountMax = line.DataCount + startDataCount;
                    stepCountMax = line.CumulativeStepCount + startStepCount;
                    list.Add($"{line.Time.ToString("F10", nfiDecimalDot)},{line.DataCount + startDataCount}," + // Decimal seperator = .
                             $"{line.Interval.ToString("F1", nfiDecimalDot)},{line.ActivityCode}," + // Decimal seperator = .
                             $"{line.CumulativeStepCount + startStepCount},{line.ActivityScore.ToString(nfiDecimalDot)}," +
                             $"{line.SumAbsDiffX},{line.SumAbsDiffY},{line.SumAbsDiffZ}");
                }
            return (list, dataCountMax, stepCountMax);
        }
    }
}
