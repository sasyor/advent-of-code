using System.Collections.Generic;

namespace AoC2022Day1
{
  public class ElfCalorieComparer: IComparer<Elf>
  {
    public int Compare(Elf x, Elf y)
    {
      if (ReferenceEquals(x, y)) return 0;
      if (ReferenceEquals(null, y)) return 1;
      if (ReferenceEquals(null, x)) return -1;
      return -x.Calories.CompareTo(y.Calories);
    }
  }
}