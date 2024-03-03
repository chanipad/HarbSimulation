using ClassLibrary.HarborFramework.ShipInfo;
using ClassLibrary.HarborFramework.Utilities;


namespace ClassLibrary.HarborFramework.DockingInfo
{
    /// <summary>
    /// Representerer en dokkinghendelse for et skip ved en spesifisert DockSpace og tidspunkt.
    /// </summary>
    public class Docking
    {
        /// <summary>
        /// Får DockSpace-objektet hvor dokkingen skjer.
        /// </summary>
        public DockSpace dockSpace { get; private set; }

        /// <summary>
        /// Får eller setter tidspunktet for dokkingen.
        /// </summary>
        public DateTime timestamp { get; set; }

        /// <summary>
        /// Initialiserer en ny instans av Docking-klassen med en spesifisert DockSpace og dateTime.
        /// </summary>
        /// <param name="dockSpace">DockSpace hvor dokkingen skal skje.</param>
        /// <param name="dateTime">Tidspunktet for når dokkingen skal skje.</param>
        public Docking(DockSpace dockSpace, DateTime dateTime)
        {
            this.dockSpace = dockSpace;
            timestamp = dateTime;
        }

        /// <summary>
        /// Planlegger en dokking for et gitt skip hvis skipstypen er tillatt i denne DockSpace.
        /// </summary>
        /// <param name="ship">Skipet som skal dokkes.</param>
        /// <exception cref="InvalidOperationException">Kastes hvis skipstypen ikke er tillatt i denne DockSpace.</exception>
        public void ScheduleDocking(Ship ship)
        {
            if (!dockSpace.AllowedShipTypes.Contains(ship.ShipType))
            {
                throw new InvalidOperationException("Ship type not allowed in this dock space.");
            }
            dockSpace.ScheduleShip(ship, timestamp);

            Console.WriteLine($"Docking scheduled for {ship.Name} at dock space number {dockSpace.DockSpaceNumber} on {timestamp.ToString("yyyy-MM-dd HH:mm:ss")}");
        }
    }

}
