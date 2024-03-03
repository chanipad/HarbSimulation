using ClassLibrary.HarborFramework.ContainerYardInfo;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    /// <summary>
    /// Representerer en lasteoperasjon for containere ved en spesifikk containergård og tidspunkt.
    /// </summary>
    public class Loading
    {
        /// <summary>
        /// Får stedet hvor lastingen skjer. Typen er objekt for å tillate forskjellige typer lasteplasser.
        /// </summary>
        public object LoadingPlace { get; private set; }

        /// <summary>
        /// Får containergården hvor lastingen finner sted.
        /// </summary>
        public ContainerYard ContainerYards { get; private set; }

        /// <summary>
        /// Får tidspunktet for når lasteoperasjonen er planlagt.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Initialiserer en ny instans av Loading-klassen med en spesifisert containergård og tidspunkt for lasteoperasjonen.
        /// </summary>
        /// <param name="containerYards">Containergården hvor lastingen finner sted.</param>
        /// <param name="timeSlot">Tidspunktet for når lasteoperasjonen er planlagt.</param>
        public Loading(ContainerYard containerYards, DateTime timeSlot)
        {
            ContainerYards = containerYards;
            Timestamp = timeSlot;
        }

        /// <summary>
        /// Planlegger en lasteoperasjon og skriver ut informasjon om planleggingen til konsollen.
        /// </summary>
        public void ScheduleLoading()
        {
            Console.WriteLine($"Loading scheduled at {ContainerYards.Location} on {Timestamp}");
        }
    }

}
