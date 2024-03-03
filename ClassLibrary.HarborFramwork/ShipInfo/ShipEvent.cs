using ClassLibrary.HarborFramework.DockingInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.ShipInfo
{
    /// <summary>
    /// Representerer en hendelse relatert til et skip, som inkluderer tidspunkt, lokasjon (DockSpace), og hendelsestypen.
    /// </summary>
    public class ShipEvent
    {
        /// <summary>
        /// Får eller setter tidspunktet når hendelsen skjer.
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Får eller setter dokkplassen der hendelsen finner sted.
        /// </summary>
        public DockSpace DockSpace { get; set; }

        /// <summary>
        /// Får eller setter typen av hendelsen, definert i Enums.EventType.
        /// </summary>
        public Enums.EventType Type { get; set; }

        /// <summary>
        /// Initialiserer en ny instans av ShipEvent-klassen med spesifisert tidspunkt, dokkplass, og hendelsestype.
        /// </summary>
        /// <param name="eventTime">Tidspunktet når hendelsen skjer.</param>
        /// <param name="dockSpace">Dokkplassen der hendelsen finner sted.</param>
        /// <param name="type">Typen av hendelsen, definert i Enums.EventType.</param>
        public ShipEvent(DateTime eventTime, DockSpace dockSpace, Enums.EventType type)
        {
            EventTime = eventTime;
            DockSpace = dockSpace;
            Type = type;
        }
    }

}
