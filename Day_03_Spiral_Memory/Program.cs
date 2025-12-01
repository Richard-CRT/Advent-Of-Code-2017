using AdventOfCodeUtilities;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;

List<string> inputList = AoC.GetInputLines();
int input = int.Parse(inputList[0]);

void P1()
{
    double rank = Math.Sqrt(input - 1);

    int intRank = (int)Math.Floor(rank);
    int baseSquare = (intRank * intRank) + 1;

    int diff = input - baseSquare;

    int x;
    int y;
    if (intRank % 2 == 0)
    {
        // even
        int baseX = -intRank / 2;
        int baseY = -intRank / 2;
        if (diff <= intRank)
        {
            x = baseX;
            y = baseY + diff;
        }
        else
        {
            y = intRank / 2;
            x = baseX + (diff - intRank);
        }
    }
    else
    {
        // odd
        int baseX = (intRank + 1) / 2;
        int baseY = ((intRank + 1) / 2) - 1;
        if (diff <= intRank)
        {
            x = baseX;
            y = baseY - diff;
        }
        else
        {
            y = -(intRank + 1) / 2;
            x = baseX - (diff - intRank);
        }
    }

    int distance = Math.Abs(x) + Math.Abs(y);

    Console.WriteLine(distance);
    Console.ReadLine();
}


void P2()
{
    int work(Dictionary<(int, int), int> map, int x, int y)
    {
        int sum = 0;
        int fetchVal;
        if (map.TryGetValue((x - 1, y - 1), out fetchVal))
            sum += fetchVal;
        if (map.TryGetValue((x, y - 1), out fetchVal))
            sum += fetchVal;
        if (map.TryGetValue((x + 1, y - 1), out fetchVal))
            sum += fetchVal;
        if (map.TryGetValue((x + 1, y), out fetchVal))
            sum += fetchVal;
        if (map.TryGetValue((x + 1, y + 1), out fetchVal))
            sum += fetchVal;
        if (map.TryGetValue((x, y + 1), out fetchVal))
            sum += fetchVal;
        if (map.TryGetValue((x - 1, y + 1), out fetchVal))
            sum += fetchVal;
        if (map.TryGetValue((x - 1, y), out fetchVal))
            sum += fetchVal;
        return sum;
    }

    Dictionary<(int, int), int> map = new();

    map[(0, 0)] = 1;

    int x = 1;
    int y = 0;

    // 1 => 3
    // 2 => 5
    // 3 => 7

    int done = -1;
    for (int rank = 1; done == -1; rank++)
    {
        int sideLength = 2 * rank + 1;

        List<(int, int)> coords = new();


        for (; y > -rank; y--)
        {
            coords.Add((x, y));
        }
        for (; x > -rank; x--)
        {
            coords.Add((x, y));
        }
        for (; y < rank; y++)
        {
            coords.Add((x, y));
        }
        for (; x <= rank; x++)
        {
            coords.Add((x, y));
        }

        foreach ((int,int) coord in coords)
        {
            int val = work(map, coord.Item1, coord.Item2);
            if (val > input)
            {
                done = val;
                break;
            }
            map[coord] = val;
        }
    }

    Console.WriteLine(done);
    Console.ReadLine();
}

P1();
P2();
