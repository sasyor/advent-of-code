using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AoC2022Day9
{
  public class Rope
  {
    private Coordinate _head = new(0, 0);
    private readonly Coordinate[] _middles = Enumerable.Range(0, 9).Select(x => new Coordinate(0, 0)).ToArray();
    private readonly IList<Coordinate> _visitedCoordinates = new Collection<Coordinate>();
    public IReadOnlyList<Coordinate> CoordinatesVisitedByTail => _visitedCoordinates.ToList();

    public void Move(MoveType type)
    {
      MoveHead(type);
      for (var i = 0; i < _middles.Length; i++)
      {
        var front = i == 0 ? _head : _middles[i - 1];
        _middles[i] = UpdateTail(_middles[i], front);
      }
      UpdateVisitedCoordinates(_middles.Last());
    }

    private void UpdateVisitedCoordinates(Coordinate coordinate)
    {
      if (_visitedCoordinates.Any(visitedCoordinate =>
            visitedCoordinate.X == coordinate.X && visitedCoordinate.Y == coordinate.Y))
      {
        return;
      }

      _visitedCoordinates.Add(new Coordinate(coordinate.X, coordinate.Y));
    }

    private void MoveHead(MoveType type)
    {
      _head = type switch
      {
        MoveType.Left => new Coordinate(_head.X - 1, _head.Y),
        MoveType.Right => new Coordinate(_head.X + 1, _head.Y),
        MoveType.Up => new Coordinate(_head.X, _head.Y + 1),
        MoveType.Down => new Coordinate(_head.X, _head.Y - 1),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
      };
    }

    public static Coordinate UpdateTail(Coordinate oldBack, Coordinate front)
    {
      if (Math.Abs(front.X - oldBack.X) < 2
          &&
          Math.Abs(front.Y - oldBack.Y) < 2)
      {
        return oldBack;
      }

      var dX = front.X - oldBack.X;
      var dY = front.Y - oldBack.Y;

      if (dX != 0 && Math.Abs(front.Y - oldBack.Y) != 2)
      {
        dX += dX > 0 ? -1 : 1;
      }

      if (dY != 0 && Math.Abs(front.X - oldBack.X) != 2)
      {
        dY += dY > 0 ? -1 : 1;
      }

      if (Math.Abs(dX) == 2 && Math.Abs(dY) == 2)
      {
        dX += dX > 0 ? -1 : 1;
        dY += dY > 0 ? -1 : 1;
      }

      return new Coordinate(oldBack.X + dX, oldBack.Y + dY);
    }

    public string GetAsString(int padX, int padY)
    {
      var strings = Enumerable.Range(0, padY).Select(x => Enumerable.Range(0, padX).Select(s => '.').ToArray())
        .ToArray();

      for (var i = _middles.Length - 1; i >= 0; i--)
      {
        strings[_middles[i].Y][_middles[i].X] = char.Parse((i + 1).ToString());
      }

      strings[_head.Y][_head.X] = 'H';

      var sb = new StringBuilder();
      foreach (var s in strings.Reverse())
      {
        foreach (var c in s)
        {
          sb.Append(c);
        }

        sb.AppendLine();
      }

      return sb.ToString();
    }
  }
}