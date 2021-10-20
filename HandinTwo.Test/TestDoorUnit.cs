using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandinTwo;
using HandinTwo.Classes;

namespace HandinTwo.Test
{
    [TestFixture]
    public class TestDoorUnit
    {
        private Door _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Door();
        }

        [Test]
        public void Test_IsLocked_True()
        {
            _uut.IsLocked = true;

            Assert.IsTrue(_uut.IsLocked);
        }

        [Test]
        public void Test_IsLocked_False()
        {
            _uut.IsLocked = false;

            Assert.IsTrue(!_uut.IsLocked);
        }

        [Test] 
        public void Test_DoorLock()
        {
            _uut.DoorLock();


            Assert.IsTrue(_uut.IsLocked);
        }

        [Test]
        public void Test_DoorUnlock()
        {
            _uut.DoorUnlock();


            Assert.IsTrue(!_uut.IsLocked);
        }


    }
}
