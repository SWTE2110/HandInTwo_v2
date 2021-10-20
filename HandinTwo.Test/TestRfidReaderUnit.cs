using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using HandinTwo.Classes;
using HandinTwo.Interfaces;
using NUnit.Framework;

namespace HandinTwo.Test
{
    [TestFixture]
    public class TestRfidReaderUnit
    {

        public RfidReader _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new RfidReader();

        }

        [Test]
        public void RfidEventRaised()
        {
            int TestId = 0;
            _uut.ReadRfidEvent += (sender, args) => TestId = args.Id;

            _uut.OnRfidRead(123);

            Assert.That(TestId, Is.EqualTo(123));
        }

    }
}
