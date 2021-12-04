using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                          "/files/input.txt");
            var numbersSung = input[0].Split(",").Select(int.Parse).ToList();
            var bingoCardListString = input[2..];
            var bingoCardList = CreateBingoCardList(bingoCardListString);
            // Part A
            //Console.WriteLine(PlayBingoPartA(numbersSung, bingoCardList));
            // Part B
            Console.WriteLine(SearchForTheLastToWin(numbersSung, bingoCardList));
        }

        private static int SearchForTheLastToWin(List<int> numbersSung, List<BingoCard> bingoCardList)
        {
            var remainingNumbers = numbersSung.Select(a=>a).ToList();
            foreach (var bingoValue in numbersSung)
            {
                foreach (var bingoCard in bingoCardList)
                {
                    bingoCard.SetValueCheckedIfExists(bingoValue);
                    if (bingoCard.CheckEveryRowAndColumn())
                    {
                        return bingoCardList.Count == 1 ? bingoCardList.FirstOrDefault().GetSumUncheckedValues()*bingoValue : SearchForTheLastToWin(remainingNumbers, bingoCardList.Where(card=>card!=bingoCard).ToList());
                    }
                }
                remainingNumbers.Remove(bingoValue);
            }
            return 0;
        }
        private static int PlayBingoPartA(IEnumerable<int> numbersSung, List<BingoCard> bingoCardList)
        {
            foreach (var bingoValue in numbersSung)
            {
                foreach (var bingoCard in bingoCardList)
                {
                    bingoCard.SetValueCheckedIfExists(bingoValue);
                    if (bingoCard.CheckEveryRowAndColumn())
                    {
                        return bingoCard.GetSumUncheckedValues() * bingoValue;
                    }
                }
            }
            return 0;
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