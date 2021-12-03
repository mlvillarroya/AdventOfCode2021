using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                          "/files/input.txt");
            var result = new List<char>();
            for (var i = 0; i < input[0].Length; i++)
            {
                result.Add(FindMoreRepeatedNumber(input, i));
            }

            var gamma = Convert.ToInt32(new string(result.ToArray()), 2);
            var epsilon = Convert.ToInt32(new string(NegateBits(result).ToArray()), 2);
            Console.WriteLine(gamma*epsilon);
        }

        private static List<char> NegateBits(List<char> input)
        {
            var result = new List<char>();
            foreach (var character in input)
            {
                if (character == '0') result.Add('1');
                else result.Add('0');
            }
            return result;
        }


        private static char FindMoreRepeatedNumber(IEnumerable<string> input, int i)
        {
            return input.GroupBy(a => a[i]).OrderByDescending(a=>a.Count()).Select(a=>a.Key).FirstOrDefault();        
        }
    }
}