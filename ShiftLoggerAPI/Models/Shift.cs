using System.ComponentModel.DataAnnotations;

namespace ShiftLoggerAPI.Models;

public class Shift
{
    public int Id { get; set; }

    [Required]
    public string? FullName { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public TimeSpan Duration { get; set; }
}