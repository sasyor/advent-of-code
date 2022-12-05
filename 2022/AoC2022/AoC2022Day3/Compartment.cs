using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AoC2022Day3
{
  public class Compartment
  {
    private static readonly ItemComparer ItemComparer = new();

    public ImmutableArray<Item> Items { get; }

    public Compartment(IEnumerable<Item> items)
    {
      Items = items.ToImmutableArray();
    }

    public Item GetSharedItem(Compartment compartment)
    {
      var otherItems = compartment.Items.Sort(ItemComparer);
      var items = Items.Sort(ItemComparer);

      foreach (var item in items)
      {
        foreach (var otherItem in otherItems)
        {
          if (item.Char == otherItem.Char)
          {
            return item;
          }

          if (item.Priority < otherItem.Priority)
          {
            break;
          }
        }
      }

      throw new InvalidOperationException();
    }

    public static Compartment Create(string input)
    {
      return new Compartment(input.Select(Item.Create));
    }
  }
}