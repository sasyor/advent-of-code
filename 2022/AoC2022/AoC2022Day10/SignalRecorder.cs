using System.Collections.Generic;
using System.Collections.Immutable;

namespace AoC2022Day10
{
  public class SignalRecorder : IDevice
  {
    private readonly ImmutableDictionary<int, Signal> _signalsToRecord;

    public SignalRecorder(IEnumerable<Signal> signalsToRecord)
    {
      _signalsToRecord = signalsToRecord.ToImmutableDictionary(x => x.Cycle);
    }

    public void Tick(int cycle, int register)
    {
      if (_signalsToRecord.TryGetValue(cycle, out var signal))
      {
        signal.Value = register;
      }
    }
  }
}