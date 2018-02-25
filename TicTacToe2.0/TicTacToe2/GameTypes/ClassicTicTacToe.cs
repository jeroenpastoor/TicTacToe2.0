using System;
using System.CodeDom;

namespace TicTacToe2.GameTypes
{
    /// <summary>
    /// Classic Tic Tac Toe game as we all know it.
    /// </summary>
    class ClassicTicTacToe : Game
    {
        /// <summary>
        /// Board the game is played on.
        /// </summary>
        protected Board board;
        
        /// <summary>
        /// Initializes classic tic tac toe game.
        /// </summary>
        /// <param name="size">Width and height of the board.</param>
        public ClassicTicTacToe(int size = 3) : base(size)
        {
            maxTurns = size * size;
            board = new Board(size);
        }

        /// <summary>
        /// Standard Tic Tac Toe gameplay. Players take turns placing symbols.
        /// </summary>
        public override void Play()
        {
            int turn = 1;
            while (Winner == 0 && turn <= maxTurns)
            {
                bool validMove = false;
                int currPlayer = 2 - turn % 2;
                Console.Write("It's currently Player {0}'s turn! Enter the coordinates where you want to place your symbol!\n" +
                              "Example: 0,0 for the top left corner!\n", currPlayer);

                while (!validMove)
                {
                    Program.WriteCenter(board.ToString());
                    string command = Console.ReadLine();
                    string[] coords = command.Split(',');
                    int x;
                    int y;
                    if (coords.Length == 2 && Int32.TryParse(coords[0], out x) && Int32.TryParse(coords[1], out y))
                    {
                        if (board.DoMove(x, y, currPlayer))
                        {
                            validMove = true;
                            turn++;
                            continue;
                        }
                        Console.WriteLine("That position already has an " + Program.SymbolMap[board.Values[x][y]] + ", choose an empty spot!");
                    }
                    Console.WriteLine("That is not valid input! Enter coordinated such as 0,0 for the top left corner!");
                }
            }

            Program.WriteCenter(board.ToString());

            base.Play();
        }

        /// <summary>
        /// The game's winner is the same as the board's winner.
        /// </summary>
        public override int Winner => board.Winner;
    }
}
