using Advent._04.Program;
using Xunit;

namespace Advent._04.Tests
{
  public class PassportTests
  {
    [Theory]
    [InlineData(@"byr:1998
ecl:hzl
cid:178 hcl:#a97842 iyr:2014 hgt:166cm pid:594143498 eyr:2030")]
    [InlineData(@"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f")]
    [InlineData(@"eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm")]
[InlineData(@"hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    public void ValidPassports(string passportPhrase)
    {
      var p = Passport.FromPhrase(passportPhrase);
      Assert.True(p.IsValid());
    }

    [Theory]
    [InlineData(@"hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007")]
    public void Invalid(string passportPhrase) => Assert.False(Passport.FromPhrase(passportPhrase).IsValid());

    //iyr
    [Theory]
    [InlineData(@"iyr:2009 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2021 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    public void InvalidIssuedYear(string passportPhrase) => Assert.False(Passport.FromPhrase(passportPhrase).IsValid());

    //hgt
    [Theory]
    [InlineData(@"iyr:2010 hgt:149cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:194cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:58in hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:79in hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:71inch hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:in hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    public void InvalidHeight(string passportPhrase) => Assert.False(Passport.FromPhrase(passportPhrase).IsValid());

    //hcl
    [Theory]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652ab ecl:blu byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#g6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#a6652 ecl:blu byr:1944 eyr:2021 pid:093154719")]
    public void InvalidHairColour(string passportPhrase) => Assert.False(Passport.FromPhrase(passportPhrase).IsValid());

    //ecl
    [Theory]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blue byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:red byr:1944 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:gr byr:1944 eyr:2021 pid:093154719")]
    public void InvalidEyeColour(string passportPhrase) => Assert.False(Passport.FromPhrase(passportPhrase).IsValid());

    //byr
    [Theory]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1919 eyr:2021 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:2003 eyr:2021 pid:093154719")]
    public void InvalidBirthYear(string passportPhrase) => Assert.False(Passport.FromPhrase(passportPhrase).IsValid());

    //eyr
    [Theory]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2019 pid:093154719")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2031 pid:093154719")]
    public void InvalidExpiryYear(string passportPhrase) => Assert.False(Passport.FromPhrase(passportPhrase).IsValid());


    //pid
    [Theory]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:x")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:93154719")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:0093154719")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:00000000")]
    [InlineData(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:00000000a")]
    public void InvalidPassportID(string passportPhrase) => Assert.False(Passport.FromPhrase(passportPhrase).IsValid());
  }
}