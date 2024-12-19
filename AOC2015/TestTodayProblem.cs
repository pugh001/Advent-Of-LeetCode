using Utility;
using Xunit;
using Xunit.Abstractions;

namespace AOC2015;

public class TestProblems
{
  private readonly ITestOutputHelper _testOutputHelper;

  public TestProblems(ITestOutputHelper testOutputHelper)
  {
    _testOutputHelper = testOutputHelper;
  }

  public static IEnumerable<object[]> GetTestCases()
  {
    var fileHandler = new SetupInputFile();
    string path = SetupInputFile.GetSolutionDirectory();
    string testDataFile = Path.Combine(path, "AOC2015", "Answers", "TestData.txt");

    var lines = File.ReadAllLines(testDataFile).Skip(1) // Skip header row
      .Where(line => !string.IsNullOrWhiteSpace(line));

    foreach (string line in lines.Reverse())
    {
      string[] parts = line.Split('|');
      string day = parts[0].PadLeft(2, '0');
      yield return new object[] { day, parts[1], parts[2] };
    }
  }

  [Theory]
  [MemberData(nameof(GetTestCases))]
  public void TestPart1(string dayStr, string expectedAnswer1, string _)
  {
    int day = int.Parse(dayStr);
    int year = 2015;
    string filePart1 = TestFiles.GetInputData(day, year, "Part1Example.txt");

    var dayType = Type.GetType($"AOC{year}.Day{day}");
    if (dayType == null)
    {
      throw new InvalidOperationException($"Type AOC{year}.Day{day} not found.");
    }

    object? dayInstance = Activator.CreateInstance(dayType);
    var methodInfo = dayType.GetMethod("Process");
    if (methodInfo == null)
    {
      throw new InvalidOperationException("Process method not found.");
    }

    var result1 = (ValueTuple<string, string>)methodInfo.Invoke(dayInstance, new object[] { filePart1 });
    _testOutputHelper.WriteLine($"Day {day} Part 1: {result1.Item1}");

    // Assert results
    Assert.Equal(expectedAnswer1, result1.Item1);
  }

  [Theory]
  [MemberData(nameof(GetTestCases))]
  public void TestPart2(string dayStr, string _, string expectedAnswer2)
  {

    int day = int.Parse(dayStr);
    int year = 2015;
    string filePart2 = TestFiles.GetInputData(day, year, "Part2Example.txt");

    var dayType = Type.GetType($"AOC{year}.Day{day}");
    if (dayType == null)
    {
      throw new InvalidOperationException($"Type AOC{year}.Day{day} not found.");
    }

    object? dayInstance = Activator.CreateInstance(dayType);
    var methodInfo = dayType.GetMethod("Process");
    if (methodInfo == null)
    {
      throw new InvalidOperationException("Process method not found.");
    }

    var result2 = (ValueTuple<string, string>)methodInfo.Invoke(dayInstance, new object[] { filePart2 });
    _testOutputHelper.WriteLine($"Day {day} Part 2: {result2.Item2}");

    // Assert results
    Assert.Equal(expectedAnswer2, result2.Item2);
  }
}