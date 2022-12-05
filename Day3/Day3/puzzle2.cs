using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
/*For safety, the Elves are divided into groups of three. Every Elf carries a badge that identifies their group. For efficiency, within each group of three Elves, the badge is the only item type carried by all three Elves. That is, if a group's badge is item type B, then all three Elves will have item type B somewhere in their rucksack, and at most two of the Elves will be carrying any other item type.

The problem is that someone forgot to put this year's updated authenticity sticker on the badges. All of the badges need to be pulled out of the rucksacks so the new authenticity stickers can be attached.

Additionally, nobody wrote down which item type corresponds to each group's badges. The only way to tell which item type is the right one is by finding the one item type that is common between all three Elves in each group.

Every set of three lines in your list corresponds to a single group, but each group can have a different badge item type. So, in the above example, the first group's rucksacks are the first three lines:

vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
And the second group's rucksacks are the next three lines:

wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw
In the first group, the only item type that appears in all three rucksacks is lowercase r; this must be their badges. In the second group, their badge item type must be Z.

Priorities for these items must still be found to organize the sticker attachment efforts: here, they are 18 (r) for the first group and 52 (Z) for the second group. The sum of these is 70.

Find the item type that corresponds to the badges of each three-Elf group. What is the sum of the priorities of those item types?*/
namespace Day3
{
    internal class puzzle2
    {
        internal void main() 
        {
            string rawData = File.ReadAllText("puzzleData.txt");
            List<string> rucksacks = new List<string>();
            rucksacks.AddRange(rawData.Split("\r\n"));
            int totalPriorityCount = 0;
            for (int i = 0; i < rucksacks.Count; i+=3)
            {
                string sack1 = rucksacks[i];
                string sack2 = rucksacks[i+1];
                char[] sack2Raw=sack2.ToCharArray();
                string sack3 = rucksacks[i+2];
                char[] sack3Raw=sack3.ToCharArray();
                List<char> oneContains=new List<char>();
                int highestPriority = 0;
                foreach(char sackItem in sack2Raw) 
                {
                    if(sack1.Contains(sackItem)) 
                    {
                        oneContains.Add(sackItem);
                    }
                }
                foreach(char sackItem in sack3Raw) 
                {
                    if(sack1.Contains(sackItem) && oneContains.Contains(sackItem)) 
                    {
                        int cur= getLetterValue(sackItem);
                        if (cur > highestPriority) 
                        {
                            highestPriority = cur;
                        }
                    }
                }
                totalPriorityCount += highestPriority;
                
            }
            Console.WriteLine("Total badge priority count: " + totalPriorityCount);
        }
        internal int getLetterValue(char item) 
        {
            int cur = 0;
            switch (item)
            {
                case 'a':
                    cur = 1;
                    break;
                case 'b':
                    cur = 2;
                    break;
                case 'c':
                    cur = 3;
                    break;
                case 'd':
                    cur = 4;
                    break;
                case 'e':
                    cur = 5;
                    break;
                case 'f':
                    cur = 6;
                    break;
                case 'g':
                    cur = 7;
                    break;
                case 'h':
                    cur = 8;
                    break;
                case 'i':
                    cur = 9;
                    break;
                case 'j':
                    cur = 10;
                    break;
                case 'k':
                    cur = 11;
                    break;
                case 'l':
                    cur = 12;
                    break;
                case 'm':
                    cur = 13;
                    break;
                case 'n':
                    cur = 14;
                    break;
                case 'o':
                    cur = 15;
                    break;
                case 'p':
                    cur = 16;
                    break;
                case 'q':
                    cur = 17;
                    break;
                case 'r':
                    cur = 18;
                    break;
                case 's':
                    cur = 19;
                    break;
                case 't':
                    cur = 20;
                    break;
                case 'u':
                    cur = 21;
                    break;
                case 'v':
                    cur = 22;
                    break;
                case 'w':
                    cur = 23;
                    break;
                case 'x':
                    cur = 24;
                    break;
                case 'y':
                    cur = 25;
                    break;
                case 'z':
                    cur = 26;
                    break;
                case 'A':
                    cur = 27;
                    break;
                case 'B':
                    cur = 28;
                    break;
                case 'C':
                    cur = 29;
                    break;
                case 'D':
                    cur = 30;
                    break;
                case 'E':
                    cur = 31;
                    break;
                case 'F':
                    cur = 32;
                    break;
                case 'G':
                    cur = 33;
                    break;
                case 'H':
                    cur = 34;
                    break;
                case 'I':
                    cur = 35;
                    break;
                case 'J':
                    cur = 36;
                    break;
                case 'K':
                    cur = 37;
                    break;
                case 'L':
                    cur = 38;
                    break;
                case 'M':
                    cur = 39;
                    break;
                case 'N':
                    cur = 40;
                    break;
                case 'O':
                    cur = 41;
                    break;
                case 'P':
                    cur = 42;
                    break;
                case 'Q':
                    cur = 43;
                    break;
                case 'R':
                    cur = 44;
                    break;
                case 'S':
                    cur = 45;
                    break;
                case 'T':
                    cur = 46;
                    break;
                case 'U':
                    cur = 47;
                    break;
                case 'V':
                    cur = 48;
                    break;
                case 'W':
                    cur = 49;
                    break;
                case 'X':
                    cur = 50;
                    break;
                case 'Y':
                    cur = 51;
                    break;
                case 'Z':
                    cur = 52;
                    break;
            }
            return cur;
        }
    }
}
