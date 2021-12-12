using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                       "/files/input.txt");
            var day12 = new Day_12();
            day12.PartTwo(input);
        }

        private static HashSet<string> ComputePossiblePaths(IEnumerable<Cave> caveList, HashSet<string> possiblePaths, string path, string caveName)
        {
            var currentCave = caveList.FirstOrDefault(c => c.Name == caveName) ??
                              throw new Exception($"Cave {caveName} not found");
            if (caveName == "end")
            {
                path+=caveName;
                possiblePaths.Add(path);
                return possiblePaths;
            }

            else if (path.Contains(caveName) && !currentCave.IsBig) return possiblePaths;
            else
            {
                path+=caveName;
                foreach (var cave in currentCave.GetCaves())
                {
                    possiblePaths.UnionWith(ComputePossiblePaths(caveList,possiblePaths,path,cave));
                }

                return possiblePaths;
            }
        }
        
        private static HashSet<string> ComputePossiblePathsPartB(IEnumerable<Cave> caveList, HashSet<string> possiblePaths, string path, string caveName)
        {
            var currentCave = caveList.FirstOrDefault(c => c.Name == caveName) ??
                              throw new Exception($"Cave {caveName} not found");
            if (caveName == "end")
            {
                path+=(caveName+';');
                possiblePaths.Add(path);
                return possiblePaths;
            }

            else if (path.Contains(caveName) && !currentCave.IsBig && smallVisitedTwiceAlreadyOrStartOrEnd(path,caveName)) return possiblePaths;
            else
            {
                path+=(caveName+';');
                foreach (var cave in currentCave.GetCaves())
                {
                    possiblePaths.UnionWith(ComputePossiblePathsPartB(caveList,possiblePaths,path,cave));
                }

                return possiblePaths;
            }
        }

        private static bool smallVisitedTwiceAlreadyOrStartOrEnd(string path,string caveName)
        {
            path += caveName;
            var repeatingSmallString = path.Split(";").Where(a => (Regex.IsMatch(a, @"[a-z]+") && a != "start" && a!= "end")).GroupBy(a => a)
                .Where(a => a.Count()>1);
            return caveName is "start" or "end" || repeatingSmallString.Count() > 1 || repeatingSmallString.FirstOrDefault().Count()>2;
        }

        private static IEnumerable<Cave> CreateCaveList(IEnumerable<string[]> input)
        {
            var caveList = new HashSet<Cave>();
            foreach (var line in input)
            {
                var cave1 = caveList.FirstOrDefault(c => c.Name == line[0]) ?? new Cave(line[0]);
                var cave2 = caveList.FirstOrDefault(c => c.Name == line[1]) ?? new Cave(line[1]);
                cave1.SetNextCave(line[1]);
                cave2.SetNextCave(line[0]);
                caveList.Add(cave1);
                caveList.Add(cave2);
            }

            return caveList;
        }
    }
}