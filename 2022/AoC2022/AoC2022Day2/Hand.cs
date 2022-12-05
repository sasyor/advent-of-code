using System;

namespace AoC2022Day2
{
  public  class Hand
  {
    private const int PointsForDraw = 3;
    private const int PointsForWin = 6;

    private readonly HandType _winAgainst;
    private readonly HandType _type;
    private readonly int _points;

    public Hand(HandType type, int points, HandType winAgainst)
    {
      _type = type;
      _points = points;
      _winAgainst = winAgainst;
    }

    public int Fight(HandType hand)
    {
      if (_type == hand)
      {
        return _points+ PointsForDraw;
      }

      return _points + (hand == _winAgainst ? PointsForWin : 0);
    }
    
    public  static Hand Create(HandType type)
    {
      return type switch
      {
        HandType.Rock => new Hand(type, 1, HandType.Scissors),
        HandType.Paper => new Hand(type, 2, HandType.Rock),
        HandType.Scissors => new Hand(type, 3, HandType.Paper),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
      };
    }
  }
}