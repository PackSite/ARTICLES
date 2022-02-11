using BenchmarkDotNet.Running;
using Demo;
using Spectre.Console;

const string BenchmarkOption = "Benchmark";

// 1. Show choices
var choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What would you like to compute?")
        .PageSize(10)
        .AddChoices(new[] {
            BenchmarkOption,
        }));

if (choice == BenchmarkOption)
{
    BenchmarkRunner.Run<Benchmarks>();
}