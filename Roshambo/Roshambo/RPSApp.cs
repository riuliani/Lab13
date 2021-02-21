using System;
using System.Collections.Generic;
using System.Text;

namespace Roshambo
{
    class RPSApp
    {
        public HumanPlayer Create(string name, string userInput)
        {
            var player = new HumanPlayer(name, userInput);
            var result = player.GenerateRPS();
            player.Result = result;
            return player;
        }

        public IPlayer SelectOpponent(string userInput)
        {
            switch (userInput)
            {
                case "The Rock":
                    RockPlayer rockPlayer = new RockPlayer(userInput);
                    var result = rockPlayer.GenerateRPS();
                    rockPlayer.Result = result;
                    return rockPlayer;
                case "Random":
                    RandomPlayer random = new RandomPlayer(userInput);
                    var randomResult = random.GenerateRPS();
                    random.Result = randomResult;
                    return random;
                default:
                    throw new ArgumentOutOfRangeException(nameof(userInput));
            }
        }        
    }
}
