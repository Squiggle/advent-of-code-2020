using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent._04.Program
{
  class Program
  {
    static async Task Main(string[] args)
    {

      using (var sr = new StreamReader("data.txt"))
      {
        var passports = PassportStream.Read(sr)
          .Select(Passport.FromPhrase)
          .Where(p => p.IsValid());
        Console.WriteLine("{0} valid passports", await passports.CountAsync());
      }
    }
  }
}
