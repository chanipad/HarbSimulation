namespace ClassLibrary.HarborFramwork.DockingInfo
{
    internal class WaitingStation
    {
        public int locationNumber { get; set; }

        public bool IsLocationBusy(List<Docking> scheduledDockings)
        {
            return scheduledDockings.Any(d => d.DockSpace.DockSpaceNumber == LocationNumber);
        }
    }
}
