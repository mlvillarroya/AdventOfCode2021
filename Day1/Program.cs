using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                          "/files/input.txt");

            // PART A
            Console.WriteLine(CalculateSingleIncrements(input));
            // PART B
            input = GroupInputThreeItems(input);
            Console.WriteLine(CalculateSingleIncrements(input));
        }

        private static string[] GroupInputThreeItems(string[] input)
        {
            var output = new List<string>();
            for (int i = 0; i < input.Length-2; i++)
            {
                output.Add((int.Parse(input[i])+int.Parse(input[i+1])+int.Parse(input[i+2])).ToString());
            }
            return output.ToArray();
        }

        private static int CalculateSingleIncrements(string[] input)
        {
            var increments = 0;
            var previousNumber = int.Parse(input[0]);
            foreach (var line in input)
            {
                if (int.Parse(line) > previousNumber) increments++;
                previousNumber = int.Parse(line);
            }
            return increments;
        }
    }
}