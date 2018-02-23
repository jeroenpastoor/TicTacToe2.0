using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe2.GameTypes
{
    class TicTacToe
    {
        protected Board board;
        protected int maxTurns;

        public TicTacToe(int size = 3)
        {
            maxTurns = size * size;
            board = new Board(size);
        }

        public void Play()
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
                    board.Display();
                    string command = Console.ReadLine();
                    string[] coords = command.Split(',');
                    int x;
                    int y;
                    if (coords.Length == 2 && Int32.TryParse(coords[0], out x) && Int32.TryParse(coords[1], out y))
                    {
                        validMove = board.Values[x][y] == 0;
                        if (validMove)
                        {
                            turn++;
                            board.Values[x][y] = currPlayer;
                            continue;
                        }
                        Console.WriteLine("That position already has an " + board.Values[x][y] + ", choose an empty spot!");
                    }
                    Console.WriteLine("That is not valid input! Enter coordinated such as 0,0 for the top left corner!");
                }
            }

            board.Display();

            if (Winner == 0)
                Console.WriteLine("DRAW!");
            else
                Console.WriteLine("Player {0} is the winner!", Winner);

            Console.WriteLine("Press any key to restart!");
            Console.ReadKey();
        }

        public virtual int Winner => board.Winner;
    }
}
