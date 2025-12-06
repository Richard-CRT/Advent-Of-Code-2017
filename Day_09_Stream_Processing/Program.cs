using AdventOfCodeUtilities;
using System.Text.RegularExpressions;

List<string> inputList = AoC.GetInputLines();
string stream = inputList[0];

void P12()
{
    int garbageCharacters = 0;

    int numConsecutiveCancels = 0;
    State state = State.TokenSearching;
    List<Group> groups = new List<Group>();
    Group? workingGroup = null;
    Group? rootGroup = null;

    for (int ci = 0; ci < stream.Length; ci++)
    {
        char c = stream[ci];
        if (c == '!') numConsecutiveCancels++;
        else
        {
            if (numConsecutiveCancels % 2 == 0)
            {
                switch (state)
                {
                    case State.TokenSearching:
                        if (c == '<')
                        {
                            state = State.Garbage;
                        }
                        else if (c == '{')
                        {
                            var newGroup = new Group();
                            newGroup.ParentGroup = workingGroup;
                            if (workingGroup is null)
                                rootGroup = newGroup;
                            else
                                workingGroup.ChildrenGroups.Add(newGroup);
                            workingGroup = newGroup;
                        }
                        else if (c == '}')
                        {
                            groups.Add(workingGroup!);
                            workingGroup = workingGroup!.ParentGroup;
                        }
                        break;
                    case State.Garbage:
                        if (c == '>')
                            state = State.TokenSearching;
                        else
                            garbageCharacters++;
                        break;
                }
            }
            numConsecutiveCancels = 0;
        }
    }

    Console.WriteLine(groups.Sum(g => g.Score));
    Console.ReadLine();

    Console.WriteLine(garbageCharacters);
    Console.ReadLine();
}

P12();

enum State
{
    TokenSearching,
    Garbage
}

public class Group
{
    public Group? ParentGroup = null;
    public List<Group> ChildrenGroups = new();
    public int Score { get => ParentGroup is null ? 1 : ParentGroup.Score + 1; }
}
