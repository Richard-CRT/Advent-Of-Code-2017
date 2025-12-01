using AdventOfCodeUtilities;
using System.Linq;
using System.Text.RegularExpressions;

List<string> inputList = AoC.GetInputLines();

void P1()
{
    int result = 0;
    foreach (string line in inputList)
    {
        int[] split = line.Split(' ', '\t').Select(s => int.Parse(s)).ToArray();
        result += split.Max() - split.Min();
    }
    Console.WriteLine(result);
    Console.ReadLine();
}

void P2()
{
    int result = 0;
    foreach (string line in inputList)
    {
        int[] split = line.Split(' ', '\t').Select(s => int.Parse(s)).ToArray();
        for (int i = 0; i < split.Length; i++)
        {
            for (int j = 0; j < split.Length; j++)
            {
                if (i != j && split[i] >= split[j])
                {
                    if (split[i] % split[j] == 0)
                    {
                        result += split[i] / split[j];
                    }
                }
            }
        }
    }
    Console.WriteLine(result);
    Console.ReadLine();
}

P1();
P2();
