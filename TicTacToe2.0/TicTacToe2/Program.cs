using System;
using TicTacToe2.GameTypes;
using System.Collections.Generic;
namespace TicTacToe2
{
    class Program
    {
        /// <summary>
        /// Maps the player number to its symbol (or a space if no player).
        /// </summary>
        public static readonly Dictionary<int, string> SymbolMap = new Dictionary<int, string>()
        {
            { 0, " " },
            { 1, "X" },
            { 2, "O" }
        };

        /// <summary>
        /// Maps input to game types.
        /// </summary>
        private static readonly Dictionary<string, string> _gameTypes = new Dictionary<string, string>()
        {
            { "C", "Classic" },
            { "I", "Inverse" },
            { "M", "Multi-Board" },
            { "IM", "Inverse Multi-Board" }
        };

        static void Main(string[] args)
        {
            while (true)
            {
                WriteCenter(
                    "*********************\n" +
                    "*  TIC TAC TOE 2.0  *\n" +
                    "* By Jeroen Pastoor *\n" +
                    "*   February 2018   *\n" +
                    "*********************\n" +
                    "\n" +
                    "Enter P to play, Q to quit, R to restart."
                );

                bool restart = false;
                while (!restart)
                {
                    string input = Console.ReadLine().ToUpper();
                    restart = HandleInput(input);
                }
                Console.Clear();
            }
        }

        /// <summary>
        /// Takes input from the player and acts on it.
        /// </summary>
        /// <param name="input">Input given in the console.</param>
        /// <returns>False if invalid input.</returns>
        private static bool HandleInput(string input)
        {
            switch (input)
            {
                case "Q":
                    Environment.Exit(0);
                    break;
                case "P":
                    string typeOptions = "";
                    foreach (var key in _gameTypes.Keys)
                    {
                        if (typeOptions != "")
                            typeOptions += ", ";
                        typeOptions += key + " for " + _gameTypes[key];
                    }
                    Console.WriteLine("Choose a game type. {0}.", typeOptions);
                    string gameType = Console.ReadLine();
                    while (!ValidGameType(gameType))
                    {
                        Console.WriteLine("{0} is not a valid game type. Please enter {1}.",  gameType, typeOptions);
                        gameType = Console.ReadLine();
                    }
                    Game game;
                    switch (gameType.ToUpper())
                    {
                        case "M":
                            game = new MultiBoardTicTacToe();
                            break;
                        case "IM":
                            game = new InverseMultiBoard();
                            break;
                        case "I":
                            game = new InverseTicTacToe();
                            break;
                        default:
                            game = new ClassicTicTacToe();
                            break;
                    }
                    game.Play();
                    Console.WriteLine("Would totally play now!");
                    break;
                case "R":
                    return false;
                default:
                    Console.WriteLine("Invalid input! " + input + " is not recognized.");
                    break;
            }

            return true;
        }

        /// <summary>
        /// Checks if the input for gameType is a valid choice.
        /// </summary>
        /// <param name="gameType">Player's input.</param>
        private static bool ValidGameType(string gameType)
        {
            return _gameTypes.ContainsKey(gameType.ToUpper());
        }

        /// <summary>
        /// Writes a string in the center of the console, keeping in mind possible multi-line strings.
        /// </summary>
        /// <param name="toWrite">The string to write in the console.</param>
        public static void WriteCenter(string toWrite)
        {
            string[] strings = toWrite.Split('\n');
            foreach (string text in strings)
                Console.WriteLine("{0," + (Console.WindowWidth + text.Length) / 2 + "}", text);
        }
    }
}
