namespace Day_7
{
    internal class dirNode
    {
        public string fileName;
        public int size;
        public dirNode? parent;
        public List<dirNode>? children;
        public bool isDir;

        public dirNode(string fileName, int size, dirNode parent)
        {
            this.fileName = fileName;
            this.size = size;
            this.parent = parent;
            this.isDir = false;
        }
        public dirNode(string dirName, dirNode parent) 
        {
            this.fileName = dirName;
            this.parent = parent;
            this.children = new List<dirNode>();
            this.isDir = true;
            this.size=0;
        } 
        public dirNode() 
        {
            this.isDir = true;
            this.fileName= "/";
            this.children=new List<dirNode>();
            this.size = 0;
        }
        public void addChild(dirNode child) 
        {
            children.Add(child);
            if (!child.isDir) 
            {
                dirNode temp = child;
                while (temp.parent != null) 
                {
                    temp.parent.size += child.size;
                    temp= temp.parent;
                }
            }
        }
    }
}
