using System;
using System.Collections.Generic;
using System.Text;
using HandinTwo.Interfaces;

namespace HandinTwo.Classes
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
