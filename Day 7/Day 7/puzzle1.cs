using Day_7;

string data = File.ReadAllText("puzzleData.txt");//gets text file data
string[] consoleLines = data.Split("\r\n");//splits input by line
Dictionary<string, int> directorySizes = new Dictionary<string, int>();//creates dictionary lookup of addresses to size
string curDirectory = "";
for (int i=0;i<consoleLines.Length;i++) //loops through all instructions
{
    if (consoleLines[i].Contains("$"))//if it is a command
    {
        if (consoleLines[i].Contains("cd /"))//go to base directory
        {
            curDirectory = "/";
        }
        else if (consoleLines[i].Contains("cd .."))//go back a directory if we are not in base directory
        {
            if (curDirectory != "/")
            {
                string replace = curDirectory.Split("/")[curDirectory.Split("/").Length - 2] + "/";
                curDirectory = curDirectory.Replace(replace, "");
            }
        }
        else if (consoleLines[i].Contains("cd")) //go to specific directory
        {
            curDirectory += consoleLines[i].Replace("$ cd ", "")+"/";
        }
        if (consoleLines[i].Contains("ls"))//if we want to list files in curent directory
        {
            for(int j = i + 1;j!=consoleLines.Length && !consoleLines[j].Contains("$");j++)//loop through lines until the next command or hit end of console lines
            {
                if (consoleLines[j].Contains("dir"))//if a directory is found do nothing
                {
                    //nothing to see here
                }
                else//increments size of current directory if it exists otherwise adds it
                {
                    int size = Convert.ToInt32(consoleLines[j].Split(" ")[0]);
                    string filename = consoleLines[j].Split(" ")[1];
                    if (directorySizes.ContainsKey(curDirectory))
                    {
                        directorySizes[curDirectory] += size;
                    }
                    else 
                    {
                        directorySizes.Add(curDirectory, size);
                    }
                }
            }
        }
    }
}
for (int i = 0; i < directorySizes.Count; i++)//adds sub directories to parent directories counter
{
    for (int j = 0; j < directorySizes.Count; j++)
    {
        if (i != j && directorySizes.ElementAt(j).Key.Contains(directorySizes.ElementAt(i).Key))
        {
            directorySizes[directorySizes.ElementAt(i).Key] += directorySizes.ElementAt(j).Value;
        }
    }
}
int totalSum = 0;
Console.WriteLine("The directories less than 100000:");
foreach (KeyValuePair<string,int> value in directorySizes) //print out all directories values
{
    if (value.Value <= 100000)
    {
        Console.WriteLine(value.Key + ": " + value.Value);
        totalSum += value.Value;
    }
}
Console.WriteLine("The sum of those directories: " + totalSum);
puzzle2 puz = new puzzle2();
puz.main();