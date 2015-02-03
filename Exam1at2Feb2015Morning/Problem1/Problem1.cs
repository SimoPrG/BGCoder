using System;

class Problem1
{
    static void Main()
    {
        long students = long.Parse(Console.ReadLine());
        long sheetsPerStudent = long.Parse(Console.ReadLine());
        decimal realPrice = decimal.Parse(Console.ReadLine());

        Console.WriteLine("{0:F2}", ((students * sheetsPerStudent) / 500m) * realPrice);
    }
}