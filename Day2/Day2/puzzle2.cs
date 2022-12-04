using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*The Elf finishes helping with the tent and sneaks back over to you. "Anyway, the second column says how the round needs to end: X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win. Good luck!"

The total score is still calculated in the same way, but now you need to figure out what shape to choose so the round ends as indicated. The example above now goes like this:

In the first round, your opponent will choose Rock (A), and you need the round to end in a draw (Y), so you also choose Rock. This gives you a score of 1 + 3 = 4.
In the second round, your opponent will choose Paper (B), and you choose Rock so you lose (X) with a score of 1 + 0 = 1.
In the third round, you will defeat your opponent's Scissors with Rock for a score of 1 + 6 = 7.
Now that you're correctly decrypting the ultra top secret strategy guide, you would get a total score of 12.

Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide?*/
namespace Day2
{
    internal class puzzle2
    {
        internal void main()
        {
            string puzzleData = File.ReadAllText("puzzleData.txt").Replace(" ", "");
            string[] matches = puzzleData.Split("\r\n");
            int totalScore = 0;
            foreach (string match in matches)
            {
                totalScore += calculatematch(match.ToUpper());
            }
            Console.WriteLine("The real total score of the matches was: " + totalScore);
        }
        internal int calculatematch(string matchData)
        {
            char[] weapon = matchData.ToCharArray();
            if (weapon[0] == 'A' && weapon[1] == 'X')
            {
                return 3;
            }
            else if (weapon[0] == 'A' && weapon[1] == 'Y')
            {
                return 4;
            }
            else if (weapon[0] == 'A' && weapon[1] == 'Z')
            {
                return 8;
            }
            else if (weapon[0] == 'B' && weapon[1] == 'X')
            {
                return 1;
            }
            else if (weapon[0] == 'B' && weapon[1] == 'Y')
            {
                return 5;
            }
            else if (weapon[0] == 'B' && weapon[1] == 'Z')
            {
                return 9;
            }
            else if (weapon[0] == 'C' && weapon[1] == 'X')
            {
                return 2;
            }
            else if (weapon[0] == 'C' && weapon[1] == 'Y')
            {
                return 6;
            }
            else if (weapon[0] == 'C' && weapon[1] == 'Z')
            {
                return 7;
            }
            throw new InvalidDataException();
        }
    }
}
