using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*By the time you calculate the answer to the Elves' question, they've already realized that the Elf carrying the most Calories of food might eventually run out of snacks.

To avoid this unacceptable situation, the Elves would instead like to know the total Calories carried by the top three Elves carrying the most Calories. That way, even if one of those Elves runs out of snacks, they still have two backups.

In the example above, the top three Elves are the fourth Elf (with 24000 Calories), then the third Elf (with 11000 Calories), then the fifth Elf (with 10000 Calories). The sum of the Calories carried by these three elves is 45000.

Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?*/
namespace Day1
{
    class puzzle2
    {
        internal void main() 
        {
            string puzzleData = File.ReadAllText("puzzleData.txt");
            List<string> rawData = puzzleData.Split("\r\n").ToList();
            List<List<int>> elfInventory = new List<List<int>>();
            List<int> toAdd = new List<int>();
            foreach (string intake in rawData)
            {
                if (intake == "")
                {
                    elfInventory.Add(toAdd);
                    toAdd = new List<int>();
                }
                else
                {
                    toAdd.Add(Convert.ToInt32(intake));
                }
            }
            int highestCallories = 0;
            int secondHeighest = 0;
            int thirdHighest = 0;
            foreach (List<int> elf in elfInventory)
            {
                int currentCalories = 0;
                foreach (int calorie in elf)
                {
                    currentCalories += calorie;
                }
                if (highestCallories < currentCalories)
                {
                    int temp1 = highestCallories;
                    int temp2 = secondHeighest;
                    highestCallories = currentCalories;
                    secondHeighest = temp1;
                    thirdHighest = temp2;
                }
                else if (secondHeighest < currentCalories)
                {
                    int temp = secondHeighest;
                    secondHeighest = currentCalories;
                    thirdHighest = temp;
                }
                else if (thirdHighest < currentCalories) 
                {
                    thirdHighest= currentCalories;
                }
            }
            Console.WriteLine("The elf with the most calories has: " + highestCallories + " calories!");
            Console.WriteLine("The elf with the second most calories has: " + secondHeighest + " calories!");
            Console.WriteLine("The elf with the third most calories has: " + thirdHighest + " calories!");
            Console.WriteLine("Their combined total is: "+(highestCallories+secondHeighest+thirdHighest)+" calories!");
        }
    }
}
