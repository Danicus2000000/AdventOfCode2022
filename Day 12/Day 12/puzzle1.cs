/*You ask the device for a heightmap of the surrounding area (your puzzle input). The heightmap shows the local area from above broken into a grid; the elevation of each square of the grid is given by a single lowercase letter, where a is the lowest elevation, b is the next-lowest, and so on up to the highest elevation, z.

Also included on the heightmap are marks for your current position (S) and the location that should get the best signal (E). Your current position (S) has elevation a, and the location that should get the best signal (E) has elevation z.

You'd like to reach E, but to save energy, you should do it in as few steps as possible. During each step, you can move exactly one square up, down, left, or right. To avoid needing to get out your climbing gear, the elevation of the destination square can be at most one higher than the elevation of your current square; that is, if your current elevation is m, you could step to elevation n, but not to elevation o. (This also means that the elevation of the destination square can be much lower than the elevation of your current square.)

For example:

Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi
Here, you start in the top-left corner; your goal is near the middle. You could start by moving down or right, but eventually you'll need to head toward the e at the bottom. From there, you can spiral around to the goal:

v..v<<<<
>v.vv<<^
.>vv>E^^
..v>>>^^
..>>>>>^
In the above diagram, the symbols indicate whether the path exits each square moving up (^), down (v), left (<), or right (>). The location that should get the best signal is still E, and . marks unvisited squares.

This path reaches the goal in 31 steps, the fewest possible.

What is the fewest steps required to move from your current position to the location that should get the best signal?*/
namespace Day_12
{
    internal static class puzzle1
    {
        internal static void main(string puzzleData) 
        {
            string[] mapLines=puzzleData.Split("\r\n");
            List<List<char>> map=new List<List<char>>();
            int myI = 0;
            int myJ = 0;
            int targetI = 0;
            int targetJ = 0;
            for(int i= 0;i<mapLines.Length;i++) //populate map list and gets relative positions
            {
                List<char> line=new List<char>();
                for(int j = 0; j < mapLines[i].Length;j++) 
                {
                    line.Add(mapLines[i][j]);
                    if (mapLines[i][j] == 'S') 
                    {
                        myI = i;
                        myJ=j;
                    }
                    if (mapLines[i][j] == 'E') 
                    {
                        targetI = i;
                        targetJ=j;
                    }
                }
                map.Add(line);
            }
            int stepsTaken = 0;
            while (map[myI][myJ] != 'E')//begin walking to hill 
            {
                (myI, myJ) = getBestStep(map, myI, myJ, targetI, targetJ);
                stepsTaken++;
            }
            Console.WriteLine("It took us " + stepsTaken + " to finish!");//outputs walk distance
        }
        internal static int getLetterValue(char letter) 
        {
            return ((int)letter)-96;
        }
        internal static (int, int) getBestStep(List<List<char>> map, int myI, int myJ, int targetI, int targetJ)//attempts to calculate best move ahead
        {
            int nextI = myI;
            int nextJ = myJ;
            int myDistanceFrom=(targetJ-myJ)+(targetI-myI);
            int bestDistanceFrom = myDistanceFrom;
            int bestI = myI;
            int bestJ= myJ;
            char letterOn;
            if (map[myI][myJ] == 'S')
            {
                letterOn = 'a';
            }
            else if (map[myI][myJ] == 'E')
            {
                letterOn = 'z';
            }
            else 
            {
                letterOn = map[myI][myJ];
            }
            if (myI != 0)
            {
                nextI= myI-1;
                nextJ= myJ;
                if (getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) || getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) - 1 || getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) + 1) 
                {
                    if (bestDistanceFrom > (targetI - nextI) + (targetJ - nextJ)) 
                    {
                        bestDistanceFrom= myDistanceFrom;
                        bestJ= myJ;
                        bestI = myI;
                    }
                }
            }
            if (myI != map.Count)
            {
                nextI= myI+1;
                nextJ= myJ;
                if (getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) || getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) - 1 || getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) + 1)
                {
                    if (bestDistanceFrom > (targetI - nextI) + (targetJ - nextJ))
                    {
                        bestDistanceFrom = myDistanceFrom;
                        bestJ = myJ;
                        bestI = myI;
                    }
                }
            }
            if (myJ != 0)
            {
                nextI = myI;
                nextJ= myJ-1;
                if (getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) || getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) - 1 || getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) + 1)
                {
                    if (bestDistanceFrom > (targetI - nextI) + (targetJ - nextJ))
                    {
                        bestDistanceFrom = myDistanceFrom;
                        bestJ = myJ;
                        bestI = myI;
                    }
                }
            }
            if (myJ != map[myI].Count) 
            {
                nextI = myI;
                nextJ = myJ + 1;
                if (getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) || getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) - 1 || getLetterValue(letterOn) == getLetterValue(map[nextI][nextJ]) + 1)
                {
                    if (bestDistanceFrom > (targetI - nextI) + (targetJ - nextJ))
                    {
                        bestDistanceFrom = myDistanceFrom;
                        bestJ = myJ;
                        bestI = myI;
                    }
                }
            }
            return (bestI, bestJ);
        }
    }
}
