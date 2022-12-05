using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2022Day3
{
  class Program
  {
    static void Main(string[] args)
    {
      var sumOfPriorities = File.ReadLines("input.txt").Select(l => Rucksack.Create(l))
        .Sum(r => r.GetSharedItem().Priority);

      Console.WriteLine($"Total sum of priorities: {sumOfPriorities}");

      var elfGroups = new List<ElfGroup>();
      var lines = new Queue<string>(File.ReadLines("input.txt"));
      while (lines.Count > 2)
      {
        elfGroups.Add(ElfGroup.Create(new[]
        {
          lines.Dequeue(),
          lines.Dequeue(),
          lines.Dequeue(),
        }));
      }

      Console.WriteLine($"Total sum of priorites for 3 elf groups: {elfGroups.Sum(e => e.GetSharedItem().Priority)}");
    }
  }
}