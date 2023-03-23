// See https://aka.ms/new-console-template for more information
using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]; // tic tac toe board

        static void Main(string[] args)
        {
            InitializeBoard();
            DisplayBoard();

            int currentPlayer = 1; // player 1 starts

            // game loop
            while (true)
            {
                Console.WriteLine("Player {0}'s turn", currentPlayer);
                Console.WriteLine("Enter row and column separated by space: ");
                string[] input = Console.ReadLine().Split(' ');

                int row, col;

                if (input.Length != 2 || !int.TryParse(input[0], out row) || !int.TryParse(input[1], out col))
                {
                    Console.WriteLine("Invalid input, please try again.");
                    continue;
                }

                row--;
                col--;

                if (row < 0 || row > 2 || col < 0 || col > 2)
                {
                    Console.WriteLine("Invalid position, please try again.");
                    continue;
                }

                if (board[row, col] != '\0')
                {
                    Console.WriteLine("Position already occupied, please try again.");
                    continue;
                }

                board[row, col] = currentPlayer == 1 ? 'X' : 'O';
                DisplayBoard();

                if (CheckForWinner())
                {
                    Console.WriteLine("Player {0} wins!", currentPlayer);
                    break;
                }

                if (CheckForTie())
                {
                    Console.WriteLine("It's a tie!");
                    break;
                }

                currentPlayer = currentPlayer == 1 ? 2 : 1;
            }

            Console.ReadLine();
        }

        // initialize board with empty cells
        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '\0';
                }
            }
        }

        // display current state of board
        static void DisplayBoard()
        {
            Console.WriteLine("  1 2 3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + (board[i, j] == '\0' ? '_' : board[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // check if any player has won
        static bool CheckForWinner()
        {
            // check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != '\0' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
            }

            // check columns
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] != '\0' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                {
                    return true;
                }
            }

            // check diagonals
            if (board[0, 0] != '\0' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
                            if (board[0, 2] != '\0' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            return false;
        }

        // check if the board is full and no player has won
        static bool CheckForTie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '\0')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

           
