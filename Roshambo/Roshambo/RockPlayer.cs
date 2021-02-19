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

        public RPS GenerateRPS()
        {
            return RPS.rock;
        }
    }
}
