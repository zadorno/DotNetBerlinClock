using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class BerlinClock : IClock
    {
        ITimeParser parser;
        public BerlinClock(ITimeParser parser)
        {
            this.parser = parser;
        }

        public string ConvertTime(string aTime)
        {
            var time = this.parser.ParseTime(aTime);

            var sb = new StringBuilder();
            sb.AppendLine(GetYellowLampString(time));
            sb.AppendLine(GetHourRow1String(time));
            sb.AppendLine(GetHourRow2String(time));
            sb.AppendLine(GetMinuteRow1String(time));
            sb.Append(GetMinuteRow2String(time));

            return sb.ToString();
        }

        private string GetYellowLampString(Time time)
        {
            return $"{(time.Seconds % 2 == 0 ? "Y" : "O")}";
        }

        private string GetHourRow1String(Time time)
        {
            var result = "OOOO".ToArray();

            for (int i = 0; i < time.Hours / 5; i++)
            {
                result[i] = 'R';
            }

            return new string(result);
        }

        private string GetHourRow2String(Time time)
        {
            var result = "OOOO".ToArray();

            for (int i = 0; i < time.Hours % 5; i++)
            {
                result[i] = 'R';
            }

            return new string(result);
        }

        private string GetMinuteRow1String(Time time)
        {
            var result = "OOOOOOOOOOO".ToArray();
            int[] minuteQuarters = new int[] { 2, 5, 8 };
            for (int i = 0; i < time.Minutes / 5; i++)
            {
                result[i] = minuteQuarters.Contains(i) ? 'R' : 'Y';
            }

            return new string(result);
        }

        private string GetMinuteRow2String(Time time)
        {
            var result = "OOOO".ToArray();

            for (int i = 0; i < time.Minutes % 5; i++)
            {
                result[i] = 'Y';
            }

            return new string(result);
        }
    }
}
