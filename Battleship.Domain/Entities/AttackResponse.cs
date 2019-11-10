using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Entities
{
    public enum AttackResponse
    {
        Undef = -1,
        Miss = 0,
        Hit = 1,
        HitAgain = 2, //User has already hit this cell repeating?
        Sunk = 3
    }
}
