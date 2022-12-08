using System;
using System.Collections.Generic;
using System.IO;

namespace AoC2022Day6
{
  class Program
  {
    static void Main(string[] args)
    {
      var line = File.ReadAllLines("input.txt")[0];
      var processedChars = 0;
      var startOfPacket = new Queue<char>();
      foreach (var currentChar in line)
      {
        processedChars++;

        while (startOfPacket.Contains(currentChar))
        {
          startOfPacket.Dequeue();
        }

        startOfPacket.Enqueue(currentChar);

        // if (startOfPacket.Count > 3) // Part one
        if (startOfPacket.Count > 13) // Part two
        {
          break;
        }
      }

      Console.WriteLine($"First marker after character {processedChars}");
    }
  }
}