namespace AoC2024.days;

public class Day2 : Day
{
    public Day2(string inputFilePath) : base(inputFilePath)
    {
    }

    public int Part1()
    {
        var inputArrays = processInput(Input);
        var safeReports = 0;
        foreach (var report in inputArrays)
        {
            safeReports += isSafe(report) ? 1 : 0;
        }
        return safeReports;
    }

    public int Part2()
    {
        return default;
    }

    private string[][] processInput(string input)
    {
        var rows = input.Split("\n");
        var resultArray = new string[rows.Length][];

        for(int i = 0; i < rows.Length; i++)
        {
            resultArray[i] = rows[i].Split(' ');
        }
        return resultArray;
    }
    
    private bool isSafe(string[] report)
    {
        for(int i = 0; i < (report.Length - 1); i++)
        {
            var isIncreasing = int.Parse(report[0]) < int.Parse(report[^1]);
            var current = int.Parse(report[i]);
            var next = int.Parse(report[i+1]);
            var hasIncreased = current < next;
            var difference = hasIncreased ? next - current : current - next;
            if (isIncreasing != hasIncreased) { return false; }
            if (difference < 1 || difference > 3) { return false; }
        }
        return true;
    }
}
