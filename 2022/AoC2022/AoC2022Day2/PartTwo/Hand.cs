using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AoC2022Day2.PartTwo
{
  public class Hand
  {
    private const int PointsForDraw = 3;
    private const int PointsForWin = 6;

    private readonly HandType _opponentStronger;
    private readonly HandType _opponentType;
    private readonly HandType _opponentWeaker;

    private static readonly ImmutableDictionary<HandType, int> PointsMap = new Dictionary<HandType, int>()
    {
      { HandType.Rock, 1 },
      { HandType.Paper, 2 },
      { HandType.Scissors, 3 },
    }.ToImmutableDictionary();

    public Hand(HandType opponentOpponentType, HandType opponentWeaker, HandType opponentStronger)
    {
      _opponentType = opponentOpponentType;
      _opponentWeaker = opponentWeaker;
      _opponentStronger = opponentStronger;
    }

    public int Fight(StrategyType strategyType)
    {
      return strategyType switch
      {
        StrategyType.Win => PointsForWin + PointsMap[_opponentWeaker],
        StrategyType.Draw => PointsForDraw+ PointsMap[_opponentType],
        StrategyType.Lose => 0 + PointsMap[_opponentStronger],
        _ => throw new ArgumentOutOfRangeException(nameof(strategyType), strategyType, null)
      };
    }

    public static Hand Create(HandType opponentType)
    {
      return opponentType switch
      {
        HandType.Rock => new Hand(opponentType,   HandType.Paper, HandType.Scissors),
        HandType.Paper => new Hand(opponentType,   HandType.Scissors, HandType.Rock),
        HandType.Scissors => new Hand(opponentType,   HandType.Rock, HandType.Paper),
        _ => throw new ArgumentOutOfRangeException(nameof(opponentType), opponentType, null)
      };
    }
  }
}