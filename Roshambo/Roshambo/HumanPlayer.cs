using System;
using System.Collections.Generic;
using System.Text;

namespace Roshambo
{
    class HumanPlayer : IPlayer
    {
        public HumanPlayer(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public RPS GenerateRPS()
        {
            throw new Exception();
        }
    }
}
