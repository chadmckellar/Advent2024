using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

public class Day6
{
    public static void Solution()
    {
        var lines = File.ReadAllLines("6_input.txt");
        var grid = lines.Select(line => line.ToCharArray()).ToArray();

        // directions N, E, S, W
        int[] dx = { -1, 0, 1, 0 };
        int[] dy = {  0, 1, 0, -1 };

        int dir = 0;

        // find ^ in grid
        int x = 0, y = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '^')
                {
                    x = i;
                    y = j;
                    break;
                }
            }
        }

        HashSet<(int, int)> visited = [(x, y)];

        bool reachedEnd = false;
        do {
            int rd = x + dx[dir];
            int cd = y + dy[dir];
            if (rd < 0 || rd >= grid.Length || cd < 0 || cd >= grid[0].Length)
            {
                reachedEnd = true;
            }
            else if (grid[rd][cd] == '#')
            {
                turnRight(ref dir);
                rd = x + dx[dir];
                cd = y + dy[dir];
            }
            visited.Add((x, y));
            x = rd;
            y = cd;
        } while (reachedEnd is false);

        Console.WriteLine(visited.Count);
    }

    private static void turnRight(ref int dir)
    {
        dir = (dir + 1) % 4;
    }
}
