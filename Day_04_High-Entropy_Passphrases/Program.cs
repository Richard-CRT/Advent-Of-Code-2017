using AdventOfCodeUtilities;
using System.Text.RegularExpressions;

List<string> inputList = AoC.GetInputLines();

void P1()
{
    int result = 0;

    foreach (string phrase in inputList)
    {
        string[] words = phrase.Split(' ');
        var wordsHash = new HashSet<string>(words);
        if (wordsHash.Count == words.Length)
            result++;
    }

    Console.WriteLine(result);
    Console.ReadLine();
}

void P2()
{
    int result = 0;

    foreach (string phrase in inputList)
    {
        string[] words = phrase.Split(' ');
        string[] wordsOrdered = words.Select(word => new string(word.Order().ToArray())).ToArray();
        var wordsHash = new HashSet<string>(wordsOrdered);
        if (wordsHash.Count == wordsOrdered.Length)
            result++;
    }

    Console.WriteLine(result);
    Console.ReadLine();
}

P1();
P2();
