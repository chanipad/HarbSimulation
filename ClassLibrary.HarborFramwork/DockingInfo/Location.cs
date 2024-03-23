using ClassLibrary.HarborFramework.ContainerYardInfo;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    /// <summary>
    /// Representerer en lokasjon med tilknytning til en spesifikk dokkplass og et tidspunkt.
    /// </summary>
    public class Location
    {
        public List<Container> Containers { get; private set; } = new List<Container>();

        /// <summary>
        /// Identifikatoren for dokkplassen assosiert med denne lokasjonen.
        /// </summary>
        public string DockLocation { get; private set; }


        /// <summary>
        /// Initialiserer en ny instans av Location-klassen med en lokasjon for lagringsplasser for containere.
        /// </summary>
        /// <param name="dockLocation">Identifikatoren for lokasjon for lagringsplasser for containere. </param>
        public Location(string dockLocation)
        {
            DockLocation = dockLocation;
        }

        public void AddContainer(Container container)
        {
            Containers.Add(container);
            container. = this; // Oppdaterer containerens lokasjon
        }
    }
}
