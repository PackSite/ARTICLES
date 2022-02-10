using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Running;
using Demo;
using Spectre.Console;

const string BenchmarkOption = "Benchmark";
const string ToBucketDistributionOption = "ToBucket() distribution";

// 1. Show choices
var choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What would you like to compute?")
        .PageSize(10)
        .AddChoices(new[] {
            ToBucketDistributionOption,
            BenchmarkOption,
        }));

if (choice == BenchmarkOption)
{
    BenchmarkRunner.Run<Benchmarks>();
}

if (choice == ToBucketDistributionOption)
{
    Dictionary<short, uint> countsLive = new();
    Dictionary<short, uint> counts = new();

    var chart = new BarChart()
        .Width(Console.WindowWidth)
        .Label("[green bold underline]Buckets distribution[/]")
        .CenterLabel()
        .ShowValues()
        .AddItem("-- Computing --", 0, Color.Red);

    AnsiConsole.Live(chart)
        .Start(ctx =>
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            int height = Console.WindowHeight - 3;

            while (stopwatch.Elapsed.TotalSeconds < 10)
            {
                stopwatch2.Restart();

                while (stopwatch2.Elapsed.TotalMilliseconds < 1000)
                {
                    short bucket = Guid.NewGuid().ToBucket();
                    if (!counts.TryAdd(bucket, 1))
                    {
                        ++counts[bucket];
                    }

                    short bucketLive = (short)Map(bucket, 0, 1024, 0, height);
                    if (!countsLive.TryAdd(bucketLive, 1))
                    {
                        ++countsLive[bucketLive];
                    }
                }

                chart.Label($"[red bold underline]Computing ({stopwatch.Elapsed.TotalSeconds:F1}/10s)[/]");
                SetCounts(chart, countsLive);
                ctx.Refresh();
            }

            chart.Label($"[green bold underline]ToBucket() distribution (n={countsLive.Sum(x => x.Value)})[/]");
            SetCounts(chart, counts);
            ctx.Refresh();
        });
}

static double Map(double value, double fromMin, double fromMax, double toMin, double toMax)
{
    return toMin + (value - fromMin) * (toMax - toMin) / (fromMax - fromMin);
}

static void SetCounts(BarChart chart, Dictionary<short, uint> data)
{
    chart.Data.Clear();
    chart.AddItems(data.OrderBy(x => x.Key), x => new BarChartItem(x.Key.ToString(), x.Value, Color.CornflowerBlue));
}