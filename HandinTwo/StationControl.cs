using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandinTwo.Interfaces;

namespace HandinTwo.Classes
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;
        private IRfidReader _reader;
        private IDisplay _display;
        private ILogFile _log;

        StationControl(IChargeControl c, IDoor d, IRfidReader r, IDisplay dp, ILogFile l)
        {
            _charger = c;
            _door = d;
            _reader = r;
            _display = dp;
            _log = l;

            
            _reader.ReadRfidEvent += OnRfidDetected;

        }

        private void OnRfidDetected(object sender, RfidEventArgs e)
        {
               
            RfidDetected(e.Id);
        }

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected())
                    {
                        _door.DoorLock();
                        _charger.StartCharge();
                        _oldId = id;
                        _log.LogDoorLocked(id);

                        _display.IsOccupied(id);
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.ConnectionError();
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.DoorUnlock();
                        _log.LogDoorUnlocked(id);

                        _display.PhoneRemove();
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.RFidError();
                    }

                    break;
            }
        }

        // Her mangler de andre trigger handlere
    }
}
