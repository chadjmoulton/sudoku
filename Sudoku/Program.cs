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

            ReadFile(puzzle1);
        }

        static void ReadFile(string puzzle)
        {
            string line;
            char[,] grid = new char[9, 9];
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
                                /*for(int j = 0; j < 9; j++)
                                {
                                    grid[i, j] = line[j];
                                }*/
                            }
                            //fullFile += line;
                            i += 1;
                        }
                    }
                    for (int k = 0; k < 9; k++)
                    {                        
                        for (int j = 0; j < 9; j++)
                        {
                            Debug.Write(grid[k,j]);
                        }
                        Debug.Write("\n");
                    }
                    //return fullFile;
                }
                else
                {
                    //return "";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //return "";
            }
        }

        static void CreateGrid(string fileOutput)
        {
            char[,] grid = new char[9,9];

            if (fileOutput.Length == 81)
            {
                foreach (char cell in fileOutput)
                {

                }
            }
            else
            {

            }
        }
    }
}
