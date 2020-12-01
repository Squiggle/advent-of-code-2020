using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Advent._01
{
  class Program
  {
    static void Main(string[] args)
    {

      var list = Data().OrderBy(x => x).ToList();

      // part one
      var match = FindSingleMatch(list, 2020);

      if (match.Length > 0)
      {
        Console.WriteLine("2020 is {0} + {1}", match[0], match[1]);
        Console.WriteLine("The value we want is {0}", match.Aggregate((a, b) => a * b));
      }
      else
      {
        Console.WriteLine("No matching results");
      }

      // part two
      var multiMatch = FindMultiMatch(list, 2020);
      if (multiMatch.Length == 3)
      {
        Console.WriteLine("2020 is {0} + {1} + {2}", multiMatch[0], multiMatch[1], multiMatch[2]);
        Console.WriteLine("The value summed is {0}", multiMatch.Aggregate((a, b) => a * b));
      }
      else
      {
        Console.WriteLine("No three numbers total 2020");
        Console.WriteLine(multiMatch);
      }
    }

    private static int[] FindSingleMatch(IEnumerable<int> list, int target)
    {
      foreach ((int item, int index) in list.Select((item, index) => (item, index)))
      {
        // calculate the value we need to make the target
        var lookingFor = target - item;
        // look through the rest of the list for the number we need
        if (list.Skip(index).Contains(lookingFor))
        {
          return new int[] { item, lookingFor };
        }
      }
      return new int[] { };
    }

    private static int[] FindMultiMatch(IEnumerable<int> list, int target)
    {
      foreach ((int item, int index) in list.Select((item, index) => (item, index)))
      {
        // calculate the value we need to make the target
        var lookingFor = target - item;
        // look through the rest of the list for the number we need
        var match = FindSingleMatch(list, lookingFor);
        if (match.Length > 0)
        {
          return new int[] { item, match[0], match[1] };
        }
      }
      return new int[] { };
    }

    private static IEnumerable<int> Data()
    {
      using (var sr = new StreamReader("data.txt"))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          yield return Convert.ToInt32(line);
        }
      }
    }
  }
}
