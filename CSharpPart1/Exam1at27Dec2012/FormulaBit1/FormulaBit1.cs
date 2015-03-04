using System;

class FormulaBit1
{
    static void Main()
    {
        byte[] grid = new byte[8];
        bool prematureEnd = false;

        byte carRow = 0; //start coordinates
        byte carCol = 7;

        byte carDirection = 0; // 0 - South, 1 - West, 2 - North, 3 - West

        byte trackLenght = 0;
        byte trackTurns = 0;

        // Reading the grid
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = byte.Parse(Console.ReadLine());
        }

        //// Printing the grid
        //Console.WriteLine();
        //for (int i = 0; i < grid.Length; i++)
        //{
        //    Console.WriteLine(Convert.ToString(grid[i], 2).PadLeft(8, '0'));
        //}

        while (!prematureEnd)
        {
            if (carRow == 7 && carCol == 0) // track end
            {
                trackLenght++;
                break;
            }

            if (((grid[carRow] >> (7 - carCol)) & 1) == 1) // track start is 1 case
            {
                prematureEnd = true;
            }
            else //on the track
            {
                trackLenght++;
                switch (carDirection)
                {
                    case 0://south
                        if (carRow > 6 || ((grid[carRow + 1] >> (7 - carCol)) & 1) == 1) // cant go south
                        {
                            //check if we can go west
                            if (carCol < 1 || ((grid[carRow] >> (8 - carCol)) & 1) == 1) //cant go west
                            {
                                prematureEnd = true;
                            }
                            else //turn west
                            {
                                carCol--;
                                carDirection = 1;
                                trackTurns++;
                            }
                        }
                        else // continue south
                        {
                            carRow++;
                        }
                        break;

                    case 1://west
                        if (carCol < 1 || ((grid[carRow] >> (8 - carCol)) & 1) == 1) //cant go west
                        {
                            //check if we can go north
                            if (carRow < 1 || ((grid[carRow - 1] >> (7 - carCol)) & 1) == 1) //cant go north
                            {
                                prematureEnd = true;
                            }
                            else //turn north
                            {
                                carRow--;
                                carDirection = 2;
                                trackTurns++;
                            }
                        }
                        else // continue west
                        {
                            carCol--;
                        }
                        break;

                    case 2://north
                        if (carRow < 1 || ((grid[carRow - 1] >> (7 - carCol)) & 1) == 1) //cant go north
                        {
                            //check if we can go west
                            if (carCol < 1 || ((grid[carRow] >> (8 - carCol)) & 1) == 1) //cant go west
                            {
                                prematureEnd = true;
                            }
                            else //turn west
                            {
                                carCol--;
                                carDirection = 3;
                                trackTurns++;
                            }
                        }
                        else //countinue north
                        {
                            carRow--;
                        }
                        break;

                    case 3://west
                        if (carCol < 1 || ((grid[carRow] >> (8 - carCol)) & 1) == 1) //cant go west
                        {
                            //check if we can go south
                            if (carRow > 6 || ((grid[carRow + 1] >> (7 - carCol)) & 1) == 1) // cant go south
                            {
                                prematureEnd = true;
                            }
                            else //turn south
                            {
                                carRow++;
                                carDirection = 0;
                                trackTurns++;
                            }
                        }
                        else // continue west
                        {
                            carCol--;
                        }
                        break;
                }
            }
        }

        if (prematureEnd)
        {
            Console.WriteLine("No {0}", trackLenght);
        }
        else
        {
            Console.WriteLine("{0} {1}", trackLenght, trackTurns);
        }
    }
}