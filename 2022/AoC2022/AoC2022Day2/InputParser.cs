using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AoC2022Day2
{
  public class TextFileParser
  {
    private static ImmutableDictionary<char, HandType> _opponentHandTypes = new Dictionary<char, HandType>
    {
      { 'A', HandType.Rock },
      { 'B', HandType.Paper },
      { 'C', HandType.Scissors },
    }.ToImmutableDictionary();

    private static ImmutableDictionary<char, HandType> _userHandTypes = new Dictionary<char, HandType>
    {
      { 'X', HandType.Rock },
      { 'Y', HandType.Paper },
      { 'Z', HandType.Scissors },
    }.ToImmutableDictionary();

    public static IEnumerable<(HandType Opponent, HandType User)> GetHands()
    {
      return File.ReadLines("input.txt").Select(x =>
      {
        
        return (opponent: _opponentHandTypes[x[0]], user: _userHandTypes[x[2]]);
      });
    }
  }
}