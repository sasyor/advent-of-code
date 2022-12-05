using System.Collections.Generic;
using System.IO;

namespace AoC2022Day1
{
  public class TextFileParser
  {
    public static IEnumerable<int> GetCalories()
    {
      var allLines = File.ReadAllLines("input.txt");

      var currentCalories = 0;
      foreach (var line in allLines)
      {
        if (line == "")
        {
          yield return currentCalories;
          currentCalories = 0;
          continue;
        }

        currentCalories += int.Parse(line);
      }

      yield return currentCalories;
    }
  }
}