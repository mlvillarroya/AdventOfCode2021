using System;
using System.Threading;

namespace Day2
{
    class Submarine
    {
        private int HorizontalPosition { get; set; }
        private int Depth { get; set; }
        public int Aim { get; set; }

        private (int horizontalPosition, int depth) GetCoordinates()
        {
            return (this.HorizontalPosition, this.Depth);
        }

        public int GetCoordinatesProduct()
        {
            (var h, var d) = GetCoordinates();
            return h * d;
        }

        public Submarine()
        {
            this.HorizontalPosition = 0;
            this.Depth = 0;
            this.Aim = 0;
        }

        public void Reset()
        {
            this.HorizontalPosition = 0;
            this.Depth = 0;
            this.Aim = 0;
        }
        public void ReadInstructionPartB(SubmarineInstruction instruction)
        {
            switch (instruction.Direction)
            {
                case SubmarineInstructionDirection.UP:
                {
                    Aim -= instruction.Amount;
                    break;
                }
                case SubmarineInstructionDirection.DOWN:
                {
                    Aim += instruction.Amount;
                    break;
                }
                case SubmarineInstructionDirection.FORWARD:
                {
                    HorizontalPosition += instruction.Amount;
                    Depth += Aim * instruction.Amount;
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ReadInstruction(SubmarineInstruction instruction)
        {
            switch (instruction.Direction)
            {
                case SubmarineInstructionDirection.UP:
                {
                    Depth -= instruction.Amount;
                    break;
                }
                case SubmarineInstructionDirection.DOWN:
                {
                    Depth += instruction.Amount;
                    break;
                }
                case SubmarineInstructionDirection.FORWARD:
                {
                    HorizontalPosition += instruction.Amount;
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}