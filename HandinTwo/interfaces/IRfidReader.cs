﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HandinTwo.klasser
{

    public class RfidEventArgs : EventArgs
    {
        public int Id { get; set; }
    }

    public interface IRfidReader
    {
        event EventHandler<RfidEventArgs> ReadRfidEvent;
    }
}
