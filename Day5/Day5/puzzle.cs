/*They do, however, have a drawing of the starting stacks of crates and the rearrangement procedure (your puzzle input). For example:

    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2
In this example, there are three stacks of crates. Stack 1 contains two crates: crate Z is on the bottom, and crate N is on top. Stack 2 contains three crates; from bottom to top, they are crates M, C, and D. Finally, stack 3 contains a single crate, P.

Then, the rearrangement procedure is given. In each step of the procedure, a quantity of crates is moved from one stack to a different stack. In the first step of the above rearrangement procedure, one crate is moved from stack 2 to stack 1, resulting in this configuration:

[D]        
[N] [C]    
[Z] [M] [P]
 1   2   3 
In the second step, three crates are moved from stack 1 to stack 3. Crates are moved one at a time, so the first crate to be moved (D) ends up below the second and third crates:

        [Z]
        [N]
    [C] [D]
    [M] [P]
 1   2   3
Then, both crates are moved from stack 2 to stack 1. Again, because crates are moved one at a time, crate C ends up below crate M:

        [Z]
        [N]
[M]     [D]
[C]     [P]
 1   2   3
Finally, one crate is moved from stack 1 to stack 2:

        [Z]
        [N]
        [D]
[C] [M] [P]
 1   2   3
The Elves just need to know which crate will end up on top of each stack; in this example, the top crates are C in stack 1, M in stack 2, and Z in stack 3, so you should combine these together and give the Elves the message CMZ.

After the rearrangement procedure completes, what crate ends up on top of each stack?*/
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
/*As you watch the crane operator expertly rearrange the crates, you notice the process isn't following your prediction.

Some mud was covering the writing on the side of the crane, and you quickly wipe it away. The crane isn't a CrateMover 9000 - it's a CrateMover 9001.

The CrateMover 9001 is notable for many new and exciting features: air conditioning, leather seats, an extra cup holder, and the ability to pick up and move multiple crates at once.

Again considering the example above, the crates begin in the same configuration:

    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 
Moving a single crate from stack 2 to stack 1 behaves the same as before:

[D]        
[N] [C]    
[Z] [M] [P]
 1   2   3 
However, the action of moving three crates from stack 1 to stack 3 means that those three moved crates stay in the same order, resulting in this new configuration:

        [D]
        [N]
    [C] [Z]
    [M] [P]
 1   2   3
Next, as both crates are moved from stack 2 to stack 1, they retain their order as well:

        [D]
        [N]
[C]     [Z]
[M]     [P]
 1   2   3
Finally, a single crate is still moved from stack 1 to stack 2, but now it's crate C that gets moved:

        [D]
        [N]
        [Z]
[M] [C] [P]
 1   2   3
In this example, the CrateMover 9001 has put the crates in a totally different order: MCD.

Before the rearrangement process finishes, update your simulation so that the Elves know where they should stand to be ready to unload the final supplies. After the rearrangement procedure completes, what crate ends up on top of each stack?*/
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