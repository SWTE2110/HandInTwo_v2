using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using HandinTwo.Interfaces;
using NUnit.Framework;
using HandinTwo.Classes;
namespace HandinTwo.Test
{
    [TestFixture]
    public class TestLogUnit
    {
        private string _fp = "LogfileTest.txt";
        private LogFile _uut;
        string _readback;

        [SetUp]
        public void Setup()
        {
            _uut = new LogFile(_fp);
            File.WriteAllText(_fp, String.Empty);
            _readback = String.Empty;
        }

        [TestCase(21)]
        [TestCase(182)]
        [TestCase(56)]
        public void LogLockedTestSingleEntry(int _id)
        {
            
            _uut.LogDoorLocked(_id);
            _readback = File.ReadAllText(_fp);
            Assert.That(_readback, Is.EqualTo($"Door locked with id:{_id}\r\n"));
        }

        [TestCase(21)]
        [TestCase(182)]
        [TestCase(56)]
        public void LogUnlockedTestSingleEntry(int _id)
        {

            _uut.LogDoorUnlocked(_id);
            _readback = File.ReadAllText(_fp);
            Assert.That(_readback, Is.EqualTo($"Door unlocked with id:{_id}\r\n"));
        }

        [TestCase(21, 84, 72, 48)]
        [TestCase(182, 182, 1, 92)]
        [TestCase(56, 75, 75, 2)]
        public void LogMultipleEntries(int _id1, int _id2, int _id3, int _id4)
        {

            _uut.LogDoorLocked(_id1);
            _uut.LogDoorLocked(_id2);
            _uut.LogDoorUnlocked(_id3);
            _uut.LogDoorUnlocked(_id4);
            _readback = File.ReadAllText(_fp);
            Assert.That(_readback, Is.EqualTo($"Door locked with id:{_id1}\r\nDoor locked with id:{_id2}\r\nDoor unlocked with id:{_id3}\r\nDoor unlocked with id:{_id4}\r\n"));
        }

    }
}
