﻿using Auth.Models;

namespace Domain.Model.PilotDocuments;

public class LogBook : ModelBase
{
    public DateOnly Date { get; set; }
    public string Departure { get; set; } = string.Empty;
    public TimeOnly DepartureTime { get; set; }
    public string Arrival { get; set; } = string.Empty;
    public TimeOnly ArrivalTime { get; set; }
    public string AirplaneType { get; set; } = string.Empty;
    public string CallSign { get; set; } = string.Empty;
    public TimeOnly TotalFlightTime { get; set; }
    public string PilotName { get; set; } = string.Empty;
    public int VfrTakeoff { get; set; }
    public int VfrLanding { get; set; }
    public int NightTakeoff { get; set; }
    public int NightLanding { get; set; }
    public TimeOnly PicTime { get; set; }
    public TimeOnly DualTime { get; set; }
    public TimeOnly InstructorTime { get; set; }
    public string Description { get; set; } = string.Empty;

    // New fields to link the LogBook to a specific user
    public string UserId { get; set; }  // Foreign key
    public ApplicationUser User { get; set; }  // Navigation property
}
