using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework
{
    public class Events
    {
        public delegate void ShipDepartureEventHandler(object source, ShipEventArgs e);

        public event ShipDepartureEventHandler ShipDeparted;

        protected virtual void OnShipDeparted(Ship ship)
        {
            ShipDeparted?.Invoke(this, new ShipEventArgs(ship));
        }
        public void DepartShip(Ship ship)
        {
            var harborEvent = new Events();
            harborEvent.ShipDeparted += HandleShipDeparted;
            harborEvent.OnShipDeparted(ship);
        }

        private void HandleShipDeparted(object sender, ShipEventArgs e)
        {
            Console.WriteLine($"{e.Ship.Name} has departed.");
        }
    }
    public class ShipEventArgs : EventArgs
    {
        public Ship Ship { get; private set; }

        public ShipEventArgs(Ship ship)
        {
            Ship = ship;
        }
    }
}