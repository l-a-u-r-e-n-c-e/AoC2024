using System.IO;

namespace AoC2024.utilities;

public class InputHandler
{
    public InputHandler()
    {

    }

    public static string GetInput(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file '{filePath}' was not found.");
        }

        using var reader = new StreamReader(filePath); 
        return reader.ReadToEnd();
    }

}
