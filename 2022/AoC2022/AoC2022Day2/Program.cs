using System;
using System.Linq;

namespace AoC2022Day2
{
  class Program
  {
    static void Main(string[] args)
    {
      var totalPoints = TextFileParser.GetHands().Sum(x => Hand.Create(x.User).Fight(x.Opponent));
      Console.WriteLine($"Total points: {totalPoints}");
    }
  }
}