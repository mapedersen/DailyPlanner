public class Habit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    private DateTime _createdAt;
    public DateTime CreatedAt
    {
        get => _createdAt;
        set => _createdAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    public Habit(string name, string description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }

    public void PrintHabit()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Created At: {CreatedAt}");
    }
}