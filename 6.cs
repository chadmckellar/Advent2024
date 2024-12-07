using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
        HashSet<(int, int)> loopObstructions = new HashSet<(int, int)>();

        int totalSteps = RunTraversal(grid, x, y, visited, loopObstructions);
        Console.WriteLine($"Part1: {visited.Count}");

        foreach (var visit in visited.Skip(1))
        {
            RunTraversal(grid, x, y, new HashSet<(int, int)>(), loopObstructions, addedObstruction: visit);
        }
        Console.WriteLine($"Part2: {loopObstructions.Count}");
    }

    private static void turnRight(ref int dir)
    {
        dir = (dir + 1) % 4;
    }

    private static int RunTraversal(char[][] grid, int x, int y, HashSet<(int, int)> visited,  HashSet<(int, int)> loopObstructions, (int, int)? addedObstruction = null)
    {
        var localGrid = grid.Select(row => row.ToArray()).ToArray();
        if (addedObstruction != null)
        {
            localGrid[addedObstruction.Value.Item1][addedObstruction.Value.Item2] = '#';
        }
        // directions N, E, S, W
        int[] dx = { -1, 0, 1, 0 };
        int[] dy = {  0, 1, 0, -1 };

        int dir = 0;

        int step = 0;
        HashSet<(int, int, int)> loopCheck = new HashSet<(int, int, int)>(); // (x, y, dir)

        bool reachedEnd = false;
        while (reachedEnd is false)
        {
            // check if loop
            if (loopCheck.Contains((x, y, dir)))
            {
                Debug.Assert(addedObstruction != null);
                loopObstructions.Add(addedObstruction.Value);
                reachedEnd = true;
            }
            loopCheck.Add((x, y, dir));

            // grab intended next position
            int rd = x + dx[dir];
            int cd = y + dy[dir];

            if (rd < 0 || rd >= localGrid.Length || cd < 0 || cd >= localGrid[0].Length)
            {
                reachedEnd = true;
            }
            else if (localGrid[rd][cd] == '#')
            {
                while (localGrid[rd][cd] == '#') // turn right until no obstruction
                {
                    turnRight(ref dir);
                    rd = x + dx[dir];
                    cd = y + dy[dir];
                }
            }

            visited.Add((x, y));
            // move in the direction the guard is facing
            x = x + dx[dir];
            y = y + dy[dir];
            step++;
        }

        return step;
    }
}
