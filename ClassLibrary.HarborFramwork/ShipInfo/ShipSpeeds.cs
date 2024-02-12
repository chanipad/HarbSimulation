using static ClassLibrary.HarborFramework.Enums;

namespace ClassLibrary.HarborFramework.ShipInfo
{
    /// <summary>
    /// Tilbyr hjelpemetoder relatert til fart på ulike typer skip.
    /// </summary>
    public class ShipSpeeds
    {
        /// <summary>
        /// Henter fart for en gitt type skip.
        /// </summary>
        /// <param name="shipType">Typen skip som fart skal hentes for.</param>
        /// <returns>Farten til skipet i nautiske mil per time.</returns>
        /// <exception cref="ArgumentException">Kastes hvis en ugyldig skipstype er angitt.</exception>
        public static int GetSpeed(ShipType shipType)
        {
            switch (shipType)
            {
                case ShipType.CARGO_SHIP:
                    return 20;
                case ShipType.CRUISE_SHIP:
                    return 30;
                case ShipType.LEISURE_BOAT:
                    return 50;
                default:
                    throw new ArgumentException("Ugyldig skipstype");
            }
        }

        /// <summary>
        /// Beregner reisetiden for et skip gitt en distanse.
        /// </summary>
        /// <param name="shipType">Typen skip som reisetiden beregnes for.</param>
        /// <param name="distance">Distanse i meter som skipet skal reise.</param>
        /// <returns>Reisetiden i minutter basert på skipets fart og gitt distanse.</returns>
        /// <exception cref="InvalidOperationException">Kastes hvis det oppstår en feil med skipets fart.</exception>
        public static int TravelTime(ShipType shipType, int distance)
        {
            int speed = GetSpeed(shipType);

            if (speed > 0)
            {
                int timeInMinutes = distance / speed;
                return timeInMinutes;
            }
            else
            {
                throw new InvalidOperationException("Feil med fart!");
            }
        }
    }
}
