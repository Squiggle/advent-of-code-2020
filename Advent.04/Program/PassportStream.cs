using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent._04.Program
{
  public static class PassportStream
  {
    public static async IAsyncEnumerable<string> Read(StreamReader sr)
    {
      var passportLine = new StringBuilder();
      var eof = false;
      while (!eof)
      {
        var line = await sr.ReadLineAsync();
        if (!string.IsNullOrEmpty(line))
        {
          passportLine.AppendLine(line);
        }
        else
        {
          var fullLine = passportLine.ToString();
          passportLine = new StringBuilder();
          yield return fullLine;
        }
        eof = line == null;
      }
      if (passportLine.Length > 0)
      {
        yield return passportLine.ToString();
      }
    }
  }
}