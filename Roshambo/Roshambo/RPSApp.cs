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

        public IPlayer SelectPlayer(string opponentName)
        {
            switch (opponentName)
            {
                case "The Rock":
                    return new RockPlayer(opponentName);
                case "Random":
                    return new RandomPlayer(opponentName);
                default:
                    throw new ArgumentOutOfRangeException(nameof(opponentName));
            }
        }
    }
}
