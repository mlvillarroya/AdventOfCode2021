using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalPoints = 0;
            var input = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                       "/files/input.txt").ToArray();
            // PART A
            /*
            foreach (var line in input)
            {
                if (!IsLegalChunk(line, out var points)) totalPoints += points;
            }
            Console.WriteLine(totalPoints);
            */
            
            // PART B
            var scoresList = new List<ulong>();
            foreach (var line in input)
            {
                if (IsLegalChunk(line, out var points)) scoresList.Add(CalculatePoints((CalculateMissingChain(line))));
            }

            Console.WriteLine(scoresList.OrderBy(a=>a).ToArray()[scoresList.Count/2]);
        }

        private static ulong CalculatePoints(string calculateMissingChain)
        {
            var total = calculateMissingChain.Aggregate((ulong)0, (current, character) => current * 5 + (ulong)LegalChunkPoints(character));
            return total;
        }

        private static string CalculateMissingChain(string input)
        {
            var stack = new Stack<char>();
            foreach (var c in input)
            {
                if (c is '(' or '[' or '{' or '<') stack.Push(c);
                else
                {
                    var last = stack.Pop();
                }
            }

            return ComputeMissingChunks(stack);
        }

        private static string ComputeMissingChunks(Stack<char> stack)
        {
            return stack.Select(chunk => chunk switch
                {
                    '{' => '}',
                    '[' => ']',
                    '<' => '>',
                    '(' => ')',
                    _ => '0'
                })
                .Aggregate(string.Empty, (current, inverseChunk) => current + inverseChunk);
        }

        public static bool IsLegalChunk(string input, out int points)
        {
            var stack = new Stack<char>();
            foreach (var c in input)
            {
                if (c is '(' or '[' or '{' or '<') stack.Push(c);
                else
                {
                    var last = stack.Pop();
                    if ((last == '(' && c == ')') || (last == '<' && c == '>') || (last == '{' && c == '}') ||
                        (last == '[' && c == ']')) continue;
                    points = IllegalChunkPoints(c);
                    return false;
                }
            }
            points = 0;
            return true;
        }

        private static int IllegalChunkPoints(char input)
        {
            return input switch
            {
                ')' => 3,
                ']' => 57,
                '}' => 1197,
                '>' => 25137,
                _ => 0
            };
        }
        private static int LegalChunkPoints(char input)
        {
            return input switch
            {
                ')' => 1,
                ']' => 2,
                '}' => 3,
                '>' => 4,
                _ => 0
            };
        }

    }
}