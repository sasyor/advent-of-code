namespace AoC2022Day11;

public class MonkeyWorryOperationStrategyMultiply : IMonkeyWorryOperationStrategy
{
  private readonly int _value;

  public MonkeyWorryOperationStrategyMultiply(int value)
  {
    _value = value;
  }
  
  public void ModifyWorryLevel(Item item)
  {
    item.MultiplyWorryLevel(_value);
  }
}