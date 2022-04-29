using System;
using System.Diagnostics;

namespace Sudoku
{
    class Board
    {
        public char[,] board;

        public Board(char[,] boardText)
        {
            board = boardText;
        }

        public bool Solve(char[,] board)
        {
            //loop through individual cells to find empty
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 'X') //if empty
                    {
                        for (char num = '1'; num <= '9'; num++) //loop through possible entries
                        {
                            if (IsValid(board, i, j, num)) //check if entry is valid
                            {
                                board[i, j] = num;//set cell to valid entry 
                                
                                if (Solve(board))//recurses until true, because if not true, there was a contradiction on board and cell needs to be set back to empty
                                {
                                    return true;
                                }
                                else
                                {
                                    board[i, j] = 'X';//set back to empty because found contradiction
                                }
                            }
                        }
                        return false; //found contradiction on board
                    }
                }
            }
            return true; //no more empty or contradictory cells
        }

        //confirm valid number placement by checking 3x3 cell, row, and column
        static bool IsValid(char[,] board, int row, int col, char value)
        {

            //confirm number not in 3x3 cell
            if (InQuadrant(board, GetQuadrant(row, col), value))
            {
                return false;
            }

            for (int i = 0; i < 9; i++)
            {                
                //confirm number not in row
                if (board[i, col] != 'X' && board[i, col] == value)
                {
                    return false;
                }
                //confirm number not in column
                if (board[row, i] != 'X' && board[row, i] == value)
                {
                    return false;
                }
            }
            return true;
        }

        //get the 3x3 quadrant an entry is in by checking it's coordinate
        /*
         *   1 | 2 | 3
         *   _________
         *   4 | 5 | 6
         *   _________
         *   7 | 8 | 9
         */
        private static int GetQuadrant(int x, int y)
        {
            int quad = 0;

            if (x < 3)
            {
                if (y < 3)
                {
                    quad = 1;
                }
                if (3 <= y && y < 6)
                {
                    quad = 2;
                }
                if (y >= 6)
                {
                    quad = 3;
                }   
            }
            if (3 <= x && x < 6)
            {
                if (y < 3)
                {
                    quad = 4;
                }
                if (3 <= y && y < 6)
                {
                    quad = 5;
                }
                if (y >= 6)
                {
                    quad = 6;
                }
            }
            if (x >= 6)
            {
                if (y < 3)
                {
                    quad = 7;
                }
                if (3 <= y && y < 6)
                {
                    quad = 8;
                }
                if (y >= 6)
                {
                    quad = 9;
                }
            }
            return quad;
        }

        //boolean returning true if a value is in a quadrant
        private static bool InQuadrant(char[,] grid, int quad, char value)
        {
            switch (quad)
            {
                case 1:
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            if (grid[x, y] == value)
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                case 2:
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 3; y < 6; y++)
                        {
                            if (grid[x, y] == value)
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                case 3:
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 6; y < 9; y++)
                        {
                            if (grid[x, y] == value)
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                case 4:
                    for (int x = 3; x < 6; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            if (grid[x, y] == value)
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                case 5:
                    for (int x = 3; x < 6; x++)
                    {
                        for (int y = 3; y < 6; y++)
                        {
                            if (grid[x, y] == value)
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                case 6:
                    for (int x = 3; x < 6; x++)
                    {
                        for (int y = 6; y < 9; y++)
                        {
                            if (grid[x, y] == value)
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                case 7:
                    for (int x = 6; x < 9; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            if (grid[x, y] == value)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                                                 
                case 8:
                    for (int x = 6; x < 9; x++)
                    {
                        for (int y = 3; y < 6; y++)
                        {
                            if (grid[x, y] == value)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                
                case 9:
                    for (int x = 6; x < 9; x++)
                    {
                        for (int y = 6; y < 9; y++)
                        {
                            if (grid[x, y] == value)
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                default:
                    return false;
            }
        }
    }
}
