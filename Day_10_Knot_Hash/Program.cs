using AdventOfCodeUtilities;
using System.Diagnostics;
using System.Text.RegularExpressions;

List<string> inputList = AoC.GetInputLines();

const int length = 256;
List<int> stepsP1 = inputList[0].Split(',', ' ').Where(s => s != "").Select(s => int.Parse(s)).ToList();
List<char> stepsP2 = inputList[0].ToCharArray().ToList();
stepsP2.AddRange(new List<char>() { (char)17, (char)31, (char)73, (char)47, (char)23 });

List<int> data;

#pragma warning disable 8321
void Print(int currentIndex)
{
    for (int i = 0; i < length; i++)
    {
        if (i == currentIndex)
            Console.Write($"[{data[i]}] ");
        else
            Console.Write($"{data[i]} ");
    }
    Console.WriteLine();
    Console.ReadLine();
}
#pragma warning restore 8321

void P1()
{
    data = new List<int>();
    for (int i = 0; i < length; i++)
        data.Add(i);

    int currentIndex = 0;
    int skipSize = 0;
    foreach (var step in stepsP1)
    {
        List<int> sublist;
        if (currentIndex + step >= length)
        {
            sublist = data[currentIndex..];
            sublist.AddRange(data[..(step - (length - currentIndex))]);
        }
        else
            sublist = data[currentIndex..(currentIndex + step)];

        for (int i = 0; i < step; i++)
        {
            data[(currentIndex + step - 1 - i) % length] = sublist[i];
        }

        currentIndex = (currentIndex + step + skipSize) % length;
        //Print(currentIndex);
        skipSize++;
    }

    Console.WriteLine(data[0] * data[1]);
    Console.ReadLine();
}

void P2()
{
    data = new List<int>();
    for (int i = 0; i < length; i++)
        data.Add(i);

    int currentIndex = 0;
    int skipSize = 0;
    for (int j = 0; j < 64; j++)
    {
        foreach (var step in stepsP2)
        {
            List<int> sublist;
            if (currentIndex + step >= length)
            {
                sublist = data[currentIndex..];
                sublist.AddRange(data[..(step - (length - currentIndex))]);
            }
            else
                sublist = data[currentIndex..(currentIndex + step)];

            for (int i = 0; i < step; i++)
            {
                data[(currentIndex + step - 1 - i) % length] = sublist[i];
            }

            currentIndex = (currentIndex + step + skipSize) % length;
            //Print(currentIndex);
            skipSize++;
        }
    }

    string result = string.Join("", data.Chunk(16).Select(chunk => chunk.Aggregate((acc, val) => (byte)(acc ^ val)).ToString("X2"))).ToLower();

    Console.WriteLine(result);
    Console.ReadLine();
}

P1();
P2();
