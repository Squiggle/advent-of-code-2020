using System;
using System.Linq;
using System.Collections.Generic;

namespace Advent._03
{
  class Program
  {
    static void Main(string[] args)
    {
      var map = Map.Load("data.txt");
      Console.WriteLine("Map:");
      Console.WriteLine(map);

      // traverse
      Console.WriteLine("Let's start!");
      var runs = new List<Run> {
        new Run(1, 1),
        new Run(3, 1),
        new Run(5, 1),
        new Run(7, 1),
        new Run(1, 2)
      };

      foreach (var run in runs)
      {
        Console.WriteLine("Run {0} hits {1} trees", run, Launch(map, run));
      }

      // and calc the tally multiplied
      Console.WriteLine("Tallies multiplied = {0}", runs.Select(r => Launch(map, r)).Aggregate(1L, (a, b) => a * b));
    }

    private static int Launch(Map map, Run run)
    {
      var (x, y) = (0, 0);
      var trees = 0;
      for (var i = 0; i < map.Rows.Length; i += run.Down)
      {
        if (map.Rows[i][x])
        {
          trees++;
        };
        x += run.Right;
      }
      return trees;
    }

    public class Run
    {
      public Run(int r, int d)
      {
        Right = r;
        Down = d;
      }
      public int Right { get; }
      public int Down { get; }

      public override string ToString()
      {
        return String.Format("{0},{1}", Right, Down);
      }
    }
  }
}
