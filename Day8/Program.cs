using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                       "/files/input.txt").Select(a => a.Split(" | ")).ToList();
            // Part A
            Console.WriteLine(input.Sum(a=>HowMany1478InString(a[1])));
            // Part B
            var totalSum = 0;
            foreach (var line in input)
            {
                var schema = GuessSecretCode(line[0].Split(" ").ToList());
                var result = line[1].Split(" ").Aggregate(string.Empty, (current, valueToDecript) => current + (schema.GetNumber(valueToDecript).ToString()));
                totalSum += int.Parse(result);
            }

            Console.WriteLine(totalSum);
        }

        private static SevenSegmentsSchema GuessSecretCode(List<string> input)
        {
            var number7 = input.FirstOrDefault(a => a.Length == 3);
            input.Remove(number7);
            var number1 = input.FirstOrDefault(a => a.Length == 2);
            input.Remove(number1);
            var number8 = input.FirstOrDefault(a => a.Length == 7);
            input.Remove(number8);
            var number4 = input.FirstOrDefault(a => a.Length == 4);
            input.Remove(number4);
            var segmentUP = StringSubtractFirstChar(number7, number1);
            var withoutEntireRightSide_1 = input.Where(a => (!a.Contains(number1[0])));
            var withoutEntireRightSide_2 = input.Where(a => (!a.Contains(number1[1])));
            var number2 = withoutEntireRightSide_1.Count() == 1
                ? withoutEntireRightSide_1.FirstOrDefault()
                : withoutEntireRightSide_2.FirstOrDefault();
            var number6 = (withoutEntireRightSide_1.Count() == 2
                ? withoutEntireRightSide_1
                : withoutEntireRightSide_2).ToArray().OrderByDescending(a => a.Length).FirstOrDefault();
            var number5 = (withoutEntireRightSide_1.Count() == 2
                ? withoutEntireRightSide_1
                : withoutEntireRightSide_2).ToArray().OrderBy(a => a.Length).FirstOrDefault();
            input.Remove(number5);
            input.Remove(number2);
            input.Remove(number6);
            var segmentUPPERRIGHT = number2.Intersect(number1).FirstOrDefault();
            var segmentBOTTOMRIGHT = number5.Intersect(number1).FirstOrDefault();
            var segmentBOTTOMLEFT = StringSubtractFirstChar(number6, number5);
            var number3 = input.FirstOrDefault(a => a.Length == 5);
            input.Remove(number3);
            var number0 = input.FirstOrDefault(a => a.Contains(segmentBOTTOMLEFT));
            input.Remove(number0);
            var number9 = input.FirstOrDefault();
            var segmentUPPERLEFT = StringSubtractFirstChar(number9, number3);
            var segmengMIDDLE = StringSubtractFirstChar(number8, number0);
            var segmentBOTTOM = StringSubtractFirstChar(StringSubtract(number3, number7).ToString(),segmengMIDDLE.ToString());
            return new SevenSegmentsSchema(segmentUP, segmentUPPERLEFT, segmentUPPERRIGHT,
                segmengMIDDLE, segmentBOTTOMLEFT, segmentBOTTOMRIGHT, segmentBOTTOM);
        }

        private static int HowMany1478InString(string input)
        {
            return input.Split(" ").Count(a => a.Length is 2 or 4 or 3 or 7);
        }

        private static char StringSubtractFirstChar(string string1, string string2)
        {
            return string2.Aggregate(string1, (current, character) => current.Remove(current.IndexOf(character), 1)).FirstOrDefault();
        }
        private static string StringSubtract(string string1, string string2)
        {
            return string2.Aggregate(string1, (current, character) => current.Remove(current.IndexOf(character), 1));
        }
        
    }
}