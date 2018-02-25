using System;
using System.Linq;

namespace TicTacToe2
{
    public class Board
    {
        /// <summary>
        /// Represents the symbols in the board;
        /// </summary>
        public int[][] Values;

        /// <summary>
        /// Winner in the current board. Zero if none;
        /// </summary>
        public int Winner { get; private set; }

        /// <summary>
        /// Size of the board.
        /// </summary>
        public int Size { get; private set; }

        public Board(int size = 3)
        {

            this.Size = size;
            Values = new int[size][];
            for (int i = 0; i < size; i++)
            {
                Values[i] = new int[size];
            }
        }

        /// <summary>
        /// Place a <paramref name="player"/>'s symbol at a given position.
        /// </summary>
        /// <param name="x">X coordinate of the target position.</param>
        /// <param name="y">Y coordinate of the target position. </param>
        /// <param name="player">Player making this move.</param>
        /// <returns>True if legal move, false otherwise.</returns>
        public bool DoMove(int x, int y, int player)
        {
            if (Values[x][y] != 0)
                return false;

            Values[x][y] = player;
            if (Values[x].All(v => v == player) ||
                Values.All(a => a[y] == player) ||
                (x == y || y == Size - 1 - x) &&
                Diagonals.Any(diag => diag.All(val => val == player)))
                Winner = player;
            
            return true;
        }

        /// <summary>
        /// Returns the diagonals of the board.
        /// Index 0 is top left to bottom right, index 1 is top right to bottom left.
        /// </summary>
        public int[][] Diagonals
        {
            get
            {
                int[][] result =
                {
                    new int[Size],
                    new int[Size]
                };

                for (int i = 0; i < Size; i++)
                {
                    result[0][i] = Values[i][i];
                    result[1][i] = Values[i][Size - 1 - i];
                }
                return result;
            }
        }

        /// <summary>
        /// Wraps the board's values into a fancy string with a grid.
        /// </summary>
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Size; i++)
            {
                result += String.Join("|", Values.Select(row => " " + Program.SymbolMap[row[i]] + " "));
                if (i != Size - 1)
                {
                    result += "\n" + new String('-', Size*4 - 1) + "\n";
                }
            }

            return result;
        }
    }
}
