using AoC2024.utilities;

namespace AoC2024.days;

public class Day
{
    private string _input;
    public Day(string inputFilePath)
    {
        _input = InputHandler.GetInput(inputFilePath);
        Console.WriteLine(_input);
    }
}
