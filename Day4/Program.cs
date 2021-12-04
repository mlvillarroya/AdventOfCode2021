using System;
using System.Collections.Generic;
using System.IO;

namespace Day4
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                          "/files/input.txt");
            var numbersSung = input[0].Split(",");
            var bingoCardListString= input[2..];
            var bingoCardList = CreateBingoCardList(bingoCardListString);
        }

        private static List<BingoCard> CreateBingoCardList(string[] input)
        {
            var bingoCardList = new List<BingoCard>();
            for (var i = 0; i < input.Length; i += 6)
            {
                bingoCardList.Add(new BingoCard(input[i..(i + 5)]));
            }

            return bingoCardList;
        }
    }
}