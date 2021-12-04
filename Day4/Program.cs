using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                          "/files/input.txt");
            var numbersSung = input[0].Split(",");
            input = input[2..];
            var bingoCardList = new List<BingoCard>();
            for (var i = 0; i < input.Length-6; i++)
            {
                bingoCardList.Add(new BingoCard(input[i..(i+5)]));
            }
        }

        public class BingoCard
        {
            private int[,] numbers { get; set; }
            public BingoCard(string[] stringCard)
            {
                numbers = new int[5,5];
                for (var i = 0; i < 5; i++)
                {
                    var rowCell = Regex.Split(stringCard[i], @"\s+");
                    rowCell = rowCell.Where(e => e != string.Empty).ToArray();
                    for (var j = 0; j < 5; j++)
                    {
                        numbers[i, j] = int.Parse(rowCell[j]);
                    }
                }
            }
        }
    }
}