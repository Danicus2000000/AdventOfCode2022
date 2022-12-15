using Day_12;

string puzzleData = File.ReadAllText("puzzleData.txt");
puzzle.parse(puzzleData.Split("\r\n").ToList());