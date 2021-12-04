namespace Day4
{
    public class BingoCardValue
    {
        public int Value { get; set; }
        public bool Checked { get; set; }

        public BingoCardValue(int value)
        {
            Value = value;
            Checked = false;
        }
    }
}