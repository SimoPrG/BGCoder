/* N = 8
       ::::::::
      ://////::
     ://////:X:
    ://////:XX:
   ://////:XXX:
  ://////:XXXX:
 ://////:XXXXX:
::::::::XXXXXX:
:      :XXXXX: 
:      :XXXX:  
:      :XXX:   
:      :XX:    
:      :X:     
:      ::      
::::::::       

*/

using System;

class Problem4
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int pictureSize = 2 * N - 1;
        string[] cube = new string[pictureSize];

        for (int i = 0; i < pictureSize; i++)
        {
            cube[i] = new string(' ', pictureSize);
        }

        char[] topEdge = cube[0].ToCharArray();
        for (int i = N - 1; i < pictureSize; i++)
        {
            topEdge[i] = ':';
        }
        cube[0] = new string(topEdge);

        char[] middleEdge = cube[N - 1].ToCharArray();
        char[] lowerEdge = cube[pictureSize - 1].ToCharArray();
        for (int i = 0; i < N; i++)
        {
            char[] array = cube[i].ToCharArray();
            array[pictureSize - 1] = ':';
            cube[i] = new string(array);
            middleEdge[i] = ':';
            lowerEdge[i] = ':';
        }
        cube[N - 1] = new string(middleEdge);
        cube[pictureSize - 1] = new string(lowerEdge);

        for (int i = N - 1; i < pictureSize; i++)
        {
            char[] array = cube[i].ToCharArray();
            array[0] = ':';
            array[N - 1] = ':';
            cube[i] = new string(array);
        }

        for (int i = 0; i < N; i++)
        {
            char[] array = cube[i].ToCharArray();
            array[N - 1 - i] = ':';
            array[pictureSize - 1 - i] = ':';
            cube[i] = new string(array);
        }

        for (int i = 0; i < N; i++)
        {
            char[] array = cube[i + N -1].ToCharArray();
            array[pictureSize - 1 - i] = ':';
            cube[i + N - 1] = new string(array);
        }

        // painting

        for (int i = 1; i < N - 1; i++)
        {
            char[] array = cube[i].ToCharArray();
            for (int j = N-i; j < N-i+N-2; j++)
            {
                array[j] = '/';
            }
            cube[i] = new string(array);
        }

        for (int i = 2; i < N; i++)
        {
            char[] array = cube[i].ToCharArray();
            for (int j = 1; j < i; j++)
            {
                array[pictureSize-1-j] = 'X'; //
            }
            cube[i] = new string(array);
        }

        for (int i = 1; i <= N - 2; i++)
        {
            char[] array = cube[pictureSize - 2 - i].ToCharArray();
            for (int j = 0; j < i; j++)
            {
                array[N + j] = 'X';
            }
            cube[pictureSize - 2 - i] = new string(array);
        }


        //printing
        for (int i = 0; i < pictureSize; i++)
        {
            Console.WriteLine(cube[i]);
        }
    }
}