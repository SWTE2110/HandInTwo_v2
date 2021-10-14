using System;
using System.Collections.Generic;
using System.Text;

namespace HandinTwo.klasser.classes
{
    public class Door : IDoor
    {
        public void DoorLock()
        {

        }
        public void DoorUnlock()
        {

        }

        public event EventHandler<CurrentEventArgs> OpenDoorEvent;
    }
}
