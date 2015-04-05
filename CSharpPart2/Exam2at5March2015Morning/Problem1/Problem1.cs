using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Problem1
{
    static void Main()
    {
        StringBuilder result = new StringBuilder();

        int N = int.Parse(Console.ReadLine());

        var list = new List<string>();

        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            if (input.IndexOf('b') > 0) //is before
            {
                string currentString = new string (new char[] { input[0], input[input.Length - 1] });
                list.Add(currentString);
            }
            else //is after - switch
            {
                string currentString = new string (new char[] { input[input.Length - 1], input[0] });
                list.Add(currentString);
            }
        }

        var uniqueList = new List<string>(list.Distinct());

        var sortedList = uniqueList.OrderBy(x => x[0]).ThenBy(x => x[1]);

        foreach (var str in sortedList)
        {
            if (IndexOfChar(result, str[0]) < 0)
            {
                if (IndexOfChar(result, str[1]) >= 0)
                {
                    if (IndexOfChar(result, '0') < 0)
                    {
                        result.Insert(IndexOfChar(result, str[1]), str[0]);
                    }
                    else
                    {
                        result.Insert(0, str[0]);
                    }
                    
                }
                else
                {
                    result.Append(str[0]);
                }
            }

            if (IndexOfChar(result, str[1]) < 0)
            {
                //result.Append(str[1]);
                SecondTraverse(result, str[0], str[1]);
            }
        }

        if (result[0] == '0')
        {
            char temp = result[0];
            result[0] = result[1];
            result[1] = temp;
        }

        Console.WriteLine(result);
    }

    static int IndexOfChar(StringBuilder builder, char c)
    {
        for (int i = 0; i < builder.Length; i++)
        {
            if (c == builder[i])
            {
                return i;
            }
        }
        return -1;
    }

    static void SecondTraverse(StringBuilder builder, char referenceChar, char c)
    {
        int i = builder.Length - 1;
        while (builder[i] != referenceChar && c < builder[i])
        {
            i--;
        }

        if (i + 1 < builder.Length)
        {
            builder.Insert(i + 1, c);
        }
        else
        {
            builder.Append(c);
        }
    }
}