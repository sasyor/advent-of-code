namespace AoC2022Day11;

public class MonkeyMediator
{
  private readonly List<Monkey> _monkeys = new();

  public void AddMonkey(Monkey monkey)
  {
    _monkeys.Add(monkey);
  }

  public void ThrowItemToMonkey(Item item, int monkeyId)
  {
    _monkeys[monkeyId].AddItem(item);
  }
}