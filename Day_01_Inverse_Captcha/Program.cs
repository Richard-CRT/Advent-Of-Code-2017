using AdventOfCodeUtilities;
using System.Text.RegularExpressions;

List<string> inputList = AoC.GetInputLines();

void P1()
{
    int result = 0;

    for (int i = 0; i < inputList[0].Length; i++)
    {
        int val = inputList[0][i]-'0';
        int nextVal = i < inputList[0].Length - 1 ? inputList[0][i+1]-'0' : inputList[0][0]-'0';
        if (val == nextVal)
        {
            result += val;
        }
    }
    Console.WriteLine(result);
    Console.ReadLine();
}

void P2()
{
    int result = 0;
    for (int i = 0; i < inputList[0].Length; i++)
    {
        int val = inputList[0][i] - '0';
        int nextIndex = (i + (inputList[0].Length / 2)) % inputList[0].Length;
        int nextVal = inputList[0][nextIndex] - '0';

        if (val == nextVal)
        {
            result += val;
        }
    }
    Console.WriteLine(result);
    Console.ReadLine();
}

P1();
P2();
