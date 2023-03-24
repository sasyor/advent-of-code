namespace AoC2022Day11;

public class Item
{
  public int WorryLevel { private set; get; }

  public Item(int worryLevel)
  {
    WorryLevel = worryLevel;
  }

  public void Relief()
  {
    WorryLevel /= 3;
  }

  public bool IsDivisible(int divider)
  {
    return int.DivRem(WorryLevel, divider).Remainder == 0;
  }

  public void AddWorryLevel(int value)
  {
    WorryLevel += value;
  }

  public void MultiplyWorryLevel(int value)
  {
    WorryLevel *= value;
  }
}