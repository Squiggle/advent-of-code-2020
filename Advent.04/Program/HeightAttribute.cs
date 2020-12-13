using System;
using System.ComponentModel.DataAnnotations;

namespace Advent._04.Program
{
  [AttributeUsage(AttributeTargets.Property, Inherited = false)]
  public class HeightAttribute : ValidationAttribute
  {
    public HeightAttribute(int minCm, int maxCm, int minIn, int maxIn)
    {
      MinCm = minCm;
      MaxCm = maxCm;
      MinIn = minIn;
      MaxIn = maxIn;
    }

    public int MinCm { get; set; }
    public int MaxCm { get; set; }
    public int MinIn { get; set; }
    public int MaxIn { get; set; }

    public override bool IsValid(object value)
    {
      var height = value as string;
      if (string.IsNullOrEmpty(height))
      {
        return false;
      }

      // cm
      if (height.EndsWith("cm"))
      {
        int val;
        if (Int32.TryParse(height.Replace("cm", ""), out val))
        {
          return val >= MinCm && val <= MaxCm;
        }
        return false;
      }
      else if (height.EndsWith("in"))
      {
        return (int.TryParse(height.Substring(0, height.Length - 2), out var val))
          && val >= MinIn && val <= MaxIn;
      }
      Console.WriteLine("Height neither matched {0}", value);
      return false;
    }
  }
}