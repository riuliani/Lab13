using System;
using System.Collections.Generic;
using System.Text;

namespace Roshambo
{
    class RandomPlayer :IPlayer
    {
        public RandomPlayer(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public RPS GenerateRPS()
        {
            var random = new Random();
            RPS randomEnum = (RPS)random.Next(0, 3);

            return randomEnum;
        }
    }
}
