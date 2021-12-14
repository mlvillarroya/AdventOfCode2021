using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Day14
{
    static class Foreign
    {
        public static (long result, long time) PartOne()
        {
            var sw = new Stopwatch();
            sw.Start();
            var lines = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                       "/files/input.txt");
            var countChar = new Dictionary<char, long>();
            var (templateString, rules, pairs) = MapInput(lines);
            for (var i = 0; i < 10; i++)
            {
                pairs = MapPairs(pairs, rules);
            }
            sw.Stop();

            return (CalculateScore(pairs, templateString), sw.ElapsedMilliseconds);
        }

        public static (long result, long time) PartTwo()
        {
            var sw = new Stopwatch();
            sw.Start();
            var lines = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                          "/files/input.txt");
            var (templateString, rules, pairs) = MapInput(lines);
            for (var i = 0; i < 40; i++)
            {
                pairs = MapPairs(pairs, rules);
            }
            sw.Stop();

            return (CalculateScore(pairs, templateString), sw.ElapsedMilliseconds);
        }
        private static (string templateString, Dictionary<string, string> rules, Dictionary<string, long> pairs) MapInput(string[] lines)
        {
            var templateString = lines[0];
            var rules = new Dictionary<string, string>();
            foreach (var line in lines[2..])
            {
                var rule = line.Split(" -> ");
                if (!rules.ContainsKey(rule[0]))
                {
                    rules.Add(rule[0], rule[1]);
                }
            }
            var pairs = new Dictionary<string, long>();

            foreach (var pair in templateString.Zip(templateString[1..], (a, b) => $"{a}{b}"))
            {
                if (!pairs.ContainsKey(pair))
                {
                    pairs[pair] = 0;
                }
                pairs[pair]++;
            }
            return (templateString, rules, pairs);
        }
        private static Dictionary<string, long> MapPairs(Dictionary<string, long> pairs, Dictionary<string, string> rules)
        {
            var temp = new Dictionary<string, long>();
            foreach(var pair in pairs)
            {
                var insert = rules[pair.Key];
                var curLeft = pair.Key[0];
                var curRight = pair.Key[1];
                if(!temp.ContainsKey(curLeft +""+ insert))
                {
                    temp[curLeft + "" + insert] = 0;
                }
                if(!temp.ContainsKey(insert + "" + curRight))
                {
                    temp[insert + "" + curRight] = 0;
                }
                temp[curLeft + "" + insert] += pair.Value;
                temp[insert + "" + curRight] += pair.Value;
            }
            return temp;
        }

        private static long CalculateScore(Dictionary<string, long> pairs, string templateString)
        {
            var countChar = new Dictionary<char, long>();
            foreach (var pair in pairs)
            {
                if (!countChar.ContainsKey(pair.Key[0]))
                {
                    countChar[pair.Key[0]] = 0;
                }
                if (!countChar.ContainsKey(pair.Key[1]))
                {
                    countChar[pair.Key[1]] = 0;
                }
                countChar[pair.Key[0]] += pair.Value;
                countChar[pair.Key[1]] += pair.Value;
            }

            foreach (var c in countChar.Keys.ToList())
            {
                if (c == templateString[0] || c == templateString[^1])
                {
                    countChar[c] = (countChar[c] + 1) / 2;
                }
                else
                {
                    countChar[c] = countChar[c] / 2;
                }
            }
            var max = countChar.Max(x => x.Value);
            var min = countChar.Min(x => x.Value);
            return max - min;
        }

    }
}