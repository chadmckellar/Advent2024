// Run advent of code 2024 solutions
Console.WriteLine("Enter the day number (1-25):");
if (!int.TryParse(Console.ReadLine(), out int day) || day < 1 || day > 25)
{
    Console.WriteLine("Invalid input. Please enter a number between 1 and 25.");
    return;
}

DateTime start = DateTime.Now;

try
{
    // Get the type for the requested day
    Type? dayType = Type.GetType($"Day{day}");
    if (dayType == null)
    {
        Console.WriteLine($"Day {day} not implemented yet.");
        return;
    }

    // Call Part1 and Part2 methods
    var part1Method = dayType.GetMethod("Part1");
    var part2Method = dayType.GetMethod("Part2");

    if (part1Method != null && part2Method != null)
    {
        part1Method.Invoke(null, null);
        part2Method.Invoke(null, null);
    }
    else
    {
        Console.WriteLine($"Day {day} methods not found.");
        return;
    }
}
catch (Exception)
{
    Console.WriteLine($"Day {day} not implemented yet.");
    return;
}

DateTime end = DateTime.Now;
Console.WriteLine($"Time for Day {day}: {end - start}");
