using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FeaturingWithGrisko
{
    static void Main(string[] args)
    {

        int c = 0;

        var input = Console.ReadLine().ToCharArray();

        Array.Sort(input);

        Check(ref c, input);

        while (NextPermutation(input))
        {
            Check(ref c, input);
        }

        Console.WriteLine(c);
    }

    private static bool NextPermutation(char[] charList)
    {
        /*
         Knuths
         1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
         2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
         3. Swap a[j] with a[l].
         4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

         */
        var largestIndex = -1;
        for (var i = charList.Length - 2; i >= 0; i--)
        {
            if (charList[i] < charList[i + 1])
            {
                largestIndex = i;
                break;
            }
        }

        if (largestIndex < 0) return false;

        var largestIndex2 = -1;
        for (var i = charList.Length - 1; i >= 0; i--)
        {
            if (charList[largestIndex] < charList[i])
            {
                largestIndex2 = i;
                break;
            }
        }

        var tmp = charList[largestIndex];
        charList[largestIndex] = charList[largestIndex2];
        charList[largestIndex2] = tmp;

        for (int i = largestIndex + 1, j = charList.Length - 1; i < j; i++, j--)
        {
            tmp = charList[i];
            charList[i] = charList[j];
            charList[j] = tmp;
        }

        return true;
    }

    private static void Check(ref int c, char[] input)
    {
        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                return;
            }
        }

        c++;
    }
}