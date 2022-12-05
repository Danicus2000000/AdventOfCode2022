/*they've noticed that many of the assignments overlap. To try to quickly find overlaps and reduce duplicated effort, the Elves pair up and make a big list of the section assignments for each pair (your puzzle input).

For example, consider the following list of section assignment pairs:

2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8
For the first few pairs, this list means:

Within the first pair of Elves, the first Elf was assigned sections 2-4 (sections 2, 3, and 4), while the second Elf was assigned sections 6-8 (sections 6, 7, 8).
The Elves in the second pair were each assigned two sections.
The Elves in the third pair were each assigned three sections: one got sections 5, 6, and 7, while the other also got 7, plus 8 and 9.
This example list uses single-digit section IDs to make it easier to draw; your actual list might contain larger numbers. Visually, these pairs of section assignments look like this:

.234.....  2-4
.....678.  6-8

.23......  2-3
...45....  4-5

....567..  5-7
......789  7-9

.2345678.  2-8
..34567..  3-7

.....6...  6-6
...456...  4-6

.23456...  2-6
...45678.  4-8
Some of the pairs have noticed that one of their assignments fully contains the other. For example, 2-8 fully contains 3-7, and 6-6 is fully contained by 4-6. In pairs where one assignment fully contains the other, one Elf in the pair would be exclusively cleaning sections their partner will already be cleaning, so these seem like the most in need of reconsideration. In this example, there are 2 such pairs.

In how many assignment pairs does one range fully contain the other?*/
using Day4;

string elfWorkload = File.ReadAllText("puzzleData.txt");
string[] elfPairs = elfWorkload.Split("\r\n");
List<List<List<int>>> trueELfWorkload= new List<List<List<int>>>();
foreach (string elf in elfPairs)
{
    string elf1load = elf.Split(",")[0];
    string elf2load = elf.Split(",")[1];
    List<int> elfWorkload1 = new List<int>();
    List<int> elfWorkload2 = new List<int>();
    for (int i = Convert.ToInt32(elf1load.Split("-")[0]); i <= Convert.ToInt32(elf1load.Split("-")[1]); i++)
    {
        elfWorkload1.Add(i);
    }
    for (int i = Convert.ToInt32(elf2load.Split("-")[0]); i <= Convert.ToInt32(elf2load.Split("-")[1]); i++)
    {
        elfWorkload2.Add(i);
    }
    trueELfWorkload.Add(new List<List<int>> { elfWorkload1, elfWorkload2 });
}
int maxCount = 0;
foreach (List<List<int>> elfPair in trueELfWorkload) 
{
    int curmatch = 0;
    foreach(int areaID in elfPair[0]) 
    {
        if (elfPair[1].Contains(areaID)) { curmatch++; }
    }
    if (curmatch == elfPair[1].Count)
    {
        maxCount++;
    }
    else
    {
        curmatch = 0;
        foreach (int areaID in elfPair[1])
        {
            if (elfPair[0].Contains(areaID)) { curmatch++; }
        }
        if (curmatch == elfPair[0].Count)
        {
            maxCount++;
        }
    }
}
Console.WriteLine("Total fully overlapping pairs: " + maxCount);
puzzle2 puzzle2 = new puzzle2();
puzzle2.main();