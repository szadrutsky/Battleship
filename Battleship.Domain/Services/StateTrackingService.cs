using Battleship.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Domain.Services
{
    public class StateTrackingService : IStateTrackingService
    {
        private IList<Board> Boards { get; set; }

        public StateTrackingService()
        {
            this.Boards = new List<Board>();
        }

        public Guid CreateBoard()
        {
            var board = new Board();


            this.Boards.Add(board);

            return board.Id;
        }

        public ServiceResponse Attack(Guid boardId, MapLocation location)
        {
            ServiceResponse response = null;

            var board = Boards.FirstOrDefault(b => b.Id == boardId);
            if (board != null)
            {
                var result = board.Attack(location);
                return new ServiceResponse { Response = result};
            }
            else
            {
                return new ServiceResponse { Response = AttackResponse.Undef, ExceptionMessage = "Board has not been found" };
            }

        }

        public ShipPlacementResponse PlaceShip(Guid boardId, MapLocation locationFrom, MapLocation  locationTo)
        {
            ServiceResponse response = null;

            var board = Boards.FirstOrDefault(b => b.Id == boardId);
            if (board != null)
            {
                Ship ship = null;
                //Normalize From To // Left TO Right // topToBottom 
                if (locationFrom.Letter == locationTo.Letter) //If user passes reversed ship  H2->C2 - we should reverse it and place ship as C2 To h2
                {
                    if (locationFrom.Number <= locationTo.Number)
                        ship = new Ship( new MapLocation(locationFrom.Letter, locationFrom.Number), new MapLocation(locationTo.Letter, locationTo.Number)); //all good
                    else
                        ship = new Ship(new MapLocation(locationFrom.Letter, locationTo.Number), new MapLocation(locationTo.Letter, locationFrom.Number)); //reverse in Numbers direction
                }
                else if (locationFrom.Number == locationTo.Number)
                {
                    if (locationFrom.Letter <= locationTo.Letter)
                        ship = new Ship(new MapLocation(locationFrom.Letter, locationFrom.Number), new MapLocation(locationTo.Letter, locationTo.Number)); //all good
                    else
                        ship = new Ship(new MapLocation(locationTo.Letter, locationFrom.Number), new MapLocation(locationFrom.Letter, locationTo.Number)); //reverse in Letters direction
                }

                return  board.PlaceShip(ship); 
            }
            return new ShipPlacementResponse {IsSuccess = false, ReasonFailed = "Board has not been found" }; 
        }
    }

    public class ServiceResponse
    {
        public AttackResponse Response { get; set; }
        public string ExceptionMessage { get; set; }

    }
}
