using System;
using System.Linq;
using System.Threading.Tasks;
using Advent.Common;

namespace Advent._05.Program
{
  class Program
  {
    static async Task Main(string[] args)
    {
      // highest seat ID in the source data
      // convert "FBFBFB" notation to binary
      var seats = await AsyncFileReader.ReadLines("data.txt")
        .Select(Seat.FromString)
        .ToListAsync();
      var maxSeatID = seats.Max(s => s.SeatID);
      Console.WriteLine("Max seatID is {0}", maxSeatID);

      // find the unoccupied seats
      var allSeats = Enumerable.Range(0, maxSeatID)
        .ToDictionary(n => n, n => seats.SingleOrDefault(s => s.SeatID == n));
      Console.WriteLine("Missing seats:");
      foreach (var index in allSeats.Where(kvp => kvp.Value == null))
      {
        Console.WriteLine(index.Key);
      }
    }
  }
}
