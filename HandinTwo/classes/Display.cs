using System;
using System.Collections.Generic;
using System.Text;
using HandinTwo.Interfaces;
using Console = System.Console;

namespace HandinTwo.Classes
{
    public class Display : IDisplay
    {

        public void RFidRead()
        {
            Console.WriteLine("Indlæs RFID");
        }
        public void RFidError()
        {
            Console.WriteLine("RFID fejl");
        }
        public void PhoneConnect()
        {
            Console.WriteLine("Tilslut telefon");
        }
        public void PhoneRemove()
        {
            Console.WriteLine("Fjern telefon");
        }
        public void ConnectionError()
        {
            Console.WriteLine("Tilslutningsfejl");
        }
        public void IsOccupied(int id)
        {
            Console.WriteLine($"Ladeskab optaget af {id}");
        }

        public void Available()
        {
            Console.WriteLine("Ladeskab er ledigt");
        }

        public void Charging(int current)
        {
            Console.WriteLine($"Charging with: {current} mA");

        }
        public void ChargingComplete()
        {
            Console.WriteLine($"Charging is complete");
        }
        public void ChargingFail()
        {
            Console.WriteLine($"Charging failed");
        }
    }
}
