using System.Collections.Generic;
using System.Threading.Tasks;

namespace DailyPlanner.API.Repositories
{
    public interface IHabitRepository
    {
        Task<IEnumerable<Habit>> GetAllAsync();
        Task<Habit?> GetByIdAsync(int id);
        Task AddAsync(Habit habit);
        Task UpdateAsync(Habit habit);
        Task DeleteAsync(int id);
    }
}