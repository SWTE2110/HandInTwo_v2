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
    public class TestStationControlIntegration
    {
        private StationControl _uut;
        private IUsbCharger _usb;
        private IChargeControl _charger;
        private IDoor _door;
        private IRfidReader _reader;
        private IDisplay _display;
        private ILogFile _log;
        private StringWriter _text;

        [SetUp]
        public void Setup()
        {
            _usb = new UsbChargerSimulator();
            _charger = new ChargeControl(_usb);
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

        [Test]
        public void TestOpenDoor_WhenDoorOpen()
        {
            _door.OnDoorOpen();

            //Resetter stringWriter
            _text = new StringWriter();
            Console.SetOut(_text);

            _door.OnDoorOpen();

            Assert.That(_uut.State, Is.EqualTo(LadeskabState.DoorOpen));
            Assert.That(_text.ToString(), Is.EqualTo(""));


        }

        [Test]
        public void TestOpenDoor_WhenLocked()
        {

        }

        [Test]
        public void TestCloseDoor_WhenDoorOpen()
        {
            _door.OnDoorOpen();

            _text = new StringWriter();
            Console.SetOut(_text);

            _door.OnDoorClosed();

            Assert.That(_uut.State, Is.EqualTo(LadeskabState.Available));
            Assert.That(_text.ToString(), Is.EqualTo("Indlæs RFID\r\n"));

        }

        [Test]
        public void TestCloseDoor_WhenAvailable()
        {
            _text = new StringWriter();
            Console.SetOut(_text);

            _door.OnDoorClosed();

            Assert.That(_uut.State, Is.EqualTo(LadeskabState.Available));
            Assert.That(_text.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void TestCloseDoor_WhenLocked()
        {

        }

        [TestCase(123)]
        [TestCase(0)]
        [TestCase(10)]
        public void TestReadRFID_WhenAvailable_AndConnected(int id)
        {
            _usb.SimulateConnected(true);

            _text = new StringWriter();
            Console.SetOut(_text);

            _reader.OnRfidRead(id);

            Assert.That(_uut.State, Is.EqualTo(LadeskabState.Locked));
            Assert.That(_text.ToString(), Is.EqualTo($"Ladeskab optaget af {i}\r\n"));
            
        }
    }
