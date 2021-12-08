using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day8
{
    partial class Program
    {
        public class SevenSegmentsSchema
        {
            public char Up { get; set; }
            public char UpperLeft { get; set; }
            public char UpperRight { get; set; }
            public char Center { get; set; }
            public char BottomLeft { get; set; }
            public char BottomRight { get; set; }
            public char Bottom { get; set; }

            public SevenSegmentsSchema(char up, char upperLeft, char upperRight, char center, char bottomLeft, char bottomRight, char bottom)
            {
                Up = up;
                UpperLeft = upperLeft;
                UpperRight = upperRight;
                Center = center;
                BottomLeft = bottomLeft;
                BottomRight = bottomRight;
                Bottom = bottom;
            }

            public int GetNumber(string input)
            {
                var matches = new int[7]{0,0,0,0,0,0,0};
                if (input.Contains(Up)) matches[0] = 1;
                if (input.Contains(UpperLeft)) matches[1] = 1;
                if (input.Contains(UpperRight)) matches[2] = 1;
                if (input.Contains(Center)) matches[3] = 1;
                if (input.Contains(BottomLeft)) matches[4] = 1;
                if (input.Contains(BottomRight)) matches[5] = 1;
                if (input.Contains(Bottom)) matches[6] = 1;
                if (Regex.IsMatch(input, @"[^abcdefg]")) throw new Exception("Invalid character in input");

                var matchesString = string.Join("", matches);
                return matchesString switch
                {
                    "1110111" => 0,
                    "0010010" => 1,
                    "1011101" => 2,
                    "1011011" => 3,
                    "0111010" => 4,
                    "1101011" => 5,
                    "1101111" => 6,
                    "1010010" => 7,
                    "1111111" => 8,
                    "1111011" => 9,
                    _ => throw new Exception("Unable to decode the number")
                };
            }
        }
    }
}