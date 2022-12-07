using System.Collections.Generic;

namespace AoC2022Day5
{
  public class OldCrane : ICrane
  {
    public void MoveCrates(int numberOfCrates, Stack<char> sourceStack, Stack<char> destinationStack)
    {
      for (int i = 0; i < numberOfCrates; i++)
      {
        var crate = sourceStack.Pop();
        destinationStack.Push(crate);
      }
    }
  }
}