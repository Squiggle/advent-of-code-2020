using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Advent._04.Program
{
  public class Passport
  {
    public static Passport FromPhrase(string line)
    {
      var parts = line
        .Replace(Environment.NewLine, " ")
        .Trim()
        .Split(" ");
      var dict = parts.Select(p => p.Split(":")).ToDictionary(kvp => kvp[0], kvp => kvp[1]);

      var passport = new Passport
      {
        BirthYear = TryGet(dict, "byr"),
        IssueYear = TryGet(dict, "iyr"),
        ExpirationYear = TryGet(dict, "eyr"),
        Height = TryGet(dict, "hgt"),
        HairColor = TryGet(dict, "hcl"),
        EyeColor = TryGet(dict, "ecl"),
        PassportID = TryGet(dict, "pid"),
        Source = line
      };
      // Console.WriteLine(passport.BirthYear);
      return passport;
    }

    static string TryGet(Dictionary<string, string> dict, string key, string defaultStr = null)
    {
      var def = string.IsNullOrEmpty(defaultStr) ? null : defaultStr;
      return dict.ContainsKey(key) ? dict[key] : def;
    }

    public string Source { get; init; }

    [Required]
    [Range(1920, 2002)]
    public string BirthYear { get; init; }

    [Required]
    [Range(2010, 2020)]
    public string IssueYear { get; init; }

    [Required]
    [Range(2020, 2030)]
    public string ExpirationYear { get; init; }

    [Required]
    [Height(150, 193, 59, 76)]
    public string Height { get; init; }

    [Required]
    [RegularExpression(@"^#[0-9a-f]{6}$")]
    public string HairColor { get; init; }

    [Required]
    [RegularExpression(@"^(amb|blu|brn|gry|grn|hzl|oth)$")]
    public string EyeColor { get; init; }

    [Required]
    [RegularExpression(@"^\d{9}$")]
    public string PassportID { get; init; }

    public bool IsValid()
    {
      var context = new ValidationContext(this);
      var results = new List<ValidationResult>();
      var valid = Validator.TryValidateObject(this, context, results, true);
      // if (results.Count == 1)
      // {
      //   Console.WriteLine(Source);
      //   Console.WriteLine(String.Join(", ", results));
      //   Console.WriteLine("===");
      // }
      return valid;
    }
  }
}