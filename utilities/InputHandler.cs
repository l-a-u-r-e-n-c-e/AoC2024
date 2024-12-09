using System.IO;
using Microsoft.Extensions.Configuration;

namespace AoC2024.utilities;

public class InputHandler
{
    IConfiguration _config;
    string _baseFilePath;
    public InputHandler(IConfiguration config)
    {
        _config = config;
        _baseFilePath = _config["inputFileBasePath"]!;
        validatePath(_baseFilePath);
    }

    public static string GetInput(string filePath)
    {
        validatePath(filePath);
        using var reader = new StreamReader(filePath); 
        return reader.ReadToEnd();
    }

    public string GenerateInputPath(int dayNumber)
    {
        var path = $"{_baseFilePath}/{_config[$"days:day{dayNumber}:inputFileName"]}";
        validatePath(path);
        return path;
    }

    private static void validatePath(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"The path {path} does not exist");
        }
    }

}
