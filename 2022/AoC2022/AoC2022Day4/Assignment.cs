using System;

namespace AoC2022Day4
{
  public class Assignment
  {
    public int SectionStart { get; }
    public int SectionEnd { get; }

    public Assignment(int sectionStart, int sectionEnd)
    {
      SectionStart = sectionStart;
      SectionEnd = sectionEnd;
    }

    public static Assignment Create(string input)
    {
      var data = input.Split('-');
      if (data.Length < 2)
      {
        throw new ArgumentException();
      }

      return new Assignment(int.Parse(data[0]), int.Parse(data[1]));
    }
  }
}