using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

public class Day7
{
    private static List<long> results = new List<long>();
    private static List<List<long>> values = new List<List<long>>();
    private static void setup()
    {
        var lines = File.ReadAllLines("7_input.txt");
        var resultValuesPairs = lines.Select(line => line.Split(":")).ToList();
        var valueStrings = resultValuesPairs.Select(pair => pair[1].Trim().Split(" ")).ToList();
        results = resultValuesPairs.Select(pair => long.Parse(pair[0].Trim())).ToList();
        values = valueStrings.Select(valueString => valueString.Select(v => long.Parse(v)).ToList()).ToList();
    }
    private static List<long> getOpsAt(long i)
    {
        string binary = Convert.ToString(i, 2);
        return binary.ToCharArray().Select(s => long.Parse(s.ToString())).ToList();
    }

    public static void Part1()
    {
        setup();

        long totalCalibrationResults = 0;

        for (int c = 0; c < results.Count; c++)
        {
            for (int i = 0; i < Math.Pow(2, values[c].Count - 1); i++)
            {
                var ops = getOpsAt(i);
                List<long> valuesCopy = new List<long>(values[c]);
                long sum = valuesCopy[0];

                // pad ops with 0s
                while (ops.Count < valuesCopy.Count - 1)
                {
                    ops.Insert(0, 0);
                }

                for (int j = 0; j < ops.Count; j++)
                {
                    if (ops[j] == 0)
                    {
                        sum *= valuesCopy[j + 1];
                    }
                    else
                    {
                        sum += valuesCopy[j + 1];
                    }
                }

                if (sum == results[c])
                {
                    totalCalibrationResults += sum;
                    break;
                }
            }
        }

        Console.WriteLine($"Part1: {totalCalibrationResults}");
    }
}
