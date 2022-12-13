/*Content with the amount of tree cover available, the Elves just need to know the best spot to build their tree house: they would like to be able to see a lot of trees.

To measure the viewing distance from a given tree, look up, down, left, and right from that tree; stop if you reach an edge or at the first tree that is the same height or taller than the tree under consideration. (If a tree is right on the edge, at least one of its viewing distances will be zero.)

The Elves don't care about distant trees taller than those found by the rules above; the proposed tree house has large eaves to keep it dry, so they wouldn't be able to see higher than the tree house anyway.

In the example above, consider the middle 5 in the second row:

30373
25512
65332
33549
35390
Looking up, its view is not blocked; it can see 1 tree (of height 3).
Looking left, its view is blocked immediately; it can see only 1 tree (of height 5, right next to it).
Looking right, its view is not blocked; it can see 2 trees.
Looking down, its view is blocked eventually; it can see 2 trees (one of height 3, then the tree of height 5 that blocks its view).
A tree's scenic score is found by multiplying together its viewing distance in each of the four directions. For this tree, this is 4 (found by multiplying 1 * 1 * 2 * 2).

However, you can do even better: consider the tree of height 5 in the middle of the fourth row:

30373
25512
65332
33549
35390
Looking up, its view is blocked at 2 trees (by another tree with a height of 5).
Looking left, its view is not blocked; it can see 2 trees.
Looking down, its view is also not blocked; it can see 1 tree.
Looking right, its view is blocked at 2 trees (by a massive tree of height 9).
This tree's scenic score is 8 (2 * 2 * 1 * 2); this is the ideal spot for the tree house.

Consider each tree on your map. What is the highest scenic score possible for any tree?*/
namespace Day_8
{
    internal static class puzzle2
    {
        public static void main(string puzzleData)
        {
            string[] gridLines = puzzleData.Split("\r\n");
            List<List<int>> grid = new List<List<int>>();//gets grid of numbers from puzzle data
            foreach (string line in gridLines)
            {
                List<int> toAdd = new List<int>();
                char[] characters = line.ToCharArray();
                foreach (char tree in characters)
                {
                    toAdd.Add(int.Parse(tree.ToString()));
                }
                grid.Add(toAdd);
            }
            int bestScenic = 0;//gets total viewable trees
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Count; j++)
                {
                    int testvalue = getScenicScore(grid, i, j);
                    if (bestScenic < testvalue)
                    {
                        bestScenic = testvalue;
                    }
                }
            }
            Console.WriteLine("The best scenic score is: " + bestScenic);
        }
        public static int getScenicScore(List<List<int>> grid, int row, int col)//gets a trees scenic score
        {
            int upScore = 0;
            int downScore = 0;
            int leftScore = 0;
            int rightScore = 0;
            upScore=checkUp(grid, row, col);
            downScore=checkDown(grid, row, col);
            rightScore=checkRight(grid, row, col);
            leftScore=checkLeft(grid, row, col);
            return upScore*downScore*leftScore*rightScore;
        }
        public static int checkUp(List<List<int>> grid, int row, int col) //counts until a tree is blocked
        {
            if (row != 0)
            {
                int treeCount = 0;
                for (int i = row - 1; i != -1; i--)
                {
                    treeCount++;
                    if (grid[i][col] >= grid[row][col])
                    {
                        break;
                    }
                }
                return treeCount;
            }
            return 0;
        }
        public static int checkDown(List<List<int>> grid, int row, int col)//checks down to see if view is blocked
        {
            if (row != grid.Count)
            {
                int treeCount = 0;
                for (int i = row+1; i != grid.Count; i++)
                {
                    treeCount++;
                    if (grid[i][col] >= grid[row][col])
                    {
                        break;
                    }
                }
                return treeCount;
            }
            return 0;
        }
        public static int checkLeft(List<List<int>> grid, int row, int col)//checks left to see if view is blocked
        {
            if (col != 0)
            {
                int treeCount = 0;
                for (int j = col - 1; j != -1; j--)
                {
                    treeCount++;
                    if (grid[row][j] >= grid[row][col])
                    {
                        break;
                    }
                }
                return treeCount;
            }
            return 0;
        }
        public static int checkRight(List<List<int>> grid, int row, int col)//checks right to see if view is blocked
        {
            if (col != grid[row].Count)
            {
                int treeCount = 0;
                for (int j = col + 1; j != grid[row].Count; j++)
                {
                    treeCount++;
                    if (grid[row][j] >= grid[row][col])
                    {
                        break;
                    }
                }
                return treeCount;
            }
            return 0;
        }
    }
}
