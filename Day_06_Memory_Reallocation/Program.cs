using AdventOfCodeUtilities;
using System.Text.RegularExpressions;

List<string> inputList = AoC.GetInputLines();
List<int> blocks = inputList[0].Split(' ', '\t').Select(int.Parse).ToList();

void P1()
{
    int result = 0;

    HashSet<string> seenStates = new();

    while (true)
    {
        if (!seenStates.Add(string.Join(',', blocks)))
            break;

        int maxIndex = 0;
        int runningMax = -1;
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i] > runningMax)
            {
                maxIndex = i;
                runningMax = blocks[i];
            }
        }

        blocks[maxIndex] = 0;
        int currentIndex = (maxIndex + 1) % blocks.Count;
        while (runningMax > 0)
        {
            blocks[currentIndex]++;
            currentIndex = (currentIndex + 1) % blocks.Count;
            runningMax--;
        }
        result++;
    }

    Console.WriteLine(result);
    Console.ReadLine();
}

void P2()
{
    int steps = 0;
    int result = 0;

    Dictionary<string, int> seenStates = new();

    while (true)
    {
        string key = string.Join(',', blocks);
        if (!seenStates.TryAdd(key, steps))
        {
            result = steps - seenStates[key];
            break;
        }
        
        int maxIndex = 0;
        int runningMax = -1;
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i] > runningMax)
            {
                maxIndex = i;
                runningMax = blocks[i];
            }
        }

        blocks[maxIndex] = 0;
        int currentIndex = (maxIndex + 1) % blocks.Count;
        while (runningMax > 0)
        {
            blocks[currentIndex]++;
            currentIndex = (currentIndex + 1) % blocks.Count;
            runningMax--;
        }
        steps++;
    }

    Console.WriteLine(result);
    Console.ReadLine();
}

P1();
P2();
