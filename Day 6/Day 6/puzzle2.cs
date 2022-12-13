/*Your device's communication system is correctly detecting packets, but still isn't working. It looks like it also needs to look for messages.

A start-of-message marker is just like a start-of-packet marker, except it consists of 14 distinct characters rather than 4.

Here are the first positions of start-of-message markers for all of the above examples:

mjqjpqmgbljsphdztnvjfqwrcgsmlb: first marker after character 19
bvwbjplbgvbhsrlpgdmjqwftvncz: first marker after character 23
nppdvjthqldpwncqszvftbrmjlhg: first marker after character 23
nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg: first marker after character 29
zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw: first marker after character 26
How many characters need to be processed before the first start-of-message marker is detected?*/
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
