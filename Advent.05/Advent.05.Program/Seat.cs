using System;

namespace Advent._05.Program
{
  public class Seat
  {
    public static Seat FromString(string source)
    {
      var row = Convert.ToInt32(source
        .Substring(0, 7)
        .Replace("B", "1")
        .Replace("F", "0"),
        2);
      var column = Convert.ToInt32(
        source.Substring(7, 3)
        .Replace("R", "1").Replace("L", "0"),
        2
      );
      return new Seat
      {
        Source = source,
        Row = row,
        Column = column
      };
    }

    public string Source { get; init; }

    public int Row { get; init; }

    public int Column { get; init; }

    public int SeatID
    {
      get => (Row * 8) + Column;
    }

    public override string ToString() => $"Row {Row}, Seat {Column}: ID {SeatID}";
  }
}