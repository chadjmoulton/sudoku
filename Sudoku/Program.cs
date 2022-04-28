using System;
using System.IO;
using System.Diagnostics;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            string puzzle1 = AppDomain.CurrentDomain.BaseDirectory + "puzzle1.txt";

            char[,] grid1 = ReadFile(puzzle1);

            Board Game1 = new Board(grid1);
            //solve(grid1);
            //Board board1 = new Board(grid1);
            //board1.Solve(board1.board);

            for (int k = 0; k < 9; k++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //Debug.Write(board1.board[k, j]);
                    Debug.Write(grid1[k,j]);
                }
                Debug.Write("\n");
            }
        }

        static char[,] ReadFile(string puzzle)
        {
            string line;
            char[,] grid = new char[9, 9];
            char[,] decoy = new char[,] { { 'a', 'a' } };
            int i = 0;
            //string fullFile = "";

            try
            {
                if (File.Exists(puzzle))
                {
                    using (StreamReader sr = new StreamReader(puzzle))
                    {
                        while (sr.Peek() > -1)
                        {
                            line = sr.ReadLine();
                            for(int j = 0; j < 9; j++)
                            {
                                grid[i, j] = line[j];
                            }
                            i += 1;
                        }
                    }
                    
                    return grid;
                }
                else
                {
                    return decoy;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Environment.Exit(0);
                return decoy;
            }
        }
    }
}
