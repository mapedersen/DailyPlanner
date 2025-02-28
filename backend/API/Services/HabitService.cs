using DailyPlanner.API.Repositories;

namespace DailyPlanner.API.Services
{
    public class HabitService
    {
        private readonly IHabitRepository _habitRepository;

        public HabitService(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        public async Task<IEnumerable<Habit>> GetHabitsAsync()
        {
            return await _habitRepository.GetAllHabitsAsync();
        }

        public async Task<Habit?> GetHabitByIdAsync(int id)
        {
            return await _habitRepository.GetHabitByIdAsync(id);
        }

        public async Task AddHabitAsync(Habit habit)
        {
            // Example business rule: Prevent adding duplicate habits
            var habits = await _habitRepository.GetAllHabitsAsync();
            if (!habits.Any(h => h.Name == habit.Name))
            {
                await _habitRepository.AddHabitAsync(habit);
            }
        }

        public async Task DeleteHabitAsync(int id)
        {
            await _habitRepository.DeleteHabitAsync(id);
        }
    }
}