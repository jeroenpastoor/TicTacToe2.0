using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe2.GameTypes
{
    class ReverseTicTacToe : TicTacToe
    {
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
