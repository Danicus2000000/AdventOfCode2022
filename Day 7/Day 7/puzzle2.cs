/*Now, you're ready to choose a directory to delete.

The total disk space available to the filesystem is 70000000. To run the update, you need unused space of at least 30000000. You need to find a directory you can delete that will free up enough space to run the update.

In the example above, the total size of the outermost directory (and thus the total amount of used space) is 48381165; this means that the size of the unused space must currently be 21618835, which isn't quite the 30000000 required by the update. Therefore, the update still requires a directory with total size of at least 8381165 to be deleted before it can run.

To achieve this, you have the following options:

Delete directory e, which would increase unused space by 584.
Delete directory a, which would increase unused space by 94853.
Delete directory d, which would increase unused space by 24933642.
Delete directory /, which would increase unused space by 48381165.
Directories e and a are both too small; deleting them would not free up enough space. However, directories d and / are both big enough! Between these, choose the smallest: d, increasing unused space by 24933642.

Find the smallest directory that, if deleted, would free up enough space on the filesystem to run the update. What is the total size of that directory?*/
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
