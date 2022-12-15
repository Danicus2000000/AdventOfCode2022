using System;
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
/*As you walk up the hill, you suspect that the Elves will want to turn this into a hiking trail. The beginning isn't very scenic, though; perhaps you can find a better starting point.

To maximize exercise while hiking, the trail should start as low as possible: elevation a. The goal is still the square marked E. However, the trail should still be direct, taking the fewest steps to reach its goal. So, you'll need to find the shortest path from any square at elevation a to the square marked E.

Again consider the example from above:

Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi
Now, there are six choices for starting position (five marked a, plus the square marked S that counts as being at elevation a). If you start at the bottom-left square, you can reach the goal most quickly:

...v<<<<
...vv<<^
...v>E^^
.>v>>>^^
>^>>>>>^
This path reaches the goal in only 29 steps, the fewest possible.

What is the fewest steps required to move starting from any square with elevation a to the location that should get the best signal?*/
namespace Day_12
{
    internal static class puzzle
    {
        private static char[,] map = new char[0, 0];//intialises map size
        private static int[,] distance = new int[0, 0], prev = new int[0, 0];//intialises distance matrix
        private static List<(int, int)> lowestPoints = new List<(int, int)>();//intialises list of low down tiles
        private static int mapWidth, mapHeight, selfX, selfY, targetX, targetY, generation;//intialises width, height, self x, self y, target x,target y and generation counters
        internal static void parse(List<string> input)
        {
            mapWidth = input[0].Length;//load data
            mapHeight = input.Count;
            map = new char[mapWidth, mapHeight];
            distance = new int[mapWidth, mapHeight];
            prev = new int[mapWidth, mapHeight];
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)//loop through map adding data points to the map
                {
                    map[x, y] = input[y][x];
                    distance[x, y] = 0;
                    if (map[x, y] == 'S') //if self is found set self x and self y and change map to true value
                    { 
                        selfX = x; 
                        selfY = y; 
                        map[x, y] = 'a'; 
                    }
                    if (map[x, y] == 'E') //if target is found set target x and target y and  change map to true value
                    { 
                        targetX = x; 
                        targetY = y; 
                        map[x, y] = 'z'; }
                    if (map[x, y] == 'a') //if we find an a add it to all the low points for puzzle two
                    { 
                        lowestPoints.Add((x, y)); 
                    }
                }
            }
            Console.WriteLine("Fewest steps required to get from current location to best siganl strength: " + BreadthFirstSearch(new List<(int, int)> { (selfX, selfY) }).ToString());//output puzzle solutions
            Console.WriteLine("Fewest steps required to get from any square 'a' to best signal location: " + BreadthFirstSearch(lowestPoints).ToString());
        }

        private static int BreadthFirstSearch(List<(int, int)> start)
        {
            List<(int, int)> stack = start;//copies start list for manipulation
            List<(int, int)> directions = new List<(int, int)> { (-1, 0), (1, 0), (0, -1), (0, 1) };//list of possible directions to move from current direction
            generation += 10000;
            int curDistance = ++generation;
            foreach ((int selfX, int selfY) in start) //set each value as start point (used for puzzle 2) 
            { 
                distance[selfX, selfY] = curDistance; 
            }
            while (stack.Count > 0)//while there are points to explore
            {
                List<(int, int)> next = new List<(int, int)>();//next tile to move to
                curDistance++;//increment distance
                foreach ((int cx, int cy) in stack)//foreach current position in the stack (part 2)
                {
                    foreach ((int dx, int dy) in directions)//foreach direction to check
                    {
                        int nx = cx + dx, ny = cy + dy;//get the value that the next x and y coord would be
                        if (nx >= 0 && nx < mapWidth && ny >= 0 && ny < mapHeight)//if they are valid
                        {
                            if (distance[nx, ny] < generation && map[nx, ny] <= map[cx, cy] + 1)//if the distance is less than max and we can move that height
                            {
                                prev[nx, ny] = cy * 1000 + cx;//incremnet value
                                if ((nx, ny) == (targetX, targetY)) //if we have hit the target coords stop and return moves
                                { 
                                    return curDistance - generation; 
                                }
                                distance[nx, ny] = curDistance;//otherwise record the distance it took as the current distance and add the next tile with its values on the stack to recurse
                                next.Add((nx, ny));
                            }
                        }
                    }
                }
                stack = next;//once all possibilites are checked check another tile out
            }
            return -1;//if this loop fails return error code
        }
    }
}
