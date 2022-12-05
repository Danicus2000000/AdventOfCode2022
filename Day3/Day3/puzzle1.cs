/*The Elves have made a list of all of the items currently in each rucksack (your puzzle input), but they need your help finding the errors. Every item type is identified by a single lowercase or uppercase letter (that is, a and A refer to different types of items).

The list of items for each rucksack is given as characters all on a single line. A given rucksack always has the same number of items in each of its two compartments, so the first half of the characters represent items in the first compartment, while the second half of the characters represent items in the second compartment.

For example, suppose you have the following list of contents from six rucksacks:

vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw
The first rucksack contains the items vJrwpWtwJgWrhcsFMMfFFhFp, which means its first compartment contains the items vJrwpWtwJgWr, while the second compartment contains the items hcsFMMfFFhFp. The only item type that appears in both compartments is lowercase p.
The second rucksack's compartments contain jqHRNqRjqzjGDLGL and rsFMfFZSrLrFZsSL. The only item type that appears in both compartments is uppercase L.
The third rucksack's compartments contain PmmdzqPrV and vPwwTWBwg; the only common item type is uppercase P.
The fourth rucksack's compartments only share item type v.
The fifth rucksack's compartments only share item type t.
The sixth rucksack's compartments only share item type s.
To help prioritize item rearrangement, every item type can be converted to a priority:*/
using Day3;

string rawData = File.ReadAllText("puzzleData.txt");
Dictionary<string,string> rucksacks= new Dictionary<string,string>();
string[] rucksackRaw = rawData.Split("\r\n");
foreach(string sack in rucksackRaw) 
{
    rucksacks.Add(sack.Substring(0, sack.Length / 2), sack.Substring(sack.Length / 2));
}
string[] compartment1 = rucksacks.Values.ToArray();
string[] compartment2 = rucksacks.Keys.ToArray();
int totalPriorityCount = 0;
for(int i = 0; i < compartment1.Length; i++) 
{
    char[] compartment1Raw = compartment1[i].ToCharArray();
    int highest = 0;
    int cur = 0;
    foreach(char item in compartment1Raw) 
    {
        if (compartment2[i].Contains(item)) 
        {
            switch (item) 
            {
                case 'a':
                    cur= 1;
                    break;
                case 'b':
                    cur= 2; 
                    break;
                case 'c':
                    cur= 3;
                    break;
                case 'd':
                    cur= 4;
                    break;
                case 'e':
                    cur= 5;
                    break;
                case 'f':
                    cur= 6;
                    break;
                case 'g':
                    cur=7;
                    break;
                case 'h':
                    cur= 8;
                    break;
                case 'i':
                    cur= 9;
                    break;
                case 'j':
                    cur= 10;
                    break;
                case 'k':
                    cur= 11;
                    break;
                case 'l':
                    cur= 12;
                    break;
                case 'm':
                    cur= 13;
                    break;
                case 'n':
                    cur= 14;
                    break;
                case 'o':
                    cur= 15;
                    break;
                case 'p':
                    cur= 16;
                    break;
                case 'q':
                    cur= 17;
                    break;
                case 'r':
                    cur= 18;
                    break;
                case 's':
                    cur= 19;
                    break;
                case 't':
                    cur= 20;
                    break;
                case 'u':
                    cur= 21;
                    break;
                case 'v':
                    cur= 22;
                    break;
                case 'w':
                    cur= 23;
                    break;
                case 'x':
                    cur= 24;
                    break;
                case 'y':
                    cur= 25;
                    break;
                case 'z':
                    cur= 26;
                    break;
                case 'A':
                    cur= 27;
                    break;
                case 'B':
                    cur= 28;
                    break;
                case 'C':
                    cur= 29;
                    break;
                case 'D':
                    cur= 30;
                    break;
                case 'E':
                    cur= 31;
                    break;
                case 'F':
                    cur= 32;
                    break;
                case 'G':
                    cur= 33;
                    break;
                case 'H':
                    cur= 34;
                    break;
                case 'I':
                    cur= 35;
                    break;
                case 'J':
                    cur= 36;
                    break;
                case 'K':
                    cur= 37;
                    break;
                case 'L':
                    cur= 38;
                    break;
                case 'M':
                    cur= 39;
                    break;
                case 'N':
                    cur= 40;
                    break;
                case 'O':
                    cur= 41;
                    break;
                case 'P':
                    cur= 42;
                    break;
                case 'Q':
                    cur= 43;
                    break;
                case 'R':
                    cur= 44;
                    break;
                case 'S':
                    cur= 45;
                    break;
                case 'T':
                    cur= 46;
                    break;
                case 'U':
                    cur= 47;
                    break;
                case 'V':
                    cur= 48;
                    break;
                case 'W':
                    cur= 49;
                    break;
                case 'X':
                    cur= 50;
                    break;
                case 'Y':
                    cur= 51;
                    break;
                case 'Z':
                    cur= 52;
                    break;
            }
            if (cur > highest)
            {
                highest= cur;
            }
        }
    }
    totalPriorityCount += highest;
}
Console.WriteLine("Total item priority count: " + totalPriorityCount);
puzzle2 puzzle=new puzzle2();
puzzle.main();