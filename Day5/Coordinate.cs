using System.Xml;

namespace Day5
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Visited { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            Visited = 1;
        }
    }
}