using System;
using System.Text.RegularExpressions;

namespace AoC2022Day5
{
  class Program
  {
    static void Main(string[] args)
    {
      var (stacksByOldCrane, stacksByNewCrane) = InputParser.ParseInputFile();

      if (stacksByOldCrane != null)
      {
        Console.WriteLine($"Crates on top moved by old crane: {stacksByOldCrane.TopCratesToString()}");
      }

      if (stacksByNewCrane != null)
      {
        Console.WriteLine($"Crates on top moved by new crane: {stacksByNewCrane.TopCratesToString()}");
      }
    }

    private static void AddCrate(string line, StackBuilder stacksBuilder)
    {
      for (int i = 1; i < line.Length; i += 4)
      {
        if (line[i] != ' ')
        {
          stacksBuilder.AddCrate(line[i], (i - 1) / 4 + 1);
        }
      }
    }

    private static void MoveCrates(Match match, string line, Stacks stacks)
    {
      var numberOfCrates = int.Parse(match.Groups[1].Value);
      var sourceStackId = int.Parse(match.Groups[2].Value);
      var destinationStackId = int.Parse(match.Groups[3].Value);
      stacks.MoveCrates(numberOfCrates, sourceStackId, destinationStackId);
    }
  }
}