using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Sudoku
{
    class Board
    {
        public char[,] board;

        public Board(char[,] boardText)
        {
            board = boardText;
        }

        private char[,] Solve(char[,] board)
        {
            char[,] decoy = new char[,] { { 'a', 'a' } };

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                }
            }
        }

        static bool In3by3(char[,] board, int row, int col, char cell)
        {
            bool exists = false;
            for (int i = 0; i < 9; i++)
            {
                if (board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != 'X' && board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == cell)
                {
                    exists = true;
                }
                else exists = false;
            }
            return exists;
        }
    }
}
