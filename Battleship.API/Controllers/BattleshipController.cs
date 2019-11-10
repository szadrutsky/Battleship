using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.API.ViewModels;
using Battleship.Domain;
using Battleship.Domain.Entities;
using Battleship.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Controllers
{
    [Route("api/[controller]")]
    public class BattleshipController : Controller
    {
        IStateTrackingService stateTrackingService;

        public BattleshipController(IStateTrackingService stateTrackingService)
        {
            this.stateTrackingService = stateTrackingService;
        }


        [HttpGet("CreateBoard")]
        public Guid CreateBoard()
        {
            return stateTrackingService.CreateBoard();
        }


        
        [HttpPost("PlaceShip")]
        public string PlaceShip([FromBody]PlaceShipViewModel value)
        {
            
            var shipVm = value.Ship;
            
            if (shipVm.From.Letter != shipVm.To.Letter && shipVm.From.Number != shipVm.To.Number)
                return "Ship must be aligned either vertically or horizontally";

            var from = new MapLocation(shipVm.From.Letter, shipVm.From.Number);
            var to = new MapLocation(shipVm.To.Letter, shipVm.To.Number);

            ShipPlacementResponse placementResponse = stateTrackingService.PlaceShip(value.BoardId, from, to); 
                
                
            if (!placementResponse.IsSuccess)
                return placementResponse.ReasonFailed;

            return "Placement Successful";

        }
       

        [HttpPost("Attack")]
        public string Attack([FromBody]AttackViewModel value)
        {
            var location = new MapLocation(value.Location.Letter, value.Location.Number);

            var result = stateTrackingService.Attack(value.BoardId, location);

            if (!String.IsNullOrEmpty(result.ExceptionMessage))
                return result.ExceptionMessage;

            return result.Response.ToString();
        }
    }
}
