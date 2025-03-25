namespace MeetingBooking.Models
{
    public class CalendarModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public DayOfWeek FirstDayOfMonth { get; set; }
        public List<DateTime>? DaysWithEvents { get; set; }
        public Dictionary<DateTime, List<TimeSpan>>? AvailableSlots { get; set; }
        public DateTime SelectedDate { get; set; } = DateTime.Today;
    }
}
