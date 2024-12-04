using System;
using System.IO;
using System.Linq;
using System.Text;

public class Day3
{
    public static void Part1()
    {
        var validNumbers = new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
        var x = new StringBuilder();
        var y = new StringBuilder();

        var validNextValue = new[] {"m", "u", "l", "(", "anyNumberX", ",", "anyNumberY", ")"};

        var lines = File.ReadAllLines("3_input.txt");
        var sum = 0;
        foreach (var line in lines)
        {
            var validNextValueIndex = 0;
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                var doingX = validNextValue[validNextValueIndex] == "anyNumberX";
                var doingY = validNextValue[validNextValueIndex] == "anyNumberY";
                if (doingX || doingY)
                {
                    if (validNumbers.Contains(c.ToString()))
                    {
                        if (doingX)
                            x.Append(c);
                        else
                            y.Append(c);
                        while (i + 1 < line.Length && validNumbers.Contains(line[i + 1].ToString()))
                        {
                            i++;
                            if (doingX)
                                x.Append(line[i]);
                            else
                                y.Append(line[i]);
                        }
                    }
                    validNextValueIndex++;
                }
                else if (validNextValue[validNextValueIndex] == c.ToString())
                {
                    if (c == ')')
                    {
                        sum += int.Parse(x.ToString()) * int.Parse(y.ToString());
                        validNextValueIndex = 0;
                        x.Clear();
                        y.Clear();
                    }
                    else
                        validNextValueIndex++;
                }
                else
                {
                    validNextValueIndex = 0;
                    x.Clear();
                    y.Clear();
                }
            }
        }
        Console.WriteLine(sum);
    }

    public static void Part2()
    {

    }
}