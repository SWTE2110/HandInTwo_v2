using System;
using System.Collections.Generic;
using System.Text;

namespace HandinTwo.klasser.classes
{
    public class ChargeControl : IChargeControl
    {

        private bool _connected = true;

        public void StartCharge()
        {


            _connected = false;

        }
        public void StopCharge()
        {


            _connected = true;

        }

        public bool Connected() { return _connected; }

    }
}
