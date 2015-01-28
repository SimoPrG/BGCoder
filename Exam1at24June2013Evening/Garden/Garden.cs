using System;

class Garden
{
    static void Main()
    {
        decimal tomatoSeedAmount = decimal.Parse(Console.ReadLine());
        decimal tomatoArea = decimal.Parse(Console.ReadLine());
        decimal cucumberSeedAmount = decimal.Parse(Console.ReadLine());
        decimal cucumberArea = decimal.Parse(Console.ReadLine());
        decimal potatoSeedAmount = decimal.Parse(Console.ReadLine());
        decimal potatoArea = decimal.Parse(Console.ReadLine());
        decimal carrotSeedAmount = decimal.Parse(Console.ReadLine());
        decimal carrotArea = decimal.Parse(Console.ReadLine());
        decimal cabbageSeedAmount = decimal.Parse(Console.ReadLine());
        decimal cabbageArea = decimal.Parse(Console.ReadLine());
        decimal beansSeedAmount = decimal.Parse(Console.ReadLine());

        decimal tomatoCostPerSeed = 0.5m;
        decimal cucumberCostPerSeed = 0.4m;
        decimal potatoCostPerSeed = 0.25m;
        decimal carrotCostPerSeed = 0.6m;
        decimal cabbageCostPerSeed = 0.3m;
        decimal beansCostPerSeed = 0.4m;

        decimal totalCost = tomatoSeedAmount * tomatoCostPerSeed + cucumberSeedAmount * cucumberCostPerSeed +
            potatoSeedAmount * potatoCostPerSeed + carrotSeedAmount * carrotCostPerSeed + cabbageSeedAmount * cabbageCostPerSeed +
            beansSeedAmount * beansCostPerSeed;

        decimal beansArea = 250 - tomatoArea - cucumberArea - potatoArea - carrotArea - cabbageArea;

        if (beansArea>0)
        {
            Console.WriteLine("Total costs: {0:F2}", totalCost);
            Console.WriteLine("Beans area: {0}", beansArea);
        }
        else if (beansArea==0)
        {
            Console.WriteLine("Total costs: {0:F2}", totalCost);
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Total costs: {0:F2}", totalCost);
            Console.WriteLine("Insufficient area");
        }
    }
}