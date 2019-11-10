using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Domain.Entities
{
    public class Board
    {
        public Guid Id { get; private set; }
        protected IList<Ship> Ships { get; private set; }

        public Board()
        {
            this.Id = Guid.NewGuid();
            this.Ships = new List<Ship>();
        }

        public ShipPlacementResponse PlaceShip(Ship ship)
        {
            ShipPlacementResponse result;
            var intersectingShip = this.Ships.FirstOrDefault(s => s.IntersectsWith(ship));

            if (intersectingShip == null)
            {
                this.Ships.Add(ship);
                return new ShipPlacementResponse { IsSuccess = true };
            }
            else
            {
                return new ShipPlacementResponse
                {
                    IsSuccess = false,
                    ReasonFailed = String.Format("Unable to place. Intersecting ship from {0} to {1}", intersectingShip.From.ToString(), intersectingShip.To.ToString())
                };
            }
        }


        public AttackResponse Attack(MapLocation location)
        {
            var ship = Ships.FirstOrDefault(s => s.IsLocationWitin(location) > -1);

            if (ship != null)
            {
                var cellNumber = ship.IsLocationWitin(location);
                if (ship.Hits[cellNumber] == true)//Has been hit before
                {
                    return AttackResponse.HitAgain;
                }
                else
                {
                    ship.Hits[cellNumber] = true;
                    return ship.IsSunk ? AttackResponse.Sunk : AttackResponse.Hit;
                }
            }
            return AttackResponse.Miss;
        }
    }
}
