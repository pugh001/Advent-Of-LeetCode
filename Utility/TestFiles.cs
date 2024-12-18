namespace Utility;

public class TestFiles
{
  public static string GetInputData(int day, int year, string myFile)
  {
    var fileHandler = new SetupInputFile();
    string path = SetupInputFile.GetSolutionDirectory();
    string fileOne = $"{path}/AOC{year}/day{day}/{myFile}";
    return fileOne;
  }
}