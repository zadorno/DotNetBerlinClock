using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class TimeParser : ITimeParser
    {
        public Time ParseTime(string aTime)
        {
            var timeParts = aTime.Split(':');
            if (timeParts.Length != 3)
            {
                throw new ArgumentException("Incorrect time format");
            }
            int hours;
            if (!int.TryParse(timeParts[0], out hours) || hours < 0 || hours > 24)
            {
                throw new ArgumentException("Incorrect time format");
            }
            int minutes;
            if (!int.TryParse(timeParts[1], out minutes) || minutes < 0 || minutes > 59)
            {
                throw new ArgumentException("Incorrect time format");
            }
            int seconds;
            if (!int.TryParse(timeParts[2], out seconds) || seconds < 0 || seconds > 59)
            {
                throw new ArgumentException("Incorrect time format");
            }

            return new Time { Hours = hours, Minutes = minutes, Seconds = seconds };
        }
    }
}
