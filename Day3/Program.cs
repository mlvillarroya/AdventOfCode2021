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
            // Part A
            var result = ComputeMostRepeatedDigits(input);
            Console.WriteLine(GammaEpsilon(result));
            
            // Part B
            Console.WriteLine(PartBCalculateOxygenAndScrubberProduct(input));
        }

        private static int PartBCalculateOxygenAndScrubberProduct(string[] input)
        {
            var partBMostRepeated = ComputeMostCommonMember(input, 0);
            var partBLessRepeated = ComputeLessCommonMember(input, 0);
            var oxygen = Convert.ToInt32(new string(partBMostRepeated.ToArray()), 2);
            var scrubber = Convert.ToInt32(new string(partBLessRepeated.ToArray()), 2);
            return oxygen * scrubber;
        }

        private static string ComputeMostCommonMember(string[] input, int i)
        {
            if (input.Length == 1) return input.FirstOrDefault();
            if (i >= input[0].Length) throw new Exception();
            
            input = input.Where(m => m[i] == FindMoreRepeatedNumber(input, i)).ToArray();
            return ComputeMostCommonMember(input, i + 1);
        }
        private static string ComputeLessCommonMember(string[] input, int i)
        {
            if (input.Length == 1) return input.FirstOrDefault();
            if (i >= input[0].Length) throw new Exception();
            
            input = input.Where(m => m[i] == FindLessRepeatedNumber(input, i)).ToArray();
            return ComputeLessCommonMember(input, i + 1);
        }

        private static int GammaEpsilon(List<char> result)
        {
            var gamma = Convert.ToInt32(new string(result.ToArray()), 2);
            var epsilon = Convert.ToInt32(new string(NegateBits(result).ToArray()), 2);
            var gammaEpsilon = gamma * epsilon;
            return gammaEpsilon;
        }

        private static List<char> ComputeMostRepeatedDigits(string[] input)
        {
            var result = new List<char>();
            for (var i = 0; i < input[0].Length; i++)
            {
                result.Add(FindMoreRepeatedNumber(input, i));
            }

            return result;
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
            var listOfOccurrences = input.GroupBy(a => a[i]).OrderByDescending(a=>a.Count()).ToList().Select(a=>(a.Key,a.Count())).ToList();
            return listOfOccurrences[0].Item2 == listOfOccurrences[1].Item2 ? '1' : listOfOccurrences[0].Key;
        }
        private static char FindLessRepeatedNumber(IEnumerable<string> input, int i)
        {
            var listOfOccurrences = input.GroupBy(a => a[i]).OrderBy(a=>a.Count()).ToList().Select(a=>(a.Key,a.Count())).ToList();
            return listOfOccurrences[0].Item2 == listOfOccurrences[1].Item2 ? '0' : listOfOccurrences[0].Key;
        }
    }
}