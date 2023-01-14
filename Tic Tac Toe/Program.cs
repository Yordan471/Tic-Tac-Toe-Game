using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] ticTacToeBoard = new char[,]
            {
                { '_', '_', '_' },
                { '_', '_', '_' },
                { '_', '_', '_' }
            };

            int player = 1;

            while (true)
            {
                PrintTicTacToeBoard(ticTacToeBoard);
                Console.WriteLine();
                Console.WriteLine($"Player {(player == 1? 'X' : 'O')} turn");
                Console.WriteLine("Row: (0-2): ");
                int row = int.Parse(Console.ReadLine());

                Console.WriteLine("Column: (0-2): ");
                int col = int.Parse(Console.ReadLine());

                if (row < 0 || row > ticTacToeBoard.GetLength(0) ||
                    col < 0 || col > ticTacToeBoard.GetLength(1) ||
                    ticTacToeBoard[row, col] != '_')
                {
                    Console.WriteLine("Invalid coordinates!");
                    Console.WriteLine("Try again...");
                    continue;
                }

                char symbolForPlayer = 'X';

                if (player == -1)
                {
                    symbolForPlayer = 'O';
                }

                ticTacToeBoard[row, col] = symbolForPlayer;
                // Clearing the Console
                Console.Clear();                

                player *= -1;
            }

            
        }

        private static void PrintTicTacToeBoard(char[,] ticTacToeBoard)
        {
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
    }
}
