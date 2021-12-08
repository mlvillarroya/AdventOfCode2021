using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                         "/files/input.txt").Split(",").Select(int.Parse).ToList();
            // Part A
            Console.WriteLine(PartACalculateMinDistance(input));
            // Part B
            Console.WriteLine(PartBCalculateMinDistance(input));
  
        }

        private static int PartACalculateMinDistance(IReadOnlyCollection<int> input)
        {
            var maxHorizontalValue = input.Max(a => a);
            var distances = new List<int>();
            for (var i = 0; i < maxHorizontalValue; i++)
            {
                distances.Add(input.Sum(a => Math.Abs(a - i)));
            }

            return distances.Min(a => a);
        }
        private static int PartBCalculateMinDistance(IReadOnlyCollection<int> input)
        {
            var maxHorizontalValue = input.Max(a => a);
            var distances = new List<int>();
            for (var i = 0; i < maxHorizontalValue; i++)
            {
                distances.Add(input.Sum(a => FuelExpent(Math.Abs(a - i))));
            }

            return distances.Min(a => a);
        }

        private static int FuelExpent(int distance)
        {
            var result = 0;
            for (int i = 0; i < distance; i++)
            {
                result += i + 1;
            }

            return result;
        }
    }
}