using System;
using System.Text.RegularExpressions;

namespace Roshambo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!");

            var name = GetPlayerName();

            var opponentSelected = SelectOpponent();
            var opponent = CreateOppnent(opponentSelected);

            var userInput = SelectRockPaperOrScissors();

            var humanPlayer = Create(name);
            var selection = humanPlayer.GenerateRPS();

        }

        private static string GetPlayerName()
        {
            string userInput;
            do
            {
                Console.WriteLine("Please enter your name:");
                userInput = Console.ReadLine();

            } while (!IsUserInputValid(userInput));
            return userInput;
        }

        private static string SelectRockPaperOrScissors()
        {
            string userInput;
            bool isInvalid;
            do
            {
                do
                {
                    Console.WriteLine("Rock, paper, or scissors? (R/P/S)");
                    userInput = Console.ReadLine();

                    isInvalid = userInput != "t" && userInput != "r";
                    if (isInvalid)
                    {
                        Console.WriteLine("OOPS! You need to enter 't' or 'r'!");
                    }

                } while (isInvalid);

            } while (!IsUserInputValid(userInput));

            return userInput;
        }

        private static string SelectOpponent()
        {
            string userInput;
            bool isInvalid;
            do
            {
                do
                {
                    Console.WriteLine("Would you like to play against The Rock, or Random? (t/r)");
                    userInput = Console.ReadLine();

                    isInvalid = userInput != "t" && userInput != "r";
                    if (isInvalid)
                    {
                        Console.WriteLine("OOPS! You need to enter 't' or 'r'!");
                    }
                } while (isInvalid);

            } while (!IsUserInputValid(userInput));

            if (userInput == "t")
            {
                return "The Rock";
            }
            else
            {
                return "Random";
            }
        }

        private static bool IsUserInputValid(string userInput)
        {
            Regex regex = new Regex("^[A-Za-z]*$");
            if (int.TryParse(userInput, out int number))
            {
                return false;
            }
            else if (!regex.IsMatch(userInput))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static HumanPlayer Create(string name)
        {
            var player = new HumanPlayer(name);
            return player;
        }

        private static RPS CreateOppnent(string opponentSelected)
        {
            var opponent = new RPSApp().SelectPlayer(opponentSelected).GenerateRPS();
            return opponent;

        }
    }
}

