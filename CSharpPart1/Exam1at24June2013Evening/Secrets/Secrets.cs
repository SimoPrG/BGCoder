using System;
using System.Numerics;
class Secrets
{
    static void Main()
    {
        string input = Console.ReadLine();
        BigInteger N = BigInteger.Parse(input);
        BigInteger M = 0;
        if (N < 0)
        {
            M = -N;
        }
        else
        {
            M = N;
        }

        BigInteger specialSum = 0;

        for (int i = 1; i <= input.Length; i++)
        {
            if (i % 2 == 0)
            {
                specialSum += (M % 10) * (M % 10) * i;
            }
            else
            {
                specialSum += (M % 10) * i * i;
            }
            M /= 10;
        }

        int alphaSequenceLenght = (int)(specialSum % 10);

        if (alphaSequenceLenght == 0)
        {
            Console.WriteLine(specialSum);
            Console.WriteLine("{0} has no secret alpha-sequence", N);
        }
        else
        {
            int R = (int)(specialSum % 26);
            char[] secretAlphaSequence = new char[alphaSequenceLenght];

            for (int i = 0; i < alphaSequenceLenght; i++)
            {
                secretAlphaSequence[i] = (char)('A' + (R + i) % 26);
            }

            Console.WriteLine(specialSum);
            Console.WriteLine(new string(secretAlphaSequence));
        }
    }
}