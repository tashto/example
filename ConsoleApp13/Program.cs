// See https://aka.ms/new-console-template for more information
using System;

namespace ahmadmakkiprojext
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameStatus = 0;
            int currentPlayer = -1;
            char[] ahmedGame = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Console.Title = " You will Lost ";

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            do
            {
                Console.Clear();

                currentPlayer = GetNextPlayer(currentPlayer);

                HeadsUpDisplay(currentPlayer);
                DrawGameboard(ahmedGame);

                GameEngine(ahmedGame, currentPlayer);




            } while (gameStatus.Equals(0));

            Console.Clear();
            HeadsUpDisplay(currentPlayer);
            DrawGameboard(ahmedGame);
            if (gameStatus.Equals(1))
            {
                Console.WriteLine($"Player {currentPlayer} is the winner!");
            }

            if (gameStatus.Equals(2))
            {
                Console.WriteLine($"The game is a draw!");
            }
        }



        private static bool IsGameDraw(char[] ahmedGame)
        {
            return ahmedGame[0] != '1' &&
                   ahmedGame[1] != '2' &&
                   ahmedGame[2] != '3' &&
                   ahmedGame[3] != '4' &&
                   ahmedGame[4] != '5' &&
                   ahmedGame[5] != '6' &&
                   ahmedGame[6] != '7' &&
                   ahmedGame[7] != '8' &&
                   ahmedGame[8] != '9';
        }

        private static bool IsahmedGameTheSame(char[] testahmedGame, int pos1, int pos2, int pos3)
        {
            return testahmedGame[pos1].Equals(testahmedGame[pos2]) && testahmedGame[pos2].Equals(testahmedGame[pos3]);
        }

        private static void GameEngine(char[] ahmedGame, int currentPlayer)
        {
            bool notValidMove = true;

            do
            {

                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) &&
                    (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9")))
                {

                    int.TryParse(userInput, out var gamePlacementMarker);

                    char currentMarker = ahmedGame[gamePlacementMarker - 1];

                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please select anotyher placement.");
                    }
                    else
                    {
                        ahmedGame[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);

                        notValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value please select anotyher placement.");
                }
            } while (notValidMove);
        }

        private static char GetPlayerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }

            return 'X';
        }

        static void HeadsUpDisplay(int PlayerNumber)

        {

            Console.WriteLine("************");
            Console.WriteLine("Welcome to the Game!");
            Console.WriteLine("************");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("************");
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();
            Console.WriteLine("************");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Player {PlayerNumber} to move, select 1 thorugh 9 from the game board.");
            Console.WriteLine();
        }

        static void DrawGameboard(char[] ahmedGame)
        {


            Console.WriteLine($"         {ahmedGame[0]} | {ahmedGame[1]} | {ahmedGame[2]}        ");
            Console.WriteLine("         ---+---+---                                           ");
            Console.WriteLine($"         {ahmedGame[3]} | {ahmedGame[4]} | {ahmedGame[5]}        ");
            Console.WriteLine("         ---+---+---    ");
            Console.WriteLine($"         {ahmedGame[6]} | {ahmedGame[7]} | {ahmedGame[8]}        ");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Game over ");
        }

        static int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }

            return 1;
        }
    }
}