using System.Linq;

namespace AoC2022Day7
{
  public class File
  {
    public string Name { get; }
    public int Size { get; }

    public File(string name, int size)
    {
      Name = name;
      Size = size;
    }

    public static File Create(string line)
    {
      var splitLine = line.Split(' ');
      return new File(string.Join(' ', splitLine.Skip(1)), int.Parse(splitLine[0]));
    }
  }
}