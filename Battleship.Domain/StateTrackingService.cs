using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Domain
{
    public class StateTrackingService
    {
        private IList<Board> Boards { get; set; }

        private Guid CreateBoard()
        {
            var board = new Board();
            this.Boards.Add(board);

            return board.Id;
        }
    }

    public class ShipPlacementResponse
    {
        public bool IsSuccess { get; set; }

        public string ReasonFailed { get; set; }

        public ShipPlacementResponse()
        {
            IsSuccess = true;
        }
    }
    
    public class Board
    {
        public Guid Id { get; private set; }
        protected IList<Ship>  Ships{ get; private set; }

        public Board()
        {
            this.Id = new Guid();
        }

        public ShipPlacementResponse PlaceShip(Ship ship)
        {
            var placementResult = new ShipPlacementResponse();

            this.Ships.Add(ship);


            return placementResult;
        }

        
        public FireResponse Attack(MapLocation location)
        {
            var ship = Ships.FirstOrDefault(s => s.IsLocationWitin(location) > -1);
            if (ship!=null){
                var cellNumber = ship.IsLocationWitin(location);
            }

            return FireResponse.Miss;

        }


        
    }

    public enum FireResponse
    {
        Miss = 0,
        Hit = 1,
        Sunk = 2
        
        
    }

    public class MapLocation
    {
        public char Letter { get; set; }
        public int Number { get; set; }

        public MapLocation(string letter, int number)
        {
            this.Letter = letter.ToUpperInvariant()[0]; 
        }
    }


    public class Ship
    {
        public MapLocation From { get; protected internal set; }
        public MapLocation To { get; protected internal set; } 

        public bool[] Hits { get; set; } // Array with state of ship cells in order from From to To


        public Ship(MapLocation from, MapLocation to)
        {
            if (from.Letter != to.Letter && from.Number != to.Number)
                throw new Exception("Ship must be aligned either vertically or horizontally");

            if (from.Letter == to.Letter && to.Number < from.Number) // inverted directions of ships are not allowed. Normalize them on service layer
                throw new Exception("Left to right and Top to Bottom please");

            if (to.Number == from.Number && (int)from.Letter < (int)to.Letter)// inverted directions of ships are not allowed. Normalize them on service layer
                throw new Exception("Left to right and Top to Bottom please");

            this.From = from;
            this.To = to;
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
                    return  location.Letter - From.Letter;
            }
            return -1;
        }
    }

}
