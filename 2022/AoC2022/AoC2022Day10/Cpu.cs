using System.Collections.Generic;
using System.Collections.Immutable;

namespace AoC2022Day10
{
  public class Cpu
  {
    private readonly ImmutableArray<IDevice> _devices;
    private int _cycle = 0;
    private int _register = 1;

    public Cpu(IEnumerable<IDevice> devices)
    {
      _devices = devices.ToImmutableArray();
    }

    public void Add(int value)
    {
      Noop();
      Noop();
      _register += value;
    }

    public void Noop()
    {
      _cycle++;

      CheckSignalsToRecord();
    }

    private void CheckSignalsToRecord()
    {
      foreach (var device in _devices)
      {
        device.Tick(_cycle, _register);
      }
    }
  }
}