using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace AoC2022Day5
{
  public class Stacks
  {
    private readonly ICrane _crane;
    private readonly ImmutableArray<Stack<char>> _stacks;

    public Stacks(IEnumerable<IEnumerable<char>> stacks, ICrane crane)
    {
      _crane = crane;
      _stacks = stacks.Select(s => new Stack<char>(s)).ToImmutableArray();
    }

    public void MoveCrates(int numberOfCrates, int sourceStackId, int destinationStackId)
    {
      _crane.MoveCrates(numberOfCrates, _stacks[sourceStackId - 1], _stacks[destinationStackId - 1]);
    }

    public string TopCratesToString()
    {
      var sb = new StringBuilder();
      foreach (var stack in _stacks)
      {
        sb.Append(stack.Peek());
      }

      return sb.ToString();
    }
  }
}