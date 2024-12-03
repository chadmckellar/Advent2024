using System;
using System.IO;
using System.Linq;

public class Day1
{
    public static void Main()
    {
        var lines = File.ReadAllLines("1_input.txt");

        var l1 = lines.Select(line => int.Parse(line.Split("   ")[0])).ToArray();
        var l2 = lines.Select(line => int.Parse(line.Split("   ")[1])).ToArray();

        var ordered_l1 = l1.OrderBy(x => x).ToArray();
        var ordered_l2 = l2.OrderBy(x => x).ToArray();

        var sum = 0;
        for (int i = 0; i < ordered_l1.Length; i++)
        {
            sum += Math.Abs(ordered_l1[i] - ordered_l2[i]);
        }

        Console.WriteLine(sum);
    }
}

