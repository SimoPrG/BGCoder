using System;

class Problem5
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string binaryConcatenated = null;

        for (int i = 0; i < N; i++)
        {
            string binary = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(32, '0').Remove(0, 2); //try long
            binaryConcatenated += binary;
        }

        int longestSequenceZeroes = 0;
        int longestSequenceOnes = 0;
        int sequenceOnes = 0;
        int sequenceZeroes = 0;
        for (int i = 0; i < binaryConcatenated.Length; i++)
        {
            if (binaryConcatenated[i] == '0')
            {
                sequenceZeroes++;
                sequenceOnes = 0;
            }
            else // '1'
            {
                sequenceOnes++;
                sequenceZeroes = 0;
            }

            if (sequenceZeroes > longestSequenceZeroes)
            {
                longestSequenceZeroes = sequenceZeroes;
            }

            if (sequenceOnes > longestSequenceOnes)
            {
                longestSequenceOnes = sequenceOnes;
            }
        }

        Console.WriteLine(longestSequenceZeroes);
        Console.WriteLine(longestSequenceOnes);
    }
}