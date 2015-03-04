using System;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        long sum = 0;
        long amount = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (i % 2 == 1)
            {
                if ((text[i] >= '0') && (text[i] <= '9'))
                {
                    amount++;
                    sum += text[i] - '0';
                }
            }
        }
        Console.WriteLine("{0} {1}", amount, sum);
    }
}