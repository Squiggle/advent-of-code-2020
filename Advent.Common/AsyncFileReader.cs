using System.Collections.Generic;
using System.IO;

namespace Advent.Common
{
  public class AsyncFileReader
  {

    public static async IAsyncEnumerable<string> ReadLines(StreamReader sr)
    {

      bool eof = false;
      while (!eof)
      {
        var line = await sr.ReadLineAsync();
        if (string.IsNullOrEmpty(line))
        {
          eof = true;
        }
        else
        {
          yield return line;
        }
      }
    }

    public static async IAsyncEnumerable<string> ReadLines(string fileName)
    {
      using (var sr = new StreamReader(fileName))
      {
        await foreach (var line in ReadLines(sr))
        {
          yield return line;
        }
      }
    }
  }
}
