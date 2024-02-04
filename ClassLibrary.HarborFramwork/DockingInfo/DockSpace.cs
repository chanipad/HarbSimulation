using ClassLibrary.HarborFramework.ShipInfo;

namespace ClassLibrary.HarborFramwork.DockingInfo
{
    public class DockSpace
    {
        private int dockSpaceNumber { get; set; }
        private DockSpaceType type { get; set; }
        private List<ShipType> allowedShipTypes { get; set; }

        public void configuraDockSpace() { }
    }
}
