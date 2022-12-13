namespace Day_7
{
    internal static class puzzle1
    {
        public static void main(string puzzleData) 
        {
            string[] commandLines=puzzleData.Split("\r\n");
            dirNode node = new();
            dirNode currentnode = node;
            foreach (string line in commandLines)
            {
                if (line.First() == '$')//if it is a command
                {
                    if (line.Contains("cd /"))//go to base directory
                    {
                        currentnode = node;
                        continue;
                    }
                    else if (line.Contains("cd .."))//go back a directory if we are not in base directory
                    {
                        if (currentnode.parent is not null)
                        {
                            currentnode = currentnode.parent;
                        }
                        continue;
                    }
                    else if (line.Contains("cd")) //go to specific directory
                    {
                        currentnode = currentnode.children.Find(childNode => childNode.fileName == line.Split(" ")[^1]);
                        continue;
                    }
                    else//if ls continue
                    {
                        continue;
                    }
                }
                string[] lineSplit = line.Split(" ");//if ls has been used and file and dirs are present add them as children
                if (lineSplit[0] == "dir")
                {
                    currentnode.addChild(new dirNode(lineSplit[^1], currentnode));
                }
                else
                {
                    currentnode.addChild(new dirNode(lineSplit[^1], int.Parse(lineSplit[0]), currentnode));
                }
            }
            Queue<dirNode> unExplored=new Queue<dirNode>();//explore children and calculate total of all files less than or equal to 100000
            unExplored.Enqueue(node);
            int totalSize = 0;
            while(unExplored.Count > 0) 
            {
                dirNode nodeSizeCheck=unExplored.Dequeue();
                if (nodeSizeCheck.size <= 100000) 
                {
                    totalSize+=nodeSizeCheck.size;
                }
                foreach (dirNode enququeNode in nodeSizeCheck.children) 
                {
                    if (enququeNode.isDir) 
                    {
                        unExplored.Enqueue(enququeNode);
                    }
                }
            }
            Console.WriteLine("Total size of directories less than or equal to 100000: " + totalSize);
        }
    }
}
