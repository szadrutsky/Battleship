using Battleship.Domain.Entities;
using System;

namespace Battleship.Domain.Services
{
    public interface IStateTrackingService
    {
        Guid CreateBoard();
        ServiceResponse Attack(Guid boardId, MapLocation location);
        ShipPlacementResponse PlaceShip(Guid boardId, MapLocation locationFrom, MapLocation locationTo);
    }
}
