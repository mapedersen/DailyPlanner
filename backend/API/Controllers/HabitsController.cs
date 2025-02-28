using DailyPlanner.API.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class HabitsController : ControllerBase
{
    private readonly HabitService _habitService;

    public HabitsController(HabitService habitService)
    {
        _habitService = habitService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Habit>>> GetHabits()
    {
        return Ok(await _habitService.GetHabitsAsync());
    }

    [HttpPost]
    public async Task<ActionResult<Habit>> CreateHabit(Habit habit)
    {
        await _habitService.AddHabitAsync(habit);
        return CreatedAtAction(nameof(GetHabits), new { id = habit.Id }, habit);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHabit(int id)
    {
        await _habitService.DeleteHabitAsync(id);
        return NoContent();
    }
}
