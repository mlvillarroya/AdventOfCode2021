using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent +
                                          "/files/input.txt");
            var submarine = new Submarine();
            foreach (var instruction in input)
            {
                var submarineInstruction = new SubmarineInstruction(instruction);
                submarine.ReadInstruction(submarineInstruction);
            }
            Console.WriteLine(submarine.GetCoordinatesProduct());
            submarine.Reset();
            foreach (var instruction in input)
            {
                var submarineInstruction = new SubmarineInstruction(instruction);
                submarine.ReadInstructionPartB(submarineInstruction);
            }

            Console.WriteLine(submarine.GetCoordinatesProduct());
        }
    }
}