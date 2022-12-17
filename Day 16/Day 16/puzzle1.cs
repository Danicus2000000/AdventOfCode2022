/*You scan the cave for other options and discover a network of pipes and pressure-release valves. You aren't sure how such a system got into a volcano, but you don't have time to complain; your device produces a report (your puzzle input) of each valve's flow rate if it were opened (in pressure per minute) and the tunnels you could use to move between the valves.

There's even a valve in the room you and the elephants are currently standing in labeled AA. You estimate it will take you one minute to open a single valve and one minute to follow any tunnel from one valve to another. What is the most pressure you could release?

For example, suppose you had the following scan output:

Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=2; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE
Valve EE has flow rate=3; tunnels lead to valves FF, DD
Valve FF has flow rate=0; tunnels lead to valves EE, GG
Valve GG has flow rate=0; tunnels lead to valves FF, HH
Valve HH has flow rate=22; tunnel leads to valve GG
Valve II has flow rate=0; tunnels lead to valves AA, JJ
Valve JJ has flow rate=21; tunnel leads to valve II
All of the valves begin closed. You start at valve AA, but it must be damaged or jammed or something: its flow rate is 0, so there's no point in opening it. However, you could spend one minute moving to valve BB and another minute opening it; doing so would release pressure during the remaining 28 minutes at a flow rate of 13, a total eventual pressure release of 28 * 13 = 364. Then, you could spend your third minute moving to valve CC and your fourth minute opening it, providing an additional 26 minutes of eventual pressure release at a flow rate of 2, or 52 total pressure released by valve CC.

Making your way through the tunnels like this, you could probably open many or all of the valves by the time 30 minutes have elapsed. However, you need to release as much pressure as possible, so you'll need to be methodical. Instead, consider this approach:

== Minute 1 ==
No valves are open.
You move to valve DD.

== Minute 2 ==
No valves are open.
You open valve DD.

== Minute 3 ==
Valve DD is open, releasing 20 pressure.
You move to valve CC.

== Minute 4 ==
Valve DD is open, releasing 20 pressure.
You move to valve BB.

== Minute 5 ==
Valve DD is open, releasing 20 pressure.
You open valve BB.

== Minute 6 ==
Valves BB and DD are open, releasing 33 pressure.
You move to valve AA.

== Minute 7 ==
Valves BB and DD are open, releasing 33 pressure.
You move to valve II.

== Minute 8 ==
Valves BB and DD are open, releasing 33 pressure.
You move to valve JJ.

== Minute 9 ==
Valves BB and DD are open, releasing 33 pressure.
You open valve JJ.

== Minute 10 ==
Valves BB, DD, and JJ are open, releasing 54 pressure.
You move to valve II.

== Minute 11 ==
Valves BB, DD, and JJ are open, releasing 54 pressure.
You move to valve AA.

== Minute 12 ==
Valves BB, DD, and JJ are open, releasing 54 pressure.
You move to valve DD.

== Minute 13 ==
Valves BB, DD, and JJ are open, releasing 54 pressure.
You move to valve EE.

== Minute 14 ==
Valves BB, DD, and JJ are open, releasing 54 pressure.
You move to valve FF.

== Minute 15 ==
Valves BB, DD, and JJ are open, releasing 54 pressure.
You move to valve GG.

== Minute 16 ==
Valves BB, DD, and JJ are open, releasing 54 pressure.
You move to valve HH.

== Minute 17 ==
Valves BB, DD, and JJ are open, releasing 54 pressure.
You open valve HH.

== Minute 18 ==
Valves BB, DD, HH, and JJ are open, releasing 76 pressure.
You move to valve GG.

== Minute 19 ==
Valves BB, DD, HH, and JJ are open, releasing 76 pressure.
You move to valve FF.

== Minute 20 ==
Valves BB, DD, HH, and JJ are open, releasing 76 pressure.
You move to valve EE.

== Minute 21 ==
Valves BB, DD, HH, and JJ are open, releasing 76 pressure.
You open valve EE.

== Minute 22 ==
Valves BB, DD, EE, HH, and JJ are open, releasing 79 pressure.
You move to valve DD.

== Minute 23 ==
Valves BB, DD, EE, HH, and JJ are open, releasing 79 pressure.
You move to valve CC.

== Minute 24 ==
Valves BB, DD, EE, HH, and JJ are open, releasing 79 pressure.
You open valve CC.

== Minute 25 ==
Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.

== Minute 26 ==
Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.

== Minute 27 ==
Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.

== Minute 28 ==
Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.

== Minute 29 ==
Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.

== Minute 30 ==
Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.
This approach lets you release the most pressure possible in 30 minutes with this valve layout, 1651.

Work out the steps to release the most pressure in 30 minutes. What is the most pressure you can release?*/
namespace Day_16
{
    internal static class puzzle1
    {
        internal static void main(string puzzleData) 
        {
            var watch=new System.Diagnostics.Stopwatch();
            watch.Start();
            string[] valveLines=puzzleData.Split(Environment.NewLine);
            List<valve> valveOptions= new List<valve>();
            for(int i=0;i<valveLines.Length;i++) //adds valves and their children
            {
                string[] words= valveLines[i].Split(" ");
                string vaulveName= words[1];//gets values to add new valve
                int flowRate = int.Parse(words[4].Replace("rate=","").Replace(";",""));
                valve currentValve = new valve(flowRate, vaulveName);//adds valve
                valveOptions.Add(currentValve);
                List<string> tunnelNames=words.Where(word=>char.IsUpper(word,1)).ToList();//gets children valves from list
                tunnelNames.RemoveAt(0);
                for (int j = 0; j < tunnelNames.Count; j++)//get pure tunnel names
                {
                    tunnelNames[j]=tunnelNames[j].Replace(",", "");
                    for (int k = 0; k < valveOptions.Count; k++) //populate children of valves
                    {
                        if (tunnelNames[j] == valveOptions[k].mValveName) 
                        {
                            currentValve.mConnectedValves.Add(valveOptions[k]);
                            valveOptions[k].mConnectedValves.Add(currentValve);
                        }
                    }
                }
            }
            valveOptions[0].mIsTurned = true;//because first valve is worth zero may as well leave it turned
            Queue<valve> queue = new Queue<valve>();
            queue.Enqueue(valveOptions[0]);
            while(queue.Count > 0) //only checks one path need to allow reset 
            {
                valve curValve= queue.Peek();
                if (curValve.mMinuitesLeft == 0) 
                {
                    break;
                }
                if (!curValve.mIsTurned)
                {
                    curValve.mIsTurned = true;
                    curValve.mMinuitesLeft--;
                }
                else 
                {
                    List<valve> toLookNext = curValve.mConnectedValves;
                    if (curValve.mParent != null && curValve.mIsTurned) 
                    {
                        curValve.mPressureReleased=curValve.mParent.mPressureReleased+(curValve.mPressureValue*curValve.mMinuitesLeft);
                        toLookNext.Remove(curValve.mParent);
                    }
                    foreach (valve valve in toLookNext) 
                    {
                        valve.mMinuitesLeft = curValve.mMinuitesLeft - 1;
                        valve.mParent = curValve;
                        queue.Enqueue(valve);
                    }
                    queue.Dequeue();
                }
            }
            watch.Stop();
            int bestPressure = 0;
            foreach(valve valve in valveOptions) 
            {
                if (valve.mPressureReleased > bestPressure) 
                {
                    bestPressure = valve.mPressureReleased;
                }
            }
            Console.WriteLine("we released "+bestPressure+" pressure, Completed in: " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
