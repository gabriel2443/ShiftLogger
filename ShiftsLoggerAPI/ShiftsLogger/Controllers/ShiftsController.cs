using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.Models;
using ShiftsLogger.Services;

namespace ShiftsLogger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftsController : ControllerBase
{
    private readonly ShiftService service = new ShiftService();

    [HttpGet]
    public async Task<IActionResult> GetAllShifts()
    {
        var shifts = await service.GetShifts();

        return Ok(shifts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShiftById(int id)
    {
        var shitId = await service.GetShiftById(id);

        if (shitId is null) return NotFound("Id not found");

        return Ok(shitId);
    }

    [HttpPost]
    public async Task<IActionResult> AddShift(Shift shift)
    {
        await service.AddShift(shift);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditShift(Shift shift)
    {
        await service.UpdateShift(shift);
        if (shift is null) return BadRequest("Shift does not exist");
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteShift(id);
        if (!result) return NotFound();
        return NoContent();
    }
}