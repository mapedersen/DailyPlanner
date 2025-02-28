public class Habit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Habit(string name, string description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }

    public void PrintHabit()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Created At: {CreatedAt}");
    }
}