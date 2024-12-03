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

            var i = 0;
            if (numbers[i] > numbers[i + 1])
            {
                while (numbers[i] > numbers[i + 1] && Math.Abs(numbers[i] - numbers[i + 1]) <= 3)
                {
                    i++;
                    if (i == numbers.Length - 1)
                    {
                        safeCount++;
                        break;
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
                        safeCount++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(safeCount);
    }

    public static void Part2()
    {

    }
}

