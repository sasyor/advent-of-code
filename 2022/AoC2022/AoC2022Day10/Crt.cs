using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace AoC2022Day10
{
  public class Crt : IDevice
  {
    private readonly ImmutableArray<int> _rowEnds;

    private ImmutableArray<StringBuilder> _lines = Enumerable.Range(0, 6)
      .Select(x => new StringBuilder(new string('.', 40)))
      .ToImmutableArray();

    private int _currentLine = 0;
    private int _currentPixel = 0;

    public Crt(IEnumerable<int> rowEnds)
    {
      _rowEnds = rowEnds.ToImmutableArray();
    }

    public void Tick(int cycle, int register)
    {
      if (Math.Abs(_currentPixel - register) <= 1)
      {
        _lines[_currentLine][_currentPixel] = '#';
      }

      if (_rowEnds.Contains(cycle))
      {
        _currentLine++;
        _currentPixel = 0;
      }
      else
      {
        _currentPixel++;
      }
    }

    public string GetImage()
    {
      return string.Join(Environment.NewLine, _lines.Select(x => x.ToString()));
    }
  }
}