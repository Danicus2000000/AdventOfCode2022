/*The device will send your subroutine a datastream buffer (your puzzle input); your subroutine needs to identify the first position where the four most recently received characters were all different. Specifically, it needs to report the number of characters from the beginning of the buffer to the end of the first such four-character marker.

For example, suppose you receive the following datastream buffer:

mjqjpqmgbljsphdztnvjfqwrcgsmlb
After the first three characters (mjq) have been received, there haven't been enough characters received yet to find the marker. The first time a marker could occur is after the fourth character is received, making the most recent four characters mjqj. Because j is repeated, this isn't a marker.

The first time a marker appears is after the seventh character arrives. Once it does, the last four characters received are jpqm, which are all different. In this case, your subroutine should report the value 7, because the first start-of-packet marker is complete after 7 characters have been processed.

Here are a few more examples:

bvwbjplbgvbhsrlpgdmjqwftvncz: first marker after character 5
nppdvjthqldpwncqszvftbrmjlhg: first marker after character 6
nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg: first marker after character 10
zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw: first marker after character 11
How many characters need to be processed before the first start-of-packet marker is detected?*/
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