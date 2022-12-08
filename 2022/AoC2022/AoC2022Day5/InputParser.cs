using System.IO;
using System.Text.RegularExpressions;

namespace AoC2022Day5
{
  public class InputParser
  {
    public static (Stacks StacksByOldCrane, Stacks StacksByNewCrane) ParseInputFile()
    {
      var moveDataRegex = new Regex("move (\\d+) from (\\d+) to (\\d+)");
      var stacksByOldCraneBuilder = new StackBuilder();
      var stacksByNewCraneBuilder = new StackBuilder().WithNewCrane();
      Stacks stacksByOldCrane = null;
      Stacks stacksByNewCrane = null;
      foreach (var line in File.ReadLines("input.txt"))
      {
        if (line == "" || line.StartsWith(" 1 "))
        {
          stacksByOldCrane = stacksByOldCraneBuilder.Build();
          stacksByNewCrane = stacksByNewCraneBuilder.Build();
          continue;
        }

        var match = moveDataRegex.Match(line);


        if (match.Success && stacksByOldCrane is not null && stacksByNewCrane is not null)
        {
          MoveCrates(match, line, stacksByOldCrane);
          MoveCrates(match, line, stacksByNewCrane);
        }
        else if (stacksByOldCrane is null && stacksByNewCrane is null)
        {
          AddCrate(line, stacksByOldCraneBuilder);
          AddCrate(line, stacksByNewCraneBuilder);
        }
      }

      return (stacksByOldCrane, stacksByNewCrane);
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