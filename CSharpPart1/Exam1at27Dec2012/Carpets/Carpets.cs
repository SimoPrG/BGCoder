//    ../\..   N = 6
//    ./  \.
//    / /\ \
//    \ \/ /
//    .\  /.
//    ..\/..


using System;

class Carpets
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        string topLeft = "";
        string topRight = "";

        for (int i = 0; i < N / 2; i++)
        {
            Console.Write(new string('.', N / 2 - 1 - i));

            if (i % 2 == 0)
            {
                topLeft += '/';
                topRight = topRight.PadLeft(i + 1, '\\');
            }
            else
            {
                topLeft += ' ';
                topRight = topRight.PadLeft(i + 1, ' ');
            }
            Console.Write(topLeft);
            Console.Write(topRight);

            Console.Write(new string('.', N / 2 - 1 - i));


            Console.WriteLine();
        }

        string bottomRight = "";
        string bottomLeft = "";
        for (int i = 0; i < N / 2; i++)
        {
            if (i % 2 == 0)
            {
                bottomLeft += '\\';
                bottomRight = bottomRight.PadLeft(i + 1, '/');
            }
            else
            {
                bottomLeft += ' ';
                bottomRight = bottomRight.PadLeft(i + 1, ' ');
            }
        }

        for (int i = 0; i < N / 2; i++)
        {
            Console.Write(new string('.', i));
            Console.Write(bottomLeft);
            Console.Write(bottomRight);
            Console.Write(new string('.', i));

            bottomLeft = bottomLeft.Remove(bottomLeft.Length - 1);
            bottomRight = bottomRight.Remove(0, 1);

            Console.WriteLine();
        }
    }
}