using FluentAssertions;
using Xunit;

namespace AoC2022Day9.Tests
{
  public class RopeTests
  {
    [Theory]
    [InlineData(0, 0, 0, 1, 0, 0)] // stay
    [InlineData(0, 0, 1, 0, 0, 0)] // stay
    [InlineData(0, 0, 1, 1, 0, 0)] // stay
    [InlineData(0, 0, 0, 2, 0, 1)] // up
    [InlineData(0, 0, 2, 0, 1, 0)] // right
    [InlineData(0, 0, 2, 2, 1, 1)] // right+up
    [InlineData(5, 5, 5, 3, 5, 4)] // down
    [InlineData(5, 5, 3, 5, 4, 5)] // left
    [InlineData(5, 5, 3, 3, 4, 4)] // left+down
    [InlineData(3, 0, 4, 2, 4, 1)] // left+down
    public void UpdateTailTest(int startBackX, int startBackY, int frontX, int frontY, int expectedBackX,
      int expectedBackY)
    {
      var actualBack = Rope.UpdateTail(new Coordinate(startBackX, startBackY), new Coordinate(frontX, frontY));

      actualBack.X.Should().Be(expectedBackX);
      actualBack.Y.Should().Be(expectedBackY);
    }
  }
}