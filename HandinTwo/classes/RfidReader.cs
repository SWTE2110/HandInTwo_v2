using System;
using System.Collections.Generic;
using System.Text;
using HandinTwo.Interfaces;

namespace HandinTwo.Classes
{

    public class RfidReader : IRfidReader
    {

        public event EventHandler<RfidEventArgs> ReadRfidEvent;

    }
}
