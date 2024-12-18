namespace AOC2024.Utility;

public class TestFiles
{
  public static string GetInputData(int day, string myFile)
  {
    var fileHandler = new SetupInputFile();
    string path = SetupInputFile.GetSolutionDirectory();
    string fileOne = $"{path}/AOC2024/day{day}/{myFile}";
    return fileOne;
  }
}