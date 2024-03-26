using ClassLibrary.HarborFramework.ContainerYardInfo;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    /// <summary>
    /// Representerer en lokasjon med tilknytning til en spesifikk dokkplass og et tidspunkt.
    /// </summary>
    public class Location
    {
        public DateTime Timestamp { get; set; }
        public List<Container> Containers { get; private set; } = new List<Container>();

        /// <summary>
        /// Identifikatoren for dokkplassen assosiert med denne lokasjonen.
        /// </summary>
        public string location { get; private set; }


        /// <summary>
        /// Initialiserer en ny instans av Location-klassen med en lokasjon for lagringsplasser for containere.
        /// </summary>
        /// <param name="TheLocation">Identifikatoren for lokasjon for containere. </param>
        public Location(string TheLocation)
        {
            location = location;
        }

    }
}
