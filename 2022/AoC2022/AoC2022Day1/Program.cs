using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022Day1
{
  class Program
  {
    static int _elfCounter = 0;
    
    static void Main(string[] args)
    {
      var calories = TextFileParser.GetCalories();

      var elves = calories.Select(CreateElf).ToArray();

      var elfWithMostCalories = elves.First(x => x.Calories == elves.Max(y => y.Calories));
      Console.WriteLine($"Elf carrying the most calories: {elfWithMostCalories.Name}, calories: {elfWithMostCalories.Calories}");
    }

    static Elf CreateElf(int calories)
    {
      _elfCounter++;
      return new Elf(_elfCounter.ToString(), calories);
    }
  }
}