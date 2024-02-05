using ClassLibrary.HarborFramework.ShipInfo;

namespace ClassLibrary.HarborFramwork.Utilities
{
    public class Inspection
    {
        private DateTime inspectionDate { get; set; }
        private Ship shipUpForInspection { get; set; }
        public static void performInspection() { Inspection.performInspection(); }
    }

    /// <summary>
    /// Schedules a random inspection from a list of ships.
    /// </summary>
    /// <param name="ships">List of ships to choose from.</param>
    public void ScheduleRandomInspection(List<Ship> ships)
    {
        if (ships == null || ships.Count == 0)
        {
            throw new ArgumentException("Ship list cannot be null or empty.");
        }

        Random rnd = new Random();
        int index = rnd.Next(ships.Count);
        this.shipUpForInspection = ships[index];
    }
}
