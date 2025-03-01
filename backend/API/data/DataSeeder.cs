using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    public static void SeedDatabase(ApplicationDbContext context)
    {
        context.Database.Migrate();

        if (!context.Habits.Any())
        {
            var habits = new List<Habit>
            {
                new Habit("Morning Workout", "Exercise for 30 minutes") { CreatedAt = DateTime.UtcNow },
                new Habit("Read a Book", "Read for at least 20 minutes") { CreatedAt = DateTime.UtcNow },
                new Habit("Meditation", "Practice mindfulness for 10 minutes") { CreatedAt = DateTime.UtcNow },
                new Habit("Daily Journal", "Write down thoughts and reflections") { CreatedAt = DateTime.UtcNow },
                new Habit("Drink Water", "Stay hydrated by drinking 8 glasses of water") { CreatedAt = DateTime.UtcNow }
            };

            context.Habits.AddRange(habits);
            context.SaveChanges();
        }
    }
}
