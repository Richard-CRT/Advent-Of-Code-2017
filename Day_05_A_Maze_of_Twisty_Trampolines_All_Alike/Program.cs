using AdventOfCodeUtilities;
using System.Text.RegularExpressions;

List<string> inputList = AoC.GetInputLines();
List<int> instructions = inputList.Select(s => int.Parse(s)).ToList();

void P1()
{
    int result = 0;

    List<int> instructionsCopy = new List<int>(instructions);

    int pc = 0;
    while (pc >= 0 && pc < instructionsCopy.Count)
    {
        int jmp = instructionsCopy[pc];
        instructionsCopy[pc]++;
        pc += jmp;

        result++;
    }

    Console.WriteLine(result);
    Console.ReadLine();
}

void P2()
{
    int result = 0;

    List<int> instructionsCopy = new List<int>(instructions);

    int pc = 0;
    while (pc >= 0 && pc < instructionsCopy.Count)
    {
        int jmp = instructionsCopy[pc];
        if (jmp >= 3)
            instructionsCopy[pc]--;
        else
            instructionsCopy[pc]++;
        pc += jmp;

        result++;
    }

    Console.WriteLine(result);
    Console.ReadLine();
}

P1();
P2();
