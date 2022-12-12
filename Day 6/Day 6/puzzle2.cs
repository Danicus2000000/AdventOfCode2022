namespace Day_6
{
    internal class puzzle2
    {
        internal void main() 
        {
            string dataIn = File.ReadAllText("puzzleData.txt");
            string[] currentCheck = { "", "", "","","","","","","","","","","","" };
            int next = 0;
            int index = 1;
            foreach (char cur in dataIn)
            {
                currentCheck[next] = cur.ToString();
                if (!currentCheck.Contains(""))
                {
                    bool isUnique = true;
                    for (int i = 0; i < currentCheck.Length; i++)
                    {
                        for (int j = 0; j < currentCheck.Length; j++)
                        {
                            if (currentCheck[i] == currentCheck[j] && i != j)
                            {
                                isUnique = false;
                            }
                        }
                    }
                    if (isUnique)
                    {
                        Console.WriteLine("First unique start of message marker found at: " + index);
                        break;
                    }
                }
                if (next == 13) { next = 0; }
                else { next++; }
                index++;
            }
        }
    }
}
