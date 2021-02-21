using System;
using System.Collections.Generic;
using System.Text;

namespace Roshambo
{
    class RockPlayer : IPlayer
    {
        public RockPlayer(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public RPS Result { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }


        public RPS GenerateRPS()
        {
            return RPS.rock;
        }

        
    }
}
