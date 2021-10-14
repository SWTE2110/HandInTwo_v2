using System;
using System.Collections.Generic;
using System.Text;

namespace HandinTwo.klasser
{
    public interface IChargeControl
    {
        void StartCharge();
        void StopCharge();
        bool Connected();

    }
}
