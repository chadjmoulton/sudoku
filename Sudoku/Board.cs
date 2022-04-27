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
            //defaults to decoy if no valid board
            char[,] decoy = new char[,] { { 'a', 'a' } };

            //loop through individual cells to find empty
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 'X') //if empty
                    {
                        for (char num = '1'; num <= '9'; num++) //loop through possible entries
                        {
                            if (IsCorrect(board, i, j, num)) //check if entry is valid
                            {
                                board[i, j] = num;
                            }
                        }
                    }
                }
            }
        }

        //confirm valid number placement by checking 3x3 cell, row, and column
        static bool IsCorrect(char[,] board, int row, int col, char num)
        {
            bool correct = true;

            for (int i = 0; i < 9; i++)
            {
                //confirm number not in 3x3 cell
                if (board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != 'X' && board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == num)
                {
                    correct = false;
                }
                //confirm number not in row
                if (board[i, col] != 'X' && board[i, col] == num)
                {
                    correct = false;
                }
                //confirm number not in column
                if (board[row, i] != 'X' && board[row, i] == num)
                {
                    correct = false;
                }
                else correct = true;
            }
            return correct;
        }
    }
}
