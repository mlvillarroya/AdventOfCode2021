using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    public class Line
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        private int Slope => (Y2 - Y1) / (X2 - X1);

        private bool PositiveSlope => Slope > 0;
        
        private bool IsStraight => (X1 == X2) || (Y1 == Y2);

        private int SmallestX => X1 < X2 ? X1 : X2;
        private int BiggestX => X1 < X2 ? X2 : X1;

        private int SmallestY => Y1 < Y2 ? Y1 : Y2;
        private int BiggestY => Y1 < Y2 ? Y2 : Y1;

        public Line(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        

        public bool PutInMapIfStraightLine(CoordinatesMap map)
        {
            if (!IsStraight)
            {
                return false;
            }
            if (X1 == X2)
            {
                for (var i = SmallestY; i <= BiggestY; i++)
                {
                    map.Visit(X1,i);
                }
            }
            else
            {
                for (var i = SmallestX; i <= BiggestX; i++)
                {
                    map.Visit(i,Y1);
                }
            }
            return true;
        }
        public bool PutInMapAnyLine(CoordinatesMap map)
        {
            if (!IsStraight)
            {
                if (PositiveSlope)
                {
                    for (var i = 0; i <= BiggestY-SmallestY; i++)
                    {
                        map.Visit(SmallestX+i,SmallestY+i);
                    }
                }
                else
                {
                    for (var i = 0; i <= BiggestY-SmallestY; i++)
                    {
                        map.Visit(SmallestX+i,BiggestY-i);
                    }
                }
            }
            else if (X1 == X2)
            {
                for (var i = SmallestY; i <= BiggestY; i++)
                {
                    map.Visit(X1,i);
                }
            }
            else
            {
                for (var i = SmallestX; i <= BiggestX; i++)
                {
                    map.Visit(i,Y1);
                }
            }
            return true;
        }
  
    }
}