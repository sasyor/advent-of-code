using System.Collections.Generic;
using System.Linq;

namespace AoC2022Day7
{
  public class Dir
  {
    public static Dir Root { get; } = new(null);

    private readonly Dictionary<string, File> _files = new();
    private readonly Dictionary<string, Dir> _children = new();

    public Dir Parent { get; }

    public IReadOnlyList<Dir> Children => _children.Values.ToArray();

    public IReadOnlyList<Dir> FlattenedChildren =>
      Children.Concat(Children.SelectMany(d => d.FlattenedChildren)).ToArray();

    public int Size => _files.Sum(f => f.Value.Size) + _children.Sum(d => d.Value.Size);

    public Dir(Dir parent)
    {
      Parent = parent;
    }

    public Dir Navigate(string name)
    {
      if (name == "..")
      {
        return Parent;
      }

      if (_children.TryGetValue(name, out var existingChild))
      {
        return existingChild;
      }

      var newChild = new Dir(this);
      _children.Add(name, newChild);
      return newChild;
    }

    public void AddFile(string line)
    {
      var file = File.Create(line);
      _files.Add(file.Name, file);
    }
  }
}