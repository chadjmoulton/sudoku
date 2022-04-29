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
            string puzzle2 = AppDomain.CurrentDomain.BaseDirectory + "puzzle2.txt";
            string puzzle3 = AppDomain.CurrentDomain.BaseDirectory + "puzzle3.txt";
            string puzzle4 = AppDomain.CurrentDomain.BaseDirectory + "puzzle4.txt";
            string puzzle5 = AppDomain.CurrentDomain.BaseDirectory + "puzzle5.txt";

            char[,] grid1 = ReadFile(puzzle1);
            char[,] grid2 = ReadFile(puzzle2);
            char[,] grid3 = ReadFile(puzzle3);
            char[,] grid4 = ReadFile(puzzle4);
            char[,] grid5 = ReadFile(puzzle5);

            Board Game1 = new Board(grid1);
            Game1.Solve(Game1.board);


            for (int k = 0; k < 9; k++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Debug.Write(Game1.board[k,j]);
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
