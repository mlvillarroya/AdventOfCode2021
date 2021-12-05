using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Day5
{
    public class CoordinatesMap
    {
        public List<Coordinate> CoordinateMap { get; set; }

        public CoordinatesMap()
        {
            CoordinateMap = new List<Coordinate>();
        }

        public void Visit(int x, int y)
        {
            var coordinate = CoordinateMap.FirstOrDefault(c => (c.X == x && c.Y == y));
            if (coordinate == null) CoordinateMap.Add(new Coordinate(x, y)); 
            else coordinate.Visited+=1;
        }
    }
}