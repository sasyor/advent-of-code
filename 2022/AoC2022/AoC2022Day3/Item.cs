using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AoC2022Day3
{
  public class Item
  {
    private static readonly ItemComparer ItemComparer = new();

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

    public static Item GetSharedItem(IEnumerable<IEnumerable<Item>> itemCollections)
    {
      var sortedCollections = itemCollections.Select(c => c.ToImmutableArray().Sort(ItemComparer).AsEnumerable());

      var sharedItem = GetSharedItemFromCollections(sortedCollections);

      if (sharedItem is null)
      {
        throw new InvalidOperationException();
      }

      return sharedItem;
    }

    private static Item GetSharedItemFromCollections(IEnumerable<IEnumerable<Item>> sortedCollections)
    {
      var collections = sortedCollections as IEnumerable<Item>[] ?? sortedCollections.ToArray();
      foreach (var item in collections.First())
      {
        var sharedItem = fadfsfa(collections.Skip(1), item);

        if (sharedItem is not null)
        {
          return sharedItem;
        }
      }

      return null;
    }

    private static Item fadfsfa(IEnumerable<IEnumerable<Item>> collections, Item item)
    {
      Item sharedItem = null;
      foreach (var collection in collections)
      {
        foreach (var otherItem in collection)
        {
          if (item.Char == otherItem.Char)
          {
            sharedItem = item;
            break;
          }

          if (item.Priority < otherItem.Priority)
          {
            return null;
          }
        }
      }

      return sharedItem;
    }
  }
}