using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022Day7
{
  public class InputParser
  {
    private Dir _currentDir;

    public InputParser(Dir currentDir)
    {
      _currentDir = currentDir;
    }

    public void ParseLines(IEnumerable<string> lines)
    {
      var fileParsing = false;
      foreach (var line in lines)
      {
        if (line.StartsWith('$'))
        {
          if (line == "$ ls")
          {
            fileParsing = true;
          }
          else
          {
            if (!line.StartsWith("$ cd "))
            {
              throw new InvalidOperationException();
            }

            fileParsing = false;
            _currentDir = _currentDir.Navigate(line.Split(' ').Last());
          }
        }
        else if (!line.StartsWith("dir") && fileParsing)
        {
          _currentDir.AddFile(line);
        }
      }
    }
  }
}