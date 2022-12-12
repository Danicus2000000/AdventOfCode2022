using Day_6;

string dataIn = File.ReadAllText("puzzleData.txt");
string[] currentCheck = {"","","","" };
int next = 0;
int index = 1;
foreach (char cur in dataIn)
{
    currentCheck[next] = cur.ToString();
    if(!currentCheck.Contains(""))
    {
        bool isUnique = true;
        for (int i = 0; i < currentCheck.Length; i++) 
        {
            for (int j = 0; j < currentCheck.Length; j++)
            {
                if (currentCheck[i] == currentCheck[j] && i!=j)
                {
                    isUnique = false;
                }
            }
        }
        if (isUnique) 
        {
            Console.WriteLine("First unique start of packet marker found at: " + index);
            break;
        }
    }
    if (next == 3) { next = 0; }
    else { next++; }
    index++;
}
puzzle2 puz = new puzzle2();
puz.main();