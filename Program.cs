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
var d1p1Answer = day1.Part1();
var d1p2Answer = day1.Part2();

Console.WriteLine($"The answer to Day 1 Part 1 is {d1p1Answer} and the answer to Part 2 is {d1p2Answer}");

// Day 2
var day2 = new Day2($"{inputBaseFilePath}/{configuration["days:day2:inputFileName"]}");
var d2p1Answer = day2.Part1();
var d2p2Answer = "not implemented yet.";

Console.WriteLine($"The answer to Day 2 Part 1 is {d2p1Answer} and the answer to Part 2 is {d2p2Answer}");