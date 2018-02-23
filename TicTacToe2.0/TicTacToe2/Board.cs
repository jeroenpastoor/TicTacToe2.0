using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Microsoft.SqlServer.Server;

namespace TicTacToe2
{
    public class Board
    {
        public int[][] Values;
        private int size = 0;

        public Board(int size = 3)
        {
            this.size = size;
            Values = new int[size][];
            for (int i = 0; i < size; i++)
            {
                Values[i] = new int[size];
            }
        }

        private int[][] TransposedValues()
        {
            int[][] result = new int[size][];
            for (int i = 0; i < size; i++)
            {
                result[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    result[i][j] = Values[j][i];
                }
            }

            return result;
        }

        public virtual int Winner
        {
            get
            {
                int[][] rows = TransposedValues();
                int[] diagA = new int[size];
                int[] diagB = new int[size];
                for (int i = 0; i < size; i++)
                {
                    if (Values[i][0] != 0 && Values[i].All(x => x == Values[i][0]))
                    {
                        return Values[i][0];
                    }
                    if (rows[i][0] != 0 && rows[i].All(x => x == rows[i][0]))
                    {
                        return rows[i][0];
                    }
                    diagA[i] = Values[i][i];
                    diagB[i] = Values[i][size - 1 - i];
                }

                if (diagA[0] != 0 && diagA.All(x => x == diagA[0]))
                {
                    return diagA[0];
                }
                if (diagB[0] != 0 && diagB.All(x => x == diagB[0]))
                {
                    return diagB[0];
                }

                return 0;
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < size; i++)
            {
                result += String.Join("|", Values[i].Select(x =>
                {
                    switch (x)
                    {
                        case 1:
                            return " X ";
                        case 2:
                            return " O ";
                        default:
                            return "   ";
                    }
                }));
                if (i != size - 1)
                {
                    result += "\n" + new String('-', size*4 - 1) + "\n";
                }
            }

            return result;
        }

        public void Display()
        {
            Program.WriteCenter(ToString());
        }
    }
}
