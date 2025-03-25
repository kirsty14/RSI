using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MeetingBooking.Models;
using System.Globalization;

namespace MeetingBooking.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult MeetingRoomHome()
    {
        var rooms = new List<Room>
            {
                new Room { Id = 1, Name = "Focus Room", Status = "active", Description = "Small room for discussions.", URL = "/images/FocusRoom.jpg", Facilities = new List<string> { "WiFi", "Whiteboard", "TV" } },
                new Room { Id = 2, Name = "Meeting Room", Status = "maintenance", Description = "Spacious room with projector.", URL = "/images/ExecutiveBoardroom.jpg", Facilities = new List<string> { "Projector", "WiFi", "Conference Phone" } },
                new Room { Id = 3, Name = "Brainstorm Room", Status = "active", Description = "Creative space with idea boards.", URL = "/images/CreativeRoom.jpg", Facilities = new List<string> { "Idea Board", "WiFi", "Coffee Machine" } },
                new Room { Id = 4, Name = "Lounge", Status = "active", Description = "Relaxation and informal discussions.", URL = "/images/TeamCollaborationRoom.jpg", Facilities = new List<string> { "Sofas", "WiFi", "TV" } },
                new Room { Id = 5, Name = "Training Room", Status = "maintenance", Description = "Equipped for workshops.", URL = "/images/TrainRoom.jpg", Facilities = new List<string> { "Projector", "Microphone", "Desks" } }
            };

        return View(rooms);
    }


    public IActionResult BookMeetingRoom(int year = 2025, int month = 3)
    {
        var availableSlots = GetAvailableSlots(year, month);
        var model = new CalendarModel
        {
            Year = year,
            Month = month,
            DaysWithEvents = GetEventDays(year, month),
            FirstDayOfMonth = new DateTime(year, month, 1).DayOfWeek,
            AvailableSlots = availableSlots,
            SelectedDate = DateTime.Today
        };

        return View(model);
    }

    private List<DateTime> GetEventDays(int year, int month)
    {
        var eventDays = new List<DateTime>
    {
        new DateTime(year, month, 5),
        new DateTime(year, month, 10),
        new DateTime(year, month, 15)
    };

        return eventDays;
    }

    private Dictionary<DateTime, List<TimeSpan>> GetAvailableSlots(int year, int month)
    {
        var availableSlots = new Dictionary<DateTime, List<TimeSpan>>();

        for (var day = 1; day <= DateTime.DaysInMonth(year, month); day++)
        {
            var date = new DateTime(year, month, day);
            var slots = new List<TimeSpan>();

            for (var hour = 8; hour < 18; hour++)
            {
                for (var minute = 0; minute < 60; minute += 15)
                {
                    slots.Add(new TimeSpan(hour, minute, 0));
                }
            }

            availableSlots[date] = slots;
        }

        return availableSlots;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
