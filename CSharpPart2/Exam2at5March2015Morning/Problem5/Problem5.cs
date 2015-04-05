using System;
using System.Numerics;
using System.Text;

class Problem5
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        BigInteger sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            sum += OtherToDecimal(input[i], 19);
        }

        Console.WriteLine("{0} = {1}", DecimalToOther(sum, 19), sum);
    }

    static BigInteger OtherToDecimal(string other, int system)
    {
        BigInteger sum = 0;
        for (int i = 0; i < other.Length; i++)
        {
                switch (other[i])
                {
                    case 'a': sum += 0 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'b': sum += 1 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'c': sum += 2 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'd': sum += 3 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'e': sum += 4 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'f': sum += 5 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'g': sum += 6 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'h': sum += 7 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'i': sum += 8 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'j': sum += 9 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'k': sum += 10 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'l': sum += 11 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'm': sum += 12 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'n': sum += 13 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'o': sum += 14 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'p': sum += 15 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'q': sum += 16 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 'r': sum += 17 * (long)Math.Pow(system, other.Length - 1 - i); break;
                    case 's': sum += 18 * (long)Math.Pow(system, other.Length - 1 - i); break;
                }
        }

        return sum;
    }

    static string DecimalToOther(BigInteger nineteen, int system)
    {
        StringBuilder otherInverted = new StringBuilder();
        do
        {
            switch ((int)(nineteen % system))
            {
                case 0: otherInverted.Append('a'); break;
                case 1: otherInverted.Append('b'); break;
                case 2: otherInverted.Append('c'); break;
                case 3: otherInverted.Append('d'); break;
                case 4: otherInverted.Append('e'); break;
                case 5: otherInverted.Append('f'); break;
                case 6: otherInverted.Append('g'); break;
                case 7: otherInverted.Append('h'); break;
                case 8: otherInverted.Append('i'); break;
                case 9: otherInverted.Append('j'); break;
                case 10: otherInverted.Append('k'); break;
                case 11: otherInverted.Append('l'); break;
                case 12: otherInverted.Append('m'); break;
                case 13: otherInverted.Append('n'); break;
                case 14: otherInverted.Append('o'); break;
                case 15: otherInverted.Append('p'); break;
                case 16: otherInverted.Append('q'); break;
                case 17: otherInverted.Append('r'); break;
                case 18: otherInverted.Append('s'); break;
            }
            nineteen /= system;
        } while (nineteen != 0);

        char[] other = new char[otherInverted.Length];
        for (int i = 0; i < other.Length; i++)
        {
            other[i] = otherInverted[other.Length - 1 - i];
        }
        return new string(other);
    }
}