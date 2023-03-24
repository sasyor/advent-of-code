using System.Text.RegularExpressions;

namespace AoC2022Day11;

public class InputInterpreter
{
  private const string MonkeyIdText = "Monkey ";
  private const string StartingItemsText = "Starting items: ";
  private const string OperationText = "Operation: new = ";

  public IReadOnlyList<Monkey> GetMonkeys(IEnumerable<string> lines)
  {
    var monkeyMediator = new MonkeyMediator();
    var linesQueue = new Queue<string>(lines);

    var monkeys = new List<Monkey>();
    int? monkeyId = null;
    var startingItems = new List<Item>();
    IMonkeyWorryOperationStrategy? operationStrategy = null;
    MonkeyThrowStrategy? throwStrategy = null;

    while (linesQueue.TryDequeue(out var line))
    {
      if (string.IsNullOrEmpty(line))
      {
        continue;
      }

      if (line.StartsWith(MonkeyIdText))
      {
        monkeyId = int.Parse(line.Substring(MonkeyIdText.Length, 1));
        continue;
      }

      if (line.TrimStart().StartsWith(StartingItemsText))
      {
        var startingItemsAsText =
          line.TrimStart()[StartingItemsText.Length..].Split(", ").Select(x => int.Parse(x));
        startingItems.AddRange(startingItemsAsText.Select(x => new Item(x)));
        continue;
      }

      if (line.TrimStart().StartsWith(OperationText))
      {
        operationStrategy = GetOperationStrategy(line);
        continue;
      }

      if (line.TrimStart().StartsWith("Test: divisible by "))
      {
        var divider = int.Parse(new Regex("by (.*)").Match(line).Groups[1].Value);
        var throwRegex = new Regex("to monkey (.*)");
        var monkeyIdWhenTrue = int.Parse(throwRegex.Match(linesQueue.Dequeue()).Groups[1].Value);
        var monkeyIdWhenFalse = int.Parse(throwRegex.Match(linesQueue.Dequeue()).Groups[1].Value);
        throwStrategy = new MonkeyThrowStrategy(divider, monkeyIdWhenTrue, monkeyIdWhenFalse, monkeyMediator);
      }

      if (monkeyId.HasValue && operationStrategy != null && throwStrategy != null)
      {
        var monkey = new Monkey(monkeyId.Value, startingItems, operationStrategy, throwStrategy);
        monkeys.Add(monkey);
        monkeyMediator.AddMonkey(monkey);

        monkeyId = null;
        startingItems = new List<Item>();
        operationStrategy = null;
        throwStrategy = null;
      }
      else
      {
        throw new InvalidOperationException();
      }
    }

    return monkeys;
  }

  private IMonkeyWorryOperationStrategy GetOperationStrategy(string line)
  {
    if (line.Contains('+'))
    {
      var value = int.Parse(new Regex("\\+ (.*)").Match(line).Groups[1].Value);
      return new MonkeyWorryOperationStrategyAdd(value);
    }

    if (line.Contains('*'))
    {
      if (line.Contains("old * old"))
      {
        return new MonkeyWorryOperationStrategyMultiplyWithSelf();
      }

      var value = int.Parse(new Regex("\\* (.*)").Match(line).Groups[1].Value);
      return new MonkeyWorryOperationStrategyMultiply(value);
    }

    throw new InvalidOperationException();
  }
}