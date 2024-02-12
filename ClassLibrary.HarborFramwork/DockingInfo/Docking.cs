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
        public TimeSlot timestamp { get; set; }

        /// <summary>
        /// Initialiserer en ny instans av Docking-klassen med en spesifisert DockSpace og TimeSlot.
        /// </summary>
        /// <param name="dockSpace">DockSpace hvor dokkingen skal skje.</param>
        /// <param name="timeSlot">Tidspunktet for når dokkingen skal skje.</param>
        public Docking(DockSpace dockSpace, TimeSlot timeSlot)
        {
            this.dockSpace = dockSpace;
            timestamp = timeSlot;
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

            Console.WriteLine($"Docking scheduled for {ship.Name} at dock space number {dockSpace.DockSpaceNumber} on {timestamp.startTime}");
        }
    }

}
