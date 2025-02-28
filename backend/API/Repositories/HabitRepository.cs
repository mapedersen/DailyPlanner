using Microsoft.EntityFrameworkCore;

public class HabitRepository
{
    private readonly ApplicationDbContext _context;

    public HabitRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Habit>> GetAllHabitsAsync()
    {
        return await _context.Habits.ToListAsync();
    }

    public async Task<Habit?> GetHabitByIdAsync(int id)
    {
        return await _context.Habits.FindAsync(id);
    }

    public async Task AddHabitAsync(Habit habit)
    {
        _context.Habits.Add(habit);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHabitAsync(int id)
    {
        var habit = await _context.Habits.FindAsync(id);
        if (habit != null)
        {
            _context.Habits.Remove(habit);
            await _context.SaveChangesAsync();
        }
    }
}
