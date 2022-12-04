// See https://aka.ms/new-console-template for more information
string rawData = File.ReadAllText("puzzleData.txt");
Dictionary<string,string> rucksacks= new Dictionary<string,string>();
string[] rucksackRaw = rawData.Split("\r\n");
foreach(string sack in rucksackRaw) 
{
    rucksacks.Add(sack.Substring(0, sack.Length / 2), sack.Substring(sack.Length / 2));
}