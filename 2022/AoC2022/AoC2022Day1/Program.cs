using System;
using System.Linq;

namespace AoC2022Day1
{
  class Program
  {
    static int _elfCounter = 0;
    
    static void Main(string[] args)
    {
      var calories = TextFileParser.GetCalories();

      var elves = calories.Select(CreateElf).ToList();
      elves.Sort(new ElfCalorieComparer());

      Console.WriteLine($"1st elf carrying the most calories: {elves[0].Name}, calories: {elves[0].Calories}");
      Console.WriteLine($"2nd elf carrying the most calories: {elves[1].Name}, calories: {elves[1].Calories}");
      Console.WriteLine($"3rd elf carrying the most calories: {elves[2].Name}, calories: {elves[2].Calories}");
      Console.WriteLine($"In total the 3 carries: {elves[0].Calories+elves[1].Calories+elves[2].Calories} calories");
    }

    static Elf CreateElf(int calories)
    {
      _elfCounter++;
      return new Elf(_elfCounter.ToString(), calories);
    }
  }
}