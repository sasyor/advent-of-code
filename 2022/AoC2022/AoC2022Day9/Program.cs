using System;
using System.IO;

namespace AoC2022Day9
{
  class Program
  {
    static void Main(string[] args)
    {
      var rope = new Rope();
      foreach (var line in File.ReadLines("input.txt"))
      {
        var split = line.Split(' ');
        var moveType = GetMoveType(split[0]);
        for (var i = 0; i < int.Parse(split[1]); i++)
        {
          rope.Move(moveType);
          // Console.WriteLine(rope.GetAsString(20, 20));
        }
      }

      Console.WriteLine($"Number of coordinates visited by tail: {rope.CoordinatesVisitedByTail.Count}");
    }

    private static MoveType GetMoveType(string s)
    {
      return s switch
      {
        "R" => MoveType.Right,
        "L" => MoveType.Left,
        "U" => MoveType.Up,
        "D" => MoveType.Down,
        _ => throw new ArgumentOutOfRangeException(nameof(s), s, null)
      };
    }
  }
}