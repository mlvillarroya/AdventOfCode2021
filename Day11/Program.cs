using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                       "/files/input.txt").Select(a=>a.Select(c=>int.Parse(c.ToString())).ToArray()).ToArray();
            // PART A
            /*var totalFlashes = 0;
            for (int i = 0; i < 100; i++)
            {
                var haveExploded = new HashSet<(int, int)>();
                totalFlashes += RoundFlashes(input,haveExploded);
            }
            Console.WriteLine(totalFlashes);*/
            
            // PART B
            var round= 1;
            while (true)
            {
                var haveExploded = new HashSet<(int, int)>();
                RoundFlashes(input,haveExploded);
                if (input.Sum(a => a.Sum(a => a)) == 0) break;
                round++;
            }
            Console.WriteLine(round);
        }

        private static int RoundFlashes(int[][] input,HashSet<(int,int)> haveExploded)
        {
            var totalFlashes = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    totalFlashes += IncreaseEnergy(input, i, j,haveExploded);
                }
            }

            return totalFlashes;
        }

        private static int IncreaseEnergy(int[][] matrix, int row, int column,HashSet<(int,int)> haveExploded)
        {
            if (row < 0 || column < 0 || row >= matrix.Length || column >= matrix[0].Length || haveExploded.Contains((row,column))) return 0;
            if (matrix[row][column] != 9)
            {
                matrix[row][column]++;
                return 0;
            }
            matrix[row][column] = 0;
            haveExploded.Add((row, column));
            return 1 + IncreaseEnergy(matrix, row - 1, column - 1,haveExploded) +
                   IncreaseEnergy(matrix, row, column - 1,haveExploded) +
                   IncreaseEnergy(matrix, row + 1, column - 1,haveExploded) +
                   IncreaseEnergy(matrix, row - 1, column,haveExploded) +
                   IncreaseEnergy(matrix, row + 1, column,haveExploded) +
                   IncreaseEnergy(matrix, row - 1, column + 1,haveExploded) +
                   IncreaseEnergy(matrix, row, column + 1,haveExploded) +
                   IncreaseEnergy(matrix, row + 1, column + 1,haveExploded);
        }
    }
}