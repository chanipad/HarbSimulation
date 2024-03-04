using ClassLibrary.HarborFramwork.Exceptions;

namespace ClassLibrary.HarborFramework.ContainerYardInfo
{
    /// <summary>
    /// Representerer et containerområde med funksjonalitet for å administrere containere og planlegge lasteoperasjoner.
    /// </summary>
    public class ContainerYard
    {
        /// <summary>
        /// Får lokasjonen til containerområdet.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// Setter start og slutt tid for en lasteopperasjon
        /// </summary>
        public class LasteOperasjon
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }

        private List<Container> Containers { get; set; } = new List<Container>();
        private List<LasteOperasjon> LasteOperasjoner { get; set; } = new List<LasteOperasjon>();

        /// <summary>
        /// Initialiserer en ny instans av <see cref="ContainerYard"/> klassen med en spesifikk lokasjon.
        /// </summary>
        /// <param name="location">Lokasjonen til containerområdet.</param>
        public ContainerYard(string location)
        {
            Location = location;
        }

        /// <summary>
        /// Legger til en container i containerområdet.
        /// </summary>
        /// <param name="container">Containeren som skal legges til.</param>
        public void AddContainer(Container container)
        {
            try
            {
                Containers.Add(container);
            }
            catch (Exception ex)
            {
                throw new ContainerException("Fail to add new container to yard.", ex);
            }
        }

        /// <summary>
        /// Henter en spesifikk container basert på container-ID.
        /// </summary>
        /// <param name="containerId">IDen til containeren som skal hentes.</param>
        /// <returns>Den funnete containeren, eller null hvis ingen container med den IDen ble funnet.</returns>
        public Container GetContainer(int containerId)
        {
            return Containers.Find(c => c.ContainerId == containerId);
        }

        /// <summary>
        /// Henter en liste over alle containere i containerområdet.
        /// </summary>
        /// <returns>En liste over alle containere.</returns>
        public List<Container> GetAllContainers()
        {
            return new List<Container>(Containers);
        }

        /// <summary>
        /// Planlegger en lasteoperasjon for en spesifikk container og legger til den planlagte tiden i listen over tidsintervaller.
        /// Sjekker for overlapp med eksisterende tidsintervaller for å unngå konflikter.
        /// </summary>
        /// <param name="containerId">IDen til containeren som lasteoperasjonen gjelder for.</param>
        /// <param name="startTime">Starttid for lasteoperasjonen.</param>
        /// <param name="endTime">Sluttid for lasteoperasjonen.</param>
        public void ScheduleLoading(int containerId, DateTime startTime, DateTime endTime)
        {
            var container = GetContainer(containerId);
            if (container != null)
            {
                // Sjekker om det er noen overlapp med eksisterende tidsintervaller
                var overlap = LasteOperasjoner.Any(op => op.StartTime < endTime && op.EndTime > startTime);
                if (!overlap)
                {
                    LasteOperasjoner.Add(new LasteOperasjon { StartTime = startTime, EndTime = endTime });
                    Console.WriteLine($"Loading for container {containerId} scheduled from {startTime} to {endTime}.");
                }
                else
                {
                    Console.WriteLine("Cannot schedule loading: Time slot overlaps with an existing operation.");
                }
            }
            else
            {
                Console.WriteLine("Container not found.");
            }
        }
    }
}
