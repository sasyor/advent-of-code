using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AoC2022Day2.PartTwo
{
  public static class TextFileParser
  {
    private static readonly ImmutableDictionary<char, HandType> OpponentHandTypes = new Dictionary<char, HandType>
    {
      { 'A', HandType.Rock },
      { 'B', HandType.Paper },
      { 'C', HandType.Scissors },
    }.ToImmutableDictionary();

    private static readonly ImmutableDictionary<char, StrategyType> StrategyTypes = new Dictionary<char, StrategyType>
    {
      { 'X', StrategyType.Lose },
      { 'Y', StrategyType.Draw },
      { 'Z', StrategyType.Win },
    }.ToImmutableDictionary();

    public static IEnumerable<(HandType Opponent, StrategyType StrategyType)> GetHands()
    {
      return File.ReadLines("input.txt").Select(x => (opponent: OpponentHandTypes[x[0]], user: StrategyTypes[x[2]]));
    }
  }
}