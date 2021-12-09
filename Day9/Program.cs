using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                       "/files/input.txt").ToArray();
            // PART A
            /*var total = 0;
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                {
                    if (IsMinimum(input,i,j,out var height)) total += height;
                }
            }
            Console.WriteLine(total);*/
            
            // PART B
            var checkedCoordinates = new HashSet<(int,int)>();
            var basinSizeList = new List<int>();
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                {
                    if (IsMinimum(input,i,j,out var height)) basinSizeList.Add(GetBasinSize(input,i,j,checkedCoordinates));
                }
            }

            Console.WriteLine(basinSizeList.OrderByDescending(a=>a).Take(3).Aggregate((product,element)=>product*element));
        }

        public static bool IsMinimum(string[] input, int row, int column, out int height)
        {
            var lessThanLeft = (column <= 0 || input[row][column] < input[row][column - 1]);
            var lessThanUp = (row <= 0 || input[row][column] < input[row - 1][column]);
            var lessThanRight = (column >= input[0].Length-1 || input[row][column] < input[row][column + 1]);
            var lessThanDown = (row >= input.Length-1 || input[row][column] < input[row + 1][column]);
            height = int.Parse(input[row][column].ToString()) + 1;
            return lessThanLeft && lessThanUp && lessThanRight && lessThanDown;
        }

        public static int GetBasinSize(string[] input, int row, int column,HashSet<(int,int)> checkedCoordinates)
        {
            if (row < 0 || row >= input.Length || column < 0 || column >= input[0].Length || input[row][column]=='9' || checkedCoordinates.Contains((row,column))) return 0;
            checkedCoordinates.Add((row, column)); 
            return (1 + GetBasinSize(input, row - 1, column,checkedCoordinates) +
                            GetBasinSize(input, row + 1, column,checkedCoordinates) +
                            GetBasinSize(input, row, column + 1,checkedCoordinates) +
                            GetBasinSize(input, row, column - 1,checkedCoordinates));
            
        }
    }
}