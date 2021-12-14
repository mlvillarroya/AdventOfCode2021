using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(Foreign.PartTwo().result);
            /*var input = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                       "/files/input.txt").ToDictionary(a=>a.Split(" -> ")[0],a=>a.Split(" -> ")[1]);

            var template = "COPBCNPOBKCCFFBSVHKO";
            var output = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                template = TransformTemplate(template, input);
            }

            var occurrences = template.GroupBy(c => c).OrderBy(c=>c.Count());
            var lessCommon = occurrences.FirstOrDefault().Count();
            var mostCommon = occurrences.LastOrDefault().Count();
            Console.WriteLine(mostCommon-lessCommon);*/

        }

        private static string TransformTemplate(string template, Dictionary<string, string> input)
        {
            var output = string.Empty;
            for (var i = 0; i < template.Length - 1; i++)
            {
                output += template[i] + input[template[i..(i + 2)]];
            }

            output += template[^1];
            return output;
        }
    }
}