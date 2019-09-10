using System;
using System.Threading;

namespace _2._4_1__Scenario
{
    class Program
    {
        static void Main(string[] args)
        {
            ScenarioReader scenarioReader = new ScenarioReader("Scenario");
            while (true)
            {
                if (scenarioReader.CanReadDirectory())
                {
                    foreach (var line in scenarioReader.ReadNext())
                        Console.WriteLine(line);
                    Console.WriteLine();

                    Thread.Sleep(500);
                }
            }
        }
    }
}
