using System;

namespace TicTacToe2.GameTypes
{
    /// <summary>
    /// Generic game class.
    /// </summary>
    abstract class Game
    {
        /// <summary>
        /// Max number of turns possible. Used for draws.
        /// </summary>
        protected int maxTurns;

        public Game(int size = 3)
        {
            if (size <= 1)
                throw new ArgumentOutOfRangeException("The size of tic tac toe boards needs to be greater than 1!");
        }

        /// <summary>
        /// Controls the full gameplay. The generic version only shows the results for the given board and waits for input to restart.
        /// </summary>
        public virtual void Play()
        {
            if (Winner == 0)
                Console.WriteLine("DRAW!");
            else
                Console.WriteLine("Player {0} ({1}) is the winner!", Winner, Program.SymbolMap[Winner]);

            Console.WriteLine("Press any key to restart!");
            Console.ReadKey();
        }
        
        /// <summary>
        /// Property to determine the winner of the game.
        /// </summary>
        public abstract int Winner { get; }
    }
}
