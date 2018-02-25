using System;
using System.Linq;

namespace TicTacToe2.GameTypes
{
    /// <summary>
    /// Multi-Board Tic Tac Toe.
    /// Multiple boards are positioned in a similar grid as the squares on a Tic Tac Toe board.
    /// Player 1 starts in the middle board. Placing a symbol in a square makes the next player play in the board in the same grid position.
    /// </summary>
    class MultiBoardTicTacToe : Game
    {
        /// <summary>
        /// Grid of boards.
        /// </summary>
        protected Board[,] boards;
        
        /// <summary>
        /// Size of the grid of boards & boards themselves.
        /// </summary>
        private int size;

        public MultiBoardTicTacToe(int size = 3)
        {
            this.size = size;
            maxTurns = (int)Math.Pow(size, 3);
            boards = new Board[size,size];
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    boards[x,y] = new Board(size);
        }

        /// <summary>
        /// Initializes multi-board tic tac toe game.
        /// </summary>
        /// <param name="size">Width and height of the board, as well as the grid of boards.</param>
        public override void Play()
        {
            int turn = 1;
            int lastX = 1;
            int lastY = 1;
            while (Winner == 0 && turn <= maxTurns)
            {
                bool validMove = false;
                int currPlayer = 2 - turn % 2;
                Console.Write("It's currently Player {0}'s turn! You have to place a symbol into the board at ({1}, {2})\n" +
                              "Enter the coordinates where you want to place your symbol!\n" +
                              "Example: 0,0 for the top left corner!\n", currPlayer, lastX, lastY);

                while (!validMove)
                {
                    ShowBoards();
                    Board board = boards[lastX,lastY];
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
                            lastX = x;
                            lastY = y;
                            continue;
                        }
                        Console.WriteLine("That position already has an " + Program.SymbolMap[board.Values[x][y]] + ", choose an empty spot!");
                    }
                    Console.WriteLine("That is not valid input! Enter coordinated such as 0,0 for the top left corner!");
                }
            }

            ShowBoards();

            base.Play();
        }

        /// <summary>
        /// Shows all boards on the grid in the console.
        /// </summary>
        public void ShowBoards()
        {
            string result = "";
            for (int y = 0; y < size; y++)
            {
                string[] rowLines = new string[size*2-1];
                for (int x = 0; x < size; x++)
                {
                    string[] lines = boards[x, y].ToString().Split('\n');
                    rowLines = rowLines.Zip(lines, (s, s1) => s + "  " + s1).ToArray();
                }
                result += string.Join("\n", rowLines) + "\n\n";
            }

            Program.WriteCenter(result);
        }

        /// <summary>
        /// The game's winner is any board's winner, or 0 if none.
        /// </summary>
        public override int Winner
        {
            get
            {
                foreach (Board board in boards)
                {
                    if (board.Winner != 0)
                        return board.Winner;
                }

                return 0;
            }
        }
    }
}
