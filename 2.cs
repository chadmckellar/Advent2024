using System;
using System.IO;
using System.Linq;

public class Day2
{
    public static void Part1()
    {
        var lines = File.ReadAllLines("2_input.txt");

        var safeCount = 0;
        foreach (var line in lines)
        {
            var numbers = line.Split(" ").Select(x => int.Parse(x)).ToArray();

            if (IsSafe(numbers))
            {
                safeCount++;
            }
        }

        Console.WriteLine(safeCount);
    }

    public static void Part2()
    {
        var lines = File.ReadAllLines("2_input.txt");

        var safeCount = 0;
        foreach (var line in lines)
        {
            var numbers = line.Split(" ").Select(x => int.Parse(x)).ToArray();
            if (IsSafe(numbers))
            {
                safeCount++;
                continue;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var numbers_copy = numbers.Take(i).Concat(numbers.Skip(i + 1)).ToArray();
                if (IsSafe(numbers_copy))
                {
                    safeCount++;
                    break;
                }
            }
        }

        Console.WriteLine(safeCount);
    }

    public static bool IsSafe(int[] numbers)
    {
        var i = 0;
        if (numbers[i] > numbers[i + 1])
        {
            while (numbers[i] > numbers[i + 1] && Math.Abs(numbers[i] - numbers[i + 1]) <= 3)
            {
                i++;
                if (i == numbers.Length - 1)
                {
                    return true;
                }
            }
        }
        else if (numbers[i] < numbers[i + 1])
        {
            while (numbers[i] < numbers[i + 1] && Math.Abs(numbers[i] - numbers[i + 1]) <= 3)
            {
                i++;
                if (i == numbers.Length - 1)
                {
                    return true;
                }
            }
        }

        return false;
    }
}

