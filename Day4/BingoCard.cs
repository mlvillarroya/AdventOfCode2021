using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Day4
{
    partial class Program
    {
        public class BingoCard
        {
            private BingoCardValue[][] Numbers { get; set; }
            public BingoCard(string[] stringCard)
            {
                Numbers = new BingoCardValue[5][];
                for (var i = 0; i < 5; i++)
                {
                    var rowCell = Regex.Split(stringCard[i], @"\s+").Where(e => e != string.Empty).ToArray();
                    var row = new BingoCardValue[5];
                    for (var j = 0; j < 5; j++)
                    {
                        row[j] = new BingoCardValue(int.Parse(rowCell[j]));
                    }

                    Numbers[i] = row;
                }
            }
            
            private BingoCardValue[] GetColumn(int columnNumber)
            {
                return Enumerable.Range(0, Numbers.GetLength(0))
                    .Select(x => Numbers[x][columnNumber])
                    .ToArray();
            }

            private BingoCardValue[] GetRow(int rowNumber)
            {
                return Numbers[rowNumber];
            }

            public bool AllChecked(int? row = null, int? column = null)
            {
                if (row == null) return column != null && GetColumn((int)column).All(value => value.Checked);
                else return column == null && GetRow((int)row).All(value => value.Checked);
            }

            public bool SetValueCheckedIfExists(int value)
            {
                foreach (var row in Numbers)
                {
                    foreach (var element in row)
                    {
                        if (element.Value == value)
                        {
                            element.Checked = true;
                            return true;
                        }
                    }
                }
                return false;
            }
            
        }
    }
}