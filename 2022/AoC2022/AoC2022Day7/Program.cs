using System;
using System.Collections.Immutable;
using System.Linq;

namespace AoC2022Day7
{
  class Program
  {
    static void Main(string[] args)
    {
      var totalSpace = 70_000_000;
      var spaceForUpdate = 30_000_000;

      var inputParser = new InputParser(Dir.Root);
      inputParser.ParseLines(System.IO.File.ReadLines("input.txt").Skip(1));

      var totalSum = Dir.Root.FlattenedChildren.Where(x => x.Size <= 100_000).Sum(d => d.Size);
      Console.WriteLine($"Sum of total size of at most 100.000 dirs: {totalSum}");

      var requiredSpace = totalSpace - Dir.Root.Size < spaceForUpdate
        ? Math.Abs(totalSpace - Dir.Root.Size - spaceForUpdate)
        : 0;
      var potentialDirsToDelete = Dir.Root.FlattenedChildren.Where(d => d.Size >= requiredSpace)
        .ToImmutableDictionary(d => d.Size);
      var dirToDelete = potentialDirsToDelete[potentialDirsToDelete.Min(d => d.Key)];
      Console.WriteLine($"Size of the dir to delete: {dirToDelete.Size}");
    }
  }
}