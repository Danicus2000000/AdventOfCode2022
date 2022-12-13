/*The Elves have already launched a quadcopter to generate a map with the height of each tree (your puzzle input). For example:

30373
25512
65332
33549
35390
Each tree is represented as a single digit whose value is its height, where 0 is the shortest and 9 is the tallest.

A tree is visible if all of the other trees between it and an edge of the grid are shorter than it. Only consider trees in the same row or column; that is, only look up, down, left, or right from any given tree.

All of the trees around the edge of the grid are visible - since they are already on the edge, there are no trees to block the view. In this example, that only leaves the interior nine trees to consider:

The top-left 5 is visible from the left and top. (It isn't visible from the right or bottom since other trees of height 5 are in the way.)
The top-middle 5 is visible from the top and right.
The top-right 1 is not visible from any direction; for it to be visible, there would need to only be trees of height 0 between it and an edge.
The left-middle 5 is visible, but only from the right.
The center 3 is not visible from any direction; for it to be visible, there would need to be only trees of at most height 2 between it and an edge.
The right-middle 3 is visible from the right.
In the bottom row, the middle 5 is visible, but the 3 and 4 are not.
With 16 trees visible on the edge and another 5 visible in the interior, a total of 21 trees are visible in this arrangement.

Consider your map; how many trees are visible from outside the grid?*/
namespace Day_8
{
    internal static class puzzle1
    {
        public static void main(string puzzleData) 
        {
            string[] gridLines = puzzleData.Split("\r\n");
            List<List<int>> grid = new List<List<int>>();//gets grid of numbers from puzzle data
            foreach(string line in gridLines) 
            {
                List<int> toAdd=new List<int>();
                char[] characters=line.ToCharArray();
                foreach (char tree in characters) 
                {
                    toAdd.Add(int.Parse(tree.ToString()));
                }
                grid.Add(toAdd);
            }
            int totalViewable = 0;//gets total viewable trees
            for(int i=0;i<grid.Count;i++) 
            {
                for (int j = 0; j < grid[i].Count; j++) 
                {
                    if (checkViewable(grid, i, j)) 
                    {
                        totalViewable++;
                    }
                }
            }
            Console.WriteLine("The total amount of viewable trees is: " + totalViewable);
        }
        public static bool checkViewable(List<List<int>> grid,int row,int col)//check if a tree is viewable
        {
            bool isOutside= false;
            if (row - 1 == -1 || row+1==grid.Count || col-1==-1 || col + 1 == grid[row].Count) 
            {
                isOutside= true;
            }
            if (isOutside || checkUp(grid, col, row) || checkDown(grid, col, row) || checkLeft(grid, col, row) || checkRight(grid, col, row)) 
            {
                return true;
            }
            return false;
        }
        public static bool checkUp(List<List<int>> grid, int row, int col) //checks up to see if view is blocked
        {
            int tallestTreeAhead = 0;
            for (int i = row-1; i != -1; i--) 
            {
                if (grid[i][col] > tallestTreeAhead) 
                {
                    tallestTreeAhead = grid[i][col];
                }
            }
            if (grid[row][col] > tallestTreeAhead) 
            {
                return true;
            }
            return false;
        }
        public static bool checkDown(List<List<int>> grid, int row, int col)//checks down to see if view is blocked
        {
            int tallestTreeAhead = 0;
            for (int i = row + 1; i!=grid.Count; i++)
            {
                if (grid[i][col] > tallestTreeAhead)
                {
                    tallestTreeAhead = grid[i][col];
                }
            }
            if (grid[row][col] > tallestTreeAhead)
            {
                return true;
            }
            return false;
        }
        public static bool checkLeft(List<List<int>> grid, int row, int col)//checks left to see if view is blocked
        {
            int tallestTreeAhead = 0;
            for (int j = col - 1; j != -1; j--)
            {
                if (grid[row][j] > tallestTreeAhead)
                {
                    tallestTreeAhead = grid[row][j];
                }
            }
            if (grid[row][col] > tallestTreeAhead)
            {
                return true;
            }
            return false;
        }
        public static bool checkRight(List<List<int>> grid, int row, int col)//checks right to see if view is blocked
        {
            int tallestTreeAhead = 0;
            for (int j = col + 1; j != grid.Count; j++)
            {
                if (grid[row][j] > tallestTreeAhead)
                {
                    tallestTreeAhead = grid[row][j];
                }
            }
            if (grid[row][col] > tallestTreeAhead)
            {
                return true;
            }
            return false;
        }

    }
}
