using BerlinClock.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class TimeParserTests
    {
        private ITimeParser parser;
        [SetUp]
        public void SetUp()
        {
            parser = new TimeParser();
        }

        [Test]
        [TestCase("22:59")]
        [TestCase("120000")]
        [TestCase("12.00.00")]
        public void InValidFormat(string aTime)
        {
            Assert.Throws<ArgumentException>(() => parser.ParseTime(aTime));
        }

        [Test]
        [TestCase("23:59:59", 23)]
        [TestCase("24:00:00", 24)]
        [TestCase("00:00:00", 00)]
        public void HoursValidConversion(string aTime, int expectedValue)
        {
            Assert.AreEqual(parser.ParseTime(aTime).Hours, expectedValue);
        }

        [Test]
        [TestCase("25:00:00")]
        [TestCase("-1:00:00")]
        public void HoursInValidConversion(string aTime)
        {
            Assert.Throws<ArgumentException>(() => parser.ParseTime(aTime));
        }

        [Test]
        [TestCase("23:59:59", 59)]
        [TestCase("24:00:00", 0)]
        [TestCase("00:30:00", 30)]
        public void MinutesValidConversion(string aTime, int expectedValue)
        {
            Assert.AreEqual(parser.ParseTime(aTime).Minutes, expectedValue);
        }

        [Test]
        [TestCase("12:60:00")]
        [TestCase("00:-1:00")]
        public void MinutesInValidConversion(string aTime)
        {
            Assert.Throws<ArgumentException>(() => parser.ParseTime(aTime));
        }

        [Test]
        [TestCase("23:59:59", 59)]
        [TestCase("24:00:00", 0)]
        [TestCase("00:00:30", 30)]
        public void SecondsValidConversion(string aTime, int expectedValue)
        {
            Assert.AreEqual(parser.ParseTime(aTime).Seconds, expectedValue);
        }

        [Test]
        [TestCase("12:30:60")]
        [TestCase("00:00:-1")]
        public void SecondsInValidConversion(string aTime)
        {
            Assert.Throws<ArgumentException>(() => parser.ParseTime(aTime));
        }
    }
}
