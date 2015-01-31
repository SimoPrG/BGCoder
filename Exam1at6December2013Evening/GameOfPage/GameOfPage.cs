using System;

class GameOfPage
{
    static void Main()
    {
        int[,] bigTray = new int[18, 18];
        decimal sum = 0m;
        decimal cookiePrice = 1.79m;

        for (int row = 0; row < 18; row++)
        {
            for (int col = 0; col < 18; col++)
            {
                bigTray[row, col] = 0;
            }
        }

        //reading the tray
        for (int row = 1; row < 17; row++)
        {
            string line = Console.ReadLine();
            for (int col = 1; col < 17; col++)
            {
                bigTray[row, col] = line[col - 1] - '0';
            }
        }

        ////Printing the tray
        //Console.WriteLine();
        //for (int row = 0; row < 18; row++)
        //{
        //    for (int col = 0; col < 18; col++)
        //    {
        //        Console.Write(bigTray[row, col]);
        //    }
        //    Console.WriteLine();
        //}

        while (true)
        {
            string question = Console.ReadLine();
            if (question == "what is" || question == "buy")
            {
                int row = int.Parse(Console.ReadLine()) + 1;
                int col = int.Parse(Console.ReadLine()) + 1;

                if (question == "what is")
                {
                    if (bigTray[row, col] == 0)
                    {
                        Console.WriteLine("smile"); //TODO: check around for 1-s
                    }
                    else //tray[row, col] == 1
                    {
                        bool cookie = true;

                        for (int i = row - 1; i <= row + 1; i++)
                        {
                            for (int j = col - 1; j <= col +1; j++)
                            {
                                if (bigTray[i, j] == 0)
                                {
                                    cookie = false;
                                }
                            }
                        }

                        if (cookie)
                        {
                            Console.WriteLine("cookie");
                        }
                        else //cookie crumb or broken cookie
                        {
                            bool cookieCrumb = true;

                            for (int i = row - 1; i <= row + 1; i++)
                            {
                                for (int j = col - 1; j <= col + 1; j++)
                                {
                                    if (i == row && j == col)
                                    {
                                        continue;
                                    }
                                    if (bigTray[i, j] != 0)
                                    {
                                        cookieCrumb = false;
                                    }
                                }
                            }

                            if (cookieCrumb)
                            {
                                Console.WriteLine("cookie crumb");
                            }
                            else
                            {
                                Console.WriteLine("broken cookie");
                            }
                        }
                    }
                }
                else // question == "buy"
                {
                    if (bigTray[row, col] == 0)
                    {
                        Console.WriteLine("smile"); //TODO: check around for 1-s
                    }
                    else //tray[row, col] == 1
                    {
                        bool cookie = true;

                        for (int i = row - 1; i <= row + 1; i++)
                        {
                            for (int j = col - 1; j <= col + 1; j++)
                            {
                                if (bigTray[i, j] == 0)
                                {
                                    cookie = false;
                                }
                            }
                        }

                        if (cookie)
                        {
                            sum += cookiePrice;

                            for (int i = row - 1; i <= row + 1; i++)
                            {
                                for (int j = col - 1; j <= col + 1; j++)
                                {
                                    bigTray[i, j] = 0;
                                }
                            }

                        }
                        else //cookie crumb or broken cookie
                        {
                            Console.WriteLine("page");
                        }
                    }
                }
            }
            else //paypal
            {
                Console.WriteLine("{0:F2}", sum);
                break;
            }
        }
    }
}