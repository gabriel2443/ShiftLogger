using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Data;
using ShiftsLogger.Models;

namespace ShiftsLogger.Services;

public class ShiftService
{
    private readonly DataContext context = new DataContext();

    public async Task<List<Shift>> GetShifts()
    {
        var shifts = await context.Shifts.ToListAsync();

        return shifts;
    }

    public async Task<Shift> GetShiftById(int id)
    {
        var shiftId = await context.Shifts.FindAsync(id);

        return shiftId;
    }

    public async Task AddShift(Shift shift)
    {
        context.Add(shift);

        await context.SaveChangesAsync();
    }

    public async Task UpdateShift(Shift shift)
    {
        var dbShift = await context.Shifts.FindAsync(shift.Id);
        dbShift.Name = shift.Name;
        dbShift.DateStart = shift.DateStart;
        dbShift.DateEnd = shift.DateEnd;
        dbShift.Duration = shift.Duration;

        await context.SaveChangesAsync();
    }

    public async Task<bool> DeleteShift(int id)
    {
        var dbShift = await context.Shifts.FindAsync(id);
        if (dbShift == null) return false;
        context.Remove(dbShift);

        await context.SaveChangesAsync();
        return true;
    }
}