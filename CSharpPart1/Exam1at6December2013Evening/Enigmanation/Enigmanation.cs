using System;

class Enigmanation
{
    static void Main()
    {
        string input = Console.ReadLine();
        decimal sum = 0m;
        char lastOperator = '+';
        bool inBrackets = false;
        char inBracketsLastOperator = '+';
        decimal inBracketsSum = 0m;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                inBrackets = true;
                continue;
            }

            if (char.IsDigit(input[i]) && inBrackets == false)
            {
                switch (lastOperator)
                {
                    case '+': sum += input[i] - '0'; break;
                    case '-': sum -= input[i] - '0'; break;
                    case '*': sum *= input[i] - '0'; break;
                    case '%': sum %= input[i] - '0'; break;
                }
                continue;
            }

            if (char.IsDigit(input[i]) && inBrackets == true)
            {
                switch (inBracketsLastOperator)
                {
                    case '+': inBracketsSum += input[i] - '0'; break;
                    case '-': inBracketsSum -= input[i] - '0'; break;
                    case '*': inBracketsSum *= input[i] - '0'; break;
                    case '%': inBracketsSum %= input[i] - '0'; break;
                }
                continue;
            }

            if (input[i] == '+')
            {
                if (inBrackets)
                {
                    inBracketsLastOperator = '+';
                }
                else
                {
                    lastOperator = '+';
                }
                continue;
            }
            if (input[i] == '-')
            {
                if (inBrackets)
                {
                    inBracketsLastOperator = '-';
                }
                else
                {
                    lastOperator = '-';
                }
                continue;
            }
            if (input[i] == '*')
            {
                if (inBrackets)
                {
                    inBracketsLastOperator = '*';
                }
                else
                {
                    lastOperator = '*';
                }
                continue;
            }
            if (input[i] == '%')
            {
                if (inBrackets)
                {
                    inBracketsLastOperator = '%';
                }
                else
                {
                    lastOperator = '%';
                }
                continue;
            }

            if (input[i] == ')')
            {
                switch (lastOperator)
                {
                    case '+': sum += inBracketsSum; break;
                    case '-': sum -= inBracketsSum; break;
                    case '*': sum *= inBracketsSum; break;
                    case '%': sum %= inBracketsSum; break;
                }
                inBrackets = false;
                inBracketsLastOperator = '+';
                inBracketsSum = 0m;
            }
        }

        Console.WriteLine("{0:F3}", sum);
    }
}