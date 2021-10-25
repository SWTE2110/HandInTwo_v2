using HandinTwo.Classes;
using HandinTwo.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HandinTwo.Test
{
    [TestFixture]
    public class TestStationControlIntergration
    {
        private StationControl _uut;
        private IChargeControl _charger;
        private IDoor _door;
        private IRfidReader _reader;
        private IDisplay _display;
        private ILogFile _log;
        private StringWriter _text;

        [SetUp]
        public void Setup()
        {
            _charger = new ChargeControl(new UsbChargerSimulator());
            _door = new Door();
            _reader = new RfidReader();
            _display = new Display();
            _log = new LogFile("StationControlTest");
            _text = new StringWriter();
            Console.SetOut(_text);
            _uut = new StationControl(_charger, _door, _reader, _display, _log);

        }

        [Test]
        public void TestInitState()
        {
            Assert.That(_uut.State, Is.EqualTo(LadeskabState.Available));
            Assert.That(_text.ToString(), Is.EqualTo($"Ladeskab er ledigt\r\n"));

        }

        [Test]
        public void TestOpenDoor_WhenAvailable()
        {
            _text = new StringWriter();
            Console.SetOut(_text);

            _door.OnDoorOpen();
            Assert.That(_uut.State, Is.EqualTo(LadeskabState.DoorOpen));
            Assert.That(_text.ToString(), Is.EqualTo("Tilslut telefon\r\n"));
        }




    }
}
