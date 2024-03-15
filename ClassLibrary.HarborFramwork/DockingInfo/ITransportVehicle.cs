using ClassLibrary.HarborFramework.ContainerYardInfo;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    public interface ITransportVehicle
    {
        void LoadContainer(Container container, string v);
        void LoadContainer(Container container);
    }
}