using System.Collections.Generic;

namespace AoC2022Day5
{
  public interface ICrane
  {
    void MoveCrates(int numberOfCrates, Stack<char> sourceStack, Stack<char> destinationStack);
  }
}