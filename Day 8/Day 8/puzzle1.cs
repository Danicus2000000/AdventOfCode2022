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
            int totalViewable = 0;
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
            bool rightClear = true;
            bool leftClear = true;
            bool upClear = true;
            bool downClear = true;
            bool isOutside= false;
            if (row - 1 == -1 || row+1==grid.Count+1 || col-1==-1 || col + 1 == grid[row].Count+1) 
            {
                isOutside= true;
            }
            if (isOutside || checkUp(grid, col, row) || checkDown(grid, col, row) || checkLeft(grid, col, row) || checkRight(grid, col, row)) 
            {
                return true;
            }
            return false;
        }
        public static bool checkUp(List<List<int>> grid, int row, int col) 
        {
            return false;
        }
        public static bool checkDown(List<List<int>> grid, int row, int col)
        {
            return false;
        }
        public static bool checkLeft(List<List<int>> grid, int row, int col)
        {
            return false;
        }
        public static bool checkRight(List<List<int>> grid, int row, int col)
        {
            return false;
        }

    }
}
