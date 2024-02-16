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

        private List<Container> Containers { get; set; } = new List<Container>();
        private List<TimeSlot> LasteOperasjoner { get; set; } = new List<TimeSlot>();

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
            Containers.Add(container);
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
        /// <param name="startTime">Starttidspunktet for lasteoperasjonen.</param>
        /// <param name="endTime">Sluttidspunktet for lasteoperasjonen.</param>
        public void ScheduleLoading(int containerId, DateTime startTime, DateTime endTime)
        {
            var container = GetContainer(containerId);
            if (container != null)
            {
                var overlap = LasteOperasjoner.Exists(ts => ts.startTime < endTime && ts.endTime > startTime);
                if (!overlap)
                {
                    LasteOperasjoner.Add(new TimeSlot { startTime = startTime, endTime = endTime });
                    Console.WriteLine($"Loading for container {containerId} scheduled at {Location} from {startTime} to {endTime}.");
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
