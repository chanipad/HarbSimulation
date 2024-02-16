/// <summary>
/// Representerer informasjon om tidevannsnivåer til forskjellige tider.
/// </summary>
public class TideInformation
{
    /// <summary>
    /// Lagrer tidevannsnivåer med tilhørende dato og tid som nøkkel.
    /// </summary>
    private Dictionary<DateTime, double> tideLevel;

    /// <summary>
    /// Initialiserer en ny instans av TideInformation-klassen.
    /// </summary>
    public TideInformation()
    {
        tideLevel = new Dictionary<DateTime, double>();
    }

    /// <summary>
    /// Setter tidevannsnivået for en spesifikk dato og tid.
    /// </summary>
    /// <param name="dateTime">Dato og tid for tidevannsnivået som skal settes.</param>
    /// <param name="level">Tidevannsnivået på spesifisert dato og tid.</param>
    public void SetTideLevel(DateTime dateTime, double level)
    {
        tideLevel[dateTime] = level;
    }

    /// <summary>
    /// Henter tidevannsnivået for en spesifikk dato og tid.
    /// </summary>
    /// <param name="dateTime">Dato og tid for det ønskede tidevannsnivået.</param>
    /// <returns>Tidevannsnivået for den angitte datoen og tiden. Returnerer -1 dersom informasjon ikke er tilgjengelig.</returns>
    public double GetTideLevel(DateTime dateTime)
    {
        if (tideLevel.ContainsKey(dateTime))
        {
            return tideLevel[dateTime];
        }
        else
        {
            // Returnerer en standardverdi som indikerer at tidevannsinformasjon ikke er tilgjengelig
            return (double)-1;
        }
    }
}
