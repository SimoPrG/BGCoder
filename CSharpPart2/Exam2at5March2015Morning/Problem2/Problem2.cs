using System;
using System.Numerics;

class Problem2
{
    static void Main()
    {
        BigInteger[] input = Array.ConvertAll(Console.ReadLine().Split(' '), BigInteger.Parse);

        int index = 1;
        BigInteger sum = 0;

        while (index < input.Length)
        {
            BigInteger abs = (input[index] - input[index - 1]) < 0 ? (input[index - 1] - input[index]) : (input[index] - input[index - 1]);

            if (abs % 2 == 0)
            {
                index += 2;
            }
            else
            {
                index++;
                sum += abs;
            }
        }

        Console.WriteLine(sum);
    }
}