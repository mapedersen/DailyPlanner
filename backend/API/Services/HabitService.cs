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

        public async Task<IEnumerable<Habit>> GetAllAsync()
        {
            return await _habitRepository.GetAllAsync();
        }

        public async Task<Habit?> GetByIdAsync(int id)
        {
            return await _habitRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Habit habit)
        {
            if (string.IsNullOrWhiteSpace(habit.Name))
                throw new ArgumentException("Habit name cannot be empty");

            await _habitRepository.AddAsync(habit);
        }

        public async Task UpdateAsync(Habit habit)
        {
            await _habitRepository.UpdateAsync(habit);
        }

        public async Task DeleteAsync(int id)
        {
            await _habitRepository.DeleteAsync(id);
        }
    }

}