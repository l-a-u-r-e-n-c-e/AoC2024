namespace AoC2024.days;

public class Day2 : Day
{
    private string[][] _inputArrays;
    public Day2(string inputFilePath) : base(inputFilePath)
    {
        _inputArrays = processInput(Input);
    }

    public int Part1()
    {
        var safeReports = 0;
        foreach (var report in _inputArrays)
        {
            safeReports += isSafe(report) ? 1 : 0;
        }
        return safeReports;
    }

    public int Part2()
    {
        var safeReports = 0;
        foreach (var report in _inputArrays)
        {
            if (isSafe(report)) { safeReports++; continue; }
            safeReports += isCorrectable(report) ? 1 : 0;
        }
        return safeReports;
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

    private bool isCorrectable(string[] report)
    {
        for(int i = 0; i < report.Length; i++)
        {
            var amendedReport = new List<string>(report);
            amendedReport.RemoveAt(i);
            if (isSafe(amendedReport.ToArray())) { return true; }
        }
        return false;
    }
}
