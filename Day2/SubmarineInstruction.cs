namespace Day2
{
    public class SubmarineInstruction
    {
        public SubmarineInstructionDirection Direction { get; set; }
        public int Amount { get; set; }

        public SubmarineInstruction(string instruction)
        {
            var instructions = instruction.Split(" ");
            Direction = instructions[0] switch
            {
                "forward" => SubmarineInstructionDirection.FORWARD,
                "up" => SubmarineInstructionDirection.UP,
                "down" => SubmarineInstructionDirection.DOWN,
                _ => Direction
            };
            Amount = int.Parse(instructions[1]);
        }
    }

    public enum SubmarineInstructionDirection
    {
        FORWARD,
        UP,
        DOWN
    }
}