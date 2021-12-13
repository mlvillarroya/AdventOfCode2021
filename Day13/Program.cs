using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                       "/files/input.txt").Select(a=>(int.Parse(a.Split(",")[0]),int.Parse(a.Split(",")[1]))).ToArray();
            var points = new Paper(input.Max(a=>a.Item2)+1,input.Max(a=>a.Item1)+1);
            foreach (var valueTuple in input)
            {
                points.WriteDot(valueTuple.Item1,valueTuple.Item2);
            }
            points.FoldVertical();
            points.FoldHorizontal();
            points.FoldVertical();
            points.FoldHorizontal();
            points.FoldVertical();
            points.FoldHorizontal();
            points.FoldVertical();
            points.FoldHorizontal();
            points.FoldVertical();
            points.FoldHorizontal();
            points.FoldHorizontal();
            points.FoldHorizontal();
            for (var i = 0; i < points.Rows; i++)
            {
                for (var j = 0; j < points.Columns; j++)
                {
                    Console.Write(points.WriteValue(i,j));
                }
                Console.Write("\n");
            }
        }
    }

    class Paper
    {
        public bool[,] Points { get; set; }
        public int Rows => Points.GetLength(0);
        public int Columns => Points.GetLength(1);
        
        public int HowManyVisible  {
            get
            {
                var count = 0;
                for (var i = 0; i < Points.GetLength(0); i++)
                {
                    for (var j = 0; j < Points.GetLength(1); j++)
                    {
                        count = Points[i, j]  ? count+1 : count;
                    }
                }
                return count;
            }
        }

        public Paper(int rows,int columns)
        {
            Points = new bool[rows,columns];
        }

        public void WriteDot(int first, int second)
        {
            Points[second, first] = true;
        }

        public void FoldHorizontal()
        {
            var newPaper = new bool[(Rows - 1) / 2, Columns];
            for (var i = 0; i < (Rows-1)/2; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    newPaper[i, j] = Points[i, j] || Points[Rows-i-1,j];
                }
            }
            Points = newPaper;
        }
        public void FoldVertical()
        {
            var newPaper = new bool[Rows, (Columns-1)/2];
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < (Columns-1)/2; j++)
                {
                    newPaper[i, j] = Points[i, j] || Points[i,Columns-j-1];
                }
            }
            Points = newPaper;
        }

        public string WriteValue(int i, int j)
        {
            return Points[i, j] ? "#" : ".";
        }
    }
}