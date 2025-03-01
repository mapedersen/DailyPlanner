using DailyPlanner.API.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/habits")]
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
        return Ok(await _habitService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Habit>> GetHabit(int id)
    {
        var habit = await _habitService.GetByIdAsync(id);
        if (habit == null) return NotFound();
        return Ok(habit);
    }

    [HttpPost]
    public async Task<ActionResult> CreateHabit(Habit habit)
    {
        await _habitService.AddAsync(habit);
        return CreatedAtAction(nameof(GetHabit), new { id = habit.Id }, habit);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHabit(int id, Habit habit)
    {
        if (id != habit.Id) return BadRequest();
        await _habitService.UpdateAsync(habit);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHabit(int id)
    {
        await _habitService.DeleteAsync(id);
        return NoContent();
    }
}
