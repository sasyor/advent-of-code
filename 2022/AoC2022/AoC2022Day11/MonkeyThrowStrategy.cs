namespace AoC2022Day11;

public class MonkeyThrowStrategy
{
  private readonly MonkeyMediator _monkeyMediator;
  private readonly int _divider;
  private readonly int _monkeyIdWhenTrue;
  private readonly int _monkeyIdWhenFalse;

  public MonkeyThrowStrategy(int divider, int monkeyIdWhenTrue, int monkeyIdWhenFalse, MonkeyMediator monkeyMediator)
  {
    _monkeyMediator = monkeyMediator;
    _divider = divider;
    _monkeyIdWhenTrue = monkeyIdWhenTrue;
    _monkeyIdWhenFalse = monkeyIdWhenFalse;
  }
  
  public void ThrowItemToMonkey(Item item)
  {
    _monkeyMediator.ThrowItemToMonkey(item, item.IsDivisible(_divider) ? _monkeyIdWhenTrue : _monkeyIdWhenFalse);
  }
}