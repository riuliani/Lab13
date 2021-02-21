using System;
using System.Collections.Generic;
using System.Text;

namespace Roshambo
{
    interface IPlayer
    {
        public string Name { get; }
        public RPS Result { get; set; }
        public int Ties { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        
        RPS GenerateRPS();
    }
}
