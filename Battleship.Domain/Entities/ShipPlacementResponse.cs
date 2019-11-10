using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Entities
{
    public class ShipPlacementResponse
    {
        public bool IsSuccess { get; set; }

        public string ReasonFailed { get; set; }

    }
}
