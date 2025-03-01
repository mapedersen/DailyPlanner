using Microsoft.EntityFrameworkCore;

namespace DailyPlanner.API.Repositories
{
    public class HabitRepository : IHabitRepository
    {
        private readonly ApplicationDbContext _context;

        public HabitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Habit>> GetAllAsync()
        {
            return await _context.Habits.ToListAsync();
        }

        public async Task<Habit?> GetByIdAsync(int id)
        {
            return await _context.Habits.FindAsync(id);
        }

        public async Task AddAsync(Habit habit)
        {
            _context.Habits.Add(habit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Habit habit)
        {
            _context.Habits.Update(habit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit != null)
            {
                _context.Habits.Remove(habit);
                await _context.SaveChangesAsync();
            }
        }
    }
}