using AoC2024.days;
using AoC2024.utilities;
using Microsoft.Extensions.Configuration;

// Setup
string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .Build();
InputHandler inputHandler = new(configuration);

// Day 1
var day1 = new Day1(inputHandler.GenerateInputPath(1));
var d1p1Answer = day1.Part1();
var d1p2Answer = day1.Part2();

Console.WriteLine($"The answer to Day 1 Part 1 is {d1p1Answer} and the answer to Part 2 is {d1p2Answer}");

// Day 2
var day2 = new Day2(inputHandler.GenerateInputPath(2));
var d2p1Answer = day2.Part1();
var d2p2Answer = day2.Part2();

Console.WriteLine($"The answer to Day 2 Part 1 is {d2p1Answer} and the answer to Part 2 is {d2p2Answer}");

// Day 3
var day3 = new Day3(inputHandler.GenerateInputPath(3));
var d3p1Answer = day3.Part1();
var d3p2Answer = day3.Part2();

Console.WriteLine($"The answer to Day 3 Part 1 is {d3p1Answer} and the answer to Part 2 is {d3p2Answer}");

// Day 4
var day4 = new Day4(inputHandler.GenerateInputPath(4));
var d4p1Answer = day4.Part1();
var d4p2Answer = day4.Part2();

Console.WriteLine($"The answer to Day 4 Part 1 is {d4p1Answer} and the answer to Part 2 is {d4p2Answer}");
