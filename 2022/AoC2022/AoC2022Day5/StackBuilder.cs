using System.Collections.Generic;

namespace AoC2022Day5
{
  public class StackBuilder
  {
    private ICrane _crane = new OldCrane();
    private readonly List<List<char>> _stacks = new();

    public void AddCrate(char name, int stackId)
    {
      while (stackId > _stacks.Count)
      {
        _stacks.Add(new List<char>());
      }

      _stacks[stackId - 1].Insert(0, name);
    }

    public StackBuilder WithNewCrane()
    {
      _crane = new NewCrane();
      return this;
    }

    public Stacks Build()
    {
      return new Stacks(_stacks, _crane);
    }
  }
}