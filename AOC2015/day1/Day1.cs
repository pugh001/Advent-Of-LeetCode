using Utility;

namespace AOC2015;

public class Day1
{
  public static (string, string) Process(string input)
  {
    var data = SetupInputFile.OpenFile(input).First();
    var bracketsClose = data.Count(x => x == ')');
    var bracketsOpen = data.Count(x => x == '(');
    var resultPart1 = bracketsOpen - bracketsClose;

    var liftPosition = 0;
    var resultPart2 = 1;
    foreach (var move in data)
    {
      if (move == '(') liftPosition++;
      if (move == ')') liftPosition--;
      if (liftPosition < 0) break;

      resultPart2++;
    }
    
    return (resultPart1.ToString(), resultPart2.ToString());
  }
}