using System;
using TicTacToe2.GameTypes;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe2
{
    class Program
    {
        private static string[] gameTypes = { "C", "I" };

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

        private static bool HandleInput(string input)
        {
            switch (input)
            {
                case "Q":
                    Environment.Exit(0);
                    break;
                case "P":
                    Console.WriteLine("Choose a game type. C for classic, I for inverse.");
                    string gameType = Console.ReadLine();
                    while (!ValidGameType(gameType))
                    {
                        Console.WriteLine(gameType + " is not a valid game type. Please enter C for classic, I for inverse.");
                        gameType = Console.ReadLine();
                    }
                    TicTacToe game;
                    switch (gameType.ToUpper())
                    {
                        case "I":
                            game = new ReverseTicTacToe();
                            break;
                        default:
                            game = new TicTacToe();
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

        private static bool ValidGameType(string gameType)
        {
            return gameType.Contains(gameType.ToUpper());
        }

        public static void WriteCenter(string toWrite)
        {
            string[] strings = toWrite.Split('\n');
            foreach (string text in strings)
                Console.WriteLine("{0," + (Console.WindowWidth + text.Length) / 2 + "}", text);
        }
    }
}
