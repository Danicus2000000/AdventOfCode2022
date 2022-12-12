using Day_7;

string data = File.ReadAllText("puzzleData.txt");
string[] consoleLines = data.Split("\r\n");
List<Dictionary<string, int>> directorySizes = new List<Dictionary<string, int>>();
string curDirectory = "";
for (int i=0;i<consoleLines.Length;i++) 
{
    if (consoleLines[i].Contains("$"))
    {
        if (consoleLines[i].Contains("cd /"))//go to base directory
        {
            curDirectory = "/";
        }
        else if (consoleLines[i].Contains("cd .."))//go back a directory
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
        else if (consoleLines[i].Contains("ls"))
        {
            while (!consoleLines[i].Contains("$")) 
            {

            }
        }
        Console.WriteLine(curDirectory);
    }
}
puzzle2 puz = new puzzle2();
puz.main();