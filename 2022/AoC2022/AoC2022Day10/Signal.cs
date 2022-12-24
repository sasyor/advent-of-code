namespace AoC2022Day10
{
  public class Signal
  {
    public int Strength => Cycle * Value;
    public int Value { get; set; }
    public int Cycle { get; }

    public Signal(int cycle)
    {
      Cycle = cycle;
    }
  }
}