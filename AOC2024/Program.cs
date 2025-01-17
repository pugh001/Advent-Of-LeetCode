﻿using System.Diagnostics;
using Utility;

namespace AOC2024;

static internal class Program
{
  public static void Main(string[] args)
  {
    for (int day = 26; day > 0; day--)
    {
      try
      {
        string inputFilePath = TestFiles.GetInputData(day, 2024, "puzzleInput.txt");

        // Create an instance of the Day## class dynamically
        object? dayInstance =
          Activator.CreateInstance(Type.GetType($"AOC2024.Day{day}") ?? throw new InvalidOperationException());

        if (dayInstance == null)
        {
          Console.WriteLine($"Day{day} class could not be instantiated.");
          continue;
        }

        Console.WriteLine("");
        Console.Write("Day " + day.ToString().PadLeft(2, ' ') + ":");

        // Retrieve the Process method dynamically
        var processMethod = dayInstance.GetType().GetMethod("Process");
        if (processMethod == null)
        {
          Console.WriteLine($"Process method not found in Day{day}.");
          continue;
        }

        var stopWatch = Stopwatch.StartNew();

        // Invoke the Process method on the instance
        object? result = processMethod.Invoke(dayInstance, new object[] { inputFilePath });

        stopWatch.Stop();

        // Display the result of the Process method
        Console.Write(result);
        Console.Write($"  Time:  {stopWatch.Elapsed}");
      }
      catch (InvalidOperationException)
      {
        // No Day# code yet
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