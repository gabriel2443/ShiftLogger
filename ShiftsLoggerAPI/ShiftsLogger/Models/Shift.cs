namespace ShiftsLogger.Models;

public class Shift
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public DateTime Duration { get; set; }
}