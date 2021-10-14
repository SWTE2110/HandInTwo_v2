using System;
using System.Collections.Generic;
using System.Text;

namespace HandinTwo.klasser
{
    public interface IDisplay
    {
        void RFidStatus();
        void RFidError();
        void PhoneConnect();
        void PhoneRemove();
        void ConnectionError();
        void IsOccupied(bool occupation);
    }
}
