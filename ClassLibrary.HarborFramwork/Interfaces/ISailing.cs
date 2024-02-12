namespace ClassLibrary.HarborFramework.Utilities
{
    public interface ISailingSchedule
    {
        void AddSingleSailing(Ship ship, DateTime sailingDate);
        void AddRecurringSailing(Ship ship, DayOfWeek dayOfWeek);
        void RemoveSailing(Ship ship);
        List<Ship> GetSailingsOn(DateTime date);
    }
}