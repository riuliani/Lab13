using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Roshambo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Roshambo App!");
            var name = GetUserName();

            string continueProgram;
            do
            {
                var opponentSelected = SelectOpponent();
                var selection = SelectRockPaperOrScissors();

                HumanPlayer human = CreateHuman(name, selection);
                IPlayer opponent = CreateOpponent(opponentSelected);

                DisplaySelection(human, opponent);

                Winner(human, opponent);

                DisplayWinsAndLosses(human, opponent);

                bool isValid;
                do
                {
                    Console.WriteLine("Would you like to continue? (y/n)");
                    continueProgram = Console.ReadLine();
                    isValid = continueProgram == "y" && continueProgram == "n";

                } while (isValid);

            } while (continueProgram == "y");

            EndProgram();
        }
        private static void EndProgram()
        {
            Console.WriteLine("Thank you for playing Roshambo" + "\r\n" + "Goodbye!");
        }

        private static void DisplayWinsAndLosses(HumanPlayer human, IPlayer opponent)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"{human.Name}: Wins: {human.Wins} Losses: {human.Losses} Ties: {human.Ties}");
            Console.WriteLine($"{opponent.Name}: Wins: {opponent.Wins} Losses: {opponent.Losses} Ties: {opponent.Ties}");
        }
        private static void DisplaySelection(HumanPlayer newHuman, IPlayer newOpponent)
        {
            Console.WriteLine($"{newHuman.Name} selected: {newHuman.Result}");
            Console.WriteLine($"{newOpponent.Name} selected: {newOpponent.Result}");
        }

        private static string GetUserName()
        {
            string userInput;
            do
            {
                Console.WriteLine("Please enter your name");
                userInput = Console.ReadLine();

            } while (!IsUserInputValid(userInput));

            return userInput;
        }

        private static string SelectOpponent()
        {
            string userInput;
            bool isInvalid;
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

            if (userInput == "t")
            {
                return "The Rock";
            }
            else
            {
                return "Random";
            }
        }

        private static IPlayer CreateOpponent(string opponent)
        {
            RPSApp rps = new RPSApp();
            var newOpponent = rps.SelectOpponent(opponent);
            return newOpponent;
        }
        private static HumanPlayer CreateHuman(string name, string selection)
        {
            RPSApp rps = new RPSApp();
            var newOpponent = rps.Create(name, selection);
            return newOpponent;
        }

        private static string SelectRockPaperOrScissors()
        {
            string userInput;
            bool isInvalid;

            do
            {
                Console.WriteLine("Rock, paper, or scissors? (r/p/s)");
                userInput = Console.ReadLine();

                isInvalid = userInput != "r" && userInput != "p" && userInput != "s";
                if (isInvalid)
                {
                    Console.WriteLine("OOPS! You need to enter 'r', 'p' or 's'!");
                }

            } while (isInvalid);

            return userInput;
        }

        private static bool IsUserInputValid(string userInput)
        {
            Regex regex = new Regex("^[A-Za-z]*$");
            if (!regex.IsMatch(userInput))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void Winner(HumanPlayer human, IPlayer opponent)
        {
            if (human.Result == RPS.rock && opponent.Result == RPS.paper)
            {
                Console.WriteLine($"{opponent.Name} Wins!");
                human.Losses++;
                opponent.Wins++;
            }
            else if (human.Result == RPS.rock && opponent.Result == RPS.scissors)
            {
                Console.WriteLine($"{human.Name} Wins!");
                human.Wins++;
                opponent.Losses++;
            }
            else if (human.Result == RPS.scissors && opponent.Result == RPS.paper)
            {
                Console.WriteLine($"{human.Name} Wins!");
                human.Wins++;
                opponent.Losses++;
            }
            else if (human.Result == RPS.scissors && opponent.Result == RPS.rock)
            {
                Console.WriteLine($"{opponent.Name} Wins!");
                human.Losses++;
                opponent.Wins++;
            }
            else if (human.Result == RPS.paper && opponent.Result == RPS.scissors)
            {
                Console.WriteLine($"{opponent.Name} Wins!");
                human.Losses++;
                opponent.Wins++;
            }
            else if (human.Result == RPS.paper && opponent.Result == RPS.rock)
            {
                Console.WriteLine($"{human.Name} Wins!");
                human.Wins++;
                opponent.Losses++;
            }
            else
            {
                Console.WriteLine("It is a tie!");
                human.Ties++;
                opponent.Ties++;
            }
        }
    }
}

