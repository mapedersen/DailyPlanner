using DailyPlanner.API.Repositories;
using DailyPlanner.API.Services;
using Moq;

namespace API.Tests
{
    public class HabitServiceTests
    {
        private readonly Mock<IHabitRepository> _habitRepositoryMock;
        private readonly HabitService _habitService;

        public HabitServiceTests()
        {
            _habitRepositoryMock = new Mock<IHabitRepository>();  // Mock the interface, not the class
            _habitService = new HabitService(_habitRepositoryMock.Object);
        }

        [Fact]
        public async Task GetHabitsAsync_ReturnsAllHabits()
        {
            var fakeHabits = new List<Habit>
        {
            new Habit("Workout", "Exercise for 30 minutes"),
            new Habit("Read", "Read a book for 20 minutes")
        };

            _habitRepositoryMock.Setup(repo => repo.GetAllHabitsAsync()).ReturnsAsync(fakeHabits);

            var habits = await _habitService.GetHabitsAsync();

            Assert.Equal(2, habits.Count());
            Assert.Contains(habits, h => h.Name == "Workout");
            Assert.Contains(habits, h => h.Name == "Read");
        }

        [Fact]
        public async Task AddHabitAsync_AddsHabit_WhenNotDuplicate()
        {
            var fakeHabits = new List<Habit> { new Habit("Workout", "Exercise for 30 minutes") };
            var newHabit = new Habit("Read", "Read a book for 20 minutes");

            _habitRepositoryMock.Setup(repo => repo.GetAllHabitsAsync()).ReturnsAsync(fakeHabits);
            _habitRepositoryMock.Setup(repo => repo.AddHabitAsync(newHabit)).Returns(Task.CompletedTask);

            await _habitService.AddHabitAsync(newHabit);

            _habitRepositoryMock.Verify(repo => repo.AddHabitAsync(newHabit), Times.Once);
        }

        [Fact]
        public async Task AddHabitAsync_DoesNotAddDuplicateHabit()
        {
            var fakeHabits = new List<Habit> { new Habit("Workout", "Exercise for 30 minutes") };
            var duplicateHabit = new Habit("Workout", "Exercise for 30 minutes");

            _habitRepositoryMock.Setup(repo => repo.GetAllHabitsAsync()).ReturnsAsync(fakeHabits);

            await _habitService.AddHabitAsync(duplicateHabit);

            _habitRepositoryMock.Verify(repo => repo.AddHabitAsync(It.IsAny<Habit>()), Times.Never);
        }

        [Fact]
        public async Task DeleteHabitAsync_CallsRepositoryDelete()
        {
            var habitId = 1;
            _habitRepositoryMock.Setup(repo => repo.DeleteHabitAsync(habitId)).Returns(Task.CompletedTask);

            await _habitService.DeleteHabitAsync(habitId);

            _habitRepositoryMock.Verify(repo => repo.DeleteHabitAsync(habitId), Times.Once);
        }
    }
}