namespace TicTacToe2.GameTypes
{
    /// <summary>
    /// Multi-board Tic Tac Toe with inverted wincondition.
    /// </summary>
    class InverseMultiBoard : MultiBoardTicTacToe
    {
        /// <summary>
        /// Invert the winner of the base Multi-Board Tic Tac Toe, or 0 if none.
        /// </summary>
        public override int Winner
        {
            get
            {
                switch (base.Winner)
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
