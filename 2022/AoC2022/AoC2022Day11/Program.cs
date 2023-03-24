// See https://aka.ms/new-console-template for more information

using AoC2022Day11;

var lines = File.ReadLines("input.txt");
var monkeys = new InputInterpreter().GetMonkeys(lines);

for (int i = 0; i < 20; i++)
{
  foreach (var monkey in monkeys)
  {
    monkey.InspectItems();
  }
}

var monkeysForMonkeyBusiness = monkeys.OrderByDescending(x => x.InspectCount).Take(2);
var monkeyBusiness = monkeysForMonkeyBusiness.Select(x => x.InspectCount).Aggregate((x, y) => x * y);

Console.WriteLine($"The level of monkey business: {monkeyBusiness}");