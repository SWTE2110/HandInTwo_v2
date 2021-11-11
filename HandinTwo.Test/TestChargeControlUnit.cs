using System;
using System.Collections.Generic;
using System.Text;
using HandinTwo.Classes;
using HandinTwo.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace HandinTwo.Test
{
    [TestFixture]
    class TestChargeControlUnit
    {
        private ChargeControl _uut;
        private IUsbCharger _usbSub;
        private IDisplay _disSub;

        [SetUp]
        public void Setup()
        {
            _usbSub = Substitute.For<IUsbCharger>();
            _disSub = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_usbSub,_disSub);

        }

        [Test]
        public void StartChargeTest()
        {
            _uut.StartCharge();
            _usbSub.Received().StartCharge();
        }

        [Test]
        public void StopChargeTest()
        {
            _uut.StopCharge();
            _usbSub.Received().StopCharge();
        }

        [TestCase(true)]
        [TestCase(false)]

        public void ConnectedTest(bool v)
        {
            bool res;
            _usbSub.Connected.Returns(v);
            res = _uut.Connected();
            Assert.That(res, Is.EqualTo(v));


        }

        [TestCase(0)]
        [TestCase(2.5)]
        [TestCase(5)]
        public void HandleChargeCompleteTest(double cur)
        {
            CurrentEventArgs arg = new CurrentEventArgs();
            arg.Current = cur;

            _usbSub.CurrentValueEvent += Raise.EventWith(new object(), arg);
           _usbSub.Received().StopCharge();
           _disSub.Received().ChargingComplete();
        }
        [TestCase(5.001)]
        [TestCase(200)]
        [TestCase(500)]
        public void HandleChargingTest(double cur)
        {
            CurrentEventArgs arg = new CurrentEventArgs();
            arg.Current = cur;

            _usbSub.CurrentValueEvent += Raise.EventWith(new object(), arg);
            _usbSub.DidNotReceive().StopCharge();
            _disSub.Received().Charging(cur);
        }

        [TestCase(500.001)]
        [TestCase(750)]
        [TestCase(10000)]
        public void HandleOverloadTest(double cur)
        {
            CurrentEventArgs arg = new CurrentEventArgs();
            arg.Current = cur;

            _usbSub.CurrentValueEvent += Raise.EventWith(new object(), arg);
            _usbSub.Received().StopCharge();
            _disSub.Received().ChargingFail();
        }

    }
}
