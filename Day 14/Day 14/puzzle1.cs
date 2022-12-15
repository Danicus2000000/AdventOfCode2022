﻿/*Fortunately, your familiarity with analyzing the path of falling material will come in handy here. You scan a two-dimensional vertical slice of the cave above you (your puzzle input) and discover that it is mostly air with structures made of rock.

Your scan traces the path of each solid rock structure and reports the x,y coordinates that form the shape of the path, where x represents distance to the right and y represents distance down. Each path appears as a single line of text in your scan. After the first point of each path, each point indicates the end of a straight horizontal or vertical line to be drawn from the previous point. For example:

498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9
This scan means that there are two paths of rock; the first path consists of two straight lines, and the second path consists of three straight lines. (Specifically, the first path consists of a line of rock from 498,4 through 498,6 and another line of rock from 498,6 through 496,6.)

The sand is pouring into the cave from point 500,0.

Drawing rock as #, air as ., and the source of the sand as +, this becomes:


  4     5  5
  9     0  0
  4     0  3
0 ......+...
1 ..........
2 ..........
3 ..........
4 ....#...##
5 ....#...#.
6 ..###...#.
7 ........#.
8 ........#.
9 #########.
Sand is produced one unit at a time, and the next unit of sand is not produced until the previous unit of sand comes to rest. A unit of sand is large enough to fill one tile of air in your scan.

A unit of sand always falls down one step if possible. If the tile immediately below is blocked (by rock or sand), the unit of sand attempts to instead move diagonally one step down and to the left. If that tile is blocked, the unit of sand attempts to instead move diagonally one step down and to the right. Sand keeps moving as long as it is able to do so, at each step trying to move down, then down-left, then down-right. If all three possible destinations are blocked, the unit of sand comes to rest and no longer moves, at which point the next unit of sand is created back at the source.

So, drawing sand that has come to rest as o, the first unit of sand simply falls straight down and then stops:

......+...
..........
..........
..........
....#...##
....#...#.
..###...#.
........#.
......o.#.
#########.
The second unit of sand then falls straight down, lands on the first one, and then comes to rest to its left:

......+...
..........
..........
..........
....#...##
....#...#.
..###...#.
........#.
.....oo.#.
#########.
After a total of five units of sand have come to rest, they form this pattern:

......+...
..........
..........
..........
....#...##
....#...#.
..###...#.
......o.#.
....oooo#.
#########.
After a total of 22 units of sand:

......+...
..........
......o...
.....ooo..
....#ooo##
....#ooo#.
..###ooo#.
....oooo#.
...ooooo#.
#########.
Finally, only two more units of sand can possibly come to rest:

......+...
..........
......o...
.....ooo..
....#ooo##
...o#ooo#.
..###ooo#.
....oooo#.
.o.ooooo#.
#########.
Once all 24 units of sand shown above have come to rest, all further sand flows out the bottom, falling into the endless void. Just for fun, the path any new sand takes before falling forever is shown here with ~:

.......+...
.......~...
......~o...
.....~ooo..
....~#ooo##
...~o#ooo#.
..~###ooo#.
..~..oooo#.
.~o.ooooo#.
~#########.
~..........
~..........
~..........
Using your scan, simulate the falling sand. How many units of sand come to rest before sand starts flowing into the abyss below?*/
namespace Day_14
{
    internal static class puzzle1
    {
        internal static void main(string puzzleData) 
        {
            puzzleData = puzzleData.Replace(" ", "");//gets rid of whitespace
            string[] rockLines=puzzleData.Split(Environment.NewLine);//splits by newline
            List<List<(int, int)>> coords = new List<List<(int, int)>>();//stores all coords
            foreach(string rockLine in rockLines) //loops through lines of rocks
            {
                string[] coordSet = rockLine.Split("->");//gets each coord set
                List<(int, int)> coordSetToAdd = new List<(int, int)>();//stores a line of coord sets
                foreach(string coord in coordSet) //for each coordinate in the coordset
                {
                    string[] xAndY = coord.Split(",");//get the x and ys and add it it to the to add list
                    coordSetToAdd.Add((int.Parse(xAndY[0]), int.Parse(xAndY[^1])));
                }
                coords.Add(coordSetToAdd);//add coord line to coords
            }
            int maxXBound = 0;//stores max value found in rocks
            int maxYBound = 0;
            for(int i=0;i<coords.Count;i++) //calculate size of the grid we are working with
            {
                for (int j = 0; j < coords[i].Count; j++) 
                {
                    (int curXBound,int curYBound) = coords[i][j];
                    if (curXBound > maxXBound) 
                    {
                        maxXBound = curXBound;
                    }
                    else if(curYBound > maxYBound) 
                    {
                        maxYBound = curYBound;
                    }
                }
            }
            char[,] sandGrid = new char[maxYBound, maxXBound];
            for (int i = 0; i < sandGrid.GetLength(0); i++) //make grid containing empty points
            {
                for (int j = 0; j < sandGrid.GetLength(1); j++) 
                {
                    sandGrid[i, j] = '.';
                }
            }
            for (int i = 0; i < coords.Count; i++) //fill grid with # were rock is
            {
                for (int j = 0; j < coords[i].Count-1; j++)
                {
                    (int rockFromX,int rockFromY) = coords[i][j];
                    (int rockToX,int rockToY) = coords[i][j+1];
                    rockFromX -= 1;
                    rockFromY-= 1;
                    rockToX -= 1;
                    rockToY -= 1;
                    int distanceToCoverX= rockToX - rockFromX;
                    int distanceToCoverY= rockToY - rockFromY;
                    if (distanceToCoverX < 0)
                    {
                        for (int travelX = rockFromX; travelX > rockFromX+distanceToCoverX; travelX--)
                        {
                            sandGrid[rockFromY, travelX] = '#';
                        }
                    }
                    else if (distanceToCoverX > 0)
                    {
                        for (int travelX = rockFromX; travelX <= rockFromX+distanceToCoverX; travelX++)
                        {
                            sandGrid[rockFromY, travelX] = '#';
                        }
                    }
                    if (distanceToCoverY < 0)
                    {
                        for (int travelY = rockFromY; travelY > rockFromY + distanceToCoverY; travelY--)
                        {
                            sandGrid[travelY, rockFromX] = '#';
                        }
                    }
                    else if (distanceToCoverY > 0) 
                    {
                        for (int travelY = rockFromY; travelY <= rockFromY+distanceToCoverY; travelY++) 
                        {
                            sandGrid[travelY, rockFromX] = '#';
                        }
                    }
                }
            }
            sandGrid[0, 500] = '+';//add sand target point
            for(int i=0;i<sandGrid.GetLength(0);i++) //output sand grid
            {
                for(int j = 0; j < sandGrid.GetLength(1); j++) 
                {
                    Console.Write(sandGrid[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
