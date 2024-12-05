using System;
using System.IO;
using System.Linq;
using System.Text;

public class Day4
{
    public static void Part1()
    {
        var lines = File.ReadAllLines("4_input.txt");
        var grid = lines.Select(line => line.ToCharArray()).ToArray();

        int rows = grid.Length;
        int cols = grid[0].Length;

        var word = "XMAS";
        int wordLength = word.Length;

        int count = 0;

        // Directions: N, NE, E, SE, S, SW, W, NW
        int[] dx = { -1, -1, 0, 1, 1, 1, 0, -1 };
        int[] dy = { 0, 1, 1, 1, 0, -1, -1, -1 };

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                for (int dir = 0; dir < 8; dir++)
                {
                    int k, rd = i, cd = j;

                    for (k = 0; k < wordLength; k++)
                    {
                        if (rd < 0 || rd >= rows || cd < 0 || cd >= cols)
                            break;

                        if (grid[rd][cd] != word[k])
                            break;

                        rd += dx[dir];
                        cd += dy[dir];
                    }

                    if (k == wordLength)
                        count++;
                }
            }
        }

        Console.WriteLine(count);
    }


    public static void Part2()
    {
        var lines = File.ReadAllLines("4_input.txt");
        var grid = lines.Select(line => line.ToCharArray()).ToArray();

        int rows = grid.Length;
        int cols = grid[0].Length;

        int count = 0;

        for (int i = 1; i < rows - 1; i++)
        {
            for (int j = 1; j < cols - 1; j++)
            {
                if (grid[i][j] != 'A')
                    continue;

                // Get the letters on both diagonals
                string diag1 = $"{grid[i - 1][j - 1]}{grid[i][j]}{grid[i + 1][j + 1]}";
                string diag2 = $"{grid[i - 1][j + 1]}{grid[i][j]}{grid[i + 1][j - 1]}";

                bool diag1Valid = diag1 == "MAS" || diag1 == "SAM";
                bool diag2Valid = diag2 == "MAS" || diag2 == "SAM";

                if (diag1Valid && diag2Valid)
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }

}
