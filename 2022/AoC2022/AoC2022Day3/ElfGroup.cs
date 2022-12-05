using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AoC2022Day3
{
  public class ElfGroup
  {
    private readonly ImmutableArray<Rucksack> _rucksacks;

    public ElfGroup(IEnumerable<Rucksack> rucksacks)
    {
      _rucksacks = rucksacks.ToImmutableArray();
    }

    public Item GetSharedItem()
    {
      return Item.GetSharedItem(_rucksacks.Select(r => r.Items.AsEnumerable()));
    }

    public static ElfGroup Create(IEnumerable<string> lines)
    {
      return new ElfGroup(lines.Select(l => Rucksack.Create(l)));
    }
  }
}