using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2022Day8
{
  public class Forest
  {
    private int _idxInLine = -1;
    private int _lineIdx = 0;

    private readonly List<List<Tree>> _treeLines = new() { new List<Tree>() };

    public void AddTree(int height, bool isAlwaysVisible)
    {
      _idxInLine++;

      var tree = new Tree(height)
      {
        IsVisible = isAlwaysVisible
      };
      _treeLines.Last().Add(tree);
    }

    public void AddLine()
    {
      _treeLines.Add(new List<Tree>());

      _idxInLine = -1;
      _lineIdx++;
    }

    public void UpdateTrees()
    {
      for (int lineIdx = 1; lineIdx < _treeLines.Count - 1; lineIdx++)
      {
        var horizontalTreeLine = _treeLines[lineIdx];
        for (int idxInLine = 1; idxInLine < horizontalTreeLine.Count - 1; idxInLine++)
        {
          UpdateTree(lineIdx, idxInLine);
        }
      }
    }

    private void UpdateTree(int lineIdx, int idxInLine)
    {
      var checkedTree = _treeLines[lineIdx][idxInLine];
      UpdateTreeFromCheckedTreeToOtherTrees(checkedTree, GetEnumerableToTopTree(lineIdx, idxInLine));
      UpdateTreeFromCheckedTreeToOtherTrees(checkedTree, GetEnumerableToBottomTree(lineIdx, idxInLine));
      UpdateTreeFromCheckedTreeToOtherTrees(checkedTree, GetEnumerableToLeftTree(lineIdx, idxInLine));
      UpdateTreeFromCheckedTreeToOtherTrees(checkedTree, GetEnumerableToRightTree(lineIdx, idxInLine));
    }

    private void UpdateTreeFromCheckedTreeToOtherTrees(Tree checkedTree, IEnumerable<Tree> otherTrees)
    {
      var visibleFromOutside = true;
      var seenTrees = 0;
      var sceneryBlocked = false;
      foreach (var otherTree in otherTrees)
      {
        if (!sceneryBlocked)
        {
          seenTrees++;
          if (otherTree.Height >= checkedTree.Height)
          {
            sceneryBlocked = true;
          }
        }

        if (otherTree.Height >= checkedTree.Height)
        {
          visibleFromOutside = false;
        }
      }

      checkedTree.IsVisible |= visibleFromOutside;
      checkedTree.ScenicScore *= seenTrees;
    }

    private IEnumerable<Tree> GetEnumerableToTopTree(int startLineIdx, int idxInLine)
    {
      for (int lineIdx = startLineIdx - 1; lineIdx >= 0; lineIdx--)
      {
        yield return _treeLines[lineIdx][idxInLine];
      }
    }

    private IEnumerable<Tree> GetEnumerableToBottomTree(int startLineIdx, int idxInLine)
    {
      for (int lineIdx = startLineIdx + 1; lineIdx < _treeLines.Count; lineIdx++)
      {
        yield return _treeLines[lineIdx][idxInLine];
      }
    }

    private IEnumerable<Tree> GetEnumerableToLeftTree(int lineIdx, int startIdxInLine)
    {
      for (int idxInLine = startIdxInLine - 1; idxInLine >= 0; idxInLine--)
      {
        yield return _treeLines[lineIdx][idxInLine];
      }
    }

    private IEnumerable<Tree> GetEnumerableToRightTree(int lineIdx, int startIdxInLine)
    {
      for (int idxInLine = startIdxInLine + 1; idxInLine < _treeLines[lineIdx].Count; idxInLine++)
      {
        yield return _treeLines[lineIdx][idxInLine];
      }
    }

    public IEnumerable<Tree> GetVisibleTrees()
    {
      return _treeLines.SelectMany(l => l.Select(t => t)).Where(t => t.IsVisible);
    }

    public IEnumerable<Tree> GetAllTrees()
    {
      return _treeLines.SelectMany(l => l);
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      for (var i = 0; i < _treeLines.Count; i++)
      {
        foreach (var tree in _treeLines[i])
        {
          sb.Append(tree);
        }

        if (i != _treeLines.Count - 1)
        {
          sb.AppendLine();
        }
      }

      return sb.ToString();
    }
  }
}