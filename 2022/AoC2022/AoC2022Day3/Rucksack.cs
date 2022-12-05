using System;
using System.Collections.Immutable;
using System.Linq;

namespace AoC2022Day3
{
  public class Rucksack
  {
    private readonly Compartment _leftCompartment;
    private readonly Compartment _rightCompartment;

    public ImmutableArray<Item> Items => _leftCompartment.Items.Concat(_rightCompartment.Items).ToImmutableArray();

    public Rucksack(Compartment leftCompartment, Compartment rightCompartment)
    {
      _leftCompartment = leftCompartment;
      _rightCompartment = rightCompartment;
    }

    public Item GetSharedItem()
    {
      return _leftCompartment.GetSharedItem(_rightCompartment);
    }

    public static Rucksack Create(string input)
    {
      if (input.Length % 2 == 1)
      {
        throw new ArgumentOutOfRangeException();
      }

      return new Rucksack(Compartment.Create(input.Substring(0, input.Length / 2)),
        Compartment.Create(input.Substring(input.Length / 2)));
    }
  }
}