using System.Collections.Generic;

namespace AoC2022Day3
{
  public class ItemComparer : IComparer<Item>
  {
    public int Compare(Item x, Item y)
    {
      if (ReferenceEquals(x, y)) return 0;
      if (ReferenceEquals(null, y)) return 1;
      if (ReferenceEquals(null, x)) return -1;
      return x.Priority.CompareTo(y.Priority);
    }
  }
}