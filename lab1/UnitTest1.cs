using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        public char[,] Board { get; set; }
        public char CurrentPlayer { get; set; }

        public Game()
        {
            Board = new char[3, 3];
            CurrentPlayer = 'X';
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Board[i, j] == '\0' ? '.' : Board[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public bool MakeMove(int row, int col)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3 || Board[row, col] != '\0')
                return false;

            Board[row, col] = CurrentPlayer;
            return true;
        }

        public bool CheckWinner()
        {
            // Check rows, columns and diagonals
            for (int i = 0; i < 3; i++)
            {
                if ((Board[i, 0] == CurrentPlayer && Board[i, 1] == CurrentPlayer && Board[i, 2] == CurrentPlayer) ||
                    (Board[0, i] == CurrentPlayer && Board[1, i] == CurrentPlayer && Board[2, i] == CurrentPlayer))
                    return true;
            }

            if ((Board[0, 0] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 2] == CurrentPlayer) ||
                (Board[0, 2] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 0] == CurrentPlayer))
                return true;

            return false;
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            int row, col;
            bool gameOver = false;

            while (!gameOver)
            {
                game.DisplayBoard();
                Console.WriteLine($"Player {game.CurrentPlayer}'s turn. Enter row and column (0-2):");
                row = int.Parse(Console.ReadLine());
                col = int.Parse(Console.ReadLine());

                if (!game.MakeMove(row, col))
                {
                    Console.WriteLine("Invalid move! Try again.");
                    continue;
                }

                if (game.CheckWinner())
                {
                    game.DisplayBoard();
                    Console.WriteLine($"Player {game.CurrentPlayer} wins!");
                    gameOver = true;
                }
                else
                {
                    game.SwitchPlayer();
                }
            }
        }
    }
}
