using System;
using System.Linq;

namespace Battleship.Domain.Entities
{
    public class Ship
    {
        public MapLocation From { get; protected internal set; }
        public MapLocation To { get; protected internal set; }

        public bool[] Hits { get; internal set; } // Array with state of ship cells in order from From to To // true = hit cell // false = has not been hit

        public bool IsSunk
        {
            get
            {
                return this.Hits.All(h => h == true);
            }
        }


        public Ship(MapLocation from, MapLocation to)
        {
            if (from.Letter != to.Letter && from.Number != to.Number)
                throw new Exception("Ship must be aligned either vertically or horizontally");

            if (from.Letter == to.Letter && to.Number < from.Number) // inverted directions of ships are not allowed. Normalize them on service layer
                throw new Exception("Left to right and Top to Bottom please");

            if (to.Number == from.Number && (int)to.Letter < (int)from.Letter)// inverted directions of ships are not allowed. Normalize them on service layer
                throw new Exception("Left to right and Top to Bottom please");

            this.From = from;
            this.To = to;
            int hitsLength = (from.Letter == to.Letter) ? to.Number - from.Number : (int)to.Letter - (int)from.Letter;
            this.Hits = new bool[hitsLength+1];
        }


        public int IsLocationWitin(MapLocation location)
        {
            if (From.Letter == location.Letter && To.Letter == location.Letter) // aligned with letter
            {
                if (From.Number <= location.Number && To.Number >= location.Number)
                    return location.Number - From.Number; // technically its cell number of the ship
            }
            else if (From.Number == location.Number && To.Number == location.Number) // aligned with number
            {
                if (From.Letter <= location.Letter && To.Letter >= location.Letter)
                    return location.Letter - From.Letter;
            }
            return -1;
        }

        public bool IntersectsWith(Ship otherShip)
        {
            if (otherShip.From.Letter == otherShip.To.Letter) // aligned with letter
            {
                for (var i = otherShip.From.Number; i < otherShip.To.Number; i++)
                {
                    int locationWithin = this.IsLocationWitin(new MapLocation(otherShip.From.Letter, i));
                    if (locationWithin >= 0)
                        return true;
                }
            }
            else if (otherShip.From.Number == otherShip.To.Number) // aligned with number
            {
                for (var i = otherShip.From.Letter; i < otherShip.To.Letter; i++)
                {
                    int locationWithin = this.IsLocationWitin(new MapLocation((char)i, otherShip.From.Number));
                    if (locationWithin >= 0)
                        return true;
                }
            }

            return false;
        }
    }
}
