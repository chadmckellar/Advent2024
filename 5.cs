using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

public class Day5
{
    public static void Part1()
    {
        var lines1 = File.ReadAllLines("5_input_1.txt");
        var pairs = lines1.Select(line => line.Split('|').Select(int.Parse).ToArray()).ToArray();

        Dictionary<int, HashSet<int>> dict1 = new Dictionary<int, HashSet<int>>();
        Dictionary<int, HashSet<int>> dict2 = new Dictionary<int, HashSet<int>>();
        foreach (var pair in pairs)
        {
            if (dict1.ContainsKey(pair[0]))
                dict1[pair[0]].Add(pair[1]);
            else
                dict1[pair[0]] = new HashSet<int> { pair[1] };
        }
        foreach (var pair in pairs)
        {
            if (dict2.ContainsKey(pair[1]))
                dict2[pair[1]].Add(pair[0]);
            else
                dict2[pair[1]] = new HashSet<int> { pair[0] };
        }


        var lines2 = File.ReadAllLines("5_input_2.txt");
        var rows = lines2.Select(line => line.Split(',').Select(int.Parse).ToArray()).ToArray();

        int sum = 0;
        foreach (var row in rows)
        {
            int i = 0;
            bool valid = true;
            foreach (var num in row)
            {
                if (dict1.ContainsKey(num))
                {
                    // dict 1 has a key of num, where the values cannot appear before it
                    foreach (var n in row.Take(i))
                    {
                        if (dict1[num].Contains(n))
                        {
                            valid = false;
                            break;
                        }
                    }
                }
                if (dict2.ContainsKey(num))
                {
                    // dict 2 has a key of num, where the values cannot appear after it
                    foreach (var n in row.Skip(i))
                    {
                        if (dict2[num].Contains(n))
                        {
                            valid = false;
                            break;
                        }
                    }
                }
                i++;
            }
            if (valid)
                sum += row[i / 2];
        }
        Console.WriteLine(sum);
    }


    public static void Part2()
    {

    }

}
