using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] ticTacToeBoard = InitializeTheBoard();

            int player = 1;
            int numberOfGames = 3;

            Console.WriteLine("How many games would you like to play?");
            Console.Write("Choose from (0 - 9) ---> ");
            
            while (true)
            {
                string numberOfGamesString = Console.ReadLine();
                bool isDigit = false;
                

                if (int.TryParse(numberOfGamesString, out numberOfGames))
                {
                    isDigit = true;
                }

                if (isDigit == false)
                {
                    Console.WriteLine("Invalid number for games!");
                    Console.WriteLine("Try again...");
                    continue;
                }
                else
                {
                    break;
                }
            }

            int countGames = 0;

            while (countGames != numberOfGames)
            {
                PrintTicTacToeBoard(ticTacToeBoard);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine($"Player {(player == 1 ? 'X' : 'O')} turn");
                Console.WriteLine("Row: (0-2): ");

                int row = int.Parse(Console.ReadLine());

                Console.WriteLine("Column: (0-2): ");
                int col = int.Parse(Console.ReadLine());

                //Ckecking if the player chose coordinates that are not valid
                //and if the coordinates are empty
                if (row < 0 || row > ticTacToeBoard.GetLength(0) ||
                    col < 0 || col > ticTacToeBoard.GetLength(1) ||
                    ticTacToeBoard[row, col] != '_')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid coordinates!");
                    Console.WriteLine("Try again...");
                    continue;
                }

                char symbolForPlayer = 'X';

                if (player == -1)
                {
                    symbolForPlayer = 'O';
                }

                //Setting sumbol on the board;
                ticTacToeBoard[row, col] = symbolForPlayer;

                // Clearing the Console
                Console.Clear();

                // Check if we have winning patter
                if (CheckHorizontalPattern(ticTacToeBoard, symbolForPlayer) ||
                    CheckVerticalPattern(ticTacToeBoard, symbolForPlayer) ||
                    CheckDiagonalsPattern(ticTacToeBoard, symbolForPlayer))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Player {symbolForPlayer} won the game!");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press any key to start new game.");
                    Console.ReadLine();
                    Console.Clear();

                    ticTacToeBoard = InitializeTheBoard();
                }

                if (GameIsTie(ticTacToeBoard))
                {
                    Console.ForegroundColor= ConsoleColor.DarkGray;
                    Console.WriteLine("Game is a tie!");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press any key to start new game.");
                    Console.ReadLine();
                    Console.Clear();

                    ticTacToeBoard = InitializeTheBoard();
                }

                    // Multiply by -1 so we can change players turns
                    player *= -1;
                    countGames++;
            }
        }

        private static char[,] InitializeTheBoard()
        {
            //Making the Tic Tac Toe Board as e matrix
            return new char[,]
            {
                { '_', '_', '_' },
                { '_', '_', '_' },
                { '_', '_', '_' }
            };
        }

        private static bool GameIsTie(char[,] ticTacToeBoard)
        {
            foreach (var item in ticTacToeBoard)
            {
                if (item == '_')
                {
                    return false;
                }
            }

            return true;
        }

        public static void PrintTicTacToeBoard(char[,] ticTacToeBoard)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tic Tac Toe Board");

            for (int row = 0; row < ticTacToeBoard.GetLength(0); row++)
            {
                for (int col = 0; col < ticTacToeBoard.GetLength(1); col++)
                {
                    Console.Write(ticTacToeBoard[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static bool CheckHorizontalPattern(char[,] ticTacToeBoard, char symbolForPlayer)
        {
            //Going through the board to check if we have horizontal winning pattern
            for (int row = 0; row < ticTacToeBoard.GetLength(0); row++)
            {
                bool isWinner = true;

                for (int col = 0; col < ticTacToeBoard.GetLength(1); col++)
                {
                    //If on the first row we have different symbols
                    //we break the program and start on a new row
                    if (ticTacToeBoard[row, col] != symbolForPlayer) 
                    {
                        isWinner = false;
                        break;
                    }
                }

                //We have found a winning pattern so we return true
                if (isWinner)
                {
                    return true;
                }
            }

            //We dont have a horizontal winning pattern so we return false
            return false;
        }

        public static bool CheckVerticalPattern(char[,] ticTacToeBoard, char symbolForPlayer)
        {
            //Going through the board to check if we have vertical winning pattern
            for (int col = 0; col < ticTacToeBoard.GetLength(0); col++)
            {
                bool isWinner = true;

                for (int row = 0; row < ticTacToeBoard.GetLength(1); row++)
                {
                    //If on the first column we have different symbols
                    //we break the program and start on a new column
                    if (ticTacToeBoard[row, col] != symbolForPlayer)
                    {
                        isWinner = false;
                        break;
                    }
                }

                //We have found a winning pattern so we return true
                if (isWinner)
                {
                    return true;
                }
            }

            //We dont have a vertical winning pattern so we return false
            return false;
        }

        public static bool CheckDiagonalsPattern(char[,] ticTacToeBoard, char symbolForPlayer)
        {
            bool isWinner = true;

            //We are going through the first diagonal from left to right
            for (int row = 0; row < ticTacToeBoard.GetLength(0); row++)
            {

                // If we find not matching symbol
                if (ticTacToeBoard[row,row] != symbolForPlayer)
                {
                    // Return false and break
                    isWinner = false;
                    break;
                }
            }

            // If we have matching diagonal pattern we return true;
            if (isWinner)
            {
                return true;
            }

            // If we have false value from the first test
            // we set true value to isWinner and check the other diagonal
            isWinner = true;

            //Going through left to right diagonal
            for (int row = 0; row < ticTacToeBoard.GetLength(0); row++)
            {
                if (ticTacToeBoard[ticTacToeBoard.GetLength(0) - row - 1, row] != symbolForPlayer)
                {
                    isWinner = false;
                    break;
                }
            }

            return isWinner;
        }
    }
}
