using ClassLibrary.HarborFramework.ContainerYardInfo;

namespace ClassLibrary.HarborFramework.Interfaces
{
    public interface ITransportVehicle
    {
        public void LoadContainer(Container container);
        public void DeliverContainer(string destination);
    }
}