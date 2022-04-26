using System;
using System.IO;
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
            string puzzle1 = AppDomain.CurrentDomain.BaseDirectory + "puzzle1";

        }

        private string ReadFile(string puzzle)
        {
            string line;
            string fullFile;

            try
            {
                if (File.Exists(puzzle))
                {
                    using (StreamReader sr = new StreamReader(puzzle))
                    {
                        while (sr.Peek() > -1)
                        {
                            line = sr.ReadLine();
                        }
                    }


                    return "";
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
