using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2022Day8
{
  class Program
  {
    static void Main(string[] args)
    {
      var forest = new Forest();
      var lines = File.ReadAllLines("input.txt");
      for (var lineIdx = 0; lineIdx < lines.Length; lineIdx++)
      {
        for (var charIdx = 0; charIdx < lines[lineIdx].Length; charIdx++)
        {
          var isLastCharInLine = charIdx == lines[lineIdx].Length - 1;
          var isLastLine = lineIdx == lines.Length - 1;
          var isAlwaysVisible = lineIdx == 0 || isLastLine || charIdx == 0 ||
                                isLastCharInLine;
          forest.AddTree(GetValue(lines, lineIdx, charIdx), isAlwaysVisible);
          if (isLastCharInLine && !isLastLine)
          {
            forest.AddLine();
          }
        }
      }

      forest.UpdateTrees();
      Console.WriteLine($"Number of trees visible from outside the grid: {forest.GetVisibleTrees().Count()}");
      Console.WriteLine($"Tree with highest scenic score: {forest.GetAllTrees().Max(t => t.ScenicScore)}");
    }

    private static int GetValue(IReadOnlyList<string> lines, int lineIdx, int charIdx)
    {
      return Convert.ToInt32(char.GetNumericValue(lines[lineIdx][charIdx]));
    }
  }
}