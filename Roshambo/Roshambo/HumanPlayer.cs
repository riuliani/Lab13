using System;
using System.Collections.Generic;
using System.Text;

namespace Roshambo
{
    class HumanPlayer : IPlayer
    {
        public HumanPlayer(string name, string selection)
        {
            Name = name;
            Selection = selection;
        }
        public string Name { get; set; }
        public string Selection { get; }
        public RPS Result { get; set; }
        public int Wins { get; set; }
        public int Losses {get; set; }
        public int Ties { get; set; }


        public RPS GenerateRPS()
        {
            if(Selection == "r")
            {
                return  RPS.rock;
            }
            else if(Selection == "p")
            {
                return  RPS.paper;
            }
            else
            {
                return  RPS.scissors;
            }
        }
    }
}
