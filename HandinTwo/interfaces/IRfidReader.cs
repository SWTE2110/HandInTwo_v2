using System;
using System.Collections.Generic;
using System.Text;

namespace HandinTwo.klasser
{
    public interface IRfidReader
    {
        event EventHandler<CurrentEventArgs> ReadRfdEvent;
    }
}
