using System;
using System.Text.RegularExpressions;

namespace Roshambo
{
    class Program
    {
        static void Main(string[] args)
        {
            int humanPlayerWinCounter = 0;
            int humanPlayerLossCounter = 0;
            int rockPlayerWinCounter = 0;
            int rockPlayerLossCounter = 0;
            int randomPlayerWinCounter = 0;
            int randomPlayerLossCounter = 0;
            Console.WriteLine("Welcome to Rock Paper Scissors!");

            var name = GetPlayerName();

            string continueProgram;
            do
            {
                var opponentSelected = SelectOpponent();
                var opponent = CreateOppnent(opponentSelected);

                var userInput = SelectRockPaperOrScissors();

                HumanPlayer humanPlayer = Create(name, userInput);
                Console.WriteLine();

                DisplaySelection(humanPlayer, opponent);
                DisplayWinner(humanPlayer, opponent, humanPlayerWinCounter, humanPlayerLossCounter, rockPlayerWinCounter, rockPlayerLossCounter,
                              randomPlayerWinCounter, randomPlayerLossCounter);

                Results(humanPlayer, opponent, humanPlayerWinCounter, humanPlayerLossCounter, rockPlayerWinCounter, rockPlayerLossCounter,
                              randomPlayerWinCounter, randomPlayerLossCounter);

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
        private static void DisplayWinner(HumanPlayer humanPlayer, IPlayer opponent, int humanPlayerWinCounter, int humanPlayerLossCounter,
                                          int rockPlayerWinCounter, int rockPlayerLossCounter, int randomPlayerWinCounter, int randomPlayerLossCounter)
        {
            if (humanPlayer.GenerateRPS() == opponent.GenerateRPS())
            {
                Console.WriteLine("It is a draw!");
            }
            else if (humanPlayer.GenerateRPS() == RPS.paper && opponent.GenerateRPS() == RPS.rock ||
                    humanPlayer.GenerateRPS() == RPS.rock && opponent.GenerateRPS() == RPS.scissors ||
                    humanPlayer.GenerateRPS() == RPS.scissors && opponent.GenerateRPS() == RPS.paper)
            {
                Console.WriteLine($"{humanPlayer.Name} wins!");
                humanPlayerWinCounter++;
                if(opponent.Name == "The Rock")
                {
                    rockPlayerLossCounter++;
                }
                else
                {
                    randomPlayerLossCounter++;
                }
            }
            else
            {
                Console.WriteLine($"{opponent.Name} wins!");

                if (opponent.Name == "The Rock")
                {
                    rockPlayerWinCounter++;
                    humanPlayerLossCounter++;
                }
                else
                {
                    randomPlayerWinCounter++;
                    humanPlayerLossCounter++;
                }
            }
        }

        private static void DisplaySelection(HumanPlayer humanPlayer, IPlayer opponent)
        {
            Console.WriteLine($"{humanPlayer.Name} selected: {humanPlayer.GenerateRPS()}");
            Console.WriteLine($"{opponent.Name} selected: {opponent.GenerateRPS()}");
            Console.WriteLine();
        }

        private static void EndProgram()
        {
            Console.WriteLine("Thank you for playing Roshambo!");

        }

        private static void Results(HumanPlayer humanPlayer, IPlayer opponent, int humanPlayerWinCounter, int humanPlayerLossCounter,
                                    int rockPlayerWinCounter, int rockPlayerLossCounter, int randomPlayerWinCounter, int randomPlayerLossCounter)
        {
            Console.WriteLine($"{humanPlayer.Name}: Wins {humanPlayerWinCounter} : Losses {humanPlayerLossCounter}" + "\r\n" +                               
                              $"{opponent.Name}: Wins {rockPlayerWinCounter} Losses {rockPlayerLossCounter}" + "\r\n" +
                              $"{opponent.Name}: Wins {randomPlayerWinCounter}: Losses {randomPlayerLossCounter}");
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
                    Console.WriteLine("Rock, paper, or scissors? (r/p/s)");
                    userInput = Console.ReadLine();

                    isInvalid = userInput != "r" && userInput != "p" && userInput != "s";
                    if (isInvalid)
                    {
                        Console.WriteLine("OOPS! You need to enter 'r', 'p' or 's'!");
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
            if (!regex.IsMatch(userInput))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static HumanPlayer Create(string name, string userInput)
        {
            var player = new HumanPlayer(name, userInput);
            return player;
        }

        private static IPlayer CreateOppnent(string userInput)
        {
            var opponent = new RPSApp().SelectPlayer(userInput);
            return opponent;

        }
    }
}

