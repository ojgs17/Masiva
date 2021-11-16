using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsOgil
{
    public class Bet
    {
        string IdRoulette { get; set; }
        string UserId { get; set; }
        int Position { get; set; }
        double Money { get; set; }
    }
}
