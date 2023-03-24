namespace AoC2022Day11;

public class MonkeyWorryOperationStrategyAdd : IMonkeyWorryOperationStrategy
{
  private readonly int _value;

  public MonkeyWorryOperationStrategyAdd(int value)
  {
    _value = value;
  }
  
  public void ModifyWorryLevel(Item item)
  {
    item.AddWorryLevel(_value);
  }
}