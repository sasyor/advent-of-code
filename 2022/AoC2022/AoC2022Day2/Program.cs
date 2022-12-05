using System;
using System.Linq;
using AoC2022Day2.PartTwo;

namespace AoC2022Day2
{
  class Program
  {
    static void Main(string[] args)
    {
      var totalPoints = TextFileParser.GetHands().Sum(x => Hand.Create(x.Opponent).Fight(x.StrategyType));
      Console.WriteLine($"Total points: {totalPoints}");
    }
  }
}