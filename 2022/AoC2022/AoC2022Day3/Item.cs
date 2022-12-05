using System;

namespace AoC2022Day3
{
  public class Item
  {
    public int Priority { get; }
    public char Char { get; }

    public Item(char @char, int priority)
    {
      Char = @char;
      Priority = priority;
    }

    public static Item Create(char @char)
    {
      int priority;
      if (@char is >= 'a' and <= 'z')
      {
        priority = GetPriority(@char, 'a', 1);
      }
      else if (@char is >= 'A' and <= 'Z')
      {
        priority = GetPriority(@char, 'A', 27);
      }
      else
      {
        throw new ArgumentOutOfRangeException();
      }

      return new Item(@char, priority);
    }

    private static int GetPriority(char @char, char c, int i)
    {
      return @char - c + i;
    }
  }
}