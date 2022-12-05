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
      return Item.GetSharedItem(new[] { Items.AsEnumerable(), compartment.Items });
    }

    public static Compartment Create(string input)
    {
      return new Compartment(input.Select(Item.Create));
    }
  }
}