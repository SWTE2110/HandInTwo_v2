using System;
using System.Collections.Generic;
using System.Text;
using HandinTwo.Interfaces;

namespace HandinTwo.Classes
{
    public class ChargeControl : IChargeControl
    {
        private IUsbCharger _charger;
        private IDisplay _display;
        private double _lastcurrent = 0;

        public ChargeControl(IUsbCharger charger, IDisplay display)
        {
            _charger = charger;
            _display = display;
            _charger.CurrentValueEvent += HandleCurrentEvent;
        }

        public void StartCharge()
        {
            _charger.StartCharge();

            

        }
        public void StopCharge()
        {


            _charger.StopCharge();
            _lastcurrent = 0;

        }

        public void HandleCurrentEvent(object sender, CurrentEventArgs e)
        {
            if (e.Current <= 5 && e.Current > 0)
            {
                
                    StopCharge();
                    _display.ChargingComplete();
                    _lastcurrent = e.Current;



            }
            else if (e.Current > 500)
            {
                StopCharge();
                _display.ChargingFail();
                _lastcurrent = e.Current;

            }
            else
            {
                if (Math.Abs(_lastcurrent - e.Current) >= 0.5)
                {
                    _display.Charging(e.Current);
                    _lastcurrent = e.Current;
                }
            }

            
            
        }


        public bool Connected() { return _charger.Connected; }

    }
}
