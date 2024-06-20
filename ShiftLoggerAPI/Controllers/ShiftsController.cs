using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftLoggerAPI.Data;
using ShiftLoggerAPI.Models;

namespace ShiftLoggerAPI.Controllers
{
    [Route("api/shifts")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly DataContext _context;

        public ShiftsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostShift(Shift shift)
        {
            _context.Shifts.Add(shift);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShifts()
        {
            var shifts = await _context.Shifts.ToListAsync();
            return Ok(shifts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShiftById(int id)
        {
            var shift = await _context.Shifts.FindAsync(id);
            if (shift == null) return NotFound("Shift not found");
            return Ok(shift);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShifts(Shift updatedShift)
        {
            var shiftDb = await _context.Shifts.FindAsync(updatedShift.Id);
            if (shiftDb == null) return NotFound("Shift not found");

            shiftDb.FullName = updatedShift.FullName;
            shiftDb.StartTime = updatedShift.StartTime;
            shiftDb.EndTime = updatedShift.EndTime;
            shiftDb.Duration = updatedShift.Duration;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShift(int id)
        {
            var shiftDb = await _context.Shifts.FindAsync(id);
            if (shiftDb == null) return NotFound("Shift not found");

            _context.Shifts.Remove(shiftDb);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}