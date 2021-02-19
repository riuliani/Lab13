using System;
using System.Collections.Generic;
using System.Text;

namespace Roshambo
{
    class RPSApp
    {
        public HumanPlayer Create(string name)
        {
            var player = new HumanPlayer(name);
            return player;
        }

        public IPlayer SelectPlayer(string userInput)
        {
            switch (userInput)
            {
                case "The Rock":
                    return new RockPlayer(userInput);
                case "Random":
                    return new RandomPlayer(userInput);
                default:
                    throw new ArgumentOutOfRangeException(nameof(userInput));
            }
        }
    }
}
