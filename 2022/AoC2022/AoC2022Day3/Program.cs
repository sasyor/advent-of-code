using System;
using System.IO;
using System.Linq;

namespace AoC2022Day3
{
  class Program
  {
    static void Main(string[] args)
    {
      var sumOfPriorities = File.ReadLines("input.txt").Select(l => Rucksack.Create(l)).Sum(r => r.GetSharedItem().Priority);

      Console.WriteLine($"Total sum of priorities: {sumOfPriorities}");
    }
  }
}