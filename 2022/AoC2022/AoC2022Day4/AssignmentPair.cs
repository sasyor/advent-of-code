using System;

namespace AoC2022Day4
{
  public class AssignmentPair
  {
    private readonly Assignment _firstAssignment;
    private readonly Assignment _secondsAssignment;

    public AssignmentPair(Assignment firstAssignment, Assignment secondsAssignment)
    {
      _firstAssignment = firstAssignment;
      _secondsAssignment = secondsAssignment;
    }

    public AssignmentContainType CompareAssignments()
    {
      if (IsPartialOverLap(_firstAssignment, _secondsAssignment) ||
          IsPartialOverLap(_secondsAssignment, _firstAssignment))
      {
        if (IsFullOverlap(_firstAssignment, _secondsAssignment) || IsFullOverlap(_secondsAssignment, _firstAssignment))
        {
          return AssignmentContainType.Full;
        }

        return AssignmentContainType.Partial;
      }

      return AssignmentContainType.None;
    }

    private bool IsFullOverlap(Assignment subject, Assignment other)
    {
      return other.SectionStart <= subject.SectionStart &&
             subject.SectionEnd <= other.SectionEnd;
    }

    private bool IsPartialOverLap(Assignment subject, Assignment other)
    {
      return (other.SectionStart <= subject.SectionStart &&
              subject.SectionStart <= other.SectionEnd) ||
             (other.SectionEnd <= subject.SectionEnd && subject.SectionStart <= other.SectionStart);
    }

    public static AssignmentPair Create(string input)
    {
      var data = input.Split(',');
      if (data.Length < 2)
      {
        throw new ArgumentException();
      }

      return new AssignmentPair(Assignment.Create(data[0]), Assignment.Create(data[1]));
    }
  }
}