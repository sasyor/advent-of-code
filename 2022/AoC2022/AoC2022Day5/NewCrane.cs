using System.Collections.Generic;

namespace AoC2022Day5
{
  public class NewCrane : ICrane
  {
    public void MoveCrates(int numberOfCrates, Stack<char> sourceStack, Stack<char> destinationStack)
    {
      var crates = new List<char>();
      for (int i = 0; i < numberOfCrates; i++)
      {
        crates.Insert(0, sourceStack.Pop());
      }

      foreach (var crate in crates)
      {
        destinationStack.Push(crate);
      }
    }
  }
}