﻿/*The Elves take turns writing down the number of Calories contained by the various meals, snacks, rations, etc. that they've brought with them, one item per line. Each Elf separates their own inventory from the previous Elf's inventory (if any) by a blank line.

For example, suppose the Elves finish writing their items' Calories and end up with the following list:

1000
2000
3000

4000

5000
6000

7000
8000
9000

10000
This list represents the Calories of the food carried by five Elves:

The first Elf is carrying food with 1000, 2000, and 3000 Calories, a total of 6000 Calories.
The second Elf is carrying one food item with 4000 Calories.
The third Elf is carrying food with 5000 and 6000 Calories, a total of 11000 Calories.
The fourth Elf is carrying food with 7000, 8000, and 9000 Calories, a total of 24000 Calories.
The fifth Elf is carrying one food item with 10000 Calories.
In case the Elves get hungry and need extra snacks, they need to know which Elf to ask: they'd like to know how many Calories are being carried by the Elf carrying the most Calories. In the example above, this is 24000 (carried by the fourth Elf).

Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?*/
using Day1;

string puzzleData = File.ReadAllText("puzzleData.txt");
List<string> rawData=puzzleData.Split("\r\n").ToList();
List<List<int>> elfInventory=new List<List<int>>();
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
foreach(List<int> elf in elfInventory) 
{
    int currentCalories = 0;
    foreach(int calorie in elf) 
    {
        currentCalories += calorie;
    }
    if (highestCallories < currentCalories) 
    {
        highestCallories = currentCalories;
    }
}
Console.WriteLine("The elf with the most calories has: " + highestCallories + " calories!");
puzzle2 puzzlePart2 = new puzzle2();
puzzlePart2.main();