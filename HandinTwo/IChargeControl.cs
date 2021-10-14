using System;
using System.Collections.Generic;
using System.Text;

namespace HandinTwo.klasser
{
    public interface IChargeControl
    {
        void DoorLock();
        void DoorUnlock();
        
        public event EventHandler<CurrentEventArgs> OpenDoorEvent;

    }
}
