using System;
using System.IO;
using System.Linq;

namespace AoC2022Day10
{
  class Program
  {
    private static void Main()
    {
      var signals = new Signal[]
      {
        new(20),
        new(60),
        new(100),
        new(140),
        new(180),
        new(220),
      };
      var signalRecorder = new SignalRecorder(signals);

      var crt = new Crt(new[] { 40, 80, 120, 160, 200, 240 });

      var cpu = new Cpu(new IDevice[] { signalRecorder, crt });

      foreach (var line in File.ReadLines("input.txt"))
      {
        if (line == "noop")
        {
          cpu.Noop();
        }
        else if (line.StartsWith("addx"))
        {
          cpu.Add(int.Parse(line.Split(' ')[1]));
        }
      }

      Console.WriteLine(
        $"Sum of signals' [{string.Join(", ", signals.Select(x => x.Cycle + "*" + x.Value))}] strengths: {signals.Sum(x => x.Strength)}");
      Console.WriteLine("Image is:");
      Console.WriteLine(crt.GetImage()); // RZHFGJCB
    }
  }
}