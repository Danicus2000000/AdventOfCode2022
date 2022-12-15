/*You realize you misread the scan. There isn't an endless void at the bottom of the scan - there's floor, and you're standing on it!

You don't have time to scan the floor, so assume the floor is an infinite horizontal line with a y coordinate equal to two plus the highest y coordinate of any point in your scan.

In the example above, the highest y coordinate of any point is 9, and so the floor is at y=11. (This is as if your scan contained one extra rock path like -infinity,11 -> infinity,11.) With the added floor, the example above now looks like this:

        ...........+........
        ....................
        ....................
        ....................
        .........#...##.....
        .........#...#......
        .......###...#......
        .............#......
        .............#......
        .....#########......
        ....................
<-- etc #################### etc -->
To find somewhere safe to stand, you'll need to simulate falling sand until a unit of sand comes to rest at 500,0, blocking the source entirely and stopping the flow of sand into the cave. In the example above, the situation finally looks like this after 93 units of sand come to rest:

............o............
...........ooo...........
..........ooooo..........
.........ooooooo.........
........oo#ooo##o........
.......ooo#ooo#ooo.......
......oo###ooo#oooo......
.....oooo.oooo#ooooo.....
....oooooooooo#oooooo....
...ooo#########ooooooo...
..ooooo.......ooooooooo..
#########################
Using your scan, simulate the falling sand until the source of the sand becomes blocked. How many units of sand come to rest?*/
namespace Day_14
{
    internal static class puzzle2
    {
        internal static void main(string puzzleData) 
        {
            puzzleData = puzzleData.Replace(" ", "");//gets rid of whitespace
            string[] rockLines = puzzleData.Split(Environment.NewLine);//splits by newline
            List<List<(int, int)>> coords = new List<List<(int, int)>>();//stores all coords
            foreach (string rockLine in rockLines) //loops through lines of rocks
            {
                string[] coordSet = rockLine.Split("->");//gets each coord set
                List<(int, int)> coordSetToAdd = new List<(int, int)>();//stores a line of coord sets
                foreach (string coord in coordSet) //for each coordinate in the coordset
                {
                    string[] xAndY = coord.Split(",");//get the x and ys and add it it to the to add list
                    coordSetToAdd.Add((int.Parse(xAndY[0]), int.Parse(xAndY[^1])));
                }
                coords.Add(coordSetToAdd);//add coord line to coords
            }
            int maxXBound = 0;//stores max value found in rocks
            int maxYBound = 0;
            for (int i = 0; i < coords.Count; i++) //calculate size of the grid we are working with
            {
                for (int j = 0; j < coords[i].Count; j++)
                {
                    (int curXBound, int curYBound) = coords[i][j];
                    if (curXBound > maxXBound)
                    {
                        maxXBound = curXBound;
                    }
                    else if (curYBound > maxYBound)
                    {
                        maxYBound = curYBound;
                    }
                }
            }
            char[,] sandGrid = new char[maxYBound+2, maxXBound*2];
            for (int i = 0; i < sandGrid.GetLength(0); i++) //make grid containing empty points
            {
                for (int j = 0; j < sandGrid.GetLength(1); j++)
                {
                    sandGrid[i, j] = '.';
                    if (i == sandGrid.GetLength(0)-1) //builds the floor
                    {
                        sandGrid[i, j] = '#';
                    }
                }
            }
            for (int i = 0; i < coords.Count; i++) //fill grid with # were rock is
            {
                for (int j = 0; j < coords[i].Count - 1; j++)
                {
                    (int rockFromX, int rockFromY) = coords[i][j];
                    (int rockToX, int rockToY) = coords[i][j + 1];
                    rockFromX -= 1;
                    rockFromY -= 1;
                    rockToX -= 1;
                    rockToY -= 1;
                    int distanceToCoverX = rockToX - rockFromX;
                    int distanceToCoverY = rockToY - rockFromY;
                    if (distanceToCoverX < 0)
                    {
                        for (int travelX = rockFromX; travelX >= rockFromX + distanceToCoverX; travelX--)
                        {
                            sandGrid[rockFromY, travelX] = '#';
                        }
                    }
                    else if (distanceToCoverX > 0)
                    {
                        for (int travelX = rockFromX; travelX <= rockFromX + distanceToCoverX; travelX++)
                        {
                            sandGrid[rockFromY, travelX] = '#';
                        }
                    }
                    if (distanceToCoverY < 0)
                    {
                        for (int travelY = rockFromY; travelY >= rockFromY + distanceToCoverY; travelY--)
                        {
                            sandGrid[travelY, rockFromX] = '#';
                        }
                    }
                    else if (distanceToCoverY > 0)
                    {
                        for (int travelY = rockFromY; travelY <= rockFromY + distanceToCoverY; travelY++)
                        {
                            sandGrid[travelY, rockFromX] = '#';
                        }
                    }
                }
            }
            sandGrid[0, 499] = '+';//add sand target point
            //Console.WriteLine("Empty Grid 2:");
            //for (int i = 0; i < sandGrid.GetLength(0); i++) //output sand grid
            //{
            //    for (int j = 0; j < sandGrid.GetLength(1); j++)
            //    {
            //        Console.Write(sandGrid[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            bool sandHasVoid = false;//generates sand until it starts to fall out
            int sandYPos = 0;
            int sandXPos = 499;
            int sandGenCount = 0;
            while (!sandHasVoid) //if sand hasnt hit the void
            {
                if (sandGrid[sandYPos + 1, sandXPos] != '#' && sandGrid[sandYPos + 1, sandXPos] != 'O')//if below is free move down
                {
                    sandYPos += 1;
                }
                else if (sandGrid[sandYPos + 1, sandXPos - 1] != '#' && sandGrid[sandYPos + 1, sandXPos - 1] != 'O')//if below is not free but down and left is move there
                {
                    sandYPos += 1;
                    sandXPos -= 1;
                }
                else if (sandGrid[sandYPos + 1, sandXPos + 1] != '#' && sandGrid[sandYPos + 1, sandXPos + 1] != 'O')//if below is not free but down and right is move there
                {
                    sandYPos += 1;
                    sandXPos += 1;
                }
                else //if the sand is stationary place it down and reset the generator
                {
                    sandGrid[sandYPos, sandXPos] = 'O';
                    sandGenCount++;
                    if (sandYPos == 0 && sandXPos == 499) 
                    {
                        sandHasVoid= true;
                    }
                    sandXPos = 499;
                    sandYPos = 0;
                }

            }
            Console.WriteLine("Units of sand that rest until source is blocked: " + sandGenCount);//output ans
            Console.WriteLine("Grid 2 after sand:");
            for (int i = 0; i < sandGrid.GetLength(0); i++) //output sand grid
            {
                for (int j = 0; j < sandGrid.GetLength(1); j++)
                {
                    Console.Write(sandGrid[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
