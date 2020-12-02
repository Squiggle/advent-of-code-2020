using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Advent._02
{
  class Program
  {
    static void Main(string[] args)
    {
      var oldMatches = ReadFile()
        .Select(line => Policy.FromString(line))
        .Count(policy => policy.Matches(OldPolicy));
      Console.WriteLine("{0} old policies match passwords", oldMatches);

      var newMatches = ReadFile()
        .Select(line => Policy.FromString(line))
        .Count(policy => policy.Matches(TobogganPolicy));
      Console.WriteLine("{0} new policies match passwords", newMatches);
    }

    public static string PasswordFromString(string passwordStr)
    {
      return passwordStr.Trim();
    }

    private static IEnumerable<string> ReadFile()
    {
      using (var sr = new StreamReader("data.txt"))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          yield return line;
        }
      }
    }

    private static bool OldPolicy(Policy policy)
    {
      var charCount = policy.Password.Count(c => c == policy.Char);
      return policy.Min <= charCount && charCount <= policy.Max;
    }

    private static bool TobogganPolicy(Policy policy)
    {
      if (policy.Password.Length < policy.Max
      || policy.Password.Length < policy.Min)
      {
        Console.WriteLine("avoided overflow; {0} or {1} exceeds password {2} of length {3}", policy.Min, policy.Max, policy.Password, policy.Password.Length);
        return false;
      }
      if (policy.Password[policy.Min - 1] == policy.Char
       ^ policy.Password[policy.Max - 1] == policy.Char)
      {
        Console.WriteLine("Match. {0} appears in either {1} or {2} of '{3}", policy.Char, policy.Min, policy.Max, policy.Password);
        return true;
      }
      return false;
    }
  }

  public class Policy
  {
    private Policy() { }

    public int Min { get; init; }
    public int Max { get; init; }
    public char Char { get; init; }
    public string Password { get; init; }

    public static Policy FromString(string line)
    {
      var parts = line.Split(":");
      var policyParts = line.Trim().Split(" ");
      var minMax = policyParts[0].Split("-");
      return new Policy
      {
        Min = Convert.ToInt32(minMax[0]),
        Max = Convert.ToInt32(minMax[1]),
        Char = policyParts[1][0],
        Password = parts[1].Trim()
      };
    }

    public bool Matches(Func<Policy, bool> policyCalc)
    {
      return policyCalc(this);
    }
  }
}
