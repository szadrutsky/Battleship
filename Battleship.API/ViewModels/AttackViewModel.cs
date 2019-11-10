using System;

namespace Battleship.API.ViewModels
{
    public class AttackViewModel
    {
        public Guid BoardId { get; set; }
        public MapLocationViewModel Location { get; set; }

    }
}
