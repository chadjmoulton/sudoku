using System;
using System.IO;
using System.Diagnostics;

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

            string sln1 = AppDomain.CurrentDomain.BaseDirectory + "puzzle1.sln.txt";
            string sln2 = AppDomain.CurrentDomain.BaseDirectory + "puzzle2.sln.txt";
            string sln3 = AppDomain.CurrentDomain.BaseDirectory + "puzzle3.sln.txt";
            string sln4 = AppDomain.CurrentDomain.BaseDirectory + "puzzle4.sln.txt";
            string sln5 = AppDomain.CurrentDomain.BaseDirectory + "puzzle5.sln.txt";

            char[,] grid1 = ReadFile(puzzle1);
            char[,] grid2 = ReadFile(puzzle2);
            char[,] grid3 = ReadFile(puzzle3);
            char[,] grid4 = ReadFile(puzzle4);
            char[,] grid5 = ReadFile(puzzle5);

            if (grid1.Length == 81) // if not decoy
            { 
                Board Game1 = new Board(grid1); //instantiate object for puzzle1.txt
                Game1.Solve(Game1.board);

                WriteToFile(sln1, Game1.board);
            }

            if (grid2.Length == 81) 
            {
                Board Game2 = new Board(grid2); 
                Game2.Solve(Game2.board);

                WriteToFile(sln2, Game2.board);
            }

            if (grid3.Length == 81) 
            {
                Board Game3 = new Board(grid3); 
                Game3.Solve(Game3.board);

                WriteToFile(sln3, Game3.board);
            }

            if (grid4.Length == 81) 
            {
                Board Game4 = new Board(grid4); 
                Game4.Solve(Game4.board);

                WriteToFile(sln4, Game4.board);
            }

            if (grid5.Length == 81) 
            {
                Board Game5 = new Board(grid5); 
                Game5.Solve(Game5.board);

                WriteToFile(sln5, Game5.board);
            }
        }

        static char[,] ReadFile(string puzzle)
        {
            string line;
            char[,] grid = new char[9, 9];
            char[,] decoy = new char[,] { { 'a', 'a' } }; //decoy so function can return without error
            int i = 0;

            try
            {
                if (File.Exists(puzzle))
                {
                    using (StreamReader sr = new StreamReader(puzzle))
                    {
                        while (sr.Peek() > -1) //while not end of file
                        {
                            line = sr.ReadLine();
                            // line by line read from file and populate 2x2 array which is the game board
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
                    Console.WriteLine("");
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

        static void WriteToFile(string file, char[,] game)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(file))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            sw.Write(game[i, j]);
                        }
                        sw.Write("\n");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Environment.Exit(0);
            }
        }
    }
}
