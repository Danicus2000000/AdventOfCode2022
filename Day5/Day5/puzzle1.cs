using Day5;
/*The ship has a giant cargo crane capable of moving crates between stacks. To ensure none of the crates get crushed or fall over, the crane operator will rearrange them in a series of carefully-planned steps. After the crates are rearranged, the desired crates will be at the top of each stack.

The Elves don't want to interrupt the crane operator during this delicate procedure, but they forgot to ask her which crate will end up where, and they want to be ready to unload them as soon as possible so they can embark.

They do, however, have a drawing of the starting stacks of crates and the rearrangement procedure (your puzzle input). For example:

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
string rawPuzzle = File.ReadAllText("puzzleData.txt");
List<string> rawPuzzleLines = rawPuzzle.Split("\r\n").ToList();
List<Stack<char>> crates = new List<Stack<char>> { new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>() };
foreach(string line in rawPuzzleLines) 
{
    if (line.Contains('1')) { break; }
    if (line[1] != ' ') 
    {
        crates[0].Push(line[1]);
    }
    if (line[5] != ' ')
    {
        crates[1].Push(line[5]);
    }
    if (line[9] != ' ')
    {
        crates[2].Push(line[9]);
    }
    if (line[13] != ' ')
    {
        crates[3].Push(line[13]);
    }
    if (line[17] != ' ')
    {
        crates[4].Push(line[17]);
    }
    if (line[21] != ' ')
    {
        crates[5].Push(line[21]);
    }
    if (line[25] != ' ')
    {
        crates[6].Push(line[25]);
    }
    if (line[29] != ' ')
    {
        crates[7].Push(line[29]);
    }
    if (line[33] != ' ')
    {
        crates[8].Push(line[33]);
    }
}
for(int i=0;i<crates.Count;i++) //reverses stacks so the top of the crate pile can be pulled correctly
{
    crates[i]=new Stack<char>(crates[i]);
}
rawPuzzleLines.RemoveRange(0, 10);//converts to instruction list
foreach(string instruction in rawPuzzleLines) 
{
    string[] instructionset=instruction.Split(' ');
    List<int> trueRequirments=new List<int>();
    foreach(string word in instructionset) 
    {
        if(int.TryParse(word,out int requiredValue)) 
        {
            trueRequirments.Add(requiredValue);
        }
    } 
    int quantity = trueRequirments[0];
    int from = trueRequirments[1]-1;
    int to = trueRequirments[2]-1;
    for(int i = 0; i < quantity; i++) 
    {
        crates[to].Push(crates[from].Pop());
    }
}
Console.WriteLine("Crates on top in order: " + crates[0].Last()+" "+ crates[1].Last() + " " + crates[2].Last() + " " + crates[3].Last() + " " + crates[4].Last() + " " + crates[5].Last() + " " + crates[6].Last() + " " + crates[7].Last() + " " + crates[8].Last() + " ");
puzzle2 puzzle2 = new puzzle2();
puzzle2.main();