using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace Day12
{
    public class Cave
    {
        public string Name { get; }
        private List<string> NextCaves { get; set; }

        public bool IsBig => Regex.IsMatch(Name,@"[A-Z]+");

        public void SetNextCave(string caveName)
        {
            NextCaves.Add(caveName);   
        }

        public List<string> GetCaves()
        {
            return NextCaves;
        }
        
        public Cave(string name)
        {
            Name = name;
            NextCaves = new List<string>();
        }
    }
}