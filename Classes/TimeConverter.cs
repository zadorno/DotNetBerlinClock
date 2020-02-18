using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        IClock clock;
        public string convertTime(string aTime)
        {
            var timeParser = new TimeParser();
            clock = new Classes.BerlinClock(timeParser);
            return clock.ConvertTime(aTime);
        }
    }
}
