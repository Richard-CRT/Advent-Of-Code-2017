using AdventOfCodeUtilities;
using System.Text.RegularExpressions;

List<string> inputList = AoC.GetInputLines();

Dictionary<string, int> registers = new();

void P12()
{
    int maxVal = int.MinValue;

    foreach (string line in inputList)
    {
        var split = line.Split(' ');
        string registerToModify = split[0];
        string operation = split[1];

        string registerInCondition = split[4];
        string condition = split[5];
        int literalCondition = int.Parse(split[6]);

        int conditionValue = registers.GetValueOrDefault(registerInCondition, 0);
        bool conditionPass;
        switch (condition)
        {
            case ">": conditionPass = conditionValue > literalCondition; break;
            case "<": conditionPass = conditionValue < literalCondition; break;
            case ">=": conditionPass = conditionValue >= literalCondition; break;
            case "<=": conditionPass = conditionValue <= literalCondition; break;
            case "==": conditionPass = conditionValue == literalCondition; break;
            case "!=": conditionPass = conditionValue != literalCondition; break;
            default: throw new NotImplementedException();
        }

        if (conditionPass)
        {
            int operationValue;
            if (!int.TryParse(split[2], out operationValue))
                operationValue = registers.GetValueOrDefault(split[2], 0);

            switch (operation)
            {
                case "inc": registers[registerToModify] = registers.GetValueOrDefault(registerToModify, 0) + operationValue; break;
                case "dec": registers[registerToModify] = registers.GetValueOrDefault(registerToModify, 0) - operationValue; break;
                default: throw new NotImplementedException();
            }

            maxVal = Math.Max(maxVal, registers[registerToModify]);
        }
    }

    Console.WriteLine(registers.MaxBy(kvp => kvp.Value).Value);
    Console.ReadLine();

    Console.WriteLine(maxVal);
    Console.ReadLine();
}

P12();
