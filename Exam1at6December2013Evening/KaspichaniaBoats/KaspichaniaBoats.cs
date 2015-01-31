using System;

class KaspichaniaBoats
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int width = 2 * N + 1;
        int height = 6 + ((N - 3) / 2) * 3;


        string[] picture = new string[height];

        for (int i = 0; i < height; i++)
        {
            picture[i] = new string('.', width);
        }

        for (int i = N - 1; i >= 0; i--)
        {
            char[] line = picture[i].ToCharArray();
            line[N - i] = '*';
            line[N] = '*';
            line[N + i] = '*';
            picture[i] = new string(line);
        }

        picture[N] = new string('*', 2 * N + 1);

        for (int i = N; i < 6 + ((N - 3) / 2) * 3; i++)
        {
            char[] line = picture[i].ToCharArray();
            line[i - N] = '*';
            line[N] = '*';
            line[3 * N - i] = '*';
            picture[i] = new string(line);
        }

        char[] bottom = picture[height - 1].ToCharArray();
        for (int i = (width - N) / 2; i < Math.Ceiling((width - N) / 2.0 + N); i++)
        {
            bottom[i] = '*';
        }
        picture[height - 1] = new string(bottom);

        for (int i = 0; i < 6 + ((N - 3) / 2) * 3; i++)
        {
            Console.WriteLine(picture[i]);
        }
    }
}