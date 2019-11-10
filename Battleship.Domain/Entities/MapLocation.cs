using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Entities
{
    public class MapLocation
    {
        public char Letter { get; set; }
        public int Number { get; set; }

        

        public MapLocation(char letter, int number)
        {
            this.Letter = letter.ToString().ToUpperInvariant()[0];
            this.Number = number;
        }
        public new string ToString()
        {
            return Letter.ToString() + Number;
        }
    }
}
