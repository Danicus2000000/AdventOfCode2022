using System.Collections;
using System.Text.RegularExpressions;
string[] inputGroups = File.ReadAllText("puzzleData.txt").Split("\r\n\r\n");
string[] moveInstructions = inputGroups[1].Split("\r\n");
string[] crateRows = inputGroups[0].Split("\r\n");
string crateNumberRow = crateRows.Last();
List<int> crateLabelPositions = GetLabelPositions(crateNumberRow);
Dictionary<int,Stack> crateStacks = PopulateCrateStacks(crateLabelPositions, crateRows);

// Puzzle 1
foreach (string moveInstruction in moveInstructions)
{
    var (transferCount, fromStack, toStack) = ParseInstructions(moveInstruction);
    for (int i = 0; i < transferCount; i++)
    {
        Object crate = crateStacks[fromStack].Pop();
        crateStacks[toStack].Push(crate);
    }
}

string topCrates = "";
foreach (KeyValuePair<int,Stack> keyValuePairin in crateStacks) 
{
    topCrates += keyValuePairin.Value.Peek();
}
Console.WriteLine("Puzzle 1 has crates: "+topCrates+" at the top");

// Puzzle 2
crateStacks.Clear();
crateStacks = PopulateCrateStacks(crateLabelPositions, crateRows);

// execute move instructions
foreach (var moveInstruction in moveInstructions)
{
    var (transferCount, fromStack, toStack) = ParseInstructions(moveInstruction);
    // Reverse move crates transferCount number of times
    crateStacks[fromStack].ToArray().Take(transferCount).Reverse().ToList().ForEach(supply =>{crateStacks[fromStack].Pop();crateStacks[toStack].Push(supply);});
}
topCrates = "";
foreach (KeyValuePair<int, Stack> keyValuePairin in crateStacks)
{
    topCrates += keyValuePairin.Value.Peek();
}
Console.WriteLine("Puzzle 2 has crates: "+topCrates+" at the top");

// functions

(int transferCount, int fromStack, int toStack) ParseInstructions(string instruction)
{
    string[] instructionParts = Regex.Matches(instruction, @"\d+").Select(m => m.Value).ToArray();
    int transferCount = int.Parse(instructionParts[0]);
    int fromStack = int.Parse(instructionParts[1]);
    int toStack = int.Parse(instructionParts[2]);
    return (transferCount, fromStack, toStack);
}

Dictionary<int, Stack> PopulateCrateStacks(IReadOnlyList<int> labelPositions, IReadOnlyList<string> supplyCratesInput)
{
    Dictionary<int,Stack> crateStacks = new Dictionary<int, Stack>();
    for (int i = 0; i < labelPositions.Count; i++) 
    {
        crateStacks.Add(i + 1, new Stack());
    }

    for (int i = 0; i < labelPositions.Count; i++)
    {
        int alphabetPosition = labelPositions[i];
        // for each crate row, except the last one, add crate labels to stack
        for (int j = supplyCratesInput.Count - 1; j >= 0; j--)
        {
            string crateRow = supplyCratesInput[j];
            char crateLabel = crateRow[alphabetPosition];
            if (char.IsLetter(crateLabel)) 
            { 
                crateStacks[i + 1].Push(crateLabel); 
            }
        }
    }
    return crateStacks;
}

List<int> GetLabelPositions(string row)
{
    List<int> positions = new List<int>();
    row.Select((c, idx) => new { character = c, index = idx }).ToList().ForEach(c =>{if (char.IsDigit(c.character)) positions.Add(c.index);});
    return positions;
}