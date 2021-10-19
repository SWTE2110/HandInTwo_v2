using System;
using System.Collections.Generic;
using System.Text;
using HandinTwo.Interfaces;

namespace HandinTwo.Classes
{
    public class Door : IDoor
    {

        public void DoorLock()
        {

        }
        public void DoorUnlock()
        {

        }

        public event EventHandler<EventArgs> OpenDoorEvent;
      
       

        public event EventHandler<EventArgs> CloseDoorEvent;

       
    }
}
