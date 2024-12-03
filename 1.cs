using System;
using System.IO;
using System.Linq;

public class Day1
{
    public static void Part1()
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

    public static void Part2()
    {
        var lines = File.ReadAllLines("1_input.txt");

        var l1Dict = lines.Select(line => int.Parse(line.Split("   ")[0])).Distinct().ToDictionary(x => x, x => 0);
        var l2 = lines.Select(line => int.Parse(line.Split("   ")[1])).ToArray();

        foreach (var l2_item in l2)
        {
            if (l1Dict.ContainsKey(l2_item))
            {
                l1Dict[l2_item] += 1;
            }
        }

        var sum = l1Dict.Where(x => x.Value > 0).Sum(x => x.Key * x.Value);

        Console.WriteLine(sum);
    }
}

