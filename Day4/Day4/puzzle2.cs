using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*In the above example, the first two pairs (2-4,6-8 and 2-3,4-5) don't overlap, while the remaining four pairs (5-7,7-9, 2-8,3-7, 6-6,4-6, and 2-6,4-8) do overlap:

5-7,7-9 overlaps in a single section, 7.
2-8,3-7 overlaps all of the sections 3 through 7.
6-6,4-6 overlaps in a single section, 6.
2-6,4-8 overlaps in sections 4, 5, and 6.
So, in this example, the number of overlapping assignment pairs is 4.

In how many assignment pairs do the ranges overlap?*/
namespace Day4
{
    internal class puzzle2
    {
        internal void main() 
        {
            string elfWorkload = File.ReadAllText("puzzleData.txt");
            string[] elfPairs = elfWorkload.Split("\r\n");
            List<List<List<int>>> trueELfWorkload = new List<List<List<int>>>();
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
                bool notSolved=false;
                foreach (int areaID in elfPair[0])
                {
                    if (elfPair[1].Contains(areaID)) 
                    { 
                        maxCount++;
                        notSolved = true;
                        break;
                    }
                }
                if(notSolved)
                {
                    foreach (int areaID in elfPair[1])
                    {
                        if (elfPair[0].Contains(areaID)) 
                        { 
                            maxCount++;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Total partially overlapping pairs: " + maxCount);
        }
    }
}
