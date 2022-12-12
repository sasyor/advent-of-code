namespace AoC2022Day8
{
  public class Tree
  {
    public bool IsVisible { get; set; }

    public int ScenicScore { get; set; } = 1;

    public int Height { get; }

    public Tree(int height)
    {
      Height = height;
    }

    public override string ToString()
    {
      var isVisibleString = IsVisible ? "V" : "H";
      return $"[{Height},{isVisibleString}]";
    }
  }
}