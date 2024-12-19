using System.Diagnostics;
using Utility;

namespace AOC2015;

static internal class Program
{
  public static void Main(string[] args)
  {
    for (int day = 18; day > 0; day--)
    {
      try
      {
        string inputFilePath = TestFiles.GetInputData(day, 2015, "puzzleInput.txt");
        object? dayInstance =
          Activator.CreateInstance(Type.GetType($"AOC2015.Day{day}") ?? throw new InvalidOperationException());
        Console.WriteLine("");
        Console.Write("Day " + day.ToString().PadLeft(2, ' ') + ":");
        var stopWatch = Stopwatch.StartNew();
        Console.Write(dayInstance.GetType().GetMethod("Process").Invoke(dayInstance, new object[] { inputFilePath }));
        stopWatch.Stop();
        Console.Write($"  Time:  {stopWatch.Elapsed}");
      }
      catch (InvalidOperationException)
      {
        //No Day# code yet
        Console.Write("");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
        break;
      }
    }
  }
}