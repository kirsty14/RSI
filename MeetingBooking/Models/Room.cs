namespace MeetingBooking.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
        public List<string> Facilities { get; set; } = new();
    }
}
