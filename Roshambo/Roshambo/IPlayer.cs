using System;
using System.Collections.Generic;
using System.Text;

namespace Roshambo
{
    interface IPlayer
    {
        public string Name { get; set; }

        RPS GenerateRPS();
    }
}
