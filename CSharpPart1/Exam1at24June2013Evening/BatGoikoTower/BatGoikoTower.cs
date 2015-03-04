using System;

class BatGoikoTower
{
    static void Main()
    {
        int H = int.Parse(Console.ReadLine());
        string[] tower = new string[H];
        for (int i = 0; i < H; i++)
        {
            tower[i] = new string('.', 2 * H);
        }

        for (int row = 0; row < H; row++)
        {
            int cow = H - 1 - row;
            char[] array = tower[row].ToCharArray();
            array[cow] = '/';
            tower[row] = new string(array);
        }

        for (int row = 0; row < H; row++)
        {
            int cow = row + H;
            char[] array = tower[row].ToCharArray();
            array[cow] = '\\';
            tower[row] = new string(array);
        }

        for (int row = 1, i = 1; row < H; i++, row = row + i)
        {
            for (int cow = H - row; cow < H + row; cow++)
            {
                char[] array = tower[row].ToCharArray();
                array[cow] = '-';
                tower[row] = new string(array);
            }

        }

        foreach (string line in tower)
        {
            Console.WriteLine(line);
        }
    }
}