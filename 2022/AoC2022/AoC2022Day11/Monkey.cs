namespace AoC2022Day11;

public class Monkey
{
  private readonly IMonkeyWorryOperationStrategy _operationStrategy;
  private readonly MonkeyThrowStrategy _monkeyThrowStrategy;
  private readonly Queue<Item> _items;
  public int Id { get; }
  public int InspectCount { private set; get; } = 0;

  public Monkey(int id, IEnumerable<Item> items, IMonkeyWorryOperationStrategy operationStrategy,
    MonkeyThrowStrategy monkeyThrowStrategy)
  {
    _operationStrategy = operationStrategy;
    _monkeyThrowStrategy = monkeyThrowStrategy;
    _items = new Queue<Item>(items);
    Id = id;
  }

  public void InspectItems()
  {
    while (_items.TryDequeue(out var item))
    {
      InspectCount++;

      _operationStrategy.ModifyWorryLevel(item);
      item.Relief();
      _monkeyThrowStrategy.ThrowItemToMonkey(item);
    }
  }

  public void AddItem(Item item)
  {
    _items.Enqueue(item);
  }
}