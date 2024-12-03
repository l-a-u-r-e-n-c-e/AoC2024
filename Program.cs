using AoC2024.days;
using Microsoft.Extensions.Configuration;

// Setup
string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .Build();
var inputBaseFilePath = configuration["inputFileBasePath"];


// Day 1
var day1 = new Day1($"{inputBaseFilePath}/{configuration["days:day1:inputFileName"]}");
var part1Answer = day1.Part1();

Console.WriteLine($"The answer to Day 1 Part 1 is {part1Answer}");