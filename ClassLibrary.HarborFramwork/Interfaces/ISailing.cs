namespace ClassLibrary.HarborFramework.Utilities
{
    public interface ISailing
    {
        void AddSingleSailing(Ship ship);
        void AddRecurringSailing(Ship ship, DayOfWeek dayOfWeek);
        void RemoveSailing(Ship ship);
        List<Ship> GetSailingScheduleBasedOnDay(DateTime date);
        List<Ship> GetAllSailings();
    }
}