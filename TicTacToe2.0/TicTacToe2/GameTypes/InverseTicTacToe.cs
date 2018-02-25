using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe2.GameTypes
{
    /// <summary>
    /// Classic Tic Tac Toe with an inverted wincondition: Force your opponent to fill a row, collumn or diagonal.
    /// </summary>
    class InverseTicTacToe : ClassicTicTacToe
    {
        /// <summary>
        /// Invert the winner of the board, or 0 if none.
        /// </summary>
        public override int Winner
        {
            get
            {
                switch (board.Winner)
                {
                    case 1:
                        return 2;
                    case 2:
                        return 1;
                    default:
                        return 0;
                }
            }
        }
    }
}
