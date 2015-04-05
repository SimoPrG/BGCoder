//from: 

using System;
using System.Numerics;

class Problem3
{
    static void Main()
    {
        int[] rowsCols = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int[,] board = new int[rowsCols[0], rowsCols[1]];

        for (int row = board.GetLength(0) - 1, value = 0; row >= 0; row--)
        {
            board[row, 0] = value;
            value += 3;
        }
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 1; col < board.GetLength(1); col++)
            {
                board[row, col] = board[row, col - 1] + 3;
            }
        }

        int N = int.Parse(Console.ReadLine());

        int bishopRow = board.GetLength(0) - 1;
        int bishopCol = 0;
        BigInteger sum = 0;

        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int moves = int.Parse(input[1]);

            if (input[0] == "LU" || input[0] == "UL")
            {
                while (bishopRow - 1 >= 0 && bishopCol - 1 >= 0 && --moves > 0)
                {
                    sum += board[bishopRow, bishopCol];
                    board[bishopRow, bishopCol] = 0;
                    bishopRow--;
                    bishopCol--;
                }
            }
            else if (input[0] == "RU" || input[0] == "UR")
            {
                while (bishopRow - 1 >= 0 && bishopCol + 1 < board.GetLength(1) && --moves > 0)
                {
                    sum += board[bishopRow, bishopCol];
                    board[bishopRow, bishopCol] = 0;
                    bishopRow--;
                    bishopCol++;
                }
            }
            else if (input[0] == "LD" || input[0] == "DL")
            {
                while (bishopRow + 1 < board.GetLength(0) && bishopCol - 1 >= 0 && --moves > 0)
                {
                    sum += board[bishopRow, bishopCol];
                    board[bishopRow, bishopCol] = 0;
                    bishopRow++;
                    bishopCol--;
                }
            }
            else if (input[0] == "RD" || input[0] == "DR")
            {
                while (bishopRow + 1 < board.GetLength(0) && bishopCol + 1 < board.GetLength(1) && --moves > 0)
                {
                    sum += board[bishopRow, bishopCol];
                    board[bishopRow, bishopCol] = 0;
                    bishopRow++;
                    bishopCol++;
                }
            }
        }

        sum += board[bishopRow, bishopCol];

        Console.WriteLine(sum);
    }
}