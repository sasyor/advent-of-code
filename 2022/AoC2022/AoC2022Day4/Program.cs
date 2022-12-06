using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AoC2022Day4
{
  class Program
  {
    static void Main(string[] args)
    {
      var overlaps = File.ReadLines("input.txt")
        .Select(l => AssignmentPair.Create(l).CompareAssignments()).ToImmutableArray();

      Console.WriteLine($"Total count of full overlaps: {overlaps.Count(x => x == AssignmentContainType.Full)}");
      Console.WriteLine($"Total count of overlaps: {overlaps.Count(x => x != AssignmentContainType.None)}");
    }
  }
}