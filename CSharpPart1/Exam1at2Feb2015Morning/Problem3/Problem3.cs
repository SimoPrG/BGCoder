using System;
using System.Numerics;

class Problem3
{
    static void Main()
    {
        string input = Console.ReadLine();
        BigInteger number = BigInteger.Parse(input);
        long sumAtEvenPositions = 0;
        BigInteger products = 1;
        BigInteger newNumber = 0;
        long inputLength = input.Length;
        long transformations = 0;


        do
        {
            for (int i = 0; i < inputLength; i++)
            {
                input = input.Remove(input.Length - 1);
                for (int j = 0; j < input.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        sumAtEvenPositions += input[j] - '0';
                    }
                }
                if (input != "")
                    products *= sumAtEvenPositions;
                sumAtEvenPositions = 0;
            }
            newNumber = products;
            products = 1;
            input = newNumber.ToString();
            inputLength = input.Length;
            transformations++;
            if (transformations == 10)
            {
                break;
            }
        } while (newNumber / 10 != 0);

        if (transformations == 10)
        {
            Console.WriteLine(newNumber);
        }
        else
        {
            Console.WriteLine(transformations);
            Console.WriteLine(newNumber);
        }

    }
}