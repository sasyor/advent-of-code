namespace AoC2022Day11;

public class MonkeyWorryOperationStrategyMultiplyWithSelf: IMonkeyWorryOperationStrategy
{
  public void ModifyWorryLevel(Item item)
  {
    item.MultiplyWorryLevel(item.WorryLevel);
  }
}