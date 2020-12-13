using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Advent._03
{
  public class Map
  {
    public Row[] Rows { get; init; }

    public static Map Load(string filename)
    {
      var rows = new List<Row>();
      using (var sr = new StreamReader("data.txt"))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          rows.Add(new Row
          {
            Obstacles = line.Select(x => x == '#' ? true : false).ToArray()
          });
        }
      }
      return new Map
      {
        Rows = rows.ToArray()
      };
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var row in Rows)
      {
        sb.AppendLine(String.Join("", row.Obstacles.Select(x => x ? '#' : '.')));
      }
      return sb.ToString();
    }
  }

  public class Row
  {
    public bool[] Obstacles
    {
      get; init;
    }
    public bool this[int i]
    {
      get => Obstacles[i % Obstacles.Length];
      set { }
    }
  }
}