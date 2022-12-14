/*The CPU uses these instructions in a program (your puzzle input) to, somehow, tell the screen what to draw.

Consider the following small program:

noop
addx 3
addx -5
Execution of this program proceeds as follows:

At the start of the first cycle, the noop instruction begins execution. During the first cycle, X is 1. After the first cycle, the noop instruction finishes execution, doing nothing.
At the start of the second cycle, the addx 3 instruction begins execution. During the second cycle, X is still 1.
During the third cycle, X is still 1. After the third cycle, the addx 3 instruction finishes execution, setting X to 4.
At the start of the fourth cycle, the addx -5 instruction begins execution. During the fourth cycle, X is still 4.
During the fifth cycle, X is still 4. After the fifth cycle, the addx -5 instruction finishes execution, setting X to -1.
Maybe you can learn something by looking at the value of the X register throughout execution. For now, consider the signal strength (the cycle number multiplied by the value of the X register) during the 20th cycle and every 40 cycles after that (that is, during the 20th, 60th, 100th, 140th, 180th, and 220th cycles).

For example, consider this larger program:

addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop
The interesting signal strengths can be determined as follows:

During the 20th cycle, register X has the value 21, so the signal strength is 20 * 21 = 420. (The 20th cycle occurs in the middle of the second addx -1, so the value of register X is the starting value, 1, plus all of the other addx values up to that point: 1 + 15 - 11 + 6 - 3 + 5 - 1 - 8 + 13 + 4 = 21.)
During the 60th cycle, register X has the value 19, so the signal strength is 60 * 19 = 1140.
During the 100th cycle, register X has the value 18, so the signal strength is 100 * 18 = 1800.
During the 140th cycle, register X has the value 21, so the signal strength is 140 * 21 = 2940.
During the 180th cycle, register X has the value 16, so the signal strength is 180 * 16 = 2880.
During the 220th cycle, register X has the value 18, so the signal strength is 220 * 18 = 3960.
The sum of these signal strengths is 13140.

Find the signal strength during the 20th, 60th, 100th, 140th, 180th, and 220th cycles. What is the sum of these six signal strengths?*/
namespace Day_10
{
    internal static class puzzle1
    {
        public static void main(string puzzleData) 
        {
            string[] cpuLines=puzzleData.Split("\r\n");//gets cpu lines
            int registerX = 1;//stores register x value
            int cycle = 1;//stores the current cycle the cpu is on
            int line = 0;//stores the line of code currently being executed
            bool isNooping = false;//stores whether the code is doing the noop comand
            bool isAdding = false;//stores whether an add is in progress
            int cycleSinceAdd = 0;//stores cycles occured since add started
            int signalStrength = 0;//stores total signal strength
            while (cpuLines.Length !=line)//while the cpu has instructions
            {
                if (!isNooping && !isAdding)//if we are not doing a command
                {
                    string[] instructionParts = cpuLines[line].Split(" ");//get the next one
                    if (instructionParts[0] == "noop")
                    {
                        isNooping = true;
                    }
                    else 
                    {
                        isAdding = true;
                    }
                }
                if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220) //if we hit a milestone cycle add to signal strength
                {
                    signalStrength += cycle * registerX;
                }
                cycle++;//increment cycle and perform instruction progress checks at end of cycle
                if (isNooping)//if we are nooping noop finishes in one cycle so completes imedietly
                {
                    isNooping = false;
                    line++;
                }
                else if (isAdding)//if we are adding adding completes in 2 cycles so completes after another loop
                {
                    cycleSinceAdd++;
                    if (cycleSinceAdd == 2)//if add complete
                    {
                        cycleSinceAdd = 0;//reset add
                        isAdding = false;
                        registerX += int.Parse(cpuLines[line].Split(" ")[1]);//add value requested to register
                        line++;//perform next line
                    }
                }
            }
            Console.WriteLine("The sum of signal strengths is: " + signalStrength);//output result
        }
    }
}
