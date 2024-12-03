using AoC2024.utilities;

namespace AoC2024.days;

public class Day
{
    public string Input { get; private set; }
    public Day(string inputFilePath)
    {
        Input = InputHandler.GetInput(inputFilePath);
    }
}
