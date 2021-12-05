using System;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                          "/files/input.txt");
            var coordinates = input.Select(l => l.Replace(" -> ", ",")).
                Select(a=>a.Split(",")).
                Select(a=>a.Select(int.Parse).ToArray()).ToList();
            var map = new CoordinatesMap();
            // PART A
            /*coordinates.ForEach(coordinates =>
            {
                var line = new Line(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
                line.PutInMapIfStraightLine(map);
            });            
            Console.WriteLine(map.CoordinateMap.Count(a => a.Visited > 1));*/
            
            // PART B
            coordinates.ForEach(coordinates =>
            {
                var line = new Line(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
                line.PutInMapAnyLine(map);
            });            
            Console.WriteLine(map.CoordinateMap.Count(a => a.Visited > 1));

        }
    }
}