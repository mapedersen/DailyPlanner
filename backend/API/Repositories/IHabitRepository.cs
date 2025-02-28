using System.Collections.Generic;
using System.Threading.Tasks;

namespace DailyPlanner.API.Repositories
{
    public interface IHabitRepository
    {
        Task<IEnumerable<Habit>> GetAllHabitsAsync();
        Task<Habit?> GetHabitByIdAsync(int id);
        Task AddHabitAsync(Habit habit);
        Task DeleteHabitAsync(int id);
    }
}