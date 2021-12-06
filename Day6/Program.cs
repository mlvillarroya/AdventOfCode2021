using System;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                          "/files/input.txt").Split(",").Select(a=>int.Parse(a)).ToList();
            var afterDays = 256;
            const int maxAge = 8;
            var lanternFishAgeDistribution = new long[maxAge + 1];
            input.ForEach(age =>
            {
                lanternFishAgeDistribution[age]++;
            });
            for (int i = 0; i < afterDays; i++)
            {
                var newBorns = lanternFishAgeDistribution[0];
                lanternFishAgeDistribution[0] = lanternFishAgeDistribution[1];
                lanternFishAgeDistribution[1] = lanternFishAgeDistribution[2];
                lanternFishAgeDistribution[2] = lanternFishAgeDistribution[3];
                lanternFishAgeDistribution[3] = lanternFishAgeDistribution[4];
                lanternFishAgeDistribution[4] = lanternFishAgeDistribution[5];
                lanternFishAgeDistribution[5] = lanternFishAgeDistribution[6];
                lanternFishAgeDistribution[6] = lanternFishAgeDistribution[7] + newBorns;
                lanternFishAgeDistribution[7] = lanternFishAgeDistribution[8];
                lanternFishAgeDistribution[8] = newBorns;
            }

            Console.WriteLine(lanternFishAgeDistribution.Sum(a=>a));
        }
        
    }
}