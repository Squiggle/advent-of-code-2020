using Advent._04.Program;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Advent._04.Tests
{
  public class ParsingTests
  {
    [Fact]
    public async void CanParseMultipleLines()
    {
      var testString = @"abc
def

123
456

foo

b
a
r";
      var memStream = new MemoryStream(Encoding.UTF8.GetBytes(testString));
      using (var sr = new StreamReader(memStream))
      {
        var results = await PassportStream.Read(sr).ToListAsync();
        Assert.Equal(4, results.Count);
        Assert.Equal("abc def", results[0]);
        Assert.Equal("123 456", results[1]);
        Assert.Equal("foo", results[2]);
        Assert.Equal("b a r", results[3]);
      }
    }
  }
}