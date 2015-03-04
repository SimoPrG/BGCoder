using System;

class Bittris
{
    static void Main()
    {
        byte[] field = new byte[4];
        uint pieceUint = 0;
        byte pieceByte = 0;
        int points = 0;
        int pointSum = 0;
        bool gameOver = false;
        bool stuck = false;
        int currentRow = 0;

        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            if (gameOver)
            {
                continue;
            }
            if (uint.TryParse(input, out pieceUint))
            {
                points = Points(pieceUint);
                pieceByte = (byte)pieceUint;
                currentRow = 0;
                stuck = false;
            }
            else
            {
                if (stuck)
                {
                    continue;
                }
                if (input == "D")
                {

                    if ((field[currentRow + 1] & pieceByte) == 0)
                    {
                        currentRow++;
                        if (currentRow == 3)
                        {
                            stuck = true;
                            field[currentRow] |= pieceByte;
                            if (field[currentRow] == 255)
                            {
                                for (int j = currentRow; j > 0; j--)
                                {
                                    field[j] = field[j - 1];
                                }
                                field[0] = 0;
                                pointSum += points * 10;
                            }
                            else
                            {
                                pointSum += points;
                            }
                        }
                    }
                    else
                    {
                        stuck = true;
                        field[currentRow] |= pieceByte;
                        if (field[currentRow] == 255)
                        {
                            for (int j = currentRow; j > 0; j--)
                            {
                                field[j] = field[j - 1];
                            }
                            field[0] = 0;
                            pointSum += points * 10;
                        }
                        else
                        {
                            pointSum += points;
                        }
                        if (field[0] != 0)
                        {
                            gameOver = true;
                        }
                        // If we stuck on row 0 gameover
                    }

                }

                if (input == "L")
                {
                    if (((pieceByte & 128) == 0) && ((pieceByte << 1) & field[currentRow]) == 0)
                    {
                        pieceByte = (byte)(pieceByte << 1);
                    }
                    //go down
                    if ((field[currentRow + 1] & pieceByte) == 0)
                    {
                        currentRow++;
                        if (currentRow == 3)
                        {
                            stuck = true;
                            field[currentRow] |= pieceByte;
                            if (field[currentRow] == 255)
                            {
                                for (int j = currentRow; j > 0; j--)
                                {
                                    field[j] = field[j - 1];
                                }
                                field[0] = 0;
                                pointSum += points * 10;
                            }
                            else
                            {
                                pointSum += points;
                            }
                        }
                    }
                    else
                    {
                        stuck = true;
                        field[currentRow] |= pieceByte;
                        if (field[currentRow] == 255)
                        {
                            for (int j = currentRow; j > 0; j--)
                            {
                                field[j] = field[j - 1];
                            }
                            field[0] = 0;
                            pointSum += points * 10;
                        }
                        else
                        {
                            pointSum += points;
                        }
                        if (field[0] != 0)
                        {
                            gameOver = true;
                        }
                        // If we stuck on row 0 gameover
                    }
                }

                if (input == "R")
                {
                    if (((pieceByte & 1) == 0) && ((pieceByte >> 1) & field[currentRow]) == 0)
                    {
                        pieceByte = (byte)(pieceByte >> 1);
                    }
                    //go down
                    if ((field[currentRow + 1] & pieceByte) == 0)
                    {
                        currentRow++;
                        if (currentRow == 3)
                        {
                            stuck = true;
                            field[currentRow] |= pieceByte;
                            if (field[currentRow] == 255)
                            {
                                for (int j = currentRow; j > 0; j--)
                                {
                                    field[j] = field[j - 1];
                                }
                                field[0] = 0;
                                pointSum += points * 10;
                            }
                            else
                            {
                                pointSum += points;
                            }
                        }
                    }
                    else
                    {
                        stuck = true;
                        field[currentRow] |= pieceByte;
                        if (field[currentRow] == 255)
                        {
                            for (int j = currentRow; j > 0; j--)
                            {
                                field[j] = field[j - 1];
                            }
                            field[0] = 0;
                            pointSum += points * 10;
                        }
                        else
                        {
                            pointSum += points;
                        }
                        if (field[0] != 0)
                        {
                            gameOver = true;
                        }
                        // If we stuck on row 0 gameover
                    }
                }
            }
        }
        Console.WriteLine(pointSum);
    }
    static int Points(uint piece)
    {
        int points = 0;
        for (int i = 0; i < 32; i++)
        {
            if (((piece >> i) & 1) == 1)
            {
                points++;
            }
        }
        return points;
    }
}