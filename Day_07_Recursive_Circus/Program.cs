using AdventOfCodeUtilities;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

List<string> inputList = AoC.GetInputLines();

List<Prog> programs = inputList.Select(s => new Prog(s)).ToList();
Dictionary<string, Prog> programNameMap = new();
Dictionary<int, Prog> programWeightMap = new();

foreach (var program in programs)
{
    programNameMap[program.Name] = program;
    programWeightMap[program.Weight] = program;
}
foreach (var program in programs)
{
    program.Children = program.ChildrenNames.Select(s => programNameMap[s]).ToList();
    program.Children.ForEach(p => { p.Parent = program; });
}

Prog root = programs.First(p => p.Parent is null);

void P1()
{
    Console.WriteLine(root.Name);
    Console.ReadLine();
}

void P2()
{
    (int,int) findOddNonOddRecursiveWeights(Prog program)
    {
        var recursiveWeights = program!.Children.Select(c => c.RecursiveWeight).ToList();
        var uniqueRecursiveWeights = program!.Children.Select(c => c.RecursiveWeight).ToHashSet().ToList();
        if (recursiveWeights.Count(w => w == uniqueRecursiveWeights[0]) == 1)
        {
            return (uniqueRecursiveWeights[0], uniqueRecursiveWeights[1]);
        }
        else
        {
            return (uniqueRecursiveWeights[1], uniqueRecursiveWeights[0]);
        }
    }

    int result = 0;

    Prog walkProg = root;
    while (true)
    {
        var recursiveWeights = walkProg.Children.Select(c => c.RecursiveWeight).ToList();
        var uniqueRecursiveWeights = walkProg.Children.Select(c => c.RecursiveWeight).ToHashSet().ToList();
        if (uniqueRecursiveWeights.Count == 1)
        {
            (_, int nonOddWeight) = findOddNonOddRecursiveWeights(walkProg.Parent!);
            result = walkProg.Weight - (walkProg.RecursiveWeight - nonOddWeight);
            break;
        }
        Debug.Assert(uniqueRecursiveWeights.Count == 2);

        (int oddWeight, _) = findOddNonOddRecursiveWeights(walkProg);
        int index = recursiveWeights.IndexOf(oddWeight);
        walkProg = walkProg.Children[index];
    }

    Console.WriteLine(result);
    Console.ReadLine();
}

P1();
P2();

public class Prog
{
    public int RecursiveWeight { get => Weight + Children.Sum(c => c.RecursiveWeight); }
    public int Weight;
    public string Name;

    public List<string> ChildrenNames = new();
    public List<Prog> Children = new();
    public Prog? Parent = null;

    public Prog(string line)
    {
        var split = line.Split(' ');
        Name = split[0];
        Weight = int.Parse(split[1][1..^1]);
        ChildrenNames = split.Skip(3).Select(s => s.TrimEnd(',')).ToList();
    }

    public override string ToString()
    {
        return $"{Name} ({Weight}) ({RecursiveWeight})";
    }
}
