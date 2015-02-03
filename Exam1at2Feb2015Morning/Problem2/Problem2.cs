using System;
using System.Numerics;

class Problem2
{
    static void Main()
    {
        BigInteger M = BigInteger.Parse(Console.ReadLine());
        string text = Console.ReadLine().ToUpper();

        BigInteger result = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '@')
            {
                break;
            }
            else if (char.IsDigit(text[i]))
            {
                result *= text[i] - '0';
            }
            else if(char.IsLetter(text[i]))
            {
                result += text[i] - 'A';
            }
            else
            {
                result %= M;
            }
        }
        Console.WriteLine(result);
    }
}