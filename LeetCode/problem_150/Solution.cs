using Xunit;

namespace LeetCode.problem_150;

public class Solution
{
  [Fact]
  public void Solution_Test1()
  {
    var solution = new Solution();
    // Arrange
    string[] tokens = ["2", "1", "+", "3", "*"];
    int expected = 9;

    // Act
    int result = solution.EvalRPN(tokens);

    // Assert
    Assert.Equal(expected, result);
  }

  [Fact]
  public void Solution_Test2()
  {
    var solution = new Solution();
    // Arrange
    string[] tokens = ["4", "13", "5", "/", "+"];
    int expected = 6;

    // Act
    int result = solution.EvalRPN(tokens);

    // Assert
    Assert.Equal(expected, result);
  }

  [Fact]
  public void Solution_Test3()
  {
    var solution = new Solution();
    // Arrange
    string[] tokens = ["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"];
    int expected = 22;

    // Act
    int result = solution.EvalRPN(tokens);

    // Assert
    Assert.Equal(expected, result);
  }


  public int EvalRPN(string[] tokens)
  {
    //I originally used a switch and checked tokens, but as something different ChatGPT
    // suggested the Dictionary, it makes code more readable but think could be faster.
    //Removed the check if token is +-*/ but try parse as integer, comes out a bit faster
    // Now parse number and loop, if not number do sum.
    // Time on LeetCode dropped from 12ms to 9ms and now better.
    
    var runningTotal = new Stack<int>();
    //Switched B, A as input into function then it is in stack order not logical
    //Made no speed impact!
    var operations = new Dictionary<string, Func<int, int, int>>
    {
      { "+", (b,a) => a + b },
      { "-", (b,a) => a - b },
      { "*", (b,a) => a * b },
      { "/", (b,a) => a / b }
    };

    foreach (string token in tokens)
    {
      if (int.TryParse(token, out int number))
      {
        runningTotal.Push(number);
        continue;
      }
      runningTotal.Push(operations[token](runningTotal.Pop(), runningTotal.Pop()));
    }

    return runningTotal.Pop();
  }
}