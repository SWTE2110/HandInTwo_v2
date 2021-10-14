using System;
using System.Collections.Generic;
using System.Text;

namespace HandinTwo.klasser.classes
{
    public class RfidReader : IRfidReader
    {
        public event EventHandler<CurrentEventArgs> ReadRfdEvent;
    }
}
