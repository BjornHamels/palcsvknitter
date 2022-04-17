using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalCSVKnitter
{
    internal struct PalCSVLine
    {
        // https://kb.palt.com/articles/events-csv/
        // CSV Line Format:
        // "Time",           "DataCount (samples)", "Interval (s)", "ActivityCode (0=sedentary, 1=standing, 2=stepping)", "CumulativeStepCount", "Activity Score (MET.h)", "Sum(Abs(DiffX)", "Sum(Abs(DiffY)", "Sum(Abs(DiffZ)"
        // 44493.3424606481, 3319966,               140.9,          0,                                                    5778,                  0.048923611111111112,     1052,             987,              979
        public readonly double Time;
        public readonly long DataCount;
        public readonly double Interval;
        public readonly byte ActivityCode;
        public readonly long CumulativeStepCount;
        public readonly Decimal ActivityScore;
        public readonly int SumAbsDiffX;
        public readonly int SumAbsDiffY;
        public readonly int SumAbsDiffZ;

        public PalCSVLine(double time, long dataCount, double interval, byte activityCode,
                          long cumulativeStepCount, decimal activityScore,
                          int sumAbsDiffX, int sumAbsDiffY, int sumAbsDiffZ)
        {
            Time = time;
            DataCount = dataCount;
            Interval = interval;
            ActivityCode = activityCode;
            CumulativeStepCount = cumulativeStepCount;
            ActivityScore = activityScore;
            SumAbsDiffX = sumAbsDiffX;
            SumAbsDiffY = sumAbsDiffY;
            SumAbsDiffZ = sumAbsDiffZ;
        }

        public DateTime GetDateTime()
        {
            return DateTime.FromOADate(Time);
        }

        public override string? ToString()
        {
            return $"{GetDateTime()} {Time} {DataCount} {Interval} {ActivityCode}";
        }
    }
}
