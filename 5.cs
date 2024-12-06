using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

public class Day5
{
    public static void Solution()
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

        var lines2 = File.ReadAllLines("5_input_2.txt");
        var rows = lines2.Select(line => line.Split(',').Select(int.Parse).ToArray()).ToArray();

        int sumPart1 = 0;
        int sumPart2 = 0;
        foreach (var row in rows)
        {
            int i = 1;
            bool valid = true;
            foreach (var num in row.Take(row.Length - 1).Skip(1))
            {
                if (dict1.ContainsKey(num))
                {
                    // dict 1 has a key of num, where the values cannot appear before it
                    int n = row[i - 1];
                    if (dict1[num].Contains(n))
                    {
                        valid = false;
                    }
                }
                if (!valid)
                    break;
                i++;
            }
            if (valid)
                sumPart1 += row[i / 2];
            else
            {
                // order the row according to the dict ordering rules
                var orderedRow = new List<int>(row);
                bool changed;
                do
                {
                    changed = false;
                    for (int j = 0; j < orderedRow.Count - 1; j++)
                    {
                        int a = orderedRow[j];
                        int b = orderedRow[j + 1];

                        // Check if b must come before a (dict1)
                        if (dict1.ContainsKey(a) && dict1[a].Contains(b))
                        {
                            orderedRow[j] = b;
                            orderedRow[j + 1] = a;
                            changed = true;
                        }
                    }
                } while (changed);

                sumPart2 += orderedRow[orderedRow.Count / 2];
            }
        }
        Console.WriteLine(sumPart1);
        Console.WriteLine(sumPart2);
    }
}
