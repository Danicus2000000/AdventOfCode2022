namespace Day_7
{
    internal static class puzzle2
    {
        public static void main(string puzzleData) 
        {
            string[] commandLines = puzzleData.Split("\r\n");
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
                string[] lineSplit = line.Split(" ");//if dir or file add as child of current dir
                if (lineSplit[0] == "dir")
                {
                    currentnode.addChild(new dirNode(lineSplit[^1], currentnode));
                }
                else
                {
                    currentnode.addChild(new dirNode(lineSplit[^1], int.Parse(lineSplit[0]), currentnode));
                }
            }
            Queue<dirNode> unExplored = new Queue<dirNode>();//calculate smallest file that could allow for update
            unExplored.Enqueue(node);
            int totalFileSystemSpace = 70000000;
            int requiredSpace = 30000000;
            int neededspace = requiredSpace - (totalFileSystemSpace - node.size);
            int bestSize = int.MaxValue;
            while (unExplored.Count > 0)
            {
                dirNode nodeSizeCheck = unExplored.Dequeue();
                if (nodeSizeCheck.size >= neededspace && nodeSizeCheck.size<bestSize)
                {
                    bestSize= nodeSizeCheck.size;
                }
                foreach (dirNode enququeNode in nodeSizeCheck.children)
                {
                    if (enququeNode.isDir)
                    {
                        unExplored.Enqueue(enququeNode);
                    }
                }
            }
            Console.WriteLine("File size of best file to delete: " + bestSize);
        }
    }
}
