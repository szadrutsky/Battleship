using System;

namespace Battleship.API.ViewModels
{
    public class PlaceShipViewModel
    {
        public Guid BoardId { get; set; }
        public ShipViewModel Ship { get; set; }

    }
}
